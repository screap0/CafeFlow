using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CafeFlow
{
    public partial class Orders : Form
    {
        private HubConnection hubConnection;
        private DatabaseConnection dbConnection;

        public Orders()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            SetupSignalR();
            LoadInitialOrders();
        }

        private async void SetupSignalR()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://31.57.33.58/orderHub", options =>
                {
                    options.UseDefaultCredentials = true;
                })
                .AddJsonProtocol()
                .WithAutomaticReconnect()
                .ConfigureLogging(logging =>
                {
                    logging.AddDebug();
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            // Bağlantı durumu değiştiğinde log ekle
            hubConnection.Closed += async (error) =>
            {
                MessageBox.Show("SignalR bağlantısı kapandı: " + (error?.Message ?? "Bilinmeyen hata"));
                await Task.Delay(5000); // 5 saniye bekle ve yeniden bağlanmayı dene
                await hubConnection.StartAsync();
            };

            hubConnection.On<int, string, int, string, string, decimal, DateTime, string>("ReceiveOrderUpdate", (orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum) =>
            {
                this.Invoke((Action)(() =>
                {
                    AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                    MessageBox.Show($"Yeni sipariş alındı: #{orderId} - {isim}, Durum: {durum}"); // Test için
                }));
            });

            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR bağlantı hatası: " + ex.Message);
            }
        }

        private async Task LoadInitialOrders()
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum " +
                                  "FROM Siparisler ORDER BY siparis_tarihi DESC LIMIT 50";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int orderId = reader.GetInt32(0);
                                string isim = reader.GetString(1);
                                int masaNo = reader.GetInt32(2);
                                string telefon = reader.IsDBNull(3) ? "Yok" : reader.GetString(3);
                                string aciklama = reader.GetString(4);
                                decimal toplamTutar = reader.GetDecimal(5);
                                DateTime siparisTarihi = reader.GetDateTime(6);
                                string durum = reader.GetString(7);

                                AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlangıç siparişleri yüklenirken hata: " + ex.Message);
            }
        }

        private async void AddOrderToPanel(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi, string durum)
        {
            Panel orderPanel = new Panel
            {
                Size = new System.Drawing.Size(300, 220),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblIsim = new Label
            {
                Text = $"İsim: {isim}",
                Location = new System.Drawing.Point(5, 5),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblMasaNo = new Label
            {
                Text = $"Masa: {masaNo}",
                Location = new System.Drawing.Point(5, 25),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblTelefon = new Label
            {
                Text = $"Telefon: {telefon}",
                Location = new System.Drawing.Point(5, 45),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblAciklama = new Label
            {
                Text = $"Açıklama: {aciklama}",
                Location = new System.Drawing.Point(5, 65),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblTutar = new Label
            {
                Text = $"Tutar: {toplamTutar} TL",
                Location = new System.Drawing.Point(5, 85),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblTarih = new Label
            {
                Text = $"Tarih: {siparisTarihi.ToString("dd/MM/yyyy HH:mm")}",
                Location = new System.Drawing.Point(5, 105),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };
            Label lblDurum = new Label
            {
                Text = $"Durum: {durum}",
                Location = new System.Drawing.Point(5, 135),
                AutoSize = true,
                ForeColor = System.Drawing.Color.White
            };

            // Add ComboBox for status selection
            ComboBox statusComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(5, 170),
                Size = new System.Drawing.Size(150, 40),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            statusComboBox.Items.AddRange(new string[] { "Ödeme Tamamlandı", "Hazırlanıyor", "Sipariş Hazır" });

            // Durum değerini temizle ve eşleştir
            string cleanedDurum = durum?.Trim(); // Boşlukları temizle
            if (cleanedDurum != null)
            {
                // Görünmeyen karakterleri temizle (örneğin, yeni satır veya fazladan boşluklar)
                cleanedDurum = cleanedDurum.Replace("\r", "").Replace("\n", "").Trim();
            }

            string matchedDurum = null;
            foreach (string item in statusComboBox.Items)
            {
                if (string.Equals(item, cleanedDurum, StringComparison.CurrentCultureIgnoreCase))
                {
                    matchedDurum = item; // Eşleşen durumu bul
                    break;
                }
            }

            // Eşleşme varsa combobox'ta seç, yoksa varsayılan olarak "Ödeme Tamamlandı" seç
            if (matchedDurum != null)
            {
                statusComboBox.SelectedItem = matchedDurum;
            }
            else
            {
                // Eşleşme başarısızsa, durumu manuel olarak standart bir formata çevirmeyi dene
                if (cleanedDurum != null)
                {
                    if (cleanedDurum.ToLower().Contains("hazirlaniyor"))
                        matchedDurum = "Hazırlanıyor";
                    else if (cleanedDurum.ToLower().Contains("siparis hazir"))
                        matchedDurum = "Sipariş Hazır";
                    else if (cleanedDurum.ToLower().Contains("odeme tamamlandi"))
                        matchedDurum = "Ödeme Tamamlandı";
                }

                if (matchedDurum != null)
                {
                    statusComboBox.SelectedItem = matchedDurum;
                }
                else
                {
                    statusComboBox.SelectedIndex = 0; // İlk seçenek: "Ödeme Tamamlandı"
                    MessageBox.Show($"Sipariş #{orderId} için durum '{durum}' eşleşmedi. Varsayılan olarak 'Ödeme Tamamlandı' seçildi. Veritabanı durumu: '{durum}'");
                }
            }

            // lblDurum ile statusComboBox'ın tutarlı olduğundan emin ol
            lblDurum.Text = $"Durum: {statusComboBox.SelectedItem.ToString()}";

            // Handle status change
            statusComboBox.SelectedIndexChanged += async (sender, e) =>
            {
                string newStatus = statusComboBox.SelectedItem.ToString();
                lblDurum.Text = $"Durum: {newStatus}";

                try
                {
                    // Update the status in the database
                    using (var connection = dbConnection.GetConnection())
                    {
                        await connection.OpenAsync();
                        string query = "UPDATE Siparisler SET durum = @durum WHERE id = @orderId";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@durum", newStatus);
                            command.Parameters.AddWithValue("@orderId", orderId);
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Durum güncellenirken hata: " + ex.Message);
                }
            };

            orderPanel.Controls.Add(lblIsim);
            orderPanel.Controls.Add(lblMasaNo);
            orderPanel.Controls.Add(lblTelefon);
            orderPanel.Controls.Add(lblAciklama);
            orderPanel.Controls.Add(lblTutar);
            orderPanel.Controls.Add(lblTarih);
            orderPanel.Controls.Add(lblDurum);
            orderPanel.Controls.Add(statusComboBox);

            // Add the panel to FlowLayoutPanel (side by side, wraps to next row)
            orderLayoutPanel.Controls.Add(orderPanel);
            orderLayoutPanel.Controls.SetChildIndex(orderPanel, 0);
            orderLayoutPanel.Refresh();
            orderLayoutPanel.Invalidate(); // Redraw the panel
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            hubConnection?.StopAsync().Wait();
            base.OnFormClosing(e);
        }
    }
}
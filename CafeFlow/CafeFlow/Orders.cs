using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO; 

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
                .WithUrl("http://31.57.33.58:8080/orderHub", options =>
                {
                    options.UseDefaultCredentials = true;
                })
                .AddJsonProtocol()
                .WithAutomaticReconnect()
                .Build();

            hubConnection.Closed += async (error) =>
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("SignalR bağlantısı kapandı: " + (error?.Message ?? "Bilinmeyen hata"));
                    File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] SignalR bağlantısı kapandı: {error?.Message ?? "Bilinmeyen hata"}\n");
                }));
                await Task.Delay(5000);
                await hubConnection.StartAsync();
            };

            hubConnection.Reconnected += async (connectionId) =>
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("SignalR bağlantısı yeniden kuruldu: " + connectionId);
                    File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] SignalR bağlantısı yeniden kuruldu: {connectionId}\n");
                }));
            };

            hubConnection.On<int, string, int, string, string, decimal, DateTime, string>("ReceiveOrderUpdate", (orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum) =>
            {
                this.Invoke((Action)(() =>
                {
                    bool found = false;
                    foreach (Control control in orderLayoutPanel.Controls)
                    {
                        if (control is Panel panel && (int)panel.Tag == orderId)
                        {
                            orderLayoutPanel.Controls.Remove(panel);
                            AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                    }
                    MessageBox.Show($"Yeni sipariş alındı: #{orderId} - {isim}, Durum: {durum}");
                    File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] Yeni sipariş alındı: #{orderId} - {isim}, Durum: {durum}\n");
                    File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] orderLayoutPanel.Controls.Count: {orderLayoutPanel.Controls.Count}\n");
                }));
            });

            try
            {
                await hubConnection.StartAsync();
                MessageBox.Show("SignalR bağlantısı kuruldu.");
                File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] SignalR bağlantısı kuruldu.\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR bağlantı hatası: " + ex.Message);
                File.AppendAllText("signalr_log.txt", $"[{DateTime.Now}] SignalR bağlantı hatası: {ex.Message}\n");
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
                            orderLayoutPanel.Controls.Clear();
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

        private void AddOrderToPanel(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi, string durum)
        {
            Panel orderPanel = new Panel
            {
                Size = new System.Drawing.Size(200, 140),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Visible = true,
                Tag = orderId
            };

            Label lblIsim = new Label
            {
                Text = $"İsim: {isim}",
                Location = new System.Drawing.Point(5, 5),
                AutoSize = true,
                Visible = true
            };
            Label lblMasaNo = new Label
            {
                Text = $"Masa: {masaNo}",
                Location = new System.Drawing.Point(5, 25),
                AutoSize = true,
                Visible = true
            };
            Label lblTelefon = new Label
            {
                Text = $"Telefon: {telefon}",
                Location = new System.Drawing.Point(5, 45),
                AutoSize = true,
                Visible = true
            };
            Label lblAciklama = new Label
            {
                Text = $"Açıklama: {aciklama}",
                Location = new System.Drawing.Point(5, 65),
                AutoSize = true,
                Visible = true
            };
            Label lblTutar = new Label
            {
                Text = $"Tutar: {toplamTutar} TL",
                Location = new System.Drawing.Point(5, 85),
                AutoSize = true,
                Visible = true
            };
            Label lblTarih = new Label
            {
                Text = $"Tarih: {siparisTarihi.ToString("dd/MM/yyyy HH:mm")}",
                Location = new System.Drawing.Point(5, 105),
                AutoSize = true,
                Visible = true
            };
            Label lblDurum = new Label
            {
                Text = $"Durum: {durum}",
                Location = new System.Drawing.Point(5, 125),
                AutoSize = true,
                Visible = true
            };

            Button btnUpdateStatus = new Button
            {
                Text = "Durumu Güncelle",
                Location = new System.Drawing.Point(100, 120),
                Size = new System.Drawing.Size(90, 20),
                Tag = orderId
            };
            btnUpdateStatus.Click += async (sender, e) =>
            {
                var button = sender as Button;
                int id = (int)button.Tag;

                using (var form = new Form { Size = new System.Drawing.Size(200, 150), Text = "Durumu Güncelle" })
                {
                    ComboBox comboBox = new ComboBox
                    {
                        Location = new System.Drawing.Point(10, 10),
                        Size = new System.Drawing.Size(160, 30),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    comboBox.Items.AddRange(new[] { "Ödeme Tamamlandı", "Hazırlanıyor", "Teslim Edildi" });
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(durum);

                    Button btnConfirm = new Button
                    {
                        Text = "Güncelle",
                        Location = new System.Drawing.Point(10, 50),
                        Size = new System.Drawing.Size(160, 30)
                    };
                    btnConfirm.Click += async (s, ev) =>
                    {
                        string newStatus = comboBox.SelectedItem.ToString();
                        await UpdateOrderStatus(id, newStatus);
                        form.Close();
                    };

                    form.Controls.Add(comboBox);
                    form.Controls.Add(btnConfirm);
                    form.ShowDialog();
                }
            };

            orderPanel.Controls.Add(lblIsim);
            orderPanel.Controls.Add(lblMasaNo);
            orderPanel.Controls.Add(lblTelefon);
            orderPanel.Controls.Add(lblAciklama);
            orderPanel.Controls.Add(lblTutar);
            orderPanel.Controls.Add(lblTarih);
            orderPanel.Controls.Add(lblDurum);
            orderPanel.Controls.Add(btnUpdateStatus);

            orderLayoutPanel.Controls.Add(orderPanel);
            orderLayoutPanel.Controls.SetChildIndex(orderPanel, 0);
            orderLayoutPanel.Refresh();
            orderLayoutPanel.Invalidate();
            orderLayoutPanel.Visible = true;
        }

        private async Task UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7222/api/Orders/{orderId}/status");
                    request.Content = new StringContent(
                        System.Text.Json.JsonSerializer.Serialize(new { Durum = newStatus }),
                        System.Text.Encoding.UTF8,
                        "application/json"
                    );
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Durum güncellendi: " + newStatus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durum güncelleme hatası: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            hubConnection?.StopAsync().Wait();
            base.OnFormClosing(e);
        }
    }
}
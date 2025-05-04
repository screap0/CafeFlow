using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CafeFlow
{
    public partial class Orders : Form
    {
        private HubConnection hubConnection;
        private DatabaseConnection dbConnection;

        // Renk paleti tanımlamaları
        private readonly Color formBackColor = Color.FromArgb(34, 33, 74);
        private readonly Color cardBackColor = Color.FromArgb(45, 45, 90);
        private readonly Color textColor = Color.FromArgb(240, 240, 245);
        private readonly Color highlightColor = Color.FromArgb(79, 79, 135);
        private readonly Color accentColor = Color.FromArgb(95, 77, 221);

        public Orders()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();

            // Form tasarımını ayarla
            ApplyFormStyling();

            SetupSignalR();
            LoadInitialOrders();
        }

        private void ApplyFormStyling()
        {
            // Form özelliklerini ayarla
            this.BackColor = formBackColor;
            this.Text = "CafeFlow - Sipariş Yönetimi";
            this.MinimumSize = new Size(950, 600);

            // FlowLayoutPanel özelliklerini ayarla
            orderLayoutPanel.BackColor = formBackColor;
            orderLayoutPanel.Padding = new Padding(15);
            orderLayoutPanel.AutoScroll = true;
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
                ShowNotification("SignalR bağlantısı kapandı: " + (error?.Message ?? "Bilinmeyen hata"), MessageBoxIcon.Warning);
                await Task.Delay(5000); // 5 saniye bekle ve yeniden bağlanmayı dene
                await hubConnection.StartAsync();
            };

            hubConnection.On<int, string, int, string, string, decimal, DateTime, string>("ReceiveOrderUpdate", (orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum) =>
            {
                this.Invoke((Action)(() =>
                {
                    AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                    ShowNotification($"Yeni sipariş alındı: #{orderId} - {isim}", MessageBoxIcon.Information);
                }));
            });

            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                ShowNotification("SignalR bağlantı hatası: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void ShowNotification(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, "CafeFlow Bildirim", MessageBoxButtons.OK, icon);
        }

        private async Task LoadInitialOrders()
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum  FROM Siparisler WHERE durum = 'Ödeme tamamlandı' ORDER BY siparis_tarihi DESC";
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
                ShowNotification("Başlangıç siparişleri yüklenirken hata: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private async void AddOrderToPanel(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi, string durum)
        {
            // Özel yuvarlak köşeli panel oluştur
            RoundedPanel orderPanel = new RoundedPanel
            {
                Size = new Size(270, 460), // Yüksekliği 2 katına çıkarıldı
                Margin = new Padding(10),
                BackColor = cardBackColor,
                CornerRadius = 15,
                Tag = orderId
            };

            // Sipariş numarası ve tarih için başlık paneli
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = accentColor
            };

            Label lblHeader = new Label
            {
                Text = $"Sipariş #{orderId}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblHeader);

            // İçerik paneli
            TableLayoutPanel contentPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 7,
                Padding = new Padding(10, 5, 10, 5),
                RowStyles = {
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.AutoSize),
            new RowStyle(SizeType.Percent, 100)
        }
            };

            // Labels oluştur ve hizala
            Label lblIsim = CreateInfoLabel("İsim", isim);
            Label lblMasaNo = CreateInfoLabel("Masa", masaNo.ToString());
            Label lblTelefon = CreateInfoLabel("Telefon", telefon);

            // Kaydırılabilir açıklama paneli
            Panel scrollableDescriptionPanel = new Panel
            {
                Size = new Size(240, 200), // Yüksekliği artırıldı
                AutoScroll = true,
                BackColor = formBackColor, // Arka plan rengi formun arka plan rengine uyumlu hale getirildi
                Padding = new Padding(5)
            };

            Label lblAciklama = new Label
            {
                Text = aciklama,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = textColor
            };

            scrollableDescriptionPanel.Controls.Add(lblAciklama);

            Label lblTutar = CreateInfoLabel("Tutar", $"{toplamTutar:N2} TL");
            Label lblTarih = CreateInfoLabel("Tarih", siparisTarihi.ToString("dd/MM/yyyy HH:mm"));

            // Status ComboBox ve başlık
            Panel statusPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 50
            };

            Label lblDurumTitle = new Label
            {
                Text = "Durum:",
                AutoSize = true,
                Location = new Point(0, 3),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = textColor
            };
            statusPanel.Controls.Add(lblDurumTitle);

            ComboBox statusComboBox = new ComboBox
            {
                Location = new Point(0, 25),
                Size = new Size(260, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9),
                BackColor = highlightColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat
            };
            statusComboBox.Items.AddRange(new string[] { "Ödeme Tamamlandı", "Hazırlanıyor", "Sipariş Hazır" });
            statusPanel.Controls.Add(statusComboBox);

            // Durum değerini temizle ve eşleştir
            string cleanedDurum = durum?.Trim().Replace("\r", "").Replace("\n", "");
            string matchedDurum = FindMatchingStatus(cleanedDurum, statusComboBox, orderId);
            statusComboBox.SelectedItem = matchedDurum;

            // Status değişikliğini ele al
            statusComboBox.SelectedIndexChanged += async (sender, e) =>
            {
                string newStatus = statusComboBox.SelectedItem.ToString();
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

                    // Durum değişikliğini visual olarak belirt
                    orderPanel.BackColor = newStatus == "Sipariş Hazır" ?
                        Color.FromArgb(45, 90, 45) : cardBackColor;
                }
                catch (Exception ex)
                {
                    ShowNotification("Durum güncellenirken hata: " + ex.Message, MessageBoxIcon.Error);
                }
            };

            // Siparişin durumuna göre renk değiştir
            if (matchedDurum == "Sipariş Hazır")
            {
                orderPanel.BackColor = Color.FromArgb(45, 90, 45);
            }

            // Panelleri ekle
            contentPanel.Controls.Add(lblIsim, 0, 0);
            contentPanel.Controls.Add(lblMasaNo, 0, 1);
            contentPanel.Controls.Add(lblTelefon, 0, 2);
            contentPanel.Controls.Add(scrollableDescriptionPanel, 0, 3); // Kaydırılabilir açıklama panelini ekle
            contentPanel.Controls.Add(lblTutar, 0, 4);
            contentPanel.Controls.Add(lblTarih, 0, 5);
            contentPanel.Controls.Add(statusPanel, 0, 6);

            orderPanel.Controls.Add(contentPanel);
            orderPanel.Controls.Add(headerPanel);

            // Paneli ekle ve en üste taşı
            orderLayoutPanel.Controls.Add(orderPanel);
            orderLayoutPanel.Controls.SetChildIndex(orderPanel, 0);
            orderLayoutPanel.Refresh();
        }



        private Label CreateInfoLabel(string title, string value)
        {
            Label lbl = new Label
            {
                Text = $"{title}: {value}",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = textColor,
                Margin = new Padding(0, 3, 0, 3)
            };
            return lbl;
        }

        private string TrimText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
        }

        private string FindMatchingStatus(string durum, ComboBox statusComboBox, int orderId)
        {
            if (string.IsNullOrEmpty(durum)) return "Ödeme Tamamlandı";

            // Tam eşleşme ara
            foreach (string item in statusComboBox.Items)
            {
                if (string.Equals(item, durum, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }

            // Kısmi eşleşme ara
            if (durum.ToLower().Contains("hazirlaniyor"))
                return "Hazırlanıyor";
            else if (durum.ToLower().Contains("hazir"))
                return "Sipariş Hazır";
            else if (durum.ToLower().Contains("odeme") || durum.ToLower().Contains("ödeme"))
                return "Ödeme Tamamlandı";

            // Eşleşme yoksa varsayılan seç
            return "Ödeme Tamamlandı";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            hubConnection?.StopAsync().Wait();
            base.OnFormClosing(e);
        }
    }

    // Yuvarlak köşeli panel sınıfı
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 20;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
    }
}
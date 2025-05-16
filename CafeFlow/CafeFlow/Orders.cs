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
        private static HubConnection hubConnection; // Statik bağlantı
        private DatabaseConnection dbConnection;
        string kullaniciadi;
        string txtform;


        private readonly Color formBackColor = Color.FromArgb(34, 33, 74);
        private readonly Color cardBackColor = Color.FromArgb(45, 45, 90);
        private readonly Color textColor = Color.FromArgb(240, 240, 245);
        private readonly Color highlightColor = Color.FromArgb(79, 79, 135);
        private readonly Color accentColor = Color.FromArgb(95, 77, 221);

        public Orders(string kullaniciadi)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.kullaniciadi= kullaniciadi;
            txtform = "Orders";

            ApplyFormStyling();
            SetupSignalRIfNeeded();
            LoadInitialOrders().ContinueWith(t =>
            {
                orderLayoutPanel.PerformLayout();
                AdjustCardHeights();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            this.Resize += Orders_Resize;
        }
       

        private void ApplyFormStyling()
        {
            this.BackColor = formBackColor;
            this.Text = "CafeFlow - Sipariş Yönetimi";
            this.MinimumSize = new Size(950, 600);

            orderLayoutPanel.BackColor = formBackColor;
            orderLayoutPanel.Padding = new Padding(15);
            orderLayoutPanel.AutoScroll = true;
            orderLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            orderLayoutPanel.WrapContents = false;
        }

        internal void SetupSignalRIfNeeded()
        {
            // Eski dinleyicileri kaldır (varsa)
            if (hubConnection != null)
            {
                hubConnection.Remove("ReceiveOrderUpdate");
            }

            // hubConnection yoksa veya disconnected ise yeniden oluştur
            if (hubConnection == null || hubConnection.State == HubConnectionState.Disconnected)
            {
                hubConnection = new HubConnectionBuilder()
                    .WithUrl("http://31.57.33.58/orderHub", options => options.UseDefaultCredentials = true)
                    .AddJsonProtocol()
                    .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10) })
                    .ConfigureLogging(logging =>
                    {
                        logging.AddDebug();
                        logging.SetMinimumLevel(LogLevel.Debug);
                    })
                    .Build();

                hubConnection.Closed += async (error) =>
                {
                    await Task.Delay(5000);
                    await hubConnection.StartAsync();
                };

                int retryCount = 0;
                const int maxRetries = 3;
                Task.Run(async () =>
                {
                    while (retryCount < maxRetries)
                    {
                        try
                        {
                            await hubConnection.StartAsync();
                            this.Invoke((Action)(() => ShowNotification("SignalR bağlantısı başarıyla kuruldu.", MessageBoxIcon.Information)));
                            dbConnection.Log(txtform, "SignalR bağlantısı başarıyla kuruldu.", DateTime.Now, kullaniciadi);
                            break;
                        }
                        catch (Exception ex)
                        {
                            retryCount++;
                            this.Invoke((Action)(() => ShowNotification($"SignalR bağlantı hatası (Deneme {retryCount}/{maxRetries}): {ex.Message}", MessageBoxIcon.Error)));
                            if (retryCount == maxRetries)
                            {
                                this.Invoke((Action)(() => ShowNotification("SignalR bağlantısı sağlanamadı. Lütfen sunucu durumunu kontrol edin.", MessageBoxIcon.Error)));
                                dbConnection.Log(txtform, "Error: " + "SignalR bağlantısı sağlanamadı. Lütfen sunucu durumunu kontrol edin.", DateTime.Now, kullaniciadi);
                                break;
                            }
                            await Task.Delay(5000);
                        }
                    }
                });
            }

            // Yeni dinleyiciyi ekle
            if (hubConnection != null)
            {
                  hubConnection.On<int, string, int, string, string, decimal, DateTime, string>(
                    "ReceiveOrderUpdate",
                    async (orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum) =>
                    {
                        this.Invoke((Action)(async () =>
                        {
                            ShowNotification($"SignalR'dan gelen orderId: {orderId}", MessageBoxIcon.Information);

                            // Her durumda veritabanından doğrulama yap (güvenlik için)
                            try
                            {
                                using (var connection = dbConnection.GetConnection())
                                {
                                    await connection.OpenAsync();
                                    string query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum FROM Siparisler WHERE isim = @isim AND masa_no = @masaNo AND DATE(siparis_tarihi) = DATE(@siparisTarihi) LIMIT 1";
                                    using (var command = new MySqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@isim", isim);
                                        command.Parameters.AddWithValue("@masaNo", masaNo);
                                        command.Parameters.AddWithValue("@siparisTarihi", siparisTarihi);
                                        using (var reader = await command.ExecuteReaderAsync())
                                        {
                                            if (await reader.ReadAsync())
                                            {
                                                orderId = reader.GetInt32(0);
                                                isim = reader.GetString(1);
                                                masaNo = reader.GetInt32(2);
                                                telefon = reader.IsDBNull(3) ? "Yok" : reader.GetString(3);
                                                aciklama = reader.GetString(4);
                                                toplamTutar = reader.GetDecimal(5);
                                                siparisTarihi = reader.GetDateTime(6);
                                                durum = reader.GetString(7);
                                                ShowNotification($"Veritabanından alınan orderId: {orderId}", MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                ShowNotification("Veritabanında eşleşen sipariş bulunamadı!", MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowNotification("Sipariş kontrol edilirken hata: " + ex.Message, MessageBoxIcon.Error);
                                dbConnection.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                            }

                            AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                            ShowNotification($"Yeni sipariş alındı: #{orderId} - {isim}", MessageBoxIcon.Information);
                            dbConnection.Log(txtform, "Yeni sipariş alındı: " + orderId + " - " + isim, DateTime.Now, kullaniciadi);
                        }));
                    });
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
                    string query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum FROM Siparisler WHERE durum = 'Ödeme tamamlandı' ORDER BY siparis_tarihi ASC LIMIT 50";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AddOrderToPanel(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.IsDBNull(3) ? "Yok" : reader.GetString(3),
                                reader.GetString(4),
                                reader.GetDecimal(5),
                                reader.GetDateTime(6),
                                reader.GetString(7)
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification("Başlangıç siparişleri yüklenirken hata: " + ex.Message, MessageBoxIcon.Error);
                dbConnection.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
            }
        }

        private async void AddOrderToPanel(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi, string durum)
        {
            if (orderLayoutPanel.Controls.Count >= 50)
            {
                orderLayoutPanel.Controls.RemoveAt(orderLayoutPanel.Controls.Count - 1);
            }

            int panelHeight = orderLayoutPanel.ClientSize.Height - 40;
            int cardWidth = 350;

            RoundedPanel orderPanel = new RoundedPanel
            {
                Width = cardWidth,
                Height = panelHeight,
                Margin = new Padding(10),
                BackColor = cardBackColor,
                CornerRadius = 15,
                Tag = orderId
            };

            Panel headerPanel = new Panel { Dock = DockStyle.Top, Height = 30, BackColor = accentColor };
            Label lblHeader = new Label
            {
                Text = $"Sipariş #{orderId}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblHeader);

            TableLayoutPanel contentPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 7,
                Padding = new Padding(10, 5, 10, 20),
                RowStyles = { new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.Percent, 100) }
            };

            Label lblIsim = CreateInfoLabel("İsim", isim);
            Label lblMasaNo = CreateInfoLabel("Masa", masaNo.ToString());
            Label lblTelefon = CreateInfoLabel("Telefon", telefon);

            int otherElementsHeight = 30 + (5 * 20) + 50 + 25;
            int descriptionHeight = panelHeight - otherElementsHeight;
            if (descriptionHeight < 50) descriptionHeight = 50;

            Panel scrollableDescriptionPanel = new Panel
            {
                Size = new Size(cardWidth - 30, descriptionHeight),
                AutoScroll = true,
                BackColor = formBackColor,
                Padding = new Padding(5),
                Tag = "DescriptionPanel"
            };

            Label lblAciklama = new Label
            {
                Text = aciklama,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = textColor
            };
            scrollableDescriptionPanel.Controls.Add(lblAciklama);

            Label lblTutar = CreateInfoLabel("Tutar", $"{toplamTutar:N2} TL");
            Label lblTarih = CreateInfoLabel("Tarih", siparisTarihi.ToString("dd/MM/yyyy HH:mm"));

            Panel statusPanel = new Panel { Dock = DockStyle.Fill, Height = 50 };

            ComboBox statusComboBox = new ComboBox
            {
                Location = new Point(0, 0),
                Size = new Size(cardWidth - 30, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = highlightColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat
            };

            statusComboBox.Items.AddRange(new string[] { "Ödeme Tamamlandı", "Hazırlanıyor", "Sipariş Hazır" });
            string cleanedDurum = durum?.Trim().Replace("\r", "").Replace("\n", "");
            string matchedDurum = FindMatchingStatus(cleanedDurum, statusComboBox, orderId);
            statusComboBox.SelectedItem = matchedDurum;
            statusPanel.Controls.Add(statusComboBox);

            statusComboBox.SelectedIndexChanged += async (sender, e) =>
            {
                string newStatus = statusComboBox.SelectedItem.ToString();
                try
                {
                    using (var connection = dbConnection.GetConnection())
                    {
                        await connection.OpenAsync();
                        using (var command = new MySqlCommand("UPDATE Siparisler SET durum = @durum WHERE id = @orderId", connection))
                        {
                            command.Parameters.AddWithValue("@durum", newStatus);
                            command.Parameters.AddWithValue("@orderId", orderId);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    orderPanel.BackColor = newStatus == "Sipariş Hazır" ? Color.FromArgb(45, 90, 45) : cardBackColor;

                    if (newStatus == "Sipariş Hazır")
                    {
                        try
                        {
                            ArduinoController arduinoController = new ArduinoController(kullaniciadi);
                            arduinoController.MasaNo(masaNo);
                            dbConnection.Log(txtform, $"Arduino'ya masa numarası gönderildi: {masaNo}", DateTime.Now, kullaniciadi);
                        }
                        catch (Exception ex)
                        {
                            ShowNotification($"Arduino'ya masa numarası gönderilirken hata: {ex.Message}", MessageBoxIcon.Error);
                            dbConnection.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowNotification("Durum güncellenirken hata: " + ex.Message, MessageBoxIcon.Error);
                    dbConnection.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            };

            if (matchedDurum == "Sipariş Hazır")
            {
                orderPanel.BackColor = Color.FromArgb(45, 90, 45);
            }

            contentPanel.Controls.Add(lblIsim, 0, 0);
            contentPanel.Controls.Add(lblMasaNo, 0, 1);
            contentPanel.Controls.Add(lblTelefon, 0, 2);
            contentPanel.Controls.Add(scrollableDescriptionPanel, 0, 3);
            contentPanel.Controls.Add(lblTutar, 0, 4);
            contentPanel.Controls.Add(lblTarih, 0, 5);
            contentPanel.Controls.Add(statusPanel, 0, 6);

            orderPanel.Controls.Add(contentPanel);
            orderPanel.Controls.Add(headerPanel);

            orderLayoutPanel.Controls.Add(orderPanel);
            orderLayoutPanel.Controls.SetChildIndex(orderPanel, 0);
            orderLayoutPanel.Refresh();
        }

        private void Orders_Resize(object sender, EventArgs e)
        {
            AdjustCardHeights();
        }

        private void AdjustCardHeights()
        {
            int panelHeight = orderLayoutPanel.ClientSize.Height - 40;
            int cardWidth = 350;

            foreach (Control ctrl in orderLayoutPanel.Controls)
            {
                if (ctrl is RoundedPanel panel)
                {
                    panel.Height = panelHeight;

                    foreach (Control panelCtrl in panel.Controls)
                    {
                        if (panelCtrl is TableLayoutPanel contentPanel)
                        {
                            foreach (Control contentCtrl in contentPanel.Controls)
                            {
                                if (contentCtrl.Tag != null && contentCtrl.Tag.ToString() == "DescriptionPanel")
                                {
                                    int otherElementsHeight = 30 + (5 * 20) + 50 + 25;
                                    int descriptionHeight = panelHeight - otherElementsHeight;
                                    if (descriptionHeight < 50) descriptionHeight = 50;
                                    contentCtrl.Size = new Size(cardWidth - 30, descriptionHeight);
                                }
                            }
                        }
                    }
                }
            }
        }

        private Label CreateInfoLabel(string title, string value)
        {
            return new Label
            {
                Text = $"{title}: {value}",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = textColor,
            };
        }

        private string FindMatchingStatus(string durum, ComboBox statusComboBox, int orderId)
        {
            if (string.IsNullOrEmpty(durum)) return "Ödeme Tamamlandı";

            foreach (string item in statusComboBox.Items)
            {
                if (string.Equals(item, durum, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }

            if (durum.ToLower().Contains("hazirlaniyor")) return "Hazırlanıyor";
            if (durum.ToLower().Contains("hazir")) return "Sipariş Hazır";
            if (durum.ToLower().Contains("odeme") || durum.ToLower().Contains("ödeme")) return "Ödeme Tamamlandı";


            return "Ödeme Tamamlandı";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }

    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 20;

        public int CornerRadius
        {
            get => _cornerRadius;
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
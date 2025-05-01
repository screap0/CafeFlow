using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class Reports : Form
    {
        private DatabaseConnection dbConnection;
        private int fixedCardWidth; // orderReportPnl için sabit genişlik
        private int fixedTurnoverCardWidth; // dailyTurnoverPnl için sabit genişlik

        public Reports()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();

            // Flicker’ı azaltmak için
            this.DoubleBuffered = true;

            // orderReportPnl ayarları (Siparişler için)
            orderReportPnl.FlowDirection = FlowDirection.TopDown; // Alt alta dizilsin
            orderReportPnl.AutoScroll = true; // Kaydırma çubuğu aktif
            orderReportPnl.WrapContents = false; // Sarma olmasın, sadece alt alta
            orderReportPnl.AutoScrollMinSize = new Size(0, 0); // Yatay kaydırmayı devre dışı bırak
            orderReportPnl.HorizontalScroll.Enabled = false; // Yatay kaydırma çubuğunu devre dışı bırak
            orderReportPnl.HorizontalScroll.Visible = false; // Yatay kaydırma çubuğunu gizle
            orderReportPnl.HorizontalScroll.Maximum = 0; // Yatay kaydırma aralığını sıfırla

            // orderReportPnl’in yüksekliğini forma göre otomatik ayarla, alttan boşluk bırak
            orderReportPnl.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Üst ve sola sabitle, alttan serbest bırak
            orderReportPnl.Height = this.ClientSize.Height - 30; // Alttan 30 piksel boşluk bırak

            // dailyTurnoverPnl ayarları (Günlük Ciro için)
            dailyTurnoverPnl.FlowDirection = FlowDirection.TopDown; // Alt alta dizilsin
            dailyTurnoverPnl.AutoScroll = true; // Kaydırma çubuğu aktif
            dailyTurnoverPnl.WrapContents = false; // Sarma olmasın, sadece alt alta
            dailyTurnoverPnl.AutoScrollMinSize = new Size(0, 0); // Yatay kaydırmayı devre dışı bırak
            dailyTurnoverPnl.HorizontalScroll.Enabled = false; // Yatay kaydırma çubuğunu devre dışı bırak
            dailyTurnoverPnl.HorizontalScroll.Visible = false; // Yatay kaydırma çubuğunu gizle
            dailyTurnoverPnl.HorizontalScroll.Maximum = 0; // Yatay kaydırma aralığını sıfırla

            // dailyTurnoverPnl’in yüksekliğini forma göre otomatik ayarla, alttan boşluk bırak
            dailyTurnoverPnl.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Üst ve sola sabitle, alttan serbest bırak
            dailyTurnoverPnl.Height = this.ClientSize.Height - 30; // Alttan 30 piksel boşluk bırak

            // Formun boyut değişimini yakala ve panellerin yüksekliğini güncelle
            this.Resize += (s, e) =>
            {
                orderReportPnl.Height = this.ClientSize.Height - 30; // Alttan 30 piksel boşluk bırak
                dailyTurnoverPnl.Height = this.ClientSize.Height - 30; // Alttan 30 piksel boşluk bırak
            };

            // orderReportPnl için sabit kart genişliğini belirle (başlangıçta kaydırma çubuğu olmadan)
            fixedCardWidth = orderReportPnl.ClientSize.Width - 40; // Daha fazla boşluk bırak

            // orderReportPnl’in genişliği değiştiğinde (örneğin kaydırma çubuğu göründüğünde) kartları yeniden boyutlandır
            orderReportPnl.ClientSizeChanged += (s, e) =>
            {
                fixedCardWidth = orderReportPnl.ClientSize.Width - 40; // Daha fazla boşluk bırak
                UpdateCardWidths(orderReportPnl, fixedCardWidth);
            };

            // dailyTurnoverPnl için sabit kart genişliğini belirle (başlangıçta kaydırma çubuğu olmadan)
            fixedTurnoverCardWidth = dailyTurnoverPnl.ClientSize.Width - 40; // Daha fazla boşluk bırak

            // dailyTurnoverPnl’in genişliği değiştiğinde (örneğin kaydırma çubuğu göründüğünde) kartları yeniden boyutlandır
            dailyTurnoverPnl.ClientSizeChanged += (s, e) =>
            {
                fixedTurnoverCardWidth = dailyTurnoverPnl.ClientSize.Width - 40; // Daha fazla boşluk bırak
                UpdateCardWidths(dailyTurnoverPnl, fixedTurnoverCardWidth);
            };

            LoadOrders(); // Siparişleri yükle (orderReportPnl için)
            LoadDailyTurnover(); // Günlük ciroları yükle (dailyTurnoverPnl için)
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Siparisler ORDER BY siparis_tarihi DESC LIMIT 50";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            orderReportPnl.Controls.Clear();

                            while (reader.Read())
                            {
                                // Kart oluştur (sabit genişlik kullan)
                                Panel orderCard = new Panel
                                {
                                    Size = new Size(fixedCardWidth, 50), // Sabit genişlik
                                    BackColor = Color.FromArgb(230, 220, 255), // Pastel mor tonu
                                    Margin = new Padding(10), // Kartlar arasında boşluk
                                    Padding = new Padding(15), // İç boşluk
                                    Tag = false // Kartın kapalı olduğunu belirt (genişletme için)
                                };

                                // Kartın içine sadece açıklama label’ı (kapalı hali)
                                Label lblAciklama = new Label
                                {
                                    Text = $"Açıklama: {reader["siparis_aciklamasi"].ToString()}",
                                    Location = new Point(10, 10),
                                    AutoSize = true,
                                    MaximumSize = new Size(orderCard.Width - 40, 0), // Ok için yer bırak
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(90, 70, 150) // Okunaklı koyu mor ton
                                };
                                orderCard.Controls.Add(lblAciklama);

                                // Açıklamanın yanına ok ekle (kapalıyken aşağı bakar, her zaman sağda hizalı)
                                Label lblArrow = new Label
                                {
                                    Text = "▼", // Aşağı ok (kapalı hali)
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(90, 70, 150),
                                    Tag = "arrow" // Ok olduğunu belirtmek için Tag kullanıyoruz
                                };
                                // Ok’un genişliğini ölç ve sağa hizala
                                using (Graphics g = orderCard.CreateGraphics())
                                {
                                    SizeF arrowSize = g.MeasureString(lblArrow.Text, lblArrow.Font);
                                    lblArrow.Location = new Point(orderCard.Width - (int)arrowSize.Width - 10, 10); // Kartın sağ kenarına hizala
                                }
                                orderCard.Controls.Add(lblArrow);

                                // Açıklamanın yüksekliğini manuel olarak hesapla ve kartın kapalı halini ayarla
                                using (Graphics g = orderCard.CreateGraphics())
                                {
                                    SizeF textSize = g.MeasureString(lblAciklama.Text, lblAciklama.Font, lblAciklama.MaximumSize.Width);
                                    lblAciklama.Height = (int)textSize.Height;
                                    orderCard.Height = lblAciklama.Height + 30; // Açıklamanın yüksekliği + padding
                                }

                                // Detaylar (genişletildiğinde görünecek)
                                int yPosition = lblAciklama.Height + 20; // Açıklamadan sonra dinamik olarak başlayacak

                                // ID
                                Label lblId = new Label
                                {
                                    Text = $"Sipariş ID: {reader["id"].ToString()}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(50, 120, 100), // Okunaklı yeşil ton
                                    Visible = false // Başlangıçta gizli
                                };
                                orderCard.Controls.Add(lblId);
                                yPosition += 25;

                                // Masa No
                                Label lblMasaNo = new Label
                                {
                                    Text = $"Masa No: {reader["masa_no"].ToString()}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    ForeColor = Color.FromArgb(120, 80, 60), // Okunaklı kahverengi ton
                                    Visible = false
                                };
                                orderCard.Controls.Add(lblMasaNo);
                                yPosition += 20;

                                // Telefon
                                Label lblTelefon = new Label
                                {
                                    Text = $"Telefon: {reader["telefon"].ToString()}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    ForeColor = Color.FromArgb(70, 100, 130), // Okunaklı mavi ton
                                    Visible = false
                                };
                                orderCard.Controls.Add(lblTelefon);
                                yPosition += 20;

                                // Toplam Tutar
                                Label lblTutar = new Label
                                {
                                    Text = $"Toplam Tutar: {Convert.ToDecimal(reader["toplam_tutar"]):C}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    ForeColor = Color.FromArgb(150, 60, 90), // Okunaklı pembe ton
                                    Visible = false
                                };
                                orderCard.Controls.Add(lblTutar);
                                yPosition += 20;

                                // Sipariş Tarihi
                                Label lblTarih = new Label
                                {
                                    Text = $"Tarih: {Convert.ToDateTime(reader["siparis_tarihi"]).ToString("dd/MM/yyyy HH:mm")}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    ForeColor = Color.FromArgb(100, 90, 50), // Okunaklı sarımsı ton
                                    Visible = false
                                };
                                orderCard.Controls.Add(lblTarih);
                                yPosition += 20;

                                // Durum
                                Label lblDurum = new Label
                                {
                                    Text = $"Durum: {reader["durum"].ToString()}",
                                    Location = new Point(10, yPosition),
                                    AutoSize = true,
                                    ForeColor = reader["durum"].ToString() == "Ödeme Tamamlandı" ? Color.FromArgb(50, 120, 80) : Color.FromArgb(150, 50, 70), // Yeşil veya kırmızı ton
                                    Visible = false
                                };
                                orderCard.Controls.Add(lblDurum);
                                yPosition += 20;

                                // Kartın tıklama olayı (genişlet/küçült) için animasyon
                                EventHandler cardClickHandler = (s, e) =>
                                {
                                    bool isExpanded = (bool)orderCard.Tag;
                                    if (!isExpanded)
                                    {
                                        // Diğer açık kartları kapat (animasyonlu)
                                        foreach (Control ctrl in orderReportPnl.Controls)
                                        {
                                            if (ctrl is Panel otherCard && ctrl != orderCard)
                                            {
                                                if ((bool)otherCard.Tag)
                                                {
                                                    AnimateCard(otherCard, otherCard.Height, otherCard.Controls.OfType<Label>().First().Height + 30, false);
                                                    otherCard.Tag = false;
                                                    foreach (Control subCtrl in otherCard.Controls)
                                                    {
                                                        if (subCtrl != otherCard.Controls.OfType<Label>().First() && subCtrl.Tag?.ToString() != "arrow")
                                                        {
                                                            subCtrl.Visible = false; // Açıklamadan ve ok’tan diğerlerini gizle
                                                        }
                                                        if (subCtrl.Tag?.ToString() == "arrow") subCtrl.Text = "▼"; // Ok’u aşağı çevir
                                                    }
                                                }
                                            }
                                        }

                                        // Genişlet (animasyonlu)
                                        AnimateCard(orderCard, orderCard.Height, yPosition + 10, true);
                                        orderCard.Tag = true;
                                        foreach (Control ctrl in orderCard.Controls)
                                        {
                                            if (ctrl != lblAciklama && ctrl.Tag?.ToString() != "arrow")
                                            {
                                                ctrl.Visible = true; // Açıklamadan ve ok’tan diğerlerini göster
                                            }
                                            if (ctrl.Tag?.ToString() == "arrow") ctrl.Text = "▲"; // Ok’u yukarı çevir
                                        }
                                    }
                                    else
                                    {
                                        // Küçült (animasyonlu)
                                        AnimateCard(orderCard, orderCard.Height, lblAciklama.Height + 30, false);
                                        orderCard.Tag = false;
                                        foreach (Control ctrl in orderCard.Controls)
                                        {
                                            if (ctrl != lblAciklama && ctrl.Tag?.ToString() != "arrow")
                                            {
                                                ctrl.Visible = false; // Açıklamadan ve ok’tan diğerlerini gizle
                                            }
                                            if (ctrl.Tag?.ToString() == "arrow") ctrl.Text = "▼"; // Ok’u aşağı çevir
                                        }
                                    }
                                };

                                // Kartın Click olayını bağla
                                orderCard.Click += cardClickHandler;

                                // Tüm label’lara tıklama olayını ekle (kartın her yerde tıklanabilir olsun)
                                foreach (Control ctrl in orderCard.Controls)
                                {
                                    ctrl.Click += cardClickHandler; // Aynı olay işleyicisini kullan
                                }

                                // Kartı panele ekle
                                orderReportPnl.Controls.Add(orderCard);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş Yükleme Hatası: " + ex.Message);
            }
        }

        private void LoadDailyTurnover()
        {
            try
            {
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT DATE(siparis_tarihi) AS gun, SUM(toplam_tutar) AS gunluk_ciro
                        FROM Siparisler
                        WHERE durum = 'Ödeme Tamamlandı'
                        GROUP BY DATE(siparis_tarihi)
                        ORDER BY gun DESC
                        LIMIT 50";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            dailyTurnoverPnl.Controls.Clear();

                            // Kayıt var mı kontrol et
                            if (!reader.HasRows)
                            {
                                // Kayıt yoksa bir bilgi kartı ekle
                                Panel noDataCard = new Panel
                                {
                                    Size = new Size(fixedTurnoverCardWidth, 50),
                                    BackColor = Color.FromArgb(255, 220, 220), // Pastel kırmızı tonu
                                    Margin = new Padding(10),
                                    Padding = new Padding(15),
                                };

                                Label lblNoData = new Label
                                {
                                    Text = "Ödeme Tamamlanmış Sipariş Bulunamadı.",
                                    Location = new Point(10, 10),
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(150, 50, 70), // Okunaklı kırmızı ton
                                };
                                noDataCard.Controls.Add(lblNoData);

                                using (Graphics g = noDataCard.CreateGraphics())
                                {
                                    SizeF textSize = g.MeasureString(lblNoData.Text, lblNoData.Font);
                                    lblNoData.Height = (int)textSize.Height;
                                    noDataCard.Height = lblNoData.Height + 30;
                                }

                                dailyTurnoverPnl.Controls.Add(noDataCard);
                                return; // Daha fazla işlem yapma
                            }

                            int recordCount = 0; // Kayıt sayısını takip et
                            while (reader.Read())
                            {
                                recordCount++;
                                // Kart oluştur (sabit genişlik kullan)
                                Panel turnoverCard = new Panel
                                {
                                    Size = new Size(fixedTurnoverCardWidth, 50), // Sabit genişlik
                                    BackColor = Color.FromArgb(220, 255, 220), // Pastel yeşil tonu
                                    Margin = new Padding(10), // Kartlar arasında boşluk
                                    Padding = new Padding(15), // İç boşluk
                                    Tag = false // Kartın kapalı olduğunu belirt (genişletme için)
                                };

                                // Kartın içine sadece günlük ciro label’ı (kapalı hali)
                                Label lblGunlukCiro = new Label
                                {
                                    Text = $"Gün: {Convert.ToDateTime(reader["gun"]).ToString("dd/MM/yyyy")} - Ciro: {Convert.ToDecimal(reader["gunluk_ciro"]):C}",
                                    Location = new Point(10, 10),
                                    AutoSize = true,
                                    MaximumSize = new Size(turnoverCard.Width - 40, 0), // Ok için yer bırak
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(50, 120, 100) // Okunaklı yeşil ton
                                };
                                turnoverCard.Controls.Add(lblGunlukCiro);

                                // Açıklamanın yanına ok ekle (kapalıyken aşağı bakar, her zaman sağda hizalı)
                                Label lblArrow = new Label
                                {
                                    Text = "▼", // Aşağı ok (kapalı hali)
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(50, 120, 100),
                                    Tag = "arrow" // Ok olduğunu belirtmek için Tag kullanıyoruz
                                };
                                // Ok’un genişliğini ölç ve sağa hizala
                                using (Graphics g = turnoverCard.CreateGraphics())
                                {
                                    SizeF arrowSize = g.MeasureString(lblArrow.Text, lblArrow.Font);
                                    lblArrow.Location = new Point(turnoverCard.Width - (int)arrowSize.Width - 10, 10); // Kartın sağ kenarına hizala
                                }
                                ;
                                turnoverCard.Controls.Add(lblArrow);

                                // Günlük ciro yüksekliğini manuel olarak hesapla ve kartın kapalı halini ayarla
                                using (Graphics g = turnoverCard.CreateGraphics())
                                {
                                    SizeF textSize = g.MeasureString(lblGunlukCiro.Text, lblGunlukCiro.Font, lblGunlukCiro.MaximumSize.Width);
                                    lblGunlukCiro.Height = (int)textSize.Height;
                                    turnoverCard.Height = lblGunlukCiro.Height + 30; // Açıklamanın yüksekliği + padding
                                }

                                // Detaylar (genişletildiğinde görünecek): O günün siparişlerini listele
                                int yPosition = lblGunlukCiro.Height + 20; // Açıklamadan sonra dinamik olarak başlayacak

                                // O günün siparişlerini çekmek için ikinci bir sorgu
                                string detailQuery = @"
                                    SELECT *
                                    FROM Siparisler
                                    WHERE DATE(siparis_tarihi) = @gun AND durum = 'Ödeme Tamamlandı'";
                                using (MySqlConnection detailConnection = dbConnection.GetConnection())
                                {
                                    detailConnection.Open();
                                    using (MySqlCommand detailCommand = new MySqlCommand(detailQuery, detailConnection))
                                    {
                                        detailCommand.Parameters.AddWithValue("@gun", reader["gun"]);
                                        using (MySqlDataReader detailReader = detailCommand.ExecuteReader())
                                        {
                                            while (detailReader.Read())
                                            {
                                                // Sipariş detayları
                                                Label lblSiparisDetay = new Label
                                                {
                                                    Text = $"Sipariş: {detailReader["siparis_aciklamasi"]} - Tutar: {Convert.ToDecimal(detailReader["toplam_tutar"]):C}",
                                                    Location = new Point(10, yPosition),
                                                    AutoSize = true,
                                                    ForeColor = Color.FromArgb(70, 100, 130), // Okunaklı mavi ton
                                                    Visible = false // Başlangıçta gizli
                                                };
                                                turnoverCard.Controls.Add(lblSiparisDetay);
                                                yPosition += 20;
                                            }
                                        }
                                    }
                                    detailConnection.Close();
                                }

                                // Kartın tıklama olayı (genişlet/küçült) için animasyon
                                EventHandler cardClickHandler = (s, e) =>
                                {
                                    bool isExpanded = (bool)turnoverCard.Tag;
                                    if (!isExpanded)
                                    {
                                        // Diğer açık kartları kapat (animasyonlu)
                                        foreach (Control ctrl in dailyTurnoverPnl.Controls)
                                        {
                                            if (ctrl is Panel otherCard && ctrl != turnoverCard)
                                            {
                                                if ((bool)otherCard.Tag)
                                                {
                                                    AnimateCard(otherCard, otherCard.Height, otherCard.Controls.OfType<Label>().First().Height + 30, false);
                                                    otherCard.Tag = false;
                                                    foreach (Control subCtrl in otherCard.Controls)
                                                    {
                                                        if (subCtrl != otherCard.Controls.OfType<Label>().First() && subCtrl.Tag?.ToString() != "arrow")
                                                        {
                                                            subCtrl.Visible = false; // Açıklamadan ve ok’tan diğerlerini gizle
                                                        }
                                                        if (subCtrl.Tag?.ToString() == "arrow") subCtrl.Text = "▼"; // Ok’u aşağı çevir
                                                    }
                                                }
                                            }
                                        }

                                        // Genişlet (animasyonlu)
                                        AnimateCard(turnoverCard, turnoverCard.Height, yPosition + 10, true);
                                        turnoverCard.Tag = true;
                                        foreach (Control ctrl in turnoverCard.Controls)
                                        {
                                            if (ctrl != lblGunlukCiro && ctrl.Tag?.ToString() != "arrow")
                                            {
                                                ctrl.Visible = true; // Açıklamadan ve ok’tan diğerlerini göster
                                            }
                                            if (ctrl.Tag?.ToString() == "arrow") ctrl.Text = "▲"; // Ok’u yukarı çevir
                                        }
                                    }
                                    else
                                    {
                                        // Küçült (animasyonlu)
                                        AnimateCard(turnoverCard, turnoverCard.Height, lblGunlukCiro.Height + 30, false);
                                        turnoverCard.Tag = false;
                                        foreach (Control ctrl in turnoverCard.Controls)
                                        {
                                            if (ctrl != lblGunlukCiro && ctrl.Tag?.ToString() != "arrow")
                                            {
                                                ctrl.Visible = false; // Açıklamadan ve ok’tan diğerlerini gizle
                                            }
                                            if (ctrl.Tag?.ToString() == "arrow") ctrl.Text = "▼"; // Ok’u aşağı çevir
                                        }
                                    }
                                };

                                // Kartın Click olayını bağla
                                turnoverCard.Click += cardClickHandler;

                                // Tüm label’lara tıklama olayını ekle (kartın her yerde tıklanabilir olsun)
                                foreach (Control ctrl in turnoverCard.Controls)
                                {
                                    ctrl.Click += cardClickHandler; // Aynı olay işleyicisini kullan
                                }

                                // Kartı panele ekle
                                dailyTurnoverPnl.Controls.Add(turnoverCard);
                            }

                            // Kayıt sayısını kontrol et (hata ayıklama için)
                            if (recordCount > 0)
                            {
                                MessageBox.Show($"Günlük ciro için {recordCount} kayıt bulundu ve kartlar oluşturuldu.");
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Günlük Ciro Yükleme Hatası: " + ex.Message);
            }
        }

        private void UpdateCardWidths(FlowLayoutPanel panel, int fixedWidth)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Panel card)
                {
                    card.Width = fixedWidth;

                    // Açıklama label’ının maksimum genişliğini güncelle
                    var lblAciklama = card.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() != "arrow");
                    if (lblAciklama != null)
                    {
                        lblAciklama.MaximumSize = new Size(card.Width - 40, 0);
                    }

                    // Ok’un pozisyonunu güncelle (her zaman sağda hizalı kalsın)
                    var lblArrow = card.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "arrow");
                    if (lblArrow != null)
                    {
                        using (Graphics g = card.CreateGraphics())
                        {
                            SizeF arrowSize = g.MeasureString(lblArrow.Text, lblArrow.Font);
                            lblArrow.Location = new Point(card.Width - (int)arrowSize.Width - 10, lblArrow.Location.Y); // Kartın sağ kenarına hizala
                        }
                    }
                }
            }
        }

        private void AnimateCard(Panel card, int startHeight, int targetHeight, bool isExpanding)
        {
            const int animationSpeed = 10; // Her adımda artırılacak/azaltılacak piksel
            const int interval = 10; // Timer aralığı (milisaniye)

            Timer animationTimer = new Timer
            {
                Interval = interval
            };

            animationTimer.Tick += (s, e) =>
            {
                if (isExpanding)
                {
                    // Açılma animasyonu
                    if (card.Height < targetHeight)
                    {
                        card.Height = Math.Min(card.Height + animationSpeed, targetHeight);
                    }
                    else
                    {
                        animationTimer.Stop();
                        animationTimer.Dispose();
                    }
                }
                else
                {
                    // Kapanma animasyonu
                    if (card.Height > targetHeight)
                    {
                        card.Height = Math.Max(card.Height - animationSpeed, targetHeight);
                    }
                    else
                    {
                        animationTimer.Stop();
                        animationTimer.Dispose();
                    }
                }
            };

            animationTimer.Start();
        }
    }
}
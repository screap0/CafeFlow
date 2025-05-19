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
    public partial class StokTakip : Form
    {
        private List<Panel> kartlar = new List<Panel>();
        private List<dynamic> tumStokVerileri = new List<dynamic>();
        private string aktifFiltre = "Tümü";
        

        public StokTakip()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(31, 30, 68);
            this.MinimumSize = new Size(900, 600);

            // Filtreleme kontrolleri oluştur
            OlusturFiltreleKontrolleri();

            // Stok verileri al ve analiz panelini yükle
            StokVerileriniAl();
            StokAnalizPaneliYukle();

            // Form boyutu değiştiğinde kartları yeniden düzenle
            this.Resize += StokTakip_Resize;
        }

        private void OlusturFiltreleKontrolleri()
        {
            // Arama kutusu oluştur
            TextBox txtArama = new TextBox();
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(250, 30);
            txtArama.Location = new Point(this.ClientSize.Width - 270, 25);
            txtArama.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtArama.Font = new Font("Segoe UI", 11);
            txtArama.Text = "Ürün ara...";
            txtArama.ForeColor = Color.Gray;
            txtArama.BorderStyle = BorderStyle.FixedSingle;
            txtArama.TextChanged += TxtArama_TextChanged;
            txtArama.GotFocus += (s, e) => {
                if (txtArama.Text == "Ürün ara...") {
                    txtArama.Text = "";
                    txtArama.ForeColor = Color.Black;
                }
            };
            txtArama.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtArama.Text)) {
                    txtArama.Text = "Ürün ara...";
                    txtArama.ForeColor = Color.Gray;
                }
            };
            this.Controls.Add(txtArama);

            // Arama ikonu
            PictureBox pbArama = new PictureBox();
            pbArama.Size = new Size(20, 20);
            pbArama.Location = new Point(txtArama.Right - 30, txtArama.Top + 5);
            pbArama.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbArama.BackColor = Color.Transparent;
            // Arama ikonu için Font Awesome veya başka bir ikon kullanabilirsiniz
            this.Controls.Add(pbArama);

            // Filtreleme butonları panel
            Panel pnlFiltre = new Panel();
            pnlFiltre.Size = new Size(350, 40);
            pnlFiltre.Location = new Point(30, 60);
            pnlFiltre.BackColor = Color.Transparent;
            this.Controls.Add(pnlFiltre);

            // Filtreleme butonları
            string[] filtreler = { "Tümü", "Acil", "Düşük", "Yeterli" };
            int btnGenislik = 80;
            int aralik = 5;

            for (int i = 0; i < filtreler.Length; i++)
            {
                Button btnFiltre = new Button();
                btnFiltre.Text = filtreler[i];
                btnFiltre.Size = new Size(btnGenislik, 35);
                btnFiltre.Location = new Point(i * (btnGenislik + aralik), 0);
                btnFiltre.FlatStyle = FlatStyle.Flat;
                btnFiltre.FlatAppearance.BorderSize = 0;
                btnFiltre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                btnFiltre.Cursor = Cursors.Hand;
                btnFiltre.Tag = filtreler[i];

                // İlk buton (Tümü) varsayılan olarak seçili
                if (i == 0)
                {
                    btnFiltre.BackColor = Color.FromArgb(92, 91, 140);
                    btnFiltre.ForeColor = Color.White;
                }
                else
                {
                    btnFiltre.BackColor = Color.FromArgb(52, 51, 95);
                    btnFiltre.ForeColor = Color.Silver;
                }

                btnFiltre.Click += BtnFiltre_Click;
                pnlFiltre.Controls.Add(btnFiltre);
            }

            // FlowLayoutPanel konumunu ayarla
            flowPanelStokAnaliz.Location = new Point(0, 110);
            flowPanelStokAnaliz.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 110);
        }

        private void BtnFiltre_Click(object sender, EventArgs e)
        {
            Button tiklananBtn = sender as Button;
            aktifFiltre = tiklananBtn.Tag.ToString();

            // Tüm butonları varsayılan duruma getir
            foreach (Control ctrl in (tiklananBtn.Parent as Panel).Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;
                    btn.BackColor = Color.FromArgb(52, 51, 95);
                    btn.ForeColor = Color.Silver;
                }
            }

            // Tıklanan butonu seçili göster
            tiklananBtn.BackColor = Color.FromArgb(92, 91, 140);
            tiklananBtn.ForeColor = Color.White;

            // Stok verilerini filtrele ve yeniden yükle
            StokAnalizPaneliYukle();
        }

        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            TextBox txtArama = sender as TextBox;
            if (txtArama != null && txtArama.Text != "Ürün ara...")
            {
                txtArama.ForeColor = Color.Black;
            }
            StokAnalizPaneliYukle();
        }

        private void StokTakip_Resize(object sender, EventArgs e)
        {
            // Form boyutu değiştiğinde kartları yeniden düzenle
            KartGenislikleriniGuncelle();

            // Arama kutusu konumunu güncelle
            TextBox txtArama = this.Controls.Find("txtArama", true).FirstOrDefault() as TextBox;
            if (txtArama != null)
            {
                txtArama.Location = new Point(this.ClientSize.Width - 270, 25);
            }
        }

        private void KartGenislikleriniGuncelle()
        {
            int panelGenislik = flowPanelStokAnaliz.ClientSize.Width;
            int kartMargin = 20; // Kartlar arası toplam boşluk
            int minKartGenislik = 280;
            int maxKartGenislik = 420;

            // Maksimum kaç kart sığar?
            int kartSayisi = Math.Max(1, (panelGenislik + kartMargin) / (maxKartGenislik + kartMargin));

            // Kart genişliğini hesapla
            int kartGenislik = (panelGenislik - (kartSayisi + 1) * kartMargin) / kartSayisi;
            kartGenislik = Math.Max(minKartGenislik, Math.Min(maxKartGenislik, kartGenislik));

            foreach (var kart in kartlar)
            {
                kart.Width = kartGenislik;
            }
        }

        private void StokVerileriniAl()
        {
            tumStokVerileri.Clear();

            try
            {
                using (MySqlConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.StokID,
                            s.UrunAdi,
                            s.Miktar AS MevcutStok,
                            COALESCE(SUM(CASE 
                                WHEN sh.HareketTuru = 'Güncelle' 
                                AND sh.Tarih >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                THEN sh.Miktar 
                                ELSE 0 
                            END), 0) AS Son30GunTuketim
                        FROM Stok s
                        LEFT JOIN StokHareket sh ON s.StokID = sh.StokID
                        GROUP BY s.StokID, s.UrunAdi, s.Miktar
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int stokID = Convert.ToInt32(reader["StokID"]);
                            string urunAdi = reader["UrunAdi"].ToString();
                            int stok = Convert.ToInt32(reader["MevcutStok"]);
                            int tuketim = Convert.ToInt32(reader["Son30GunTuketim"]);

                            double gunlukTuketim = tuketim / 30.0;
                            double tahminiGun = gunlukTuketim > 0 ? stok / gunlukTuketim : double.PositiveInfinity;

                            // Aciliyet durumunu belirle
                            string aciliyetDurum;
                            Color aciliyetRenk;
                            Color kartRenk;

                            if (tahminiGun <= 7)
                            {
                                aciliyetDurum = "Acil";
                                aciliyetRenk = Color.FromArgb(220, 53, 69); // Kırmızı
                                kartRenk = Color.FromArgb(64, 44, 52);      // Koyu kırmızı arka plan
                            }
                            else if (tahminiGun <= 15)
                            {
                                aciliyetDurum = "Düşük";
                                aciliyetRenk = Color.FromArgb(255, 193, 7); // Sarı/Turuncu
                                kartRenk = Color.FromArgb(64, 58, 42);      // Koyu turuncu arka plan
                            }
                            else
                            {
                                aciliyetDurum = "Yeterli";
                                aciliyetRenk = Color.FromArgb(40, 167, 69); // Yeşil
                                kartRenk = Color.FromArgb(44, 62, 80);      // Standart arka plan
                            }

                            tumStokVerileri.Add(new
                            {
                                StokID = stokID,
                                UrunAdi = urunAdi,
                                MevcutStok = stok,
                                Son30GunTuketim = tuketim,
                                TahminiGun = tahminiGun,
                                AciliyetDurum = aciliyetDurum,
                                AciliyetRenk = aciliyetRenk,
                                KartRenk = kartRenk
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok verileri alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StokAnalizPaneliYukle()
        {
            // FlowLayoutPanel'i temizle
            flowPanelStokAnaliz.Controls.Clear();
            kartlar.Clear();

            // Filtreleme ve arama kriterlerini uygula
            TextBox txtArama = this.Controls.Find("txtArama", true).FirstOrDefault() as TextBox;
            string aramaMetni = txtArama != null ? txtArama.Text.ToLower() : "";
            if (aramaMetni == "ürün ara...") aramaMetni = "";

            // Verileri filtrele ve sırala
            var filtrelenmisStoklar = tumStokVerileri
                .Where(s => s.UrunAdi.ToLower().Contains(aramaMetni) &&
                       (aktifFiltre == "Tümü" || s.AciliyetDurum == aktifFiltre))
                .OrderBy(s => {
                    // Acil stoklar önce, sonra düşük stoklar, sonra yeterli stoklar
                    if (s.AciliyetDurum == "Acil") return 1;
                    if (s.AciliyetDurum == "Düşük") return 2;
                    return 3;
                })
                .ThenBy(s => s.TahminiGun)
                .ToList();

            // Filtrelenen stoklar için kartları oluştur
            foreach (var stok in filtrelenmisStoklar)
            {
                Panel kart = OlusturStokKart(stok);
                flowPanelStokAnaliz.Controls.Add(kart);
                kartlar.Add(kart);
            }

            // Eğer hiç sonuç yoksa bilgi mesajı göster
            if (filtrelenmisStoklar.Count == 0)
            {
                Label lblBosFiltre = new Label();
                lblBosFiltre.Text = "Bu filtreye uygun ürün bulunamadı.";
                lblBosFiltre.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                lblBosFiltre.ForeColor = Color.White;
                lblBosFiltre.AutoSize = true;
                lblBosFiltre.Padding = new Padding(10);
                flowPanelStokAnaliz.Controls.Add(lblBosFiltre);
            }

            KartGenislikleriniGuncelle();
        }

        private Panel OlusturStokKart(dynamic stok)
        {
            Panel kart = new Panel();
            kart.Width = 300; // Varsayılan genişlik, KartGenislikleriniGuncelle'de değişecek
            kart.Height = 150;
            kart.Margin = new Padding(10);
            kart.BorderStyle = BorderStyle.None;
            kart.BackColor = stok.KartRenk;
            kart.Padding = new Padding(20);
            kart.Cursor = Cursors.Hand;
            kart.Tag = stok.StokID;

            // Kart stili için yuvarlatılmış köşeler
            kart.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(kart.BackColor))
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 18;
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(kart.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(kart.Width - radius, kart.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, kart.Height - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    g.FillPath(brush, path);
                }
            };

            // Aciliyet durumu için gösterge
            Panel aciliyetGosterge = new Panel();
            aciliyetGosterge.Size = new Size(5, kart.Height);
            aciliyetGosterge.Location = new Point(0, 0);
            aciliyetGosterge.BackColor = stok.AciliyetRenk;
            aciliyetGosterge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            kart.Controls.Add(aciliyetGosterge);

            // Aciliyet etiketi
            Label aciliyet = new Label();
            aciliyet.AutoSize = true;
            aciliyet.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            aciliyet.ForeColor = Color.White;
            aciliyet.BackColor = stok.AciliyetRenk;
            aciliyet.Text = stok.AciliyetDurum;
            aciliyet.Padding = new Padding(8, 2, 8, 2);
            aciliyet.Location = new Point(kart.Width - 100, 10);
            aciliyet.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Aciliyet etiketini yuvarla
            aciliyet.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(aciliyet.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(aciliyet.Width - radius, aciliyet.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, aciliyet.Height - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    e.Graphics.FillPath(new SolidBrush(aciliyet.BackColor), path);
                    e.Graphics.DrawString(aciliyet.Text, aciliyet.Font, Brushes.White,
                        new PointF(aciliyet.Padding.Left, aciliyet.Padding.Top));
                }
            };

            // Ürün adı (başlık)
            Label lblUrun = new Label();
            lblUrun.Text = stok.UrunAdi;
            lblUrun.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblUrun.ForeColor = Color.White;
            lblUrun.AutoSize = true;
            lblUrun.Location = new Point(15, 15);
            lblUrun.MaximumSize = new Size(kart.Width - 120, 0);

            // Stok ve tüketim bilgileri
            Label lblDetay = new Label();
            lblDetay.Text = $"Mevcut Stok: {stok.MevcutStok}\nSon 30 Günlük Tüketim: {stok.Son30GunTuketim}\nTahmini Yetecek Gün: {(stok.TahminiGun == double.PositiveInfinity ? "∞" : stok.TahminiGun.ToString("0"))}";
            lblDetay.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblDetay.ForeColor = Color.Gainsboro;
            lblDetay.AutoSize = true;
            lblDetay.Location = new Point(15, 50);

            // İlerleme çubuğu (tahmini gün göstergesi)
            if (stok.TahminiGun != double.PositiveInfinity)
            {
                Panel pnlIlerleme = new Panel();
                pnlIlerleme.Size = new Size(kart.Width - 40, 10);
                pnlIlerleme.Location = new Point(15, kart.Height - 25);
                pnlIlerleme.BackColor = Color.FromArgb(64, 64, 64);
                pnlIlerleme.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                // Yuvarlatılmış köşeli ilerleme çubuğu
                pnlIlerleme.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    int radius = 5;

                    // Arka plan
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(0, 0, radius, radius, 180, 90);
                        path.AddArc(pnlIlerleme.Width - radius, 0, radius, radius, 270, 90);
                        path.AddArc(pnlIlerleme.Width - radius, pnlIlerleme.Height - radius, radius, radius, 0, 90);
                        path.AddArc(0, pnlIlerleme.Height - radius, radius, radius, 90, 90);
                        path.CloseFigure();
                        g.FillPath(new SolidBrush(pnlIlerleme.BackColor), path);
                    }

                    // İlerleme çubuğu (tahmini gün göstergesi)
                    double yuzde = Math.Min(stok.TahminiGun / 30.0, 1.0); // 30 gün maksimum gösterge
                    int ilerlemeGenislik = (int)(yuzde * pnlIlerleme.Width);

                    if (ilerlemeGenislik > 0)
                    {
                        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            path.AddArc(0, 0, radius, radius, 180, 90);
                            if (ilerlemeGenislik >= pnlIlerleme.Width - radius)
                            {
                                path.AddArc(ilerlemeGenislik - radius, 0, radius, radius, 270, 90);
                                path.AddArc(ilerlemeGenislik - radius, pnlIlerleme.Height - radius, radius, radius, 0, 90);
                            }
                            else
                            {
                                path.AddLine(ilerlemeGenislik, 0, ilerlemeGenislik, pnlIlerleme.Height);
                            }
                            path.AddArc(0, pnlIlerleme.Height - radius, radius, radius, 90, 90);
                            path.CloseFigure();
                            g.FillPath(new SolidBrush(stok.AciliyetRenk), path);
                        }
                    }
                };

                kart.Controls.Add(pnlIlerleme);
            }

            // Hover efekti
            Color normalColor = stok.KartRenk;
            Color hoverColor = Color.FromArgb(
                Math.Min(normalColor.R + 20, 255),
                Math.Min(normalColor.G + 20, 255),
                Math.Min(normalColor.B + 20, 255)
            );

            kart.MouseEnter += (s, e) => {
                kart.BackColor = hoverColor;
                // Animasyon ve diğer hover efektleri buraya eklenebilir
            };
            kart.MouseLeave += (s, e) => kart.BackColor = normalColor;

            // Kart tıklama olayı
            kart.Click += (s, e) =>
            {
                // Detaylı bilgi göster
                ShowStokDetay(stok);
            };

            // Kontrolleri karta ekle
            kart.Controls.Add(aciliyet);
            kart.Controls.Add(lblUrun);
            kart.Controls.Add(lblDetay);

            return kart;
        }

        private void ShowStokDetay(dynamic stok)
        {
            // Detaylı stok bilgisi için formun içine dialog eklenebilir
            // veya yeni bir form açılabilir

            // Şimdilik basit bir messagebox gösterelim
            MessageBox.Show(
                $"Ürün: {stok.UrunAdi}\n" +
                $"Mevcut Stok: {stok.MevcutStok}\n" +
                $"Son 30 Günlük Tüketim: {stok.Son30GunTuketim}\n" +
                $"Tahmini Yetecek Gün: {(stok.TahminiGun == double.PositiveInfinity ? "∞" : stok.TahminiGun.ToString("0"))}\n\n" +
                $"Bu ürün için stok durumu: {stok.AciliyetDurum}",
                "Stok Detay",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Farklı kriterlere göre stok analizi için ek özellikler eklenebilir
    }
}
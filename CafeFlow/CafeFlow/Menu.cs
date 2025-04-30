using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class Menu : Form
    {
        private readonly DatabaseConnection dbConnection;
        private readonly Panel menuItemTemplate; // menuItem şablonu
        private Panel selectedPanel; // Şu an seçili olan panel
        public Menu()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            menuItemTemplate = menuItem; // Form tasarımında oluşturduğun menuItem paneli
            if (menuItemTemplate == null)
            {
                MessageBox.Show("menuItem paneli bulunamadı! Tasarımda 'menuItem' adında bir panel olduğundan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            menuItemTemplate.Visible = false; // Şablon paneli gizli tut
            kategoricb.Items.AddRange(new[] { "Sicak Icecekler", "Soguk Icecekler", "Ozel Secim" });
        }

            

        public void Menu_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
        }
        public void LoadMenuItems()
        {
            // Mevcut panelleri temizle
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control != menuItemTemplate) // Şablon paneli hariç
                {
                    control.Dispose();
                }
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(menuItemTemplate); // Şablonu geri ekle

            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Urun_ismi, kategori, aciklama, tutar, resim_yolu FROM Menu ORDER BY FIELD(kategori, 'Sicak Icecekler', 'Soguk Icecekler', 'Ozel Secim'), Urun_ismi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Panel newPanel = ClonePanel(menuItemTemplate);
                                newPanel.Visible = true;

                                var pictureBox = newPanel.Controls.Find("pictureBox", true).Length > 0 ? newPanel.Controls.Find("pictureBox", true)[0] as PictureBox : null;
                                var urunIsmiLabel = newPanel.Controls.Find("urunIsmiLabel", true).Length > 0 ? newPanel.Controls.Find("urunIsmiLabel", true)[0] as Label : null;
                                var kategoriLabel = newPanel.Controls.Find("kategoriLabel", true).Length > 0 ? newPanel.Controls.Find("kategoriLabel", true)[0] as Label : null;
                                var aciklamaLabel = newPanel.Controls.Find("aciklamaLabel", true).Length > 0 ? newPanel.Controls.Find("aciklamaLabel", true)[0] as Label : null;
                                var tutarLabel = newPanel.Controls.Find("tutarLabel", true).Length > 0 ? newPanel.Controls.Find("tutarLabel", true)[0] as Label : null;

                                if (pictureBox == null || urunIsmiLabel == null || kategoriLabel == null || aciklamaLabel == null || tutarLabel == null)
                                {
                                    MessageBox.Show($"Paneldeki kontrollerden biri bulunamadı! Kontrol isimleri: pictureBox, urunIsmiLabel, kategoriLabel, aciklamaLabel, tutarLabel", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }

                                urunIsmiLabel.Text = reader["Urun_ismi"].ToString();
                                kategoriLabel.Text = reader["kategori"].ToString();
                                aciklamaLabel.Text = reader["aciklama"].ToString();
                                tutarLabel.Text = $"{reader["tutar"]:N2} ₺";

                                string imagePath = reader["resim_yolu"].ToString();
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    try
                                    {
                                        string imageUrl = $"http://www.cafeflow.com.tr/{imagePath}";
                                        using (WebClient webClient = new WebClient())
                                        {
                                            byte[] imageBytes = webClient.DownloadData(imageUrl);
                                            using (MemoryStream ms = new MemoryStream(imageBytes))
                                            {
                                                pictureBox.Image = Image.FromStream(ms);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        pictureBox.Image = null;
                                        Console.WriteLine($"Resim yükleme hatası: {ex.Message}");
                                    }
                                }

                                // Panelin verilerini saklamak için Tag özelliğini kullan
                                newPanel.Tag = new MenuItemData
                                {
                                    UrunIsmi = reader["Urun_ismi"].ToString(),
                                    Kategori = reader["kategori"].ToString(),
                                    Aciklama = reader["aciklama"].ToString(),
                                    Tutar = Convert.ToDecimal(reader["tutar"]),
                                    ResimYolu = reader["resim_yolu"].ToString()
                                };

                                // Panel tıklama olayını ekle
                                newPanel.Click += Panel_Click;
                                foreach (Control ctrl in newPanel.Controls)
                                {
                                    ctrl.Click += Panel_Click; // İçindeki kontroller de tıklanabilir
                                }

                                flowLayoutPanel1.Controls.Add(newPanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel ClonePanel(Panel template)
        {
            // Yeni bir panel oluştur
             Panel newPanel = new Panel
            {
                Size = template.Size,
                Margin = template.Margin,
                Padding = template.Padding,
                BackColor = template.BackColor,
                BorderStyle = template.BorderStyle
            };

            // Şablon paneldeki tüm kontrolleri klonla
            foreach (Control control in template.Controls)
            {
                Control newControl = CloneControl(control);
                newPanel.Controls.Add(newControl);
            }

            return newPanel;
        }

        private Control CloneControl(Control control)
        {
            // Kontrolün tipine göre klonla
            if (control is PictureBox)
            {
                PictureBox template = (PictureBox)control;
                return new PictureBox
                {
                    Name = template.Name,
                    Size = template.Size,
                    Location = template.Location,
                    SizeMode = template.SizeMode,
                    BorderStyle = template.BorderStyle
                };
            }
            else if (control is Label)
            {
                Label template = (Label)control;
                return new Label
                {
                    Name = template.Name,
                    Text = template.Text,
                    Size = template.Size,
                    Location = template.Location,
                    Font = template.Font,
                    ForeColor = template.ForeColor,
                    BackColor = template.BackColor,
                    TextAlign = template.TextAlign
                };
            }

            // Diğer kontrol türleri için gerekirse ekleme yap
            return new Control
            {
                Name = control.Name,
                Size = control.Size,
                Location = control.Location
            };
        }

        private class MenuItemData
        {
            public string UrunIsmi { get; set; }
            public string Kategori { get; set; }
            public string Aciklama { get; set; }
            public decimal Tutar { get; set; }
            public string ResimYolu { get; set; }
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            // Tıklanan kontrolün ana panelini bul
            Panel clickedPanel = sender is Panel ? (Panel)sender : ((Control)sender).Parent as Panel;
            if (clickedPanel == null || clickedPanel.Tag == null) return;

            // Seçili paneli güncelle
            if (selectedPanel != null)
            {
                selectedPanel.BackColor = menuItemTemplate.BackColor; // Önceki seçili panelin rengini sıfırla
            }
            selectedPanel = clickedPanel;
            selectedPanel.BackColor = Color.FromArgb(34, 33, 74); // Seçili panelin rengini değiştir

            // Paneldeki verileri TextBox ve ComboBox'a yaz
            MenuItemData data = (MenuItemData)selectedPanel.Tag;
            uruntxt.Text = data.UrunIsmi;
            aciklamatxt.Text = data.Aciklama;
            tutartxt.Text = data.Tutar.ToString("N2");
            kategoricb.SelectedItem = data.Kategori;
        }

        private void resimsecbtn_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
            {
                MessageBox.Show("Lütfen önce bir menü öğesi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    string fileName = Path.GetFileName(filePath);
                    string ftpPath = $"ftp://cafeflow.com.tr/public_html/resim/{fileName}";
                    string ftpUser = "caf2bbowcomtr";
                    string ftpPass = "a018c-f1d1c0";

                    // FTP'ye dosyayı yükle
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(ftpUser, ftpPass);

                    byte[] fileContents;
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        fileContents = new byte[fs.Length];
                        fs.Read(fileContents, 0, fileContents.Length);
                    }

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                    // Veritabanını güncelle
                    MenuItemData data = (MenuItemData)selectedPanel.Tag;
                    string newImagePath = $"resim/{fileName}";
                    using (MySqlConnection conn = dbConnection.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE Menu SET resim_yolu = @resimYolu WHERE Urun_ismi = @urunIsmi";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@resimYolu", newImagePath);
                            cmd.Parameters.AddWithValue("@urunIsmi", data.UrunIsmi);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // PictureBox'ı güncelle
                    var pictureBox = selectedPanel.Controls.Find("pictureBox", true)[0] as PictureBox;
                    pictureBox.Image = Image.FromFile(filePath);
                    data.ResimYolu = newImagePath;
                    selectedPanel.Tag = data;

                    MessageBox.Show("Resim başarıyla yüklendi ve veritabanı güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Resim yükleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuguncellebtn_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
            {
                MessageBox.Show("Lütfen önce bir menü öğesi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giriş doğrulaması
            if (string.IsNullOrWhiteSpace(uruntxt.Text))
            {
                MessageBox.Show("Ürün ismi boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tutartxt.Text) || !decimal.TryParse(tutartxt.Text, out decimal tutar))
            {
                MessageBox.Show("Geçerli bir tutar girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kategoricb.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MenuItemData oldData = (MenuItemData)selectedPanel.Tag;
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Menu SET Urun_ismi = @urunIsmi, kategori = @kategori, aciklama = @aciklama, tutar = @tutar WHERE Urun_ismi = @oldUrunIsmi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@urunIsmi", MySqlDbType.VarChar).Value = uruntxt.Text;
                        cmd.Parameters.Add("@kategori", MySqlDbType.VarChar).Value = kategoricb.SelectedItem.ToString();
                        cmd.Parameters.Add("@aciklama", MySqlDbType.VarChar).Value = aciklamatxt.Text;
                        cmd.Parameters.Add("@tutar", MySqlDbType.Decimal).Value = tutar;
                        cmd.Parameters.Add("@oldUrunIsmi", MySqlDbType.VarChar).Value = oldData.UrunIsmi;
                        cmd.ExecuteNonQuery();
                    }
                }

                // Panelleri tekrar yükle
                LoadMenuItems();

                // TextBox ve ComboBox'ı temizle
                uruntxt.Clear();
                aciklamatxt.Clear();
                tutartxt.Clear();
                kategoricb.SelectedIndex = -1;
                selectedPanel = null;

                MessageBox.Show("Menü öğesi başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuEkle menuEkle = new MenuEkle();
            menuEkle.Show();
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
            {
                MessageBox.Show("Lütfen önce bir menü öğesi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Silme işlemini onaylat
            MenuItemData data = (MenuItemData)selectedPanel.Tag;
            DialogResult result = MessageBox.Show($"Ürün '{data.UrunIsmi}' silinecek. Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // FTP'den resmi sil (eğer varsa)
                if (!string.IsNullOrEmpty(data.ResimYolu))
                {
                    string ftpPath = $"ftp://cafeflow.com.tr/public_html/{data.ResimYolu}";
                    string ftpUser = "caf2bbowcomtr";
                    string ftpPass = "a018c-f1d1c0";

                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                        request.Method = WebRequestMethods.Ftp.DeleteFile;
                        request.Credentials = new NetworkCredential(ftpUser, ftpPass);
                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        {
                            response.Close();
                        }
                    }
                    catch (WebException ex)
                    {
                        // Resim yoksa veya silme başarısızsa, hata mesajı göster ama işlemi durdurma
                        MessageBox.Show($"Resim silme hatası: {ex.Message}. Ürün silme işlemine devam ediliyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Veritabanından ürünü sil
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Menu WHERE Urun_ismi = @urunIsmi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@urunIsmi", data.UrunIsmi);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Silme başarısız! Ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Panelleri tekrar yükle
                LoadMenuItems();

                // Formu sıfırla
                uruntxt.Clear();
                aciklamatxt.Clear();
                tutartxt.Clear();
                kategoricb.SelectedIndex = -1;
                selectedPanel = null;

                MessageBox.Show("Ürün başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yenilebtn_Click(object sender, EventArgs e)
        {
            Menu_Load(sender, e);
        }
    }




}


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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class MenuEkle : Form
    {
        private readonly DatabaseConnection dbConnection;
        private string selectedImagePath; // Seçilen resmin yerel dosya yolu
        public MenuEkle()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            // tutartxt için giriş kısıtlamaları
            // tutartxt için giriş kısıtlamaları
            kategoricb.Items.AddRange(new[] { "Sıcak İçecekler", "Soğuk İçecekler", "Özel Seçim" });
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resimsecbtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Resim seçme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void eklebtn_Click(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Lütfen bir resim seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Resmi FTP'ye yükle
                string fileName = Path.GetFileName(selectedImagePath);
                string ftpPath = $"ftp://cafeflow.com.tr/public_html/resim/{fileName}";
                string ftpUser = "caf2bbowcomtr";
                string ftpPass = "a018c-f1d1c0";
                string imagePath = $"resim/{fileName}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpUser, ftpPass);

                byte[] fileContents;
                using (FileStream fs = File.OpenRead(selectedImagePath))
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

                // Veritabanına ürünü ekle
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Menu (Urun_ismi, kategori, aciklama, tutar, resim_yolu) VALUES (@urunIsmi, @kategori, @aciklama, @tutar, @resimYolu)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@urunIsmi", uruntxt.Text);
                        cmd.Parameters.AddWithValue("@kategori", kategoricb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@aciklama", aciklamatxt.Text);
                        cmd.Parameters.AddWithValue("@tutar", tutar);
                        cmd.Parameters.AddWithValue("@resimYolu", imagePath);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Formu sıfırla
                Menu menu = new Menu();
                menu.LoadMenuItems();
                
                uruntxt.Clear();
                aciklamatxt.Clear();
                tutartxt.Clear();
                kategoricb.SelectedIndex = -1;
                selectedImagePath = null;

                MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün ekleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

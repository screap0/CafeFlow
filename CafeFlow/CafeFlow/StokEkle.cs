﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class StokEkle : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        string kullaniciadi;
        string txtform;
        public StokEkle(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;
            txtform = "StokEkle";

            ekleBtn.Click += EkleBtn_Click;
        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            string urun = urunTxt.Text.Trim();
            string aciklama = aciklamaTxt.Text.Trim();
            if (!int.TryParse(miktarTxt.Text.Trim(), out int miktar))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin (Miktar).");
                return;
            }

            if (string.IsNullOrWhiteSpace(urun))
            {
                MessageBox.Show("Ürün adı boş olamaz.");
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Stok (UrunAdi, Miktar, Aciklama) VALUES (@urun, @miktar, @aciklama)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun", urun);
                        cmd.Parameters.AddWithValue("@miktar", miktar);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Stok başarıyla eklendi.");
                    db.Log(txtform, "Stok eklendi: " + "Ürün Adı:"+urun+"Ürün Miktarı: "+miktar+"Ürün Acıklaması: "+aciklama, DateTime.Now, kullaniciadi);
                    this.Close(); // Formu kapat
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stok eklenirken hata oluştu: " + ex.Message);
                    db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

public class DatabaseConnection
{
    private string ConnectionString { get; set; }

    public DatabaseConnection()
    {
        ConnectionString = "Server=www.cafeflow.com.tr;Database=caf2bbowcomtr_CafeDB;Uid=caf2bbowcomtr_cafedb;Pwd=Deneme21*.;";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    public bool KullaniciBilgileriniKontrolEt(string username, string password)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @username AND Sifre = @password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return count == 1;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: "+ex);
                return false; 
            }
        }
    }
    public void KullaniciKayit(string ad,string soyad,string username,string password)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "insert into Kullanicilar(Ad,Soyad,KullaniciAdi,Sifre) values(@ad,@soyad,@kullaniciadi,@sifre)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@soyad", soyad);
                    command.Parameters.AddWithValue("@kullaniciadi", username);
                    command.Parameters.AddWithValue("@sifre", password);

                    command.ExecuteNonQuery(); 
                    MessageBox.Show("Tebrikler. Başarılı bir şekilde kaydoldunuz!");
                }


            }
            catch (Exception ex) {
                MessageBox.Show("Hata: " + ex);
                
            }
        }
    }

    public List<DateTime> SiparisTarihleriGetir()
    {
        List<DateTime> tarihListesi = new List<DateTime>();

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT siparis_tarihi FROM Siparisler WHERE siparis_tarihi >= DATE_SUB(NOW(), INTERVAL 7 DAY)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarihListesi.Add(reader.GetDateTime("siparis_tarihi"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş tarihleri alınırken hata oluştu: " + ex.Message);
            }
        }

        return tarihListesi;
    }
    public string EnCokSiparisVerilenUrun()
    {
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            string query = "SELECT siparis_aciklamasi FROM Siparisler";
            Dictionary<string, int> urunSayilari = new Dictionary<string, int>();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string siparisAciklamasi = reader["siparis_aciklamasi"].ToString();
                    if (!string.IsNullOrEmpty(siparisAciklamasi))
                    {
                        // Satırları ayır (\n ile)
                        string[] urunler = siparisAciklamasi.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string urun in urunler)
                        {
                            if (urun.Contains("-"))
                            {
                                string urunAdi = urun.Split('-')[0].Trim();
                                if (!string.IsNullOrEmpty(urunAdi))
                                {
                                    // Ürün adını say
                                    if (urunSayilari.ContainsKey(urunAdi))
                                        urunSayilari[urunAdi]++;
                                    else
                                        urunSayilari[urunAdi] = 1;
                                }
                            }
                        }
                    }
                }
            }

            // En çok sipariş edilen ürünü bul
            if (urunSayilari.Any())
            {
                var enCokSiparis = urunSayilari.OrderByDescending(x => x.Value).First();
                return enCokSiparis.Key; // En çok sipariş edilen ürün adı
            }

            return "Veri Yok";
        }
    }

    //public int OrtalamaSiparisSuresi()
    //{
    //    using (MySqlConnection conn = GetConnection())
    //    {
    //        conn.Open();
    //        string query = "SELECT AVG(TIMESTAMPDIFF(MINUTE, siparis_tarihi, teslim_tarihi)) AS ortalama_sure FROM Siparisler";
    //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
    //        {
    //            object result = cmd.ExecuteScalar();
    //            if (result != DBNull.Value)
    //            {
    //                return Convert.ToInt32(result);
    //            }
    //            else
    //            {
    //                return 0;
    //            }
    //        }
    //    }
    //}

    //public string EnSadikMusteri()
    //{
    //    using (MySqlConnection conn = GetConnection())
    //    {
    //        conn.Open();
    //        string query = "SELECT isim, COUNT(*) as siparis_sayisi FROM Siparisler GROUP BY musteri_adi ORDER BY siparis_sayisi DESC LIMIT 1";
    //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
    //        using (MySqlDataReader reader = cmd.ExecuteReader())
    //        {
    //            if (reader.Read())
    //            {
    //                return reader["musteri_adi"].ToString();
    //            }
    //            else
    //            {
    //                return "Veri Yok";
    //            }
    //        }
    //    }
    //}
    public int AylikMusteriSayisiGetir()
    {
        int musteriSayisi = 0;

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();

                // İçinde bulunduğumuz ayın başından şu ana kadar olan siparişleri sorgula
                string query = @"SELECT COUNT(DISTINCT isim) as musteri_sayisi 
                            FROM Siparisler 
                            WHERE siparis_tarihi >= DATE_FORMAT(CURRENT_DATE(), '%Y-%m-01')
                            AND siparis_tarihi <= NOW()";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        musteriSayisi = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aylık müşteri sayısı hesaplanırken hata oluştu: " + ex.Message);
            }
        }

        return musteriSayisi;
    }

    public decimal AylikKazancGetir()
    {
        decimal toplamKazanc = 0;

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();

                // İçinde bulunduğumuz ayın başından şu ana kadar olan siparişlerin toplam tutarı
                string query = @"SELECT SUM(toplam_tutar) as aylik_kazanc 
                            FROM Siparisler 
                            WHERE siparis_tarihi >= DATE_FORMAT(CURRENT_DATE(), '%Y-%m-01')
                            AND siparis_tarihi <= NOW()
                           ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        toplamKazanc = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aylık kazanç hesaplanırken hata oluştu: " + ex.Message);
            }
        }

        return toplamKazanc;
    }

}


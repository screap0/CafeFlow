using System;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

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
                MessageBox.Show("Hata: " + ex);
                return false;
            }
        }
    }

    public void KullaniciKayit(string ad, string soyad, string username, string password)
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
            catch (Exception ex)
            {
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

    public string GetMostOrderedProduct()
    {
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            string query = "SELECT siparis_aciklamasi FROM Siparisler";
            Dictionary<string, int> productCounts = new Dictionary<string, int>();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string orderDescription = reader["siparis_aciklamasi"].ToString();
                    if (!string.IsNullOrEmpty(orderDescription))
                    {
                        string[] products = orderDescription.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string product in products)
                        {
                            if (product.Contains("-"))
                            {
                                string productName = product.Split('-')[0].Trim();
                                if (!string.IsNullOrEmpty(productName))
                                {
                                    if (productCounts.ContainsKey(productName))
                                        productCounts[productName]++;
                                    else
                                        productCounts[productName] = 1;
                                }
                            }
                        }
                    }
                }
            }

            if (productCounts.Any())
            {
                var mostOrdered = productCounts.OrderByDescending(x => x.Value).First();
                return mostOrdered.Key;
            }

            return "No Data";
        }
    }

    public int AylikMusteriSayisiGetir()
    {
        int musteriSayisi = 0;

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();

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

                string query = @"SELECT SUM(toplam_tutar) as aylik_kazanc 
                            FROM Siparisler 
                            WHERE siparis_tarihi >= DATE_FORMAT(CURRENT_DATE(), '%Y-%m-01')
                            AND siparis_tarihi <= NOW()";

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

    public int GetTotalOrderCount()
    {
        int totalOrders = 0;

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) as total_orders FROM Siparisler";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalOrders = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving total order count: " + ex.Message);
            }
        }

        return totalOrders;
    }

    public int GetCompletedOrderCount()
    {
        int completedOrders = 0;

        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) as completed_orders FROM Siparisler WHERE durum = 'Ödeme Tamamlandı'";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        completedOrders = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving completed order count: " + ex.Message);
            }
        }

        return completedOrders;
    }

    public string GetLeastOrderedProduct()
    {
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            string query = "SELECT siparis_aciklamasi FROM Siparisler";
            Dictionary<string, int> productCounts = new Dictionary<string, int>();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string orderDescription = reader["siparis_aciklamasi"].ToString();
                    if (!string.IsNullOrEmpty(orderDescription))
                    {
                        string[] products = orderDescription.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string product in products)
                        {
                            if (product.Contains("-"))
                            {
                                string productName = product.Split('-')[0].Trim();
                                if (!string.IsNullOrEmpty(productName))
                                {
                                    if (productCounts.ContainsKey(productName))
                                        productCounts[productName]++;
                                    else
                                        productCounts[productName] = 1;
                                }
                            }
                        }
                    }
                }
            }

            if (productCounts.Any())
            {
                var leastOrdered = productCounts.OrderBy(x => x.Value).First();
                return leastOrdered.Key;
            }

            return "No Data";
        }
    }

    public string GetMostSaleDayOfWeek()
    {
        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT DAYNAME(siparis_tarihi) as day_name, SUM(toplam_tutar) as total_revenue " +
                              "FROM Siparisler " +
                              "GROUP BY DAYNAME(siparis_tarihi) " +
                              "ORDER BY total_revenue DESC LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dayName = reader.GetString("day_name");
                        // MySQL DAYNAME genelde İngilizce döner (örneğin "Sunday"), Türkçeye çevirelim
                        Dictionary<string, string> dayNameMap = new Dictionary<string, string>
                    {
                        { "Monday", "Pazartesi" },
                        { "Tuesday", "Salı" },
                        { "Wednesday", "Çarşamba" },
                        { "Thursday", "Perşembe" },
                        { "Friday", "Cuma" },
                        { "Saturday", "Cumartesi" },
                        { "Sunday", "Pazar" }
                    };
                        return dayNameMap.ContainsKey(dayName) ? dayNameMap[dayName] : dayName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving most sale day of week: " + ex.Message);
            }
        }

        return "No Data";
    }

    public Dictionary<string, int> GetTopFiveProducts()
    {
        Dictionary<string, int> productCounts = new Dictionary<string, int>();

        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT siparis_aciklamasi FROM Siparisler";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string orderDescription = reader["siparis_aciklamasi"].ToString();
                        if (!string.IsNullOrEmpty(orderDescription))
                        {
                            string[] products = orderDescription.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string product in products)
                            {
                                if (product.Contains("-"))
                                {
                                    string productName = product.Split('-')[0].Trim();
                                    if (!string.IsNullOrEmpty(productName))
                                    {
                                        if (productCounts.ContainsKey(productName))
                                            productCounts[productName]++;
                                        else
                                            productCounts[productName] = 1;
                                    }
                                }
                            }
                        }
                    }
                }

                // En çok satan ilk 5 ürünü al
                return productCounts.OrderByDescending(x => x.Value).Take(5).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving top five products: " + ex.Message);
                return new Dictionary<string, int>();
            }
        }
    }
}
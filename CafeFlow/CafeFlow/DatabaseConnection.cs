﻿using System;
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

                return productCounts.OrderByDescending(x => x.Value).Take(7).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving top five products: " + ex.Message);
                return new Dictionary<string, int>();
            }
        }
    }

    public Dictionary<string, decimal> GetSalesByDayOfWeek()
    {
        Dictionary<string, decimal> salesByDay = new Dictionary<string, decimal>();

        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT DAYNAME(siparis_tarihi) as day_name, SUM(toplam_tutar) as total_revenue " +
                              "FROM Siparisler " +
                              "GROUP BY DAYNAME(siparis_tarihi)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dayName = reader.GetString("day_name");
                        decimal totalRevenue = reader.GetDecimal("total_revenue");

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
                        string translatedDayName = dayNameMap.ContainsKey(dayName) ? dayNameMap[dayName] : dayName;
                        salesByDay[translatedDayName] = totalRevenue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving sales by day of week: " + ex.Message);
            }
        }

        return salesByDay;
    }

    public Dictionary<DateTime, decimal> GetLast7DaysProfits()
    {
        Dictionary<DateTime, decimal> profits = new Dictionary<DateTime, decimal>();

        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT DATE(siparis_tarihi) as sale_date, SUM(toplam_tutar) as total_revenue " +
                              "FROM Siparisler " +
                              "WHERE siparis_tarihi >= DATE_SUB(NOW(), INTERVAL 7 DAY) " +
                              "GROUP BY DATE(siparis_tarihi)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime saleDate = reader.GetDateTime("sale_date");
                        decimal totalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue");
                        profits[saleDate] = totalRevenue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving last 7 days profits: " + ex.Message);
            }
        }

        return profits;
    }

    public Dictionary<string, int> GetLowStockProducts()
    {
        Dictionary<string, int> lowStockProducts = new Dictionary<string, int>();

        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT UrunAdi, Miktar FROM Stok WHERE Miktar > 0 ORDER BY Miktar ASC LIMIT 7";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString("UrunAdi");
                        int quantity = reader.GetInt32("Miktar");
                        lowStockProducts[productName] = quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving low stock products: " + ex.Message);
            }
        }

        return lowStockProducts;
    }

    public Dictionary<DateTime, decimal> GetMonthlyProfits(DateTime startDate, DateTime endDate)
    {
        Dictionary<DateTime, decimal> monthlyProfits = new Dictionary<DateTime, decimal>();
        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT DATE_FORMAT(siparis_tarihi, '%Y-%m-01') as month, SUM(toplam_tutar) as total_revenue " +
                              "FROM Siparisler " +
                              "WHERE siparis_tarihi BETWEEN @startDate AND @endDate " +
                              "GROUP BY DATE_FORMAT(siparis_tarihi, '%Y-%m-01')";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate.AddDays(1).AddSeconds(-1));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime month = DateTime.Parse(reader.GetString("month"));
                            decimal totalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue");
                            monthlyProfits[month] = totalRevenue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving monthly profits: " + ex.Message);
            }
        }
        return monthlyProfits;
    }

    public Dictionary<int, decimal> GetSalesPerHour(DateTime startDate, DateTime endDate)
    {
        Dictionary<int, decimal> hourlySales = new Dictionary<int, decimal>();
        for (int hour = 0; hour < 24; hour++) hourlySales[hour] = 0; // 0-23 saatleri için başlangıç değeri 0

        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT HOUR(siparis_tarihi) as hour, SUM(toplam_tutar) as total_revenue " +
                              "FROM Siparisler " +
                              "WHERE siparis_tarihi BETWEEN @startDate AND @endDate " +
                              "GROUP BY HOUR(siparis_tarihi)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate.AddDays(1).AddSeconds(-1));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int hour = reader.GetInt32("hour");
                            decimal totalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue");
                            hourlySales[hour] = totalRevenue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving hourly sales: " + ex.Message);
            }
        }
        return hourlySales;
    }

    public Dictionary<string, Tuple<int, decimal>> GetSalesByCategory(DateTime startDate, DateTime endDate)
    {
        Dictionary<string, Tuple<int, decimal>> categoryStats = new Dictionary<string, Tuple<int, decimal>>();
        using (MySqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT m.kategori, COUNT(s.id) as order_count, SUM(s.toplam_tutar) as total_revenue " +
                              "FROM Siparisler s " +
                              "JOIN Menu m ON s.siparis_aciklamasi LIKE CONCAT('%', m.urun_ismi, '%') " +
                              "WHERE s.siparis_tarihi BETWEEN @startDate AND @endDate " +
                              "GROUP BY m.kategori";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate.AddDays(1).AddSeconds(-1));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader.IsDBNull(reader.GetOrdinal("kategori")) ? "Bilinmeyen" : reader.GetString("kategori");
                            int orderCount = reader.GetInt32("order_count");
                            decimal totalRevenue = reader.IsDBNull(reader.GetOrdinal("total_revenue")) ? 0 : reader.GetDecimal("total_revenue");
                            categoryStats[category] = new Tuple<int, decimal>(orderCount, totalRevenue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving sales by category: " + ex.Message);
            }
        }
        return categoryStats;
    }

    public bool Log(string logEkrani, string logMesaji, DateTime logTarihi, string kullanci)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO Log (LogTarihi, LogEkrani, LogMesaji, Kullanici) VALUES (@logTarihi, @logEkrani, @logMesaji, @kullanici)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@logTarihi", logTarihi);
                    command.Parameters.AddWithValue("@logEkrani", logEkrani);
                    command.Parameters.AddWithValue("@logMesaji", logMesaji);
                    command.Parameters.AddWithValue("@kullanici", kullanci);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log hatası: " + ex.Message);
                return false;
            }
        }
    }
}
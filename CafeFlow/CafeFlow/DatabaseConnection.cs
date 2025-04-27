using System;
using System.Data.Common;
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
}


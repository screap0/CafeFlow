using MySql.Data.MySqlClient;

namespace CafeFlowApi
{
    public class DatabaseConnection
    {
        private string ConnectionString { get; set; }

        public DatabaseConnection()
        {
            ConnectionString = "Server=www.cafeflow.com.tr;Database=caf28dowcomtr_CafeDB;Uid=caf28dowcomtr_cafedb;Pwd=Deneme21*.;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
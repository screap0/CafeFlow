﻿using MySql.Data.MySqlClient;

namespace CafeFlowApi
{
    public class DatabaseConnection
    {
        private string ConnectionString { get; set; }

        public DatabaseConnection()
        {
            ConnectionString = "Server=www.cafeflow.com.tr;Database=caf2bbowcomtr_CafeDB;Uid=caf2bbowcomtr_cafedb;Pwd=Deneme21*.;utf8mb4_turkish_ci";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
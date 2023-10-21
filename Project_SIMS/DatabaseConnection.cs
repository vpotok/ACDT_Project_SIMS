using System;
using Microsoft.Data.SqlClient;
namespace Project_SIMS;
    public class DatabaseConnection
    {
        static string serverIP = "127.0.0.1";
        static int serverPort = 1433;
        static string saPassword = "TestTest12";
        static string connectionString = $"Server={serverIP},{serverPort};Database=Incidentmanagement;User Id=sa;Password={saPassword};TrustServerCertificate=true;";
        public SqlConnection con = new SqlConnection(connectionString);

        public void openConnection()
        {
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }

    }

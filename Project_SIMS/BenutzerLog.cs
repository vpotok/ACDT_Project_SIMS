using System;
using Microsoft.Data.SqlClient;
namespace Project_SIMS;

public class BenutzerLog
    {
        public void selectBenutzerLogView()
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM benutzer_log_view", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            dc.closeConnection();

        }
    }
using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Project_SIMS;

public class Vorfall
	{
        public void selectUnsolvedIncidents()
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM vorfall WHERE VorfallStatus = 0", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            escalation();
            dc.closeConnection();
        }


        public void updateVorfallstatus(string status)
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            SqlCommand command = new SqlCommand(null, dc.con);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE vorfall SET VorfallStatus = 1 WHERE VorfallId = @id";

            SqlParameter statusParam = new SqlParameter("@id", SqlDbType.VarChar, 255);


            statusParam.Value = status;

            command.Parameters.Add(statusParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
            dc.closeConnection();
        }

        public void escalation()
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM vorfall WHERE VorfallStatus = 0", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(reader["SchwereGrad"])== 1)
                {
                    Console.WriteLine("Admin Max hat die Nachricht bekommen!");

                }
                else if (Convert.ToInt32(reader["SchwereGrad"]) == 2)
                {
                    Console.WriteLine("Admin Ibo hat die Nachricht bekommen!");

                }
                else if (Convert.ToInt32(reader["SchwereGrad"]) == 3)
                {
                    Console.WriteLine("Admin Fabi hat keine Ahnung!");

                }

            }
            dc.closeConnection();
        }
    }
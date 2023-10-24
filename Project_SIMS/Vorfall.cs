using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Project_SIMS;
using Spectre.Console;

public class Vorfall
{
    public void selectUnsolvedIncidents()
    {
        DatabaseConnection dc = new DatabaseConnection();
        try
        {
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM vorfall WHERE VorfallStatus = 0", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();
            Table table = new Table();
            table.Title("[white]Vorfall Tabelle[/]");
            table.AddColumn("VorfallID");
            table.AddColumn("SchwereGrad");
            table.AddColumn("VorfallStatus");
            table.AddColumn("Zeitstempel");
            table.AddColumn("Beschreibung");
            while (reader.Read())
            {
                table.AddRow(
                    Convert.ToString(reader["VorfallID"]),
                    Convert.ToString(reader["SchwereGrad"]),
                    Convert.ToString(reader["VorfallStatus"]),
                    Convert.ToString(reader["Zeitstempel"]),
                    Convert.ToString(reader["Beschreibung"])
                );
            }
            AnsiConsole.Render(table);
            escalation();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during incident selection: {ex.Message}");
            // Handle the exception, e.g., log it or show an error message.
        }
        finally
        {
            dc.closeConnection();
        }
    }

    public void updateVorfallstatus(int vorfallId)
    {
        DatabaseConnection dc = new DatabaseConnection();
        try
        {
            dc.openConnection();
            SqlCommand command = new SqlCommand(null, dc.con);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE vorfall SET VorfallStatus = 1 WHERE VorfallId = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = vorfallId;

            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during incident status update: {ex.Message}");
            // Handle the exception, e.g., log it or show an error message.
        }
        finally
        {
            dc.closeConnection();
        }
    }

    public void escalation()
    {
        DatabaseConnection dc = new DatabaseConnection();
        try
        {
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM vorfall WHERE VorfallStatus = 0", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(reader["SchwereGrad"]) == 1)
                {
                    Console.WriteLine("Vorfall mit der ID: " + reader["VorfallID"] + " ... wird von Admin Max bearbeitet!");
                }
                else if (Convert.ToInt32(reader["SchwereGrad"]) == 2)
                {
                    Console.WriteLine("Vorfall mit der ID: " + reader["VorfallID"] + " ... wird von Admin Ibo bearbeitet!");
                }
                else if (Convert.ToInt32(reader["SchwereGrad"]) == 3)
                {
                    Console.WriteLine("Vorfall mit der ID: " + reader["VorfallID"] + " ... wird von Praktikant Fabi bearbeitet!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during escalation: {ex.Message}");
            // Handle the exception, e.g., log it or show an error message.
        }
        finally
        {
            dc.closeConnection();
        }
    }
}

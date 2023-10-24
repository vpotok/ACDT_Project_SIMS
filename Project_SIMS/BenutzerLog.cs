using System;
using Microsoft.Data.SqlClient;
using Project_SIMS;
using Spectre.Console;

public class BenutzerLog
{
    public void selectBenutzerLogView()
    {
        DatabaseConnection dc = new DatabaseConnection();
        try
        {
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM benutzer_log_view", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();
            Table table = new Table();
            table.Title("[white]Benutzer Log-Tabelle[/]");
            table.AddColumn("BenutzerLogId");
            table.AddColumn("ZeitStempel");
            table.AddColumn("Nachricht");
            table.AddColumn("BenutzerId");
            while (reader.Read())
            {
                table.AddRow(
                    Convert.ToString(reader["BenutzerLogId"]),
                    Convert.ToString(reader["ZeitStempel"]),
                    Convert.ToString(reader["Nachricht"]),
                    Convert.ToString(reader["BenutzerId"])
                );
            }
            AnsiConsole.Render(table);
        
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during BenutzerLogView selection: {ex.Message}");
            // Handle the exception, e.g., log it or show an error message.
        }
        finally
        {
            dc.closeConnection();
        }
    }
}
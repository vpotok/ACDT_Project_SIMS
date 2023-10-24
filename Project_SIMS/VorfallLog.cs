using System;
using Microsoft.Data.SqlClient;
using Project_SIMS;
using Spectre.Console;

public class VorfallLog
{
    public void selectVorfallLogView()
    {
        DatabaseConnection dc = new DatabaseConnection();
        try
        {
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM vorfall_log_view", dc.con);
            using SqlDataReader reader = cmd.ExecuteReader();
            Table table = new Table();
            table.Title("[white]Vorfall Log-Tabelle[/]");
            table.AddColumn("VorfallLogId");
            table.AddColumn("ZeitStempel");
            table.AddColumn("Nachricht");
            table.AddColumn("VorfallId");
            while (reader.Read())
            {
                table.AddRow(
                    Convert.ToString(reader["VorfallLogId"]),
                    Convert.ToString(reader["ZeitStempel"]),
                    Convert.ToString(reader["Nachricht"]),
                    Convert.ToString(reader["VorfallId"])
                );
            }
            AnsiConsole.Render(table);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during VorfallLogView selection: {ex.Message}");
            // Handle the exception, e.g., log it or show an error message.
        }
        finally
        {
            dc.closeConnection();
        }
    }
}
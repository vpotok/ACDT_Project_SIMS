using System;
using System.Data;
using System.Windows.Input;
using Microsoft.Data.SqlClient;
using Spectre.Console;
namespace Project_SIMS
{
    public class Benutzerverwaltung
    {
        public void insertUser(string vorname, string nachname, bool isAdmin, bool isActive)
        {
            DatabaseConnection dc = new DatabaseConnection();
            try
            {
                dc.openConnection();
                SqlCommand command = new SqlCommand(null, dc.con);

                // Create and prepare an SQL statement.
                command.CommandText =
                    "INSERT INTO benutzer (Vorname, Nachname, isAdmin, isActive) " +
                    "VALUES (@Vorname, @Nachname, @isAdmin, @isActive)";
                SqlParameter vornameParam = new SqlParameter("@Vorname", SqlDbType.VarChar, 255);
                SqlParameter nachnameParam = new SqlParameter("@Nachname", SqlDbType.VarChar, 255);
                SqlParameter isAdminParam = new SqlParameter("@isAdmin", SqlDbType.Bit, 2);
                SqlParameter isActiveParam = new SqlParameter("@isActive", SqlDbType.Bit, 2);

                vornameParam.Value = vorname;
                nachnameParam.Value = nachname;
                isAdminParam.Value = isAdmin;
                isActiveParam.Value = isActive;

                command.Parameters.Add(vornameParam);
                command.Parameters.Add(nachnameParam);
                command.Parameters.Add(isAdminParam);
                command.Parameters.Add(isActiveParam);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user insertion: {ex.Message}");
            }
            finally
            {
                dc.closeConnection();
            }
        }

        public void selectUser(int id)
        {
            DatabaseConnection dc = new DatabaseConnection();
            try
            {
                dc.openConnection();
                SqlCommand command = new SqlCommand(null, dc.con);

                command.CommandText = "SELECT * FROM benutzer WHERE BenutzerId = @BenutzerId";

                SqlParameter idParam = new SqlParameter("@BenutzerId", SqlDbType.Int);
                idParam.Value = id;
                command.Parameters.Add(idParam);

                command.Prepare();
                using SqlDataReader reader = command.ExecuteReader();

                Table table = new Table();
                table.Title("[white]Benutzer Tabelle[/]");
                table.AddColumn("ID");
                table.AddColumn("Vorname");
                table.AddColumn("Nachname");
                table.AddColumn("isAdmin");
                table.AddColumn("isActive");

                while (reader.Read())
                {
                    table.AddRow(
                        Convert.ToString(reader["BenutzerId"]),
                        Convert.ToString(reader["Vorname"]),
                        Convert.ToString(reader["Nachname"]),
                        Convert.ToString(reader["isAdmin"]),
                        Convert.ToString(reader["isActive"])
                    );
                }
                AnsiConsole.Render(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user selection: {ex.Message}");
            }
            finally
            {
                dc.closeConnection();
            }
        }


        public void selectAllUser()
        {
            DatabaseConnection dc = new DatabaseConnection();
            try
            {
                dc.openConnection();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM benutzer", dc.con);
                using SqlDataReader reader = cmd.ExecuteReader();
                Table table = new Table();
                table.Title("[white]Benutzer Tabelle[/]");
                table.AddColumn("ID");
                table.AddColumn("Vorname");
                table.AddColumn("Nachname");
                table.AddColumn("isAdmin");
                table.AddColumn("isActive");
                while (reader.Read())
                {
                    table.AddRow(
                        Convert.ToString(reader["BenutzerId"]),
                        Convert.ToString(reader["Vorname"]),
                        Convert.ToString(reader["Nachname"]),
                        Convert.ToString(reader["isAdmin"]),
                        Convert.ToString(reader["isActive"])
                    );
                }
                AnsiConsole.Render(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user selection: {ex.Message}");
            }
            finally
            {
                dc.closeConnection();
            }
        }

        public void updateUser(int id, string columnName, object newValue)
        {
            List<string> allowedColumns = new List<string> { "Vorname", "Nachname", "isAdmin", "isActive" };

            if (allowedColumns.Contains(columnName))
            {
                DatabaseConnection dc = new DatabaseConnection();
                try
                {
                    dc.openConnection();
                    SqlCommand command = new SqlCommand(null, dc.con);

                    command.CommandText = $"UPDATE benutzer SET {columnName} = @newValue WHERE BenutzerId = @BenutzerId";

                    command.Parameters.AddWithValue("@BenutzerId", id);

                    if (newValue.GetType() == typeof(bool))
                    {
                        command.Parameters.AddWithValue("@newValue", Convert.ToBoolean(newValue));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@newValue", Convert.ToString(newValue));
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during user update: {ex.Message}");
                }
                finally
                {
                    dc.closeConnection();
                }
            }
        }

        public void deleteUser(int id)
        {
            DatabaseConnection dc = new DatabaseConnection();
            try
            {
                dc.openConnection();
                SqlCommand command = new SqlCommand(null, dc.con);

                command.CommandText = $"UPDATE benutzer SET isActive = 0 WHERE BenutzerId = @BenutzerId";

                SqlParameter idParam = new SqlParameter("@BenutzerId", SqlDbType.Int);

                idParam.Value = id;

                command.Parameters.Add(idParam);

                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user deletion: {ex.Message}");
            }
            finally
            {
                dc.closeConnection();
            }
        }
    }
}

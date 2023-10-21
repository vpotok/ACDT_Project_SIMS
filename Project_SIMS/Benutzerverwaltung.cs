using System;
using System.Data;
using System.Windows.Input;
using Microsoft.Data.SqlClient;
namespace Project_SIMS;
public class Benutzerverwaltung
    {
        public void insertUser(string vorname, string nachname, bool isAdmin, bool isActive)
        {
            DatabaseConnection dc = new DatabaseConnection();
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
            dc.closeConnection();

        }

        public void selectUser(int id)
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            SqlCommand command = new SqlCommand(null, dc.con);

            // Create and prepare an SQL statement.
            command.CommandText =
                "SELECT * FROM benutzer WHERE BenutzerId = @BenutzerId";

            SqlParameter idParam = new SqlParameter("@BenutzerId", SqlDbType.Int);

            idParam.Value = id;
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            using SqlDataReader reader = command.ExecuteReader();

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

        public void selectAllUser()
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.openConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM benutzer", dc.con);
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

        public void updateUser(int id, string columnName, string newValue)
        {
            List<string> allowedColumns = new List<string> { "Vorname", "Nachname", "isAdmin", "isActive" };

            if (allowedColumns.Contains(columnName))
            {
                DatabaseConnection dc = new DatabaseConnection();
                dc.openConnection();
                SqlCommand command = new SqlCommand(null, dc.con);

                // Erstelle und bereite die SQL-Anweisung vor.
                command.CommandText = $"UPDATE benutzer SET {columnName} = @newValue WHERE BenutzerId = @BenutzerId";

                SqlParameter idParam = new SqlParameter("@BenutzerId", SqlDbType.Int);
                SqlParameter newValueParam = new SqlParameter("@newValue", SqlDbType.VarChar, 255);

                idParam.Value = id;
                newValueParam.Value = newValue;

                command.Parameters.Add(idParam);
                command.Parameters.Add(newValueParam);

                // Rufe Prepare auf, nachdem du Commandtext und Parameter festgelegt hast.
                command.Prepare();
                command.ExecuteNonQuery();
                dc.closeConnection();
            }
            else
            {
                // Spaltenname ist nicht erlaubt.
                // Hier kannst du Fehlerbehandlung oder Logging hinzufügen.
            }
        }


        //    public void updateUser2(int id, string eingabe)
        //    {
        //        DatabaseConnection dc = new DatabaseConnection();
        //        dc.openConnection();
        //        SqlCommand command = new SqlCommand(null, dc.con);

        //        // Create and prepare an SQL statement.
        //        command.CommandText =
        //            "UPDATE benutzer SET Vorname = @eingabe WHERE BenutzerId = @BenutzerId";

        //        SqlParameter idParam = new SqlParameter("@BenutzerId", SqlDbType.Int);
        //        SqlParameter eingabeParam = new SqlParameter("@eingabe", SqlDbType.VarChar, 255);

        //        idParam.Value = id;
        //        eingabeParam.Value = eingabe;

        //        command.Parameters.Add(id);
        //        command.Parameters.Add(eingabeParam);

        //        // Call Prepare after setting the Commandtext and Parameters.
        //        command.Prepare();
        //        command.ExecuteNonQuery();
        //        dc.closeConnection();
        //    }



        //}
    }
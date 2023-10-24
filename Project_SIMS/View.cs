using Spectre.Console;
using System;

namespace Project_SIMS
{
    public class View
    {
        public static void Main()
        {
            try
            {
                View v = new View();
                v.Auswahl();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        public void Auswahl()
        {
            try
            {
                TableFkt();
                while (true)
                {
                    int auswahl = AnsiConsole.Ask<int>("Wähle eine Tabelle [green](Nr.)[/]?");
                    if (auswahl == 1)
                    {
                        Benutzerverwaltung benutzerverwaltung = new Benutzerverwaltung();
                        TableBenutzerFkt(benutzerverwaltung);
                    }
                    else if (auswahl == 2)
                    {
                        TableVorfälle();
                    }
                    else if (auswahl == 3)
                    {
                        TableLog();
                    }
                    else if (auswahl == 0)
                    {
                        TableFkt();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private void TableFkt()
        {
            try
            {
                // Create a table
                var table = new Table();
                table.Title(new TableTitle("[Yellow]SIMS[/]"));
                // Add some columns
                table.AddColumn(new TableColumn("Nr.").Centered());
                table.AddColumn(new TableColumn("[Green]Funktion[/]").Centered());

                // Add some rows
                table.AddRow("[White]1[/]", "[Cyan]Benutzer[/]");
                table.AddRow("[White]2[/]", "[Blue]Vorfälle[/]");
                table.AddRow("[White]3[/]", "[Magenta]Log[/]");
                // Render the table to the console
                AnsiConsole.Write(table);
                AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private void TableBenutzer()
        {
            try
            {
                var table = new Table();
                table.Title(new TableTitle("[Yellow]Benutzer[/]"));
                // Add some columns
                table.AddColumn(new TableColumn("Nr.").Centered());
                table.AddColumn(new TableColumn("[Green]Funktion[/]").Centered());

                // Add some rows
                table.AddRow("[White]1[/]", "[Cyan]Show all[/]");
                table.AddRow("[White]2[/]", "[White]Benutzer auswählen[/]");
                table.AddRow("[White]3[/]", "[Blue]Benutzer hinzufügen[/]");
                table.AddRow("[White]4[/]", "[Magenta]Benutzer anpassen[/]");
                table.AddRow("[White]5[/]", "[Red]Benutzer löschen[/]");
                // Render the table to the console
                AnsiConsole.Write(table);
                AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private void TableBenutzerFkt(Benutzerverwaltung benutzerverwaltung)
        {
            try
            {
                TableBenutzer();
                int auswahl;
                int user;
                while (true)
                {
                    auswahl = AnsiConsole.Ask<int>("Wähle eine Funktion [green](Nr.)[/]?");

                    if (auswahl == 1)
                    {
                        benutzerverwaltung.selectAllUser();
                    }
                    else if (auswahl == 2)
                    {
                        Panel ex = new Panel("[red]0 Exit[/]");
                        AnsiConsole.Write(ex);
                        user = AnsiConsole.Ask<int>("Welchen Benutzer möchtest du auswählen [green](int)[/]?");
                        benutzerverwaltung.selectUser(user);
                    }
                    else if (auswahl == 3)
                    {
                        bool eing = BenutzerHinzu(benutzerverwaltung);
                        if (eing == false)
                        {
                            auswahl = 0;
                        }
                    }
                    else if (auswahl == 4)
                    {
                        Panel ex = new Panel("[red]0 Exit[/]");
                        AnsiConsole.Write(ex);
                        user = AnsiConsole.Ask<int>("Welchen Benutzer möchtest du bearbeiten?");
                        if (user == 0)
                        {
                            auswahl = 0;
                        }
                        else
                        {
                            BenutzerUpdate(user, benutzerverwaltung);
                        }
                    }
                    else if (auswahl == 5)
                    {
                        Panel ex = new Panel("[red]0 Exit[/]");
                        AnsiConsole.Write(ex);
                        user = AnsiConsole.Ask<int>("Welchen Benutzer möchtest du löschen [green](int)[/]?");
                        benutzerverwaltung.deleteUser(user);
                    }
                    else if (auswahl == 0)
                    {
                        TableFkt();
                        break;
                    }
                    TableBenutzer();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private bool BenutzerHinzu(Benutzerverwaltung benutzerverwaltung)
        {
            try
            {
                Panel hinzu = new Panel("[bold green]vorname(string);nachname(string);isAdmin(false oder true);isActive(false oder true)[/]");
                hinzu.Header("[red]Benutzer hinzufügen[/]");
                AnsiConsole.Write(hinzu);
                Panel ex = new Panel("[red]0 Exit[/]");
                AnsiConsole.Write(ex);
                
                string newUser = AnsiConsole.Ask<string>("[red]Achtung Syntax![/]Gib dem neuen Benutzer ein:");
                if (newUser == "0")
                {
                    return false;
                }
                Console.WriteLine(newUser);
                try
                {
                    // User hinzufügen
                    string[] input = newUser.Split(";");
                    benutzerverwaltung.insertUser(input[0], input[1], Convert.ToBoolean(input[2]), Convert.ToBoolean(input[3]));
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    throw;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return false;
            }
        }

        private void BenutzerUpdate(int userID, Benutzerverwaltung benutzerverwaltung)
        {
            try
            {
                // Create a table
                var table = new Table();
                table.Title(new TableTitle("[Gray]Benutzer anpassen[/]"));
                // Add some columns
                table.AddColumn(new TableColumn("Nr.").Centered());
                table.AddColumn(new TableColumn("[Yellow]Eigenschaft[/]").Centered());

                // Add some rows
                table.AddRow("[White]1[/]", "[Green]Vorname[/]");
                table.AddRow("[White]2[/]", "[Cyan]Nachname[/]");
                table.AddRow("[White]3[/]", "[Blue]isAdmin[/]");
                table.AddRow("[White]4[/]", "[Magenta]isActive[/]");
                // Render the table to the console
                AnsiConsole.Write(table);
                AnsiConsole.Write(new Panel("[red]0 Exit[/]"));

                while (true)
                {
                    int auswahl = AnsiConsole.Ask<int>("Wähle eine Eigenschaft [green](Nr.)[/]?");
                    if (auswahl == 1)
                    {
                        Panel vn = new Panel("[green]Bitte den neuen Vornamen eingeben[/]");
                        vn.Header("[red]Vorname[/]");
                        AnsiConsole.Write(vn);
                        string eing = AnsiConsole.Ask<string>("Eingabe:");
                        AnsiConsole.Write(new Text(eing));
                        Benutzerverwaltung bw = new Benutzerverwaltung();
                        bw.updateUser(userID, "Vorname", eing);
                        break;
                    }
                    else if (auswahl == 2)
                    {
                        Panel vn = new Panel("[green]Bitte den neuen Nachnamen eingeben[/]");
                        vn.Header("[red]Nachname[/]");
                        AnsiConsole.Write(vn);
                        string eing = AnsiConsole.Ask<string>("[green]Eingabe:[/]");
                        AnsiConsole.Write(new Text(eing));
                        Benutzerverwaltung bw = new Benutzerverwaltung();
                        bw.updateUser(userID, "Nachname", eing);
                        break;
                    }
                    else if (auswahl == 3)
                    {
                        Panel vn = new Panel("[green]isAdmin: 1 = true; 0 = false[/]");
                        vn.Header("[red]isAdmin[/]");
                        AnsiConsole.Write(vn);
                        bool eing = AnsiConsole.Ask<bool>("Eingabe:");
                        AnsiConsole.Write(new Text(eing.ToString()));
                        Benutzerverwaltung bw = new Benutzerverwaltung();
                        bw.updateUser(userID, "isAdmin", eing);
                        break;
                    }
                    else if (auswahl == 4)
                    {
                        Panel vn = new Panel("[green]isActive: 1 = true; 0 = false[/]");
                        vn.Header("[red]isActive[/]");
                        AnsiConsole.Write(vn);
                        bool eing = AnsiConsole.Ask<bool>("Eingabe:");
                        AnsiConsole.Write(new Text(eing.ToString()));
                        Benutzerverwaltung bw = new Benutzerverwaltung();
                        bw.updateUser(userID, "isActive", eing);
                        break;
                    }
                    else if (auswahl == 0)
                    {
                        Console.WriteLine("Close");
                        TableBenutzer();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private void TableVorfälle()
        {
            try
            {
                // Create a table
                VorfallTabelle();
                while (true)
                {
                    int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Funktion [green](Nr.)[/]?"));
                    if (auswahl == 1)
                    {
                        Vorfall vf = new Vorfall();
                        vf.selectUnsolvedIncidents();
                    }
                    else if (auswahl == 2)
                    {
                        Vorfall vf = new Vorfall();
                        Panel ex = new Panel("[red]0 Exit[/]");
                        AnsiConsole.Write(ex);
                        int eingabe = AnsiConsole.Ask<int>("Welchen Vorfall möchten Sie bearbeiten? (ID) [green](int)[/]?");
                        if (eingabe == 0)
                        {
                            auswahl = 0;
                        }
                        else
                        {
                            vf.updateVorfallstatus(eingabe);   
                        }
                    }
                    else if (auswahl == 0)
                    {
                        TableFkt();
                        break;
                    }
                    VorfallTabelle();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            
        }

        private void VorfallTabelle()
        {
            var table = new Table();
            table.Title(new TableTitle("[Cyan]Vorfälle[/]"));
            // Add some columns
            table.AddColumn(new TableColumn("Nr.").Centered());
            table.AddColumn(new TableColumn("Funktion").Centered());

            // Add some rows
            table.AddRow("[White]1[/]", "[Blue]Show all[/]");
            table.AddRow("[White]2[/]", "[Magenta]Vorfall schließen[/]");

            // Render the table to the console
            AnsiConsole.Write(table);
            AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        }
        private void TableLog()
        {
            try
            {
                LogTabelle();
                while (true)
                {
                    int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Funktion [green](Nr.)[/]?"));
                    if (auswahl == 1)
                    {
                        VorfallLog vl = new VorfallLog();
                        vl.selectVorfallLogView();
                    }
                    else if (auswahl == 2)
                    {
                        BenutzerLog bl = new BenutzerLog();
                        bl.selectBenutzerLogView();
                    }
                    else if (auswahl == 0)
                    {
                        TableFkt();
                        break;
                    }
                    LogTabelle();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private void LogTabelle()
        {
            // Create a table
            var table = new Table();
            table.Title(new TableTitle("[Yellow]Log[/]"));
            // Add some columns
            table.AddColumn(new TableColumn("Nr.").Centered());
            table.AddColumn(new TableColumn("[Green]Log anzeigen von:[/]").Centered());
            // Add some rows
            table.AddRow("[White]1[/]", "[Blue]Vorfälle[/]");
            table.AddRow("[White]2[/]", "[Cyan]Benutzer[/]");
            // Render the table to the console
            AnsiConsole.Write(table);
            AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        }
        

        //private bool SelectTable(string type)
        //{
        //    try
        //    {
        //        Panel panel = new Panel("[red]Table[/]");
        //        switch (type)
        //        {
        //            case "benutzer":
        //                panel.Header("[green]Benutzer[/]");
        //                break;
        //            case "vorfälle":
        //                panel.Header("[green]Vorfälle[/]");
        //                break;
        //            case "log":
        //                panel.Header("[green]Log[/]");
        //                break;
        //            default:
        //                break;
        //        }
        //        AnsiConsole.Write(panel);
        //        AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        //        while (true)
        //        {
        //            int eing = AnsiConsole.Ask<int>("Eingabe:");
        //            if (eing == 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("An error occurred: " + e.Message);
        //        return false;
        //    }
        //}
    }
}

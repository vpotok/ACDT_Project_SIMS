using System.Collections;
using System.Security.Cryptography;

namespace Project_SIMS;
using Spectre.Console;


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
            Console.WriteLine(e);
            throw;
        }
    }

    public void Auswahl()
    {
        Panel wlcm = new Panel("[red]Hello Admin ![/]");
        TableFkt();
        while (true)
        {
            int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Tabel [green](Nr.)[/]?"));
            if (auswahl == 1)
            {
                TableBenutzerFkt();
            }else if (auswahl == 2)
            {
                TableVorfälle();
            }else if (auswahl == 3)
            {
                TableLog();
            }else if (auswahl == 0)
            {
                Console.WriteLine("Close");
                break;
            }
        }
    }

    private void TableFkt()
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

    private void TableBenutzer()
    {
        var table = new Table();
        table.Title(new TableTitle("[Yellow]Benutzer[/]"));
        // Add some columns
        table.AddColumn(new TableColumn("Nr.").Centered());
        table.AddColumn(new TableColumn("[Green]Funktion[/]").Centered());

        // Add some rows
        table.AddRow("[White]1[/]", "[Cyan]Show all[/]");
        table.AddRow("[White]2[/]", "[Blue]Benutzer hinzufügen[/]");
        table.AddRow("[White]3[/]", "[Magenta]Benutzer anpassen[/]");
        // Render the table to the console
        AnsiConsole.Write(table);
        AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
    }
    private void TableBenutzerFkt()
    {
        TableBenutzer();
        int auswahl;
        while (true)
        {
            auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Funktion [green](Nr.)[/]?"));
            
            if (auswahl == 1)
            {
                bool selectTable = SelectTable("benutzer");
                if (selectTable)
                {
                    auswahl = 0;
                }

            }else if (auswahl == 2)
            {
                bool hinuz = BenutzerHinzu();
                if (hinuz)
                {
                    auswahl = 0;
                }

            }else if (auswahl == 3)
            {
                string user = AnsiConsole.Ask<string>("Welchen Benutzer möchtest zu bearbeiten?");
                EigenschaftTable(user);
            }else if (auswahl == 0)
            {
                Console.WriteLine("Close");
                TableFkt();
                break;
            }
            TableBenutzer();
        }
    }

    private bool BenutzerHinzu()
    {
        Panel hinzutitel = new Panel("[bold green]Benutzer hinzufügen[/]");
        AnsiConsole.Write(hinzutitel);
  
        Panel ex = new Panel("[red]0 Exit[/]");
        AnsiConsole.Write(ex);
        string newUser = AnsiConsole.Ask<string>("[red]Achtung Syntax![/]Geben die dem neuen Benutzer ein:");
        Console.WriteLine(newUser);
        
        try
        {
            // User hinzufügen
            // string[] arr = newUser.Split(";");
            // method(arr[0],arr[1],int(arr[2], int(arr[3]))
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
    private void EigenschaftTable(string user)
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
            int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Eigenschaft [green](Nr.)[/]?"));
            if (auswahl == 1)
            {
                Panel vn = new Panel("[green]Bitten den neuen Vorname eingeben[/]");
                vn.Header("[red]Vorname[/]");
                AnsiConsole.Write(vn);
                string eing = AnsiConsole.Ask<string>("Eingabe:");
                AnsiConsole.Write(new Text(eing));
                break;
            }else if (auswahl == 2)
            {
                Panel vn = new Panel("[green]Bitten den neuen Nachnamen eingeben[/]");
                vn.Header("[red]Nachname[/]");
                AnsiConsole.Write(vn);
                string eing = AnsiConsole.Ask<string>("[green]Eingabe:[/]");
                AnsiConsole.Write(new Text(eing));
                break;
            }else if (auswahl == 3)
            {
                Panel vn = new Panel("[green]isAdmin: 1 = true; 0 = false[/]");
                vn.Header("[red]isAdmin[/]");
                AnsiConsole.Write(vn);
                string eing = AnsiConsole.Ask<string>("Eingabe:");
                AnsiConsole.Write(new Text(eing));
                break;
            }else if (auswahl == 4)
            {
                Panel vn = new Panel("[green]isActive: 1 = true; 0 = false[/]");
                vn.Header("[red]isActive[/]");
                AnsiConsole.Write(vn);
                string eing = AnsiConsole.Ask<string>("Eingabe:");
                AnsiConsole.Write(new Text(eing));
                break;
            }else if (auswahl == 0)
            {
                Console.WriteLine("Close");
                TableBenutzer();
                break;
            }
        }
    }
    
    
    private void TableVorfälle()
    {
        // Create a table
        var table = new Table();
        table.Title(new TableTitle("[Cyan]Vorfälle[/]"));
        // Add some columns
        table.AddColumn(new TableColumn("Nr.").Centered());
        table.AddColumn(new TableColumn("Funktion").Centered());

        // Add some rows
        table.AddRow("[White]1[/]", "[Blue]Show all[/]");
        table.AddRow("[White]2[/]", "[Magenta]Vorfall hinzufügen[/]");

        // Render the table to the console
        AnsiConsole.Write(table);
        AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        while (true)
        {
            int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Funktion [green](Nr.)[/]?"));
            if (auswahl == 1)
            {
                Console.WriteLine("Show all");
            }else if (auswahl == 2)
            {
                Console.WriteLine("Vorfall hinzufügen");
            }else if (auswahl == 0)
            {
                Console.WriteLine("Close");
                TableFkt();
                break;
            }
        }
    }

    private void TableLog()
    {
        // Create a table
        var table = new Table();
        table.Title(new TableTitle("[Yellow]Log[/]"));
        // Add some columns
        table.AddColumn(new TableColumn("Nr.").Centered());
        table.AddColumn(new TableColumn("[Green]Log anzeigen von:[/]").Centered());
        // Add some rows
        table.AddRow("[White]1[/]", "[Blue]Vorfälle[/]");
        table.AddRow("[White1]2[/]", "[Cyan]Benutzer[/]");
        // Render the table to the console
        AnsiConsole.Write(table);
        AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        while (true)
        {
            int auswahl = int.Parse(AnsiConsole.Ask<string>("Wähle eine Funktion [green](Nr.)[/]?"));
            if (auswahl == 1)
            {
                Console.WriteLine("Show all");
            }else if (auswahl == 2)
            {
                Console.WriteLine("Show all");
            }else if (auswahl == 0)
            {
                Console.WriteLine("Close");
                TableFkt();
                break;
            }
        }
    }

    private bool SelectTable(string type)
    {
        Panel panel = new Panel("[red]Table[/]");
        switch (type)
        {
            case "benutzer":
                panel.Header("[green]Benutzer[/]");
                break;
            case "vorfälle":
                panel.Header("[green]Vorfälle[/]");
                break;
            case "log":
                panel.Header("[green]Log[/]");
                break;
            default:
                break;
        }
        AnsiConsole.Write(panel);
        AnsiConsole.Write(new Panel("[red]0 Exit[/]"));
        while (true)
        {
            int eing = AnsiConsole.Ask<int>("Eingabe:");
            if (eing == 0)
            {
                return true;
            }
        }
    }
}
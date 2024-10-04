using ConsoleTables;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ConsoleCardGame.UserInterface.Pages;

public class StatsPage : Page
{
    private int CreatedGames { get; } = 0;
    private int FinishedGames { get; } = 0;

    private static void WriteTable()
    {
        var table = new Table().Centered();

        AnsiConsole.Live(table)
            .Start(ctx => 
            {
                table.Title("Stats");
                table.AddColumn("Card name");
                ctx.Refresh();
                Thread.Sleep(500);

                table.AddColumn("Power");
                ctx.Refresh();
                Thread.Sleep(500);
                
                table.AddColumn("Description");
                ctx.Refresh();
                Thread.Sleep(500);
                
                table.AddRow("King", "5", "King");
                ctx.Refresh();
                Thread.Sleep(500);
                
                table.AddRow("Queen", "4", "Queen");
                ctx.Refresh();
                Thread.Sleep(500);

                table.Border = TableBorder.Horizontal;
                ctx.Refresh();
                Thread.Sleep(500);
                
                
                table.Columns[0].Header = new Markup("[bold]Card name[/]");
                table.Columns[1].Header = new Markup("[bold red]Power[/]");
                table.Columns[2].Header = new Markup("[bold yellow]Description[/]");
                ctx.Refresh();

            });
    }

    private static string YesNo(bool value)
    {
        return value ? "Yes" : "No";
    }

    public override void View()
    {
        base.View();
        Console.WriteLine();
        WriteTable();

        Console.WriteLine("\nEnter any key for return to menu...");
        Console.ReadKey(true);

        HomePage homePage = new();
        homePage.View();
    }
}
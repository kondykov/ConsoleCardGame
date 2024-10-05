using Spectre.Console;

namespace ConsoleCardGame.UserInterface.Pages;

public class StatsPage : Page
{
    private int CreatedGames { get; } = 0;
    private int FinishedGames { get; } = 0;

    private List<string> TableHeaders { get; } =
    [
        "Timestamp", "First card", "Starting cards", "Last card", "Last cards", "Round duration", "Finished game?"
    ];

    private List<string> TableHeadersWithStyling { get; } =
    [
        "[bold]Timestamp[/]",
        "[bold Cyan]First card[/]",
        "[bold Cyan]Starting cards[/]",
        "[bold DarkMagenta]Last card[/]",
        "[bold DarkMagenta]Last cards[/]",
        "[bold #875fd7]Round duration[/]",
        "[bold #5f5f00]Finished game?[/]"
    ];

    private Dictionary<int, List<string>> TableRows { get; } = new()
    {
        { 0, [$"{DateTime.Now}", "CARD, fh", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 1, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 2, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 3, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 4, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 5, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 6, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] },
        { 7, [$"{DateTime.Now}", "CARD", "CARDS", "CARD", "CARDS", "15", "YES"] }
    };

    private List<string> TableFooters { get; } =
    [
        "", "First card", "Starting cards", "Last card", "Last cards", "Round duration", "Finished game?"
    ];

    private List<string> TableFootersWithStyling { get; } =
    [
        "",
        "[bold Cyan]First card[/]",
        "[bold Cyan]Starting cards[/]",
        "[bold DarkMagenta]Last card[/]",
        "[bold DarkMagenta]Total slot[/]",
        "[bold #875fd7]slot[/]",
        ""
    ];

    private static Table Instance { get; set; } = null!;

    private void WriteTable()
    {
        Instance = new Table();

        AnsiConsole.Live(Instance)
            .Start(ctx =>
            {
                Instance.ShowFooters = false;
                foreach (var item in TableHeaders.Select((value, i) => new { i, value }))
                {
                    Instance.AddColumn(new TableColumn(item.value).Footer(TableFooters[item.i]));
                    ctx.Refresh();
                    Thread.Sleep(200);
                }

                foreach (var row in TableRows)
                {
                    Instance.AddRow(row.Value.ToArray());
                    ctx.Refresh();
                    Thread.Sleep(200);
                }
                
                Instance.ShowFooters = true;
                ctx.Refresh();
                Thread.Sleep(200);
            });
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
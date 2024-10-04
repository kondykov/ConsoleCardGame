using ConsoleCardGame.UserInterface.Menu;

namespace ConsoleCardGame.UserInterface.Pages;

public class HomePage : Page
{
    private List<Option> Options { get; } =
    [
        new("New game", () =>
        {
            GamePage gamePage = new();
            gamePage.View();
        }),
        new("Stats", () =>
        {
            StatsPage statsPage = new();
            statsPage.View();
        }),
        new("Exit", () => Environment.Exit(0))
    ];

    public override void View()
    {
        Selector.Handle(Options, callingClass: nameof(HomePage));
    }
}
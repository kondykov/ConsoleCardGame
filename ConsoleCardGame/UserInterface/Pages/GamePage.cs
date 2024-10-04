using Spectre.Console;

namespace ConsoleCardGame.UserInterface.Pages;

public class GamePage : Page
{
    private static Task UpdateView()
    {
        var table = new Table().Centered();
        
        return Task.CompletedTask;
    }

    public override void View()
    {
        base.View();
        Console.WriteLine("Welcome to Console Card Game!");
        Task.Run(UpdateView);
    }
}
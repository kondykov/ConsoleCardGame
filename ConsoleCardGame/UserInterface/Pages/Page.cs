namespace ConsoleCardGame.UserInterface.Pages;

public class Page
{
    public static void WritePageTitle(bool noClear = false)
    {
        if(!noClear)
            Console.Clear();
        Console.Write(GameInfo.GetGameTitle() + ". ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(GameInfo.GetGameVersion());
        Console.ResetColor();
    }

    public static void WritePageError(string? message = null!)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message ?? $"Internal error");
        Console.ResetColor();
    }
    public virtual void View()
    {
        WritePageTitle();
    }

    public virtual async Task Update()
    {
        
    }
}
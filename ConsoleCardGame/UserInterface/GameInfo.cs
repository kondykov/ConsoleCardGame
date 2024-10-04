namespace ConsoleCardGame.UserInterface;

public static class GameInfo
{
    private const string GameTitle = "Card Game";
    private const string GameVersion = "Indev 1.0";
    
    public static string GetGameTitle() => GameTitle;
    public static string GetGameVersion() => GameVersion;
}
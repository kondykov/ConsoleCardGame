using ConsoleCardGame.FileManagement.Stats;

namespace ConsoleCardGame.Services;

public static class Initializer
{
    public static async Task Initialize()
    {
        await StatsManager.InitializeStatsAsync();
    }
}
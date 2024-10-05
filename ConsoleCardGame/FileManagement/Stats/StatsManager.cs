using Newtonsoft.Json;

namespace ConsoleCardGame.FileManagement.Stats;

public static class StatsManager
{
    private const string Path = "resources/stats.json";
    private const string Folder = "resources";

    private static readonly JsonSerializerSettings Config = new()
        { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

    public static async Task<List<Stats>?> GetStatsAsync()
    {
        return File.Exists(Path) ? JsonConvert.DeserializeObject<List<Stats>>(await File.ReadAllTextAsync(Path)) : null;
    }

    public static async Task AddStatsAsync(Stats stats)
    {
        var statsList = GetStatsAsync().Result ?? [];
        statsList.Add(stats);
        await SaveStatsAsync(statsList);
    }

    public static async Task SaveStatsAsync(List<Stats> statsList)
    {
        await File.WriteAllTextAsync(Path, JsonConvert.SerializeObject(statsList, Formatting.Indented, Config));
    }

    public static async Task InitializeStatsAsync()
    {
        Directory.CreateDirectory(Folder);
    }
}
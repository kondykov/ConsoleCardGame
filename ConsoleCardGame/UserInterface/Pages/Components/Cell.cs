namespace ConsoleCardGame.UserInterface.Pages.Components;

public class Cell
{
    public string TryAddContent(string cell, string[] content)
    {
        return cell.Contains("slot") ? cell.Replace("slot", content.ToString()) : "cell";
    }
    
    public string TryAddContent(string cell, List<string> content)
    {
        return cell.Contains("slot") ? cell.Replace("slot", content.ToString()) : "cell";
    }
    
    public static string YesNo(bool value)
    {
        return value ? "Yes" : "No";
    }
}
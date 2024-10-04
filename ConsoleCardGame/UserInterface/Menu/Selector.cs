using ConsoleCardGame.UserInterface.Pages;

namespace ConsoleCardGame.UserInterface.Menu;

public static class Selector
{
    private static void WriteMenu(List<Option> options, Option selectedOption, string subTitle = "")
    {
        if (options.Count >= Console.BufferHeight - 5) Console.Clear();
        Console.SetCursorPosition(0, 0);
        Page.WritePageTitle(true);
        Console.WriteLine(subTitle);
        foreach (var option in options)
            if (option == selectedOption)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t{option.Name}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine('\t' + option.Name!, 30);
            }
    }

    public static void Handle(List<Option> options, string message = null!, string callingClass = "")
    {
        if (options.Count <= 0)
        {
            Page.WritePageError(callingClass != "" ? $"Failed to load <<{callingClass}>> menu" : $"Failed to load menu");
            Console.WriteLine($"Game finished. Press any key to exit.");
            Console.ResetColor();
            Console.ReadKey(true);
            return;
        }
        Console.Clear();
        Console.CursorVisible = false;
        var index = 0;
        Console.WriteLine(message);
        WriteMenu(options, options[index]);
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }

                    break;
                case ConsoleKey.Enter:
                    options[index].Selected.Invoke();
                    index = 0;
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.X);
    }
}
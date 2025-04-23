using WCTool.Config;
using WCTool.Models;

namespace WCTool.Services;
public class CommandParser
{
    private readonly AppConfig _config;

    public CommandParser(AppConfig config)
    {
        _config = config;
    }

    public Command Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || !input.StartsWith("ccwc"))
            return new Command();

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // ccwc <file> — No flags, just file
        if (parts.Length == 2)
        {
            return BuildCommand(new List<CommandOption>(), parts[1]);
        }

        // ccwc -clw <file>
        if (parts.Length >= 3)
        {
            var options = ParseFlags(parts[1]);
            return BuildCommand(options, parts[2]);
        }

        return new Command();
    }

    private List<CommandOption> ParseFlags(string flagString)
    {
        var options = new List<CommandOption>();

        if (!flagString.StartsWith("-"))
            return options;

        foreach (var c in flagString.Skip(1))
        {
            var option = c switch
            {
                'c' => CommandOption.CountBytes,
                'l' => CommandOption.CountLines,
                'w' => CommandOption.CountWords,
                'm' => CommandOption.CountCharacters,
                _ => CommandOption.None
            };

            if (option != CommandOption.None && !options.Contains(option))
                options.Add(option);
        }

        return options;
    }

    private Command BuildCommand(List<CommandOption> options, string rawFile)
    {
        var cleaned = rawFile.Trim('"', ' ');
        var fullPath = Path.Combine(_config.BaseFolder, cleaned);

        return new Command
        {
            Options = options,
            FilePath = fullPath
        };
    }
}

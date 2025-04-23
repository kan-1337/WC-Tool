namespace WCTool.Models;
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

        // ccwc <file> — No flag provided
        if (parts.Length == 2)
            return BuildCommand(CommandOption.None, parts[1]);

        // ccwc -x <file> — Flag + file
        if (parts.Length >= 3)
        {
            var option = MapToOption(parts[1]);
            return BuildCommand(option, parts[2]);
        }

        return new Command(); // fallback
    }

    // ccwc -x <file> — Flag + file
    private Command BuildCommand(CommandOption option, string rawFile)
    {
        var cleaned = rawFile.Trim('"', ' ');
        var fullPath = Path.Combine(_config.BaseFolder, cleaned);

        return new Command
        {
            Option = option,
            FilePath = fullPath
        };
    }

    // ccwc <file> — No flag provided
    private CommandOption MapToOption(string flag) => flag switch
    {
        "-c" => CommandOption.CountBytes,
        "-l" => CommandOption.CountLines,
        "-w" => CommandOption.CountWords,
        "-m" => CommandOption.CountCharacters,
        _ => CommandOption.None
    };
}
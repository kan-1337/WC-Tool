internal class CommandParser
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

        if (parts.Length == 2)
        {
            var cleaned = parts[1].Trim('"', ' ');
            var fullPath = Path.Combine(_config.BaseFolder, cleaned);

            return new Command
            {
                Option = CommandOption.None,
                FilePath = fullPath
            };
        }

        if (parts.Length >= 3)
        {
            var option = parts[1] switch
            {
                "-c" => CommandOption.CountBytes,
                "-l" => CommandOption.CountLines,
                "-w" => CommandOption.CountWords,
                "-m" => CommandOption.CountCharacters,
                _ => CommandOption.None
            };

            var cleaned = parts[2].Trim('"', ' ');
            var fullPath = Path.Combine(_config.BaseFolder, cleaned);

            return new Command
            {
                Option = option,
                FilePath = fullPath
            };
        }

        return new Command();
    }
}
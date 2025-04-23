public class Command
{
    public CommandOption Option { get; set; }
    public string FilePath { get; set; } = string.Empty;

    public string FileName => Path.GetFileName(FilePath);

    public bool IsValid =>
        Option != CommandOption.None && File.Exists(FilePath);

    public static Command Parse(string input, AppConfig config)
    {
        if (string.IsNullOrWhiteSpace(input) || !input.StartsWith("ccwc"))
            return new Command();

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3)
            return new Command();

        var option = parts[1] switch
        {
            "-c" => CommandOption.CountBytes,
            "-l" => CommandOption.CountLines,
            "-w" => CommandOption.CountWords,
            "-m" => CommandOption.CountCharacters,
            _ => CommandOption.None
        };

        var cleaned = parts[2].Trim('"', ' ');
        var fullPath = Path.Combine(config.BaseFolder, cleaned);

        return new Command
        {
            Option = option,
            FilePath = fullPath
        };
    }
}

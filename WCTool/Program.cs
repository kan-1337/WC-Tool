var config = AppConfig.Load();
var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("No command provided.");
    return;
}

var command = Command.Parse(input, config);

if (!command.IsValid)
{
    Console.WriteLine("Invalid command or file not found.");
    return;
}

switch (command.Option)
{
    case CommandOption.CountBytes:
        Console.WriteLine($"{GetBytesFromFile(command),8} {Path.GetFileName(command.FilePath)}");
        break;
    case CommandOption.CountLines:
        Console.WriteLine(GetLineCount(command));
        break;
    case CommandOption.CountWords:
        Console.WriteLine($"{GetWordCount(command).Length,8} {command.FileName}");
        break;
    case CommandOption.CountCharacters:
        Console.WriteLine($"{GetCharacterCount(command),8} {command.FileName}");
        break;
    case CommandOption.None:
        Console.WriteLine($"{GetLineCount(command),8} {GetWordCount(command).Length,8} {GetBytesFromFile(command),8} {command.FileName}");
        break;
    default:
        Console.WriteLine("Unsupported command.");
        break;
}

// Helper methods
static int GetBytesFromFile(Command command)
{
    return File.ReadAllBytes(command.FilePath).Length;
}
static int GetLineCount(Command command)
{
    return File.ReadLines(command.FilePath).Count();
}
static string[] GetWordCount(Command command)
{
    var text = File.ReadAllText(command.FilePath);
    var words = text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
    return words;
}
static int GetCharacterCount(Command command)
{
    return File.ReadAllText(command.FilePath).Length;
}
var config = AppConfig.Load();
var input = Console.ReadLine();
var command = Command.Parse(input, config);

if (!command.IsValid)
{
    Console.WriteLine("Invalid command or file not found.");
    return;
}

switch (command.Option)
{
    case CommandOption.CountBytes:
        var bytes = File.ReadAllBytes(command.FilePath).Length;
        Console.WriteLine($"{bytes,8} {Path.GetFileName(command.FilePath)}");
        break;
    case CommandOption.CountLines:
        var lines = File.ReadLines(command.FilePath).Count();
        Console.WriteLine(lines);
        break;
    case CommandOption.CountWords:
        var text = File.ReadAllText(command.FilePath);
        var words = text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"{words.Length,8} {command.FileName}");
        break;
    default:
        Console.WriteLine("Unsupported command.");
        break;
}

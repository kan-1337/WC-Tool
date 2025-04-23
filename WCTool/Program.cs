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
    default:
        Console.WriteLine("Unsupported command.");
        break;
}

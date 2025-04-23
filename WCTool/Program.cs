using WCTool.Config;
using WCTool.Models;
using WCTool.Services;

var config = AppConfig.Load();
var parser = new CommandParser(config);
var executor = new CommandExecutor();

Console.WriteLine("Enter your command:");
var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("No command entered.");
    return;
}

var command = parser.Parse(input);

if (!command.IsValid)
{
    Console.WriteLine("Invalid command or file not found.");
    return;
}

if (!command.Options.Any())
{
    command.Options = new List<CommandOption>
    {
        CommandOption.CountLines,
        CommandOption.CountWords,
        CommandOption.CountBytes
    };
}

executor.Execute(command);

using WCTool.Config;
using WCTool.Models;
using WCTool.Services;

var config = AppConfig.Load();
var parser = new CommandParser(config);
var executor = new CommandExecutor();

string input = "";
if (Console.IsInputRedirected)
{
    input = "ccwc " + string.Join(" ", args);
}
else
{
    Console.WriteLine("Enter your command:");
    input = Console.ReadLine() ?? string.Empty;
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

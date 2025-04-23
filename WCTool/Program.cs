using WCTool.Models;
using WCTool.Services;

var config = AppConfig.Load();
var parser = new CommandParser(config);

Console.WriteLine("Enter your command:");
var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("No command entered.");
    return;
}

var command = parser.Parse(input);
var analyzer = new FileAnalyzer();

switch (command.Option)
{
    case CommandOption.CountBytes:
        Console.WriteLine($"{analyzer.GetByteCount(command.FilePath),8} {command.FileName}");
        break;

    case CommandOption.CountLines:
        Console.WriteLine($"{analyzer.GetLineCount(command.FilePath),8} {command.FileName}");
        break;

    case CommandOption.CountWords:
        Console.WriteLine($"{analyzer.GetWordCount(command.FilePath),8} {command.FileName}");
        break;

    case CommandOption.CountCharacters:
        Console.WriteLine($"{analyzer.GetCharacterCount(command.FilePath),8} {command.FileName}");
        break;

    case CommandOption.None:
        Console.WriteLine(
            $"{analyzer.GetLineCount(command.FilePath),8}" +
            $"{analyzer.GetWordCount(command.FilePath),8}" +
            $"{analyzer.GetByteCount(command.FilePath),8} {command.FileName}"
        );
        break;
}
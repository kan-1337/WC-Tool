using WCTool.Models;

namespace WCTool.Services;
public class CommandExecutor
{
    private readonly InputReader _inputReader;
    private readonly FileAnalyzer _analyzer;

    public CommandExecutor()
    {
        _inputReader = new InputReader();
        _analyzer = new FileAnalyzer();
    }

    public void Execute(Command command)
    {
        var inputText = _inputReader.Read(command);
        var outputParts = new List<string>();

        foreach (var option in command.Options)
        {
            var value = option switch
            {
                CommandOption.CountLines => _analyzer.GetLineCount(inputText),
                CommandOption.CountWords => _analyzer.GetWordCount(inputText),
                CommandOption.CountCharacters => _analyzer.GetCharacterCount(inputText),
                CommandOption.CountBytes => _analyzer.GetByteCount(inputText),
                _ => 0
            };

            outputParts.Add($"{value,8}");
        }

        Console.WriteLine(string.Join("", outputParts) + $" {command.FileName}");
    }
}

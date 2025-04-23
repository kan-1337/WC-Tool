namespace WCTool.Services;
public class FileAnalyzer
{
    public int GetByteCount(string filePath) => File.ReadAllBytes(filePath).Length;

    public int GetLineCount(string filePath) => File.ReadLines(filePath).Count();

    public int GetCharacterCount(string filePath) => File.ReadAllText(filePath).Length;

    public int GetWordCount(string filePath)
    {
        var text = File.ReadAllText(filePath);
        return text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}


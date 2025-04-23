using System.Text;

namespace WCTool.Services;
public class FileAnalyzer
{
    public int GetLineCount(string inputText) =>
        inputText.Split('\n').Length;

    public int GetWordCount(string inputText) =>
        inputText.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;

    public int GetCharacterCount(string inputText) =>
        inputText.Length;

    public int GetByteCount(string inputText) =>
        Encoding.UTF8.GetByteCount(inputText);
}



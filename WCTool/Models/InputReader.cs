namespace WCTool.Models;
public class InputReader
{
    public string Read(Command command)
    {
        if (Console.IsInputRedirected)
        {
            return Console.In.ReadToEnd();
        }

        if (!string.IsNullOrEmpty(command.FilePath) && File.Exists(command.FilePath))
        {
            return File.ReadAllText(command.FilePath);
        }

        return string.Empty;
    }
}

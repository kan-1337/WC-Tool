using System.Text.Json;
namespace WCTool.Config;
public class AppConfig
{
    public string BaseFolder { get; set; } = "";

    public static AppConfig Load(string path = "config.json")
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"⚠️ Config file not found at: {Path.GetFullPath(path)}");
            Console.WriteLine("Make sure it's copied to the output directory.");
            Environment.Exit(1);
        }

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<AppConfig>(json)!;
    }
}


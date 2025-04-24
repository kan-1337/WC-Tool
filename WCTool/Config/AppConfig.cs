using System.Text.Json;
namespace WCTool.Config;
public class AppConfig
{
    public string BaseFolder { get; set; } = "";
    public static AppConfig Load()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "config.json");

        if (!File.Exists(path))
        {
            Console.WriteLine($"⚠️ Config file not found at: {path}");
            return new AppConfig();
        }

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
    }
}


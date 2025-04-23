public class Command
{
    public CommandOption Option { get; set; }
    public string FilePath { get; set; } = string.Empty;

    public string FileName => Path.GetFileName(FilePath);

    public bool IsValid => File.Exists(FilePath);
}

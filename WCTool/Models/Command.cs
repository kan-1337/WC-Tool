﻿namespace WCTool.Models;
public class Command
{
    public List<CommandOption> Options { get; set; } = new();

    public string FilePath { get; set; } = string.Empty;

    public string FileName => Path.GetFileName(FilePath);
    public bool IsValid =>
        (Console.IsInputRedirected || File.Exists(FilePath));
}

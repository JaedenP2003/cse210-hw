using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string StringEntry { get; set; }

    public Entry(string prompt, string entryText)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        StringEntry = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry: {StringEntry}");
        Console.WriteLine("-----------------------------------");
    }
}

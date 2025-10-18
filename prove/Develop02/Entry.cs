using System;
using System.ComponentModel;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _stringEntry;

    public Entry(string prompt, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _stringEntry = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Entry: {_stringEntry}");
        Console.WriteLine("-----------------------------------");
    }
}

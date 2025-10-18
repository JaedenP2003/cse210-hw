using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public string _filename;
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAllEntries()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToJson(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine($"Entries saved to {filename}");
    }

    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        Console.WriteLine($"Entries loaded from {filename}");
    }

}

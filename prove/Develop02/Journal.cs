using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public string Filename { get; set; }
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAllEntries()
    {
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }
    public void SaveToJson(string filename)
    {
        string json = JsonSerializer.Serialize(Entries, new JsonSerializerOptions { WriteIndented = true });
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
        Entries = JsonSerializer.Deserialize<List<Entry>>(json);
        Console.WriteLine($"Entries loaded from {filename}");
    }

}

using System;
using System.Collections.Generic;
using System.IO;

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

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.StringEntry}");
            }
        }
        Console.WriteLine($"Entries saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2]);
                entry.Date = parts[0]; // override with saved date
                Entries.Add(entry);
            }
        }
        Console.WriteLine($"Entries loaded from {filename}");
    }
}

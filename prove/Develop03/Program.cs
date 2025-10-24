using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
class Program
{
    static void Main(string[] args)
    {
        string filename = "scriptures.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found!");
            return;
        }

        List<Scripture> scriptures = LoadScripturesFromFile(filename);

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in file.");
            return;
        }

        Console.WriteLine("Choose a scripture to practice:\n");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
        }

        Console.Write("\nEnter a number: ");
        string choice = Console.ReadLine();

        if (!int.TryParse(choice, out int index) || index < 1 || index > scriptures.Count)
        {
            Console.WriteLine("Invalid choice. Exiting.");
            return;
        }

        Scripture scripture = scriptures[index - 1];

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("You've memorized the scripture!");
                break;
            }

            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(1);
        }
    }
    static List<Scripture> LoadScripturesFromFile(string filename) // I wanted to make it so that I could load scriptures from a text file to make it easier to add more scriptures in the future. This is how I showed creativity.
        {
            List<Scripture> scriptures = new List<Scripture>();

            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] parts = parser.ReadFields();

                    
                    if (parts.Length < 5) continue;

                    string book = parts[0].Trim();
                    int chapter = int.Parse(parts[1].Trim());
                    int startVerse = int.Parse(parts[2].Trim());
                    int? endVerse = string.IsNullOrWhiteSpace(parts[3]) ? null : int.Parse(parts[3].Trim());
                    string text = parts[4].Trim();

                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    Scripture scripture = new Scripture(reference, text);
                    scriptures.Add(scripture);
                }
            }

            return scriptures;
        }
}


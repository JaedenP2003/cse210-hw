using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List the people you appreciate.",
        "List your personal strengths.",
        "List the blessings in your life.",
        "List the things that make you laugh."
    };

    public ListingActivity() 
        : base("Listing Activity", 
              "This activity helps you reflect on the good things in your life by listing as many as you can in a given time.")
    {
    }

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($">>> {prompt} <<<");
        Console.WriteLine("\nYou may begin in: ");
        ShowAnimation(3);

        List<string> responses = new List<string>();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            responses.Add(response);
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        EndActivity();
        ActivityLogger.Log(_name, _duration);
    }
}

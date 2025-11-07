using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself through this experience?",
        "Have you ever done anything like this before?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() 
        : base("Reflecting Activity", 
              "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nConsider the following prompt:\n>>> {prompt} <<<");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on the following questions:");
        ShowAnimation(3);

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"> {question} ");
            ShowAnimation(5);
            Console.WriteLine();
        }

        EndActivity();
        ActivityLogger.Log(_name, _duration);
    }
}

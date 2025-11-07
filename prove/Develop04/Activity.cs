using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");

        Console.WriteLine("\nGet ready...");
        ShowAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        ShowAnimation(2);
        Console.WriteLine($"You’ve completed {_duration} seconds of {_name}.");
        ShowAnimation(2);
    }

    protected void ShowAnimation(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}

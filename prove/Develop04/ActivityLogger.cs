using System;
using System.IO;

public static class ActivityLogger
{
    private static string _logFile = "activity_log.txt";

    // This method records a line each time an activity ends
    public static void Log(string activityName, int duration)
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {activityName} for {duration} seconds";
        File.AppendAllText(_logFile, entry + Environment.NewLine);
    }

    // Optional: show previous logs when the program starts
    public static void DisplayLog()
    {
        if (File.Exists(_logFile))
        {
            Console.Clear();
            Console.WriteLine("\nPrevious Activity Log:");
            Console.WriteLine("----------------------");
            string[] lines = File.ReadAllLines(_logFile);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
            Console.WriteLine("----------------------\n");
        }
        else
        {
            Console.WriteLine("\nNo previous logs found.\n");
        }
    }
}

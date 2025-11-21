using System;

/*
  Creative features added:
    - Simple Level/Badge system: every 1000 points = new "Level X" badge automatically awarded.
      Additional badge "Veteran" awarded at 5000 points.
    - Score is saved and loaded with goals (goals_save.txt).
    - Badges and level are displayed alongside total score.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        // Attempt to auto-load existing save (optional)
        if (System.IO.File.Exists("goals_save.txt"))
        {
            Console.Write("A save file was found. Load it? (y/n): ");
            string ans = Console.ReadLine().Trim().ToLower();
            if (ans == "y")
            {
                manager.LoadDefault();
            }
        }

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1) Create a new goal");
            Console.WriteLine("2) List goals");
            Console.WriteLine("3) Record event (complete a goal)");
            Console.WriteLine("4) Show score & badges");
            Console.WriteLine("5) Save goals");
            Console.WriteLine("6) Load goals");
            Console.WriteLine("7) Quit");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.DisplayGoals();
                    manager.Pause();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    Console.Clear();
                    manager.DisplayScore();
                    manager.Pause();
                    break;
                case "5":
                    manager.SaveDefault();
                    break;
                case "6":
                    manager.LoadDefault();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    System.Threading.Thread.Sleep(800);
                    break;
            }
        }

        Console.WriteLine("Goodbye — keep up the quest!");
    }
}

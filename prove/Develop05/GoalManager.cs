using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private HashSet<string> _badges; // creative feature: badges awarded once

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _badges = new HashSet<string>();
    }

    // Create a goal interactively
    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Create a new goal");
        Console.WriteLine("-----------------");
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1) Simple goal (one-time reward)");
        Console.WriteLine("2) Eternal goal (repeatable)");
        Console.WriteLine("3) Checklist goal (repeatable with bonus when finished)");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points per record: ");
        int points = ReadIntFallback(0);

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count (e.g., 10): ");
                int target = ReadIntFallback(1);
                Console.Write("Enter bonus points on completion: ");
                int bonus = ReadIntFallback(0);
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to menu.");
                System.Threading.Thread.Sleep(800);
                return;
        }

        Console.WriteLine("Goal created!");
        System.Threading.Thread.Sleep(800);
    }

    // Record an event for a selected goal
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            Pause();
            return;
        }

        DisplayGoals();
        Console.Write("Enter the number of the goal you completed (or 0 to cancel): ");
        int idx = ReadIntFallback(-1);

        if (idx <= 0 || idx > _goals.Count)
        {
            Console.WriteLine("Canceled or invalid choice.");
            Pause();
            return;
        }

        Goal g = _goals[idx - 1];
        int earned = g.RecordEvent();

        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            CheckForBadges();
        }
        else
        {
            Console.WriteLine("No points earned (maybe the goal was already completed).");
        }

        Pause();
    }

    // Display goals with status
    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("Your Goals");
        Console.WriteLine("----------");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Goal g = _goals[i];
                Console.WriteLine($"{i + 1}. {g.GetStatusString()} {g.GetName()} - {g.GetDescription()} (Points: {g.GetPoints()})");
            }
        }
        Console.WriteLine();
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nTotal Score: {_score} points");
        Console.WriteLine($"Level: {GetLevel()}");
        if (_badges.Count > 0)
        {
            Console.WriteLine("Badges: " + string.Join(", ", _badges));
        }
        else
        {
            Console.WriteLine("Badges: (none yet)");
        }
    }

    // Save goals to a text file (simple, robust format)
    public void SaveGoals(string filename)
    {
        try
        {
            List<string> lines = new List<string>();
            lines.Add(_score.ToString()); // first line is score

            foreach (Goal g in _goals)
            {
                lines.Add(g.Serialize());
            }

            // badges saved as comma-separated on final line
            lines.Add(string.Join(",", _badges));

            File.WriteAllLines(filename, lines);
            Console.WriteLine($"Saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
        Pause();
    }

    // Load goals from file created by SaveGoals
    public void LoadGoals(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                Pause();
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("Save file empty.");
                Pause();
                return;
            }

            _goals.Clear();
            _badges.Clear();

            // First line is score
            _score = int.Parse(lines[0]);

            // All intermediate lines are goals until the last line which is badges
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');

                string type = parts[0];
                if (type == "SIMPLE")
                {
                    // SIMPLE|name|description|points|isComplete
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal g = new SimpleGoal(name, desc, points);
                    if (isComplete) g.RecordEvent();

                    _goals.Add(g);
                }
                else if (type == "ETERNAL")
                {
                    // ETERNAL|name|description|points
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int points = int.Parse(parts[3]);
                    EternalGoal g = new EternalGoal(name, desc, points);
                    _goals.Add(g);
                }
                else if (type == "CHECKLIST")
                {
                    // CHECKLIST|name|description|points|target|current|bonus|isComplete
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int points = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int current = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    bool isComplete = bool.Parse(parts[7]);

                    ChecklistGoal g = new ChecklistGoal(name, desc, points, target, bonus);
                    g.SetCurrentCount(current);
                    if (isComplete)
                    {

                        if (current >= target)
                        {

                        }
                    }
                    _goals.Add(g);
                }
            }

            // Last line: badges (comma separated)
            if (lines.Length >= 2)
            {
                string badgesLine = lines[lines.Length - 1];
                if (!string.IsNullOrWhiteSpace(badgesLine))
                {
                    string[] badges = badgesLine.Split(',');
                    foreach (string b in badges)
                    {
                        if (!string.IsNullOrWhiteSpace(b)) _badges.Add(b.Trim());
                    }
                }
            }

            Console.WriteLine("Goals loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }

        Pause();
    }

    // Helper: simple save/load is used; we escape vertical bar used as separator
    private string Unescape(string s) => s.Replace("&#124;", "|");

    // Save and load used score to preserve total score across runs

    private int ReadIntFallback(int defaultValue)
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int val)) return val;
        return defaultValue;
    }

    public void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    // Small creative feature: level increases every 1000 points and badges at thresholds
    private void CheckForBadges()
    {
        int level = GetLevel();
        if (level >= 1 && !_badges.Contains("Level " + level))
        {
            _badges.Add("Level " + level);
            Console.WriteLine($"Badge earned: Level {level}!");
        }

        if (_score >= 5000 && !_badges.Contains("Veteran"))
        {
            _badges.Add("Veteran");
            Console.WriteLine("Badge earned: Veteran (5000 pts)!");
        }
    }

    public int GetLevel() => _score / 1000;

    // Expose saving/loading with default file name
    public void SaveDefault() => SaveGoals("goals_save.txt");
    public void LoadDefault() => LoadGoals("goals_save.txt");
}

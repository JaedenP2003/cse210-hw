using System;

public class SimpleGoal : Goal
{
    // Constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // When recorded, award points once and mark complete
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            SetComplete(true);
            return GetPoints();
        }
        else
        {
            // Already completed
            return 0;
        }
    }

    public override string GetStatusString()
    {
        return base.GetStatusString();
    }

    // Serialize to a single-line representation:
    // SIMPLE|name|description|points|isComplete
    public override string Serialize()
    {
        return $"SIMPLE|{Escape(GetName())}|{Escape(GetDescription())}|{GetPoints()}|{IsComplete()}";
    }

    private string Escape(string s) => s.Replace("|", "&#124;");
}

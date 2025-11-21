using System;

public class EternalGoal : Goal
{
    // Eternal goals never complete; they award points every time.
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Always award points, never mark complete
        return GetPoints();
    }

    public override string GetStatusString()
    {
        // Eternal goals are never marked complete
        return "[∞]";
    }

    // ETERNAL|name|description|points
    public override string Serialize()
    {
        return $"ETERNAL|{Escape(GetName())}|{Escape(GetDescription())}|{GetPoints()}";
    }

    private string Escape(string s) => s.Replace("|", "&#124;");
}

using System;

public abstract class Goal
{
    // Private fields (encapsulation)
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    // Base constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    // Public accessors (read-only)
    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public bool IsComplete() => _isComplete;

    // Protected setter for derived classes to mark completion
    protected void SetComplete(bool value) => _isComplete = value;

    // Polymorphic behavior - derived classes override how they record events
    // Returns points awarded by recording the event
    public virtual int RecordEvent()
    {
        return 0;
    }

    // Status string for display in lists
    public virtual string GetStatusString()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    // Persist format - used by GoalManager save/load
    // Subclasses should include type when saving/loading
    public abstract string Serialize();
}

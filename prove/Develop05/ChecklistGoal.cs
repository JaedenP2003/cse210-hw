using System;

public class ChecklistGoal : Goal
{
    // private fields for checklist progress
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
            return 0;

        _currentCount++;

        int award = GetPoints();

        if (_currentCount >= _targetCount)
        {
            // Completed the checklist goal
            SetComplete(true);
            award += _bonusPoints;
        }

        return award;
    }

    public override string GetStatusString()
    {
        // Example: [ ] Completed 2/5 times
        return $"{(IsComplete() ? "[X]" : "[ ]")} Completed {_currentCount}/{_targetCount} times";
    }

    // CHECKLIST|name|description|points|target|current|bonus|isComplete
    public override string Serialize()
    {
        return $"CHECKLIST|{Escape(GetName())}|{Escape(GetDescription())}|{GetPoints()}|{_targetCount}|{_currentCount}|{_bonusPoints}|{IsComplete()}";
    }

    // Methods to initialize state when loading
    public void SetCurrentCount(int value) => _currentCount = value;
    public void SetTargetCount(int value) => _targetCount = value;
    public void SetBonus(int value) => _bonusPoints = value;

    private string Escape(string s) => s.Replace("|", "&#124;");
}

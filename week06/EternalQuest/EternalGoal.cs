using System;

// A goal that is never "finished" -- every time the user records it
// they simply earn points again, forever (e.g. reading scriptures).
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        // Eternal goals are, by definition, never complete.
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) -- Ongoing";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}

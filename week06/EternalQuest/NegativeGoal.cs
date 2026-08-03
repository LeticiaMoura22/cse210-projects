using System;

// CREATIVE ADDITION: represents a bad habit the user is trying to
// stop (e.g. "Skipped scripture study" or "Stayed up too late").
// Recording this goal SUBTRACTS points instead of adding them,
// which reinforces breaking bad habits as part of the quest.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override bool IsComplete()
    {
        // A habit to avoid is never really "finished."
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) -- Avoid this! (-{_points} points each time)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}

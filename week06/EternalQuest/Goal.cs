using System;

// Base class for all goal types. Holds the attributes shared by every
// kind of goal (name, description, and the base point value) and
// declares the behaviors that each derived class must implement
// polymorphically.
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string ShortName
    {
        get { return _shortName; }
    }

    // Records that the goal was worked on / accomplished one time.
    // Returns the number of points earned (can be negative for
    // NegativeGoal) so GoalManager can update the overall score.
    public abstract int RecordEvent();

    // Whether the goal has been fully completed.
    public abstract bool IsComplete();

    // A human readable line describing the goal and its current
    // status, used when listing goals to the user.
    public abstract string GetDetailsString();

    // A string that can be written to a file and later parsed back
    // into an equivalent Goal object (simple "serialization").
    public abstract string GetStringRepresentation();
}

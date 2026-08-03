using System;

// CREATIVE ADDITION: lets the user make incremental progress toward
// one big goal, such as running a marathon one mile at a time, or
// reading a long book one chapter at a time. Each recorded event
// adds one unit of progress and earns points; reaching the target
// earns a large completion bonus on top of the per-unit points.
public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;
    private string _unit;

    public ProgressGoal(string name, string description, int points, int targetProgress, string unit)
        : base(name, description, points)
    {
        _currentProgress = 0;
        _targetProgress = targetProgress;
        _unit = unit;
    }

    // Used when loading a saved goal with existing progress.
    public ProgressGoal(string name, string description, int points, int targetProgress, string unit, int currentProgress)
        : base(name, description, points)
    {
        _currentProgress = currentProgress;
        _targetProgress = targetProgress;
        _unit = unit;
    }

    public override int RecordEvent()
    {
        if (_currentProgress >= _targetProgress)
        {
            return 0;
        }

        _currentProgress++;
        int earned = _points;

        if (_currentProgress >= _targetProgress)
        {
            // Big one-time bonus for finishing the whole thing.
            earned += _points * 5;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _targetProgress;
    }

    public override string GetDetailsString()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        double percent = _targetProgress == 0 ? 0 : (100.0 * _currentProgress / _targetProgress);
        return $"{check} {_shortName} ({_description}) -- Progress: {_currentProgress}/{_targetProgress} {_unit} ({percent:0}%)";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName},{_description},{_points},{_targetProgress},{_unit},{_currentProgress}";
    }
}

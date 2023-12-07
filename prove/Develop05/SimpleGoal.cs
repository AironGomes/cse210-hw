using System.Drawing;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal has already been completed");
            return 0;
        }
        else 
        {
            _isComplete = true;
            return int.Parse(_points);
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"Goal:SimpleGoal;Name:{_shortName};Description:{_description};Points:{_points};IsComplete:{_isComplete}";
    }
}
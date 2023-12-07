public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {}

    public override int RecordEvent()
    {
        return int.Parse(_points);
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Goal:EternalGoal;Name:{_shortName};Description:{_description};Points:{_points}";
    }
}
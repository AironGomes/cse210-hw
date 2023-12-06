public abstract class Goal
{
    internal string _shortName;
    internal string _description;
    internal string _points;

    public Goal(string name, string description, string points) 
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
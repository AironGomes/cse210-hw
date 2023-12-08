public class EternalGoal : Goal
{

    private int _countAchievements;

    public EternalGoal(string name, string description, string points, int countAchievements = 0) : base(name, description, points)
    {
        _countAchievements = countAchievements;
    }

    public override int RecordEvent()
    {
        _countAchievements++;
        return int.Parse(_points);
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Goal:EternalGoal;Name:{_shortName};Description:{_description};Points:{_points};Achievements:{_countAchievements}";
    }

    public override int GetScorePoints()
    {
        return _countAchievements * int.Parse(_points);
    }
}
public class ChecklistGoal : Goal
{
    private int _target;
    private int _amountCompleted;
    private int _bonus;
        

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted = 0) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
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
            _amountCompleted++;
            if (IsComplete())
            {
                return int.Parse(_points) + _bonus;
            }
            else
            {
                return int.Parse(_points);
            }
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Currently completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Goal:ChecklistGoal;Name:{_shortName};Description:{_description};Points:{_points};AmountCompleted:{_amountCompleted};Target:{_target};Bonus:{_bonus}";
    }
}
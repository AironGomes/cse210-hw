using System.Text.Json;
using System.Text.Json.Serialization;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager() 
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        DisplayPlayerInfo();

        string option = "";

        while (option != "6") 
        {
            option = ChooseOption();

            switch(option) 
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalDetails();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }


    private string ChooseOption()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
        Console.Write("Select a choice from the menu: ");
        string choice = Console.ReadLine();
        return choice;
    }

    private void ListGoalName()
    {

    }

    private void ListGoalDetails()
    {
        for (var i = 1; i<= _goals.Count; i++)
        {
            string detail = _goals[i-1].GetDetailsString();
            Console.WriteLine($"{i}. [ ] {detail}");
        }
    }

    private void CreateGoal()
    {
        string option = "";

        while (option != "1" || option != "2" || option != "3") 
        {
            option = CreateGoalOptions();

            switch(option) 
                {
                    case "1":
                        CreateSimpleGoal();
                        break;
                    case "2":
                        CreateEternalGoal();
                        break;
                    case "3":
                        CreateChecklistGoal();
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }
        }
    }

    private string CreateGoalOptions()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();
        return choice;
    }

    private void CreateSimpleGoal()
    {
        string goalName = GetResponse("What is the name of your goal? ");
        string goalDescription = GetResponse("What is the short description of it? ");
        string goalPoints = GetResponse("What is the amount of points associated with this goal? ");

        SimpleGoal newGoal = new SimpleGoal(
            name: goalName,
            description: goalDescription,
            points: goalPoints
        );

        AddToGoalList(newGoal);
    }

    private void CreateEternalGoal()
    {
        string goalName = GetResponse("What is the name of your goal? ");
        string goalDescription = GetResponse("What is the short description of it? ");
        string goalPoints = GetResponse("What is the amount of points associated with this goal? ");

        EternalGoal newGoal = new EternalGoal(
            name: goalName,
            description: goalDescription,
            points: goalPoints
        );

        AddToGoalList(newGoal);
    }

    private void CreateChecklistGoal()
    {
        string goalName = GetResponse("What is the name of your goal? ");
        string goalDescription = GetResponse("What is the short description of it? ");
        string goalPoints = GetResponse("What is the amount of points associated with this goal? ");
        string goalTarget = GetResponse("How many times does this goal need to be accomplished for a bonus? ");
        string goalBonus = GetResponse("What is the bonus for accomplishing it that many times? ");

        ChecklistGoal newGoal = new ChecklistGoal(
            name: goalName,
            description: goalDescription,
            points: goalPoints,
            target: int.Parse(goalTarget),
            bonus: int.Parse(goalBonus)
        );

        AddToGoalList(newGoal);
    }

    private string GetResponse(string question)
    {
        Console.Write(question);
        string response = Console.ReadLine();
        return response;
    }

    private void AddToGoalList(Goal goal)
    {
        _goals.Add(goal);
    }

    private void RecordEvent()
    {
    }

    private void SaveGoals(string file)
    {
        string json = JsonSerializer.Serialize(_goals);
        File.WriteAllText(@$"{file}", json);
    }

    private void LoadGoals(string file)
    {
        string jsonString = File.ReadAllText(file);
        _goals = JsonSerializer.Deserialize<List<Goal>>(jsonString);
    }
}
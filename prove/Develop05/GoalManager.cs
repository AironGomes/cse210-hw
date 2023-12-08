using System.IO;
using System.Reflection.Metadata;
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
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
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
        DisplayPlayerInfo();

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
        Console.WriteLine("The goals are:");
        for (var i = 1; i<= _goals.Count; i++)
        {
            Goal goal = _goals[i-1];
            Console.WriteLine($"{i}. {goal.GetGoalName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (var i = 1; i<= _goals.Count; i++)
        {
            Goal goal = _goals[i-1];

            string detail = goal.GetDetailsString();
            if (goal.IsComplete())
            {
                Console.WriteLine($"{i}. [X] {detail}");
            }
            else
            {
                Console.WriteLine($"{i}. [ ] {detail}");
            }
        }
        Console.WriteLine();
    }

    private void CreateGoal()
    {
        string option = "";

        while (option != "1" && option != "2" && option != "3") 
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
        Console.WriteLine();
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
        ListGoalName();
        Console.Write("Which goal did you accomplish? ");
        string choice = Console.ReadLine();
        int choiceValue = int.Parse(choice);


        if(1 <= choiceValue && choiceValue <= _goals.Count)
        {
            int points = _goals[choiceValue-1].RecordEvent();
            _score += points;
        }
        else
        {
            Console.WriteLine("An error occurred while loading the data.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            _goals.ForEach((goal)=> {
                outputFile.WriteLine(goal.GetStringRepresentation());
            });
        }
        
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(";");

            string goalType = parts[0].Split(":").Last();

            switch(goalType) 
                {
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new SimpleGoal(
                            name: parts[1].Split(":").Last(), 
                            description: parts[2].Split(":").Last(), 
                            points: parts[3].Split(":").Last(),
                            isComplete: bool.Parse(parts[4].Split(":").Last())
                        );
                        AddToGoalList(simpleGoal);
                        _score += simpleGoal.GetScorePoints();
                        break;
                    case "EternalGoal":
                        EternalGoal eternalGoal = new EternalGoal(
                            name: parts[1].Split(":").Last(), 
                            description: parts[2].Split(":").Last(), 
                            points: parts[3].Split(":").Last(),
                            countAchievements: int.Parse(parts[4].Split(":").Last())
                        );
                        AddToGoalList(eternalGoal);
                        _score += eternalGoal.GetScorePoints();
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new ChecklistGoal(
                            name: parts[1].Split(":").Last(), 
                            description: parts[2].Split(":").Last(), 
                            points: parts[3].Split(":").Last(),
                            amountCompleted: int.Parse(parts[4].Split(":").Last()),
                            target: int.Parse(parts[5].Split(":").Last()),
                            bonus: int.Parse(parts[6].Split(":").Last())
                        );
                        AddToGoalList(checklistGoal);
                        _score += checklistGoal.GetScorePoints();
                        break;
                    default:
                        Console.WriteLine("An error occurred while loading the data.");
                        break;
                }
        }
        
    }
}
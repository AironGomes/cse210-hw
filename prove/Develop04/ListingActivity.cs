public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _userList;

    public ListingActivity() 
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        InitiatePromptList();
        InitializeCount();
        _userList = new List<string>();

    }

    private void InitiatePromptList()
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    private void InitializeCount()
    {
        _count = 0;
    }

    public void Run()
    {
        InitializeCount();
        DisplayPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        WriteList();
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
    }

    private string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int position = randomGenerator.Next(0, _prompts.Count);
        return _prompts[position];
    }

    private void WriteList()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            _userList.Add(answer);
            _count ++;
        }
    }

    private List<string> GetListFromUser()
    {
        return _userList;
    }
}
using System;

class Program
{
    static PromptGenerator _prompt = new PromptGenerator();
    static Journal _journal = new Journal();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        string action = "";

        while (action != "5") 
        {
            action = GetAction();

            switch(action) 
            {
            case "1":
                Entry newEntry = WriteEntry();
                _journal.AddEntry(newEntry);
                break;
            case "2":
                _journal.DisplayAll();
                break;
            case "3":
                _journal.LoadFromFile("file.json");
                break;
            case "4":
                _journal.SaveToFile("file.json");
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Invalid value. Try again.");
                break;
            }
        }
    }

    static string GetAction()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        string action = Console.ReadLine();
        return action;
    }

    static Entry WriteEntry()
    {
        string newPrompt = _prompt.GetRandomPrompt();
        Console.WriteLine($"{newPrompt}");

        Console.Write("> ");
        string newText = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string newDate = theCurrentTime.ToShortDateString();

        Entry entry = new Entry {
            _entryText = newText,
            _promptText = newPrompt,
            _date = newDate
        };

        return entry;
    }
}
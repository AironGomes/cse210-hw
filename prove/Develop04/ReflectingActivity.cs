public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() 
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        InitiatePromptList();
        InitiateQuestionList();
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

    private void InitiateQuestionList()
    {
        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayPrompt();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
    }

    private string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int position = randomGenerator.Next(0, _prompts.Count);
        return _prompts[position];
    }

    private string GetRandomQuestion(List<string> questions)
    {
        Random randomGenerator = new Random();
        int position = randomGenerator.Next(0, questions.Count);
        return questions[position];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        List<string> questions = new List<string>(_questions);

        while (DateTime.Now < endTime && questions.Count > 0)
        {
            string question = GetRandomQuestion(questions);
            int index = questions.IndexOf(question);
            questions.RemoveAt(index);
            Console.Write($"> {question} ");
            ShowSpinner(6);
            Console.WriteLine();
        }
    }
    
}
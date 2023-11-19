using System;

class Program
{
    private static Reference reference = new Reference("Proverbs", 3, 5, 6);
    private static string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
    
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(reference, scriptureText);
        string answer = "";
        bool finished = false;

        while (answer != "quit" && !finished)
        {

            Console.Clear();
            
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            answer = Console.ReadLine();

            if(scripture.IsCompletelyHidden()) {
                finished = true;
            }
            else {
            Random randomGenerator = new Random();
            int randomValue = randomGenerator.Next(1, 5);
            scripture.HideRandomWords(randomValue);
            }
        }
    }
}   
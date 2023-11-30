using System;

class Program
{
    static BreathingActivity breathingActivity = new BreathingActivity();
    static ReflectingActivity reflectingActivity = new ReflectingActivity();
    static ListingActivity listingActivity = new ListingActivity();

    static void Main(string[] args)
    {
        string option = "";

        while (option != "4") 
        {
            option = ChooseOption();

            switch(option) 
                {
                    case "1":
                        breathingActivity.DisplayStartingMessage();
                        breathingActivity.Run();
                        breathingActivity.DisplayEndingMessage();
                        break;
                    case "2":
                        reflectingActivity.DisplayStartingMessage();
                        reflectingActivity.Run();
                        reflectingActivity.DisplayEndingMessage();
                        break;
                    case "3":
                        listingActivity.DisplayStartingMessage();
                        listingActivity.Run();
                        listingActivity.DisplayEndingMessage();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }
        }

    }

    static private string ChooseOption()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");
        Console.WriteLine(" 2. Start reflecting activity");
        Console.WriteLine(" 3. Start listing activity");
        Console.WriteLine(" 4. Quit");
        Console.Write("Select a choice from the menu: ");
        string choice = Console.ReadLine();
        return choice;
    }
}
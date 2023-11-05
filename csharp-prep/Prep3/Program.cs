using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumberValue = randomGenerator.Next(1, 101);

        int guessValue = -1;

        while(guessValue != magicNumberValue)
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            guessValue = int.Parse(guess);


            if (guessValue > magicNumberValue)
            {
                Console.WriteLine($"Lower");
            }
            else if (guessValue < magicNumberValue)
            {
                Console.WriteLine($"Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }
    }
}
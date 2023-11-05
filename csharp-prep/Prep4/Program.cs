using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int numberValue = -1;
        do
        {
            Console.Write("Enter number: ");
            string number = Console.ReadLine();
            numberValue = int.Parse(number);

            if (numberValue != 0)
            {
                numbers.Add(numberValue);
            }

        } while(numberValue != 0);

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        float average = ((float)sum) / numbers.Count;
        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
    }
}
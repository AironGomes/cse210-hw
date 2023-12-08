/*
* As an extra activity, I added that, when saving, it is possible to keep the number of times each Goal was achieved. When Loading, it is possible to retrieve this information and thus maintain the score data obtained.
* The GetScorePoints() abstrack was added to Goal and each child of this class implements this function according to its characteristics.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
public class BreathingActivity : Activity
{
    public BreathingActivity() 
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your though breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            BreatheIn();
            BreatheOut();
            Console.WriteLine();
        }
    }

    private void BreatheIn()
    {
        Console.Write("Breathe in...");
        ShowCountDown(4);
        Console.WriteLine();
    }

    private void BreatheOut()
    {
        Console.Write("Now breathe out...");
        ShowCountDown(6);
        Console.WriteLine();
    }
}
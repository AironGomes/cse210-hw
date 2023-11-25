public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() 
    {
        _name = "Listing";
        _description = "";

        _count = 0;
        _prompts = new List<string>();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public string GetRandomPrompt()
    {
        return "";
    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();
        return list;
    }
}
using System.Text.Json;
using System.Text.Json.Serialization;

public class Journal 
{

    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        string json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(@$"{file}", json);
    }

    public void LoadFromFile(string file)
    {
        string jsonString = File.ReadAllText(file);
        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
    }

}
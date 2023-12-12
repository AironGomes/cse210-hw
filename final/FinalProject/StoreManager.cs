public class StoreManager
{
    private Store _store;

    public void Start()
    {
        string option = "";

        while (option != "7") 
        {
            option = ChooseOption();

            switch(option) 
                {
                    case "1":
                        StoreInformation();
                        break;
                    case "2":
                        SalesHistory();
                        break;
                    case "3":
                        Stock();
                        break;
                    case "4":
                        SellProduct();
                        break;
                    case "5":
                        Load();
                        break;
                    case "6":
                        Save();
                        break;
                    case "7":
                        SaveAndQuit();
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }
        }
    }

    
    private string ChooseOption()
    {
        CheckStoreAvailability();

        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Store information");
        Console.WriteLine(" 2. Sales history");
        Console.WriteLine(" 3. Stock details");
        Console.WriteLine(" 4. Sell product");
        Console.WriteLine(" 5. Load store data");
        Console.WriteLine(" 6. Save");
        Console.WriteLine(" 7. Save and Quit");
        Console.Write("Select a choice from the menu: ");
        string choice = Console.ReadLine();
        return choice;
    }

    private void CheckStoreAvailability()
    {
        bool uninitialized = _store == default(Store); 
        
        while (uninitialized)
        {
            Console.Clear();
            string option = ChooseInitializationMethod();

            switch(option) 
                {
                    case "1":
                        RegisterStore();
                        break;
                    case "2":
                        Load();
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }

            uninitialized = _store == default(Store); 
        }
    }

    private string ChooseInitializationMethod()
    {
        Console.WriteLine("There is no store data. What do you want to do?");
            Console.WriteLine(" 1. Register a new store.");
            Console.WriteLine(" 2. Load saved data.");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            return choice;
    }

    private void RegisterStore()
    {
        Console.Clear();
        Console.Write("What is the store name? ");
        string storeName = Console.ReadLine();
        Store store = new Store(storeName);
        _store = store;
        Console.WriteLine("Store successfully registered! ");
        Console.WriteLine();
    }

    public void StoreInformation()
    {
        _store.ShowInfo();
    }

    public void SalesHistory()
    {}

    public void Stock()
    {}

    public void SellProduct()
    {
        if(!_store.HasStock())
        {
            Console.Write("There are no items in stock.");
            return;
        }
        
    }

    public void Load()
    {
        //Console.Write("What is the store name? ");
        //string filename = Console.ReadLine();

        
    }

    public void Save()
    {}

    public void SaveAndQuit()
    {}
}
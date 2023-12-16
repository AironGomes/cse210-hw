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
                        Stock();
                        break;
                    case "3":
                        SalesHistory();
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
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Store information");
        Console.WriteLine(" 2. Stock details");
        Console.WriteLine(" 3. Sales history");
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
    }

    public void StoreInformation()
    {
        _store.ShowInfo();
    }

    public void SalesHistory()
    {
        _store.ShowSalesHistory();
    }

    public void Stock()
    {
        string option = ChooseStockMenu();

            switch(option) 
                {
                    case "1":
                        _store.ShowStockProducts();
                        break;
                    case "2":
                        CreateProduct();
                        break;
                    default:
                        Console.WriteLine("Invalid value. Press a key to try again.");
                        Console.ReadLine();
                        break;
                }
    }

    private string ChooseStockMenu()
    {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Stock information");
            Console.WriteLine(" 2. Add new product");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            return choice;
    }

    public void CreateProduct()
    {
        Console.Clear();
        Console.Write("What is the product sku? ");
        string sku = Console.ReadLine();
        Console.Write("What is the product name? ");
        string name = Console.ReadLine();
        Console.Write("What is the product brand? ");
        string brand = Console.ReadLine();
        Console.Write("What is the product value? ");
        string value = Console.ReadLine();
        Console.WriteLine();
        
        Console.WriteLine("Please enter the batch expiration date");
        Console.Write("What is the validation Year: ");
        string validationYearText = Console.ReadLine();
        Console.Write("What is the validation Month: ");
        string validationMonthText = Console.ReadLine();
        Console.Write("What is the validation Day: ");
        string validationDayText = Console.ReadLine();
        Console.WriteLine();
        Console.Write("How many products from this batch do you want to add? ");
        string quantity = Console.ReadLine();

        DateTime validation = new DateTime(int.Parse(validationYearText), int.Parse(validationMonthText), int.Parse(validationDayText));

        string type = ChooseProductType();

            switch(type) 
                {
                    case "1":
                        bool isPerishable = AskSimpleQuestion("Is it a perishable food? ");
                        Food food = new Food(name, sku, validation, brand, isPerishable);
                        _store.AddStockProduct(food, int.Parse(quantity), double.Parse(value));
                        break;
                    case "2":
                        bool isAdulthood = AskSimpleQuestion("Is it an adults only drink? ");
                        Drink drink = new Drink(name, sku, validation, brand, isAdulthood);
                        _store.AddStockProduct(drink, int.Parse(quantity), double.Parse(value));
                        break;
                    case "3":
                        bool isDangerous = AskSimpleQuestion("Is this a dangerous product? ");
                        CleaningProduct cleaningProduct = new CleaningProduct(name, sku, validation, brand, isDangerous);
                        _store.AddStockProduct(cleaningProduct, int.Parse(quantity), double.Parse(value));
                        break;
                    default:
                        Console.WriteLine("Invalid value. Try again.");
                        Console.ReadLine();
                        break;
                }
    }

    private bool AskSimpleQuestion(string question)
    {
        string choose = "";

        while (choose != "1" && choose != "2") 
        {
            Console.WriteLine();
            Console.WriteLine(question);
            Console.WriteLine(" 1. True");
            Console.WriteLine(" 2. False");
            Console.Write("Choose one of the options above: ");
            choose = Console.ReadLine();
        }
        bool result;
        if (choose == "1")
        {
            result = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

    private string ChooseProductType()
    {
        Console.WriteLine();
        Console.WriteLine("Product type:");
        Console.WriteLine(" 1. Food");
        Console.WriteLine(" 2. Drink");
        Console.WriteLine(" 3. Cleaning Product");
        Console.Write("Choose one of the options above: ");
        string type = Console.ReadLine();
        return type;
    }

    public void SellProduct()
    {
        if(!_store.HasStock())
        {
            Console.Write("There are no items in stock.");
            return;
        }
        
        Console.Clear();
        _store.ShowStockProducts();
        Console.WriteLine();
        Console.Write("Choose the product to be sold (by sku): ");
        string sku = Console.ReadLine();
        Console.Write("Choose the quantity: ");
        string quantity = Console.ReadLine();
        _store.SellProduct(sku, int.Parse(quantity));
        
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
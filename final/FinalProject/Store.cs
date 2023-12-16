public class Store
{
    private string _name;
    private List<StockProduct> _stockList;
    private List<SalesHistory> _salesHistory;

    public Store(string name) 
    {
        _name = name;
        _stockList = new List<StockProduct>();
        _salesHistory = new List<SalesHistory>();
    }

    public void ShowInfo()
    {
         Console.WriteLine();
        Console.WriteLine($"Store: {_name}");
        Console.WriteLine($"Items in stock: {_stockList.Count}");
        Console.WriteLine($"Items sold: {_salesHistory.Count}");
    }

    public bool HasStock()
    {
        foreach(StockProduct sProduct in _stockList)
        {
            if (sProduct.GetQuantity() > 0)
            {
                return true;
            }
        }
        return false;
    }

    private bool HasSale()
    {
        foreach(SalesHistory saleHistory in _salesHistory)
        {
            if (saleHistory.GetQuantity() > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void ShowSalesHistory()
    {
        if(!HasSale())
        {
            Console.WriteLine("There is no sales record.");
            return;
        }
        else
        {
            Console.WriteLine("Sales history:");
            Console.WriteLine();

            foreach(SalesHistory sale in _salesHistory)
            {
                sale.GetProductInfo();
            }
        }
    }

    public void ShowStockProducts()
    {
        if(!HasStock())
        {
            Console.WriteLine("There are no items in stock.");
            return;
        }
        else
        {
            Console.WriteLine("Stock:");
            Console.WriteLine();
            foreach(StockProduct stockProduct in _stockList)
            {
                stockProduct.GetProductInfo();
            }
        }
    }
    
     public void AddStockProduct(Product product, int quantity, double value)
    {
        StockProduct stockProduct = new StockProduct(product, quantity, value);
        _stockList.Add(stockProduct);
    }

    public void SellProduct(string sku, int quantity)
    {
        bool successfully = false;

        for (int i = 0; i < _stockList.Count && !successfully; i++)
        {
            StockProduct sProduct = _stockList[i];

            if (sProduct.CheckEquivalence(sku, quantity))
            {
                sProduct.RemoveQuantity(quantity);

                if (sProduct.GetQuantity() <= 0)
                {
                    _stockList.RemoveAt(i);
                }

                SalesHistory salesHistory = new SalesHistory(sProduct.GetProduct(), quantity, sProduct.GetValue(), DateTime.Now);
                _salesHistory.Add(salesHistory);

                successfully = true;   
            }
        }

        if (!successfully)
        {
            Console.WriteLine("An error occurred while performing the product transaction.");
        }
    }

    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter($"{_name}-stock"))
        {
            _stockList.ForEach((stockProduct)=> {
                outputFile.WriteLine(stockProduct.GetStringRepresentation());
            });
        }

        using (StreamWriter outputFile = new StreamWriter($"{_name}-history"))
        {
            _salesHistory.ForEach((salesHistory)=> {
                outputFile.WriteLine(salesHistory.GetStringRepresentation());
            });
        }
    }

    public void Load()
    {
        LoadStock();
        LoadHistory();
    }

    private void LoadStock()
    {

        string[] lines = File.ReadAllLines($"{_name}-stock");

        foreach (string line in lines)
        {
            Product product = GetProduct(line);
            string[] parts = line.Split(";");

            int quantity = int.Parse(parts[7].Split(":").Last());
            double value = double.Parse(parts[8].Split(":").Last());

            AddStockProduct
            (
                product: product,
                quantity: quantity,
                value: value
            );
        }
    }

    private void LoadHistory()
    {

        string[] lines = File.ReadAllLines($"{_name}-history");

        foreach (string line in lines)
        {
            Product product = GetProduct(line);
            string[] parts = line.Split(";");

            int quantity = int.Parse(parts[7].Split(":").Last());
            double value = double.Parse(parts[8].Split(":").Last());
            DateTime saleDate = DateTime.Parse(parts[9].Split(":", 2).Last());


            SalesHistory salesHistory = new SalesHistory(
                product, 
                quantity, 
                value, 
                saleDate
                );
                _salesHistory.Add(salesHistory);
        }
    }

    private Product GetProduct(string line)
    {
        string[] parts = line.Split(";");
        string product = parts[1].Split(":").Last();

            switch(product) 
                {
                    case "Food":
                        Food food = new Food(
                            name: parts[2].Split(":").Last(), 
                            sku: parts[3].Split(":").Last(), 
                            validation: DateTime.Parse(parts[4].Split(":", 2).Last()),
                            brand: parts[5].Split(":").Last(),
                            isPerishable: bool.Parse(parts[6].Split(":").Last())
                        );

                        return food;
                    case "Drink":
                        Drink drink = new Drink(
                            name: parts[2].Split(":").Last(), 
                            sku: parts[3].Split(":").Last(), 
                            validation: DateTime.Parse(parts[4].Split(":", 2).Last()),
                            brand: parts[5].Split(":").Last(),
                            adulthood: bool.Parse(parts[6].Split(":").Last())
                        );

                        return drink;
                    case "CleaningProduct":
                        CleaningProduct cleaningProduct = new CleaningProduct(
                            name: parts[2].Split(":").Last(), 
                            sku: parts[3].Split(":").Last(), 
                            validation: DateTime.Parse(parts[4].Split(":", 2).Last()),
                            brand: parts[5].Split(":").Last(),
                            isDangerous: bool.Parse(parts[6].Split(":").Last())
                        );

                        return cleaningProduct;
                }
                throw new InvalidOperationException("Unidentified product");
    }
        
}
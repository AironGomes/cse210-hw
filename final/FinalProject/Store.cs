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
        Console.WriteLine($"Items sold: {_stockList.Count}");
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
}
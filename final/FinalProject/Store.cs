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
        Console.Clear();
        Console.WriteLine($"Store: {_name}");
        Console.WriteLine($"Items in stock: {_stockList.Count}");
        Console.WriteLine($"Items sold: {_stockList.Count}");
        Console.WriteLine();
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

    public void ShowSalesHistory()
    {
        Console.WriteLine("Sales history:");
        Console.WriteLine();

        foreach(SalesHistory sale in _salesHistory)
        {
            sale.GetProductInfo();
        }
    }
}
public class SalesHistory : ProductManager
{
    private DateTime _saleDate;
    public SalesHistory(Product product, int quantity, double value, DateTime saleDate) : base(product, quantity, value)
    {
        _saleDate = saleDate;
    }

    public override void GetProductInfo()
    {
        Console.WriteLine($"{_saleDate}: {_product.GetInfo()} - {_quantity} unit(s)");
    }

    public override string GetStringRepresentation()
    {
        return $"ProductManager:SalesHistory;{_product.GetStringRepresentation()};Quantity:{_quantity};Value:{_value};SaleDate^:{_saleDate}";
    }
}
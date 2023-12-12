public class SalesHistory : ProductManager
{
    private DateTime _saleDate;
    public SalesHistory(Product product, int quantity, double value, DateTime saleDate) : base(product, quantity, value)
    {
        _saleDate = saleDate;
    }

    public override string GetProductInfo()
    {
        return $"{_saleDate}: {_product} - {_quantity}";
    }
}
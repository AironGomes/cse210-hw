public class SalesHistory : ProductManager
{
    private DateTime _saleDate;
    public SalesHistory(Product product, int quantity, double value) : base(product, quantity, value)
    {}

    public override string GetProductInfo()
    {
        return "";
    }
}
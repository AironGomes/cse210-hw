public class StockProduct : ProductManager
{
    public StockProduct(Product product, int quantity, double value) : base(product, quantity, value)
    {}

    public override string GetProductInfo()
    {
        return "";
    }
}
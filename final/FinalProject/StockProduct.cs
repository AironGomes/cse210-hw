public class StockProduct : ProductManager
{
    public StockProduct(Product product, int quantity, double value) : base(product, quantity, value)
    {}

    public override void GetProductInfo()
    {
        string productInfo = _product.GetInfo();
        Console.WriteLine($"{productInfo} - ${_value} [{_quantity} unit(s) in stock]");
    }

    public bool CheckEquivalence(string sku, int quantity)
    {
        return _product.GetSku() == sku && _quantity >= quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        _quantity -= quantity;
    }
}
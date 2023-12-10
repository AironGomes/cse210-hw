public abstract class ProductManager
{
    internal Product _product;
    internal int _quantity;
    internal double _value;

    public ProductManager(Product product, int quantity, double value) 
    {
        _product = product;
        _quantity = quantity;
        _value = value;
    }

    public abstract string GetProductInfo();
}
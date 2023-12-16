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

    public abstract void GetProductInfo();
    public abstract string GetStringRepresentation();

    public int GetQuantity()
    {
        return _quantity;
    }

    public Product GetProduct(){
        return _product;
    }

    public double GetValue()
    {
        return _value;
    }
}
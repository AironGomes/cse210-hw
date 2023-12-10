public abstract class Product
{
    internal string _name;
    internal int _sku;
    internal DateTime _validation;
    internal string _brand;

    public Product(string name, int sku, DateTime validation, string brand) 
    {
        _name = name;
        _sku = sku;
        _validation = validation;
        _brand = brand;
    }

    public abstract bool NearExpiry();

    public abstract string GetInfo();
}
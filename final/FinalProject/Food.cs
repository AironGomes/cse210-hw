public class Food: Product
{
    private bool _isPerishable;

    public Food(string name, int sku, DateTime validation, string brand, bool isPerishable): base(name, sku, validation, brand) 
    {
        _isPerishable = isPerishable;
    }

    public override bool NearExpiry()
    {
        return false;
    }

    public override string GetInfo()
    {
        return "";
    }
}
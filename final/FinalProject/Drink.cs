public class Drink: Product
{
    private bool _adulthood;

    public Drink(string name, int sku, DateTime validation, string brand, bool adulthood): base(name, sku, validation, brand) 
    {
        _adulthood = adulthood;
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
public class Food: Product
{
    private bool _isPerishable;

    public Food(string name, string sku, DateTime validation, string brand, bool isPerishable): base(name, sku, validation, brand) 
    {
        _isPerishable = isPerishable;
    }

    public override bool NearExpiry()
    {
        DateTime nearExpiring = DateTime.Today.AddMonths(1);     
        return _validation <= nearExpiring;
    }

    public override string GetInfo()
    {
       return $"{_name} - {_brand}";
    }
}
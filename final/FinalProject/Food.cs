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
        string note = "";
        if(_isPerishable)
        {
            note += "[Perishable]";
        }

        if(NearExpiry())
        {
            note += "[Expiring]";
        }
        if(note.Length > 0)
        {
            return $"{_sku}: {_name} {_brand} - Note: {note}";
        }
        return $"{_sku}: {_name} {_brand}";
    }
}
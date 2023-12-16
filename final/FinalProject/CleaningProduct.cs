public class CleaningProduct: Product
{
    private bool _isDangerous;

    public CleaningProduct(string name, string sku, DateTime validation, string brand, bool isDangerous): base(name, sku, validation, brand) 
    {
        _isDangerous = isDangerous;
    }

    public override bool NearExpiry()
    {
        DateTime nearExpiring = DateTime.Today.AddMonths(6);     
        return _validation <= nearExpiring;
    }

    public override string GetInfo()
    {
        string note = "";
        if(_isDangerous)
        {
            note += "[Dangerous product]";
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
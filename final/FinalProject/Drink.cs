public class Drink: Product
{
    private bool _adulthood;

    public Drink(string name, string sku, DateTime validation, string brand, bool adulthood): base(name, sku, validation, brand) 
    {
        _adulthood = adulthood;
    }

    public override bool NearExpiry()
    {
        DateTime nearExpiring = DateTime.Today.AddMonths(3);     
        return _validation <= nearExpiring;
    }

    public override string GetInfo()
    {
        string note = "";
        if(_adulthood)
        {
            note += "[Sale for adults]";
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

    public override string GetStringRepresentation()
    {
        return $"Product:Drink;Name:{_name};Sku:{_sku};Validation:{_validation};Brand:{_brand};Adulthood:{_adulthood}";
    }
}
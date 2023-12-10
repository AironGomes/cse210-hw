public class CleaningProduct: Product
{
    private bool _isDangerous;

    public CleaningProduct(string name, int sku, DateTime validation, string brand, bool isDangerous): base(name, sku, validation, brand) 
    {
        _isDangerous = isDangerous;
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
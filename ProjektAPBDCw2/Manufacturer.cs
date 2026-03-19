namespace ProjektAPBDCw2;

public enum Manufacturer
{
    Sony,
    Panasonic,
    Acer,
    Asus
}

public static class ManufacturerExtensions
{
    public static string ToString(this Manufacturer manufacturer)
    {
        return manufacturer switch
        {
            Manufacturer.Sony => "Sony",
            Manufacturer.Panasonic => "Panasonic",
            Manufacturer.Acer => "Acer",
            Manufacturer.Asus => "Asus",
            _ => throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null)
        };
    }
}
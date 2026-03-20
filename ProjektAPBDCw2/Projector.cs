namespace ProjektAPBDCw2;

public class Projector : Device
{
    public int Brightness { get; }
    public int MaxRange { get; }
    
    public Projector(string name, Manufacturer manufacturer, int price, int brightness, int maxRange) : base(name, manufacturer, price)
    {
        Brightness = brightness;
        MaxRange = maxRange;
    }
    
    public override string ToString()
    {
        return $"Typ: Projektor, Nazwa: {Name}, Producent: {Manufacturer}, Cena: {Price}, Jasnosc (lm): {Brightness}, Maks. Zasieg: {MaxRange}";
    }
}
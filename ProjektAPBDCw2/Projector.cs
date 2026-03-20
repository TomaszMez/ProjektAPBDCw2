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

    public Projector(Projector other) : base(other)
    {
        Brightness = other.Brightness;
        MaxRange = other.MaxRange;
    }
    
    public override string ToString()
    {
        return $"ID: {Id}, Typ: Projektor, Nazwa: {Name}, Producent: {Manufacturer}, Cena (PLN): {Price}, Jasnosc (lm): {Brightness}, Maks. Zasieg: {MaxRange}"
               + ", Dostepny: " + (Available ? "Tak" : "Nie");
    }
}
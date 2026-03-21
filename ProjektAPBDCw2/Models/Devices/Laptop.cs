namespace ProjektAPBDCw2;

public class Laptop : Device
{
    public float BatteryTime { get; }
    public bool HasWebcam { get; }

    public Laptop(string name, Manufacturer manufacturer, float price, float batteryTime, bool hasWebcam) : base(name, manufacturer, price)
    {
        BatteryTime = batteryTime;
        HasWebcam = hasWebcam;
    }

    public Laptop(Laptop other) : base(other)
    {
        BatteryTime = other.BatteryTime;
        HasWebcam = other.HasWebcam;
    }

    public override Device Copy()
    {
        return (Device)(new Laptop(this));
    }

    public override string ToString()
    {
        return $"ID: {Id}, Typ: Laptop, Nazwa: {Name}, Producent: {Manufacturer}, Cena (PLN): {Price}, Czas Baterii (h): {BatteryTime}, Kamerka: " + (HasWebcam ? "Tak" : "Nie")
            + ", Dostepny: " + (Available ? "Tak" : "Nie");
    }
}
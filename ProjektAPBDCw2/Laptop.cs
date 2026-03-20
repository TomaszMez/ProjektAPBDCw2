namespace ProjektAPBDCw2;

public class Laptop : Device
{
    public float BatteryTime { get; }
    public bool HasWebcam { get; }

    public Laptop(string name, Manufacturer manufacturer, int price, float batteryTime, bool hasWebcam) : base(name, manufacturer, price)
    {
        BatteryTime = batteryTime;
        HasWebcam = hasWebcam;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Typ: Laptop, Nazwa: {Name}, Producent: {Manufacturer}, Cena (PLN): {Price}, Czas Baterii (h): {BatteryTime}, Kamerka: " + (HasWebcam ? "Tak" : "Nie")
            + ", Dostepny: " + (Available ? "Tak" : "Nie");
    }
}
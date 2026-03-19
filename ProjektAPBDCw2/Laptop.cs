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
}
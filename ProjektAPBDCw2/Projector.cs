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
}
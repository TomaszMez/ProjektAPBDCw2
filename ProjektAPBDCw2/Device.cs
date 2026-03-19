namespace ProjektAPBDCw2;

public abstract class Device
{
    private static int _idCounter = 0;
    
    public int Id { get; }
    public string Name { get; }
    public Manufacturer Manufacturer { get; }
    public int Price { get; }
    public bool Available { get; set; }
    protected Device(string name, Manufacturer manufacturer, int price) 
    {
        Id = _idCounter++;
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
        
        Available = true;
    }
}
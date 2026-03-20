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

    public static Device DeepCopyDevice(Device device)
    {
        switch (device)
        {
            case Laptop:
                Laptop tclp = (Laptop)device;
                return (Device)(new Laptop(tclp.Name, tclp.Manufacturer, tclp.Price, tclp.BatteryTime, tclp.HasWebcam));
            case Camera:
                Camera tccm = (Camera)device;
                return (Device)(new Camera(tccm.Name, tccm.Manufacturer, tccm.Price, tccm.Resolution, tccm.LensExchangeable));
            case Projector:
                Projector tcpj = (Projector)device;
                return (Device)(new Projector(tcpj.Name, tcpj.Manufacturer, tcpj.Price, tcpj.Brightness, tcpj.MaxRange));
            default:
                throw new Exception("Nieznany typ urzadzenia");
        }
    }
    
    public abstract override string ToString();
}
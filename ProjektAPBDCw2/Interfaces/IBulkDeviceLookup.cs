namespace ProjektAPBDCw2;

public interface IBulkDeviceLookup
{
    public List<Device> GetDevices();
    public List<Device> GetAvailableDevices();
    
}
namespace ProjektAPBDCw2;

public interface IBulkDeviceLookup
{
    public List<Device> GetDevicesCopy();
    public List<Device> GetAvailableDevices();
    
}
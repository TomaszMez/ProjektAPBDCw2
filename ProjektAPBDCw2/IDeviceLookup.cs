namespace ProjektAPBDCw2;

public interface IDeviceLookup
{
    public Device? GetDeviceById(int id);
    public bool DeviceExists(int id);
    public bool IsDeviceAvailable(int id);
}
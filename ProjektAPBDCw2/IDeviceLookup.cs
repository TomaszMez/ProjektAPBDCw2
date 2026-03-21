namespace ProjektAPBDCw2;

public interface IDeviceLookup
{
    public Device? GetDeviceCopyById(int id);
    public bool DeviceExists(int id);
    public bool DeviceAvailable(int id);
}
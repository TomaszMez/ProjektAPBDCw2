namespace ProjektAPBDCw2;

public interface IDeviceAvailabilityWriter
{
    public void SetDeviceAvailableById(int id, bool available);
}
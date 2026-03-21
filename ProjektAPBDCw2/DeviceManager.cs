namespace ProjektAPBDCw2;

public class DeviceManager : IDeviceLookup, IDeviceAvailabilityWriter, IBulkDeviceLookup
{
    private List<Device> devices = new List<Device>();
    
    public void AddDevice(Device device)
    {
        
        if (GetDeviceById(device.Id)!=null) throw new Exception("Juz istnieje urzadzenie o tym id");
        
        devices.Add(device);
    }

    public List<Device> GetDevicesCopy()
    {
        List<Device> result = new List<Device>();
        foreach (Device device in devices)
        {
            result.Add(device.Copy());
        }
        return result;
    }

    public List<Device> GetAvailableDevices()
    {
        List<Device> result = new List<Device>();
        foreach (Device device in devices)
        {
            if(device.Available)
                result.Add(device.Copy());
        }
        return result;
    }

    public Device? GetDeviceCopyById(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id) return device.Copy();
        }
        return null;
    }

    private Device? GetDeviceById(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id) return device;
        }
        return null;
    }

    public bool DeviceExists(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id) return true;
        }
        return false;
    }

    public bool DeviceAvailable(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id) return device.Available;
        }
        return false;
    }
    
    public void RemoveDeviceById(int id)
    {
        for (int i = 0; i < devices.Count; i++)
        {
            if (devices[i].Id == id)
            {
                devices.RemoveAt(i);
                return;
            }
        }
    }
    
    public void SetDeviceAvailableById(int id, bool available)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id)
            {
                device.Available =available;
                return;
            }
        }
    }
    
}
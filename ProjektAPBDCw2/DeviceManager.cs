namespace ProjektAPBDCw2;

public class DeviceManager : IDeviceLookup, IDeviceAvailabilityWriter, IBulkDeviceLookup
{
    private List<Device> _devices = new List<Device>();
    
    public void AddDevice(Device device)
    {
        
        if (GetDeviceRefById(device.Id)!=null) throw new Exception("Juz istnieje urzadzenie o tym id");
        
        _devices.Add(device);
    }

    public List<Device> GetDevices()
    {
        List<Device> result = new List<Device>();
        foreach (Device device in _devices)
        {
            result.Add(device.Copy());
        }
        return result;
    }

    public List<Device> GetAvailableDevices()
    {
        List<Device> result = new List<Device>();
        foreach (Device device in _devices)
        {
            if(device.Available)
                result.Add(device.Copy());
        }
        return result;
    }

    public Device? GetDeviceById(int id)
    {
        foreach (Device device in _devices)
        {
            if (device.Id == id) return device.Copy();
        }
        return null;
    }

    private Device? GetDeviceRefById(int id)
    {
        foreach (Device device in _devices)
        {
            if (device.Id == id) return device;
        }
        return null;
    }

    public bool DeviceExists(int id)
    {
        foreach (Device device in _devices)
        {
            if (device.Id == id) return true;
        }
        return false;
    }

    public bool IsDeviceAvailable(int id)
    {
        foreach (Device device in _devices)
        {
            if (device.Id == id) return device.Available;
        }
        return false;
    }
    
    public void RemoveDeviceById(int id)
    {
        for (int i = 0; i < _devices.Count; i++)
        {
            if (_devices[i].Id == id)
            {
                _devices.RemoveAt(i);
                return;
            }
        }
    }
    
    public void SetDeviceAvailableById(int id, bool available)
    {
        foreach (Device device in _devices)
        {
            if (device.Id == id)
            {
                device.Available =available;
                return;
            }
        }
    }
    
}
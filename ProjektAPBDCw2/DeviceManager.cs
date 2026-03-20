namespace ProjektAPBDCw2;


public static class DeviceManager
{
    public static List<Device> devices = new List<Device>();

    public static Device StringToDevice(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        
        int m = -1;
        foreach (Manufacturer manufacturer in Enum.GetValues(typeof(Manufacturer)))
        {
            if (fields[2].Equals(manufacturer.ToString()))
            {
                m = (int) manufacturer;
            }
        }
        if (m == -1) throw new Exception("Invalid input");
        
        switch  (fields[0])
        {
            case "Laptop":
                if (fields.Length != 6) throw new Exception("Invalid input");
                return new Laptop(fields[1], (Manufacturer) m, int.Parse(fields[3]), float.Parse(fields[4]), bool.Parse(fields[5]));
            case "Camera":
                if (fields.Length != 6) throw new Exception("Invalid input");
                return new Camera(fields[1], (Manufacturer) m, int.Parse(fields[3]), int.Parse(fields[4]), bool.Parse(fields[5]));
            case "Projector":
                if (fields.Length != 6) throw new Exception("Invalid input");
                return new Projector(fields[1], (Manufacturer) m, int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
            default:
                throw new Exception("Invalid input");
        }
    }
    
    public static void AddDevice(Device device)
    {
        try
        {
            GetDeviceById(device.Id);
        } catch (Exception e)
        {
            devices.Add(device);
        }
        throw new Exception("Juz istnieje urzadzenie o tym id");
    }

    public static List<Device> GetDevicesCopy()
    {
        List<Device> result = new List<Device>();
        foreach (Device device in devices)
        {
            result.Add(Device.DeepCopyDevice(device));
        }
        return result;
    }

    public static Device GetDeviceById(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id) return Device.DeepCopyDevice(device);
        }
        throw new Exception("Device not found");
    }
    
    public static void RemoveDeviceById(int id)
    {
        foreach (Device device in devices)
        {
            if (device.Id == id)
            {
                devices.Remove(device);
                return;
            }
        }
    }
    
}
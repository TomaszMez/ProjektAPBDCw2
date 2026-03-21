namespace ProjektAPBDCw2;

public static class InputParser
{
    public static User StringToUser(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        if (fields.Length != 3) throw new Exception("Za malo danych");

        int ut = -1;
        foreach (UserType type in Enum.GetValues(typeof(UserType)))
        {
            if (fields[2].Equals(type.ToString()))
            {
                ut = (int) type;
            }
        }
        if (ut == -1) throw new Exception("Nie istnieje taki typ uzytkownika");
        return new User(fields[0], fields[1], (UserType) ut);
    }
    
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
        if (m == -1) throw new Exception("Nie istnieje taki producent");
        
        switch  (fields[0])
        {
            case "Laptop":
                if (fields.Length != 6) throw new Exception("Za malo danych");
                return new Laptop(fields[1], (Manufacturer) m, int.Parse(fields[3]), float.Parse(fields[4]), bool.Parse(fields[5]));
            case "Camera":
                if (fields.Length != 6) throw new Exception("Za malo danych");
                return new Camera(fields[1], (Manufacturer) m, int.Parse(fields[3]), int.Parse(fields[4]), bool.Parse(fields[5]));
            case "Projector":
                if (fields.Length != 6) throw new Exception("Za malo danych");
                return new Projector(fields[1], (Manufacturer) m, int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
            default:
                throw new Exception("Nieznany typ urzadzenia");
        }
    }
    
    public static Rental StringToRental(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        if (fields.Length != 4) throw new Exception("Za malo danych");
        
        return new Rental(int.Parse(fields[0]), int.Parse(fields[1]), DateTime.Parse(fields[2]), DateTime.Parse(fields[3]));
    }
    
}
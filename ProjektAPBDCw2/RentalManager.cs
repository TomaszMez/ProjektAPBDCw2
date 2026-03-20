namespace ProjektAPBDCw2;

public static class RentalManager
{
    private static List<Rental> rentals = new List<Rental>();

    public static Rental StringToRental(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        if (fields.Length != 4) throw new Exception("Invalid input");

        try
        {
            UserManager.GetUserById(int.Parse(fields[0]));
            //DeviceManager.GetDeviceById(int.Parse(fields[1]));
        }
        catch (Exception e)
        {
            throw new Exception("Invalid input");
        }
        
        if (DateTime.Parse(fields[2]) <= DateTime.Parse(fields[3])) throw new Exception("Invalid input");
        
        return new Rental(int.Parse(fields[0]), int.Parse(fields[1]), DateTime.Parse(fields[2]), DateTime.Parse(fields[3]));
    }

    public static List<Rental> GetRentalsCopy()
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            result.Add(new Rental(rental));
        }
        return result;
    }

    public static List<Rental> GetRentalsCopyByUserId(int id)
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            if (rental.UserId == id)
            {
                result.Add(new Rental(rental));
            }
        }
        return result;
    }
    
    public static List<Rental> GetRentalsCopyByDeviceId(int id)
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            if (rental.DeviceId == id)
            {
                result.Add(new Rental(rental));
            }
        }
        return result;
    }

    public static Rental GetExactRentalCopy(int userId, int deviceId)
    {
        foreach (Rental rental in rentals)
        {
            if (rental.UserId == userId && rental.DeviceId == deviceId)
            {
                return new Rental(rental);
            }
        }
        throw new Exception("Rental not found");
    }

    public static List<Rental> GetExpiredRentalsCopy()
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            if (rental.AgreedReturnDate < DateTime.Now)
            {
                result.Add(new Rental(rental));
            }
        }
        return result;
    }
    
}
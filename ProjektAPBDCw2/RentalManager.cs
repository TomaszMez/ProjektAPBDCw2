namespace ProjektAPBDCw2;

public static class RentalManager
{
    public static List<Rental> Rentals { get; } = new List<Rental>();

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

    public static List<Rental> GetRentalsByUserId(int id)
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in Rentals)
        {
            if (rental.UserId == id)
            {
                result.Add(rental);
            }
        }
        return result;
    }
    
    public static List<Rental> GetRentalsByDeviceId(int id)
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in Rentals)
        {
            if (rental.DeviceId == id)
            {
                result.Add(rental);
            }
        }
        return result;
    }

    public static Rental GetExactRental(int userId, int deviceId)
    {
        foreach (Rental rental in Rentals)
        {
            if (rental.UserId == userId && rental.DeviceId == deviceId)
            {
                return rental;
            }
        }
        throw new Exception("Rental not found");
    }

    public static List<Rental> GetExpiredRentals()
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in Rentals)
        {
            if (rental.AgreedReturnDate < DateTime.Now)
            {
                result.Add(rental);
            }
        }
        return result;
    }
    
}
namespace ProjektAPBDCw2;

public static class RentalManager
{
    private static List<Rental> rentals = new List<Rental>();

    public static Rental StringToRental(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        if (fields.Length != 4) throw new Exception("Invalid input");
        
        return new Rental(int.Parse(fields[0]), int.Parse(fields[1]), DateTime.Parse(fields[2]), DateTime.Parse(fields[3]));
    }

    public static void AddRental(Rental rental)
    {
        if (!IsRentalValid(rental)) throw new Exception("Niewlasciwe wypozyczenie");
            
        rentals.Add(rental);
        DeviceManager.SetDeviceAvailableById(rental.DeviceId, false);
    }

    public static void EndRental(int userId, int deviceId)
    {
        Rental? rental = GetExactRental(userId, deviceId);
        if (rental == null) throw new Exception("Nie ma takiego wypozyczenia");
        else if (rental.ActualReturnDate != null) throw new Exception("To wypozyczenie juz sie zakonczylo");
        
        rental.ReturnDevice();
        DeviceManager.SetDeviceAvailableById(rental.DeviceId, true);
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

    public static Rental? GetExactRentalCopy(int userId, int deviceId)
    {
        foreach (Rental rental in rentals)
        {
            if (rental.UserId == userId && rental.DeviceId == deviceId)
            {
                return new Rental(rental);
            }
        }

        return null;
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
    
    private static Rental? GetExactRental(int userId, int deviceId)
    {
        foreach (Rental rental in rentals)
        {
            if (rental.UserId == userId && rental.DeviceId == deviceId)
            {
                return rental;
            }
        }

        return null;
    }

    private static bool IsRentalValid(Rental rental)
    {
        try
        {
            User? vu = UserManager.GetUserById(rental.UserId);
            Device? vd = DeviceManager.GetDeviceById(rental.DeviceId);
            
            if (vu == null || vd == null || !vd.Available) return false;
        }
        catch (Exception e)
        {
            return false;
        }
        
        foreach (Rental existing in rentals)
        {
            if (existing.UserId == rental.UserId && existing.DeviceId == rental.DeviceId) return false;
        }

        User user = UserManager.GetUserById(rental.UserId);
        if (user == null) return false;
        
        switch (user.UserType)
        {
            case UserType.Student:
                if (GetRentalsCopyByUserId(rental.UserId).Count >= 2)
                    return false;
                break;
            case UserType.Employee:
                if (GetRentalsCopyByUserId(rental.UserId).Count >= 5)
                    return false;
                break;
        }

        return true;
    }
    
}
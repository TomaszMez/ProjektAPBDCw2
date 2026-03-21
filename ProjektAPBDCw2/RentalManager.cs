namespace ProjektAPBDCw2;

public class RentalManager
{
    private List<Rental> rentals = new List<Rental>();
    
    private IUserLookup _userLookup;
    private IDeviceLookup _deviceLookup;
    private IDeviceAvailabilityWriter _deviceAvailabilityWriter;

    public RentalManager(IUserLookup userLookup, IDeviceLookup deviceLookup, IDeviceAvailabilityWriter deviceAvailabilityWriter)
    {
        this._userLookup = userLookup;
        this._deviceLookup = deviceLookup;
        this._deviceAvailabilityWriter = deviceAvailabilityWriter;
    }

    public void AddRental(Rental rental)
    {
        if (!IsRentalValid(rental)) throw new Exception("Niewlasciwe wypozyczenie");
            
        rentals.Add(rental);
        _deviceAvailabilityWriter.SetDeviceAvailableById(rental.DeviceId, false);
    }

    public void EndRental(int userId, int deviceId)
    {
        Rental? rental = GetRentalRef(userId, deviceId);
        if (rental == null) throw new Exception("Nie ma takiego wypozyczenia");
        else if (rental.ActualReturnDate != null) throw new Exception("To wypozyczenie juz sie zakonczylo");
        
        rental.ReturnDevice();
        _deviceAvailabilityWriter.SetDeviceAvailableById(rental.DeviceId, true);
    }

    public List<Rental> GetRentals()
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            result.Add(new Rental(rental));
        }
        return result;
    }
    
    public List<Rental> GetActiveRentalsByUserId(int userId)
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            if(rental.UserId == userId && rental.ActualReturnDate == null) 
                result.Add(new Rental(rental));
        }
        return result;
    }

    public List<Rental> GetRentalsByUserId(int id)
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
    
    public List<Rental> GetRentalsByDeviceId(int id)
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

    public Rental? GetRental(int userId, int deviceId)
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
    
    private Rental? GetRentalRef(int userId, int deviceId)
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

    public List<Rental> GetExpiredRentals()
    {
        List<Rental> result = new List<Rental>();
        foreach (Rental rental in rentals)
        {
            if (rental.ActualReturnDate == null && rental.AgreedReturnDate < DateTime.Now)
            {
                result.Add(new Rental(rental));
            }
        }
        return result;
    }

    private bool IsRentalValid(Rental rental)
    {
        if (!_userLookup.UserExists(rental.UserId) || !_deviceLookup.DeviceExists(rental.DeviceId) || !_deviceLookup.IsDeviceAvailable(rental.DeviceId)) return false;
        
        switch (_userLookup.GetUserById(rental.UserId).UserType)
        {
            case UserType.Student:
                if (GetActiveRentalsByUserId(rental.UserId).Count >= 2)
                    return false;
                break;
            case UserType.Employee:
                if (GetActiveRentalsByUserId(rental.UserId).Count >= 5)
                    return false;
                break;
        }

        return true;
    }
    
}
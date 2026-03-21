using System.Text;

namespace ProjektAPBDCw2;

public class RentalReporter
{
    private IBulkDeviceLookup _devices;
    private IBulkUserLookup _users;
    private RentalManager _rentals;

    public RentalReporter(IBulkUserLookup users, IBulkDeviceLookup devices, RentalManager rentals)
    {
        _users = users;
        _devices = devices;
        _rentals = rentals;
    }

    public string GenerateReport()
    {
        StringBuilder sb = new StringBuilder();
        int dcnt = _devices.GetDevices().Count;
        int adcnt = _devices.GetAvailableDevices().Count;
        int ucnt = _users.GetUsers().Count;
        int rcnt = _rentals.GetRentals().Count;
        int ercnt = _rentals.GetExpiredRentals().Count;

        sb.AppendLine($"Zarejestrowanych uzytkownikow: {ucnt}");
        sb.AppendLine($"Zarejestrowanych urzadzen: {dcnt}");
        sb.AppendLine($"Dostepnych urzadzen: {adcnt}");
        sb.AppendLine($"Wszystkich wypozyczen: {rcnt}");
        sb.AppendLine($"Przeterminowanych wypozyczen: {ercnt}");
        
        return sb.ToString();
    }
}
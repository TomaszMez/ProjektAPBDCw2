using System.Text;

namespace ProjektAPBDCw2;

public class RentalReporter
{
    private IBulkDeviceLookup _devices;
    private IBulkUserLookup _users;
    private RentalManager _rentals;

    public RentalReporter(IBulkDeviceLookup devices, IBulkUserLookup users, RentalManager rentals)
    {
        _devices = devices;
        _users = users;
        _rentals = rentals;
    }

    public string GenerateReport()
    {
        StringBuilder sb = new StringBuilder();
        int dcnt = _devices.GetDevicesCopy().Count;
        int adcnt = _devices.GetAvailableDevices().Count;
        int ucnt = _users.GetUsersCopy().Count;
        int rcnt = _rentals.GetRentalsCopy().Count;
        int ercnt = _rentals.GetExpiredRentalsCopy().Count;

        sb.AppendLine($"Zarejestrowanych uzytkownikow: {ucnt}");
        sb.AppendLine($"Zarejestrowanych urzadzen: {dcnt}");
        sb.AppendLine($"Dostepnych urzadzen: {adcnt}");
        sb.AppendLine($"Wszystkich wypozyczen: {rcnt}");
        sb.AppendLine($"Przeterminowanych wypozyczen: {ercnt}");
        
        return sb.ToString();
    }
}
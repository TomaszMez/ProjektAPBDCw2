namespace ProjektAPBDCw2;

public interface IBulkRentalLookup
{
    public List<Rental> GetRentals();
    public List<Rental> GetExpiredRentals();
}
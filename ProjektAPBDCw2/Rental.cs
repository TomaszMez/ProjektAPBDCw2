namespace ProjektAPBDCw2;

public class Rental
{
    public int UserId { get; }
    public int DeviceId { get; }
    public DateTime RentalDate { get; }
    public DateTime AgreedReturnDate { get; }
    public DateTime? ActualReturnDate { get; private set; }
    public bool? IsOnTime { get; private set; }
    public int? Penalty { get; private set; }

    public Rental(int userId, int devideId, DateTime rentalDate, DateTime agreedReturnDate)
    {
        UserId = userId;
        DeviceId = devideId;
        RentalDate = rentalDate;
        AgreedReturnDate = agreedReturnDate;
    }

    public void ReturnDevice()
    {
        ActualReturnDate = DateTime.Now;
        if (ActualReturnDate > AgreedReturnDate)
        {
            IsOnTime = false;
            TimeSpan? diff = ActualReturnDate-AgreedReturnDate;
            Penalty = diff.Value.Days*100;
            
        }
        else IsOnTime = true;
    }
    
}
namespace ProjektAPBDCw2;

public interface IUserLookup
{
    public User? GetUserCopyById(int id);
    public bool UserExists(int id);
}
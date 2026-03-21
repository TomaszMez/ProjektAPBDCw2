namespace ProjektAPBDCw2;

public interface IUserLookup
{
    public User? GetUserById(int id);
    public bool UserExists(int id);
}
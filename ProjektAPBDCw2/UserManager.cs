namespace ProjektAPBDCw2;

public class UserManager : IUserLookup,  IBulkUserLookup
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        if (GetUserById(user.Id)!=null) throw new Exception("Juz istnieje uzytkownik o tym id");
        
        users.Add(user);
    }

    public List<User> GetUsersCopy()
    {
        List<User> result = new List<User>();
        foreach (User user in users)
        {
            result.Add(new User(user));
        }
        return result;
    }
    
    public User? GetUserCopyById(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return new User(user);
        }

        return null;
    }
    
    private User? GetUserById(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return user;
        }

        return null;
    }
    
    public bool UserExists(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return true;
        }
        return false;
    }
    
    public void RemoveUserById(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Id == id)
            {
                users.RemoveAt(i);
                return;
            }
        }
    }
    
}
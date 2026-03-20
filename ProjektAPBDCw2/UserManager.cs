namespace ProjektAPBDCw2;

public static class UserManager
{
    private static List<User> users = new List<User>();

    public static User StringToUser(String inputStr)
    {
        string[] fields = inputStr.Split(' ');
        if (fields.Length != 3) throw new Exception("Invalid input");

        int ut = -1;
        foreach (UserType type in Enum.GetValues(typeof(UserType)))
        {
            if (fields[2].Equals(type.ToString()))
            {
                ut = (int) type;
            }
        }
        if (ut == -1) throw new Exception("Invalid input");
        return new User(fields[0], fields[1], (UserType) ut);
    }

    public static void AddUser(User user)
    {
        if (GetUserById(user.Id)!=null) throw new Exception("Juz istnieje uzytkownik o tym id");
        
        users.Add(user);
    }

    public static List<User> GetUsersCopy()
    {
        List<User> result = new List<User>();
        foreach (User user in users)
        {
            result.Add(new User(user));
        }
        return result;
    }
    
    public static User? GetUserCopyById(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return new User(user);
        }

        return null;
    }
    
    private static User? GetUserById(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return user;
        }

        return null;
    }
    
    public static bool UserExists(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id) return true;
        }
        return false;
    }
    
    public static void RemoveUserById(int id)
    {
        foreach (User user in users)
        {
            if (user.Id == id)
            {
                users.Remove(user);
                return;
            }
        }
    }
    
}
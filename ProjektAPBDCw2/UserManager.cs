namespace ProjektAPBDCw2;

public static class UserManager
{
    public static List<User> Users { get; } = new List<User>();

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

    public static User GetUserById(int id)
    {
        foreach (User user in Users)
        {
            if (user.Id == id) return user;
        }
        throw new Exception("User not found");
    }
    
    public static void RemoveUserById(int id)
    {
        foreach (User user in Users)
        {
            if (user.Id == id)
            {
                Users.Remove(user);
                return;
            }
        }
    }
    
}
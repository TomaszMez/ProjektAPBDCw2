namespace ProjektAPBDCw2;

public class User
{
    private static int _idCounter = 0;
    
    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public UserType UserType { get; }

    public User(string name, string surname, UserType userType)
    {
        Id = _idCounter++;
        Name = name;
        Surname = surname;
        UserType = userType;
    }

    public User(User other)
    {
        Id = other.Id;
        Name = other.Name;
        Surname = other.Surname;
        UserType = other.UserType;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Imie: {Name}, Nazwisko: {Surname}, Typ: {UserType}";
    }
}
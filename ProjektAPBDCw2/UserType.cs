namespace ProjektAPBDCw2;

public enum UserType
{
    Student,
    Employee
}

public static class UserTypeExtensions
{
    public static string ToString(this UserType userType)
    {
        return userType switch
        {
            UserType.Student => "Student",
            UserType.Employee => "Pracownik",
            _ => throw new ArgumentOutOfRangeException(nameof(userType), userType, null)
        };
    }
}
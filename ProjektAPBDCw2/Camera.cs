namespace ProjektAPBDCw2;

public class Camera : Device
{
    public int Resolution { get; }
    public bool LensExchangeable { get; }
    
    public Camera(string name, Manufacturer manufacturer, int price, int resolution, bool lensExchangeable) : base(name, manufacturer, price)
    {
        Resolution = resolution;
        LensExchangeable = lensExchangeable;
    }

    public Camera(Camera other) : base(other)
    {
        Resolution = other.Resolution;
        LensExchangeable = other.LensExchangeable;
    }
    
    public override string ToString()
    {
        return $"ID: {Id}, Typ: Aparat, Nazwa: {Name}, Producent: {Manufacturer}, Cena (PLN): {Price}, Rozdzielczosc (mp): {Resolution}, Wymienny obiektyw: " + (LensExchangeable ? "Tak" : "Nie")
            + ", Dostepny: " + (Available ? "Tak" : "Nie");
    }
}
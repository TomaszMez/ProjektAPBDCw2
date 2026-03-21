using ProjektAPBDCw2;

DeviceManager dm = new DeviceManager();
UserManager um = new UserManager();
RentalManager rm = new RentalManager(um, dm, dm);
RentalReporter rr = new RentalReporter(um, dm, rm);

dm.AddDevice(InputParser.StringToDevice("Laptop Lap1 Asus 2500 10 false"));
dm.AddDevice(InputParser.StringToDevice("Camera Cam1 Panasonic 1500 20 false"));
dm.AddDevice(InputParser.StringToDevice("Projector Pro1 Sony 2200 2800 3"));
dm.AddDevice(InputParser.StringToDevice("Laptop Lap2 Acer 5000 12 true"));
dm.AddDevice(InputParser.StringToDevice("Camera Cam2 Sony 4599,99 25 true"));

Console.WriteLine(string.Join("\r\n", dm.GetDevices()));

um.AddUser(InputParser.StringToUser("Tytus Bomba Employee"));
um.AddUser(InputParser.StringToUser("Ryszard Kabura Employee"));
um.AddUser(InputParser.StringToUser("Marcin Lopian Student"));

Console.WriteLine(string.Join("\r\n", um.GetUsers()));

rm.AddRental(InputParser.StringToRental("2 0 20/03/2026 20/04/2026"));
rm.AddRental(InputParser.StringToRental("2 1 20/03/2026 20/04/2026"));
//Proba przekroczenia limitu
try
{
    rm.AddRental(InputParser.StringToRental("2 2 20/03/2026 20/04/2026"));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
rm.AddRental(InputParser.StringToRental("1 2 20/03/2026 20/04/2026"));
rm.AddRental(InputParser.StringToRental("1 3 20/01/2026 20/02/2026"));
rm.AddRental(InputParser.StringToRental("1 4 20/01/2026 20/02/2026"));

rm.EndRental(2,0);
rm.EndRental(2,1);
rm.AddRental(InputParser.StringToRental("2 1 20/03/2026 20/05/2026"));
rm.EndRental(1,4);
Console.WriteLine(string.Join("\r\n", rm.GetRentals()));

Console.WriteLine(rr.GenerateReport());


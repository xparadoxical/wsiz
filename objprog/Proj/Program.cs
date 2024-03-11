using Proj;

internal class Program
{
    internal static Parking parking;

    [STAThread]
    private static void Main(string[] args)
#if RELEASE
    {
        try
        {
            Cli.MainLoop();
        }
        catch (Exception e)
        {
            Console.WriteLine();
            Console.WriteLine($"Wystąpił nieoczekiwany błąd. Zgłoś jego wystąpienie do autora programu.\n{e}");
            Console.ReadKey(true);
        }
    }
#else
    {
        var p = parking = new Parking(5, 6);
        p.AddSlot(VehicleTraits.Family, 1);
        p.AddSlot(VehicleTraits.Disabilities, 1);
        p.AddSlot(VehicleTraits.KissAndRide, 1);
        p.AddSlot(VehicleTraits.None, 7);

        p.AddSlot(VehicleTraits.None);
        p.AddSlot(VehicleTraits.ReservedForServices, 2);
        p.AddSlot(VehicleTraits.None, 2);
        p.AddSlot(VehicleTraits.None);
        p.AddSlot(VehicleTraits.ReservedForServices, 2);
        p.AddSlot(VehicleTraits.None, 2);

        p.AddSlot(VehicleTraits.EmissionFree, 5);

        var v1 = new Bike("1");
        p.Park(v1, 3, 1);
        var v2 = new Bus("asd", VehicleTraits.ReservedForServices);
        p.Park(v2);
        var v3 = new Car("AB1234", VehicleTraits.EmissionFree);
        p.Park(v3);

        Cli.DisplayParking();
        Console.WriteLine("before");
        Thread.Sleep(200);
        p.Unpark(v2);

        DataManager.SerializeToXmlFile(ParkingDto.FromParking(parking), "./test.xml");

        parking = DataManager.DeserializeFromXmlFile("./test.xml").ToParking();

        Cli.DisplayParking();
        Console.WriteLine("after");
    }
#endif
}
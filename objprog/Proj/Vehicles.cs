namespace Proj;

public class Motorcycle(string id, VehicleTraits traits) : Vehicle(id, Width, Height, traits), IVehicleSize
{
    public static int Width => 1;
    public static int Height => 1;
}
public class Car(string id, VehicleTraits traits) : Vehicle(id, Width, Height, traits), IVehicleSize
{
    public static int Width => 2;
    public static int Height => 1;
}
public class Bus(string id, VehicleTraits traits) : Vehicle(id, Width, Height, traits), IVehicleSize
{
    public static int Width => 2;
    public static int Height => 2;
}
public class Truck(string id, VehicleTraits traits) : Vehicle(id, Width, Height, traits), IVehicleSize
{
    public static int Width => 4;
    public static int Height => 2;
}
public class Bike(string id) : Vehicle(id, Width, Height, VehicleTraits.None), IVehicleSize
{
    public static int Width => 1;
    public static int Height => 1;
}

public interface IVehicleSize
{
    static abstract int Width { get; }
    static abstract int Height { get; }
}

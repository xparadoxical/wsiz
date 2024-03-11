using System.Collections.Immutable;

namespace Parking;
public abstract class Vehicle
{
    protected Vehicle(string id, int width, int height, VehicleTraits traits)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

        ID = id;
        Width = width;
        Height = height;
        Traits = traits;
    }

    public string ID { get; }
    public int Width { get; }
    public int Height { get; }
    public VehicleTraits Traits { get; }
    public ImmutableArray<Slot>? OccupiedSlots { get; set; }

    internal static IReadOnlyList<(Type type, string display)> typeInfo = [
            (typeof(Car), "Samochód"),
            (typeof(Bike), "Rower"),
            (typeof(Motorcycle), "Motocykl"),
            (typeof(Bus), "Autobus"),
            (typeof(Truck), "Ciężarówka")
        ];

    public static string GetDisplayName(Type t) => typeInfo.Single(i => i.type == t).display;

    internal static Vehicle MakeVehicle(Type vehicleType, string id, VehicleTraits? traits = null)
    {
        var bike = vehicleType == typeof(Bike);

        return (Vehicle)vehicleType!.GetConstructor(bike ? [typeof(string)] : [typeof(string), typeof(VehicleTraits)])!
            .Invoke(bike ? [id] : [id, traits]);
    }
}

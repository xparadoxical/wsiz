using System.Xml.Serialization;

namespace Parking.Serialization;

[Serializable, XmlType("Parking")]
public sealed class ParkingDto(int width, int height, int maxVehicleHeight)
{
    private ParkingDto() : this(default, default, default) { }

    [XmlAttribute]
    public int Width { get; set; } = width;
    [XmlAttribute]
    public int Height { get; set; } = height;
    [XmlAttribute]
    public int MaxVehicleHeight { get; set; } = maxVehicleHeight;

    public List<SlotDto> Slots { get; set; } = null!;
    public List<ParkedVehicleDto> ParkedVehicles { get; set; } = null!;
    public List<ParkingEventDto> Events { get; set; } = null!;

    public static ParkingDto FromParking(Parking p)
    {
        var dto = new ParkingDto(p.Width, p.Height, p.MaxVehicleHeight)
        {
            Slots = new(100),
            ParkedVehicles = new(100),
            Events = new(100)
        };

        for (int y = 0; y < p.Height; y++)
        {
            for (int x = 0; x < p.Width; x++)
            {
                var slot = p[x, y];
                if (slot is not null)
                    dto.Slots.Add(new(x, y, slot.Type));
            }
        }

        foreach (var veh in p.GetVehicles())
        {
            var (x, y) = p.GetVehiclePosition(veh)!.Value;
            dto.ParkedVehicles.Add(new(x, y, veh.GetType().Name, veh.ID, veh.Traits));
        }

        foreach (var e in p.Events)
            dto.Events.Add(new(e.Time, e.VehicleID, e.Position.x, e.Position.y, e.VehicleType.Name, e.Parked, e.TotalTime ?? nullTimeSpan));

        return dto;
    }

    private static readonly TimeSpan nullTimeSpan = TimeSpan.FromSeconds(-1);

    public Parking ToParking()
    {
        var p = new Parking(Width, Height) { MaxVehicleHeight = MaxVehicleHeight };

        foreach (var slot in Slots)
            p[slot.X, slot.Y] = new(slot.Traits);

        foreach (var parked in ParkedVehicles)
        {
            var vehicleType = Vehicle.typeInfo.Single(i => i.type.Name == parked.Type).type;
            var bike = vehicleType == typeof(Bike);

            var veh = Vehicle.MakeVehicle(vehicleType, parked.ID, parked.Traits);

            p.Park(veh, parked.X, parked.Y);
        }

        p.Events.Clear();
        p.Events.EnsureCapacity(Events.Count);
        foreach (var e in Events)
        {
            p.Events.Add(new(
                e.Time,
                e.VehicleID,
                (e.X, e.Y),
                Vehicle.typeInfo.Single(i => i.type.Name == e.VehicleType).type,
                e.Parked,
                e.TotalTime == nullTimeSpan ? null : e.TotalTime));
        }

        return p;
    }
}

[XmlType("Slot")]
public sealed record SlotDto(
    [property: XmlAttribute] int X,
    [property: XmlAttribute] int Y,
    [property: XmlAttribute] VehicleTraits Traits)
{ private SlotDto() : this(default, default, default) { } }

[XmlType("Vehicle")]
public sealed record ParkedVehicleDto(
    [property: XmlAttribute] int X,
    [property: XmlAttribute] int Y,
    [property: XmlAttribute] string Type,
    [property: XmlAttribute] string ID,
    [property: XmlAttribute] VehicleTraits Traits)
{ private ParkedVehicleDto() : this(default, default, default, default, default) { } }

[XmlType("Event")]
public sealed record ParkingEventDto(
    [property: XmlAttribute] DateTime Time,
    [property: XmlAttribute] string VehicleID,
    [property: XmlAttribute] int X,
    [property: XmlAttribute] int Y,
    [property: XmlAttribute] string VehicleType,
    [property: XmlAttribute] bool Parked,
    [property: XmlAttribute] TimeSpan TotalTime)
{ private ParkingEventDto() : this(default, default, default, default, default, default, default) { } }

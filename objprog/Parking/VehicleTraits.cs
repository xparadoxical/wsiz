namespace Parking;

using static VehicleTraits;
[Flags]
public enum VehicleTraits
{
    None = 0,
    EmissionFree = 1 << 0,
    ReservedForServices = 1 << 1,
    Family = 1 << 2,
    Disabilities = 1 << 3,
    KissAndRide = 1 << 4
}

public static class VehicleTraitsExtensions
{
    public static string GetDisplayName(this VehicleTraits t)
    {
        return t switch
        {
            None => "Zwykłe",
            EmissionFree => "Tylko dla pojazdów bezemisyjnych",
            ReservedForServices => "Tylko dla służb",
            Family => "Tylko dla rodzin z dzieckiem",
            Disabilities => "Tylko dla osób niepełnosprawnych",
            KissAndRide => "Służące do krótkiego postoju w celu przesiadki",
            _ => throw new NotImplementedException(t.ToString())
        };
    }
}
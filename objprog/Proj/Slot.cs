using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Proj;

[DebuggerDisplay("Type={Type} IsOccupied={IsOccupied}")]
public sealed class Slot(VehicleTraits type, Vehicle? vehicle = null)
{
    public VehicleTraits Type { get; set; } = type;
    public Vehicle? Vehicle { get; set; } = vehicle;

    [MemberNotNullWhen(true, nameof(Vehicle))]
    public bool IsOccupied => Vehicle is not null;

    public bool CanPark(Vehicle vehicle)
        => (vehicle.Traits & Type) == Type;
}

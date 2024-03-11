using System.Collections.Immutable;

namespace Parking;

public sealed class Parking
{
    /// <summary>[y,x] because the actual order of dimensions is [..,3,2,1]</summary>
    private readonly Slot?[,] slots;

    public Parking(int width, int height)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

        slots = new Slot?[height, width];
        Width = width;
        Height = height;
        Lanes = (height + 1) / MaxVehicleHeight - 1;
        Events = new();
    }

    public int Width { get; }
    public int Height { get; }
    public int MaxVehicleHeight { get; init; } = 2;
    public int Lanes { get; }

    public record ParkingEvent(DateTime Time, string VehicleID, (int x, int y) Position, Type VehicleType, bool Parked, TimeSpan? TotalTime);
    public List<ParkingEvent> Events { get; }

    internal const int AlphabetLength = 'z' - 'a' + 1;

    public IEnumerable<Vehicle> GetVehicles()
        => GetSlots().Where(s => s.IsOccupied).Select(s => s.Vehicle!).Distinct();

    public IEnumerable<Slot> GetSlots() => slots.Cast<Slot>().Where(s => s is not null);

    public Slot? this[int x, int y]
    {
        get => slots[y, x];
        set => slots[y, x] = value;
    }

    public (int x, int y)? GetVehiclePosition(Vehicle toFind)
    {
        var found = GetSlots().Select((s, i) => (s, i)).FirstOrDefault(si => si.s.Vehicle == toFind);
        if (found.s is null)
            return null;
        else
            return (found.i % Width, found.i / Width);
    }

    /// <summary>
    /// Adds the specified <paramref name="count"/> of <see cref="Slot"/>s of a <paramref name="type"/>.
    /// The operation does not take place if there was an exception thrown.</summary>
    /// <exception cref="InvalidOperationException">There is not enough space to add the specified slots. Data: <c>remaining</c></exception>
    public void AddSlot(VehicleTraits type, int count = 1, int startX = 0, int startY = 0)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentOutOfRangeException.ThrowIfNegative(startX);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startX, Width);
        ArgumentOutOfRangeException.ThrowIfNegative(startY);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startY, Height);

        if (count == 0)
            return;

        int added = 0;

        //var rowGroups = (int)double.Ceiling((double)Height / MaxVehicleHeight);
        //for (int rowGroup = 0; rowGroup < rowGroups; rowGroup++)
        //{
        //var baseY = rowGroup * MaxVehicleHeight;
        var searchFullRow = false;
        var newSlots = new List<((int x, int y), Slot)>(count);
        for (int y = startY; y < Height; y++)
        {
            for (var x = searchFullRow ? 0 : startX; x < Width; x++)
            {
                if (slots[y, x] is null)
                {
                    newSlots.Add(((x, y), new Slot(type)));
                    added++;

                    if (added == count)
                    {
                        foreach (var (pos, slot) in newSlots)
                            slots[pos.y, pos.x] = slot;
                        return;
                    }
                }
            }

            searchFullRow = true;
        }
        //}

        throw new InvalidOperationException($"Not enough space to add the remaining {count - added} slots.")
        {
            Data = { ["remaining"] = count - added }
        };
    }

    /// <summary>Parks <paramref name="vehicle"/> on the next slot available for it.</summary>
    public void Park(Vehicle vehicle)
    {
        var rowGroups = (int)double.Ceiling((double)Height / MaxVehicleHeight);

        for (int g = 0; g < rowGroups; g++)
        {
            var yMin = g * MaxVehicleHeight;
            var yMax = yMin + MaxVehicleHeight - vehicle.Height + 1;
            for (int y = yMin; y < yMax; y++)
            {
                for (int x = 0; x < Width - vehicle.Width + 1; x++)
                {
                    if (TryPark(vehicle, x, y))
                        return;
                }
            }
        }

        throw new InvalidOperationException();
    }

    public void Park(Vehicle vehicle, int column, int row)
    {
        if (!TryPark(vehicle, column, row))
            throw new InvalidOperationException();
    }

    public bool TryPark(Vehicle vehicle, int column, int row)
    {
        var w = vehicle.Width;
        var h = vehicle.Height;

        var startSlot = slots[row, column];
        if (startSlot is null)
            return false;

        for (int x = column; x < column + w; x++)
        {
            for (int y = row; y < row + h; y++)
            {
                var slot = slots[y, x];
                if (slot is null || startSlot.Type != slot.Type || slot.IsOccupied || !slot.CanPark(vehicle))
                    return false;
            }
        }

        var occupied = new List<Slot>(w * h);
        for (int y = row; y < row + h; y++)
        {
            for (int x = column; x < column + w; x++)
            {
                var slot = slots[y, x]!;
                slot.Vehicle = vehicle;
                occupied.Add(slot);
            }
        }

        vehicle.OccupiedSlots = occupied.ToImmutableArray();
        Events.Add(new(DateTime.Now, vehicle.ID, (column, row), vehicle.GetType(), true, null));
        return true;
    }

    public void Unpark(Vehicle v)
    {
        if (v.OccupiedSlots is null)
            throw new InvalidOperationException();

        foreach (var s in v.OccupiedSlots)
            s.Vehicle = null;
        v.OccupiedSlots = null;

        var parked = Events.FindLast(e => e.VehicleID == v.ID)!;
        var now = DateTime.Now;
        Events.Add(parked with { Time = now, Parked = false, TotalTime = now - parked.Time });
    }

    public static (int x, int y) NotationToCoords(string col, string row)
    {
        col = col.ToUpper();

        int x = 0;
        for (int pos = 0; pos < col.Length; pos++)
        {
            var c = col[^(pos + 1)];
            if (c is not (>= 'A' and <= 'Z'))
                throw new ArgumentException($"Invalid character '{c}' at pos {pos}.");
            x += (c - 'A') * (int)double.Pow(AlphabetLength, pos);
        }

        int y = int.Parse(row);
        ArgumentOutOfRangeException.ThrowIfLessThan(y, 1);

        return (x, y - 1);
    }

    public static string CoordsToNotation(int x, int y)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(x);
        ArgumentOutOfRangeException.ThrowIfNegative(y);

        var chars = new List<char>(8);
        for (int dividend = x; dividend > 0;) //base10->26
        {
            var (quot, rem) = int.DivRem(dividend, AlphabetLength);
            chars.Add((char)('A' + rem));
            dividend = quot;
        }

        if (x == 0)
            chars.Add('A');
        chars.Reverse();
        return string.Concat(chars) + (y + 1);
    }
}

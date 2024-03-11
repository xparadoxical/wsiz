using System.Text;

using Proj.Serialization;

namespace Proj;
internal static partial class Cli
{
    public static void MainLoop()
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            DisplayParking();
            DisplayFooter();

            WaitForKey(ConsoleKey.Spacebar);

            DisplayMenu();
        }
    }

    public static void DisplayFooter() => Console.WriteLine("Naciśnij spację aby przejść do menu.");

    public static void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                1. Konfiguracja parkingu
                2. Zaparkowane pojazdy
                3. Dodaj wpis o wjeździe lub wyjeździe pojazdu
                4. Przeglądaj historię pojazdów
                5. Eksportuj/importuj dane
                0. Powrót do widoku parkingu
                """);

            switch (ReadDigitSelection(0, 5))
            {
                case 1: ParkingConfig(); break;
                case 2: ParkedList(); break;
                case 3: ParkUnpark(); break;
                case 4: ParkingEvents(); break;
                case 5: DataManagement(); break;
                case 0: return;
            }
        }
    }

    public static void ParkingConfig()
    {
        while (true)
        {
            var create = Program.parking is null;
            Console.WriteLine($"""
                1. {(create ? "Utwórz" : "Zresetuj")} parking
                2. Konfiguracja miejsc parkingowych
                0. Powrót
                """);

            switch (ReadDigitSelection(0, 2))
            {
                case 1:
                    Program.parking = null!;
                    Console.WriteLine($"{(create ? "Utworzono" : "Zresetowano")} parking. Ustaw teraz szerokość i wysokość.");
                    var w = Prompt<int>("Szerokość");
                    var h = Prompt<int>("Wysokość");
                    Program.parking = new Parking(w, h);
                    Pause("Ustawiono szerokość i wysokość. Dodaj miejsca.");
                    break;
                case 2: SlotConfig(); break;
                case 0: return;
            }
        }
    }

    public static void SlotConfig()
    {
        if (!RequireParking()) return;

        while (true)
        {
            DisplayParking();
            Console.WriteLine("""
                1. Dodaj miejsca
                2. Ustaw typ miejsca
                0. Powrót
                """);

            switch (ReadDigitSelection(0, 2))
            {
                case 1:
                    {
                        var emptySlots = (uint)(Program.parking.Width * Program.parking.Height - Program.parking.GetSlots().Count());
                        if (emptySlots == 0)
                        {
                            Pause("Nie można dodać miejsc do parkingu z pełną liczbą miejsc. Ustaw typ konkretnego miejsca lub zresetuj parking.");
                            continue;
                        }

                        DisplayParking();
                        Console.WriteLine("Dodawanie miejsc");

                        var startPos = ReadParkingPosition("Identyfikator miejsca, od którego zacząć");
                        if (!IsValidPosition(startPos))
                            continue;

                        var count = Prompt<uint>("Liczba nowych miejsc", 1, emptySlots);

                        var type = ReadTrait("typ miejsca");

                        try
                        {
                            Program.parking.AddSlot(type, (int)count, startPos.x, startPos.y);
                        }
                        catch (InvalidOperationException e)
                        {
                            Pause($"Nie ma wystarczająco miejsca na {e.Data["remaining"]} z {count} miejsc. Ustaw typ konkretnego miejsca lub zresetuj parking.");
                            continue;
                        }

                        Pause($"Dodano {count} miejsc.");
                        continue;
                    }
                case 2:
                    {
                        if (!Program.parking.GetSlots().Any())
                        {
                            Pause("Najpierw dodaj miejsca.");
                            continue;
                        }

                        DisplayParking();
                        Console.WriteLine("Zmiana typu miejsca");

                        var pos = ReadParkingPosition();
                        if (!IsValidPosition(pos))
                            continue;

                        var slot = Program.parking[pos.x, pos.y];
                        if (slot is null)
                        {
                            Pause("Pod tym identyfikatorem nie ma miejsca parkingowego.");
                            continue;
                        }
                        if (slot.IsOccupied)
                        {
                            Pause("To miejsce jest obecnie zajęte i nie może być edytowane.");
                            continue;
                        }

                        slot.Type = ReadTrait("typ miejsca");

                        Pause($"Zmieniono typ miejsca.");
                        continue;
                    }
                case 0:
                    return;
            }
        }
    }

    public static void ParkedList()
    {
        if (!RequireParking()) return;

        DisplayParking();

        var now = DateTime.Now;
        var namePad = Vehicle.typeInfo.Max(i => i.display.Length);
        var coordsPad = Parking.CoordsToNotation(Program.parking.Width - 1, Program.parking.Height - 1).Length;

        foreach (var v in Program.parking.GetVehicles())
        {
            var parked = Program.parking.Events.FindLast(e => e.VehicleID == v.ID)!;
            var (x, y) = Program.parking.GetVehiclePosition(v)!.Value;
            Console.WriteLine($"{Parking.CoordsToNotation(x, y).PadRight(coordsPad)} {Vehicle.GetDisplayName(v.GetType()).PadRight(namePad)} {v.ID,-8} od {parked.Time:dd'.'MM'.'yyyy' 'HH':'mm':'ss} ({now - parked.Time:d\\d' 'hh':'mm})");
        }

        Console.WriteLine();
        Pause("Naciśnij klawisz aby zamknąć listę.");
    }

    public static void ParkingEvents()
    {
        if (!RequireParking()) return;

        Console.Clear();

        var namePad = Vehicle.typeInfo.Max(i => i.display.Length);
        var coordsPad = Parking.CoordsToNotation(Program.parking.Width - 1, Program.parking.Height - 1).Length;

        foreach (var (time, id, (x, y), type, parked, total) in Program.parking.Events)
        {
            Console.Write($"{time:dd'.'MM'.'yyyy' 'HH':'mm':'ss} {Parking.CoordsToNotation(x, y).PadRight(coordsPad)} {id,-8} {Vehicle.GetDisplayName(type).PadRight(namePad)}");
            if (!parked)
                Console.Write($" = {total:d\\d' 'hh':'mm}");
            Console.WriteLine();
        }

        Pause("Naciśnij klawisz aby zamknąć listę.");
    }

    public static void DataManagement()
    {
        while (true)
        {
            Console.WriteLine("""
                1. Zapisz do pliku XML
                2. Wczytaj z pliku XML
                0. Powrót
                """);

            switch (ReadDigitSelection(0, 2))
            {
                case 1:
                    if (!RequireParking()) continue;

                    Console.WriteLine("Wybierz plik w otwartym okienku.");
                    using (var dialog = new SaveFileDialog()
                    {
                        AddExtension = true,
                        CheckWriteAccess = true,
                        CreatePrompt = false,
                        DefaultExt = "xml",
                        Filter = "Text files (*.xml)|*.xml|All files (*.*)|*.*",
                        FileName = "parking",
                        OverwritePrompt = true,
                        InitialDirectory = Environment.CurrentDirectory,
                        RestoreDirectory = true,
                        SupportMultiDottedExtensions = true,
                        Title = "Zapisywanie parkingu"
                    })
                    {
                        var result = dialog.ShowDialog();
                        if (result != DialogResult.OK)
                            continue;

                        DataManager.SerializeToXmlFile(ParkingDto.FromParking(Program.parking), dialog.FileName);
                        //try
                        //{

                        //    File.Delete(dialog.FileName);
                        //    using var fs = dialog.OpenFile();
                        //    DataManager.SerializeXml(ParkingDto.FromParking(Program.parking), fs);
                        //}
                        //catch (Exception e)
                        //{
                        //    Pause($"Nie można zapisać danych do pliku {dialog.FileName}:\n{e}");
                        //}
                        Pause("Zapisano.");
                    }

                    continue;
                case 2:
                    Console.WriteLine("Wybierz plik w otwartym okienku.");
                    using (var dialog = new OpenFileDialog()
                    {
                        AddExtension = true,
                        DefaultExt = "xml",
                        Filter = "Text files (*.xml)|*.xml|All files (*.*)|*.*",
                        FileName = "parking",
                        InitialDirectory = Environment.CurrentDirectory,
                        RestoreDirectory = true,
                        SupportMultiDottedExtensions = true,
                        Title = "Zapisywanie parkingu"
                    })
                    {
                        var result = dialog.ShowDialog();
                        if (result != DialogResult.OK)
                            continue;

                        try
                        {
                            Program.parking = DataManager.DeserializeFromXmlFile(dialog.FileName).ToParking();
                            Pause("Załadowano.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Pause($"Wystąpił błąd podczas wczytywania danych. Spróbuj ponownie lub wybierz inny plik.\n{e}");
                        }
                    }

                    continue;
                case 0:
                    return;
            }
        }
    }

    public static void ParkUnpark()
    {
        if (!RequireParking()) return;

        DisplayParking();

        while (true)
        {
            Console.WriteLine("""
                1. Wpis o zaparkowaniu
                2. Wpis o wyjeździe
                0. Powrót
                """);

            switch (ReadDigitSelection(0, 2))
            {
                case 1:
                    {
                        Console.WriteLine("Zaparkowanie");

                        var type = ReadVehicleType();
                        VehicleTraits? traits = type == typeof(Bike) ? null : ReadTraits("zezwoleń pojazdu");

                        DisplayParking();
                        var pos = ReadParkingPosition();
                        if (!IsValidPosition(pos))
                            continue;

                        var id = Prompt("Identyfikator pojazdu (np. ABC123, 1Z0)", "^[A-Za-z0-9]{3,8}$");

                        var veh = Vehicle.MakeVehicle(type, id.ToUpper(), traits);

                        if (!Program.parking.TryPark(veh, pos.x, pos.y))
                        {
                            Pause("Nie można zaparkować pojazdu o podanych parametrach w tym miejscu.");
                            continue;
                        }

                        Pause("Dodano wpis o zaparkowaniu.");
                    }
                    continue;
                case 2:
                    {
                        Console.WriteLine("Wyjazd");

                        var pos = ReadParkingPosition();
                        if (!IsValidPosition(pos))
                            continue;

                        var slot = Program.parking[pos.x, pos.y];
                        if (slot is null)
                        {
                            Pause("W tym miejscu nie ma wyznaczonego miejsca parkingowego.");
                            continue;
                        }
                        if (!slot.IsOccupied)
                        {
                            Pause("To miejsce nie jest zajęte przez jakikolwiek pojazd.");
                            continue;
                        }

                        var veh = slot.Vehicle;
                        Program.parking.Unpark(veh);

                        Pause("Dodano wpis o wyjeździe.");
                    }
                    continue;
                case 0:
                    return;
            }
        }
    }
}

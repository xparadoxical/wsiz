using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Proj;
internal static partial class Cli
{
    public static void WaitForKey(ConsoleKey key)
    {
        ConsoleKeyInfo info;
        do
        {
            info = Console.ReadKey(true);
        } while (info.Key != key);
    }

    public static string Prompt(string prompt, [StringSyntax(StringSyntaxAttribute.Regex)] string? regex = null)
        => Prompt(prompt, out _, regex);

    public static string Prompt(string prompt, out MatchCollection? matches, [StringSyntax(StringSyntaxAttribute.Regex)] string? regex = null)
    {
        Regex? rg = null;
        if (regex is not null)
            rg = new(regex);

        while (true)
        {
            Console.Write($"{prompt}: ");
            var s = Console.ReadLine()!;

            matches = rg?.Matches(s);
            if (rg is null || matches!.Count > 0)
            {
                return s;
            }
            else
            {
                Console.WriteLine("Nieprawidłowe dane.");
                continue;
            }
        }
    }

    public static T Prompt<T>(string prompt, T? min = default, T? max = default)
        where T : IParsable<T>, IComparisonOperators<T, T, bool>
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            var s = Console.ReadLine();
            if (T.TryParse(s, null, out var result))
            {
                if ((min == default || result >= min!) && (max == default || result <= max!))
                    return result;
                else
                    Pause($"Wartość jest poza zakresem {min} - {max}");
            }
            else
                Pause("Wprowadzono nieprawidłowe dane.");
        }
    }

    public static int ReadDigitSelection(int min, int max)
    {
        Console.WriteLine();

        ConsoleKeyInfo info;
        int result;
        do
        {
            info = Console.ReadKey(true);
        } while (!int.TryParse(info.KeyChar.ToString(), out result) || result < min || result > max);

        return result;
    }

    public static int[] PromptMultiSelection(uint minCount, string promptSubject, params string[] options)
    {
        const char disabled = '⨯', enabled = '✓';
        var states = new bool[options.Length];
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Wybierz {minCount} lub więcej {promptSubject}. Naciśnij enter aby zaakceptować wybór.");
            Console.WriteLine(string.Join('\n', options.Select((s, i) => $"{(states[i] ? enabled : disabled)} {i + 1}. {s}")));

            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
            } while (info.Key is not (ConsoleKey.Enter or >= ConsoleKey.D1) || info.Key > ConsoleKey.D1 + (options.Length - 1));

            if (info.Key is ConsoleKey.Enter)
            {
                if (states.Count(b => b) >= minCount)
                {
                    return options.Zip(states)
                        .Select(((string option, bool state) z, int i) => (z, i))
                        .Where(t => t.z.state)
                        .Select(t => t.i).ToArray();
                }
                else
                {
                    Console.WriteLine();
                    Pause($"Nie wybrano przynajmniej {minCount} opcji.");
                    continue;
                }
            }
            else
            {
                var i = info.Key - ConsoleKey.D1;
                states[i] ^= true; //toggle
            }
        }
    }

    public static void Pause(string prompt)
    {
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.ReadKey(true);
    }

    public static T Read<T>() where T : IParsable<T>
    {
        while (true)
        {
            var s = Console.ReadLine();
            if (T.TryParse(s, null, out var result))
                return result;
        }
    }

    public static VehicleTraits ReadTrait(string promptSubject)
    {
        Console.WriteLine($"Wybierz {promptSubject}:");
        Console.WriteLine(string.Join('\n', Enum.GetValues<VehicleTraits>()
                .Select((trait, i) => $"{i + 1}. {trait.GetDisplayName()}")
            ));

        var chosenType = ReadDigitSelection(1, 6);
        return Enum.GetValues<VehicleTraits>()[chosenType - 1];
    }

    public static VehicleTraits ReadTraits(string promptSubject)
    {
        var enumValues = Enum.GetValues<VehicleTraits>();
        var options = enumValues.Select(VehicleTraitsExtensions.GetDisplayName).ToArray();
        var selected = PromptMultiSelection(1, promptSubject, options);

        return selected.Select(i => enumValues[i])
            .Aggregate(default(VehicleTraits), (acc, trait) => acc | trait);
    }

    public static Type ReadVehicleType()
    {
        Console.WriteLine("Wybierz typ pojazdu:");
        for (int i = 0; i < Vehicle.typeInfo.Count; i++)
        {
            var (type, display) = Vehicle.typeInfo[i];

            var interfMap = type.GetInterfaceMap(typeof(IVehicleSize));
            var width = (int)interfMap.TargetMethods[Array.FindIndex(interfMap.InterfaceMethods, m => m.Name == $"get_{nameof(IVehicleSize.Width)}")]
                .Invoke(null, null)!;
            var height = (int)interfMap.TargetMethods[Array.FindIndex(interfMap.InterfaceMethods, m => m.Name == $"get_{nameof(IVehicleSize.Height)}")]
                .Invoke(null, null)!;

            Console.WriteLine($"{i + 1}. {display} ({width}x{height})");
        }

        var selection = ReadDigitSelection(1, Vehicle.typeInfo.Count);
        return Vehicle.typeInfo[selection - 1].type;
    }

    public static (int x, int y) ReadParkingPosition(string promptSubject = "Identyfikator miejsca")
    {
        var start = Prompt($"{promptSubject} (np. B4)",
            out var matches,
            "^ *(?<column>[A-Za-z]+) *(?<row>[0-9]+) *$");
        return Parking.NotationToCoords(matches![0].Groups["column"].Value, matches[0].Groups["row"].Value);
    }

    public static bool IsValidPosition((int x, int y) pos)
    {
        if (pos.x >= Program.parking.Width || pos.y >= Program.parking.Height)
        {
            Pause("Identyfikator jest spoza parkingu.");
            return false;
        }

        return true;
    }
}

using System.Diagnostics;

using static System.ConsoleColor;

namespace Parking;
internal static partial class Cli
{
    public static ConsoleColor BackColorForSlot(Slot slot)
    {
        return slot.Type switch
        {
            VehicleTraits.None => DarkGray,
            VehicleTraits.EmissionFree => DarkGreen,
            VehicleTraits.ReservedForServices => DarkRed,
            VehicleTraits.Disabilities => DarkBlue,
            VehicleTraits.Family => DarkCyan,
            VehicleTraits.KissAndRide => DarkMagenta,
            var v => throw new UnreachableException(v.ToString())
        };
    }

    public static ConsoleColor ForeColorForSlot(Slot slot)
    {
        return slot.Type switch
        {
            VehicleTraits.None => Gray,
            VehicleTraits.EmissionFree => Green,
            VehicleTraits.ReservedForServices => Red,
            VehicleTraits.Disabilities => Blue,
            VehicleTraits.Family => Cyan,
            VehicleTraits.KissAndRide => Magenta,
            var v => throw new UnreachableException(v.ToString())
        };
    }

    public static char? DecorationForSlot(Slot slot)
    {
        return slot.Type switch
        {
            VehicleTraits.ReservedForServices => '╳',
            _ => '·'
        };
    }

    private static (int ofColumns, int ofRows) GetMaxLabelLengths(Parking p)
    {
        return ((int)double.Ceiling(Math.Log(p.Width, Parking.AlphabetLength)),
            p.Height.ToString().Length);
    }

    public static (int width, int height) GetMinDimensions(Parking p)
    {
        var (maxColumnLabelHeight, maxRowLabelWidth) = GetMaxLabelLengths(p);

        var width = maxRowLabelWidth + p.Width + 1/*no auto-newlines*/;

        const int menuPadding = 2;
        var height = maxColumnLabelHeight + p.Height + p.Lanes + menuPadding;

        return (width, height);
    }

    /// <summary>Checks if a <see cref="Parking"/> is loaded.</summary>
    /// <returns><see langword="true"/> if a <see cref="Parking"/> is loaded, <see langword="false"/> otherwise.</returns>
    public static bool RequireParking()
    {
        var exists = Program.parking is not null;
        if (!exists)
            Pause("Najpierw utwórz lub wczytaj parking.");

        return exists;
    }

    public static void DisplayParking()
    {
        Console.Clear();
        Parking p = Program.parking;

        if (p is null)
        {
            Console.WriteLine("Brak parkingu.");
            return;
        }

#if RELEASE
        Console.CursorVisible = false;
#endif
        Console.ForegroundColor = White;
        Console.BackgroundColor = Black;

        var (maxColumnLabelHeight, maxRowLabelWidth) = GetMaxLabelLengths(p);

        DrawColumnLabels();
        DrawRowLabels();
        DrawSlots();

        Console.SetCursorPosition(0, maxColumnLabelHeight + p.Height + p.Lanes);
        Console.ForegroundColor = White;
        Console.BackgroundColor = Black;
#if RELEASE
        Console.CursorVisible = true;
#endif
        Console.WriteLine();
        return;

        void DrawColumnLabels()
        {
            var label = new char?[maxColumnLabelHeight];
            label[0] = 'A';

            Console.CursorLeft = maxRowLabelWidth;
            for (int col = 0; col < p.Width; col++)
            {
                Console.CursorTop = maxColumnLabelHeight - 1;

                DrawCurrentLabel();
                AdvanceLabel();
            }
            return;

            void DrawCurrentLabel()
            {
                int c = 0;
                while (true)
                {
                    Console.Write(label[c++]);

                    if (c < label.Length && label[c] is not null)
                    {
                        Console.CursorLeft--;
                        Console.CursorTop--;
                    }
                    else
                        break;
                }
            }

            void AdvanceLabel()
            {
                int c = 0;
                label[c]++;
                while (label[c] > 'Z')
                {
                    label[c] = 'A';
                    if (label[c + 1] is not null)
                        label[c + 1]++;
                    else
                        label[c + 1] = 'A';

                    c++;
                }
            }
        }

        void DrawRowLabels()
        {
            Console.SetCursorPosition(0, maxColumnLabelHeight);

            for (int row = 0; row < p.Height; row++)
            {
                if (row > 0 && row % p.MaxVehicleHeight == 0)
                    Console.CursorTop++;

                Console.Write((row + 1).ToString().PadLeft(maxRowLabelWidth));

                Console.WriteLine();
            }
        }

        void DrawSlots()
        {
            var visited = new bool[p.Width, p.Height];

            for (int y = 0; y < p.Height; y++)
            {
                var lanesWalkedOver = y / p.MaxVehicleHeight;

                for (int x = 0; x < p.Width; x++)
                {
                    if (visited[x, y])
                        continue;

                    visited[x, y] = true;

                    var slot = p[x, y];
                    if (slot is null)
                        continue;

                    Console.BackgroundColor = BackColorForSlot(slot);
                    Console.ForegroundColor = ForeColorForSlot(slot);

                    if (slot.IsOccupied)
                    {
                        var veh = slot.Vehicle;
                        DrawVehicle(x, y + lanesWalkedOver, veh);
                        //entire vehicle can be marked as visited now
                        for (int x2 = 0; x2 < veh.Width; x2++)
                            for (int y2 = 0; y2 < veh.Height; y2++)
                                visited[x + x2, y + y2] = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(maxRowLabelWidth + x, maxColumnLabelHeight + y + lanesWalkedOver);
                        Console.Write(DecorationForSlot(slot));
                        visited[x, y] = true;
                    }
                }
            }
        }

        void DrawVehicle(int xPos, int yPos, Vehicle v)
        {
            Console.SetCursorPosition(maxRowLabelWidth + xPos, maxColumnLabelHeight + yPos);

            if (v.Height == 1) //horizontal
            {
                if (v.Width == 1)
                    Console.Write('◼');
                else
                    Console.Write('◄' + string.Concat(Enumerable.Repeat('▬', v.Width - 2)) + '►');
            }
            else if (v.Width == 1) //vertical
            {
                //1x1 already handled
                Console.Write('▲');
                for (int y = 0; y < v.Height - 2; y++)
                {
                    Console.CursorLeft--;
                    Console.CursorTop++;
                    Console.Write('▮');
                }
                Console.CursorLeft--;
                Console.CursorTop++;
                Console.Write('▼');
            }
            else
            {
                //TL-top-TR
                Console.Write('╭' + string.Concat(Enumerable.Repeat('─', v.Width - 2)) + '╮');

                //left
                //Console.SetCursorPosition(maxRowLabelWidth + xPos, maxColumnLabelHeight + yPos + 1);
                //for (int y = 0; y < v.Height - 2; y++)
                //{
                //    Console.Write('│');
                //    Console.CursorLeft--;
                //    Console.CursorTop++;
                //}

                //right
                //Console.SetCursorPosition(maxRowLabelWidth + xPos + v.Width - 1, maxColumnLabelHeight + yPos + 1);
                //for (int y = 0; y < v.Height - 2; y++)
                //{
                //    Console.Write('│');
                //    Console.CursorLeft--;
                //    Console.CursorTop++;
                //}

                //BL-bottom-BR
                Console.SetCursorPosition(maxRowLabelWidth + xPos, maxColumnLabelHeight + yPos + v.Height - 1);
                Console.Write('╰' + string.Concat(Enumerable.Repeat('─', v.Width - 2)) + '╯');
            }

            Console.SetCursorPosition(maxRowLabelWidth + xPos + 1, maxColumnLabelHeight + yPos);
        }
        /*
         ┌─┐      ╭─╮                ▲
         │╳│      │ │       │ ┃      ▮
         └─┘╳░▒▓█ ╰─╯ ── ━━ │ ┃ ◼ ◄▬►▼
         */
    }
}

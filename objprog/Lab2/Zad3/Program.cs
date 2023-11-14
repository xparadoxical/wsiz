using System;

namespace Zad3
{
    internal class Program
    {
        private static void Main()
        {
            Date d = new Date();
            Console.WriteLine($"Obecna data: {d.GetValue()}");
            d.AddWeek();
            d.AddWeek();
            Console.WriteLine($"Za 2 tygodnie: {d.GetValue()}");
            d.SubtractWeek();
            Console.WriteLine($"Za tydzień: {d.GetValue()}");
        }
    }
}

using System;

namespace Zad2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Sumator s = new Sumator(2, 5, -1, 0, 1);
            Console.WriteLine($"Suma: {s.Suma()}");
            Console.WriteLine($"Suma liczb podzielnych przez 2: {s.SumaPodziel2()}");
            Console.WriteLine($"Liczba elementów: {s.IleElementow()}");

            Console.WriteLine("Elementy:");
            s.WypiszLiczby();

            Console.WriteLine("Elementy o indeksach od 4 do 8:");
            s.WypiszOdDo(3, 8);
        }
    }
}

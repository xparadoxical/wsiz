using System;

namespace Zad2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Samochód osobowy");
            SamochodOsobowy so = new SamochodOsobowy();

            Console.WriteLine();
            Console.WriteLine("Samochód");
            Samochod s1 = new Samochod();
            Samochod s2 = new Samochod("Volksvagen", "ID.7", "hatchback", "biały", 2023, 8945);

            Console.WriteLine();
            Console.WriteLine("1:");
            so.WriteInfo();
            Console.WriteLine("2:");
            s1.WriteInfo();
            Console.WriteLine("3:");
            s2.WriteInfo();
        }
    }
}
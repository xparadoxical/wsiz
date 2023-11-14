using System;

namespace Zad2
{
    public class SamochodOsobowy : Samochod
    {
        public double Waga { get; set; }
        public double PojemnoscSilnika { get; set; }
        public uint IloscOsob { get; set; }

        public SamochodOsobowy() : base()
        {
            Waga = ReadDouble(2, 4.5, "Waga (2 - 4,5 t): ");
            PojemnoscSilnika = ReadDouble(0.8, 3, "Pojemność silnika (0,8 - 3,0 l): ");
            IloscOsob = ReadUInt("Ilość osób: ");
        }

        public override void WriteInfo()
        {
            base.WriteInfo();
            Console.WriteLine($"Waga: {Waga}");
            Console.WriteLine($"PojemnoscSilnika: {PojemnoscSilnika}");
            Console.WriteLine($"IloscOsob: {IloscOsob}");
        }
    }
}

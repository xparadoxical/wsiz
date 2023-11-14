using System;

namespace Zad2
{
    public class Samochod
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Nadwozie { get; set; }
        public string Kolor { get; set; }
        public int RokProdukcji { get; set; }
        public uint Przebieg { get; set; }

        public Samochod()
        {
            Console.Write("Marka: ");
            Marka = Console.ReadLine();

            Console.Write("Model: ");
            Model = Console.ReadLine();

            Console.Write("Nadwozie: ");
            Nadwozie = Console.ReadLine();

            Console.Write("Kolor: ");
            Kolor = Console.ReadLine();

            Console.Write("Rok produkcji: ");
            RokProdukcji = int.Parse(Console.ReadLine());

            Przebieg = ReadUInt("Przebieg (nieujemny): ");
        }

        public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, uint przebieg)
        {
            Marka = marka;
            Model = model;
            Nadwozie = nadwozie;
            Kolor = kolor;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg;
        }

        public virtual void WriteInfo()
        {
            Console.WriteLine($"Marka: {Marka}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Nadwozie: {Nadwozie}");
            Console.WriteLine($"Kolor: {Kolor}");
            Console.WriteLine($"RokProdukcji: {RokProdukcji}");
            Console.WriteLine($"Przebieg: {Przebieg}");
        }

        protected uint ReadUInt(string prompt)
        {
            int value;
            do
            {
                Console.Write(prompt);
                value = int.Parse(Console.ReadLine());
            } while (value < 0);

            return (uint)value;
        }

        protected double ReadDouble(double min, double max, string prompt)
        {
            double value;
            do
            {
                Console.Write(prompt);
                value = double.Parse(Console.ReadLine());
            } while (value < min || value > max);

            return value;
        }
    }
}

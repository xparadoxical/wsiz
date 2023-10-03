using System;

namespace QuadraticFormulaRoots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double a = ReadDouble(nameof(a));
            double b = ReadDouble(nameof(b));
            double c = ReadDouble(nameof(b));

            if (a == 0)
            {
                Console.WriteLine("To nie jest równanie kwadratowe.");
                return;
            }

            double delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta < 0)
            {
                Console.WriteLine("Brak rozwiązań w zbiorze liczb rzeczywistych.");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Rozwiązanie to {x}");
            }
            else
            {
                double deltaRoot = Math.Sqrt(delta);
                double x1 = (-b - deltaRoot) / (2 * a);
                double x2 = (-b + deltaRoot) / (2 * a);
                Console.WriteLine($"Rozwiązania to x1 = {x1}, x2 = {x2}");
            }
        }

        private static double ReadDouble(string name)
        {
            Console.Write($"Podaj wartość {name}: ");
            return double.Parse(Console.ReadLine());
        }
    }
}

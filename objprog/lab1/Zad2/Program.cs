using System;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void ShowMenu()
        {
            Console.WriteLine("0: Zakończ");
            Console.WriteLine("1: Suma");
            Console.WriteLine("2: Różnica");
            Console.WriteLine("3: Iloczyn");
            Console.WriteLine("4: Iloraz");
            Console.WriteLine("5: Potęga");
            Console.WriteLine("6: Pierwiastek kwadratowy");
            Console.WriteLine("7: Sinus");
            Console.WriteLine("8: Cosinus");
            Console.WriteLine("9: Tangens");
            Console.WriteLine("10: Kotangens");
        }

        static void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();

                int selection = Convert.ToInt32(Console.ReadLine());
                double a, b;

                switch (selection)
                {
                    case 0:
                        return;
                    case 1:
                        a = ReadDouble();
                        b = ReadDouble();
                        Sum(a, b);
                        break;
                    case 2:
                        a = ReadDouble();
                        b = ReadDouble();
                        Difference(a, b);
                        break;
                    case 3:
                        a = ReadDouble();
                        b = ReadDouble();
                        Product(a, b);
                        break;
                    case 4:
                        a = ReadDouble();
                        b = ReadDouble();
                        Quotient(a, b);
                        break;
                    case 5:
                        a = ReadDouble();
                        b = ReadDouble();
                        Power(a, b);
                        break;
                    case 6:
                        a = ReadDouble();
                        SquareRoot(a);
                        break;
                    case 7:
                        a = ReadDouble();
                        Sine(a);
                        break;
                    case 8:
                        a = ReadDouble();
                        Cosine(a);
                        break;
                    case 9:
                        a = ReadDouble();
                        Tangent(a);
                        break;
                    case 10:
                        a = ReadDouble();
                        Cotangent(a);
                        break;
                    default: Console.WriteLine("Nieznana opcja."); break;
                }

                Console.WriteLine();
                Console.WriteLine("Naciśnij klawisz aby kontynuować...");
                Console.ReadKey(true);
            }
        }

        static double ReadDouble()
        {
            Console.Write("Podaj wartość: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static void Sum(double a, double b)
            => Console.WriteLine($"{a} + {b} = {a + b}");

        static void Difference(double a, double b)
            => Console.WriteLine($"{a} - {b} = {a - b}");

        static void Product(double a, double b)
            => Console.WriteLine($"{a} * {b} = {a * b}");

        static void Quotient(double a, double b)
            => Console.WriteLine($"{a} / {b} = {a / b}");

        static void Power(double a, double b)
            => Console.WriteLine($"{a} ^ {b} = {Math.Pow(a, b)}");

        static void SquareRoot(double a)
            => Console.WriteLine($"Pierwiastek kwadratowy z {a} = {Math.Sqrt(a)}");

        static void Sine(double a)
        {
            double radians = a * Math.PI / 180;
            Console.WriteLine($"sin({a}°) = {Math.Sin(radians)}");
        }

        static void Cosine(double a)
        {
            double radians = a * Math.PI / 180;
            Console.WriteLine($"cos({a}°) = {Math.Cos(radians)}");
        }

        static void Tangent(double a)
        {
            double radians = a * Math.PI / 180;
            Console.WriteLine($"tan({a}°) = {Math.Tan(radians)}");
        }

        static void Cotangent(double a)
        {
            double radians = a * Math.PI / 180;
            Console.WriteLine($"ctg({a}°) = {1 / Math.Tan(radians)}");
        }
    }
}

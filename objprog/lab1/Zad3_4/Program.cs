using System;

namespace Zad3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadanie 3 czy 4? ");
            char c = Console.ReadKey().KeyChar;
            if (c == '3')
                Zad3.Run();
            else if (c == '4')
                Zad4.Run();
            else
                Console.WriteLine("Nieprawidłowa wartość.");
        }
    }
}

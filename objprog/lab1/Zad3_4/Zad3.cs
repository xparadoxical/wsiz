using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_4
{
    internal static class Zad3
    {
        static void ShowMenu()
        {
            Console.WriteLine("0: Zakończ");
            Console.WriteLine("1: Od początku");
            Console.WriteLine("2: Od końca");
            Console.WriteLine("3: Nieparzyste indeksy");
            Console.WriteLine("4: Parzyste indeksy");
        }

        internal static void Run()
        {
            int selection;
            do
            {
                Console.Clear();
                ShowMenu();

                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                    ;
                else if (selection == 2)
                    ;
                else if (selection == 3)
                    ;
                else if (selection == 4)
                    ;

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
                    default: Console.WriteLine("Nieznana opcja."); break;
                }

                Console.WriteLine();
                Console.WriteLine("Naciśnij klawisz aby kontynuować...");
                Console.ReadKey(true);
            }
            while (selection != 0);
        }
    }
}

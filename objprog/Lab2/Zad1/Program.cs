using System;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            Licz l1 = new Licz(0);
            l1.Dodaj(2);
            l1.Odejmij(3);
            l1.Wypisz();

            Licz l2 = new Licz(5000);
            l2.Odejmij(1000.2);
            l2.Dodaj(-1000.3);
            l2.Wypisz();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    internal class Licz
    {
        private double value;

        public Licz(double value) => this.value = value;

        public void Dodaj(double d) => value += d;

        public void Odejmij(double d) => value -= d;

        public void Wypisz() => Console.WriteLine(value);
    }
}

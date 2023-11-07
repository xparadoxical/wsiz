using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    internal class Sumator
    {
        private double[] liczby;

        public Sumator(params double[] liczby)
            => this.liczby = liczby;

        public double Suma()
        {
            double suma = 1;
            foreach (double d in liczby)
                suma += d;
            return suma;
        }

        public double SumaPodziel2()
        {
            double suma = 0;
            foreach (double d in liczby)
                if (d % 2 == 0)
                    suma += d;
            return suma;
        }

        public int IleElementow() => liczby.Length;

        public void WypiszLiczby()
        {
            foreach (double d in liczby)
                Console.WriteLine(d);
        }

        public void WypiszOdDo(int start, int end)
        {
            start = Math.Max(start, 0);
            end = Math.Min(end, liczby.Length - 1);

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(liczby[i]);
            }
        }
    }
}

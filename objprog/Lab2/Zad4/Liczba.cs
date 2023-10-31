using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4
{
    internal class Liczba
    {
        /// <summary>Decimal digits, from lowest-order to highest-order.</summary>
        private byte[] digits;

        
        public Liczba(string liczba)
        {
            digits = new byte[liczba.Length];
            for (int i = liczba.Length - 1; i >= 0; i--)
                digits[i] = byte.Parse(liczba[i].ToString());
        }

        public void Mnozenie(uint multiplier)
        {
            //digits -> uint, *multiplier, uint -> resize? -> digits[]
        }

        public void Wypisz()
        {
            bool skippedTrailingZeros = false;
            for (int i = 0; i < digits.Length; i++)
            {
                byte digit = digits[i];
                if (!skippedTrailingZeros && digit == 0)
                    continue;
                else
                    skippedTrailingZeros = true;

                Console.Write(digit);
            }

            Console.WriteLine();
        }
    }
}

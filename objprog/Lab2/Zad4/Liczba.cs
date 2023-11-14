using System;

namespace Zad4
{
    internal class Liczba
    {
        /// <summary>Decimal digits, from low-order to high-order.</summary>
        private byte[] digits;

        public Liczba(string liczba)
        {
            int trailingZeros = 0;
            for (int i = 0; i < liczba.Length; i++)
            {
                if (liczba[i] == '0')
                    trailingZeros++;
                else
                    break;
            }

            digits = new byte[liczba.Length - trailingZeros];

            for (int i = 0; i < liczba.Length - trailingZeros; i++)
                digits[i] = byte.Parse(liczba[liczba.Length - 1 - i].ToString());
        }

        public void Mnozenie(uint mnoznik)
        {
            Span<byte> accumulator = stackalloc byte[digits.Length * 2];

            for (int i = 0; i < digits.Length; i++)
            {
                byte our = digits[i];

                uint remainingMnoznik = mnoznik;

                for (int j = 0; remainingMnoznik > 0; j++)
                {
                    int a = i + j;

                    uint their = remainingMnoznik % 10;
                    remainingMnoznik /= 10;

                    uint result = our * their + accumulator[a]; //max 9*9+9 = 90

                    // add this up until there's nothing to carry
                    accumulator[a] = (byte)(result % 10);
                    if (result > 9)
                        accumulator[a + 1] = accumulator[a + 1] + (byte)(result / 10);
                }
            }
        }

        public void Silnia()
        {

        }

        public void Wypisz()
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                Console.Write(digits[i]);
            }

            Console.WriteLine();
        }
    }
}

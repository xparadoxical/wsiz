using System;

namespace Zad3
{
    internal class Date
    {
        private DateTime date = DateTime.Now;

        public void AddWeek() => date = date.AddDays(7);

        public void SubtractWeek() => date = date.AddDays(-7);

        public DateTime GetValue() => date;
    }
}

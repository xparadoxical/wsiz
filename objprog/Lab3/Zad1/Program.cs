using System;
using System.Collections.Generic;

namespace Zad1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person p1 = new Person("Stefan", "Ziemowit", 30);
            Person p2 = new Person("Jan", "Kowalski", 15);
            p1.View();
            p2.View();

            Person a1 = new Person("Jan", "Kochanowski", 37);
            Person a2 = new Person("Jan", "Brzechwa", 60);
            Person a3 = new Person("Adam", "Mickiewicz", 40);
            Person a4 = new Person("Olga", "Tokarczuk", 43);
            Book b1 = new Book("Ania z Zielonego Wzgórza", a1, new DateTime(1965, 4, 21));
            Book b2 = new Book("Folwark Zwierzęcy", a2, new DateTime(1980, 9, 3));
            Book b3 = new Book("Kubuś Puchatek", a3, new DateTime(1936, 11, 14));
            Book b4 = new Book("Dziady", a4, new DateTime(2001, 7, 30));
            b1.View();
            b2.View();
            b3.View();
            b4.View();

            Reader r1 = new Reader(p1, new Book[] { b2, b4 });
            Reader r2 = new Reader(p2, new Book[] { b1, b4 });
            Reader r3 = new Reader("Anna", "Zielińska", 45, new Book[] { b1, b2, b3 });
            r1.ViewBooks();
            r2.ViewBooks();
            r3.ViewBooks();

            Reviewer rv1 = new Reviewer("Izabela", "Łukowska", 26, new Book[] { b3 });
            Reviewer rv2 = new Reviewer("Krzysztof", "Cwojdziński", 51, new Book[] { b2, b4 });
            rv1.Wypisz();
            rv2.Wypisz();

            Console.WriteLine("---");
            List<Person> readers = new List<Person>() { r1, r2, r3, rv1, rv2 };
            foreach (Person p in readers)
            {
                p.View();
                Console.WriteLine();
            }
        }
    }
}
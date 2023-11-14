using System;

namespace Zad1
{
    public class Reviewer : Reader
    {
        public Reviewer(string firstName, string lastName, uint age, Book[] books) : base(firstName, lastName, age, books)
        { }

        public void Wypisz()
        {
            foreach (Book b in books)
            {
                Console.WriteLine($"{b} [ocena {Random.Shared.Next(1, 10)}/10]");
            }
        }
    }
}

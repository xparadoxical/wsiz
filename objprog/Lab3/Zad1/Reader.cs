using System;

namespace Zad1
{
    public class Reader : Person
    {
        protected Book[] books;

        public Reader(string firstName, string lastName, uint age, Book[] books) : base(firstName, lastName, age)
            => this.books = books;

        public Reader(Person p, Book[] books) : this(p.FirstName, p.LastName, p.Age, books)
        { }

        public void ViewBooks()
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b);
            }
        }

        public override void View()
        {
            base.View();
            ViewBooks();
        }
    }
}

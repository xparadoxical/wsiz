using System;

namespace Zad1
{
    public class Book
    {
        protected string title;
        protected Person author;
        protected DateTime publishedOn;

        public Book(string title, Person author, DateTime publishedOn)
        {
            this.title = title;
            this.author = author;
            this.publishedOn = publishedOn;
        }

        public void View() => Console.WriteLine(ToString());

        public override string ToString() => $"{author} - „{title}” ({publishedOn.Year} r.)";
    }
}

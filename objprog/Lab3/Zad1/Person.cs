using System;

namespace Zad1
{
    public class Person
    {
        private string firstName, lastName;
        private uint age;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public uint Age { get => age; set => age = value; }

        public Person(string firstName, string lastName, uint age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public virtual void View() => Console.WriteLine(ToString());

        public override string ToString() => $"{firstName} {lastName}, {age} lat";
    }
}

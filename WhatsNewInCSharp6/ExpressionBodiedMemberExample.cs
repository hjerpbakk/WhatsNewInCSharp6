using System;

namespace WhatsNewInCSharp6
{
    /// <summary>
    /// - Expression bodies on method-like members
    /// - Expression bodies on property-like function members
    /// </summary>
    public class Person
    {
        private readonly string first;
        private readonly string last;
        
        public Person(string first, string last, uint age)
        {
            Age = age;
            this.last = last;
            this.first = first;
        }

        public uint Age { get; }

        public string Name => first + " " + last;

        public static implicit operator string(Person p) => p.Name + " " + p.Age;

        public static Person operator ++(Person p) => new Person(p.first, p.last, p.Age + 1);

        // Must be a statement expression in methods returning void or Task
        public void Print() => Console.WriteLine(this);
    }
}
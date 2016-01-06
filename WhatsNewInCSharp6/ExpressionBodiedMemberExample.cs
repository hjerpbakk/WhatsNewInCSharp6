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
        private readonly uint age;

        public Person(string first, string last, uint age)
        {
            this.age = age;
            this.last = last;
            this.first = first;
        }

        public string Name => first + " " + last;

        public static implicit operator string(Person p) => p.Name + " " + p.age;

        public static Person operator ++(Person p) => new Person(p.first, p.last, p.age + 1);

        public void Print() => Console.WriteLine(this);
    }
}
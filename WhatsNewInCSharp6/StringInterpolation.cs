namespace WhatsNewInCSharp6
{
    /// <summary>
    /// Example of string interpolation using C# 6
    /// </summary>
    public class StringInterpolation
    {
        public string OldWay(Person person, string adjective)
        {
            // ReSharper disable once UseStringInterpolation
            return string.Format("{0} is {1}", person.Name, adjective);
        }

        public string NewWay(Person person, string adjective)
        {
            return string.Format($"{person.Name} is {adjective}");
        }

        public string AlignmentAndFormatCanStillBeUsed(Person person)
        {
            return string.Format($"{person.Name, 20} is {person.Age} years old");
        }

        public string ExpressionsToo(Person person)
        {
            return string.Format($"{person.Name} is {(person.Age > 32 ? "old" : "young")}");
        }
    }
}
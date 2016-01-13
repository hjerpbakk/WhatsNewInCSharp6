namespace WhatsNewInCSharp6
{
    public class StringInterpolation
    {
        public string OldWay(Person person, string adjective)
        {
            return string.Format("{0} er {1}", person, adjective);
        }

        public string NewWay(Person person, string adjective)
        {
            return string.Format($"{person} er {adjective}");
        }

        public string AlignmentAndFormatCanStillBeUsed(Person person)
        {
            return string.Format($"{person.Name, 20} er {person.Age} år gammel");
        }

        public string ExpressionsToo(Person person)
        {
            return string.Format($"{person} er {(person.Age > 32 ? "gammel" : "ung")}");
        }
    }
}
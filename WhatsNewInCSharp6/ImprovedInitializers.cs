namespace WhatsNewInCSharp6
{
    public class ImprovedInitializers : IEnumerable 
    {
        readonly IList<Person> persons;
        
        public ImprovedInitializers() 
        {
            persons = new List<Person>
            {
                new Person("", 1),
                new Person("", 3)  
            };
            
            // Using the extension method
            persons = new List<Person>
            {
                { "", 1 },
                { "", 3 }  
            };
            
            // Old way using Add
            var dictionary = new Dictionary<string, int> 
            {
                { "Runar", 32 },
                { "Isaac Newton", 373 }    
            };0
            
            // Using indexer
            var dictionary = new Dictionary<string, int> 
            {
                ["Runar"] = 32,
                ["Isaac Newton"] = 373,   
            };
        }
        
        public void Add(Person p) 
        {
            persons.Add(p);
        }
        
        private IEnumerator IEnumerable.GetEnumerator() 
        {
            throw new NotImplementedException("Only implemented for collection initializer.");    
        }
    }
    
    // TODO: Use this in example
    public static class ThisIsNew
    {
        public static void Add(this IList<Person> people, string name, int age) 
        {
            people.Add(new Person(name, age));
        }
    }
}
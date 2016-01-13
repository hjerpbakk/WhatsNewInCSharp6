using System;
using System.Collections;
using System.Collections.Generic;

namespace WhatsNewInCSharp6
{
    public class ImprovedInitializers : IEnumerable 
    {
        readonly IList<Person> persons;
        
        public ImprovedInitializers() 
        {
            persons = new List<Person>();

            // Old way using Add
            // ReSharper disable once UnusedVariable
            var dict1 = new Dictionary<string, int> 
            {
                { "Runar", 32 },
                { "Isaac Newton", 373 }    
            };

            // Using indexer
            // ReSharper disable once UnusedVariable
            var dict2 = new Dictionary<string, int> 
            {
                ["Runar"] = 32,
                ["Isaac Newton"] = 373,   
            };
        }
        
        public void Add(Person p) 
        {
            persons.Add(p);
        }
        
        IEnumerator IEnumerable.GetEnumerator() 
        {
            throw new NotImplementedException("Only implemented for collection initializer.");    
        }
    }
    
    public static class ThisIsNew
    {
        public static void Add(this ImprovedInitializers people, string firstName, string lastName, uint age) 
        {
            people.Add(new Person(firstName, lastName, age));
        }
    }
}
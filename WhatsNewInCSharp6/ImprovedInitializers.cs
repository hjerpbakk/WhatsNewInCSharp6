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
            persons = new List<Person>
            {
                new Person("First", "Last", 1),
                new Person("Another", "Person", 3)  
            };
            
            // Using the extension method
            persons = new List<Person>
            {
                { "First", "Last", 1 },
                { "Another", "Person", 3 }  
            };
            
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
    
    // TODO: Use this in example
    public static class ThisIsNew
    {
        public static void Add(this IList<Person> people, string firstName, string lastName, uint age) 
        {
            people.Add(new Person(firstName, lastName, age));
        }
    }
}
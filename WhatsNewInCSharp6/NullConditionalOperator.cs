using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhatsNewInCSharp6
{
    public class NullConditionalOperator : INotifyPropertyChanged 
    {     
        public event PropertyChangedEventHandler PropertyChanged;
        
        // ReSharper disable once NotAccessedField.Local
        int actionCounter;
        
        // Sooooo much code
        public bool ShouldGiveDrug(Prescription prescription)
        {   
            // Not even safe!
            return prescription != null && prescription.Person != null && prescription.Person.Name == "Runar";
        }
        
        // Better? Better.
        public bool ShouldGiveImprovedDrug(Prescription prescription)
        {   
            return prescription?.Person?.Name == "Runar Hjerpbakk";
        }
        
        public void DoAction(Action theBestAction)
        {
            ++actionCounter;
            
            // Can't do it
            // theBestAction?();
            
            // But there is a way
            theBestAction?.Invoke();
        }        
        
        // Verbose and needlesly complex
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        // Proper way
        protected void OnPropertyChangedProper([CallerMemberName] string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public class Prescription 
    {
        public Prescription(Person person, string drugInfo)
        {
            Person = person;
            DrugInfo = drugInfo;
        }
        
        public Person Person { get; }
        public string DrugInfo { get; }
    }
}
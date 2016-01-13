namespace WhatsNewInCSharp6
{
    public class NullConditionalOperator : INotifyPropertyChanged 
    {     
        public event PropertyChangedEventHandler PropertyChanged;
        
        int actionCounter;
        
        // Sooooo much code
        public bool ShouldGiveDrug(Prescription prescription)
        {   
            // Not even safe!
            return prescription != null && prescription.Person != null && prescription.Person.FirstName == "Runar";
        }
        
        // Better? Better.
        public bool ShouldGiveDrug(Prescription prescription)
        {   
            return prescription?.Person?.FirstName == "Runar";
        }
        
        public void DoAction(Action theBestAction)
        {
            ++actionCounter;
            
            // Can't do it
            // theBestAction?();
            
            // But there is a way
            theBestAction?.Invoke();
        }        
        
        // Old way, but new to us :(
        // Verbose and needlesly complex
        protected void OnPropertyChanged([CallerMemberName] string propertyName)
        {
            // To be thread safe
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        // Proper way
        protected void OnPropertyChangedProper([CallerMemberName] string propertyName) => 
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
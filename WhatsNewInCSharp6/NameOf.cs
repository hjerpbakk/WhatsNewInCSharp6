using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhatsNewInCSharp6
{
    public class NameOf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NameOf() 
        {
            Value1 = 1;
            Value2 = 2;    
        }
        
        public NameOf(string argument) : this()
        {
            // So error prone in notepad
            if (argument == null)
            {
                throw new ArgumentNullException("argument");
            }
        }
        
        public NameOf(Person person) : this()
        {
            // It just works
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
        }
        
        // No backing fields, yeiii
        public int Value1 { get; private set; }
        public int Value2 { get; private set; }
        
        public void Swap() 
        {
            var temp = Value2;
            Value2 = Value1;
            Value1 = temp;
            // ReSharper disable ExplicitCallerInfoArgument
            OnPropertyChanged(nameof(Value1));
            OnPropertyChanged(nameof(Value2));
            // ReSharper restore ExplicitCallerInfoArgument
        }

        public override string ToString()
        {
            return Value1 + " " + Value2;
        }

        // Old way, but new to us :(
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // To be thread safe
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
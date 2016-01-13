using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhatsNewInCSharp6
{
    /// <summary>
    /// Shows usage of nameof operator in C# 6
    /// </summary>
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
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("argument");
            }
        }
        
        public NameOf(Person person) : this()
        {
            if (person == null)
            {
                // It just works
                throw new ArgumentNullException(nameof(person));
            }
        }
        
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
            // ReSharper disable once UseNullPropagation
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
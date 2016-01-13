// Super awesome static using

using System;
using static System.Math; 
using static System.DayOfWeek;

// The type, not the namespace
using static System.Linq.Enumerable; 

namespace WhatsNewInCSharp6
{
    public class UsingStatic 
    {
        private readonly DayOfWeek calculationDay;
        
        public UsingStatic(DayOfWeek calculationDay)
        {
            this.calculationDay = calculationDay;
        }
        
        public int CalculateIfLuckyDay()
        {
            if (calculationDay != Wednesday) 
            {
                return 0;    
            }
            
            // Such readability
            return (int)((PI * E) / 0.2033270053D); 
        }
        
        public int[] EvenNumbers(int lowerLimit, int upperLimit)
        {
            var range = Range(lowerLimit, upperLimit);
            
            // Even without using System.Linq 
            return range.Where(i => i % 2 == 0).ToArray();
        }
    }    
}
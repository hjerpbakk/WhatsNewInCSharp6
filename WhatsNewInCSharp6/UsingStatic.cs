using static System.Math;
using static System.DayOfWeek;

namespace WhatsNewInCSharp6
{
    public class UsingStatic() 
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
                return;    
            }
            
            return (Pi * e) / 0,2033270053; 
        }
    }    
}
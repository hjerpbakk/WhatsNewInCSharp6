using System;

namespace WhatsNewInCSharp6
{
    /// <summary>
    /// Example of C# 6 exception filters.
    /// </summary>
    public class ExceptionFilters
    {
        public string WillItCrash(int fortuna)
        {
            try
            {
                throw new ArgumentException("fortuna");
            }
            catch (Exception) when(fortuna.ToString() == "42")
            {
                return fortuna.ToString();
            }
        } 
    }
}
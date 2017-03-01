using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Theranos.Automation.PSC3.Utility
{
    public class UtilityClass
    {
        public static string GetCurrentDate()
        {
            return Regex.Replace(DateTime.Now.ToString(), @"[^0-9a-zA-Z\s]+", ".");
        }

        public static string GetCurrentMethod(int level)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(level);

            return sf.GetMethod().Name;
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
    
    }
}

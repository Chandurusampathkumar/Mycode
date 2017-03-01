using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Theranos.Automation.AutoStack.Android.Utility
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

        public static string GetListItemId(string id, int i)
        {
            return id.Replace('$', i.ToString().ToCharArray()[0]);
        }

        public static bool CompareDictionary(Dictionary<string, int> x, Dictionary<string, int> y)
        {
            // early-exit checks
            if (null == y)
                return null == x;
            if (null == x)
                return false;
            if (object.ReferenceEquals(x, y))
                return true;
            if (x.Count != y.Count)
                return false;

            // check keys are the same
            foreach (string k in x.Keys)
                if (!y.ContainsKey(k))
                    return false;

            // check values are the same
            foreach (string k in x.Keys)
                if (!x[k].Equals(y[k]))
                    return false;

            return true;
        }

        public static bool CompareDictionary(Dictionary<string, string> x, Dictionary<string, string> y)
        {
            // early-exit checks
            if (null == y)
                return null == x;
            if (null == x)
                return false;
            if (object.ReferenceEquals(x, y))
                return true;
            if (x.Count != y.Count)
                return false;

            // check keys are the same
            foreach (string k in x.Keys)
                if (!y.ContainsKey(k))
                    return false;

            // check values are the same
            foreach (string k in x.Keys)
                if (!x[k].Equals(y[k]))
                    return false;

            return true;
        }

        //public static string DictToString(Dictionary<string, int> dict)
        //{
        //    return string.Join(";", dict.Select(x => x.Key + "=" + x.Value).ToArray());
        //}

        public static string GetLine(Dictionary<string, int> dictionary)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                builder.Append(pair.Key).Append(":").Append(pair.Value).Append(',');
            }
            string result = builder.ToString();
            result = result.TrimEnd(',');
            return result;
        }

        public static string GetLine(Dictionary<string, string> dictionary)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                builder.Append(pair.Key).Append(":").Append(pair.Value).Append(',');
            }
            string result = builder.ToString();
            result = result.TrimEnd(',');
            return result;
        }
    }
}

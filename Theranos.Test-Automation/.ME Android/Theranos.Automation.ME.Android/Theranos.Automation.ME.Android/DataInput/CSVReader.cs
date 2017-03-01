using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Theranos.Automation.ME.Android.DataInput.Inputpro;


namespace Theranos.Automation.ME.Android.DataInput
{
    [TestClass]
    public class CSVReader
    {

        public static List<T> GetRecords<T>(string filename)
        {
            string pathCSV = filename;
            // string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathCSV);
            string pat = Path.Combine(Path.GetFullPath(@"C:\csampathkumar\Source\Theranos.Test-Automation\.ME Android\Internal\Input"), pathCSV);
            var reader = new StreamReader(pat);
            var csvReader = new CsvReader(reader);
            var returnList = csvReader.GetRecords<T>().ToList();
            reader.Close();
            csvReader.Dispose();
            return returnList;
        }

        public void WiterRecords(string filename,string user,string pwd, string co)
        {
            string pathCSV = filename;
            string rrpath = Path.Combine(Path.GetFullPath(@"C:\Users\balaji.venkat\Source\Workspaces\Theranos.Test-Automation\.ME Android\Internal\Input"), "dump.csv");
            string wrpath = Path.Combine(Path.GetFullPath(@"C:\Users\balaji.venkat\Source\Workspaces\Theranos.Test-Automation\.ME Android\Internal\Input"), pathCSV);
            var reader = new StreamReader(rrpath);
            var CSvreader = new CsvReader(reader);
            var lists = CSvreader.GetRecords<CSVLoginInput>().ToList();
            var witer = new StreamWriter(wrpath);
            var CSVWiter = new CsvWriter(witer);
            foreach (var item in lists)
            {
               
                CSVWiter.WriteField(user);
                CSVWiter.WriteField(pwd);
                CSVWiter.WriteField(co);
                CSVWiter.NextRecord();
                witer.Close();

            }

             //CSVWiter.WriteRecords(lists);
             //witer.Close();   
        }

        [TestMethod]
        public void CallWriterMethod()
        {
            WiterRecords("test.csv", "seqq", "se123qq", "445qq");
        }
        public class CSVLoginInput
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Passcode { get; set; }
        }
    }

}

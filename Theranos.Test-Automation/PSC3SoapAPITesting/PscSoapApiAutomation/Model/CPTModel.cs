using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//@author   Fangming Lu

namespace PscSoapApiAutomation.Model
{
    internal class CptModel
    {
        public const string InputFileName = "CPTDataSet.csv";
        public const string InputFilePath = "C:\\Users\\flu\\Source\\Workspaces\\Theranos.Test-Automation\\PSC3SoapAPITesting\\Test.xlsx";
        public const string CharsForRandom = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string CptCode { get; set; }
        public string TestName { get; set; }
        public string Price { get; set; }
    }
}

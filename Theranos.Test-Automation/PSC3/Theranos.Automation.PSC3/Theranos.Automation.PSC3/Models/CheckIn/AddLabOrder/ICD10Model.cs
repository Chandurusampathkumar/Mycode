using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class ICD10Model:PSC3Model
    {
        public const string InputFileName = "ICD10DataSet.csv";

        public const string ICD10_ByID = "ICD9.Screen.ICD10.Radiobutton";


        public string ICDCode { get; set; }
        public string ICDName { get; set; }

    }
}

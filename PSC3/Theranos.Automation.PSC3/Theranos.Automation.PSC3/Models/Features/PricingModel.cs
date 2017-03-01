using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Features
{
    public class PricingModel:PSC3Model
    {
        public const string InputFileName = "PricingDataSet.csv";
        public const string DoctorNA = "N/A";

        //Scenarios
        public string SelfV1Scenario = "SelfV1";
        public string SelfV2Scenario = "SelfV2";


        public string Scenario { get; set; }
        public string Visit { get; set; }
        public string Order { get; set; }
        public string Dr { get; set; }
        public string PaymentMethod { get; set; }
        public string CPTCode { get; set; }
        public string CPTName { get; set; }
        public string TestPrice { get; set; }
        public string Adjustment { get; set; }
        public string TotalCharge { get; set; }


    }
}

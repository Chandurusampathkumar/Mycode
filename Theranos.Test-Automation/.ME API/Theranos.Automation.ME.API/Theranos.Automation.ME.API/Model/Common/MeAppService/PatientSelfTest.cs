using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class PatientSelfTest
    {
        public int CPTCodeId { get; set; }
        public string State { get; set; }
        public decimal TestCost { get; set; }
        public string TestDescription { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }

    }
}

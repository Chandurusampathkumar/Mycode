using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.External
{
    public class DisplayPatientLabTest
    {
        public int? BaseFrequency { get; set; }
        public string CPTCode { get; set; }
        public int CPTCodeId { get; set; }
        public string DisplayLabOrderFrequency { get; set; }
        public DateTime? EndDate { get; set; }
        public string FrequencyTimeScale { get; set; }
        public bool IsAReflexTest { get; set; }
        public bool IsCPTValid { get; set; }
        public int LabTestId { get; set; }
        public DateTime? LastCompletedOn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TestCompletedOn { get; set; }
        public string TestName { get; set; }
        public string TestStatus { get; set; }
        public string TestTime { get; set; }
        public List<TestSetInfo> TestSets { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.PatientLabTest
    /// </summary>
    
    public class PatientLabTest
    {
        public int BaseFrequency { get; set; }
        public string CPTCode { get; set; }
        public int CPTCodeId { get; set; }
        public DateTime EndDate { get; set; }
        public string FrequencyTimeScale { get; set; }
        public bool IsAReflexTest { get; set; }
        public bool IsCPTValid { get; set; }
        public int LabTestId { get; set; }
        public DateTime LastCompletedOn { get; set; }
        public int PanelId { get; set; }
        public string PanelName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TestCompletedOn { get; set; }
        public string TestName { get; set; }
        public string TestStatus { get; set; }
        public string TestTime { get; set; }
    }
}

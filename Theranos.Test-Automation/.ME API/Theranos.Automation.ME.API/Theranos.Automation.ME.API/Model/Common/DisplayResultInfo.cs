using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.Common
{
    public class DisplayResultInfo
    {
        public List<DisplayTestResult> TestResults { get; set; }
        public string DoctorNotes { get; set; }
        public Guid LabOrderId { get; set; }
        public string LabOrderName { get; set; }
        public string OrderSource { get; set; }
        public Doctor OrderingDoctor { get; set; }
        public string ReportType { get; set; }
        public List<string> ResultQualifiers { get; set; }
  //      public List<TestResult> TestResult { get; set; }
    }
}

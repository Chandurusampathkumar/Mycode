using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class TestResult
    {
        public int CPTCodeId { get; set; }
        public List<EnumResultValue> EnumResults { get; set; }
        public bool IsAReflexTest { get; set; }
        public Guid PatientVisitId { get; set; }
        public List<QuantResultValue> QuantResults { get; set; }
        public int RequireFastingHours { get; set; }
        public string ResultType { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitFastingStatus { get; set; }
        public RetailLocation VisitLocation { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.PatientDiagnostics
    /// </summary>
    public class PatientDiagnostics
    {
        public string DiagnosticsName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorMiddleName { get; set; }
        public string DoctorSuffix { get; set; }
        public string DoctorTitle { get; set; }
        public DateTime EnteredOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.External
{
    public class GetVisitLabOrderTurnaroundTimeRequest
    {
        public Guid LabOrderId { get; set; }
        public Guid PatientVisitId { get; set; }
        public string AuthToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class EarlyCheckInPatientRequest
    {
        public Guid LocationId { get; set; }
        public Guid LabOrderId { get; set; }
        public string AuthToken { get; set; }
    }
}

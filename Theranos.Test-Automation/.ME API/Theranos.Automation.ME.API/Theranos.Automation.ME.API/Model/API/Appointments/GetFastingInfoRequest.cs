using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class GetFastingInfoRequest
    {
        public int AppointmentId { get; set; }
        public Guid LaborderId { get; set; }
        public string AuthToken { get; set; }
    }
}

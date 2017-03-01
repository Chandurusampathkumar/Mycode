using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class SaveAppointmentRequest
    {
        public Guid LocationId { get; set; }
        public DateTime CheckInTime { get; set; }
        public int ServiceId { get; set; }
        public int CurrentAppointmentId { get; set; }
        public List<Guid?> LabOrderIds { get; set; }
        public string AuthToken { get; set; }
    }
}

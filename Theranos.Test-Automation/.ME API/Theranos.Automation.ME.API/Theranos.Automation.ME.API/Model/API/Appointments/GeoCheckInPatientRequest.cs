using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public  class GeoCheckInPatientRequest
    {
        public Guid LocationId { get; set; }
        public int AppointmentId { get; set; }
        public List<Guid> LabOrderIds { get; set; }
        public DateTime CheckInTime { get; set; }
        public string AuthToken { get; set; }
    }
}

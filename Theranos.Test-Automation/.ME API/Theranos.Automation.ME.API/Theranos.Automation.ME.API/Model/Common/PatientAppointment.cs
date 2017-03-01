using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.Common
{
    public class PatientAppointment
    {
        public int AppointmentId { get; set; }
        public int EarlyCheckInId { get; set; }
        public DateTime AppointmentBeginTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string LocationWindowsTimeZoneId { get; set; }
        public string LocationUnicodeTimeZoneId { get; set; }
        public int OffsetMinutes { get; set; }
        public int ServiceId { get; set; }
        public int AppointmentSlot { get; set; }
        public DateTime AppointmentCreatedOn { get; set; }
        public RetailLocation AppointmentLocation { get; set; }
        public Guid LabOrderIds { get; set; }
    }
}

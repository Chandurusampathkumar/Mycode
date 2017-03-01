using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class GetAvailableTimeSlotsRequest
    {
        public Guid LocationId { get; set; }
        public int ServiceId { get; set; }
        public DateTime GivenDate { get; set; }
        public string AuthToken { get; set; }
    }
}

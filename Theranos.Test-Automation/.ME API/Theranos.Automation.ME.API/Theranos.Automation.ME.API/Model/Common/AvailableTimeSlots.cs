using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common
{
    public class AvailableTimeSlots
    {
        public Guid LocationId { get; set; }
        public int ServiceId { get; set; }
        public int BucketStartTime { get; set; }
        public int BucketEndTime { get; set; }
        public int BucketDurationInMinutes { get; set; }
        public List<int> AvailableSlots { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common
{
    public class AvailableServices
    {
        public Guid LocationId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceDescription { get; set; }
        public string UnicodeTimeZoneId { get; set; }
        public string WindowsTimeZoneId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}

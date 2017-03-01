using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Physicians
{
    public class GetPhysiciansRequest
    {
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public decimal minDistance { get; set; }
        public decimal maxDistance { get; set; }
        public string unit { get; set; }
    }
}

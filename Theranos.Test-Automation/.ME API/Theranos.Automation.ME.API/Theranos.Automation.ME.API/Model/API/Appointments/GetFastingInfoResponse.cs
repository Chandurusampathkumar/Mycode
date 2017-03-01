using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class GetFastingInfoResponse
    {
        public string fastingHours { get; set; }
        public ErrorCodes code { get; set; }
        public string message { get; set; }
    }
}

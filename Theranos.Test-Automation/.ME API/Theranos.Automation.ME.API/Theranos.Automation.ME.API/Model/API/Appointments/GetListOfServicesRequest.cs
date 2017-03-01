using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.EndPoint;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class GetListOfServicesRequest
    {
        public Guid LocationId { get; set; }
        public DateTime GivenDate { get; set; }
        public string AuthToken { get; set; }
    }
}

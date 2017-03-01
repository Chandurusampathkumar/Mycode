using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Results.Request
{
    public class GetPatientVisitInfoDetailsRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
    }
}

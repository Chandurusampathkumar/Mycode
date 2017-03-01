using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Results.Request
{
   public class GetVisitPaymentSummaryRequest
    {
        public Guid PatientVisitId { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string AuthToken { get; set; }
    }
}

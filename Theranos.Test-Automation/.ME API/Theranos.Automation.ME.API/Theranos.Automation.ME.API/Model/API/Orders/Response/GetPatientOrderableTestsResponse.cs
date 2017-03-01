using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Orders.Response
{
    public class GetPatientOrderableTestsResponse
    {
        public List<PatientSelfTest> Tests { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

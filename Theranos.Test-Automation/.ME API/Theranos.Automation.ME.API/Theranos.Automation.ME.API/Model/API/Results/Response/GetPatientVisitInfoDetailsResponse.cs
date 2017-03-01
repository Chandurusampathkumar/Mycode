using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.External;

namespace Theranos.Automation.ME.API.Model.API.Results.Response
{
    public class GetPatientVisitInfoDetailsResponse
    {
        public List<DisplayPatientVisitDetails> visitDetails { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

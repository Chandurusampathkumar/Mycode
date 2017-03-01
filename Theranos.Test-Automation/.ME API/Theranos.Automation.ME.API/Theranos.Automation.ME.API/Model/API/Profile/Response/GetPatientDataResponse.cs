using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;


namespace Theranos.Automation.ME.API.Model.API.Profile.Response
{
    public class GetPatientDataResponse
    {
        public PatientBasicInfo BasicInfo { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Profile.Request
{
    public class SetPatientGuardianInfoRequest
    {
        public List<GuardianInfo> guardians { get; set; }
        public string authToken { get; set; }
    }
}

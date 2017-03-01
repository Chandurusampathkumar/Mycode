using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Profile.Request
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.SetBasicPatientInfoRequest
    /// </summary>
    public class SetBasicPatientInfoRequest
    {
        public PatientBasicInfo BasicInfo { get; set; }
        public string AuthToken { get; set; }

        public SetBasicPatientInfoRequest( string authToken,PatientBasicInfo basicInfo = null)
         {
            BasicInfo=basicInfo;
            AuthToken = authToken;
         }
    }
}

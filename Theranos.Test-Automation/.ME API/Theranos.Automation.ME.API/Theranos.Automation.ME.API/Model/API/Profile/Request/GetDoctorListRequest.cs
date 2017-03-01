using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Profile.Request
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetDoctorListRequest
    /// </summary>
    public class GetDoctorListRequest
    {
        public Doctor DoctorInfo { get; set; }
        public string AuthToken { get; set; }

        public GetDoctorListRequest(Doctor doctorInfo, string authToken)
        {
            DoctorInfo = doctorInfo;
            AuthToken = authToken;
        }
    }
}

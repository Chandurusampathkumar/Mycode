using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Tests.Request
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetPanelDetailsRequest
    /// </summary>
    public class GetPanelDetailsRequest
    {
        public string TheranosId { get; set; }
        public string AuthToken { get; set; }

        public GetPanelDetailsRequest(string theranosId,string authToken)
        {
            TheranosId = theranosId;
            AuthToken = authToken;
        }
    }
}

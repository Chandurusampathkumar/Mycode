using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Tests.Request
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetCptPanelMembersRequest
    /// </summary>
    public class GetCptPanelMembersRequest
    {
        public string CptCodeList { get; set; }
        public string AuthToken { get; set; }

        public GetCptPanelMembersRequest(string authToken)
        {
            AuthToken = authToken;
        }

        public GetCptPanelMembersRequest(string authToken,string cptCodeList)
        {
            CptCodeList = cptCodeList;
            AuthToken = authToken;
        }
    }
}

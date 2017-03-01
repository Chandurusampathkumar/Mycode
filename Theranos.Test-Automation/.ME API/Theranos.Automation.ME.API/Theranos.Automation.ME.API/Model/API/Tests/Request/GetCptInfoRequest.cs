using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Tests.Request
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetCptInfoRequest
    /// </summary>
    public class GetCptInfoRequest
    {
        public string CptCodeList { get; set; }
        public bool IncludeInactiveCpt { get; set; }

        public GetCptInfoRequest(string cptCodeList,bool includeInactiveCpt)
        {
            CptCodeList = cptCodeList;
            IncludeInactiveCpt = includeInactiveCpt;
        }
    }
}

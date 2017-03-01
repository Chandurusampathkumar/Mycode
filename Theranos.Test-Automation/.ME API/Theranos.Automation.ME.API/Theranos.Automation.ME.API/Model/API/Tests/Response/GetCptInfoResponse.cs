using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Tests.Response
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetCptInfoResponse
    /// </summary>
    public class GetCptInfoResponse
    {
        public List<CPTInfo> CptList { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

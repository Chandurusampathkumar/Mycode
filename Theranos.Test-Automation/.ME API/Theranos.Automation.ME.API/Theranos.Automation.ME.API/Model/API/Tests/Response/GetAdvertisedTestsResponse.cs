using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Tests.Response
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetAdvertisedTestsResponse
    /// </summary>
    public class GetAdvertisedTestsResponse
    {
        public List<string> CptCodes { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

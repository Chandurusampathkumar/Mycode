using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.Models;

namespace Theranos.Automation.ME.API.Model.API.Tests.Response
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.Api.GetAllTestsResponse
    /// </summary>
    public class GetAllTestsResponse  // Adopted API-V5
    {
     //   public List<TestInfo> Tests { get; set; }  // Not part of Response. Kept to support populating Staging & Production user accounts.

        public List<TestInfo> Cpts { get; set; }
        public List<TestInfo> Panels { get; set; }
        public List<TestInfo> TestSets { get; set; }

        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }


}

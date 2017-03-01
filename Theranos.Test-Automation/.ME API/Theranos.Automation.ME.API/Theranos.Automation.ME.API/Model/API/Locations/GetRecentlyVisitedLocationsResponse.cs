using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Locations
{
    public class GetRecentlyVisitedLocationsResponse
    {
        public List<GetRecentlyVisitedLocations_Result> Locations { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

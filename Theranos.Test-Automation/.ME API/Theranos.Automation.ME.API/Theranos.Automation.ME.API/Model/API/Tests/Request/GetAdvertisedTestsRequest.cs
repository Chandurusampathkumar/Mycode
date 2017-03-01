using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Tests.Request
{
    public class GetAdvertisedTestsRequest
    {
        public string LocationState { get; set; }
        public string AuthToken { get; set; }

        public GetAdvertisedTestsRequest(string authToken, string locationState)
        {
            LocationState = locationState;
            AuthToken = authToken;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.General.Response
{
    public class CommunicateToUserResponse
    {
        public string SendPinTo { get; set; }
        public string UserMessage { get; set; }
        public string UserContactInfo { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }

    }
}

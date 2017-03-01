using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.General.Request
{
    public class AuthRequest
    {
        public string AuthToken { get; set; }

        public AuthRequest()
        {

        }
        public AuthRequest(string authToken)
        {
            AuthToken = authToken;
        }
    }
}

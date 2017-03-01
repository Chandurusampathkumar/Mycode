using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Account.Response
{
    public class LoginResponse
    {
        public string AuthToken { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}

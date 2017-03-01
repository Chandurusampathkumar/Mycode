using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class WebLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public WebLoginRequest()
        {

        }

        public WebLoginRequest(BasicInfo basicInfo)
        {
            UserName = basicInfo.UserName;
            Password = basicInfo.Password;
        }
    }

  
}

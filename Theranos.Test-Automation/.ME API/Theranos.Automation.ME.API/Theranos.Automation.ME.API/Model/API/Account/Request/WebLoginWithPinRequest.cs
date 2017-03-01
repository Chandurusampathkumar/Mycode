using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class WebLoginWithPinRequest
    {
        public string PinNumber { get; set; }
        public bool RememberDevice { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public WebLoginWithPinRequest()
        {

        }

        public WebLoginWithPinRequest(BasicInfo basicInfo,string PINnumber)
        {
            UserName = basicInfo.UserName;
            Password = basicInfo.Password;
            RememberDevice = true;
            PinNumber = PINnumber;
        }
    }
}

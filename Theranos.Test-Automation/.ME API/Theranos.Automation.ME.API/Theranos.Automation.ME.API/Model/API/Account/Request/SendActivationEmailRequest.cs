using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class SendActivationEmailRequest
    {
         public string UserName { get; set; }

                public SendActivationEmailRequest()
                {

                }

                public SendActivationEmailRequest(string uname)
                {
                    UserName = uname;
                }

                public SendActivationEmailRequest(BasicInfo basicInfo)
                {
                    UserName = basicInfo.UserName;
                }
    }
}

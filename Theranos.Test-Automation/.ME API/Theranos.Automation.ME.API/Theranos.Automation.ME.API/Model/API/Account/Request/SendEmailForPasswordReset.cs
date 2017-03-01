using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class SendEmailForPasswordResetRequest
    {
        public string UserName { get; set; }

                public SendEmailForPasswordResetRequest()
                {

                }

                public SendEmailForPasswordResetRequest(string uname)
                {
                    UserName = uname;
                }

                public SendEmailForPasswordResetRequest(BasicInfo basicInfo)
                {
                    UserName = basicInfo.UserName;
                }
          
    }


}

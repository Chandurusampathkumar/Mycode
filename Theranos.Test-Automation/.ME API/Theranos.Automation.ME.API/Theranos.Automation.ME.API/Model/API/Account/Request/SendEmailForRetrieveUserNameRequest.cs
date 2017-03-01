using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class SendEmailForRetrieveUserNameRequest
    {
          public string emailAddress { get; set; }

                        public SendEmailForRetrieveUserNameRequest()
                        {

                        }

                        public SendEmailForRetrieveUserNameRequest(string email)
                        {
                            emailAddress = email;
                        }

                        public SendEmailForRetrieveUserNameRequest(BasicInfo basicInfo)
                        {
                            emailAddress = basicInfo.EmailAddress;
                        }
    }
}

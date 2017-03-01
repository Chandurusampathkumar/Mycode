using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class GetSecurityQuestionsRequest
    {
         public string UserName { get; set; }
         public string AuthToken { get; set; }

                public GetSecurityQuestionsRequest()
                {

                }

                public GetSecurityQuestionsRequest(string userName,string authToken)
                {
                    UserName = userName;
                    AuthToken = authToken;
                }
    }
}

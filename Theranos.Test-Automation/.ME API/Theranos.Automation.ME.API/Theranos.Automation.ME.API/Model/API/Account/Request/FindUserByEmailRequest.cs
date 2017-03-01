using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;


namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class FindUserByEmailRequest
    {
        public string UserName { get; set; }

                public FindUserByEmailRequest()
                {

                }

                public FindUserByEmailRequest(string uname)
                {
                    UserName = uname;
                }

                public FindUserByEmailRequest(BasicInfo basicInfo)
                {
                    UserName = basicInfo.UserName;
                }
          
    }
}

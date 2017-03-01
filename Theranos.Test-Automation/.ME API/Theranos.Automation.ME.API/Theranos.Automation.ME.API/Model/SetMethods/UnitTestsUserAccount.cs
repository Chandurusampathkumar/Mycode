using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Newtonsoft.Json;

namespace Theranos.Automation.ME.API.Model.SetMethods
{
    public class UnitTestsUserAccount : RestSharpLib
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string dob { get; set; }

        public UnitTestsUserAccount()
        {
            var accData = ReadCsv<UserAccount>("UnitTestsUserAccount.csv");
            var account = accData.ElementAt(0);
            username = account.username;
            password = account.password;
            email = account.email;
            dob = account.dob;
        }
    }
}

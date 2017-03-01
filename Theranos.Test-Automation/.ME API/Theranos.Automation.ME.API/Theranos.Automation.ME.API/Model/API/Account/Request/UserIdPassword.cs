using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.AuthenticationService;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class UserIdPassword
    {
        public string ApplicationName { get; set; }
        public string AuthToken { get; set; }
        public string Comments { get; set; }
        public string EmailAddress { get; set; }
        public UserInfo NameInfo { get; set; }
        public string NewPassword { get; set; }
        public string PINNumber { get; set; }
        public string Password { get; set; }
        public string RequestingUser { get; set; }
        public List<string> RolesToAdd { get; set; }
        public List<SecurityQuestion> SecurityQuestions { get; set; }
        public static Guid UserId { get; set; }
        public static string UserName { get; set; }
        
    }
}

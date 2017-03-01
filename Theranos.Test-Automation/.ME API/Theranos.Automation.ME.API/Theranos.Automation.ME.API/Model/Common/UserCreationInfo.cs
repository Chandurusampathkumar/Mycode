using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Model.Common.AuthenticationService;

namespace Theranos.Automation.ME.API.Model.Common
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.UserCreationInfo
    /// </summary>
    public class UserCreationInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public List<SecurityQuestion> SecurityQuestions { get; set; }

        public UserCreationInfo()
        {

        }

        public UserCreationInfo(BasicInfo basicInfo)
        {
            UserName = basicInfo.UserName;
            Password = basicInfo.Password;
            EmailAddress = basicInfo.EmailAddress;
            SecurityQuestions = new List<SecurityQuestion>();
            SecurityQuestions.Add(new SecurityQuestion(basicInfo.Question1, basicInfo.Answer1));
            SecurityQuestions.Add(new SecurityQuestion(basicInfo.Question2, basicInfo.Answer2));
            SecurityQuestions.Add(new SecurityQuestion(basicInfo.Question3, basicInfo.Answer3));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.AuthenticationService
{
    public class SecurityQuestion
    {
        public string Answer { get; set; }
        public string Question { get; set; }

        public SecurityQuestion()
        {

        }

        public SecurityQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}

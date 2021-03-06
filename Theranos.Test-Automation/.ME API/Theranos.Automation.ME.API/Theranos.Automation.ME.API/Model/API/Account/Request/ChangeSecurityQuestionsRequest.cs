﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class ChangeSecurityQuestionsRequest
    {
        public string UserName { get; set; }
        public List<string> SecurityQuestions { get; set; }
        public string AuthToken { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Account.Response
{
    public class UserMessageResponse
    {
        public string UserMessage { get; set; }
        public ErrorCodes Code{get;set;}
        public string Message { get; set; }
    }
}

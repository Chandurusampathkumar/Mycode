﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class GetListOfServicesResponse
    {
        public List<AvailableServices> ServicesAvailable { get; set; }
        public ErrorCodes Code {get;set;}
        public string Message {get;set;}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Orders.Request
{
    public class GetLabOrdersRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AuthToken { get; set; }
    }
}

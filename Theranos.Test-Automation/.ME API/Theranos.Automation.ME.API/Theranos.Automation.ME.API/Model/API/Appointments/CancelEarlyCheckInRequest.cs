﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Appointments
{
    public class CancelEarlyCheckInRequest
    {
        public int EarlyCheckInId { get; set; }
        public string AuthToken { get; set; }
    }
}

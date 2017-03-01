using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class TimeZoneData
    {
        public int DaylightOffset { get; set; }
        public bool IsCurrentTimeDaylightSavingsTime { get; set; }
        public int StandardOffset { get; set; }
        public bool SupportsDaylightSavingsTime { get; set; }
        public string UnicodeTimeZoneId { get; set; }
        public string WindowsTimeZoneId { get; set; }

    }
}

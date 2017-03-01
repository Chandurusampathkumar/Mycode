using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class HolidayInfo
    {
        public DateTime HolidayDate { get; set; }
        public string HolidayHours { get; set; }
        public int HolidayId { get; set; }
        public List<HolidayDescription> HolidayNames { get; set; }
        public bool IsTrueHoliday{get;set;}
        public Guid LocationId{get;set;}
    }
}

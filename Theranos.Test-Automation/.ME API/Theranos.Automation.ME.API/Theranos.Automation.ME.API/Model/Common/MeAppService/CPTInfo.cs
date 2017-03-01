using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class CPTInfo
    {
        public string CPTCode { get; set; }
        public int CPTCodeId { get; set; }
        public decimal CPTPrice { get; set; }
        public string Description { get; set; }
        public int FastingHours { get; set; }
        public bool IsCPTValid { get; set; }
        public string MarketingCode { get; set; }
        public string ModifierCode { get; set; }
        public string SelfOrderableStates { get; set; }
    }
}

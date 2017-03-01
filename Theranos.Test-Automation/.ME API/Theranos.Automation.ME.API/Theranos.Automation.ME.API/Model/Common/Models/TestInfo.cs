using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.External;
namespace Theranos.Automation.ME.API.Model.Common.Models
{
    public class TestInfo  // Adopted API-V5 
    {
        public Int64 Type { get; set; }
        public string CptCode { get; set; }
        public int CptCodeId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int FastingHours { get; set; }
        public bool IsValid {get;set;}
        public string MarketingCode { get; set; }
        public List<string> SelfOrderableStates { get; set; }
        public int TestSetId { get; set; }
        public List<int> Tests { get; set; }

       // public bool IsPanel { get; set; }
       // public PanelInfo Panel { get; set; }
       // public string State { get; set; }
       // public string TestType { get; set; }
       // public int CPTCodeId { get; set; }
       // public string CPTCode { get; set; }
       // public string ModifierCode { get; set; }
       // public string Description { get; set; }
       // public string MarketingCode { get; set; }
       // public decimal CPTPrice { get; set; }
       // public bool IsCPTValid { get; set; }
       // public int FastingHours { get; set; }
       // public string SelfOrderableStates { get; set; }
    }
}

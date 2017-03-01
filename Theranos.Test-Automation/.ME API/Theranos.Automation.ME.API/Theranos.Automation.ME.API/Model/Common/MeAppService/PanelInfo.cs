using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class PanelInfo
    {
        public string PanelCPTCode { get; set; }
        public int PanelCPTCodeId { get; set; }
        public string PanelCPTDescription { get; set; }
        public int PanelId { get; set; }
        public string PanelName { get; set; }
        public decimal PanelPrice { get; set; }
        public List<CPTInfo> PanelTests { get; set; }
        public string PanelType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class SampleBasicInfoModel:BasicInfoModel
    {
        public List<BasicInfoModel> basic { get; set; }
        public string duration { get; set; }
        public string count { get; set; }
        public string name { get; set; }
    }
}

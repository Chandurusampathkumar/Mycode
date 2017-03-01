using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class SampleModel:SampleBasicInfoModel
    {
        public List<SampleBasicInfoModel> sample { get; set; }
    }
}

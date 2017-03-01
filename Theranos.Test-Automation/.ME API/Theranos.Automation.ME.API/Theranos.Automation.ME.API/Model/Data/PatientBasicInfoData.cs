using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.Data
{
    public class PatientBasicInfoData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
        public string mobilePhoneNo { get; set; }
        public List<PatientAddressInfo> addresses { get; set; }

    }
}

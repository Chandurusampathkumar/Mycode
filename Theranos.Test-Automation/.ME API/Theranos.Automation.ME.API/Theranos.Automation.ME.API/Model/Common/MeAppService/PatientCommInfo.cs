using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class PatientCommInfo
    {
        public string CommAddress { get; set; }
        public CommAddressType CommAddressType { get; set; }
        public UserIDType CommUserIdType { get; set; }
        public Boolean IsAddressVerified { get; set; }
    }
}

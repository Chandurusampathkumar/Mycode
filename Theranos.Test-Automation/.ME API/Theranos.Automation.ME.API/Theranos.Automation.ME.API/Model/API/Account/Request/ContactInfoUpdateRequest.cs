using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class ContactInfoUpdateRequest
    {
        public CommAddressType ContactInfoType { get; set; }
        public string NewContactInfoValue { get; set; }
        public string AuthToken { get; set; }
    }
}

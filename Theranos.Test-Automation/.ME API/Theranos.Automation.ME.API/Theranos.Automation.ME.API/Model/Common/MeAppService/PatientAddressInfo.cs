using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.PatientAddressInfo
    /// </summary>
    public class PatientAddressInfo
    {
        public static string InputFileName = "AddressDataSetAPI.csv";
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsMailingAddress { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}

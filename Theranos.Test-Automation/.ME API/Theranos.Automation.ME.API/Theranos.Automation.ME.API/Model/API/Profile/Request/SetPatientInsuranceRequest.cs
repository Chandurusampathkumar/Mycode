using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Profile.Request
{
    public class SetPatientInsuranceRequest
    {
        public List<PatientInsurance> Insurances { get; set; }
        public string AuthToken { get; set; }
    }
}

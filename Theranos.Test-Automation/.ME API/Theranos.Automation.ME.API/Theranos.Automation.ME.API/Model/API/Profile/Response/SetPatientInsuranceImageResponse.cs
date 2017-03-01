using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Profile.Response
{
    public class SetPatientInsuranceImageResponse
    {
        public Guid ImageId { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

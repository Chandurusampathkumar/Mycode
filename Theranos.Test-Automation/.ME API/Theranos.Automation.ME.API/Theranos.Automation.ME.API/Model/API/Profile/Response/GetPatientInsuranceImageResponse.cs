using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Profile.Response
{
    public class GetPatientInsuranceImageResponse
    {
        public string ImageContent { get; set; }
        public string ImageType { get; set; }
        public string ImageContentType { get; set; }
        public int InsuranceId { get; set; }
        public Guid ImageId { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

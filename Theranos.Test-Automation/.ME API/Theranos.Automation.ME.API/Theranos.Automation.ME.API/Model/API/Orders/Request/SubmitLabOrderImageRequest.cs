using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Orders.Request
{
    public class SubmitLabOrderImageRequest
    {
        public string ImageData { get; set; }
        public string LabOrderName { get; set; }
        public string ImageContentType { get; set; }
        public Guid LabOrderId { get; set; }
        public string AuthToken { get; set; }

        //internal void ImageData(string p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

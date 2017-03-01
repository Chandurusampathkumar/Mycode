using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.MEAppInfo
    /// </summary>
    public class MEAppInfo
    {
        public string AppKey { get; set; }
        public string AppVersion { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string CertFileName { get; set; }
        public string CertPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsProduction { get; set; }
        public string Platform { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool PublishedToProduction { get; set; }
    }
}

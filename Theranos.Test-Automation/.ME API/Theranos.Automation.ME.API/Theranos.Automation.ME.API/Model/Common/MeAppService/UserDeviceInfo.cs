using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.UserDeviceInfo
    /// </summary>
    public class UserDeviceInfo
    {
        public int ApplicationId { get; set; }
        public string DeviceId { get; set; }
        public string NotificationStatus { get; set; }
        public string OldDeviceId { get; set; }
        public Guid PatientId { get; set; }
        public string Platform { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.Specialty
    /// </summary>
    public class Specialty
    {
        public string SpecialtyName { get; set; }
        public string SubSpecialty { get; set; }
    }
}

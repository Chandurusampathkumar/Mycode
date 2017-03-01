using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.InsuranceCo
    /// </summary>
    public class InsuranceCo
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        //public InsuranceCo(string companyName)
        //{
        //    CompanyName = companyName;
        //}
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.PatientInsurance
    /// </summary>
    public class PatientInsurance
    {
        public int InsuranceId { get; set; }
        public string InsuranceName { get; set; }
        public Guid CompanyId { get; set; }
        public string PlanId { get; set; }
        public string PlanType { get; set; }
        public string PlanCode { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string Status { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredMiddleName { get; set; }
        public DateTime InsuredDOB { get; set; }
        public string RelationshipToInsured { get; set; }
        public int InsuranceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Guid> ImageIds { get; set; }
    }
}

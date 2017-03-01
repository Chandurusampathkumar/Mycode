using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.Doctor
    /// </summary>
    public class Doctor
    {
        public string Address1 { get;set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DoctorLocationId { get; set; }
        public string EmailAddress { get; set; }
        public string FaxNumber { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public bool IsPrimary { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string OrgName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Specialty> Specialties { get; set; }
        public string State { get;set;}
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Zip { get; set; }

        //public Doctor(string zip)
        //{
        //    Zip = zip;
        //}

    }
}

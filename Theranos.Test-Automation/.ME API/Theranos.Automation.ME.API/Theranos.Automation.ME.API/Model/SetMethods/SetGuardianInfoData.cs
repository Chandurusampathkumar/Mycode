using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.SetMethods
{
    public class SetGuardianInfoData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string relationship { get; set; }
        public string homePhoneNo { get; set; }
        public string emailAddress { get; set; }
        public DateTime dob { get; set; }
    //    public Guid guardianId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class AddMoreContactDetailsModel:PSC3Model
    {
        public const string AddMoreContactsInputFileName = "AddMoreContactDetailsDataSet.csv";

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Status { get; set; }
        public string AgeGroup { get; set; }

    }
}

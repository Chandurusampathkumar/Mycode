using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Profile.Request
{
    public class UpdatePatientEmailAddressRequest
  {
        public string OldEmailAddress { get; set; }
        public string NewEmailAddress { get; set; }
        public string AuthToken { get; set; }


    public UpdatePatientEmailAddressRequest(string authtoken, string oldEmailAddress, string newEmailAddress)
    {
    AuthToken=authtoken;
    OldEmailAddress=oldEmailAddress;
    NewEmailAddress=newEmailAddress;
    }

  }
}

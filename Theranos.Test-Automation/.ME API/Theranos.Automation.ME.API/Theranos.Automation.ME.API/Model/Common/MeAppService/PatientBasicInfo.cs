using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Scripts;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.PatientBasicInfo
    /// </summary>
    public class PatientBasicInfo
    {
        
        public List<PatientAddressInfo> Addresses { get; set; }
        public List<PatientCommInfo> AlternateAddresses { get; set; }
        public DateTime DOB { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string HomePhoneNo { get; set; }
        public bool IsBlackListed { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobilePhoneNo { get; set; }
        public Guid? PatientId { get; set; }
        public string PatientUserPIN { get; set; }
        public string PreferredMethodOfContact { get; set; }
        public string Sex { get; set; }
        public string Suffix { get; set; }
        public string WorkPhoneNo { get; set; }
      
       /*         public PatientBasicInfo (BasicInfo basicInfo)
                {
                    Addresses.Add(Scripts.Scripts.GetNewBillingAddress());
                    Addresses.Add(Scripts.Scripts.GetNewMailingAddress());
                    DOB=Convert.ToDateTime(basicInfo.DOB.Replace("'",""));
                    EmailAddress = basicInfo.EmailAddress;
                    FirstName = basicInfo.FirstName;
            
                    LastName = basicInfo.LastName;
                    MiddleName = basicInfo.MI;
                    MobilePhoneNo = basicInfo.PhoneNo;
                }
        */
    }
}

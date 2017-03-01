using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScenarios;

namespace Theranos.Automation.ME.Android.TestSuite
{
  
    public class BasicIfoSuite : BasicInfoScenarios
    {
      
        public void BasicinfoST()
        {
            ACC_BasicInfoScripts();
            ACC_BasicInfoDateOfBirth();
            ACC_BasicInfoGender();
            ACC_LinkedAccountMailingAddress();
            ACC_ProvisionalAccountMailingAddress();
            ACC_LinkedAccountBasicInfoPage();
            ACC_BasicInfoMobile();
            ACC_AddEmergencyContactspage();
            ACC_EditEmergencyContact();
            ACC_RemoveEmergencyValidation();
            ACC_RemoveEmergencyContact();
        }
    }
}

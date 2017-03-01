using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScenarios;

namespace Theranos.Automation.ME.Android.TestSuite
{
   
    public class InsuranceSuite : InsuranceScenarios
    {
        
        public void InsuranceMethod()
        {
            ACC_AddInsurancepage();
            ACC_RemoveInsurance();

        }
    }
}

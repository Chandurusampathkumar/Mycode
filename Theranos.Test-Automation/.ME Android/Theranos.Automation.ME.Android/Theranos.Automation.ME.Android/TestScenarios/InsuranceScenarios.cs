using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.TestScripts.Insurance;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestScenarios
{
    [TestClass]
    public class InsuranceScenarios : ScreenShot
    {
        LoginValidation LV = new LoginValidation();
        AccountScripts AS = new AccountScripts();
        InsuranceScripts SS = new InsuranceScripts();

        [TestMethod]
        public void ACC_RemoveInsurance()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            SS.InsurancePage(LaunchActivity.driver);
            SS.RemoveInsurance(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void ACC_AddInsurancepage()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            SS.InsurancePage(LaunchActivity.driver);
            SS.AddInsurancepage(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_SelectedInsuranceDisplayed() 
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            SS.InsurancePage(LaunchActivity.driver);
            SS.SelectedInsuranceDisplayed(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
    }
}

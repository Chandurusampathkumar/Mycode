using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestScenarios
{
    [TestClass]
    public class UnLinkAccScenario : ScreenShot
    {
        LoginValidation LS = new LoginValidation();
        UnLinkAccScripts UL = new UnLinkAccScripts();

        [TestMethod]
        public void UNACC_AccountUserName()
        {
            LaunchActivity.launchapp();
            LS.LoginUnLinkedAcc(LaunchActivity.driver);
            UL.UnLinkAccountPage(LaunchActivity.driver);
            UL.UnLinkAccountUserName(LaunchActivity.driver);
            UL.UnLinkAccountToDashBoard(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void UNACC_PasswordUpdate()
        {
            LaunchActivity.launchapp();
            LS.LoginUnLinkedAcc(LaunchActivity.driver);
            UL.UnLinkAccountPage(LaunchActivity.driver);
            UL.UnLinkAccountPasswordUpdate(LaunchActivity.driver);
            UL.UnLinkAccountToDashBoard(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
        }
              
        [TestMethod]
        public void UNACC_PasscodeValidation() 
        {
            LaunchActivity.launchapp();
            LS.LoginUnLinkedAcc(LaunchActivity.driver);
            UL.UnLinkAccountPage(LaunchActivity.driver);
            UL.UnLinkPasscodeValidation(LaunchActivity.driver);

        }
    }
}

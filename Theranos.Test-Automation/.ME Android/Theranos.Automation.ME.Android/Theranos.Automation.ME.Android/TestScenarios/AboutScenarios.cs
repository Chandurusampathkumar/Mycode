using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;

namespace Theranos.Automation.ME.Android.TestScenarios
{
    [TestClass]
    public class AboutScenarios
    {
        LoginValidation LV = new LoginValidation();
        About Abt = new About();

        [TestMethod]
        public void AboutPagIsDisplayed()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Abt.Aboutpage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ThirdPartyPageIsDisplayed()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Abt.ThirdPartyPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void PrivacyPolicyPageIsDisplayed() 
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Abt.PrivacyPolicyPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void SecurityPageIsDisplayed()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Abt.SecurityPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void TermPageIsDisplayed()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Abt.TermPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
    }
}

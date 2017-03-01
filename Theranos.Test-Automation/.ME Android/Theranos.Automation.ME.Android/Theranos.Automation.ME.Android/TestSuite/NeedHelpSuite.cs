using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts.NeedForHelp;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.MeWeb;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestSuite
{
    [TestClass]
    public class NeedHelpSuite : ScreenShot
    {
        NeedForHelp RL = new NeedForHelp();
        CreateAccountPage CP = new CreateAccountPage();
        YopActivation YA = new YopActivation();
        LoginValidation LV = new LoginValidation();

        [TestMethod]
        public void Need_ActivateLink()
        {
            LaunchActivity.launchapp();
            RL.ActivationLink(LaunchActivity.driver);
        }
        [TestMethod]
        public void Need_PasswordResetValidUser()
        {
            LaunchActivity.launchapp();
            RL.ResetPasswordValidUser(LaunchActivity.driver);
        }
        [TestMethod]
        public void Need_PasswordResetInValidUser()
        {
            LaunchActivity.launchapp();
            RL.ResetPasswordInValidUser(LaunchActivity.driver);
        }
        [TestMethod]
        public void Need_RetrieveActiveUserName()
        {
            LaunchActivity.launchapp();
            RL.RetrieveActiveUserName(LaunchActivity.driver);
        }
        [TestMethod]
        public void Need_RetrieveNonActiveUserName()
        {
            LaunchActivity.launchapp();
            RL.RetrieveNonActiveUserName(LaunchActivity.driver);
        }
         [TestMethod]
        public void ActivateUserResendEmail()
        {
            LaunchActivity.launchapp();
            CP.CreateAccount(LaunchActivity.driver);
            RL.ResendActivationLink(LaunchActivity.driver);
            YA.ActivateYopmail();
            LV.LoginSignUpUserProvisional(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);



        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.MeWeb;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestSuite
{
    [TestClass]
    public class LoginSuite : ScreenShot
    {
        LoginValidation LS = new LoginValidation();
        UnLinkAccScripts UL = new UnLinkAccScripts();
        CreateAccountPage CA = new CreateAccountPage();
        YopActivation YA = new YopActivation();
        UserInfoSuite US = new UserInfoSuite();

        [TestMethod]
        public void LSLoginValid()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void InvaildUser()
        {
            LaunchActivity.launchapp();
            LS.InvalidUserName(LaunchActivity.driver);
        }
        [TestMethod]
        public void InvaildPass()
        {
            LaunchActivity.launchapp();
            LS.InvalidPassWord(LaunchActivity.driver);
        }
        [TestMethod]
        public void InvaildCredetial()
        {
            LaunchActivity.launchapp();
            LS.InvalidCredentials(LaunchActivity.driver);
        }
        [TestMethod]
        public void Inactiveacc()
        {
            LaunchActivity.launchapp();
            LS.InActivateAccount(LaunchActivity.driver);
        }
        [TestMethod]
        public void BlockAcc()
        {
            LaunchActivity.launchapp();
            LS.BlockedAccount(LaunchActivity.driver);

        }
        [TestMethod]
        public void SequentialLogin()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
            LS.LoginUnLinkedAcc(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
            LS.LoginUnLinkedAcc(LaunchActivity.driver);
            UL.UnLinkAccountPage(LaunchActivity.driver);
            UL.UnLinkAccountUserName(LaunchActivity.driver);
            UL.UnLinkAccountToDashBoard(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
        }
        /// <summary>
        /// This test method should be insert in order suite after newly signUp method.And make sure VPN is 
        /// connected before running this method.
        /// </summary>
        [TestMethod]
        public void ResendActivateAccount()
        {
            LaunchActivity.launchapp();
            LS.ResendEmailActivate(LaunchActivity.driver);
            YA.ActivateYopmail();
            LS.LoginSignUpUserProvisional(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
        }




    }
}

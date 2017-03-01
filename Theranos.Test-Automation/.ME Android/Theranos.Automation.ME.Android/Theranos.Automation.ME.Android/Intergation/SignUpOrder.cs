using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.MeWeb;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestSuite;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.Intergation
{
    [TestClass]
    public class SignUpOrder : ScreenShot
    {
        CreateAccountPage CA = new CreateAccountPage();
        YopActivation YA = new YopActivation();
        UserInfoSuite US = new UserInfoSuite();
        LoginValidation Login = new LoginValidation();

        [TestMethod]
        public void SignUpProvisionalAcc()
        {
            LaunchActivity.launchapp();
            CA.CreateAccount(LaunchActivity.driver);
            YA.ActivateYopmail();
            US.ProvisionAccount();

        }
        [TestMethod]
        public void SignUpLinkAcc()
        {
            LaunchActivity.launchapp();
            CA.CreateAccount(LaunchActivity.driver);
            YA.ActivateYopmail();
            US.LinkAccountFromPSC();
        }
        [TestMethod]
        public void LinkAccFromDashBoard()
        {
            LaunchActivity.launchapp();
            CA.CreateAccount(LaunchActivity.driver);
            YA.ActivateYopmail();
            US.DashBoardToLinkAccount();
        }
        [TestMethod]
        public void SignUpProvisionalUploadOrder()
        {
            LaunchActivity.launchapp();
            CA.CreateAccount(LaunchActivity.driver);
            YA.ActivateYopmail();
            US.ProvisionAccountUploadOrder();

        }
    }
}

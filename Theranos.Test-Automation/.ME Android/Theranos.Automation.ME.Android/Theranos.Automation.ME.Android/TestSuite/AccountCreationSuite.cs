using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestSuite
{
    [TestClass]
    public class AccountCreationSuite:ScreenShot
    {
        
        CreateAccountPage CA = new CreateAccountPage();
        
        [TestMethod]
        public void SignupnewAccount()
        {
            LaunchActivity.launchapp();
            CA.CreateAccount(LaunchActivity.driver);
            CA.AlreadyCreatedAccount(LaunchActivity.driver);
        }
        
        [TestMethod]
        public void SignUpInvalidEmail()
        {
            LaunchActivity.launchapp();
            CA.CreatedAccount_InvalidEmail(LaunchActivity.driver);
        }
        [TestMethod]
        public void SignUpInvalidUserName()
        {
            LaunchActivity.launchapp();
            CA.CreatedAccount_InvalidUsername(LaunchActivity.driver);
        }
        [TestMethod]
        public void SignUpAgeValidation()
        {
            LaunchActivity.launchapp();
            CA.AgeValidation(LaunchActivity.driver);
        }
        [TestMethod]
        public void SignUpInValidPasswordSevenChar()
        {
            LaunchActivity.launchapp();
            CA.InvalidPasswordSevenChar(LaunchActivity.driver);

        }
        [TestMethod]
        public void SignUpInValidPasswordNoUpper() 
        {
            LaunchActivity.launchapp();
            CA.InvalidPasswordNoUpperChar(LaunchActivity.driver);

        }
        [TestMethod]
        public void SignUpInValidPasswordNoLower()
        {
            LaunchActivity.launchapp();
            CA.InvalidPasswordNoLowerChar(LaunchActivity.driver);

        }
        [TestMethod]
        public void SignUpInValidPasswordNoNumeric()
        {
            LaunchActivity.launchapp();
            CA.InvalidPasswordNoNumeric(LaunchActivity.driver);

        }
        [TestMethod]
        public void SignUpSigleSecurityAns()
        {
            LaunchActivity.launchapp();
            CA.OnesecurityAns(LaunchActivity.driver);
        }
        [TestMethod]
        public void SignUpTwoSecurityAns()
        {
            LaunchActivity.launchapp();
            CA.twosecurityAns(LaunchActivity.driver);
        }
          //  LaunchActivity.AfterAll();

        }
    }


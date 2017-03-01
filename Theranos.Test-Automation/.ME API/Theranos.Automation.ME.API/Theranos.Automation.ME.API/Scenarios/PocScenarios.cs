using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Scripts;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class PocScenarios:Scripts.Scripts
    {
        AccountScripts account = new AccountScripts();
        
        ProfileScripts profile = new ProfileScripts();
        FirstTimeLogin firstTime = new FirstTimeLogin();

        [TestMethod]
        public void Scenario01()
        {
            HttpClientHelper.ClearCookies();
            var basicInfo = GetNewUser();
            
            var createAccountResponse = account.CreateShellUserAccount(basicInfo);
            TestContext.WriteLine("API call \"Account/CreateShellUserAccount\" is successful. New account created for user: {0}", basicInfo.EmailAddress);

            var activationCode = firstTime.GetAccountActivationCode(createAccountResponse.UserContactInfo);
            TestContext.WriteLine("Activation code received through email: {0}", activationCode);

            account.AccountActivation(activationCode);
            TestContext.WriteLine("API call \"Account?activationCode={0}\" is successful. Account is activated", activationCode);

            var loginResponse = account.Login(basicInfo);
            TestContext.WriteLine("API call \"Account/Login\" is successful. AuthToken received: {0}", loginResponse.AuthToken);

            account.VerifyGetAccountEmailAddress(loginResponse.AuthToken, basicInfo.EmailAddress);
            TestContext.WriteLine("API call \"Account/GetAccountEmailAddress\" is successful. Expected email address is returned, i.e. {0}", basicInfo.EmailAddress);
        
            //var loginResponse = account.Login(basicInfo.UserName, basicInfo.Password);
            //account.GetAccountEmailAddress(loginResponse.AuthToken,basicInfo.Email);
        }

        [TestMethod]
        public void Scenario03()
        {
            HttpClientHelper.ClearCookies();
            var basicInfo = GetRandomOldUser();
            var webLoginResponse = account.Login(basicInfo);
            var cookie = HttpClientHelper.AuthCookies;

            //var loginResponse = account.Login(basicInfo.UserName, basicInfo.Password);
            //account.GetAccountEmailAddress(loginResponse.AuthToken,basicInfo.Email);
        }
    }
}

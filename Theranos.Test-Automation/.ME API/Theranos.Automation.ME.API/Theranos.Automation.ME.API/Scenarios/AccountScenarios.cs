using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Model.EndPoint;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Extensions;
using Theranos.Automation.ME.API.Model.Common.AuthenticationService;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Model.SetMethods;
using Theranos.Automation.ME.API.Model.Common;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class AccountScenarios : RestSharpLib
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        FirstTimeLogin firstTime = new FirstTimeLogin();
        RestSharpLib rsl = new RestSharpLib();
        public List<Model.Common.AuthenticationService.SecurityQuestion> SecurityQuestions { get; set; }



        [TestMethod]
        public void LoginNormal()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            object logoutJson = new { loginResult.AuthToken };
            account.logout(client, logoutJson);
        }

        /// Sample method using "string" instead of "Object" as Service request
        public void loginUsingJsonString()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login
            string mno = "{ \"userName\": \"oneasd\", \"password\": \"Abcd1234\"}";
            var res = account.loginWithJsonString(client, mno);
        }

        [TestMethod]
        public void logout()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            //logout
            object logoutJson = new { authToken = Token };
            var logoutResp = account.logout(client, logoutJson);
        }

        [TestMethod]
        public void findUserByEmail()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;           
            //findUserByEmail
            object findUserByEmailJson = new { username = ExcelValues.UserName };
            var findUserByEmailResp = account.findUserByEmail(client, findUserByEmailJson);
        }

        [TestMethod]
        public void sendEmailForRetrieveUserName()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;            
            //findUserByEmail
            Console.WriteLine("Email : " + ExcelValues.Email);
            object sendEmailforRetrUserNameJson = new { emailAddress = ExcelValues.Email };
            var sendEmailForRetrieveUserNameResp = account.sendEmailForRetrieveUserName(client, sendEmailforRetrUserNameJson);
        }

        [TestMethod]
        public void getAccountEmailAddress()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            //getAccountEmailAddress
            object getAccEmailAddRespJson = new { authToken = Token };
            var getAccountEmailAddressResp = account.getAccountEmailAddress(client, getAccEmailAddRespJson);
            //Logout
            object logoutJson = new { loginResult.AuthToken };
            account.logout(client, logoutJson);
        }

        [TestMethod]
        public void sendEmailForPasswordReset()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // sendEmailForPasswordReset
            object sendEmailForPwResetJson = new { username = ExcelValues.UserName };
            var sendEmailForPasswordResetResp = account.sendEmailForPasswordReset(client, sendEmailForPwResetJson);
        }

        [TestMethod]
        public void webLoginOnNewDevice()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Weblogin 
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var webLoginResult = account.webLogin(client, loginJson);
            int resultCode = (int)webLoginResult.Code;
            Console.WriteLine("Result Code : " + resultCode);
            if (resultCode != 301)
                throw (new Exception(" Result is not as Expected "));
        }

        [TestMethod]   
        public void webLoginAsReturningUser()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Weblogin FirstTime
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var webLoginResult = account.webLogin(client, loginJson);
            Console.WriteLine(JsonConvert.SerializeObject(webLoginResult));
            if ((int)webLoginResult.Code != 301)
                throw (new Exception(" Result is not as Expected "));
            // getPin which is require for Two step authentication
            var twoStepPin = account.getTwoStepVerificationCode(ExcelValues.Email);
            // webLoginWithPin
            object webLoginWithPinJson = new { username = ExcelValues.UserName, password = ExcelValues.Password, rememberDevice = "true", pinNumber = twoStepPin };
            var webLoginWithPinResp = account.webLoginWithPin(client, webLoginWithPinJson);
            var Token = webLoginWithPinResp.AuthToken;
            //logout
            object logoutJson = new { authToken = Token };
            var logoutResp = account.logout(client, logoutJson);
            
            // Weblogin as returning user
            Console.WriteLine(" Now Logging in as returning User ");
            var webLoginAsReturningUserResult = account.webLogin(client, loginJson);
            if ((int)webLoginAsReturningUserResult.Code != 0)
                throw (new Exception(" Result not as expected "));
        }

        [TestMethod]
        public void webLoginWithPin()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Weblogin 
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var webLoginResult = account.webLogin(client, loginJson);
            // getPin which is require for Two step authentication
            var twoStepPin = account.getTwoStepVerificationCode(ExcelValues.Email);
            // webLoginWithPin
            object webLoginWithPinJson = new { username = ExcelValues.UserName, password = ExcelValues.Password, rememberDevice = "true", pinNumber = twoStepPin };
            var webLoginWithPinResp = account.webLoginWithPin(client, webLoginWithPinJson);
            // logout
            object logoutJson = new { webLoginWithPinResp.AuthToken };
            account.logout(client, logoutJson);
        }

        [TestMethod]
        public void changePassword()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // changePassword
            Console.WriteLine("Setting new Password");
            object changePasswordJson = new { authToken = Token, username = ExcelValues.UserName, password = ExcelValues.Password, newPassword = "Pqrs6789" };
            var changePwResp = account.changePassword(client, changePasswordJson);
            //logout
            object logoutJson = new { authToken = Token };
            var logoutResp = account.logout(client, logoutJson);
            // Login With New Password
            Console.WriteLine(" Attempting to login with new Password ");
            object loginwithNewPwJson = new { username = ExcelValues.UserName, password = "Pqrs6789" };
            var loginWithNewPwResult = account.loginForAuthToken(client, loginwithNewPwJson);
            // Setback Old Password
            object changePasswordJson1 = new { authToken = loginWithNewPwResult.AuthToken, username = ExcelValues.UserName, password = "Pqrs6789", newPassword = "Abcd1234" };
            var changePwJson1 = account.changePassword(client, changePasswordJson1);
            //logout
            object logoutJson1 = new { authToken = loginWithNewPwResult.AuthToken };
            var logoutResp1 = account.logout(client, logoutJson);
        }

        [TestMethod]
        public void sendActivationEmail()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // sendActivationEmail 
            object sendActivationMailJson = new { username = "NotYetActivated" };
            var sendActivationEmailResp = account.sendActivationEmail(client, sendActivationMailJson);
        }

        [TestMethod]
        public void getSecurityQuestions()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // sendEmailForPasswordReset
            object sendEmailForPwResetJson = new { userName = "oneasdd" };
            var sendEmailForPasswordResetResp = account.sendEmailForPasswordReset(client, sendEmailForPwResetJson);
            // getSecurityQuestions
            var PasswordResetLink = getUrl("oneasdd");
            string[] url = PasswordResetLink.Split('/');
            string PwResetLinkCode = url.Last();
            object getSecQuesJson = new { userName = "oneasdd", PasswordResetLinkCode = PwResetLinkCode };
            var getSecurityQuestionsResp = account.getSecurityQuestions(client, getSecQuesJson);
        }

        [TestMethod]
        public void resetPassword()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // sendEmailForPasswordReset
            object sendEmailForPwResetJson = new { userName = "oneasdd" };
            var sendEmailForPasswordResetResp = account.sendEmailForPasswordReset(client, sendEmailForPwResetJson);
            // getSecurityQuestions
            var PasswordResetLink = getUrl("oneasdd");
            string[] url = PasswordResetLink.Split('/');
            string PwResetLinkCode = url.Last();
            object getSecQuesJson = new { userName = "oneasdd", PasswordResetLinkCode = PwResetLinkCode };
            var getSecurityQuestionsResp = account.getSecurityQuestions(client, getSecQuesJson);
            // resetPassword
            var secQues = new Theranos.Automation.ME.API.Model.Common.AuthenticationService.SecurityQuestion();
            secQues.Question = getSecurityQuestionsResp.SecurityQuestions.ElementAt(0);
            secQues.Answer = "a";
            var secQuesList = new List<Theranos.Automation.ME.API.Model.Common.AuthenticationService.SecurityQuestion>();
            secQuesList.Add(secQues);
            object resetPwJson = new { userName = "oneasdd", newPassword = "Abcd1234", securityQuestions = secQuesList };
            var json = JsonConvert.SerializeObject(resetPwJson);
            Console.WriteLine("Json Request : " + json);
            var resetPasswordResp = account.resetPassword(client, resetPwJson);
        }

        [TestMethod]
        public void createShellUserAccount()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // CreateShellUserAccount
            ExcelValues.Excelindexvalue(CreateShellAccountExcel, 1, "");

                var userInfo = new UserCreationInfo();
                userInfo.EmailAddress = ExcelValues.Email;
                userInfo.UserName = ExcelValues.UserName;
                userInfo.Password = ExcelValues.Password;
                userInfo.SecurityQuestions = new List<SecurityQuestion>();
                var secQue1 = new SecurityQuestion();
                secQue1.Question = ExcelValues.Question1;
                secQue1.Answer = ExcelValues.Answer1;
                userInfo.SecurityQuestions.Add(secQue1);

                var secQue2 = new SecurityQuestion();
                secQue2.Question = ExcelValues.Question2;
                secQue2.Answer = ExcelValues.Answer2;
                userInfo.SecurityQuestions.Add(secQue2);

                var secQue3 = new SecurityQuestion();
                secQue3.Question = ExcelValues.Question3;
                secQue3.Answer = ExcelValues.Answer3;
                userInfo.SecurityQuestions.Add(secQue3);

                object createShellAccJson = new { userInfo };
                Console.WriteLine(" UsesrInfo : " + JsonConvert.SerializeObject(createShellAccJson));
                var createShellUserAccountResp = account.createShellUserAccount(client, userInfo);
        }

        [TestMethod]
        public void activate_activationCode()
        {
                ExcelValues.Excelindexvalue(CreateShellAccountExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // CreateShellUserAccount
                var userInfo = new UserCreationInfo();
                userInfo.EmailAddress = ExcelValues.Email;
                userInfo.UserName = ExcelValues.UserName;
                userInfo.Password = ExcelValues.Password;
                userInfo.SecurityQuestions = new List<SecurityQuestion>();
                var secQue1 = new SecurityQuestion();
                secQue1.Question = ExcelValues.Question1;
                secQue1.Answer = ExcelValues.Answer1;
                userInfo.SecurityQuestions.Add(secQue1);

                var secQue2 = new SecurityQuestion();
                secQue2.Question = ExcelValues.Question2;
                secQue2.Answer = ExcelValues.Answer2;
                userInfo.SecurityQuestions.Add(secQue2);

                var secQue3 = new SecurityQuestion();
                secQue3.Question = ExcelValues.Question3;
                secQue3.Answer = ExcelValues.Answer3;
                userInfo.SecurityQuestions.Add(secQue3);

                object createShellAccJson = new { userInfo };
                Console.WriteLine(" UsesrInfo : " + JsonConvert.SerializeObject(createShellAccJson));
                var createShellUserAccountResp = account.createShellUserAccount(client, userInfo);
                // activate_activationCode
                string activationUrl = getUrl(createShellUserAccountResp.UserContactInfo);
                string[] code = activationUrl.Split('/');
                string activationCode = code.Last();
                Console.WriteLine("ActivationCode : " + activationCode);
                var activateAccountResp = account.activate_activationCode(client, activationCode);
                Thread.Sleep(500);
        }

        [TestMethod]
        public void sendMessageForContactInfoUpdate()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // sendMessageForContactInfoUpdate
            object contInfoUpdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(contInfoUpdaJson);
            var sendMessageForContactInfoUpdateResp = account.sendMessageForContactInfoUpdate(client, contInfoUpdaJson);
            //Cancel Request
            object cancelconinfoupdaJson1 = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(cancelconinfoupdaJson1);
            var cancelcontactInfoUpdateResp = account.cancelContactInfoUpdate(client, cancelconinfoupdaJson1);
            Console.WriteLine("Cancelcontactupdateresponse :" + cancelcontactInfoUpdateResp);
        }

        [TestMethod]
        public void resendMessageForContactInfoUpdate()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //SendMessageForContactInfoUpdate
            object contInfoUpdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(contInfoUpdaJson);
            var sendMessageForContactInfoUpdateResp = account.sendMessageForContactInfoUpdate(client, contInfoUpdaJson);
            Console.WriteLine(sendMessageForContactInfoUpdateResp);
            //ResendMessageForContactInfoUpdate
            object resendcontinfoupdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(resendcontinfoupdaJson);
            var resendMessageForContactInfoUpdateResp = account.resendMessageForContactInfoUpdate(client, resendcontinfoupdaJson);
            Console.WriteLine(resendMessageForContactInfoUpdateResp);
            //Cancel the request
            object cancelconinfoupdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(cancelconinfoupdaJson);
            var cancelcontactInfoUpdate = account.cancelContactInfoUpdate(client, cancelconinfoupdaJson);
            Console.WriteLine("Cancelcontactupdateresponse :" + cancelcontactInfoUpdate);
        }


        [TestMethod]
        public void cancelContactInfoUpdate()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // sendMessageForContactInfoUpdate
            object contInfoUpdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(contInfoUpdaJson);
            var sendMessageForContactInfoUpdateResp = account.sendMessageForContactInfoUpdate(client, contInfoUpdaJson);
            //CancelContactInfoUpdate
            object cancelconinfoupdaJson = new { contactInfoType = (int)CommAddressType.EMAIL, newContactInfoValue = ExcelValues.Email2, authToken = Token };
            Console.WriteLine(cancelconinfoupdaJson);
            var cancelcontactInfoUpdate = account.cancelContactInfoUpdate(client, cancelconinfoupdaJson);
            Console.WriteLine("Cancelcontactupdateresponse :"+cancelcontactInfoUpdate);
        }


        [TestMethod]
        public void getSecurityQuestionsAuthenticated()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // getPatientData
            object authToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getAccountEmailAddress
            account.getAccountEmailAddress(client, authToken);
            // getSecurityQuestionsAuthenticated
            object getquestionAutJson = new { authToken = Token };
            Console.WriteLine(getquestionAutJson);
            var sendMessageForContactInfoUpdateResp = account.getSecurityQuestionsAuthenticated(client, authToken);
        }
        
        [TestMethod]
        public void changeSecurityQuestions()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            object authToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getScurityQuestions
            var getScurityquestuinslist = account.getSecurityQuestionsAuthenticated(client, authToken);
            List<string> getquestions = getScurityquestuinslist.SecurityQuestions.ToList();
            string question1 = getquestions[0];
            string question2 = getquestions[1];
            string question3 = getquestions[2];
            Console.WriteLine("Security Questions list :" + getquestions);
            SecurityQuestions = new List<SecurityQuestion>();
            SecurityQuestions.Add(new SecurityQuestion(question1, "a"));
            SecurityQuestions.Add(new SecurityQuestion(question2, "a"));
            SecurityQuestions.Add(new SecurityQuestion(question3, "a"));
            object changesquestionJson = new { Username = ExcelValues.UserName, SecurityQuestions = SecurityQuestions, authToken = Token };
            Console.WriteLine(changesquestionJson);
            var updateScurityQuestionResp = account.changeSecurityQuestions(client, changesquestionJson);
            Console.WriteLine("changeSequrityQuestion res: " + updateScurityQuestionResp);
        }
        
        
        [TestMethod]
        public void mailCheck()
        {
            var code = getUrl("oneasd");
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }


       
    }
}

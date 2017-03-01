using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.AuthenticationService;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Scripts;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class CreateProvisionalAccount:RestSharpLib
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();

        [
        TestMethod]
        public void createProvisionalAccount()
        {
            ExcelValues.Excelindexvalue(CreateShellAccountExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // CreateShellUserAccount  ( Creates Shell Account )
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
            // activate_activationCode  ( Activates Account )
            string activationUrl = getUrl(createShellUserAccountResp.UserContactInfo);
            string[] code = activationUrl.Split('/');
            string activationCode = code.Last();
            Console.WriteLine("ActivationCode : " + activationCode);
            var activateAccountResp = account.activate_activationCode(client, activationCode);
            Thread.Sleep(500);
            //Login
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // SetBasicPatientInfo   ( Converts account as provisional Account )
            var patInfo = new PatientBasicInfo();
            patInfo.FirstName = ExcelValues.FirstName;
            patInfo.LastName = ExcelValues.LastName;
            patInfo.Sex = "M";
            patInfo.MobilePhoneNo = "9875644214";
            patInfo.DOB = pstTimeZoneDateTime().AddYears(-20);
            patInfo.Addresses = new List<PatientAddressInfo>();

            var addr = new PatientAddressInfo();
            addr.IsBillingAddress = true;
            addr.IsMailingAddress = true;
            addr.Address1 = "addresas";
            addr.Address2 = "localadd";
            addr.City = "Arizona";
            addr.State = "AZ";
            addr.Zip = "90023";
            patInfo.Addresses.Add(addr);

            object setBasInfoJson = new { basicInfo = patInfo, AuthToken = Token };
            var jsonString = JsonConvert.SerializeObject(setBasInfoJson);
            Console.WriteLine(jsonString);
            var setBasicInfoResp = profile.setBasicPatientInfo(client, setBasInfoJson);
            Thread.Sleep(1000);

        }
    }

}

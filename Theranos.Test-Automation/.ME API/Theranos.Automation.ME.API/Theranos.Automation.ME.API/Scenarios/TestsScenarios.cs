using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.API.Model.API.Tests.Response;
using Theranos.Automation.ME.API.Model.API.Tests.Request;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Newtonsoft.Json;
using Theranos.Automation.ME.API.Model.SetMethods;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class TestsScenarios : RestSharpLib
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        TestsScripts tests = new TestsScripts();

        [TestMethod]
        public void getAllTests()  
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
             object jsonWithAuthToken = new { authToken = AuthToken};  // This is for V4
           // object jsonWithAuthToken = new { authToken = AuthToken}; // This is for V5
            var getPatientDataResult = profile.GetPatientData(client, jsonWithAuthToken);
            //getAllTests
            var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
         //   Console.WriteLine("Total No. of Cpts: {0}, Panels: {1}, TestSets: {2} ", getAlltestsResp.Cpts.Count, getAlltestsResp.Panels.Count, getAlltestsResp.TestSets.Count);
        }

        [TestMethod]
        public void getCptPanelMembers()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken, locationState = "AZ" };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getAllTests   : To get CPT Code 
         //   var allTests = tests.getAllTests(client, authToken);
            //getCptPanelMembers
            object getCptPanelMemJson = new { authToken = AuthToken, cptCodeList = "82565" };
            var getCptPanelMembersResp = tests.getCptPanelMembers(client, getCptPanelMemJson);
        }

        [TestMethod]
        public void getCptInfo()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken, locationState = "AZ" };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getAllTests   : To get CPT Code 
         //   var allTests = tests.getAllTests(client, authToken);
            //getCptInfo
            object getCptInfoJson = new { includeInactiveCpt = "false", cptCodeList = 80178 };
            var getCptInfoResp = tests.getCptInfo(client, getCptInfoJson);
        }

        [TestMethod]
        public void getPanelDetails()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken, locationState = "AZ" };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getAllTests   : To get CPT Code 
            //var allTests = tests.getAllTests(client, authToken);
            //getPanelDetails
            //var id=allTests.Cpts.ElementAt(15).CptCode;
            //Console.WriteLine("CptCode "+id);
            var getPanelDetailsJson = new { authToken = AuthToken, theranosId = "82270" };
            var getPanelDetailsResp = tests.getPanelDetails(client, getPanelDetailsJson);
        }

        [TestMethod]
        public void getAdvertisedTests()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getAdvertisedTests
            object getAdvTestsJson = new { authToken = AuthToken, locationState = "AZ" };
            var getAdvertisedTestsResp = tests.getAdvertisedTests(client, getAdvTestsJson);
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }

       
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using Newtonsoft.Json;
using Theranos.Automation.ME.API.Model.API.Profile.Response;
using Theranos.Automation.ME.API.Model.API.Orders.Response;
using Theranos.Automation.ME.API.Model.API.Orders.Request;
using System.IO;
using System.Drawing;
using Theranos.Automation.ME.API.Model.SetMethods;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class ResultsScenarios : RestSharpLib
    {
        ResultsScripts results = new ResultsScripts();
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();

        [TestMethod]
        public void getPatientLabResults()
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
            //getPatientLabResults
            var patientLabResultsResp = results.getPatientLabResults(client, authToken);
            Console.WriteLine("Testsets Count: " + patientLabResultsResp.Results.ElementAt(0).TestResults.ElementAt(0).TestSets.Count);
           // Console.WriteLine("LabTestId: "+patientLabResultsResp.Results.ElementAt(0).TestResults.ElementAt(0).TestSets.ElementAt(0).LabTestId);
        }

        [TestMethod]
        public void markResultAsRead()
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
            //MarkResultAsRead
            object req = new { authToken = Token, resultId = "6ada8be2-ccb7-4cf4-ba9b-bfb436d7c43b" };
            var MarkResultAsReadResp = results.markResultAsRead(client, req);
        }

        [TestMethod]
        public void getPatientVisitInfoDetails()
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
            object secToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, secToken);
            //GetPatientVisitInfoDetails
            object json = new { authToken = Token, password = ExcelValues.Password };
            var patientVisitInfoDetailsResp = results.getPatientVisitInfoDetails(client, json);
        }

        [TestMethod]
        public void getResultReport()
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
            object secToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, secToken);
            //getPatientLabResults

            var patientLabReResp = results.getPatientLabResults(client, secToken);
            var validResultOrderId = new Guid?();

            for (int list = 0; list < patientLabReResp.Results.Count; list++)
            {
                if (patientLabReResp.Results.ElementAt(list).ReportType == "Final")
                    validResultOrderId = patientLabReResp.Results.ElementAt(list).LabOrderId;

            }

            if (validResultOrderId == null)
            {
                Console.WriteLine("No. of Results available : 0 ");
                Assert.Inconclusive("There are no results available to download");
            }

            Console.WriteLine(" Laborder id of valid result : " + validResultOrderId);
            object downldFileJson = new { labOrderId = validResultOrderId, authToken = Token, password = "Abcd1234" };
            var downloadFileResp = results.getResultReport(client, downldFileJson);
            var testResultLocation = getTestResultLocation();

            using (FileStream stream = System.IO.File.Create(testResultLocation + (DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf")))
            {
                byte[] byteArray = Convert.FromBase64String(downloadFileResp.File);
                stream.Write(byteArray, 0, byteArray.Length);
                Console.WriteLine("Completed");
            }
        }
        [TestMethod]
        public void getVisitLabOrderTurnaroundTime()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken

            object loginJson = new { username = "Autotest13", password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // GetPatientData
            object secToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, secToken);
            //getPatientLabResults

            var patientLabReResp = results.getPatientLabResults(client, secToken);
            var validResultOrderId = new Guid?();
            var patientvisitId = new Guid?();

            for (int list = 0; list < patientLabReResp.Results.Count; list++)
            {
                if (patientLabReResp.Results.ElementAt(list).ReportType == "Final")
                    validResultOrderId = patientLabReResp.Results.ElementAt(list).LabOrderId;
            }

            if (validResultOrderId == null)
            {
                Console.WriteLine("No. of Results available : 0 ");
                Assert.Inconclusive("There are no results available to download");
            }
            Console.WriteLine(" Laborder id of valid result : " + validResultOrderId);
            //get patient visit ID
            var patientvisitdetails = results.getPatientVisitInfoDetails(client, secToken);
            patientvisitId = patientvisitdetails.visitDetails[0].PatientVisitId;
            Console.WriteLine(" Patientvisit id of valid result : " + patientvisitId);
            object getVTATimeJson = new { labOrderId = validResultOrderId, patientvisitId = patientvisitId, authToken = Token, };
            var getvisitturnArounTimeResp = results.getVisitLabOrderTurnaroundTime(client, getVTATimeJson);

        }
        [TestMethod]
        public void getVisitPaymentSummary()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken

            object loginJson = new { username = "Autotest13", password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var Token = loginResult.AuthToken;
            // GetPatientData
            object secToken = new { authToken = Token };
            var getPatientDataResult = profile.GetPatientData(client, secToken);
            var patientvisitId = new Guid?();
             //GetpatientvisitID       
            var patientvisitdetails = results.getPatientVisitInfoDetails(client, secToken);
            patientvisitId = patientvisitdetails.visitDetails[0].PatientVisitId;
            Console.WriteLine(" Patientvisit id of valid result : " + patientvisitId);
            // getVisitPaymentSummary
            object getVpsJson = new { PatientVisitId = patientvisitId, Password = "Abcd1234", IpAddress = "10.101.4.61:1212", authToken = Token, };
            Console.WriteLine("login token :" + Token);
            var getVpaymentsummaryResp = results.getVisitPaymentSummary(client, getVpsJson);

            var testResultLocation = getTestResultLocation();

            using (FileStream stream = System.IO.File.Create(testResultLocation + (DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf")))
            {
                byte[] byteArray = Convert.FromBase64String(getVpaymentsummaryResp.File);
                stream.Write(byteArray, 0, byteArray.Length);
                Console.WriteLine("Completed");
            }
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }


    }
}

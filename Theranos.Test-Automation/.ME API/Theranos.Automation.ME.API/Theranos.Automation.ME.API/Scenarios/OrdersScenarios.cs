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
using Newtonsoft.Json.Serialization;
using Theranos.Automation.ME.API.Model.API.Profile.Response;
using Theranos.Automation.ME.API.Model.API.Orders.Response;
using Theranos.Automation.ME.API.Model.API.Orders.Request;
using Theranos.Automation.ME.API.Model.SetMethods;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;

namespace Theranos.Automation.ME.API.Scenarios

{
    [TestClass]
    public class OrdersScenarios : RestSharpLib
    {
        OrdersScripts order = new OrdersScripts();
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        TestsScripts tests = new TestsScripts();

        [TestMethod]
        public void getSelfOrderableStates()
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
            //getPatientOrderableTests  
            var getSelfOrderableStatesResp = order.getSelfOrderableStates(client, authToken);
        }

        [TestMethod]
        public void getPatientOrderableTests()
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
            //getPatientOrderableTests
            var getPatientOrderableTestsResp = order.getPatientOrderableTests(client, authToken);
        }

        [TestMethod]
        public void getLabOrders()
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
            //getLabOrders
            var getLabOrdersResp = order.getLabOrders(client, authToken);
        }

        [TestMethod]
        public void deleteLabOrder()
        {
           
                ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // Login for AuthToken
                object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
                var loginResult = account.loginForAuthToken(client, loginJson);
                string AuthToken = loginResult.AuthToken;
                // GetPatientData
                object Token = new { authToken = AuthToken };
                var getPatientDataResult = profile.GetPatientData(client, Token);
                //getLabOrders
                var orderResp = order.getLabOrders(client, Token);
                var orderslist = orderResp.LabOrders;
                //deleteLabOrder
                var deletableLabOrderId = new Guid?();  // Following is to get LabOrder which can be deleted
                for (int list = 0; list < orderslist.Count; list++)
                {
                    if (orderslist.ElementAt(list).LabOrderStatus == "RFP" && orderslist.ElementAt(list).IsSelfOrdered == true && orderslist.ElementAt(list).OrderSource == "SELF")
                    {
                        deletableLabOrderId = orderslist.ElementAt(list).LabOrderId;
                        break;
                    }
                }

                if (deletableLabOrderId == null)
                {
                    Console.WriteLine("No. of deletable LabOrders : 0 ");
                    Assert.Inconclusive("There's No deletable LabOrders");
                }
                object delLaborderJson = new { authToken = AuthToken, labOrderId = deletableLabOrderId };
                Console.WriteLine(" Laborder Id to Delete :" + deletableLabOrderId);
                var delLabOrderResp = order.deleteLabOrder(client, delLaborderJson);
          
        }

        [TestMethod]  
        public void submitPatientTests()
        {
                ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // Login for AuthToken
                object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
                var loginResult = account.loginForAuthToken(client, loginJson);
                string AuthToken = loginResult.AuthToken;
                // GetPatientData
                object Token = new { authToken = AuthToken };
                var getPatientDataResult = profile.GetPatientData(client, Token);
                // getAllTests
                //object jsonWithAuthToken = new { authToken = AuthToken, locationState = "AZ" };
                //var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
                ////Random rnd = new Random();
                ////int randumIndex = rnd.Next(40, 100); // gets randum index b/w 40to100
                //var SelectedTest = JsonConvert.SerializeObject(getAlltestsResp.Cpts.ElementAt(55));
                //Console.WriteLine(" Test to be submitted : " + SelectedTest);
                //var cptCodeId = getAlltestsResp.Cpts.ElementAt(55).CptCodeId;  // collects random CPT CodeId
                //var testName = getAlltestsResp.Cpts.ElementAt(55).Name;
                //Console.WriteLine("CPT CodeId = " +cptCodeId);
                // submitPatientTests
                var test = new PatientLabTest();
                test.CPTCodeId = 315;
                //  test.TestName = testName;
                var ordr = new PatientLabOrder();
                ordr.IsShoppingCart = false;
                ordr.IsSelfOrdered = true;
                ordr.LabOrderName = "Self Order - " + pstTimeZoneDateTime().ToShortDateString();
                ordr.OrderDate = pstTimeZoneDateTime();
                // Console.WriteLine(" Name of the Test :" + testName);
                ordr.LabOrderId = new Guid?();
                ordr.Tests = new List<PatientLabTest>();
                ordr.Tests.Add(test);
                object submitTestJson = new { authToken = AuthToken, labOrder = ordr };
                Console.WriteLine("Json request : " + JsonConvert.SerializeObject(submitTestJson));
                var submitPatientTestsResp = order.submitPatientTests(client, submitTestJson);
        }

        [TestMethod]
        public void submitLabOrderImage()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            string AuthToken = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            // submitLabOrderImage
            string imgData = getImageData("LabOrderDoctor.jpg");
            string type = "image/jpeg";
            object subLabOrdImgJson = new { authToken = AuthToken, ImageContentType = type,CurrentImageCount="1",TotalImageCount="1", ImageData = imgData };
            var subLabOrdImgResp = order.submitLabOrderImage(client, subLabOrdImgJson);
        }

        [TestMethod]
        public void removeRejectedLabOrderFromList()
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
            //getLabOrders
            var getLabOrdersResp = order.getLabOrders(client, authToken);
            // removeRejectedLabOrderFromList
            var orderslist = getLabOrdersResp.LabOrders;
            var OrderId = new Guid?();  // get LabOrder which can be deleted
            for (int list = 0; list < orderslist.Count; list++)
            {
               if (orderslist.ElementAt(list).LabOrderStatus == "SSB" && orderslist.ElementAt(list).IsSelfOrdered == true&&orderslist.ElementAt(list).TranscriptionStatus=="ERR")
               OrderId = orderslist.ElementAt(list).LabOrderId;
            }
            if(OrderId==null)
            {
                Console.WriteLine("No. of Rejected Orders : 0 ");
                Assert.Inconclusive("There are No rejected LabOrders");
            }
            Console.WriteLine("Rejected LabOrder Id : " + OrderId);
            object remRejOrdFrmListJson = new { authToken = AuthToken, labOrderId = OrderId };
            var removeRejectedLabOrderFromListResp = order.removeRejectedLabOrderFromList(client, remRejOrdFrmListJson);
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(1000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.API.Library;
using System.Net;
using Theranos.Automation.ME.API.Model.SetMethods;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Regression
{
    [TestClass]
    public class OrderTests:RestSharpLib
    {
        OrdersScripts order = new OrdersScripts();
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        TestsScripts tests = new TestsScripts();
        
        [TestMethod]
        public void verifyOrderDate()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            string AuthToken = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            // getAllTests
            object jsonWithAuthToken = new { authToken = AuthToken, locationState = "AZ" };
            var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
            Random rnd = new Random();
            int randumIndex = rnd.Next(40, 100); // gets randum index b/w 40to100
            var cptCode = getAlltestsResp.Cpts.ElementAt(randumIndex).CptCodeId;  // collects random CPT CodeId
            var testName = getAlltestsResp.Cpts.ElementAt(randumIndex).Name;
            Console.WriteLine("CPT CodeId = " + cptCode);
            // submitPatientTests
            var test = new PatientLabTest();
            test.CPTCodeId = cptCode;
            test.TestName = testName;
            var ordr = new PatientLabOrder();
            ordr.IsShoppingCart = false;
            ordr.IsSelfOrdered = true;
            ordr.LabOrderName = "Self Order - " + pstTimeZoneDateTime().ToShortDateString();
            var orderedTimeStamp = pstTimeZoneDateTime();
            ordr.OrderDate = orderedTimeStamp;
            var orderedTimeStampString = orderedTimeStamp.ToString("MM/dd/yyyy HH.mm.ss");
            Console.WriteLine(" LabOrder Name :" + testName);
            ordr.LabOrderId = new Guid?();
            ordr.Tests = new List<PatientLabTest>();
            ordr.Tests.Add(test);
            object submitTestJson = new { authToken = AuthToken, labOrder = ordr };
            Console.WriteLine("Json request : " + JsonConvert.SerializeObject(submitTestJson));
            var submitPatientTestsResp = order.submitPatientTests(client, submitTestJson);
            var newLabOrderId = submitPatientTestsResp.LabOrderId;
            //getLabOrders & Verify
            var getLabOrdrs = order.getLabOrders(client, Token);
            for(int i=0;i<getLabOrdrs.LabOrders.Count;i++)
            {
                if(getLabOrdrs.LabOrders.ElementAt(i).LabOrderId==newLabOrderId)
                {
                    var reflectedDateTimeStamp=getLabOrdrs.LabOrders.ElementAt(i).OrderDate;
                    if(reflectedDateTimeStamp.Equals(orderedTimeStamp))
                    {
                        Console.WriteLine("Actual Order Time Stamp: {0} ; Reflected order time stamp: {1}", orderedTimeStampString, reflectedDateTimeStamp);
                        Console.WriteLine("Date & Time matched");
                    }
                    else
                    {
                        Console.WriteLine("Actual Order Time Stamp: {0} ; Reflected order time stamp: {1}", orderedTimeStampString, reflectedDateTimeStamp);
                        throw (new Exception("Verify order date Failed"));
                    }
                }
            }
        }

        [TestMethod]
        public void verifyOrderedTestName()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            string AuthToken = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            // getAllTests
            object jsonWithAuthToken = new { authToken = AuthToken, locationState = "AZ" };
            var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
            Random rnd = new Random();
            int randumIndex = rnd.Next(40, 100); // gets randum index b/w 40to100
            var cptCodeId = getAlltestsResp.Cpts.ElementAt(randumIndex).CptCodeId;  // collects random CPT CodeId
            var testName = getAlltestsResp.Cpts.ElementAt(randumIndex).Name;
            Console.WriteLine("CPT CodeId = " + cptCodeId);
            // submitPatientTests
            var test = new PatientLabTest();
            test.CPTCodeId = cptCodeId;
            test.TestName = testName;
            var ordr = new PatientLabOrder();
            ordr.IsShoppingCart = false;
            ordr.IsSelfOrdered = true;
            ordr.LabOrderName = "Self Order - " + pstTimeZoneDateTime().ToShortDateString();
            var orderedTimeStamp = pstTimeZoneDateTime();
            ordr.OrderDate = orderedTimeStamp;
            var orderedTimeStampString = orderedTimeStamp.ToString("MM/dd/yyyy HH.mm.ss");
            Console.WriteLine(" LabOrder Name :" + testName);
            ordr.LabOrderId = new Guid?();
            ordr.Tests = new List<PatientLabTest>();
            ordr.Tests.Add(test);
            object submitTestJson = new { authToken = AuthToken, labOrder = ordr };
            Console.WriteLine("Json request : " + JsonConvert.SerializeObject(submitTestJson));
            var submitPatientTestsResp = order.submitPatientTests(client, submitTestJson);
            var newLabOrderId = submitPatientTestsResp.LabOrderId;
            //getLabOrders & Verify
            var getLabOrdrs = order.getLabOrders(client, Token);
            for (int i = 0; i < getLabOrdrs.LabOrders.Count; i++)
            {
                if (getLabOrdrs.LabOrders.ElementAt(i).LabOrderId == newLabOrderId)
                {
                    var reflectedTestName = getLabOrdrs.LabOrders.ElementAt(i).Tests.ElementAt(0).TestName;
                    if (testName.Equals(reflectedTestName))
                    {
                        Console.WriteLine("Name of the added Test: {0} ; Reflected Test Name: {1}", testName, reflectedTestName);
                        Console.WriteLine("Test names matched");
                    }
                    else
                    {
                        Console.WriteLine("Name of the added Test: {0} ; Reflected Test Name: {1}", testName, reflectedTestName);
                        throw (new Exception("Test names mismatched"));
                    }
                }
            }        
        }

        [TestMethod]
        public void verifyOrderCptCode()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            string AuthToken = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            // getAllTests
            object jsonWithAuthToken = new { authToken = AuthToken, locationState = "AZ" };
            var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
            Random rnd = new Random();
            int randumIndex = rnd.Next(40, 100); // gets randum index b/w 40to100
            var randomTest = getAlltestsResp.Cpts.ElementAt(randumIndex);  // Selects random Test
            var cptCodeId = randomTest.CptCodeId;  // collects CPT CodeId
            var cptCode = randomTest.CptCode;
            var testName = randomTest.Name;
            Console.WriteLine("Ordered CPT CodeId = " + cptCodeId);
            Console.WriteLine("Ordered CPT Code = " + cptCode);
            // submitPatientTests
            var test = new PatientLabTest();
            test.CPTCodeId = cptCodeId;
            test.TestName = testName;
            var ordr = new PatientLabOrder();
            ordr.IsShoppingCart = false;
            ordr.IsSelfOrdered = true;
            ordr.LabOrderName = "Self Order - " + pstTimeZoneDateTime().ToShortDateString();
            var orderedTimeStamp = pstTimeZoneDateTime();
            ordr.OrderDate = orderedTimeStamp;
            Console.WriteLine(" Ordered Test Name :" + testName);
            ordr.LabOrderId = new Guid?();
            ordr.Tests = new List<PatientLabTest>();
            ordr.Tests.Add(test);
            object submitTestJson = new { authToken = AuthToken, labOrder = ordr };
            Console.WriteLine("Json request : " + JsonConvert.SerializeObject(submitTestJson));
            var submitPatientTestsResp = order.submitPatientTests(client, submitTestJson);
            var newLabOrderId = submitPatientTestsResp.LabOrderId;
            //getLabOrders & Verify
            var getLabOrdrs = order.getLabOrders(client, Token);
            for (int i = 0; i < getLabOrdrs.LabOrders.Count; i++)
            {
                if (getLabOrdrs.LabOrders.ElementAt(i).LabOrderId == newLabOrderId)
                {
                    var reflectedCPTCode = getLabOrdrs.LabOrders.ElementAt(i).Tests.ElementAt(0).CPTCode;
                    if (cptCode.Equals(reflectedCPTCode))
                    {
                        Console.WriteLine("CPT of Added Test: {0} ; Reflected CPT Code: {1}", cptCode, reflectedCPTCode);
                        Console.WriteLine("CPT Codes matched");
                    }
                    else
                    {
                        Console.WriteLine("CPT of Added Test: {0} ; Reflected CPT Code: {1}", cptCode, reflectedCPTCode);
                        throw (new Exception("CPT Codes mismatched"));
                    }
                }
            }       
        }

    }
}

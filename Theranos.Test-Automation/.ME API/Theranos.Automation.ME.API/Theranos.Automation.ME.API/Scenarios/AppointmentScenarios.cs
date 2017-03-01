using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Appointments;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.API.Model.API.Orders.Response;
using System.Threading;
using System.Globalization;
using Theranos.Automation.ME.API.Model.SetMethods;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class AppointmentScenarios : AppointmentScripts
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        AppointmentScripts appointment = new AppointmentScripts();
        OrdersScripts order = new OrdersScripts();

        [TestMethod]
        public void getListOfServices()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getListOfServices
            var dateTime = pstTimeZoneDateTime();
            object LoSjson = new { authToken = AuthToken, locationId = "3ee12887-ad32-4ae1-ac7a-d02aa4f77ab1", givenDate = dateTime };
            var getListOfServicesResp = appointment.getListOfServices(client, authToken);
        }

        [TestMethod]
        public void getAvailableTimeSlots()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getAvailableTimeSlots
            var dateTime = pstTimeZoneDateTime().AddDays(1); // set Tomorrow
            object LoSjson = new { authToken = AuthToken, locationId = "3e38a140-62c1-4055-9479-dc7168004f28", givenDate = dateTime };
            var getAvailableTimeSlotsResp = appointment.getAvailableTimeSlots(client, authToken);
        }

        [TestMethod]
        public void getFastingInfo()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getLabOrders
            var labOrderList = order.getLabOrders(client, authToken);
          //  var labOrderList = JsonConvert.DeserializeObject<GetLabOrdersResponse>(getLabOrdersResp);
            var singleOrder=labOrderList.LabOrders.ElementAt(0);
            var orderId=singleOrder.LabOrderId;
            //getFastingInfo
            var dateTime = pstTimeZoneDateTime();
            object fastingJson = new { authToken = AuthToken, laborderId = orderId, locationId = "3e38a140-62c1-4055-9479-dc7168004f28", givenDate = dateTime };
            var getFastingInfoResp = appointment.getFastingInfo(client, fastingJson);
        }

        [TestMethod]
        public void getPatientAppointments()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getPatientAppointments
            var getPatientAppointmentsResp = appointment.getPatientAppointments(client, authToken);
        }
         
        [TestMethod]     
        public void saveAppointment()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getLabOrders
            var labOrderList = order.getLabOrders(client, authToken);
            //var labOrderList = JsonConvert.DeserializeObject<GetLabOrdersResponse>(getLabOrdersResp);
            var orderslist = labOrderList.LabOrders;
        //    var orderId = singleOrder.LabOrderId;
            var singleLabOrderId = new Guid?();

            for (int list = 0; list < orderslist.Count; list++)
            {
                if (orderslist.ElementAt(list).LabOrderStatus == "RFP" && orderslist.ElementAt(list).IsSelfOrdered == true && orderslist.ElementAt(list).OrderSource == "SELF")
                {
                    singleLabOrderId = orderslist.ElementAt(list).LabOrderId;
                    break;
                }
            }
            if (singleLabOrderId == null)
            {
                Console.WriteLine(" No self orders available to to SaveAppointment ");
                Assert.Inconclusive("There's No self orders available");
            }
            //saveAppointment     
            var appointReq = new SaveAppointmentRequest();
            appointReq.AuthToken = AuthToken;
            appointReq.CurrentAppointmentId = 2;
            appointReq.LabOrderIds = new List<Guid?>();
            appointReq.LabOrderIds.Add(singleLabOrderId);
            appointReq.LocationId = new Guid("3ee12887-ad32-4ae1-ac7a-d02aa4f77ab1");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            var dt = pstTimeZoneDateTime();
            appointReq.CheckInTime = dt.AddHours(4);
            appointReq.ServiceId = 1;
      //    object saveAppontmentJson = new { locationId = "3e38a140-62c1-4055-9479-dc7168004f28", checkInTime = "2016-03-08T21:02:12.4793276-08:00", serviceId = "2", currentAppointmentId = "1", labOrderIds = laborderids, authToken = AuthToken };
            var SaveAppJson = JsonConvert.SerializeObject(appointReq);
            Console.WriteLine(" Save Appointment Req Json " + SaveAppJson);
            var saveAppResp=appointment.saveAppointmentWithJsonString(client,SaveAppJson);
        }

        [TestMethod]        // Seems service not yet implemented
        public void cancelAppointment()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getPatientAppointments
            var appointments = appointment.getPatientAppointments(client, authToken);
            var appointmentsResult = appointments.Appointments.ElementAt(0);
            var appointmentIdValue = appointmentsResult.AppointmentId;
            //cancelAppointment
            object cancelAppointmentJson = new { appointmentId = appointmentIdValue, authToken = AuthToken };
            var cancelAppointmentResult = appointment.cancelAppointment(client, cancelAppointmentJson);
        }

        [TestMethod]   // Service responding without required parameters
        public void earlyCheckInPatient()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
          //  getPatientAppointments  "To catch locationId & LabOrderId"
            //var getPatientAppointmentsResp = appointment.getPatientAppointments(client, Token);
            //var appointResp = JsonConvert.DeserializeObject<GetPatientAppointmentsResponse>(getPatientAppointmentsResp);
            //var locationIdValue = appointResp.Appointments.ElementAt(0).AppointmentLocation.LocationId;
            //var labOrderIdValue = appointResp.Appointments.ElementAt(0).LabOrderIds;
            //earlyCheckInPatient
           // object earlyCheckinJson = new { LabOrderId = labOrderIdValue, LocationId = locationIdValue, authToken = AuthToken };
            var earlyCheckinResp=appointment.earlyCheckInPatient(client,Token);
        }

        [TestMethod]
        public void updateEarlyCheckIn()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //updateEarlyCheckIn
            object earlyCheckInJson = new { newLocationId = "3e38a140-62c1-4055-9479-dc7168004f28", earlyCheckInId = "4", authToken = AuthToken };
            var updateEarlyCheckInResp = appointment.updateEarlyCheckIn(client, earlyCheckInJson);
        }

        [TestMethod]
        public void cancelEarlyCheckIn()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //updateEarlyCheckIn
            object earlyCheckInJson = new { newLocationId = "3e38a140-62c1-4055-9479-dc7168004f28", earlyCheckInId = "3", authToken = AuthToken };
            var updateEarlyCheckInResp = appointment.updateEarlyCheckIn(client, earlyCheckInJson);
            //cancelEarlyCheckIn
            object cancelEarlyCheckinJson = new { earlyCheckInId = "3", authToken = AuthToken };
            var cancelEarlyCheckInResp = appointment.cancelEarlyCheckIn(client, cancelEarlyCheckinJson);
        }

        [TestMethod]
        public void saveCheckInConsentForm()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //updateEarlyCheckIn
            object earlyCheckInJson = new { newLocationId = "3e38a140-62c1-4055-9479-dc7168004f28", earlyCheckInId = "2", authToken = AuthToken };
            var updateEarlyCheckInResp = appointment.updateEarlyCheckIn(client, earlyCheckInJson);
            //saveCheckInConsentForm
            object saveCheckinConFormJson = new { signature = " MySignature1", formName = " Form Name222", earlyCheckInId = "2", authToken = AuthToken };
            var saveCheckInConsentFormResp = appointment.saveCheckInConsentForm(client, saveCheckinConFormJson);
        }

        [TestMethod]
        public void geoCheckInPatient()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            var acc = new UnitTestsUserAccount();
            object loginJson = new { username = acc.username, password = acc.password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //updateEarlyCheckIn   " Use this if there's no existed entry"
            //object earlyCheckInJson = new { newLocationId = "3e38a140-62c1-4055-9479-dc7168004f28", earlyCheckInId = "3", authToken = AuthToken };
            //var updateEarlyCheckInResp = appointment.updateEarlyCheckIn(client, earlyCheckInJson);
            //  getPatientAppointments  "To catch locationId & LabOrderId"
            var appointResp = appointment.getPatientAppointments(client, authToken);
            var locationIdValue = appointResp.Appointments.ElementAt(0).AppointmentLocation.LocationId;
            var labOrderIdValue = appointResp.Appointments.ElementAt(0).LabOrderIds;
            
            //geoCheckInPatient
            object geoCheckinJson = new { newLocationId = "3e38a140-62c1-4055-9479-dc7168004f28", earlyCheckInId = "3", authToken = AuthToken };
            var geoCheckinResp = appointment.geoCheckInPatient(client, geoCheckinJson);
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }
    }
}

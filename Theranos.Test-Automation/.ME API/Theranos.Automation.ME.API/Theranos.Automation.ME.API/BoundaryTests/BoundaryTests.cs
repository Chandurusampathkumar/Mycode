using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Appointments;
using Theranos.Automation.ME.API.Scripts;
using System.Net;
using Theranos.Automation.ME.API.Model.SetMethods;
using Newtonsoft.Json;
using RestSharp;
using Theranos.Automation.ME.API.Model.EndPoint;

namespace Theranos.Automation.ME.API.BoundaryTests
{
    [TestClass]
    public class BoundaryTests : RestSharpLib
    {
        AppointmentScripts appointment = new AppointmentScripts();
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        LocationsScripts location = new LocationsScripts();

        [TestMethod]
        public void getListOfServices_Boundary()
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
            //getStoreLocations
            object stroreLocationsJson = new { Latitude = "37.09024", Longitude = "-95.71289", MinDistance = "0", MaxDistance = "3000" };
            var getStoreLocationsResp = location.getStoreLocations(client, stroreLocationsJson);
            //getListOfServices
            int locationWithAvailableServices = 0;
            for (int i = 0; i < getStoreLocationsResp.locations.Count; i++)
            {
                object LoSjson = new { authToken = AuthToken, locationId = getStoreLocationsResp.locations.ElementAt(i).LocationId, givenDate = "2016-04-12T03:48:46.5553313-08:00" };
                var getListOfServicesResp = listOfServices(client, authToken);
                 if(getListOfServicesResp.Code==0)
                 {
                     locationWithAvailableServices++;
                    Console.WriteLine("Services Avilable at location : "+getStoreLocationsResp.locations.ElementAt(i).LocationId+" & Services Available are : "+JsonConvert.SerializeObject(getListOfServicesResp));
                 }
                 Console.WriteLine("No Services available at LocationID: " + getStoreLocationsResp.locations.ElementAt(i).LocationId + ", City: " + getStoreLocationsResp.locations.ElementAt(i).City + ", Zip: " + getStoreLocationsResp.locations.ElementAt(i).Zip);
                // Console.WriteLine("Services offered: "+getStoreLocationsResp.locations.ElementAt(i).ServicesOffered);
            }
            if (locationWithAvailableServices < 1)
                throw (new Exception("No location available with \"List Of Services\" "));
        }


         public GetListOfServicesResponse listOfServices(RestClient client, object json)
        {
            string urn = AppointmentsURN.GetListOfServices;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetListOfServicesResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            return result;
        }



    }
}

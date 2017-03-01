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
using Theranos.Automation.ME.API.Model.API.Locations;
using Theranos.Automation.ME.API.Model.SetMethods;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class LocationScenarios : LocationsScripts
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        LocationsScripts location = new LocationsScripts();

        [TestMethod]
        public void getStoreLocations()
        {

            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            //getStoreLocations
            object stroreLocationsJson=new { Latitude="32.7558935",Longitude="-111.67095840000002",MinDistance="0",MaxDistance="50" };
            var getStoreLocationsResp = location.getStoreLocations(client, stroreLocationsJson);
        }

        [TestMethod]
        public void getRecentlyVisitedLocations()
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
            //GetRecentlyVisitedLocations
            var recentVisitLocResp = location.GetRecentlyVisitedLocations(client, authToken);
        }

        [TestMethod]
        public void getPatientFavoriteLocations()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var authTokenString = loginResult.AuthToken;
            // GetPatientData
              object Token = new { authToken = authTokenString };
              var getPatientDataResult = profile.GetPatientData(client, Token);
            //getPatientFavoriteLocations
            var getPatFavLocations = location.getPatientFavoriteLocations(client, Token);
            Console.WriteLine("No of Favorite Locations : " + getPatFavLocations.locations.Count);
        }

        [TestMethod]
        public void getLocations()
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
            object Token = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            //getLocations
            object getLocationsJson = new { Latitude = "32.7558935", Longitude = "-111.67095840000002", MinDistance = "0", MaxDistance = "10", coordinatesOnly = "true", authToken = AuthToken };
            var getLocationsResp = location.getLocations(client, getLocationsJson);
        }

        [TestMethod]  
        public void deletePatientFavoriteLocation()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var authTokenString = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = authTokenString };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            //getPatientFavoriteLocations
            var favLocations = location.getPatientFavoriteLocations(client, Token);
            if(favLocations.locations.Count==0)
            {
                Console.WriteLine(" No. of Favorite Locations : 0 ");
                Assert.Inconclusive(" There are no Favorite locations available to delete ");
            }
            var favLocID = favLocations.locations.ElementAt(0).LocationId;
            Console.WriteLine("Fav Location ID is " +favLocID);
            //deletePatientFavoriteLocation
            List<Guid> LocIds = new List<Guid>();
            LocIds.Add(new Guid(favLocID.ToString()));
            object delFavLocJson = new { authToken = authTokenString, locationIds = LocIds };  
            var delPatFavLocation = location.deletePatientFavoriteLocation(client, delFavLocJson);
        }

        [TestMethod]  
        public void setPatientFavoriteLocation()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var authTokenString = loginResult.AuthToken;
            // GetPatientData
            object Token = new { authToken = authTokenString };
            var getPatientDataResult = profile.GetPatientData(client, Token);
            //getStoreLocations
            object stroreLocationsJson = new { Latitude = "32.7558935", Longitude = "-111.67095840000002", MinDistance = "0", MaxDistance = "50" };
            var getStoreLocResp = location.getStoreLocations(client, stroreLocationsJson);
            // setPatientFavoriteLocation
            List<Guid> LocIds = new List<Guid>();
            var locid = getStoreLocResp.locations.ElementAt(new Random().Next(0,15)).LocationId;
            LocIds.Add(locid);
            object setPatFavLocJson = new { locationIds = LocIds, authToken = authTokenString };
            var setFavLocResp = location.setPatientFavoriteLocation(client, setPatFavLocJson);  
        }

        [TestMethod]
        public void getHolidayInfo()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // getHolidayInfo
            var LocationIds = new List<Guid>();
            LocationIds.Add(new Guid("88525421-3207-4265-b175-b4d8459f9181"));
            object getHolidayJson = new { year = "2016", locationIds = LocationIds };
            var getHolidayInfoResp = location.getHolidayInfo(client, getHolidayJson);
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }
    }
}

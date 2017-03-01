using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Model.API.Profile.Response;
using Theranos.Automation.ME.API.Model.Common.Models;
using Theranos.Automation.ME.API.Model.API.Others;
using System.Threading;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class OthersScenarios : OthersScripts
    {
        OthersScripts others = new OthersScripts();
        
        [TestMethod]
        public void apiStatus()
        {
           var client = initializeClient();
           CookieContainer CC = new CookieContainer();
           client.CookieContainer = CC;
           // ApiStatus
           var apiStatus = others.apiStatus(client);  
        }

        [TestMethod]
        public void homeApiStatus()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // HomeApiStatus
            var HomeApiStatusResp = others.homeApiStatus(client);
        }

        [TestMethod]   // Error - Failed
        public void homeGET()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // HomeApiStatus
            var HomeApiStatusResp = others.homeGET(client);
        }

        [TestMethod]
        public void homePOST()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // homePOST
            var homePostResp = others.homePOST(client);
        }

        [TestMethod]
        public void getPhysicians()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // getPhysicians
            var getPhysiciansResp = others.getPhysicians(client, 33.4495511,-112.0789355, 1,"miles");
        }

        [TestMethod]
        public void textContent()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            //textContent
            var textContentResp = others.textContent(client);
        }

        [TestMethod]
        public void textContentGetAll()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            //textContent/GetAll
            var textContentGetAllResp = others.textContentGetAll(client);
        }

        [TestMethod]
        public void textCatalog()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // textCatalog
            var item=new TextCatalogItemRequest();
            item.Category = "UserMessage";
            var textCatalogRequest = new GetTextCatalogItemsRequest();
            textCatalogRequest.Items = new List<TextCatalogItemRequest>();
            textCatalogRequest.Items.Add(item);
            textCatalogRequest.Locale = "en-US";
            textCatalogRequest.GetInactiveItems = true;
            object json = textCatalogRequest;
            var textCatalogResp = others.textCatalog(client, json);
        }

        [TestMethod]
        public void textCatalogGetItems()
        {
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // textCatalogGetItems
            var textCatalogRequest = new GetTextCatalogItemsRequest();

            var item = new TextCatalogItemRequest();
            item.Category = "UserMessage";
            item.Name = "SentActivationEmail";

            textCatalogRequest.Items = new List<TextCatalogItemRequest>();
            textCatalogRequest.Items.Add(item);
            textCatalogRequest.Locale = "en-US";
            textCatalogRequest.GetInactiveItems = true;
            textCatalogRequest.ModifiedSince = pstTimeZoneDateTime().AddYears(-1);
            object json = textCatalogRequest;
            var textCatalogGetItemsResp = others.textCatalogGetItems(client, json);
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }
    }
}

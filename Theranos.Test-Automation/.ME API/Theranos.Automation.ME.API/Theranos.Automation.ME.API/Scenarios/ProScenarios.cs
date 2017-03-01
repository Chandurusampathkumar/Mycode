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

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class ProScenarios:RestSharpLib
    {
        AccScripts account = new AccScripts();
    //    ProScripts profile = new ProScripts();

        [TestMethod]
        public void getEmergencyContacts()
        {
            var client = initializeClient();
            CookieContainer cookiecon = new System.Net.CookieContainer ();
            client.CookieContainer = cookiecon;
            Uri uri1 = new Uri("http://alpha:1212");
            
           
            object jsonLoginReq = new { userName = "oneasd", password = "Abcd1234" };
            
            var req = account.login(jsonLoginReq);
            IRestResponse resp = client.Execute(req);
            client.CookieContainer.GetCookieHeader(uri1);
          
            var cook = resp.Cookies.FirstOrDefault();
         //   cook.HttpOnly = true;
          //  cookiecon.Add(new Cookie(cook.Name, cook.Value, cook.Path, cook.Domain));
             client.AddDefaultParameter(cook.Name, cook.Value, ParameterType.Cookie);
          //  Console.WriteLine(" No of Cookies : {0}. Cookie Name : {1} Cookie Value : {2} ", cookiecon.Count ,cook.Name.ToString(),cook.Value.ToString());
          
            var content = resp.Content;
            Console.WriteLine(" Content of login : " + content);
            LoginResponse res = JsonConvert.DeserializeObject<LoginResponse>(content); // converting normal string as collection
           
            string authToken = res.AuthToken;
            int code = res.Code;
            string message = res.Message;

            // getEmergencyContacts

            object JsonEmergencyContactReq = new { authtoken = authToken};
            var req1 = constructRequest("Profile/GetEmergencyContacts", JsonEmergencyContactReq);
          
         //  req1.AddHeader("Accept-Charset", "charset=utf-8");
         //   req1.AddCookie(cook.Name, cook.Value);
            string cookieKeyValuePair = cook.Name + "=" + cook.Value;
        //    Console.WriteLine(cookieKeyValuePair);
            req1.AddHeader("Cookie", cookieKeyValuePair);
            
            req1.AddParameter(cook.Name, cook.Value, ParameterType.Cookie);
            var finalresp = ProScenarios.Execute<GetEmergencyContactsResponse>(client, req1);
            Console.WriteLine(" Resp Code is {0} Emer.Contacts are {1}",finalresp.Code, finalresp.EmergencyContacts);
        }
    }
}

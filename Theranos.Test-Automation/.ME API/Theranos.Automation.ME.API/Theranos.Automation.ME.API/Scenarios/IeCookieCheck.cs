using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.API.Profile.Response;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class IeCookieCheck
    {
        [TestMethod]
        public void ieCookieCheck()
        {
            var handler=new HttpClientHandler();
            CookieContainer cookiecon = new CookieContainer();
            handler.CookieContainer = cookiecon;
            var client = new HttpClient(handler);
            var baseUri = new Uri("http://alpha:1212");
            
            client.BaseAddress = baseUri;
            client.DefaultRequestHeaders.Accept.Clear();
            
      //    client.DefaultRequestHeaders.Add("tokenNotRequired", "true");
            client.DefaultRequestHeaders.Add("Accept","application/json,text/plain");
      //    client.DefaultRequestHeaders.Referrer = new Uri("http://alpha:96/me/login");
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
            client.DefaultRequestHeaders.Add("AcceptEncoding","gzip,deflate");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)");
            client.DefaultRequestHeaders.Host = "alpha:1212";
        //    client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
           
            object obi=new { username="oneasd",password="Abcd1234"};
            HttpResponseMessage response=client.PostAsJsonAsync("/api/v4/Account/login", obi).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(" Content is :" +content);
            var sesCook = cookiecon.GetCookieHeader(baseUri);
            Console.WriteLine(" No of Cookies : " +cookiecon.Count + " Cookie Header : " +sesCook);
            var resp = JsonConvert.DeserializeObject<LoginResponse>(content);
            
            object obj1 = new { authToken = resp.AuthToken };
            HttpResponseMessage response1 = client.PostAsJsonAsync("/api/v4/profile/getPatientData", obj1).Result;
            var content1 = response1.Content.ReadAsStringAsync().Result;
            Console.WriteLine(" No of Cookies : " + cookiecon.Count + " Cookie Header : " + cookiecon.GetCookieHeader(baseUri));
            Console.WriteLine(" Content1 is :" + content1);
            var respCode = JsonConvert.DeserializeObject<GetPatientDataResponse>(content1);
            

            //HttpResponseMessage response2 = client.PostAsJsonAsync("/api/v4/profile/GetEmergencyContacts", obj1).Result;
            //var content2 = response2.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(" No of Cookies : " + cookiecon.Count + " Cookie Header : " + cookiecon.GetCookieHeader(baseUri));
            //Console.WriteLine(" Content2 is : " + content2);

            HttpResponseMessage response3 = client.PostAsJsonAsync("/api/v4/profile/GetGuardianInfo", obj1).Result;
            var content3 = response3.Content.ReadAsStringAsync().Result;
            Console.WriteLine(" No of Cookies : " + cookiecon.Count + " Cookie Header : " + cookiecon.GetCookieHeader(baseUri));
            Console.WriteLine(" Content3 is : " + content3);

        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using RestSharp.Reflection;
using RestSharp.Validation;
using RestSharp;
using System.Net;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class Cookiecheck
    {
        [TestMethod]
        public void cookieCheck()
        {
            var client = new RestClient("http://alpha:1212");
            client.AddDefaultParameter("Origin", "http://alpha:96", ParameterType.HttpHeader);
         //   client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.103");
           
            client.AddDefaultParameter("Host","alpha:1212",ParameterType.HttpHeader);
            CookieContainer cookiecon = new CookieContainer();
            client.CookieContainer = cookiecon;
            client.FollowRedirects = true;
            Uri uri = new Uri("http://alpha:1212");

            // WebLogin
            var request = new RestRequest("/api/v4/Account/WebLogin", Method.POST);
            request.RequestFormat = DataFormat.Json;  // Sets request format as Json
            request.AddJsonBody(new { username = "oneasd", password = "Abcd1234" });  // Used to add Body
            IRestResponse response = client.ExecuteTaskAsync(request).Result;  // Execute reuqest & capture response in RAW
            var content = response.Content;
            Console.WriteLine(" Account/WEbLogin Response is :" + content);
            var sesCook = response.Cookies.FirstOrDefault();
          
           
  //          Console.WriteLine(" Sescook name: "+ sesCook.Name + " Value : " + sesCook.Value+ "Domain : " +sesCook.Domain);
    //        cookiecon.Add(new System.Net.Cookie(sesCook.Name, sesCook.Value, sesCook.Path, sesCook.Domain));
            // Get Verification Code 
    
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.yopmail.com/en/");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            string email = "oneasd@yopmail.com";
            driver.FindElement(By.Id("login")).SendKeys(email);
            driver.FindElement(By.ClassName("sbut")).Click();
            driver.SwitchTo().Frame(driver.FindElement(By.Id("ifmail")));
            string verifiCode = driver.FindElement(By.XPath("//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/span")).Text;
            
            Console.WriteLine(" VerifiCode : " + verifiCode);
          
         // WebLoginWithPIN
            var request1 = new RestRequest("/api/v4/Account/WebLoginWithPin", Method.POST);
            request1.RequestFormat = DataFormat.Json;  // Sets request format as Json
            
            request1.AddJsonBody(new {username="oneasd",password="Abcd1234",pinNumber=verifiCode,rememberDevice="true" });  // Used to add Body
            request1.AddHeader("tokenNotRequired", "true");
      //      request1.AddParameter(sesCook.Name, sesCook.Value, ParameterType.Cookie);
            IRestResponse response1 = client.ExecuteTaskAsync(request1).Result;  // Execute reuqest & capture response in RAW
            var cryptoCookie = response1.Cookies.FirstOrDefault();
      //      cookiecon.Add(new System.Net.Cookie(cryptoCookie.Name, cryptoCookie.Value, cryptoCookie.Path, cryptoCookie.Domain));
            Console.WriteLine("Crypto Cookie Header :" + cryptoCookie.Name + "=" + cryptoCookie.Value);
            var content1 = response1.Content;
            Console.WriteLine("WebloginWithPin Resp" + content1);
            var loginResult = JsonConvert.DeserializeObject<LoginResponse>(content1);
            Console.WriteLine(" No of Cookies in cookiecon : " + cookiecon.Count);
            string CookieHeaders = cookiecon.GetCookieHeader(uri);
            Console.WriteLine(" Cookiecon Headers " + CookieHeaders);
       
            //GetPatientData

            var request3 = new RestRequest("/api/v4/profile/getPatientData", Method.POST);
            request3.RequestFormat = DataFormat.Json;  // Sets request format as Json
            request3.AddHeader("Host", "alpha:1212");
            request3.AddHeader("Accept-Language", "en-US,en;q=0.5");

            request3.AddHeader("Accept-Charset", "Charset=utf-8");
            request3.AddHeader("Accept", "application/json, text/plain, ");
            request3.AddHeader("Referer", "http://alpha:96/me/settings/emergency");
            request3.AddHeader("Content-Length", "60");
            request3.AddHeader("Accept-Encoding", "gzip,deflate");
            request3.AddHeader("Content-Type", "application/json;charset=utf-8");
            request3.AddJsonBody(new { authToken = loginResult.AuthToken });
            IRestResponse response3 = client.ExecuteTaskAsync(request3).Result;
            var content3 = response3.Content;
            
            Console.WriteLine(" getPatientData " + content3);
          
            //GetEmergency Contactes Method: POST
            var request2 = new RestRequest("/api/v4/Profile/GetEmergencyContacts", Method.POST);
            request2.RequestFormat = DataFormat.Json;  // Sets request format as Json
            request2.AddHeader("Host","alpha:1212");
            request2.AddHeader("Accept-Language", "en-US,en;q=0.5");

            request2.AddHeader("Accept-Charset", "Charset=utf-8");
           request2.AddHeader("Accept", "application/json, text/plain, ");
            request2.AddHeader("Referer", "http://alpha:96/me/settings/emergency");
            request2.AddHeader("Content-Length", "60");
            request2.AddHeader("Accept-Encoding", "gzip,deflate");
            request2.AddHeader("Content-Type", "application/json;charset=utf-8");
            

            //request2.AddCookie(sesCook.Name, sesCook.Value);    // Manually 
            //request2.AddCookie(cryptoCookie.Name, cryptoCookie.Value);

//            request2.AddParameter(sesCook.Name, sesCook.Value, ParameterType.Cookie);
            request2.AddJsonBody(new { authToken = loginResult.AuthToken });
            Console.WriteLine(" No of Cookies added : " + cookiecon.Count);
            IRestResponse response2 = client.ExecuteTaskAsync(request2).Result;
            var content2 = response2.Content;
            Console.WriteLine(" Emergency Contactes " + content2);

        }
   }
}

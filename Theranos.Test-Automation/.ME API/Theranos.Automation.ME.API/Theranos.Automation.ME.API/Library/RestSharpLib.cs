using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CsvHelper;
using System.IO;
using Theranos.Automation.AutoStack;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Theranos.Automation.ME.API.Library
{
    public class RestSharpLib:Scripts.Scripts
    {

        public static string APIbase = System.Configuration.ConfigurationManager.AppSettings["EndPoint"];
        public static string TestDataLoc = System.Configuration.ConfigurationManager.AppSettings["TestDataDirectory"];
        public static string userAccountsExcel = TestDataLoc + "UserAccounts.xlsx";
        public static string CreateShellAccountExcel = TestDataLoc + "CreateShellAccount.xlsx";


        public static RestClient initializeClient()
        {
            var client=new RestClient(APIbase);
            client.AddDefaultHeader("Accept", "application/json, text/plain, */*");
            client.AddDefaultHeader("Content-Type", "application/json,charset=UTF-8");
            client.AddDefaultHeader("Accept-Encoding", "gzip, deflate");
            client.AddDefaultHeader("Accept-Language", "en-US,en;q=0.8");
            client.AddDefaultHeader("Accept-Charset", "charset=UTF-8");
            return client;
        }

        public static RestRequest constructPostRequest(string URN,object JsonObject)
        {
            var request = new RestRequest(URN, Method.POST);
            request.RequestFormat = DataFormat.Json;  // Sets request format as Json  
            request.AddJsonBody(JsonObject);
            //request.AddHeader("Host", "labcheckin.theranos.com");
            //request.AddHeader("Origin", "https://theranos.com");
            return request;
        }

        public static RestRequest constructPostRequest(string URN,string JsonString)
        {
            var request = new RestRequest(URN, Method.POST);
            request.RequestFormat = DataFormat.Json;  // Sets request format as Json  
            request.AddParameter("application/json", JsonString, ParameterType.RequestBody);
            //request.AddHeader("Host", "labcheckin.theranos.com");
            //request.AddHeader("Origin", "https://theranos.com");
            return request;
        }

        public static RestRequest constructPostRequest(string URN)
        {
            var request = new RestRequest(URN, Method.POST);
            request.RequestFormat = DataFormat.Json;  // Sets request format as Json  
     //     request.AddHeader("Host", "alpha:1212");
            return request;
        }

        public static RestRequest constructGetRequest(string URN)
        {
            var request = new RestRequest(URN, Method.GET);
            request.RequestFormat = DataFormat.Json;  // Sets request format as Json  
          //  request.AddJsonBody(JsonObject);
          //  request.AddHeader("Host", "alpha:1212");
            return request;
        }

        public static IRestResponse getResponse(RestClient client,RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static string executeAsync(RestClient client,RestRequest request)
        {
            IRestResponse response = client.ExecuteTaskAsync(request).Result;
            var content = response.Content;
            return content;
        }

        public static T Execute<T>(RestClient client, RestRequest request) where T : new()
        {
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public List<T> ReadCsv<T>(string fileName) where T : new()
        {
            string testDataLoc = System.Configuration.ConfigurationManager.AppSettings["TestDataDirectory"];
            var streamRe = new StreamReader(testDataLoc + fileName);
            var csv = new CsvHelper.CsvReader(streamRe);
          //  csv.Configuration.RegisterClassMap<EmContactMap>();  
            var records = csv.GetRecords<T>().ToList();  // get records as List
            streamRe.Close();  // Closing stream.
            return records;
        }

        public static string getTestDataLocation()
        {
            //string TestDataDirectory = "\\Source\\Workspaces\\Theranos.Test-Automation\\.ME API\\Internal\\";  // Test Data Directory
            //string UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);   // returns "C:\Users\_USER DIRECTORY"
            //string testDataLoc = UserHome + TestDataDirectory;
            string testDataLoc = System.Configuration.ConfigurationManager.AppSettings["TestDataDirectory"];
            return testDataLoc;
        }

        public static string getTestResultLocation()
        {
            string TestResultLocation = System.Configuration.ConfigurationManager.AppSettings["DownloadsDirectory"];
            return TestResultLocation;
        }

        public static string getImageData(string fileName)
        {
            string testDataLoc = getTestDataLocation();
            string base64 = null;
            using (Bitmap bm = new Bitmap(testDataLoc+fileName))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bm.Save(ms, ImageFormat.Jpeg);
                    base64 = Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                }
            }
            return base64;
        }

        // Other Scripts
        public string getTwoStepVerificationCode(string email)
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.guerrillamail.com/inbox");
            Thread.Sleep(1100);

            IWebElement dd = driver.FindElement(By.Id("gm-host-select"));
            var DDown = new SelectElement(dd);
            DDown.SelectByIndex(2);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("inbox-id")).Click();
            Thread.Sleep(880);
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/input")).Clear();
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/input")).SendKeys(email);
            Thread.Sleep(880);
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/button")).Click();
            Thread.Sleep(38000);
            driver.FindElement(By.XPath(".//*[@id='email_list']//tr[1]//td[2]")).Click();
            Thread.Sleep(2000);
            var verificationCode = driver.FindElement(By.XPath(".//*[@id='display_email']/div/div[2]/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td/span")).Text;
            Thread.Sleep(2000);
            Console.WriteLine(" Verification Code : " + verificationCode);
            driver.Quit();
            return verificationCode;

        }


        // Using guerrillamail
        public string getUrl(string email)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.guerrillamail.com/inbox");
            Thread.Sleep(3100);
            
            IWebElement dd = driver.FindElement(By.Id("gm-host-select"));
            var DDown = new SelectElement(dd);
            DDown.SelectByIndex(2);
            Thread.Sleep(2100);
            driver.FindElement(By.Id("inbox-id")).Click();
            Thread.Sleep(2100);
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/input")).Clear();
            Thread.Sleep(1100);
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/input")).SendKeys(email);
            Thread.Sleep(1880);
            driver.FindElement(By.XPath(".//*[@id='inbox-id']/button")).Click();
            Thread.Sleep(38000);
            driver.FindElement(By.XPath(".//*[@id='email_list']//tr[1]//td[2]")).Click();
            Thread.Sleep(2000);
            var verificationCode = driver.FindElement(By.XPath(".//*[@id='display_email']/div/div[2]/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a")).GetAttribute("href");
            Thread.Sleep(2000);
            Console.WriteLine(" href Attribute : " + verificationCode);
            driver.Quit();
            return verificationCode;
        }

        public DateTime pstTimeZoneDateTime()
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            //Set the time zone information to PST(US Mountain Standard Time)
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time");
            //Get date and time of PST 
            dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //Return date and time
            return dateTime;
        }
    }
}

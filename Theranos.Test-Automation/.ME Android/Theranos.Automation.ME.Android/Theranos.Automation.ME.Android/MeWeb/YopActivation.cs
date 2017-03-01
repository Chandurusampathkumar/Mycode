using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.MeWeb
{
    [TestClass]
    public class YopActivation : ScreenShot
    {
        ActionLib Wib = new ActionLib();
        public static string VisitCode = string.Empty;

        [TestMethod]
        public void ActivateYopmail()
        {

            if (ExcelValues.NewUserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            FirefoxDriver Driver = new FirefoxDriver();
            Console.WriteLine("Opened URL");
            String MailUrl = "http://www.yopmail.com/en/";
            Driver.Navigate().GoToUrl(MailUrl);
            Driver.Manage().Window.Maximize();
            Driver.FindElementByXPath(MELoginModel.Yopemail_ByXpath).SendKeys(ExcelValues.NewUserName + "@Yopmail.com");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(80));
            Driver.FindElementByXPath(MELoginModel.yopBtn_ByXpath).Click();
            Console.WriteLine("waiting for element");
            WebDriverWait waitelement = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MELoginModel.Yopemail_ByXpath)));
            Console.WriteLine("system executed the script successful ");
            Driver.SwitchTo().Frame(MELoginModel.Frame_ByID);
            Driver.FindElementByXPath(MELoginModel.Activatelink_ByXpath).Click();
            Thread.Sleep(10000);
            //string currentwindow = Driver.CurrentWindowHandle;
            //List<string> w = new List<string>(Driver.WindowHandles);
            //Driver.SwitchTo().Window(w[1]);
            //Driver.Quit();
        }

       [TestMethod]
        public void RetriveCode()
        {

            if (ExcelValues.NewUserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            FirefoxDriver Driver = new FirefoxDriver();
            Console.WriteLine("Opened URL");
            String MailUrl = "http://www.yopmail.com/en/";
            Driver.Navigate().GoToUrl(MailUrl);
            Driver.Manage().Window.Maximize();
            Driver.FindElementByXPath(MELoginModel.Yopemail_ByXpath).SendKeys("Autogsrba@yopmail.com");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.FindElementByXPath(MELoginModel.yopBtn_ByXpath).Click();
            Console.WriteLine("waiting for element");
            WebDriverWait waitelement = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MELoginModel.Yopemail_ByXpath)));
            Console.WriteLine("system executed the script successful ");
            Driver.SwitchTo().Frame(MELoginModel.Frame_ByID);
            VisitCode = Driver.FindElementByXPath(MELoginModel.ActivateCode_ByXpath).Text;
            Driver.Quit();
            //return VisitCode;
                    
        }
       
    }
}

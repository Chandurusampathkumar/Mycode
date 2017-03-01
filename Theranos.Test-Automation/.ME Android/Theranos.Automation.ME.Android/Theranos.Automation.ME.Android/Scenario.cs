using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using Theranos.Automation.ME.Android;
using Theranos.Mailtemplate.Report.Mail;
using Theranos.Mailtemplate.AppStack;

namespace Theranos.Automation.ME.Android
{
    [TestClass]
    public class Scenario
    {
        public static AndroidDriver<AndroidElement> driver;

        private static Uri testServerAddress = new Uri(AndroStack.ServerAddress);
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.CommandTimeout);
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.ImplicitTimeout);

        Mailtrigger MT = new Mailtrigger();
        //[TestInitialize]
        //public void BeforeAll()
        //{
        //    DesiredCapabilities capabilities = new DesiredCapabilities();
        //    TestCapabilities testCapabilities = new TestCapabilities();

        //    testCapabilities.App = AndroStack.ApkPath;
        //    testCapabilities.AutoWebView = true;
        //    testCapabilities.AutomationName = "Ssample";
        //    testCapabilities.BrowserName = String.Empty;
        //    testCapabilities.DeviceName = ".Me";
        //    testCapabilities.FwkVersion = "1.0";
        //    testCapabilities.Platform = TestCapabilities.DevicePlatform.Android;
        //    testCapabilities.PlatformVersion = String.Empty;

        //    testCapabilities.AssignAppiumCapabilities(ref capabilities);
        //    driver = new AndroidDriver<AndroidElement>(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
        //    driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);

        //}

        public void AfterAll()
        {
            driver.Quit();
        }


        [TestMethod]
        public String BuildFormTitle()
        {
            String AppName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            //String FormTitle = String.Format("{0} {1} ({2})",AppName,Application.ProductName,Application.ProductVersion);
            return AppName;
        }
        [TestMethod]
        public void Scenario1()
        {
            CreateAccountPage login = new CreateAccountPage();
            DashBoardOrder pro = new DashBoardOrder();
            LoginValidation LV = new LoginValidation();
            DashBoardUser user = new DashBoardUser();
            LaunchActivity Applaunch = new LaunchActivity();
            DashBoardUser US = new DashBoardUser();
            UploadOrders Upload = new UploadOrders();
            //login.ActivateYopmail();

            Applaunch.launchAVD();
            Thread.Sleep(180000);
            Applaunch.unlockemulator();
            Applaunch.startAppium();
            LaunchActivity.Appclose();
            LaunchActivity.launchapp();
            Applaunch.Stopserver();
            //MT.EmailTriggering();
            //LV.LoginLinkedAcc(LaunchActivity.driver);

            //Applaunch.Stopserver();

            //pro.DashBoardOrders(LaunchActivity.driver);
            //Upload.CaptureImage(LaunchActivity.driver);

            //US.AccountPage(LaunchActivity.driver);
            //US.BasicInfoPage(LaunchActivity.driver);
            //US.BasicInfoMailingAddressPage(LaunchActivity.driver);
            //US.AddBasicInfoMailingAddress(LaunchActivity.driver);
        }
        [TestMethod]
        public static string GetapplicationnameAndroid()
        {
            var appname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string projectname = appname.ToString();
            return projectname;
        }

        public void androidapp()
        {
            Appassembly.setappFilepath(GetapplicationnameAndroid());
        }

        [TestMethod]
        public void result()
        {
            //MT.EmailTriggering();
            androidapp();
            //MT.setapp_path();
            MT.getfilename();
            MT.convertTRX_HTML();
            MT.sendingmail();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack.Android;
using Theranos.Automation.AutoStack.Android.Utility;

namespace Theranos.Automation.PSC3.Models
{
    [TestClass]
    public class PSC3_ME_Android_Model:PSC3Model
    {
        public static AndroidDriver<AndroidElement> driver;

        private static Uri testServerAddress = new Uri(AndroStack.ServerAddress);
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.CommandTimeout);
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.ImplicitTimeout);

        [TestInitialize]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            TestCapabilities testCapabilities = new TestCapabilities();

            testCapabilities.App = AndroStack.ApkPath;
            testCapabilities.AutoWebView = true;
            testCapabilities.AutomationName = String.Empty;
            testCapabilities.BrowserName = String.Empty;
            testCapabilities.DeviceName = String.Empty;
            testCapabilities.FwkVersion = "1.0";
            testCapabilities.Platform = TestCapabilities.DevicePlatform.Android;
            testCapabilities.PlatformVersion = String.Empty;

            testCapabilities.AssignAppiumCapabilities(ref capabilities);
            driver = new AndroidDriver<AndroidElement>(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }
    }
}

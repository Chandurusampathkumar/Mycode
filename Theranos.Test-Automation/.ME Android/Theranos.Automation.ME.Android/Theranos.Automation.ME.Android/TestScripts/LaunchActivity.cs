using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Threading;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestScripts
{
    [TestClass]
    public class LaunchActivity
    {
        public static AndroidDriver<AndroidElement> driver;

        private static Uri testServerAddress = new Uri(AndroStack.ServerAddress);
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.CommandTimeout);
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(AndroStack.ImplicitTimeout);
     

        

        public static void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            TestCapabilities testCapabilities = new TestCapabilities();

            testCapabilities.App = AndroStack.ApkPath;
            testCapabilities.AutoWebView = true;
            testCapabilities.AutomationName = "Ssample";
            testCapabilities.BrowserName = String.Empty;
            testCapabilities.DeviceName = ".Me";
            testCapabilities.FwkVersion = "1.0";
            testCapabilities.Platform = TestCapabilities.DevicePlatform.Android;
            testCapabilities.PlatformVersion = String.Empty;

            testCapabilities.AssignAppiumCapabilities(ref capabilities);
            driver = new AndroidDriver<AndroidElement>(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);

        }
        public static void AfterAll()
        {
            driver.Quit();
        }
        public static void CloseApp()
        {
            driver.CloseApp();
        }
        public static void startapp()
        {
            DesiredCapabilities capabilities1 = new DesiredCapabilities();
            TestCapabilities testCapabilities1 = new TestCapabilities();

            testCapabilities1.App = String.Empty;
            testCapabilities1.AutoWebView = true;
            testCapabilities1.AutomationName = "Ssample";
            testCapabilities1.BrowserName = String.Empty;
            testCapabilities1.DeviceName = "TestDevice5.1";
            testCapabilities1.FwkVersion = "1.0";
            testCapabilities1.Platform = TestCapabilities.DevicePlatform.Android;
            testCapabilities1.PlatformVersion = String.Empty;
            testCapabilities1.Apppackage = "com.theranos.me";
            testCapabilities1.Appactivity = "com.theranos.me.login.LoginActivity";
            //capabilities1.SetCapability("app-package", "com.theranos.me"); // This is package name of your app (you can get it from apk info app)
            //capabilities1.SetCapability("app-activity", ".com.theranos.me.landing.landingPageActivity"); // This is Launcher activity of your app (you can get it from apk info app)
            ////Create RemoteWebDriver instance and connect to the Appium server.
            //It will launch the Calculator App in Android Device using the configurations specified in Desired Capabilities
            testCapabilities1.AssignAppiumCapabilities(ref capabilities1);
            driver = new AndroidDriver<AndroidElement>(testServerAddress, capabilities1, INIT_TIMEOUT_SEC);
        }
        public static void launchapp()
        {
            //AccountScripts.killapp();
            Appclose();
            Console.WriteLine("Executing Appium Script");

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "TestDevice5.1");
            capabilities.SetCapability("platformVersion", "4.4.4");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("appPackage", "com.theranos.me");
            capabilities.SetCapability("newCommandTimeout", "1500");
            capabilities.SetCapability("appActivity", "com.theranos.me.login.LoginActivity");

            driver = new AndroidDriver<AndroidElement>(testServerAddress, capabilities, INIT_TIMEOUT_SEC);

        }
        [TestMethod]
        public void startAppium()
        {
            //string[] MyArguments = { @"cmd", @"C:\Users\mkarthik\Documents\selenium\Appium\node.exe", @"C:\Users\mkarthik\Documents\selenium\Appium\node_modules\appium\bin\appium.js\", "--address", "127.0.0.1", "--bootstrap-port", "4242", "--no-reset", "--log", @"C:\Users\mkarthik\workspace\Android\AppiumMobileAutomation\src\com\log\appiumLogs.txt" };
            //String[] PInfoArgs = { @"cmd", @"C:\Program Files (x86)\Appium\node.exe", @"C:\Program Files (x86)\Appium\node_modules\appium\bin\appium.js\", "--address", "127.0.0.1", "--bootstrap-port", "4723", "--no-reset", "--log", @"C:\Automation\appiumLogs.txt" };

            //String[] startsinfoArgs = { @"cmd", @"C:/Program Files (x86)/Appium/node.exe", @"C:/Program Files (x86)/Appium/node_modules/appium/bin/Appium.js", " --address", "127.0.0.1", " --port", "4723", " --avd", "TestDevice5.1", " --no-reset", " --session-override", " --platform-name Android", " --platform-version 21", " --automation-name Appium", " --log-no-color" };



            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = AndroStack.appiumserverpath;
            startInfo.Arguments = @"""C:/Program Files (x86)/Appium/node_modules/appium/bin/appium.js"" --address 127.0.0.1 --port 4723 --automation-name Appium --log-no-color";
            process.StartInfo = startInfo;
            process.Start();
        }
        [TestMethod]
        public void Stopserver()
        {
            Process[] proceses = null;
            proceses = Process.GetProcessesByName("node");
            foreach (Process proces in proceses)
            {
                proces.Kill();
            }
        }
        [TestMethod]
        public void launchAVD()
        {
            //String adbpath = "C:\\AndroidSdk\\sdk\\platform-tools";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            p.StandardInput.WriteLine(@"cd " +  AndroStack.Adbpath);
            p.StandardInput.WriteLine(AndroStack.LaunchEmulator);


        }
        [TestMethod]
        public void unlockemulator()
        {
            //String adbpath = "C:\\AndroidSdk\\sdk\\platform-tools";
            //String unlockemulator = "adb shell input keyevent 82";
            Process p1 = new Process();
            p1.StartInfo.FileName = "cmd.exe";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardInput = true;
            p1.Start();
            p1.StandardInput.WriteLine(@"cd " +  AndroStack.Adbpath);
            p1.StandardInput.WriteLine("timeout 300");
            p1.StandardInput.WriteLine(AndroStack.Emulatorunlock);
        }
        public static void Appclose()
        {
            //String adbpath = "C:\\AndroidSdk\\sdk\\platform-tools";
            //String close = "adb shell pm clear com.theranos.me";
            Process p2 = new Process();
            p2.StartInfo.FileName = "cmd.exe";
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.RedirectStandardInput = true;
            p2.Start();
            p2.StandardInput.WriteLine(@"cd " +  AndroStack.Adbpath);
            p2.StandardInput.WriteLine(AndroStack.Closeapp);

        }
    }
}
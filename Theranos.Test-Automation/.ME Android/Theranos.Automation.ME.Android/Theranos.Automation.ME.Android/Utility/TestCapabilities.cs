using System;
using OpenQA.Selenium.Remote;

namespace Theranos.Automation.ME.Android.Utility
{
    public class TestCapabilities
    {
        String package = "com.theranos.me";
        String Launchactivity = "com.theranos.me.login.LoginActivity";
        /// Tracking platforms  
        public enum DevicePlatform
        {
            Undefined,
            Windows,
            IOS,
            Android
        }

        public string BrowserName { get; set; }
        public string FwkVersion { get; set; }
        public DevicePlatform Platform { get; set; }
        public string PlatformVersion { get; set; }
        public string DeviceName { get; set; }
        public string App { get; set; }
        public bool AutoWebView { get; set; }
        public string AutomationName { get; set; }
        public string Apppackage { get; set; }
        public string Appactivity { get; set; }

        public TestCapabilities()
        {
            this.BrowserName = String.Empty;
            this.FwkVersion = String.Empty;
            this.Platform = DevicePlatform.Android;
            this.PlatformVersion = String.Empty;
            this.DeviceName = String.Empty;
            this.App = String.Empty;
            this.AutoWebView = true;
            this.AutomationName = String.Empty;
            this.Apppackage = String.Empty;
            this.Appactivity = String.Empty;
        }

        public void AssignAppiumCapabilities(ref DesiredCapabilities appiumCapabilities)
        {
            appiumCapabilities.SetCapability("browserName", this.BrowserName);
            appiumCapabilities.SetCapability("appium-version", this.FwkVersion);
            appiumCapabilities.SetCapability("platformName", this.Platform2String(this.Platform));
            appiumCapabilities.SetCapability("platformVersion", this.PlatformVersion);
            appiumCapabilities.SetCapability("deviceName", this.DeviceName);
            appiumCapabilities.SetCapability("autoWebview", this.AutoWebView);
            appiumCapabilities.SetCapability("app-package", this.Apppackage);
            appiumCapabilities.SetCapability("app-activity", this.Appactivity);

            // App push (will be covered later)
            if (this.App != String.Empty)
            {
                appiumCapabilities.SetCapability("app", this.App);
            }
            if(this.Apppackage !=String.Empty)
            {
                appiumCapabilities.SetCapability("Apppackage", package);
                appiumCapabilities.SetCapability("app-activity", Launchactivity);
            }
            
        }

        /// Converting to string the platform (for Appium)
        private string Platform2String(DevicePlatform value)
        {
            switch (value)
            {
                case DevicePlatform.Windows:
                    return "win"; /* TODO: Need to write your own extension of Appium for this */
                case DevicePlatform.IOS:
                    return "iOS";
                case DevicePlatform.Android:
                    return "Android";
                default:
                    return "";
            }
        }
    }
}

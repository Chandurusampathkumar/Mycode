using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Theranos.Automation.ME.Android.TestScripts;

namespace Theranos.Automation.ME.Android.Utility
{
    [TestClass]
    public class ScreenShot
    {
        public TestContext TestContext { get; set; }
        public static AndroidDriver<AndroidElement> Driver;

       [TestCleanup]
        public void TakeScreeShot()
        {
            TakeScreenShot(LaunchActivity.driver);
        }
        public void TakeScreenShot(AndroidDriver<AndroidElement> driver)
        {

            var screenShot =driver.GetScreenshot();
           screenShot.SaveAsFile(TestContext.TestName+" "+ UtilityClass.GetCurrentDate()+ ".jpg", ImageFormat.Jpeg);
           

        }

    }
}

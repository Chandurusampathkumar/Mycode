﻿using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.AutoStack.Utility;
using System.Drawing.Imaging;
using Theranos.Automation.AutoStack;


namespace Integration_Project.Model
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class IntegrationModel : AutoStack
    {
        
        //public TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext{get;set;}
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        
        [TestCleanup()]
        public void Cleanup()
        {
            TakeScreenShot();
        }

        public void TakeScreenShot()
        {
            ScreenshotHelper.CaptureScreenToFile(TestContext.TestName + " " + UtilityClass.GetCurrentDate() + ".png", ImageFormat.Png);
        }

        public void TakeScreenShot(string fileName)
        {
            ScreenshotHelper.CaptureScreenToFile(fileName + " " + UtilityClass.GetCurrentDate() + ".png", ImageFormat.Png);
        }
    }
}

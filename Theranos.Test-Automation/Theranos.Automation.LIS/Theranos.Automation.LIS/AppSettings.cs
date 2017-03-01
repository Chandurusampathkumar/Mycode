using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
namespace Theranos.Automation.LIS
{

    public class AppSettings
    {

        //Test Category
        public const string Unit = "UNIT"; //These scripts cannot be executed separately
        public const string UnitRunnable = "UNITRUN";//These scripts can be executed separately
        public const string L1 = "PRIORITY1";// Priority Level 1
        public const string SpecialSuite = "SpecialSuite";

        public const string E2E = "E2E";// End 2 End Scenario
        public const string Demo = "DEMO";


    }
}
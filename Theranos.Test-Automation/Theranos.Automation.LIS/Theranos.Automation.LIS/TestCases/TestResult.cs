using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.AutoStack;
using TestStack.White.UIItems.WPFUIItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.LIS.TestCases
{
    [TestClass]
    public class TestResult:AccessionsModel
    {
        public string ResultValues { get; set; }
        public string ResultRange { get; set; }
    }
}

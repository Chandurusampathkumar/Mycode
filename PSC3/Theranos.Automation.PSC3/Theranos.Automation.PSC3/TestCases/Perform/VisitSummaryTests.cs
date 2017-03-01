
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White.UIItems;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.Perform;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using System.Collections.Generic;

namespace Theranos.Automation.PSC3.TestCases.Perform
{
    [TestClass]
    public class VisitSummaryTests:VisitSummaryModel
    {
        [TestMethod]
        public void Finish()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardModel.ScanReturnContainerHost_ByID));
        }
    }
}

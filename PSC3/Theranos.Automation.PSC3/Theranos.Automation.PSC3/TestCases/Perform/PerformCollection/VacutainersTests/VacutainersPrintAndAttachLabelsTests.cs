
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests
{
    [TestClass]
    public class VacutainersPrintAndAttachLabelsTests:PrintAndAttachLabels
    {
        //[TestMethod]
        //public void Labels()
        //{
        //    CheckLabels(3);
        //}

        public void VacutainersCheckLabels(int label)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var labels = AutoElement.GetElementNameById(appWin,PrintAndAttachLabelsCount_ByID);
            var count = Convert.ToInt32(labels);
            Assert.AreEqual(count,label);
        }

        //check, When clicking Print extra labels... app does not crash
        [TestMethod]
        public void ClkVacPrntExtraLabelChkApp()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, PrintAndAttachIncrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachDecrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachIncrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachPrintExtraLabel_ByID);
            HandleBarcodePrintingError();
            

        }

        [TestMethod]
        public void HandleBarcodePrintingError()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,VacutainersBarcodeOk_ByID);
            Assert.IsTrue(AutoElement.EnabledById(appWin,LabelsNextButton_ByID));
        }

        [TestMethod]
        public void MoveToScanCollection()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,LabelsNextButton_ByID);
            Assert.IsTrue(AutoElement.ExistsByClassName(appWin,VacutainerScanCollection.VacutainerScanCollectionHost_ByClass));
        }
    }
}

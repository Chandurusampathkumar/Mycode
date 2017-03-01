
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;


namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests
{
    [TestClass]
    public class OtherPrintAndAttachLabelsTests:PrintAttachLabels
    {

        //[TestMethod]
        //public void OtherContainersLabels()
        //{
        //    OtherContainersCheckLabels(2);
        //}


        public void OtherContainersCheckLabels(int label)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var labels = AutoElement.GetElementNameById(appWin, LabelsCount_ByID);
            var count = Convert.ToInt32(labels);
            Assert.AreEqual(count, label);

        }

        //check, When clicking Print extra labels... app does not crash
        [TestMethod]
        public void ClkOthrPrntExtraLabelChkApp()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, PrintAndAttachIncrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachDecrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachIncrement_ByID);
            AutoAction.ClickButtonById(appWin, PrintAndAttachPrintExtraLabel_ByID);
            OtherContainersHandleBarcodePrintingError();

        }
        

        [TestMethod]
        public void OtherContainersHandleBarcodePrintingError()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,OtherContainersBarcodeOk_ByID);
            Assert.IsTrue(AutoElement.EnabledById(appWin, PrintNextButton_ByID));
        }

        [TestMethod]
        public void OtherContainersMoveToScanCollection()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,PrintNextButton_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,ScanCollection.OtherContainersScanCollectionHost_ByID));
        }
    }     
}

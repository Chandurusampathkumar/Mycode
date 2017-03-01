
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Nanotainers;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests
{
    [TestClass]
    public class NanotainersSampleCollectionTests:NanotainersSampleCollection
    {

        //[TestMethod]
        //public void NanotainerInstruction()
        //{
        //    CheckNanotainerInstruction(3);
        //}


        public void CheckNanotainerInstruction(int quantity)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var instruction = AutoElement.GetElementNameById(appWin,CollectionInstruction_ByID);
            var container = instruction.Substring(8,2);
            var containerQuantity = Convert.ToInt32(container);
            var message = instruction.Substring(instruction.Length-84);
            Assert.AreEqual(containerQuantity,quantity);
            Assert.AreEqual(message,NanotainerSampleCollectionMessage);
        }

        [TestMethod]
        public void MoveToScanCollection()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, SampleCollectionNext_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, NanotainersScanCollection.NanotainersPostscanHost_ByID));
        }
    }
}

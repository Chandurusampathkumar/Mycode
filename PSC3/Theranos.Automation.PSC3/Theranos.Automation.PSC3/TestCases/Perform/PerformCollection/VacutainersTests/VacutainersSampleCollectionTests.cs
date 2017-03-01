
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
using System.Collections.Generic;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests
{
    [TestClass]
    public class VacutainersSampleCollectionTests:VacutainersSampleCollection
    {

        public void CheckCollectSamplesInstruction(Dictionary<string,string> ExpectedInstruction)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Dictionary<string,string> PresentInstruction=new Dictionary<string,string>();
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                var container = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(VacutainersSampleCollectionNameX_ByID,i));
                var instruction = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(VacutainersSampleCollectionInstructionX_ByID,i));

                PresentInstruction.Add(container,instruction);
            }
            Assert.IsTrue(UtilityClass.CompareDictionary(ExpectedInstruction, PresentInstruction), "Expected and present containers doesn't match. \nExpected: " + UtilityClass.GetLine(ExpectedInstruction) + "\nPresent: " + UtilityClass.GetLine(PresentInstruction));

        }

        [TestMethod]
        public void CollectionComplete()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,VacutainersSampleCollectionNext_ByID);
            //var host = AutoElement.GetElementByClassName(appWin,VacutainersSampleCollectionHost_ByClass);
            //Assert.IsNull(host,"Print and Attach Labels page is not displayed");
        }
    }
}

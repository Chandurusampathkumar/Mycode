
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
using System.Collections.Generic;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;
using TestStack.White.UIItems.ListBoxItems;

namespace Theranos.Automation.PSC3.TestCases.Perform
{
    [TestClass]
    public class PrepareContainersTests:PrepareContainers
    {
        [TestMethod]
        public void SwitchToVenousDraw()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);            
            AutoAction.ClickButtonById(appWin,SwitchToVenous_ByID);
            AutoAction.ClickButtonById(appWin, NoTestChangeConfirm_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,SwitchToFingerstick_ByID));
        }

        [TestMethod]
        public void SwitchToVenousDrawRemoveTest()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, SwitchToVenous_ByID);
            AutoAction.ClickButtonById(appWin, RemoveTestConfirmSwitch_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, SwitchToFingerstick_ByID));
        }

        [TestMethod]
        public void SwitchToFingerStick()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, SwitchToFingerstick_ByID);
            AutoAction.ClickButtonById(appWin, NoTestChangeConfirm_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, SwitchToVenous_ByID));
        }

        [TestMethod]
        public void SwitchToFingerStickRemoveTest()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, SwitchToFingerstick_ByID);
            Thread.Sleep(2* WaitTime);
            AutoAction.ClickButtonById(appWin, RemoveTestConfirmSwitch_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, SwitchToVenous_ByID));
        }

       
        [TestMethod]
        public void MoveToPerformCollectionNanotainers()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,PrescanNanotainers.PrescanHost_ByID));            
        }

        [TestMethod]
        public void MoveToPerformCollectionVacutainers()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByID));
        }

        [TestMethod]
        public void MoveToPerformCollectionOtherContainers()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID));
        }

        //[TestMethod]
        //public void Containers()
        //{
        //    VerifyContainers("Urine Collection Kit");
        //}


        [TestMethod]
        public void CheckDiscardTube()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            int i = 0;
            if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, i)) == PrepareContainers.ContainerLightBlueTop)
            {
                var discardTube = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i));
                Assert.IsTrue(discardTube==DiscardTube,"Discard tube is not present");
            }
            else if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, i)) == PrepareContainers.ContainerTanTop)
            {
                var discardTube = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i));
                Assert.IsTrue(discardTube == DiscardTube, "Discard tube is not present");
            }
            else
            {
                Assert.Fail("Light blue top contianer is not present");
            }
        }

        [TestMethod]
        public void CheckDiscardTubeLightBlueTop()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            int i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(VacutainersNameX_ByID, i))))
            {
                var containerName = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(VacutainersNameX_ByID,i));
                if (containerName==ContainerLightBlueTop)
                {
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i)));
                    var discardTube = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i));
                    Assert.IsTrue(discardTube == DiscardTube, "Discard tube is not present");
                }
                i++;
            }
        }

        [TestMethod]
        public void TanTopWithDiscardTube()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            int i = 0;
            var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, 0));
            if (containerName == ContainerTanTop)
            {
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, 0)));
                var discardTube = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i));
                Assert.IsTrue(discardTube == DiscardTube, "Discard tube is not present");
            }
        }

        [TestMethod]
        public void TanTopWithoutDiscardTube()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            int i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(VacutainersNameX_ByID, i))))
            {
                var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, i));
                if (containerName == ContainerTanTop)
                {
                    Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i)));
                }
                i++;
            }
        }


        public void VerifyContainers(Dictionary<string,int> ExpectedContainers)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Dictionary<string, int> PresentContainers = new Dictionary<string, int>();
            //foreach (var item in name)
            //{
            int i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(NanotainersNameX_ByID,i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersNameX_ByID, i));
                var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersCountX_ByID, i));
                
                PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

            i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(VacutainersNameX_ByID, i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, i));
                var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersCountX_ByID, i));
                
                PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

            i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(OtherContainersNameX_ByID, i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersNameX_ByID, i));
                var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersCountX_ByID, i));
                
                PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

            Assert.IsTrue(UtilityClass.CompareDictionary(ExpectedContainers, PresentContainers), "Expected and present containers doesn't match. \nExpected: " + UtilityClass.GetLine(ExpectedContainers) + "\nPresent: " + UtilityClass.GetLine(PresentContainers));
           
            
        }

        //delete a (Urine test) in confirm order page and verify that test's container does not display in prepare container page
        [TestMethod]
        public void VerifyVacutainer_OtherContainers()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var PrepContainHost = AutoElement.GetElementById(appWin, PrepareContainersHost_ByID);
            var hostItem = AutoElement.GetAllChilderen(PrepContainHost);

            var containerPane = AutoElement.GetElementByClassName(PrepContainHost, hostItem[0].Current.ClassName);
            var conPaneItem = AutoElement.GetAllChilderen(containerPane);
            if (conPaneItem.Count != 0)
            {
                string itemName = "";
                foreach (AutomationElement item in conPaneItem)
                {
                    itemName = item.Current.Name;
                    if (itemName.Contains("urine"))
                    {
                        Assert.Fail("PrePare Container Page contains Urine Container when the order is deleted in confirm order page");
                        break;
                    }

                }
            }
            else
            {
                Assert.Fail();
            }

        }


        public void VerifyContainers(HashSet<string> ExpectedContainers)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            HashSet<string> PresentContainers = new HashSet<string>();
            //foreach (var item in name)
            //{
            int i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(NanotainersNameX_ByID, i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersNameX_ByID, i));
               // var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersCountX_ByID, i));
                PresentContainers.Add(name);
                //PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

            i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(VacutainersNameX_ByID, i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, i));
                //var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersCountX_ByID, i));
                PresentContainers.Add(name);
                //PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

            i = 0;
            while (appWin.Exists<Label>(SearchCriteria.ByAutomationId(UtilityClass.GetListItemId(OtherContainersNameX_ByID, i))))
            {
                var name = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersNameX_ByID, i));
                //var count = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersCountX_ByID, i));
                PresentContainers.Add(name);
                //PresentContainers.Add(name, Convert.ToInt32(count.Remove(0, 1)));
                i++;
            }

           // Assert.IsTrue(UtilityClass.CompareDictionary(ExpectedContainers, PresentContainers), "Expected and present containers doesn't match. \nExpected: " + UtilityClass.GetLine(ExpectedContainers) + "\nPresent: " + UtilityClass.GetLine(PresentContainers));
            if (!ExpectedContainers.SetEquals(PresentContainers))
            {
                Assert.Fail("Expected and present containers doesn't match Expected Containers: " + String.Join(", ", ExpectedContainers) + " Present Containers: " + String.Join(", ", PresentContainers));
            }

        }

        [TestMethod]
        public void BackToVerifyIdentification()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.ClickButtonById(appWin,Back_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,VerifyIdentifiationHost_ByID));
        }

        [TestMethod]
        public void GTTCancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin,CollectionExpiredCancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(CollectionPeriodExpiredReason_ById));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin,CollectionPeriodExpiredOk_ByID);
            AutoAction.ClickButtonById(appWin,PerformModel.Yes_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,DashboardModel.ScanReturnContainerHost_ByID));
        }

        [TestMethod]
        public void OFTWithMintTop()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            int i = 0;
            var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersNameX_ByID, 0));
            if (containerName == ContainerQFTGrey)
            {
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, 0)));
                var discardTube = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainerDiscardTubeX_ByID, i));
                Assert.AreEqual(discardTube,MintTube, "Discard tube is not present");
            }
        }

        [TestMethod]
        public void CheckCollectionPeroidExpiredAndContinueVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin,CollectionPeriodExpiredPopup_ById));
            AutoAction.ClickRadioButtonById(appWin,CollectionPeriodExpiredContinue_ByID);
            AutoAction.ClickButtonById(appWin,CollectionPeriodExpiredOk_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,PrepareContainersHost_ByID));
        }

        [TestMethod]
        public void CheckCollectionPeroidExpiredAndCancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, CollectionPeriodExpiredPopup_ById));
            AutoAction.ClickRadioButtonById(appWin,CollectionExpiredCancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("CollectionPeriodExpired.SelectReason.ComboBox.Combo"));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin,CollectionPeriodExpiredOk_ByID);
            AutoAction.ClickButtonById(appWin, "CancelVisitPopup.Yes.button");
        }
    }
}

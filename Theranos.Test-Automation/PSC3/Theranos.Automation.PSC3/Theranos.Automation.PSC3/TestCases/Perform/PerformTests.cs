
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
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.PSC3.TestCases.CheckIn;
namespace Theranos.Automation.PSC3.TestCases.Perform
{
    [TestClass]
    public class PerformTests:PerformModel
    {

        CheckInTests check = new CheckInTests();
        DashboardTests dashboard = new DashboardTests();

        //Incomplete
        [TestMethod]
        public void CancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, CancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin,Yes_ByID);
            AutoAction.ClickButtonById(appWin,Yes_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardModel.ScanReturnContainerHost_ByID));
        }

        [TestMethod]
        public void VerifyForGTT1Hour()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var gttType = AutoElement.GetElementNameById(appWin,GlucoseDrinkMessage_ByID);
            Assert.AreEqual(gttType,GTT1Hour,"50 g Glucose drink is not displayed");
        }

        [TestMethod]
        public void VerifyForGTT2Hour()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var gttType = AutoElement.GetElementNameById(appWin, GlucoseDrinkMessage_ByID);
            Assert.AreEqual(gttType, GTT2Hour, "75 g Glucose drink is not displayed");
        }

        [TestMethod]
        public void VerifyForGTT3Hour()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var gttType = AutoElement.GetElementNameById(appWin, GlucoseDrinkMessage_ByID);
            Assert.AreEqual(gttType, GTT3Hour, "75 g Glucose drink is not displayed");
        }

        [TestMethod]
        public void ClickNextButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,GlucoseDrinkNextButton_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,GTTTimerHost_ByID));
        }

        [TestMethod]
        public void StartTimer()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,GTTTimerNextButton_ByID);
            dashboard.CloseTempraturePopup();
            Assert.IsTrue(AutoElement.VisibleById(appWin,DashboardModel.ScanReturnContainerHost_ByID));
        }


       
        [TestMethod]
        public void GuestValidation()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guest = AutoElement.GetElementNameById(appWin,GuestName_ByID);
            check.NavigateToDashboard();
            var host = AutoElement.GetElementById(appWin, DashboardModel.ActionsRequired_ByID);
            var guestList = AutoElement.GetElementCollectionByName(host,DashboardModel.PerformGuestName_Name);

            int count;
            if (guestList.Count!=0)
            {
                do
                {
                    count=guestList.Count;
                    foreach (AutomationElement item in guestList)
                    {
                         var listItemTask = item.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                         if (guest==listItemTask[1].Current.Name)
                         {
                             UIAutoHelper.ScrollIntoView(item);
                             Assert.AreEqual(listItemTask[1].Current.Name,guest);
                             Assert.AreEqual(listItemTask[3].Current.Name,InProgress);
                         }                        
                    }
                    UIAutoHelper.ScrollIntoView(guestList[count - 1]);
                    guestList = AutoElement.GetElementCollectionByName(host, DashboardModel.PerformGuestName_Name);
                } while (count!=guestList.Count);
            }
        }
    }
}

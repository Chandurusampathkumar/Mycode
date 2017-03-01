using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn
{
    [TestClass]
    public class CheckInTests:CheckInModel
    {
        
        /// <summary>
        /// CTC-59: Verify user is able to cancel visit during Check-in Process
        /// </summary>
        [TestMethod]
        public void CancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, CancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardModel.ActionsRequired_ByID));          
        }

        /// <summary>
        ///CTC-58: Verify user is able to navigate back to dashboard during Check-in Process
        /// </summary>
        [TestMethod]
        public void NavigateToDashboard()
        {
            //var itemSelected = false;
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));

            //var guestName = appWin.Get<Label>(SearchCriteria.ByAutomationId(GuestName_ByID)).Name;
            var navigationBar = appWin.GetElement(SearchCriteria.ByAutomationId(NavigationBar_ById));
            var backToDashboardImage = navigationBar.FindFirst(TreeScope.Descendants,new PropertyCondition(AutomationElement.ClassNameProperty,Image_ByClass));
            var backToDashboardButton = TreeWalker.RawViewWalker.GetParent(backToDashboardImage);
            UIAutoHelper.performInvokePattern(backToDashboardButton);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardModel.ActionsRequired_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardModel.DashboardHost_ByID));
            ////Thread.Sleep(5*WaitTime);
            //var host = appWin.GetElement(SearchCriteria.ByAutomationId(DashboardModel.ActionsRequired_ByID));
            //Assert.IsNotNull(host);

            //var listView = host.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            //var guestOrders = host.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));
            //int listItemCount;
            //if (guestOrders.Count != 0)
            //{

            //    listItemCount = guestOrders.Count;
            //    foreach (AutomationElement item in guestOrders)
            //    {
            //        //var listItemText = item.FindFirst(TreeScope.Children,new PropertyCondition(AutomationElement.ClassNameProperty,TextBlock_ByClass));
            //        UIAutoHelper.ScrollIntoView(item);
            //        //itemSelected = true;
            //        //break;
            //    }
            //    //if (itemSelected)
            //    //{
            //    //    break;
            //    //}
            //    //UIAutoHelper.ScrollIntoView(guestOrders[listItemCount - 1]);
            //}           
            
        }

        [TestMethod]
        public void MoveToAddLabOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var labOrder = AutoElement.GetElementByName(appWin,AddLabOrder_ByName);
            UIAutoHelper.performInvokePattern(labOrder);
            //AutoAction.ClickUIItemByName(appWin, AddLabOrder_ByName);
            Assert.IsTrue(AutoElement.ExistsById(appWin, NewOrder_ByID));
        }

        [TestMethod]
        public void MoveToGuestInfo()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guestInfo = AutoElement.GetElementByName(appWin,GuestInfo_ByName);
            UIAutoHelper.performInvokePattern(guestInfo);
            //AutoAction.ClickUIItemByName(appWin, GuestInfo_ByName);
            Assert.IsTrue(AutoElement.ExistsById(appWin, BasicInfoModel.GuestInfoHost_ByID));
        }

        [TestMethod]
        public void MoveToGuestForms()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var guestForm = AutoElement.GetElementByName(appWin,GuestForms_ByName);
            UIAutoHelper.performInvokePattern(guestForm);
            //AutoAction.ClickUIItemByName(appWin, GuestForms_ByName);
            Assert.IsTrue(AutoElement.ExistsById(appWin, GuestFormsModel.GuestFormsHost_ByID));
        }

        [TestMethod]
        public void MoveToConfirmOrders()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var confirmOrders = AutoElement.GetElementByName(appWin,ConfirmOrders_ByName);
            UIAutoHelper.performInvokePattern(confirmOrders);
            //AutoAction.ClickUIItemByName(appWin, ConfirmOrders_ByName);
            Assert.IsTrue(AutoElement.ExistsById(appWin, ConfirmOrdersModel.ConfirmOrdersHost_ByID));
        }

        [TestMethod]
        public void MoveToSummaryPage()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var summary = AutoElement.GetElementByName(appWin,Summary_ByName);
            UIAutoHelper.performInvokePattern(summary);
            //AutoAction.ClickUIItemByName(appWin, Summary_ByName);
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.SummaryHost_ByID));
        }
    }
}

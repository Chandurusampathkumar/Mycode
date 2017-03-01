
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.AutoStack;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.PSC3.Models.CheckIn;

namespace Theranos.Automation.PSC3.TestCases.CheckIn
{
    [TestClass]
    public class PaymentTests:PaymentModel
    {
        //In Progress
        /// <summary>
        /// Verify on clicking back to dashboard button user is displayed in perform room waiting section.
        /// </summary>
        [TestMethod]
        public void BackToDashboard()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,BackToDashboard_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardHost_ByID));            
        }

        /// <summary>
        /// CTC-77: Verify user is able to edit the visit.
        /// </summary>
        [TestMethod]
        public void EditVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            Thread.Sleep(WaitTime);
            AutoAction.ClickButtonById(appWin, EditVidit_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,Pay_ByID));
            //var PayButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Pay_ByID));
            //Assert.IsNotNull(PayButton);
        }

        /// <summary>
        /// click full refund
        /// </summary>
        
        [TestMethod]
        public void clickFullRefund()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            AutoAction.ClickButtonById(appWin, FullRefund_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, Finish_ByID));


        }

        //In Progress
        /// <summary>
        /// CTC-76: Verify user is perform full refund for the lab order and complete the visit.
        /// CTC-80- System must allow user to conduct full refund via external and imbedded Point of Service.
        /// </summary>
        [TestMethod]
        public void FullRefund()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            AutoAction.ClickButtonById(appWin, FullRefund_ByID);

            var refundHost = AutoElement.GetElementById(appWin, PaymentModel.PaymentHost_ByID);
            var confirmrefund = AutoElement.GetAllChilderen(refundHost);
            var refund = confirmrefund[9].Current.Name;
            AutoAction.ClickUIItemByName(appWin, refund);
            //AutoAction.ClickCheckBoxById(appWin, PaymentModel.ConfirmRefund_ByID);

            //AutoAction.ClickCheckBoxById(appWin, ConfirmRefund_ByID);
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, Finish_ByID);

            var PopUpMsg = AutoElement.GetElementById(appWin, "TbMessage");
            string PopupMsg = PopUpMsg.Current.Name.ToString();
            Assert.IsTrue((PopupMsg.Contains("visit is complete")), "Visit complete message not displayed after full refund");

            AutoAction.ClickButtonById(appWin, OK_ByID);
            var refundCheck = appWin.GetElement(SearchCriteria.ByText(ScanID_ByName));
            Assert.IsNotNull(refundCheck);
        }

        //Full Refund process when Insurance Payment mode is selected...
        [TestMethod]
        public void FullRefundInsurance()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            AutoAction.ClickButtonById(appWin, FullRefund_ByID);

            //var host = AutoElement.GetElementById(appWin, OK_ByID);
            //var orders = AutoElement.GetAllChilderen(host);
            //Assert.AreSame("Full Refund Complete", orders[0].Current.Name, "Application is not displays Full Refund Complete message to the user");

            AutoAction.ClickButtonById(appWin, OK_ByID);

            Assert.IsTrue(AutoElement.ExistsById(appWin, DashboardHost_ByID));
        }

        /// <summary>
        /// CTC-78: Verify user is able to cancel the full refund.
        /// </summary>
        [TestMethod]
        public void CancelRefund()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            AutoAction.ClickButtonById(appWin, FullRefund_ByID);
            AutoAction.ClickButtonById(appWin, Cancel_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,DashboardHost_ByID));
            //var backToDashboardButton = appWin.Get<Button>(SearchCriteria.ByText(BackToDashboard_ByName));
            //Assert.IsNotNull(backToDashboardButton);

        }

        [TestMethod]
        public void ProcessRefund()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin,ConfirmRefund_ByID);
            AutoAction.ClickButtonById(appWin,Finish_ByID);
            AutoAction.ClickButtonById(appWin,OK_ByID);
        }


        //CTC84: System must give user ability to select "Bill Me Later" as method of payment (configuration based on location).
        [TestMethod]
        public void BillMeLater()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, BillMeLater_ByID);
            AutoAction.ClickButtonById(appWin, SummaryModel.Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, SummaryModel.PaymentComplete_ByName));
        }

        [TestMethod]
        public void ConfirmPayment()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, ConfirmPayment_ByID);
            AutoAction.ClickButtonById(appWin, SummaryModel.Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, SummaryModel.PaymentComplete_ByName));
        }

        //Check user can't cancel visit in MakeAdjustment Overlay
        [TestMethod]
        public void CheckCancelVisitinMakeAdjustment()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, MakeAdjustment_ByID);
            var host = AutoElement.GetElementById(appWin, MakeAdjustmentHost_ByID);
            var items = AutoElement.GetAllChilderen(host);
            for (int i = 0; i <= (items.Count) - 1; i++)
            {
                string itemName = items[i].Current.Name.ToString();

                if (itemName.IndexOf("cancel", 0, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    if (AutoElement.VisibleByName(appWin, items[i].Current.Name))
                    {
                        Assert.Fail("Cancel Button is present in MakeAdjustment overlay.... user can able to cancel the visit");
                        return;
                    }
                }

            }
            UIAutoHelper.performInvokePattern(items[1]);
            
            
           
        }

    }
}

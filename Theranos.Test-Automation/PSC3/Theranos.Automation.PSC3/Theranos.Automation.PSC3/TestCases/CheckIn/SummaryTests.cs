
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.Features;
using Theranos.Automation.PSC3.TestCases.FeaturesTests;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.TestCases.Perform;




namespace Theranos.Automation.PSC3.TestCases.CheckIn
{
    [TestClass]
    public class SummaryTests : SummaryModel
    {

        
        //Split the method into PayByInsurance and PayByCash
        /// <summary>
        /// CTC-82: Verify user is able to pay the amount.  
        /// </summary>
        [TestMethod]
        public void Pay()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //Wait until payment is displayed
            AutoAction.ClickButtonById(appWin,Pay_ByID);
            AutoAction.ClickUIItemById(appWin, ConfirmPayment_ByID);
            AutoAction.ClickButtonById(appWin, Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin,PaymentComplete_ByName));
        }

        [TestMethod]
        public void SelfPay()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var selfPay = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(SelfPay_ByID));
            if (selfPay.Visible)
            {
                if (!selfPay.IsSelected)
                {
                    selfPay.Select();
                }
            }
        }

        //Select Insurance as a Payment mode
        [TestMethod]
        public void Insurance()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insurance = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(Insurance_ByID));
            if (insurance.Visible)
            {                
                if (!insurance.IsSelected)
                {
                    insurance.Select();
                }                
            }
        }

        /// <summary>
        /// CTC-81: Verify user is able top print the payment summary.
        /// </summary>
        [TestMethod]
        public void PrintPaymentSummary()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, PrintPaymentSummary_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);
        }

        
        public void CheckPricing(string totalCharge)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            //var displayedAmount = appWin.Get<Label>(SearchCriteria.ByAutomationId(SummaryModel.AmountDue_ByID)).Name.Replace('$', ' ').Trim();
            var displayedAmount = AutoElement.GetElementNameById(appWin, AmountDue_ByID).Replace('$', ' ').Trim();
            //TestContext.WriteLine("Displayed total charge: " + displayedAmount);
            //TestContext.WriteLine("Expected total charge: " + totalCharge);
            //TestContext.WriteLine("Expected total charge:" +PricingTests.totalCharge);
            Assert.AreEqual(totalCharge, displayedAmount, "Expected total charge is not equal to the displayed total charge");
        }

        [TestMethod]
        public void PrintAndPay()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin,Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);

            AutoAction.ClickUIItemById(appWin, ConfirmPayment_ByID);
            AutoAction.ClickButtonById(appWin, Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
        }

        [TestMethod]
        public void PrintAndPayCancel()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);

            AutomationElement cancelButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition cancelButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, PrintCancel_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                //cancelButton = AutoElement.GetElementCollectionByName(uiWindow,Cancel_ByName,TreeScope.Children);
                cancelButton = uiWindow.FindFirst(TreeScope.Descendants, cancelButtonCondition);

            } while (cancelButton == null);
            UIAutoHelper.performInvokePattern(cancelButton);
            
            AutoAction.ClickUIItemById(appWin, ConfirmPayment_ByID);
            AutoAction.ClickButtonById(appWin, Finish_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
            
        }

        [TestMethod]
        public void PrintAndPayInsurance()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);
           
            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
        }

        [TestMethod]
        public void PrintAndPayCancelInsurance()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);

            AutomationElement cancelButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition cancelButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, PrintCancel_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                //cancelButton = AutoElement.GetElementCollectionByName(uiWindow,Cancel_ByName,TreeScope.Children);
                cancelButton = uiWindow.FindFirst(TreeScope.Descendants, cancelButtonCondition);

            } while (cancelButton == null);
            UIAutoHelper.performInvokePattern(cancelButton);

            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
        }

        [TestMethod]
        public void Print()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);
            Assert.IsTrue(AutoElement.VisibleById(appWin,ConfirmPayment_ByID));
        }

        [TestMethod]
        public void PrintAndNavigateToVerifyIdentification()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);
            Assert.IsTrue(AutoElement.VisibleById(appWin, VerifyIdentificationTests.VerifyIdentifiationHost_ByID));
        }

        [TestMethod]
        public void PrintAndCancel()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);

            AutomationElement cancelButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition cancelButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, PrintCancel_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                //cancelButton = AutoElement.GetElementCollectionByName(uiWindow,Cancel_ByName,TreeScope.Children);
                cancelButton = uiWindow.FindFirst(TreeScope.Descendants, cancelButtonCondition);

            } while (cancelButton == null);
            UIAutoHelper.performInvokePattern(cancelButton);
            Assert.IsTrue(AutoElement.VisibleById(appWin,ConfirmPayment_ByID));
        }

        [TestMethod]
        public void PayAfterEdit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Pay_ByID);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
        }

        //CTC-86: ABN pop-up is displayed.
        //CTC-87: User should be able to scan the ABN form and finish the process.
        [TestMethod]
        public void PrintAndPayABNInsurance()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            AutoAction.ClickButtonById(appWin, Pay_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            AutoAction.ClickUIItemByName(appWin, XPSDocument_ByName);
            UIAutoHelper.performInvokePattern(printButton);


            AutomationElement fileName = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition fileNameCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, FileName_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Edit_ByClass));

                fileName = uiWindow.FindFirst(TreeScope.Descendants, fileNameCondition);

            } while (fileName == null);
            UIAutoHelper.performValuePattern(fileName, UtilityClass.GetCurrentMethod(1) + " " + UtilityClass.GetCurrentDate());
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);

            Assert.IsTrue(AutoElement.VisibleById(appWin,ABNPrintFormPopUp_ByID));

            AutoAction.ClickButtonById(appWin,ABNFormNext_ByID);
            AutoAction.ClickButtonById(appWin,ScanABNForm_ByID);
            AutoAction.ClickButtonById(appWin,ScanABNFormNext_ByID);
            AutoAction.ClickButtonById(appWin,ABNDoneButton_ByID);

            Assert.IsTrue(AutoElement.ExistsByName(appWin, PaymentComplete_ByName));
        }

        [TestMethod]
        public void VerifyForAmountDue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var amountDue = AutoElement.GetElementNameById(appWin,AmountDue_ByID);
            PrintAndCancel();
            var amount = AutoElement.GetElementNameById(appWin,PaymentModel.Amount_ByID);
            Assert.AreEqual(amountDue,amount,"Amount due in summary and payment page is not same");

        }

        //CTC-107: To verify when user wish to add test after te payment by edit visit section system should prompt for payment collection in the summary page.
        public void ChekRecentOdrAdded(string cliName)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var RecentOrd = AutoElement.GetElementById(appWin, OrderName_ByID);
            var RecentOrdData = AutoElement.GetAllChilderen(RecentOrd);
            var item = RecentOrdData[1].Current.Name;
            Assert.IsTrue(item.Equals(cliName), "Recent order not shown in summary page");


        }

        [TestMethod]
        public void CheckAmountDueForSTIPanel()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var amountDue = AutoElement.GetElementNameById(appWin, AmountDue_ByID);
            Assert.AreEqual(STIPrice_ByID,amountDue,"Expected amount is not displayed");
        }

        //Check for "Co-Pay" text in Price Field when Insurance Radio button is selected in the summary page
        [TestMethod]
        public void CheckPriceForInsurance()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var priceValue = AutoElement.GetElementNameById(appWin, OrderCopay_ByID);
            Assert.AreEqual("Co-Pay", priceValue, "Price value is not Co-Pay when Insurance payment mode is selected");
        }

        [TestMethod]
        public void ClickBackButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //Wait until payment is displayed
            AutoAction.ClickButtonById(appWin, BackButton_ByID);

        }

        
    }
}

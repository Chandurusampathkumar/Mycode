
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

namespace Theranos.Automation.PSC3.TestCases.CheckIn
{
    [TestClass]
    public class GuestFormsTests : GuestFormsModel
    {

        [TestMethod]
        public void GuestFormMandatory()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            if (next.Enabled)
            {
                Assert.Fail("Next button is enabled");
            }
        }


        /// <summary>
        /// CTC-72: Verify user is able to confirm the guest sign of the form.
        /// </summary>
        [TestMethod]
        public void ConfirmGuestSign()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin, Yes_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsByClassName(appWin, ActiveOrders_ByClass));
            //var Orders = appWin.GetElement(SearchCriteria.ByClassName(ActiveOrders_ByClass));
            //Assert.IsNotNull(Orders, "Unable to reach confirm orders page"); 
        }

        /// <summary>
        /// CTC-71: Verify user is able to print the privacy practice form.
        /// </summary>
        [TestMethod]
        public void PrintPrivacyPracticeForm()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, PrintForms_ByID);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty,AppWindowName));

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

        /// <summary>
        /// PSC3-TS-112	MoveToConfirmOrders
        /// </summary>
        [TestMethod]
        public void ClickNextButton()
        {
            Thread.Sleep(8000);
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //System.Threading.Thread.Sleep(2000);
            //AutoAction.ClickButtonById(appWin, Back_ByID);
            //System.Threading.Thread.Sleep(2000);
            //AutoAction.ClickButtonById(appWin, Next_ByID);
            //System.Threading.Thread.Sleep(2000);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, ConfirmOrdersModel.ConfirmOrdersHost_ByID));
        }

        [TestMethod]
        public void CheckGuestSign()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin, Yes_ByID);
            Assert.IsTrue(AutoElement.EnabledById(appWin, Next_ByID));
        }

        [TestMethod]
        public void ClickNextButtonAndCheckForSwabTestRemoval()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            AutoAction.ClickButtonById(appWin, ConfirmOrdersModel.Ok_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, ConfirmOrdersModel.ConfirmOrdersHost_ByID));
            Assert.IsFalse(AutoElement.EnabledById(appWin, ConfirmOrdersModel.Next_ByID));
        }

        [TestMethod]
        public void ClickBackButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Back_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, BasicInfoModel.BasicInfoHost_ByID));
        }

        [TestMethod]
        public void CheckForAcknowledgeForm()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, AcknowledgementForm_ById));
        }


    }
}

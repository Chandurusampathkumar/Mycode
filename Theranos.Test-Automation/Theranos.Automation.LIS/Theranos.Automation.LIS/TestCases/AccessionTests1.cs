using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.AutoStack;
using TestStack.White.UIItems.WPFUIItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.LIS.TestCases
{
    [TestClass]
    public class AccessionTests1 : AccessionsModel
    {
        public void FinishLabOrderInLisScenario(bool isDirectMode, BasicInfoModel basicInfo)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(LISAppWindowName));
            //var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            var accessionsTab = AutoElement.GetElementByName(appWin, SearchAccessionsTabByName);
            var clickPattern = (InvokePattern)accessionsTab.GetCurrentPattern(InvokePattern.Pattern);
            clickPattern.Invoke();

            //Passing the Guest name from PSC 3.0 to LIS
            //guestName variable contains first name and last name
            var guestName = basicInfo.FirstName + " " + basicInfo.LastName;
            AutoAction.SetTextById(appWin, SearchBoxById, guestName);

            //AutoAction.SetTextById(appWin, SearchBoxById, SampleTestPatientNameString);
            AutoAction.ClickButtonById(appWin, SearchButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DataGridById);
            //var distributionGrid = appWin.Get<ListView>(SearchCriteria.ByAutomationId(DataGridById));
            //var firstRow = distributionGrid.Rows[0];

            var distributedGrid = appWin.Get<ListViewRow>(SearchCriteria.ByClassName("DataGridRow"));
            var name = distributedGrid.Cells[4].Name;
            var dob = distributedGrid.Cells[6].Name;

            if (name==guestName)
            {
                distributedGrid.DoubleClick();
            }
            
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonEditRequisitionById);
            AutoAction.ClickButtonById(appWin, ButtonEditRequisitionById);
            var containersTab = appWin.Get<TestStack.White.UIItems.TabItems.TabPage>(SearchCriteria.ByAutomationId(TabContainersById));
            containersTab.Click();
            var tabControl =
                appWin.Get(SearchCriteria.ByAutomationId(TabControlUnderContainersTabById));
            tabControl.Get<ComboBox>(
                SearchCriteria.ByAutomationId(StatusListBoxById));
            var listBox = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StatusListBoxById));
            listBox.Click();
            listBox.Select(3);
            AutoAction.ClickButtonById(appWin, ButtonSaveContainerById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonLabViewById);
            var labViewButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(ButtonLabViewById));
            labViewButton.Click();
            var testList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBoxOfTestsById));
            var numberoftests = testList.Items.Count;
            for (var i = 0; i < numberoftests; i++)
            {
                AutoAction.ClickButtonById(appWin, "LabTests.Expanded" + i + ".TextBox");
                //var resultsLabList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBOxOfTestResultsById));
                //var numberoftestresults = resultsLabList.Items.Count;
                //for (var j = 0; j < numberoftestresults; j++)
                //{
                    AutoAction.ClickButtonById(appWin, "LabTest.LabTestItem.0.LabResultDetail.Edit1.Button");
                    var referenceName = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ReferenceName1.TextBox"));
                    referenceName.Click();
                    referenceName.Select(1);
                    var resultValueTextBox = appWin.Get(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ResultValue1.TextBox"));
                    resultValueTextBox.Click();
                    Thread.Sleep(500);
                    AutoAction.SetTextById(appWin, "LabTest.LabTestItem.0.LabResultEdit.ResultValue1.TextBox", "111");
                    var resultStatus = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ResultStatus1.ComboBox"));
                    resultStatus.Click();
                    resultStatus.Select(1);
                    Thread.Sleep(500);
                    var updateButtons = appWin.Get<Button>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.Update1.Button"));
                    updateButtons.Click();
                //}
            }
            AutoAction.ClickButtonById(appWin, ButtonSendLabResultsById);
            if (!isDirectMode)
            {
                AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonSendAnywayById);
                AutoAction.ClickButtonById(appWin, ButtonSendAnywayById);
            }
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonConfirmSendLabResultById);
            AutoAction.ClickButtonById(appWin, ButtonConfirmSendLabResultById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonFinishSendingReportById);
            AutoAction.ClickButtonById(appWin, ButtonFinishSendingReportById);
            var visitStatus = appWin.GetElement(SearchCriteria.ByAutomationId(TextBlockVisitStatusById));
            Assert.AreEqual(" Status :  Ready for CLS Review", visitStatus.Current.Name, "Visit Status Is Not Updated Successfully!");
            appWin.Close();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindownConfirmCloseById);
            AutoAction.ClickButtonById(appWin, PopUpWindownConfirmCloseById);
        }

        public void FinishLabOrderForMEInLisScenario(bool isDirectMode, MELoginModel basicInfo)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(LISAppWindowName));
            //var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            var accessionsTab = AutoElement.GetElementByName(appWin, SearchAccessionsTabByName);
            var clickPattern = (InvokePattern)accessionsTab.GetCurrentPattern(InvokePattern.Pattern);
            clickPattern.Invoke();

            //Passing the Guest name from PSC 3.0 to LIS
            //guestName variable contains first name and last name
            var guestName = basicInfo.FirstName + " " + basicInfo.LastName;
            AutoAction.SetTextById(appWin, SearchBoxById, guestName);

            //AutoAction.SetTextById(appWin, SearchBoxById, SampleTestPatientNameString);
            AutoAction.ClickButtonById(appWin, SearchButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DataGridById);
            //var distributionGrid = appWin.Get<ListView>(SearchCriteria.ByAutomationId(DataGridById));
            //var firstRow = distributionGrid.Rows[0];

            var distributedGrid = appWin.Get<ListViewRow>(SearchCriteria.ByClassName("DataGridRow"));
            var name = distributedGrid.Cells[4].Name;
            var dob = distributedGrid.Cells[6].Name;

            if (name == guestName)
            {
                distributedGrid.DoubleClick();
            }

            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonEditRequisitionById);
            AutoAction.ClickButtonById(appWin, ButtonEditRequisitionById);
            var containersTab = appWin.Get<TestStack.White.UIItems.TabItems.TabPage>(SearchCriteria.ByAutomationId(TabContainersById));
            containersTab.Click();
            var tabControl =
                appWin.Get(SearchCriteria.ByAutomationId(TabControlUnderContainersTabById));
            tabControl.Get<ComboBox>(
                SearchCriteria.ByAutomationId(StatusListBoxById));
            var listBox = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StatusListBoxById));
            listBox.Click();
            listBox.Select(3);
            AutoAction.ClickButtonById(appWin, ButtonSaveContainerById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonLabViewById);
            var labViewButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(ButtonLabViewById));
            labViewButton.Click();
            var testList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBoxOfTestsById));
            var numberoftests = testList.Items.Count;
            for (var i = 0; i < numberoftests; i++)
            {
                AutoAction.ClickButtonById(appWin, "LabTests.Expanded" + i + ".TextBox");
                //var resultsLabList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBOxOfTestResultsById));
                //var numberoftestresults = resultsLabList.Items.Count;
                //for (var j = 0; j < numberoftestresults; j++)
                //{
                AutoAction.ClickButtonById(appWin, "LabTest.LabTestItem.0.LabResultDetail.Edit1.Button");
                var referenceName = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ReferenceName1.TextBox"));
                referenceName.Click();
                referenceName.Select(1);
                var resultValueTextBox = appWin.Get(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ResultValue1.TextBox"));
                resultValueTextBox.Click();
                Thread.Sleep(500);
                AutoAction.SetTextById(appWin, "LabTest.LabTestItem.0.LabResultEdit.ResultValue1.TextBox", "111");
                var resultStatus = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.ResultStatus1.ComboBox"));
                resultStatus.Click();
                resultStatus.Select(1);
                Thread.Sleep(500);
                var updateButtons = appWin.Get<Button>(SearchCriteria.ByAutomationId("LabTest.LabTestItem.0.LabResultEdit.Update1.Button"));
                updateButtons.Click();
                //}
            }
            AutoAction.ClickButtonById(appWin, ButtonSendLabResultsById);
            if (!isDirectMode)
            {
                AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonSendAnywayById);
                AutoAction.ClickButtonById(appWin, ButtonSendAnywayById);
            }
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonConfirmSendLabResultById);
            AutoAction.ClickButtonById(appWin, ButtonConfirmSendLabResultById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonFinishSendingReportById);
            AutoAction.ClickButtonById(appWin, ButtonFinishSendingReportById);
            var visitStatus = appWin.GetElement(SearchCriteria.ByAutomationId(TextBlockVisitStatusById));
            Assert.AreEqual(" Status :  Ready for CLS Review", visitStatus.Current.Name, "Visit Status Is Not Updated Successfully!");
            appWin.Close();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindownConfirmCloseById);
            AutoAction.ClickButtonById(appWin, PopUpWindownConfirmCloseById);
        }

        //[TestMethod]
        //public void sample()
        //{
        //    AccessionsTests test = new AccessionsTests();
        //    test.FinishLabOrderInLis(false,"harryK","saz",01/01/1990);
        //}
    }
}

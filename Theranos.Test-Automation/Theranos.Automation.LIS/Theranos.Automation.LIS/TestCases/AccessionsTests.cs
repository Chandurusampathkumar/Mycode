using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Controls;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.AutoStack;
using TestStack.White.UIItems.WPFUIItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Button = TestStack.White.UIItems.Button;
using ComboBox = TestStack.White.UIItems.ListBoxItems.ComboBox;
using ListBox = TestStack.White.UIItems.ListBoxItems.ListBox;
using ListView = TestStack.White.UIItems.ListView;


//@Author Fangming Lu

namespace Theranos.Automation.LIS.TestCases
{
    [TestClass]
    public class AccessionsTests : AccessionsModel 
    {
        public Window AppWin;

        /// <summary>
        /// Verify a new user can be finished edit lab test results in LIS.
        /// </summary>
        //[TestCategory(AppSettings.Unit), TestMethod()]
        public void FinishLabOrderInLis(bool isDirectMode, string firstName, string lastName, DateTime DOB)
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            var accessionsTab = AutoElement.GetElementByName(appWin, SearchAccessionsTabByName);
            var clickPattern = (InvokePattern) accessionsTab.GetCurrentPattern(InvokePattern.Pattern);
            clickPattern.Invoke();

            //Passing the Guest name from PSC 3.0 to LIS
            //guestName variable contains first name and last name
            //var guestName = basicInfo.FirstName + " " + basicInfo.LastName;
            //AutoAction.SetTextById(appWin, SearchBoxById, guestName);

            AutoAction.SetTextById(appWin, SearchBoxById, SampleTestPatientNameString);
            AutoAction.ClickButtonById(appWin, SearchButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DataGridById);
            var distributionGrid = appWin.Get<ListView>(SearchCriteria.ByAutomationId(DataGridById));
            var firstRow = distributionGrid.Rows[0];
            for (var row = 0; row < distributionGrid.Rows.Count; row++)
            {
                var line = distributionGrid.Rows[row];
                //if ((line.Cells[4].Name == guestName) && line.Cells[6].Name == basicInfo.DOB)
                //{
                //    line.DoubleClick();
                //}
                if ((line.Cells[4].Name == firstName + " " + lastName) &&
                    line.Cells[6].Name == DOB.Month + "/" + DOB.Day + "/" + DOB.Year)
                {
                    line.DoubleClick();
                }
            }

            // Assert.AreEqual("3157", firstRow.Cells[0].Name);
            firstRow.DoubleClick();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonEditRequisitionById);
            AutoAction.ClickButtonById(appWin, ButtonEditRequisitionById);
            var containersTab =
                appWin.Get<TestStack.White.UIItems.TabItems.TabPage>(SearchCriteria.ByAutomationId(TabContainersById));
            containersTab.Click();
            var tabControl =
                appWin.Get(SearchCriteria.ByAutomationId(TabControlUnderContainersTabById));
            var containerList = tabControl.Get<ListBox>(SearchCriteria.ByAutomationId(ListBoxEditContainersById));
            var numberOfContainers = containerList.Items.Count;
            for (var i = 0; i < numberOfContainers; i++)
            {   
            var listBox =
                appWin.Get<ComboBox>(
                    SearchCriteria.ByAutomationId("EditRequisitionDetails.AssociatedContainers."+ i +".StatusList" + i +
                                                  ".ComboBox"));
            listBox.Click();
            listBox.Select(3);  
            }

            AutoAction.ClickButtonById(appWin, ButtonSaveContainerById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            //AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindowOkButtonById);
            //AutoAction.ClickButtonById(appWin, PopUpWindowOkButtonById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ButtonLabViewById);
            var labViewButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(ButtonLabViewById));
            labViewButton.Click();
            var testList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBoxOfTestsById));
            var numberoftests = testList.Items.Count;
            for(var i = 0 ;i < numberoftests ;i++){
                AutoAction.ClickButtonById(appWin, "LabTests.Expanded" + i +".TextBox");
                var resultsLabList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBOxOfTestResultsById));
                var numberoftestresults = resultsLabList.Items.Count;
                for (var j = 1; j < numberoftestresults; j++)
                {
                    AutoAction.ClickButtonById(appWin, "LabTest.LabTestItem."+i+ ".LabResultDetail.Edit"+ j + ".Button");
                    var referenceName = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.ReferenceName" + j + ".TextBox"));
                    referenceName.Click();
                    referenceName.Select(1);
                    var resultValueTextBox = appWin.Get(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.ResultValue" + j + ".TextBox"));
                    resultValueTextBox.Click();
                    Thread.Sleep(500);
                    //some test results need to click the combobox to choose positive or not
                    if (appWin.Get<ListBox>(SearchCriteria.ByAutomationId("lstEnumResult")).Items.Count > 0)
                    {
                        var resultValues =
                            appWin.Get<ListBox>(
                                SearchCriteria.ByAutomationId("lstEnumResult"));
                        resultValues.Click();
                        resultValues.Select(1);
                    }
                    // other tests just need input value directly
                    else
                    {
                        AutoAction.SetTextById(appWin,
                            "LabTest.LabTestItem." + i + ".LabResultEdit.ResultValue" + j + ".TextBox", "111");
                    }
                    var resultStatus = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.ResultStatus" + j + ".ComboBox"));
                    resultStatus.Click();
                    resultStatus.Select(1);
                    Thread.Sleep(500);
                    var updateButtons = appWin.Get<Button>(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.Update" + j + ".Button"));
                    updateButtons.Click();
                }
                AutoAction.ClickButtonById(appWin, "LabTests.Collapsed" + i + ".TextBox");
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
            Assert.AreEqual(" Status :  Ready for CLS Review",visitStatus.Current.Name,"Visit Status Is Not Updated Successfully!");
            appWin.Close();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, PopUpWindownConfirmCloseById);
            AutoAction.ClickButtonById(appWin, PopUpWindownConfirmCloseById);
        }
    }
}
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
using System.Collections.Generic;

namespace Theranos.Automation.LIS.TestCases
{

    [TestClass]
    public class UpdatedTestResult:AccessionsModel
    {

        [TestMethod]
        public void Test()
        {
            UpdateTestResult();
        }

        public List<TestResult1> UpdateTestResult()
        {
            List<TestResult1> update = new List<TestResult1>();
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(LISAppWindowName));

            //var labViewButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(ButtonLabViewById));
            //labViewButton.Click();
            var testList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBoxOfTestsById));
            var numberoftests = testList.Items.Count;
            for (var i = 0; i < numberoftests; i++)
            {
                TestResult1 tstRslt = new TestResult1();
                var testName = AutoElement.GetElementById(appWin, "LabTests.ShowGrid" + i + ".Button");
                var items = AutoElement.GetAllChilderen(testName);
                tstRslt.TestName = items[4].Current.Name;
                AutoAction.ClickButtonById(appWin, "LabTests.Expanded" + i + ".TextBox");
                var resultsLabList = appWin.Get<ListBox>(SearchCriteria.ByAutomationId(ListBOxOfTestResultsById));
                var numberoftestresults = resultsLabList.Items.Count;
               
                tstRslt.test = new List<TestResult>();
                for (var j = 0; j < numberoftestresults; j++)
                {
                    TestResult temp = new TestResult();
                    AutoAction.ClickButtonById(appWin, "LabTest.LabTestItem." + i + ".LabResultDetail.Edit" + j + ".Button");
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
                    AutoAction.SendTabKey();
                    temp.ResultValues = AutoElement.GetTextBoxValueById(appWin, "LabTest.LabTestItem." + i + ".LabResultEdit.ResultValue" + j + ".TextBox");
                    temp.ResultRange = AutoElement.GetElementNameById(appWin, "LabTest.LabTestItem."+i+".LabResultEdit.ResultRangeType"+j+".TextBlock");
                    tstRslt.test.Add(temp);
                    var resultStatus = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.ResultStatus" + j + ".ComboBox"));
                    resultStatus.Click();
                    resultStatus.Select(1);
                    Thread.Sleep(500);
                    var updateButtons = appWin.Get<Button>(SearchCriteria.ByAutomationId("LabTest.LabTestItem." + i + ".LabResultEdit.Update" + j + ".Button"));
                    updateButtons.Click();
                }
                update.Add(tstRslt);
                AutoAction.ClickButtonById(appWin, "LabTests.Collapsed" + i + ".TextBox");
            } 
            return update;
        }
    }
}

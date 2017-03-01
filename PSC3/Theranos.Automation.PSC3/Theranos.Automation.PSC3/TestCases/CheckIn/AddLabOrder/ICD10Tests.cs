
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder
{
    [TestClass]
    public class ICD10Tests:ICD10Model
    {
        [TestMethod]
        public void AddICD10ByCode()
        {
            var testPassed = false;
            var itemSelected = false;
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, ICD10_ByID);

            var host = AutoElement.GetElementById(appWin, ICDModel.ICDHost_ByID);
            var testEdit = AutoElement.GetElementById(host, ICDModel.ICD9TestName_ByID);

            var records = CSVHelper.GetRecords<ICD10Model>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);

            UIAutoHelper.performValuePattern(testEdit,records[i].ICDCode.Substring(1).Trim());

            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            Thread.Sleep(2 * WaitTime);

            var popUp = appWin.GetElement(SearchCriteria.ByClassName(PSC3Model.Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ICDModel.ICDListItem_ByName);

            inputData = "ICD Code: " + records[i].ICDCode + ", ICD Name: " + records[i].ICDName;
            int itemsCount;

            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var listItemText = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children);
                        //var listItemText = item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var icdCodeAndText = listItemText.Current.Name.Split('(');
                        if (records[i].ICDCode.Substring(1).Trim() == icdCodeAndText[0].Trim())
                        {

                            UIAutoHelper.ScrollIntoView(item);
                            UIAutoHelper.performSelectionItemPattern(item);
                            AutoAction.SendTabKey();
                            itemSelected = true;
                            break;
                        }
                    }

                    if (itemSelected)
                    {
                        break;
                    }

                    UIAutoHelper.ScrollIntoView(listItems[itemsCount - 1]);
                    listItems = AutoElement.GetElementCollectionByName(popUp, ICDModel.ICDListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ICDListItem_ByName));

                } while (itemsCount != listItems.Count);
            }

            else
            {
                Assert.Fail("No results were displayed for the data " + inputData);
            }
            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass, TreeScope.Children);
            foreach (AutomationElement item in textBlockCollection)
            {
                if (item.Current.Name.Contains(records[i].ICDCode.Substring(1).Trim()))
                {
                    testPassed = true;
                    break;
                }
            }
            Assert.IsTrue(testPassed, "Selected ICD is not displayed in the list " + inputData);
        }

        [TestMethod]
        public void ADDICD10ByName()
        {
            bool testPassed = false;
            var itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, ICDModel.ICDHost_ByID);
            AutoAction.ClickRadioButtonById(appWin, ICD10_ByID);
            var testEdit = AutoElement.GetElementById(host, ICDModel.ICD9TestName_ByID);
            var inputData = "";

            var records = CSVHelper.GetRecords<ICD10Model>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);


            char[] delimitedChars = { '(', ' ', ')' };
            UIAutoHelper.performValuePattern(testEdit, records[i].ICDName.Replace("\"", "").Trim().Split(delimitedChars)[1]);

            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            Thread.Sleep(2 * WaitTime);
            inputData = "ICD Code: " + records[i].ICDCode + ", ICD Name: " + records[i].ICDName;
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(PSC3Model.Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ICDModel.ICDListItem_ByName);
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var listItemText = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children);
                        var icdCodeAndText = listItemText.Current.Name.Split('(');
                        if (records[i].ICDCode.Split('\'')[1].Trim() == icdCodeAndText[0].Trim())
                        {

                            UIAutoHelper.ScrollIntoView(item);
                            UIAutoHelper.performSelectionItemPattern(item);
                            AutoAction.SendTabKey();
                            itemSelected = true;
                            break;
                        }
                    }

                    if (itemSelected)
                    {
                        break;
                    }

                    UIAutoHelper.ScrollIntoView(listItems[itemsCount - 1]);
                    listItems = AutoElement.GetElementCollectionByName(popUp, ICDModel.ICDListItem_ByName);

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }


            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass, TreeScope.Children);
            foreach (AutomationElement item in textBlockCollection)
            {
                if (item.Current.Name.Contains(records[i].ICDCode.Split('\'')[1].Trim()))
                {
                    testPassed = true;
                    break;
                }
            }
            Assert.IsTrue(testPassed, "Selected ICD is not displayed in the list " + inputData);
        }
    }
}

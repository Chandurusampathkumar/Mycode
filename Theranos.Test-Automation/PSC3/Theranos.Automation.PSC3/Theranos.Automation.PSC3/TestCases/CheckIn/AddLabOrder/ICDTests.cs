
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
    public class ICDTests:ICDModel
    {
       
        /// <summary>
        /// CTC-53: Verify user is able to add ICD by its code.
        /// </summary>
        [TestMethod]
        public void AddICDByCode()
        {

            bool testPassed = false;
            var itemSelected = false;
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, ICDHost_ByID);
            AutoAction.ClickRadioButtonById(appWin,ICD9_ByID);
            //var spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
            var testEdit = AutoElement.GetElementById(host,ICD9TestName_ByID);
            //var testEdit = host.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, ICD9TestName_ByID));

            var records = CSVHelper.GetRecords<ICDModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);

            //Workaround for network related problem
            //#region
            //Util.SetText(testEdit, "E001.1");
            //Thread.Sleep(3 * WaitTime);
            //#endregion

            UIAutoHelper.performValuePattern(testEdit, records[i].ICDCode.Split('\'')[1].Trim());

            //do
            //{
            //    Thread.Sleep(5 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            Thread.Sleep(2*WaitTime);

            var popUp = appWin.GetElement(SearchCriteria.ByClassName(PSC3Model.Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp,ICDListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ICDListItem_ByName));
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ICDListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ICDListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data "+inputData);
            }

            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass, TreeScope.Descendants);
            //var textBlockCollection = host.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
            foreach (AutomationElement item in textBlockCollection)
            {
                if (item.Current.Name.Contains(records[i].ICDCode.Split('\'')[1].Trim()))
                {
                    testPassed = true;
                    break;
                }
            }
            Assert.IsTrue(testPassed, "Selected ICD is not displayed in the list "+inputData);
        }

        /// <summary>
        /// CTC-54: Verify user is able to add ICD by its name.
        /// </summary>
        [TestMethod]
        public void AddICDByName()
        {
            bool testPassed = false;
            var itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, ICDHost_ByID);
            AutoAction.ClickRadioButtonById(appWin, ICD9_ByID);
            //var spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
            var testEdit = AutoElement.GetElementById(host, ICD9TestName_ByID);
            //var testEdit = host.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, ICD9TestName_ByID));
            var inputData = "";

            var records = CSVHelper.GetRecords<ICDModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);

            //Workaround for network related problem
            //#region
            //Util.SetText(testEdit, "Activities");
            //Thread.Sleep(3 * WaitTime);
            //#endregion

            char[] delimitedChars={'(',' ',')'};
            UIAutoHelper.performValuePattern(testEdit, records[i].ICDName.Replace("\"","").Trim().Split(delimitedChars)[1]);

            //do
            //{
            //    Thread.Sleep(5 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            Thread.Sleep(2*WaitTime);
            inputData = "ICD Code: " + records[i].ICDCode + ", ICD Name: " + records[i].ICDName;
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(PSC3Model.Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ICDListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ICDListItem_ByName));
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ICDListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ICDListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, "+inputData);
            }


            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass, TreeScope.Descendants);
            //var textBlockCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
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

        /// <summary>
        /// CTC-55: Verify user is able to remove ICD code.
        /// </summary>
        [TestMethod]
        public void RemoveICD()
        {
            int i = 0;
            bool testRemoved = false;
            bool removeConfirmed = true;
            string icdName = "";
            var inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, ICDHost_ByID);
            //var elementCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));
            var elementCollection = host.FindAll(TreeScope.Descendants, Condition.TrueCondition);


            foreach (AutomationElement element in elementCollection)
            {
                if (element.Current.ClassName == "Button")
                {

                      UIAutoHelper.ClickElement(element);
                      testRemoved = true;
                      icdName = elementCollection[i - 1].Current.Name;
                      inputData = "Test Name: " + icdName;
                      break;
                }
                i++;
            }
            Assert.IsTrue(testRemoved, "No test available to remove");

            var textCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass, TreeScope.Children);
            //var textCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
            foreach (AutomationElement textItem in textCollection)
            {
                if (textItem.Current.Name == icdName)
                {
                    removeConfirmed = false;
                    break;
                }
            }

            Assert.IsTrue(removeConfirmed,"Test remove is not confirmed for data "+inputData);
        }
   
    }
}

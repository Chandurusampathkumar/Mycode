
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using System.Collections.Generic;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder
{
    [TestClass]
    public class CPTTests:CPTModel
    {
        [TestMethod]
        public void CPTTestMandatory()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            Thread.Sleep(2*WaitTime);
            if (appWin.Exists(SearchCriteria.ByAutomationId(ClinicianSave_ByID)))
            {
                var clinicianSave = appWin.GetElement(SearchCriteria.ByAutomationId(ClinicianSave_ByID));
           
                if ((clinicianSave.Current.IsEnabled))
                {
                    Assert.Fail("Save button is enabled");
                }
            }
            else if (appWin.Exists(SearchCriteria.ByAutomationId(SaveDirectTesting_ById)))
            {
                var directSave = appWin.GetElement(SearchCriteria.ByAutomationId(SaveDirectTesting_ById));
                if (directSave.Current.IsEnabled)
                {
                    Assert.Fail("Save button is enabled");
                }
            }
            
        }

        

        /// <summary>
        /// CTC-49: Verify user is able to add test by entering CPT code.
        /// </summary>
        [TestMethod]
        public void AddTestByCode()
        {
            bool testPassed = false;
            var itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,CPTHost_ByID);
            //var host = appWin.GetElement(SearchCriteria.ByAutomationId(CPTHost_ByID));        
        //    var spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
            var testEdit = AutoElement.GetElementById(host,TestName_ByID);
            //var testEdit = host.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, TestName_ByID));
            string inputData = "";
            var records = CSVHelper.GetRecords<CPTModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);
            inputData = "CPT Code: " + records[i].CPTCode + ", Test Name: " + records[i].TestName + ", Price: " + records[i].Price;

            //Workaround for network related problem
            //#region
            //Util.SetText(testEdit, "82610");
            //Thread.Sleep(3 * WaitTime);
            //#endregion
            
            UIAutoHelper.performValuePattern(testEdit, records[i].CPTCode.Trim());
            Thread.Sleep(2*WaitTime);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            //do
            //{
            //    Thread.Sleep(5 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);

            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));

            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp,CPTListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, CPTListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { '-' };
                        var listItemText = AutoElement.GetElementByClassName(item,TextBlock_ByClass,TreeScope.Children);
                        //var listItemText = item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var cptCodeAndText = listItemText.Current.Name.Split('-');
                        if (records[i].CPTCode.Trim() == cptCodeAndText[0].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp,CPTListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, CPTListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, "+inputData);
            }
            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host,TextBlock_ByClass);
            //var textBlockCollection=host.FindAll(TreeScope.Children,new PropertyCondition(AutomationElement.ClassNameProperty,TextBlock_ByClass));
            foreach (AutomationElement item in textBlockCollection)
            {
                if (item.Current.Name.Contains(records[i].CPTCode.Trim()))
                {
                    testPassed = true;
                    break;
                }
            }

            Assert.IsTrue(testPassed, "Selected test is not displayed in the list. Data, "+inputData);
        }

        /// <summary>
        /// CTC-50: Verify user is able to add test by entering test name.
        /// </summary>
        [TestMethod]
        public void AddTestByName()
        {
            var itemSelected = false;
            bool testPassed = false;
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, CPTHost_ByID);
         //   var spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
            var testEdit = AutoElement.GetElementById(host, TestName_ByID);
            //var testEdit = host.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, TestName_ByID));

            var records = CSVHelper.GetRecords<CPTModel>(InputFileName);
            

            //Workaround for network related problem
            //#region
            //Util.SetText(testEdit, "Digoxin");
            //Thread.Sleep(3 * WaitTime);
            //#endregion
            

            //char[] delimiterChars = { ',' };
            string tName = "";
            int i;
            do
            {
                i = UtilityClass.GetRandomNumber(0, records.Count);
                tName = records[i].TestName.Replace("\"", "").Replace(",", "").Trim().Split(' ')[0];
            } while (tName.Length<3);
            
            UIAutoHelper.performValuePattern(testEdit, tName);
            Thread.Sleep(2*WaitTime);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);

            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, CPTListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, CPTListItem_ByName));
            inputData = "CPT Code: " + records[i].CPTCode + ", Test Name: " + records[i].TestName + ", Price: " + records[i].Price;
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { '-' };
                        var listItemText = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children);
                        //var listItemText = item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var cptCodeAndText = listItemText.Current.Name.Split('-');
                        if (records[i].CPTCode.Trim() == cptCodeAndText[0].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, CPTListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, CPTListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
               Assert.Fail("INVALID TEST DATA!!! No results were displayed for the data "+inputData);
                
            }

            var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
            //var textBlockCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
            foreach (AutomationElement item in textBlockCollection)
            {
                if (item.Current.Name.Contains(records[i].CPTCode.Trim()))
                {
                    testPassed = true;
                    break;
                }
            }
            Assert.IsTrue(testPassed, "Selected test is not displayed in the list for the data, " + inputData);

        }

        /// <summary>
        /// CTC-51: Verify user is able to add one of the physician favorite test.
        /// </summary>
        [TestMethod]
        public void AddTestByFavourites()
        {

            bool clickButton = true;
            bool isTestAdded = false;
            bool isFavouritesAvailable = false;
            bool isTestMatched=false;
            string testName = "";
            string inputData="";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, CPTHost_ByID);
            var buttonCollection = AutoElement.GetElementCollectionByClassName(host,Button_ByClass);
            //var buttonCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));
            var textCollection = AutoElement.GetElementCollectionByClassName(host,TextBlock_ByClass,TreeScope.Children);
            //var textCollection=host.FindAll(TreeScope.Children,new PropertyCondition(AutomationElement.ClassNameProperty,TextBlock_ByClass));
            foreach (AutomationElement button in buttonCollection)
            {
                clickButton = true;
                var textChild = AutoElement.GetElementByClassName(button,TextBlock_ByClass,TreeScope.Children);
                //var textChild = button.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                if (textChild!=null)
                {
                    isFavouritesAvailable = true;
                    foreach (AutomationElement text in textCollection)
                    {
                        if (text.Current.Name==textChild.Current.Name)
                        {
                            clickButton = false;
                        }
                    }
                    if (clickButton)
                    {
                        //Util.GetCurrentMethod
                        UIAutoHelper.ClickElement(button);
                        testName = textChild.Current.Name;
                        inputData = "Test Name: " + testName;
                        isTestAdded = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(isFavouritesAvailable,"No Favorites are available for the selected clinician");
            Assert.IsTrue(isTestAdded, "DATA INVALID!!!!, All available favorite tests are already selected");

            textCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
            //textCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
            foreach (AutomationElement text in textCollection)
            {
                if (text.Current.Name == testName)
                {
                    isTestMatched=true;
                    break;
                }
            }

            Assert.IsTrue(isTestMatched,"Selected Favorite is not reflected in the list, "+inputData);
            
        }

        /// <summary>
        /// CTC-52: Verify user is able to remove selected test.
        /// </summary>
        [TestMethod]
        public void RemoveTests()
        {
            int i=0;
            bool testRemoved = false;
            //bool removeConfirmed = true;
            string testName = "";
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, CPTHost_ByID);
            //var elementCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));
            var elementCollection = host.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            int testCountInitial = 0;
            int testCount = 0;


            foreach (AutomationElement element in elementCollection)
            {
                if (element.Current.ClassName == "Button")
                {
                    var textChild = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                    if (textChild == null)
                    {
                        
                        testName = elementCollection[i - 1].Current.Name;
                        var textCollection1 = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
                        //var textCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        foreach (AutomationElement textItem in textCollection1)
                        {
                            if (textItem.Current.Name == testName)
                            {
                                testCountInitial++;
                            }
                        }

                        inputData= "Test Name: " + testName;
                        UIAutoHelper.ClickElement(element);
                        testRemoved = true;
                        break;
                    }
                }
                i++;
            }
            Assert.IsTrue(testRemoved, "INVALID DATA!!!, No test available to remove");

            var textCollection2 = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
            //var textCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
            foreach (AutomationElement textItem in textCollection2)
            {
                if (textItem.Current.Name==testName)
                {
                    testCount++;
                }
            }

            Assert.IsTrue(testCountInitial-1==testCount, "Test remove is not confirmed "+inputData);
        }

       //[TestMethod]
       // public void SaveDetailsClincianOrder()
       // {
       //     var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
       //     var button = appWin.GetElement(SearchCriteria.ByAutomationId(ClinicianSave_ByID));
       //     UIAutoHelper.performInvokePattern(button);
       // }

       //[TestMethod]
       //public void SaveDetailsDirectingTesting()
       //{
       //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
       //    var button = appWin.GetElement(SearchCriteria.ByAutomationId(SaveDirectTesting_ById));
       //    UIAutoHelper.performInvokePattern(button);
       //}


        [TestCategory(AppSettings.Unit),TestMethod()]
        public void SaveDetails()
       {
           var appWin = AutoElement.GetWindowByName(AppWindowName);
           
           if (AutoElement.ExistsByIdNoWait(appWin,SaveDirectTesting_ById))
           {
               AutoAction.ClickButtonById(appWin, SaveDirectTesting_ById);
           }
           else if (AutoElement.ExistsByIdNoWait(appWin, ClinicianSave_ByID)) //Todo: Update it oce automation id is received
           {
               AutoAction.ClickButtonById(appWin, ClinicianSave_ByID);    
           }
           
       }

        //[TestMethod]
        //public void AddTestWithCodeA()
        //{
        //    AddTestWithCode("85379", "D-Dimer ");
        //}

        //CTC-41, : Verify user is able to scan lab order for Direct Testing, add Tests and Panels
       public void AddTestWithCode(string CPTCode,string CPTName)
       {
           bool testPassed = false;
           var itemSelected = false;
           var appWin = AutoElement.GetWindowByName(AppWindowName);
           var host = AutoElement.GetElementById(appWin,CPTHost_ByID);
           var spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
           var testEdit = AutoElement.GetElementById(host, TestName_ByID);
           //var testEdit = host.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, TestName_ByID));
           string inputData = "";
           //var records = CSVHelper.GetRecords<CPTModel>(InputFileName);
           //int i = UtilityClass.GetRandomNumber(0, records.Count);
           inputData = "CPT Code: " + CPTCode + ", Test Name: " + CPTName;

           //Workaround for network related problem
           //#region
           //Util.SetText(testEdit, "82610");
           //Thread.Sleep(3 * WaitTime);
           //#endregion

           UIAutoHelper.performValuePattern(testEdit, CPTCode.Trim()); 
           Thread.Sleep(2*WaitTime);

           AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

           //do
           //{
           //    Thread.Sleep(5 * WaitTime);
           //} while (!spinner.Current.IsOffscreen);

           var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));

           //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, CPTListItem_ByName));
           var listItems = AutoElement.GetElementCollectionByName(popUp , CPTListItem_ByName);
           int itemsCount;
           if (listItems.Count != 0)
           {
               do
               {
                   itemsCount = listItems.Count;

                   foreach (AutomationElement item in listItems)
                   {
                       char[] delimiterChars = { '-' };
                       //var listItemText = item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                       var listItemText = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children);
                       var cptCodeAndText = listItemText.Current.Name.Split('-');
                       if (CPTCode.Trim() == cptCodeAndText[0].Trim())
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
                   listItems = AutoElement.GetElementCollectionByName(popUp, CPTListItem_ByName);

               } while (itemsCount != listItems.Count);
           }
           else
           {
               Assert.Fail("No results were displayed for the data, " + inputData);
           }

           var textBlockCollection = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
           foreach (AutomationElement item in textBlockCollection)
           {
               if (item.Current.Name.Contains(CPTCode.Trim()))
               {
                   testPassed = true;
                   break;
               }
           }

           Assert.IsTrue(testPassed, "Selected test is not displayed in the list. Data, " + inputData);
       }

       //Checkin TC -231 To verify the panels are displayed for the exact codes.
        [TestMethod]
       public void verifyaddedtest()
       {

           int i = 0;
          // bool testRemoved = false;
          // bool removeConfirmed = true;
           string testName = "";
           string inputData = "";
           var appWin = AutoElement.GetWindowByName(AppWindowName);
           var host = AutoElement.GetElementById(appWin, CPTHost_ByID);
           var elementCollection = host.FindAll(TreeScope.Descendants, Condition.TrueCondition);
           int testCountInitial = 0;
          // int testCount = 0;
           List<String> fromele = new List<string>();

        String testtype1 = "T700265  -  Hepatitis B (HBV) Surface Antigen (HBsAg) with reflex to HBsAg confirmation";
        String testtype2 = "T700230  -  Syphilis Screen (Treponema Pallidum Antibody) with reflex to RPR with reflex to TP-PA";

           foreach (AutomationElement element in elementCollection)
           {
               if (element.Current.ClassName == "Button")
               {
                   var textChild = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                   if (textChild == null)
                   {

                       testName = elementCollection[i - 1].Current.Name;
                       var textCollection1 = AutoElement.GetElementCollectionByClassName(host, TextBlock_ByClass);
                       //var textCollection = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                       foreach (AutomationElement textItem in textCollection1)
                       {
                           if (textItem.Current.Name == testName)
                           {
                               String value2 = textItem.Current.Name;
                               fromele.Add(value2);
                               
                               testCountInitial++;
                           }
                       }

                       inputData = "Test Name: " + testName;
                   }
               }
               i++;
             
           }

           Assert.AreEqual(fromele[0], testtype1, "T700265 test type is not available.");
           Assert.AreEqual(fromele[1], testtype2, "T700230 test type is not available.");      
       }

    }
}

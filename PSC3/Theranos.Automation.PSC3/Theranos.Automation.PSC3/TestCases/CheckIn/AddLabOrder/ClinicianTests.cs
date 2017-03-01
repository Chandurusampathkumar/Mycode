
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder
{
    [TestClass]
    public class ClinicianTests:ClinicianModel
    {

        [TestMethod]
        public void ClinicianDetailMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //Assert.IsTrue(AutoElement.EnabledById(appWin,Next_ByID));
            var clinicianDetailNext = appWin.GetElement(SearchCriteria.ByAutomationId(Next_ByID));
            if ((clinicianDetailNext.Current.IsEnabled))
            {
                Assert.Fail("Order instructions elements or Next button are enabled");
            }
        }


        /// <summary>
        /// CTC-40, CTC-47: Verify user is able to select the clinician details(using Name) including Location. Also verify user is able to enter notes.
        /// </summary>
        [TestMethod]
        public void ClinicianDetailsName()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var host = AutoElement.GetElementByClassName(appWin,ClinicianHost_ByClass);
            //AutomationElement spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));
            bool itemSelected = false;
            var records = CSVHelper.GetRecords<ClinicianModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);
            string inputData = "";

            //Workaround for network related problem
            //#region
            //Actions.SetTextByAutomationID(appWin, Clinician_ByID, "Phaaa");
            //Thread.Sleep(3 * WaitTime);
            //#endregion

            AutoAction.SetTextById(appWin, Clinician_ByID, records[i].ClinicianName.Replace("\"", "").Trim());
            //do
            //{
            //    Thread.Sleep(3 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);
            //Thread.Sleep(2*WaitTime);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);
            inputData = "NPI: " + records[i].NPI + ", Clinician: " + records[i].ClinicianName + ", Provider: " + records[i].ProviderName + ", Location: " + records[i].LocationName;
           // TestContext.WriteLine(inputData);
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));

            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item, TextBlock_ByClass, TreeScope.Children); 
                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (records[i].NPI.Trim() == NPIAndPhysicain[0].Trim() && records[i].ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp,ClinicianListItem_ByName);

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data" + inputData);
                
            }

            AutoAction.SetTextById(appWin, PhysicianNotes_ById, "physician notes text box accepts data");
            //Need to add Location combo selection after automation ids are available
            //Need to add physician notes after automation ids are available
            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();
            Assert.IsTrue(AutoElement.EnabledById(appWin,Next_ByID), "Next button is not enabled for data, " + inputData);
            //var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            //Assert.IsTrue(nextButton.Enabled, "Next button is not enabled for data, "+inputData);
        }

        /// <summary>
        ///CTC-48: Verify user is able to select the clinician details(using NPI) including Location. Also verify user is able to enter notes.
        /// </summary>
        [TestMethod]
        public void ClinicianDetailsNPI()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByClassName(appWin,ClinicianHost_ByClass);
            //var host = appWin.GetElement(SearchCriteria.ByClassName(ClinicianHost_ByClass));
            var itemSelected = false;
            //AutomationElement spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));

            var records = CSVHelper.GetRecords<ClinicianModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);
            string inputData = "";
            //Workaround for network related problem
            //#region
            //Actions.SetTextByAutomationID(appWin, Clinician_ByID, "Phaaa");
            //Thread.Sleep(3 * WaitTime);
            //#endregion

            AutoAction.SetTextById(appWin, Clinician_ByID, records[i].NPI.Trim());
            //Thread.Sleep(2*WaitTime);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement,SmallSpinner_ByClass);
            //do
            //{
            //    Thread.Sleep(3 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);
            inputData = "NPI: " + records[i].NPI + ", Clinician: " + records[i].ClinicianName + ", Provider: " + records[i].ProviderName + ", Location: " + records[i].LocationName;
            //TestContext.WriteLine(inputData);
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp,ClinicianListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item,TextBlock_ByClass);
                        //var clinicianItem = item.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (records[i].ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }
            AutoAction.SetTextById(appWin, PhysicianNotes_ById, "physician notes text box accepts data");
            //Need to add Location combo selection after automation ids are available
            //Need to add physician notes after automation ids are available
            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();

            var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            Assert.IsTrue(nextButton.Enabled,"Next button is not enabled for data, "+inputData);

            

        }

        // add a clinician from csv and return the clinician model (name+ npi...)
        
        public ClinicianModel GetClinicianDetails()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByClassName(appWin, ClinicianHost_ByClass);
            
            var itemSelected = false;
            

            var records = CSVHelper.GetRecords<ClinicianModel>(InputFileName);
            int i = UtilityClass.GetRandomNumber(0, records.Count);
            string inputData = "";
            
            AutoAction.SetTextById(appWin, Clinician_ByID, records[i].NPI.Trim());
            
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

            inputData = "NPI: " + records[i].NPI + ", Clinician: " + records[i].ClinicianName + ", Provider: " + records[i].ProviderName + ", Location: " + records[i].LocationName;
            
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
            
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item, TextBlock_ByClass);

                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (records[i].ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }

            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();

            var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            Assert.IsTrue(nextButton.Enabled, "Next button is not enabled for data, " + inputData);
            return records[i];


        }

        [TestMethod]
        public void MoveToTestPage()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
        }


        [TestMethod]
        public void ClinicianDetailsNPIWithFavourites()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByClassName(appWin, ClinicianHost_ByClass);
            var itemSelected = false;
            //AutomationElement spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));

            var records = CSVHelper.GetRecords<ClinicianModel>(InputFileName);
            int i; 
            string inputData = "";
            ////Workaround for network related problem
            //#region
            //Actions.SetTextByAutomationID(appWin, Clinician_ByID, "Phaaa");
            //Thread.Sleep(3 * WaitTime);
            //#endregion

            do
            {
             i= UtilityClass.GetRandomNumber(0, records.Count);   
            } while (records[i].HasFavourites==No);
            AutoAction.SetTextById(appWin, Clinician_ByID, records[i].NPI.Trim());

            //Thread.Sleep(2 * WaitTime);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            inputData = "NPI: " + records[i].NPI + ", Clinician: " + records[i].ClinicianName + ", Provider: " + records[i].ProviderName + ", Location: " + records[i].LocationName;
            
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item, TextBlock_ByClass);
                        //var clinicianItem = item.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (records[i].ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }

            //Need to add Location combo selection after automation ids are available
            //Need to add physician notes after automation ids are available

            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();

            var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            Assert.IsTrue(nextButton.Enabled, "Next button is not enabled for data, " + inputData);



        }


        public void ClinicianDetailsWithNPI(ClinicianModel clinician )
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByClassName(appWin, ClinicianHost_ByClass);
            var itemSelected = false;
            //AutomationElement spinner = host.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, SmallSpinner_ByClass));


            string inputData = "";
            AutoAction.SetTextById(appWin,Clinician_ByID,clinician.NPI.Trim());

            //do
            //{
            //    Thread.Sleep(3 * WaitTime);
            //} while (!spinner.Current.IsOffscreen);

            //Thread.Sleep(2 * WaitTime);
            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            inputData = "NPI: " + clinician.NPI + ", Clinician: " + clinician.ClinicianName + ", Provider: " + clinician.ProviderName + ", Location: " + clinician.LocationName;
            
            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
            //AutomationElementCollection listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item, TextBlock_ByClass);
                        //var clinicianItem = item.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (clinician.ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
                    //listItems = popUp.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ClinicianListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }

            //Need to add Location combo selection after automation ids are available
            //Need to add physician notes after automation ids are available

            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();

            var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            Assert.IsTrue(nextButton.Enabled, "Next button is not enabled for data, " + inputData);



        }

        public void ClinicianDetailsWithNPI(string NPI, string ProviderName)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByClassName(appWin, ClinicianHost_ByClass);
            var itemSelected = false;

            string inputData = "";
            AutoAction.SetTextById(appWin, Clinician_ByID, NPI.Trim());

            AutoAction.WaitForBusyBoxByClassName(host, SmallSpinner_ByClass);
            inputData = "NPI: " + NPI + "Provider: " + ProviderName;// ", Location: " + clinician.LocationName;

            var popUp = appWin.GetElement(SearchCriteria.ByClassName(Popup_ByClass));
            AutomationElementCollection listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);

            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        char[] delimiterChars = { ',' };
                        var clinicianItem = AutoElement.GetElementCollectionByClassName(item, TextBlock_ByClass);
                        //var clinicianItem = item.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                        var NPIAndPhysicain = clinicianItem[1].Current.Name.Split(delimiterChars);
                        if (ProviderName.Trim() == NPIAndPhysicain[1].Trim())
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
                    listItems = AutoElement.GetElementCollectionByName(popUp, ClinicianListItem_ByName);
                    

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data, " + inputData);
            }

            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();


            var nextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            Assert.IsTrue(nextButton.Enabled, "Next button is not enabled for data, " + inputData);



        }


       
    }
}

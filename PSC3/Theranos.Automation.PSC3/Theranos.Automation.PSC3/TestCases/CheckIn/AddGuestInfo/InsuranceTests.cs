
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo
{
    [TestClass]
    public class InsuranceTests:InsuranceModel
    {
        BasicInfoTests basic = new BasicInfoTests();

        //CTC-33 : Verify user is able to add an insurance card details..
        public void AddInsurance(bool isPrimary)
        {
            var records = CSVHelper.GetRecords<InsuranceModel>(InputFileName);
            var index = UtilityClass.GetRandomNumber(0, records.Count);
            var insurance = records[index];
            if (isPrimary)
            {
                insurance.InsuranceType = PrimaryInsurance;
            }
            else
            {
                insurance.InsuranceType = OtherInsurance;
            }
            AddInsurance(insurance);
        }

        public void AddInsurance(InsuranceModel insurance)
        {
            bool itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.ClickButtonById(appWin,AddCard_ByID);
            AutoAction.ClickButtonById(appWin, FrontCardScan_ByID);
            AutoAction.ClickButtonById(appWin, BackCardScan_ByID);

            var primary = AutoElement.GetElementNameById(appWin,PrimaryInsurance_ByID);
            Assert.AreEqual(primary,PrimaryInsurance);
            var other = AutoElement.GetElementNameById(appWin, OtherInsurance_ByID);
            Assert.AreEqual(other,OtherInsurance);

            Assert.IsTrue(AutoElement.VisibleById(appWin,PrimaryInsurance_ByID),"Primary Insurance is not available");
            Assert.IsTrue(AutoElement.VisibleById(appWin, OtherInsurance_ByID), "Primary Insurance is not available");

            //var providerEditBox = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, InsuranceProvider_ByID));
            var providerEditBox = AutoElement.GetElementById(appWin,InsuranceProvider_ByID,TreeScope.Descendants);
            UIAutoHelper.performTextPattern(providerEditBox, insurance.InsuranceProvider.Trim().Split(' ')[0]);
          //  var spinner = appWin.GetElement(SearchCriteria.ByClassName(SmallSpinner_ByClass));

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);
            Thread.Sleep(2*WaitTime);
            var providerList = AutoElement.GetElementById(appWin,InsuranceProviderList_ByID);
            //var providerList = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceProviderList_ByID));
            var listItems = AutoElement.GetElementCollectionByName(providerList,InsuranceProviderListItem_ByName);
            //var listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var providerName = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children).Current.Name;
                        //var providerName = (item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass))).Current.Name;
                        if (providerName==insurance.InsuranceProvider.Trim())
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            //var providerListName = AutoElement.GetElementByName(appWin, providerName);
                            UIAutoHelper.performSelectionItemPattern(item);
                            Thread.Sleep(2*WaitTime);
                            //AutoAction.ClickUIItemByName(appWin, providerName);
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
                    listItems=AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
                    //listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data");
            }

            var insuranceNo = UtilityClass.GetRandomNumber(1000000000, 2000000000).ToString();
            AutoAction.SetTextById(appWin, PolicyNumber_ByID,insuranceNo);

            if (insurance.InsuranceType==PrimaryInsurance)
            {
                AutoAction.ClickRadioButtonById(appWin, PrimaryInsurance_ByID);
            }
            else if (insurance.InsuranceType==OtherInsurance_ByID)
            {
                AutoAction.ClickRadioButtonById(appWin, OtherInsurance_ByID);
            }

            AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);


       }

        //CTC-37: Verify user is able to add the Primary Insurance Cards.
        [TestMethod]
        public void AddInsurancePrimary()
        {
            //TODO: Get random record

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insuranceHost = AutoElement.GetElementById(appWin,InsuranceHost_ByID);
            var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;

            AddInsurance(true);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            var currentInsuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;
            if (currentInsuranceCount != insuranceCount + 1)
            {
                Assert.Fail("Unable to primary add insurance details");
            }
        }

        //CTC-36: Verify user is able to add the other Insurance Cards.
        [TestMethod]
        public void AddInsuranceOther()
        {
            //TODO: Get random record
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insuranceHost = AutoElement.GetElementById(appWin, InsuranceHost_ByID);
            var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;
  
            AddInsurance(false);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            
            var currentInsuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;
            if (currentInsuranceCount != insuranceCount + 1)
            {
                Assert.Fail("Unable to add insurance details");
            }
        }


        /// <summary>
        ///CTC-35: Verify user is able to delete an insurance card.
        /// </summary>
        [TestMethod]
        public void DeleteInsurance()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insuranceHost = AutoElement.GetElementById(appWin,InsuranceHost_ByID);
            //var insuranceHost = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceHost_ByID));
            var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;

            if (insuranceCount==0)
            {
                Assert.Fail("No insurance available to delete");
            }
            //var insuranceInfo = AutoElement.GetElementByName(appWin,InsuranceListItem_ByName);
            var insuranceInfo = appWin.Get(SearchCriteria.ByText(InsuranceListItem_ByName));
            
            var name = insuranceInfo.GetElement(SearchCriteria.ByClassName(Text_ByClass)).Current.Name;
            //var insuranceListName = AutoElement.GetElementByName(appWin,InsuranceListItem_ByName);
            //UIAutoHelper.performInvokePattern(insuranceListName);
            AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
            AutoAction.ClickButtonById(appWin, DeleteInsurance_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            var currentInsuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;
            if (currentInsuranceCount != insuranceCount - 1)
            {
                Assert.Fail("Unable to delete insurance details");
            }
           
        }

        //[TestMethod]
        //public void EditInsurance()
        //{
        //    var appWin = AutoElement.GetWindowByName(AppWindowName);
        //    var insuranceHost = AutoElement.GetElementById(appWin, InsuranceHost_ByID);
        //    var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;

        //    if (insuranceCount == 0)
        //    {
        //        Assert.Fail("No insurance available to delete");
        //    }
        //    else
        //    {
        //        var records = CSVHelper.GetRecords<InsuranceModel>(InputFileName);
        //        int index;

                
        //        AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
        //        var insuranceProvider = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(InsuranceProvider_ByID)).Text;
        //        var policyNo = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PolicyNumber_ByID)).Text;
        //        var primary = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(PrimaryInsurance_ByID));                

        //        do
        //        {
        //            index = UtilityClass.GetRandomNumber(0, records.Count);   
        //        } while (insuranceProvider.Equals(records[index].InsuranceProvider)&&policyNo.Equals(records[index].Policy));

        //        var insurance = records[index];
        //        AutoAction.SetTextById(appWin,InsuranceProvider_ByID,insurance.InsuranceProvider.Trim());
        //        AutoAction.SetTextById(appWin,PolicyNumber_ByID,insurance.Policy.Trim());

        //        if (primary.IsSelected)
        //        {
        //            AutoAction.ClickRadioButtonById(appWin,OtherInsurance_ByID);
        //        }
        //        else
        //        {
        //            AutoAction.ClickRadioButtonById(appWin,PrimaryInsurance_ByID);
        //        }
        //        AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);
        //        AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

                
        //        AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
        //        Assert.AreEqual(insurance.InsuranceProvider.Trim(),insuranceProvider,"Insurance Provider is not edited");

        //        policyNo = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PolicyNumber_ByID)).Text;
        //        Assert.AreEqual(insurance.Policy.Trim(),policyNo,"Policy number is not edited");
        //    }
        //}
        
        
        // Created by Saveetha: Function to update/add Insurance Provider Name List box by selecting from drop down list
        public void SetProviderName(Window appWin, InsuranceModel insurance)
        {

            bool itemSelected = false;
            //var providerEditBox = AutoElement.GetElementById(appWin,InsuranceProvider_ByID,TreeScope.Descendants);
            
            //UIAutoHelper.performTextPattern(providerEditBox, insurance.InsuranceProvider.Trim().Split(' ')[0]);
            AutoAction.SetTextValuePatternById(appWin, InsuranceProvider_ByID, insurance.InsuranceProvider.Trim().Split(' ')[0]);

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

            //AutoAction.WaitTillVisibleById(appWin.AutomationElement, InsuranceProvider_ByID);
            Thread.Sleep(4*WaitTime);
            var providerList = AutoElement.GetElementById(appWin,InsuranceProviderList_ByID);
            //var providerList = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceProviderList_ByID));
            var listItems = AutoElement.GetElementCollectionByName(providerList,InsuranceProviderListItem_ByName);
            //var listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
               
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var providerName = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children).Current.Name;
                        //var providerName = (item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass))).Current.Name;
                        if (providerName==insurance.InsuranceProvider.Trim())
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            //var providerListName = AutoElement.GetElementByName(appWin, providerName);
                            UIAutoHelper.performSelectionItemPattern(item);
                            Thread.Sleep(2*WaitTime);
                            //AutoAction.ClickUIItemByName(appWin, providerName);
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
                    listItems=AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
                    //listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data");
            }
        }

        
        // CTC-34: Function to Edit all the Insurance details (ie, provider, member id, primary/other) with another record from Insurance_data_set.csv

        [TestMethod]
        public void EditInsurance()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insuranceHost = AutoElement.GetElementById(appWin, InsuranceHost_ByID);
            var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;

            if (insuranceCount == 0)
            {

                Assert.Fail("No insurance available to edit. Please Add an Insurance, then try to edit");
            }
            else
            {
                var records = CSVHelper.GetRecords<InsuranceModel>(InputFileName);
                int index;

                //var insuranceListName = AutoElement.GetElementByName(appWin, InsuranceListItem_ByName);
                //UIAutoHelper.performSelectionItemPattern(insuranceListName);
                AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
                var insuranceProvider = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(InsuranceProvider_ByID)).Text;
                var policyNo = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PolicyNumber_ByID)).Text;
                var primary = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(PrimaryInsurance_ByID));

                do
                {
                    index = UtilityClass.GetRandomNumber(0, records.Count);
                } while (insuranceProvider.Equals(records[index].InsuranceProvider));

                var insurance = records[index];
                SetProviderName(appWin, insurance);
                //AutoAction.SetTextById(appWin, InsuranceProvider_ByID, insurance.InsuranceProvider.Trim());

                var insuranceNo = UtilityClass.GetRandomNumber(1000000000, 2000000000).ToString();
                AutoAction.SetTextValuePatternById(appWin, PolicyNumber_ByID, insuranceNo);


                if (primary.IsSelected)
                {
                    AutoAction.ClickRadioButtonById(appWin, OtherInsurance_ByID);
                }
                else
                {
                    AutoAction.ClickRadioButtonById(appWin, PrimaryInsurance_ByID);
                }
                AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);
                AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

                //UIAutoHelper.performSelectionItemPattern(insuranceListName);
                AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
                insuranceProvider = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(InsuranceProvider_ByID)).Text;
                Assert.AreEqual(insurance.InsuranceProvider.Trim(), insuranceProvider, "Insurance Provider is not edited");

                policyNo = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PolicyNumber_ByID)).Text;
                Assert.AreEqual(insuranceNo, policyNo, "Policy number is not edited");


                AutoAction.ClickButtonById(appWin,SaveInsurance_ByID);
            }
        }

        //CTC-38 : Try to add dublicate Insurance and check whether application displays ""This insurance card already exists.Please add a different card or cancel the operation"
        [TestMethod]
        public void AddDublicateInsurance()
        {
            var records = CSVHelper.GetRecords<InsuranceModel>(InputFileName);
            var index = UtilityClass.GetRandomNumber(0, records.Count);
            var insurance = records[index];
            AddInsurance(insurance);
            AddInsurance(insurance);
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,OkPopUp_ByID);
            var orders = AutoElement.GetAllChilderen(host);
            if (orders[1].Current.Name.Equals("This insurance card already exists.Please add a different card or cancel the operation"))
                Assert.IsTrue(true);
            else
                Assert.Fail("Application does not shows insurance error when try to add dublicate insurance");
                      
        }


        [TestMethod]
        public void InsuranceError()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,BasicInfoModel.Next_ByID);
            //basic.ClickNextButton();
            var host = appWin.GetElement(SearchCriteria.ByText(Popup_ByName));
            if (host.Current.IsOffscreen)
            {
                Assert.Fail("Guest Error is not displayed");
            }
            AutoAction.ClickButtonById(appWin,Ok_ByID);
        }

        [TestMethod]
        public void InsuranceAdd()
        {
            AddABNInsurance("Medicare A and B");
        }

        //CTC-86: Add Add Medicare A and B plan in Add Insurance.
        //CTC-87: Add Add Medicare A and B plan in Add Insurance.
        public void AddABNInsurance(string insurance)
        {
            bool itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.ClickButtonById(appWin, AddCard_ByID);
            AutoAction.ClickButtonById(appWin, FrontCardScan_ByID);
            AutoAction.ClickButtonById(appWin, BackCardScan_ByID);          

            Assert.IsTrue(AutoElement.VisibleById(appWin, PrimaryInsurance_ByID), "Primary Insurance is not available");

            var providerEditBox = AutoElement.GetElementById(appWin, InsuranceProvider_ByID, TreeScope.Descendants);
            UIAutoHelper.performTextPattern(providerEditBox, insurance);

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);
            Thread.Sleep(2 * WaitTime);
            var providerList = AutoElement.GetElementById(appWin, InsuranceProviderList_ByID);
            var listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var providerName = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children).Current.Name;
                        if (providerName == MedicareAandB)
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            UIAutoHelper.performSelectionItemPattern(item);
                            Thread.Sleep(2 * WaitTime);
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
                    listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
                } while (itemsCount != listItems.Count);
            }

            else
            {
                Assert.Fail("No results were displayed for the data");
            }

            var insuranceNo = UtilityClass.GetRandomNumber(1000000000, 2000000000).ToString();
            AutoAction.SetTextById(appWin, PolicyNumber_ByID,insuranceNo);

            AutoAction.ClickRadioButtonById(appWin, PrimaryInsurance_ByID);
            AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);
        }

        [TestMethod]
        public void DeleteInsuranceFailure()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var insuranceHost = AutoElement.GetElementById(appWin, InsuranceHost_ByID);
            //var insuranceHost = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceHost_ByID));
            var insuranceCount = insuranceHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceListItem_ByName)).Count;

            if (insuranceCount == 0)
            {
                Assert.Fail("No insurance available to delete");
            }
           
            AutoAction.ClickUIItemByName(appWin, InsuranceListItem_ByName);
            AutoAction.ClickButtonById(appWin, DeleteInsurance_ByID);
            AutoAction.ClickButtonById(appWin,Ok_ByID);
        }

        //CTC-39: Set Other as Insurance Provider and check whether a Text box shown by the application
        [TestMethod]
        public void AddOtherAsInsuranceProvider()
        {
            bool itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, AddCard_ByID);

            //var providerEditBox = AutoElement.GetElementById(appWin, InsuranceProvider_ByID, TreeScope.Descendants);
            AutoAction.SetTextValuePatternById(appWin, InsuranceProvider_ByID, "Other - Unlisted");
            //UIAutoHelper.performValuePattern(providerEditBox, "Other - Unlisted");

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);
            var providerList = AutoElement.GetElementById(appWin, InsuranceProviderList_ByID);
            //var providerList = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceProviderList_ByID));
            var listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
            //var listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var providerName = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children).Current.Name;
                        //var providerName = (item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass))).Current.Name;
                        if (providerName.Equals("Other - Unlisted"))
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            //var providerListName = AutoElement.GetElementByName(appWin, providerName);
                            UIAutoHelper.performSelectionItemPattern(item);
                            Thread.Sleep(2 * WaitTime);
                            //AutoAction.ClickUIItemByName(appWin, providerName);
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
                    listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
                    //listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data");
            }

            Assert.IsTrue((AutoElement.ExistsById(appWin, OtherInsuranceProvider_ByID)), "Text box not shown by the application when Insurance Provider is Other");
            AutoAction.SetTextById(appWin, OtherInsuranceProvider_ByID, "xxxxx");
            var insuranceNo = UtilityClass.GetRandomNumber(1000000000, 2000000000).ToString();
            AutoAction.SetTextById(appWin, PolicyNumber_ByID, insuranceNo);
            AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);

        }

        //Edit subscriber info in the Insurance page and check whether the same get modified in the Basic info Firstname,Lastname field
        [TestMethod]
        public void EditSubscriberAndCheckBasicinfo()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            string FirstNameBfIns = AutoElement.GetTextBoxValueById(appWin, BasicInfoModel.GuestInfoFirst_ByAutoID);
            string LastNameBfIns = AutoElement.GetTextBoxValueById(appWin, BasicInfoModel.GuestInfoLast_ByAutoID);

            //Add insurance and change the subscriber name
            var records = CSVHelper.GetRecords<InsuranceModel>(InputFileName);
            var index = UtilityClass.GetRandomNumber(0, records.Count);
            var insurance = records[index];

            bool itemSelected = false;

            AutoAction.ClickButtonById(appWin, AddCard_ByID);
            //AutoAction.ClickButtonById(appWin, FrontCardScan_ByID);
            //AutoAction.ClickButtonById(appWin, BackCardScan_ByID);


            AutoAction.SetTextValuePatternById(appWin, FirstName_ByID, string.Concat("Modified", FirstNameBfIns));
            AutoAction.SetTextValuePatternById(appWin, LastName_ByID, string.Concat("Edited", LastNameBfIns));

            var primary = AutoElement.GetElementNameById(appWin, PrimaryInsurance_ByID);
            Assert.AreEqual(primary, PrimaryInsurance);
            var other = AutoElement.GetElementNameById(appWin, OtherInsurance_ByID);
            Assert.AreEqual(other, OtherInsurance);

            Assert.IsTrue(AutoElement.VisibleById(appWin, PrimaryInsurance_ByID), "Primary Insurance is not available");
            Assert.IsTrue(AutoElement.VisibleById(appWin, OtherInsurance_ByID), "Primary Insurance is not available");

            //var providerEditBox = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, InsuranceProvider_ByID));
            var providerEditBox = AutoElement.GetElementById(appWin, InsuranceProvider_ByID, TreeScope.Descendants);
            UIAutoHelper.performTextPattern(providerEditBox, insurance.InsuranceProvider.Trim().Split(' ')[0]);
            //  var spinner = appWin.GetElement(SearchCriteria.ByClassName(SmallSpinner_ByClass));

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);
            Thread.Sleep(2 * WaitTime);
            var providerList = AutoElement.GetElementById(appWin, InsuranceProviderList_ByID);
            //var providerList = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceProviderList_ByID));
            var listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
            //var listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));
            int itemsCount;
            if (listItems.Count != 0)
            {
                do
                {
                    itemsCount = listItems.Count;

                    foreach (AutomationElement item in listItems)
                    {
                        var providerName = AutoElement.GetElementByClassName(item, TextBlock_ByClass, TreeScope.Children).Current.Name;
                        //var providerName = (item.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass))).Current.Name;
                        if (providerName == insurance.InsuranceProvider.Trim())
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            //var providerListName = AutoElement.GetElementByName(appWin, providerName);
                            UIAutoHelper.performSelectionItemPattern(item);
                            Thread.Sleep(2 * WaitTime);
                            //AutoAction.ClickUIItemByName(appWin, providerName);
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
                    listItems = AutoElement.GetElementCollectionByName(providerList, InsuranceProviderListItem_ByName);
                    //listItems = providerList.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, InsuranceProviderListItem_ByName));

                } while (itemsCount != listItems.Count);
            }
            else
            {
                Assert.Fail("No results were displayed for the data");
            }

            var insuranceNo = UtilityClass.GetRandomNumber(1000000000, 2000000000).ToString();
            AutoAction.SetTextById(appWin, PolicyNumber_ByID, insuranceNo);


            AutoAction.ClickRadioButtonById(appWin, PrimaryInsurance_ByID);

            AutoAction.ClickButtonById(appWin, SaveInsurance_ByID);

            String FirstNameAfIns = AutoElement.GetTextBoxValueById(appWin, BasicInfoModel.GuestInfoFirst_ByAutoID);
            String LastNameAfIns = AutoElement.GetTextBoxValueById(appWin, BasicInfoModel.GuestInfoLast_ByAutoID);

            Assert.IsTrue(string.Equals(FirstNameBfIns, FirstNameAfIns), "FirstName in the Basic Info Modifed when subscriber name changed in the Insurance page");
            Assert.IsTrue(string.Equals(LastNameBfIns, LastNameAfIns), "LastName in the Basic Info Modifed when subscriber name changed in the Insurance page");

        }






        //yet to be update

        //[TestMethod]
        //public void DuplicateInsuranceCheck()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppSettings.AppWindowName));
        //    var insuranceHost = appWin.GetElement(SearchCriteria.ByAutomationId(InsuranceHost_ByID));
        //    var insuranceList = insuranceHost.FindAll(TreeScope.Descendants,new PropertyCondition(AutomationElement.ClassNameProperty,ListBox_ByClass));
        //    var insuranceItem = insuranceHost.FindAll(TreeScope.Descendants,new PropertyCondition(AutomationElement.NameProperty,InsuranceListItem_ByName));

        //    foreach (AutomationElement item in insuranceItem)
        //    {
        //        var listItem = item.FindAll(TreeScope.Descendants, Condition.TrueCondition);
        //    }

        //}


    }
}

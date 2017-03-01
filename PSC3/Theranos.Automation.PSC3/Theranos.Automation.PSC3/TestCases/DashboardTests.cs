using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using System.Collections.Generic;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.PSC3.Models.Perform;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests;
using System.IO;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;
using Theranos.Automation.ME.Android.Model;
using System.Globalization;
using Theranos.Automation.PSC3.TestCases.Perform;


namespace Theranos.Automation.PSC3.TestCases
{
    [TestClass]
    public class DashboardTests : DashboardModel
    {
        LoginTests login = new LoginTests();
        CheckInTests check = new CheckInTests();
        PaymentTests pay = new PaymentTests();
        public Window appWin;

        /// <summary>
        /// Verify existing guest details is displayed when searched with the Name and DOB of that guest.
        /// </summary>
        [TestMethod]
        public void SearchExistingByNameDOB()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, SearchBox_ByID);
            //var busyBox = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));

            string inputData = "";
            string fname = "";
            string lname = "";
            string dob = "";

            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);

            do
            {
                var itemInner = records[UtilityClass.GetRandomNumber(0, records.Count)];
                if (itemInner.Status == BasicInfoModel.ExistingGuest)
                {
                    AutoAction.SetTextById(appWin, LastName_ByID, itemInner.LastName);
                    AutoAction.SetTextById(appWin, FirstName_ByID, itemInner.FirstName);
                    AutoAction.SetTextById(appWin, DOB_ByID, itemInner.DOB.Substring(1));
                    AutoAction.SendTabKey();
                    fname = itemInner.FirstName;
                    lname = itemInner.LastName;
                    dob = itemInner.DOB.Substring(1);
                    inputData = "FirstName: " + itemInner.FirstName + ", LastName: " + itemInner.LastName + ", DOB: " + itemInner.DOB.Substring(1);
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);
                    break;
                }
            } while (inputData == "");
            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!busyBox.Current.IsOffscreen);

            var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            //var listView = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            //var listViewItems = listView.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBoxItem_ByClass));
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                //var details = itemInner.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                if (lname == details[0].Current.Name && fname == details[2].Current.Name)
                {
                    //DateTime d1 = Convert.ToDateTime(dob);
                    //DateTime d2 = Convert.ToDateTime(details[3].Current.Name);
                    //int results = DateTime.Compare(d1, d2);
                    //if (results == 0)
                    //{
                    //    resultFound = true;
                    //    break;
                    //}
                    resultFound = true;

                }

            }
            Assert.IsTrue(resultFound, "No results has been found for the data, " + inputData);

        }


        public void SearchExistingByNameDOBCheckIn(string firstName, string lastname, string DOB, string phoneNo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, SearchBox_ByID);

            AutoAction.SetTextById(appWin, LastName_ByID, lastname);
            AutoAction.SetTextById(appWin, FirstName_ByID, firstName);
            AutoAction.SetTextById(appWin, DOB_ByID, DOB);
            AutoAction.SendTabKey();

            string inputData = "FirstName: " + firstName + ", LastName: " + lastname + ", DOB: " + DOB;
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);

            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);


            var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                if (lastname == details[0].Current.Name && firstName == details[2].Current.Name && phoneNo == details[5].Current.Name)
                {
                    resultFound = true;
                    UIAutoHelper.performSelectionItemPattern(itemInner);

                }
            }
            Assert.IsTrue(resultFound, "No results has been found for the data, " + inputData);

        }

        public void SearchExistingByNameDOBPerform(string firstName, string lastname, string DOB, string phoneNo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.SetTextById(appWin, LastName_ByID, lastname);
            AutoAction.SetTextById(appWin, FirstName_ByID, firstName);
            AutoAction.SetTextById(appWin, DOB_ByID, DOB);
            AutoAction.SendTabKey();

            string inputData = "FirstName: " + firstName + ", LastName: " + lastname + ", DOB: " + DOB;
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);

            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);


            var resultFound = false;
            var listViewItems = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                if (lastname == details[0].Current.Name && firstName == details[1].Current.Name && phoneNo == details[5].Current.Name)
                {
                    resultFound = true;
                    UIAutoHelper.performSelectionItemPattern(itemInner);

                }
            }
            Assert.IsTrue(resultFound, "No results has been found for the data, " + inputData);

        }

     
        /// <summary>
        /// Verify existing guest details is displayed when searched with the Phone No of that guest.
        /// </summary>
        [TestMethod]
        public void SearchExistingByPhoneNo()
        {
            // login.LoginValid();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, SearchBox_ByID);
            //var busyBox = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string inputData = "";

            string phoneNo = "";

            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            do
            {
                var itemInner = records[UtilityClass.GetRandomNumber(0, records.Count)];
                if (itemInner.Status == BasicInfoModel.ExistingGuest)
                {
                    AutoAction.SetTextById(appWin, PhoneNo_ByID, itemInner.PhoneNo);
                    AutoAction.SendTabKey();
                    phoneNo = itemInner.PhoneNo;
                    inputData = "PhoneNo: " + itemInner.PhoneNo;
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);

                    break;
                }
            } while (inputData == "");
            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!busyBox.Current.IsOffscreen);

            var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            //var listView = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            //var listViewItems = listView.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBoxItem_ByClass));
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                //var details = itemInner.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                if (phoneNo == details[5].Current.Name)
                {
                    resultFound = true;
                    break;
                }
            }
            Assert.IsTrue(resultFound, "No results has been found for the data, " + inputData);
        }

        /// <summary>
        /// Verify no records is displayed when searched Last Name & DOB of new guest.
        /// </summary>
        [TestMethod]
        public void SearchNewByNameDOB()
        {
            //login.LoginValid();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, SearchBox_ByID);
            //var busyBox = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string inputData = "";
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            BasicInfoModel basicInfo = new BasicInfoModel();
            foreach (var itemInner in records)
            {
                if (itemInner.Status == BasicInfoModel.NewGuest)
                {
                    basicInfo = itemInner;
                    AutoAction.SetTextById(appWin, LastName_ByID, itemInner.LastName);
                    AutoAction.SetTextById(appWin, FirstName_ByID, itemInner.FirstName);
                    AutoAction.SetTextById(appWin, DOB_ByID, itemInner.DOB.Substring(1));
                    AutoAction.SendTabKey();
                    inputData = "FirstName: " + itemInner.FirstName + ", LastName: " + itemInner.LastName + ", DOB: " + itemInner.DOB.Substring(1);
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);
                    break;
                }
            }
            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!busyBox.Current.IsOffscreen);

            var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            //var listView = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            //var listViewItems = listView.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBoxItem_ByClass));
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                //var details = itemInner.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                if (basicInfo.LastName == details[0].Current.Name && basicInfo.FirstName == details[2].Current.Name)
                {
                    //DateTime d1 = Convert.ToDateTime(basicInfo.DOB.Substring(1));
                    //DateTime d2 = Convert.ToDateTime(details[3].Current.Name);
                    //int results = DateTime.Compare(d1, d2);
                    //if (results == 0)
                    //{
                    resultFound = true;
                    break;
                    //}

                }

            }
            Assert.IsFalse(resultFound, "Results has been found for the data, " + inputData);

        }

        /// <summary>
        /// Verify no records is displayed when searched Phone NO of new guest.
        /// </summary>
        [TestMethod]
        public void SearchNewByPhoneNo()
        {
            // login.LoginValid();
            BasicInfoModel basicInfo = new BasicInfoModel();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, SearchBox_ByID);
            //var busyBox = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string inputData = "";

            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            do
            {
                var itemInner = records[UtilityClass.GetRandomNumber(0, records.Count)];
                if (itemInner.Status == BasicInfoModel.NewGuest)
                {
                    basicInfo = itemInner;
                    AutoAction.SetTextById(appWin, PhoneNo_ByID, itemInner.PhoneNo);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);
                    inputData = "PhoneNo: " + itemInner.PhoneNo;

                    break;
                }
            } while (inputData == "");
            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!busyBox.Current.IsOffscreen);


            var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            //var listView = searchBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            //var listViewItems = listView.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, ListBoxItem_ByClass));
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                //var details = itemInner.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, TextBlock_ByClass));
                if (basicInfo.PhoneNo == details[5].Current.Name)
                {
                    resultFound = true;
                    break;
                }
            }
            Assert.IsFalse(resultFound, "Results has been found for the data, " + inputData);


        }

        /// <summary>
        /// Verify user is able to navigate to AddLabOrder page.
        /// </summary>
        [TestMethod]
        public void SearchAndAddByNameDOB()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string inputData = "";
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            foreach (var itemInner in records)
            {
                if (itemInner.Status == BasicInfoModel.NewGuest)
                {
                    AutoAction.SetTextById(appWin, LastName_ByID, itemInner.LastName);
                    AutoAction.SetTextById(appWin, FirstName_ByID, itemInner.FirstName);
                    AutoAction.SetTextById(appWin, DOB_ByID, itemInner.DOB.Substring(1));
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);
                    inputData = "FirstName: " + itemInner.FirstName + ", LastName: " + itemInner.LastName + ", DOB: " + itemInner.DOB.Substring(1);
                    AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
                    AutoAction.ClickButtonById(appWin, NewGuestName_ByID);
                    break;
                }
            }
            Assert.IsTrue(AutoElement.ExistsByClassName(appWin, AddLabOrderModel.ActiveLabOrders_ByClass));
        }

        /// <summary>
        /// Verify user is able to navigate to AddLabOrder page.
        /// </summary>
        [TestMethod]
        public void SearchAndAddByPhoneNo()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string inputData = "";
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            foreach (var itemInner in records)
            {
                if (itemInner.Status == BasicInfoModel.NewGuest)
                {
                    AutoAction.SetTextById(appWin, PhoneNo_ByID, itemInner.PhoneNo);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, SearchButton_ByID);
                    inputData = "PhoneNo: " + itemInner.PhoneNo;
                    AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
                    AutoAction.ClickButtonById(appWin, NewGuestName_ByID);
                    break;
                }
            }
            Assert.IsTrue(AutoElement.ExistsByClassName(appWin, AddLabOrderModel.ActiveLabOrders_ByClass));
            //var searchBoxLabOrders = appWin.GetElement(SearchCriteria.ByClassName(AddLabOrderModel.ActiveLabOrders_ByClass));
            //Assert.IsNotNull(searchBoxLabOrders, "Unable to navigate to AddLabOrders page, " + inputData);
        }

        /// <summary>
        /// CTC-10: Verify guest search button is not enabled until Last Name & DOB or Phone No is entered.
        /// </summary>
        [TestMethod]
        public void SearchButtonMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            int index = UtilityClass.GetRandomNumber(0, records.Count);

            var searchBox = records[index];
            //when both Lastname and D.O.B is not entered.
            Assert.IsFalse(AutoElement.EnabledById(appWin, SearchButton_ByID));

            //when last name alone entered
            AutoAction.SetTextById(appWin, LastName_ByID, searchBox.LastName);
            AutoAction.SendTabKey();
            Assert.IsFalse(AutoElement.EnabledById(appWin, SearchButton_ByID));

            //when Phone number alone entered 
            AutoAction.SetTextById(appWin, LastName_ByID, " ");
            AutoAction.SetTextById(appWin, PhoneNo_ByID, searchBox.PhoneNo);
            AutoAction.SendTabKey();
            Assert.IsTrue(AutoElement.EnabledById(appWin, SearchButton_ByID));

            //when both last name and DOB is entered
            AutoAction.SetTextById(appWin, LastName_ByID, searchBox.LastName);
            AutoAction.SetTextById(appWin, DOB_ByID, searchBox.DOB);
            Assert.IsTrue(AutoElement.EnabledById(appWin, SearchButton_ByID));
        }

        public void SearchGuestByNameDOB(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, LastName_ByID, basicInfo.LastName);
            AutoAction.SetTextById(appWin, FirstName_ByID, basicInfo.FirstName);
            AutoAction.SetTextById(appWin, DOB_ByID, basicInfo.DOB.Substring(1));
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]
        public void GuestSearchMandatoryFieldValidation()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutomationElement rootElement = AutomationElement.RootElement;
            var windows = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var host = AutoElement.GetElementByClassName(appWin, GuestSearchHost_ByClass);
            //var hostItems = AutoElement.GetAllChilderen(host);
            //var items = hostItems[2];
            //var nameItems = AutoElement.GetAllChilderen(items);
            //var item = nameItems[0].Current.Name;
            //var lname = AutoElement.GetUIItemById(appWin,LastNameMandatory_ByID);
            var lname = AutoElement.GetElementById(windows, LastNameMandatory_ByID);
            var item = lname.Current.Name;
            //var items = AutoElement.GetAllChilderen(lname);
            //var item = items[0].Current.Name;
            //var items = AutoElement.GetAllChilderen(lname);
            //var item = items[0].Current.Name;
            //var item = AutoElement.GetElementNameBId(appWin, LastNameMandatory_ByID);
            //var name = item.ToString();
            //var mandatorySymbol = item.Substring(10);
            //Assert.AreEqual("*", mandatorySymbol);
        }

        public void SearchGuestByPhoneNo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, PhoneNo_ByID, basicInfo.PhoneNo);
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]
        public void GuestSearchPhoneNumberFieldMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var phone = AutoElement.GetElementById(appWin, PhoneNumberHost_ByID);
            //var items = phone.Count;
            var items = AutoElement.GetAllChilderen(phone);
            //    var item = items[0].Current.Name;
        }

        public bool IsGuestDisplayedInSearchResultsPerform(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            if (searchResults == null)
            {
                return false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == basicInfo.LastName && details[1].Current.Name == basicInfo.FirstName && details[5].Current.Name == basicInfo.PhoneNo)
                {
                    //DateTime d1 = Convert.ToDateTime(basicInfo.DOB.Substring(1));
                    //DateTime d2 = Convert.ToDateTime(details[3].Current.Name);
                    //int results = DateTime.Compare(d1, d2);
                    //if (results == 0)
                    //  {
                    UIAutoHelper.performSelectionItemPattern(result);
                    return true;
                    // }
                }
            }

            return false;

        }

        public void SearchCheckedInGuestNameDOB(BasicInfoModel basicInfo)
        {
            SearchGuestByNameDOB(basicInfo);
            Assert.IsTrue(IsGuestDisplayedInSearchResultsPerform(basicInfo));
        }

        public void SearchCheckedInGuestPhoneNo(BasicInfoModel basicInfo)
        {
            SearchGuestByPhoneNo(basicInfo);
            Assert.IsTrue(IsGuestDisplayedInSearchResultsPerform(basicInfo));
        }

        [TestCategory(AppSettings.Unit), TestMethod]
        public void SearchNewByNameDOBPerform()
        {
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            do
            {
                var basicInfo = records[UtilityClass.GetRandomNumber(0, records.Count)];
                if (basicInfo.Status == BasicInfoModel.NewGuest)
                {
                    SearchGuestByNameDOB(basicInfo);
                    Assert.IsFalse(IsGuestDisplayedInSearchResultsPerform(basicInfo));
                    break;
                }
            } while (true);
        }

        [TestCategory(AppSettings.Unit), TestMethod]
        public void SearchNewByPhonePerform()
        {
            var records = CSVHelper.GetRecords<BasicInfoModel>(BasicInfoModel.InputFileName);
            do
            {
                var basicInfo = records[UtilityClass.GetRandomNumber(0, records.Count)];
                if (basicInfo.Status == BasicInfoModel.NewGuest)
                {
                    SearchGuestByPhoneNo(basicInfo);
                    Assert.IsFalse(IsGuestDisplayedInSearchResultsPerform(basicInfo));
                    break;
                }
            } while (true);
        }


        [TestCategory(AppSettings.Unit), TestMethod]
        public void ChangeCurrentLoactionTerminalCheckIn()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);

            foreach (AutomationElement item in providerLocationLists)
            {
                var childs = AutoElement.GetAllChilderen(item);
                string locname = childs[0].Current.Name;
                if (locname.Contains(GSRLocation2))
                {
                    UIAutoHelper.performSelectionItemPattern(item);
                    break;
                }

            }


            if (!AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);

                if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

        }

        [TestCategory(AppSettings.Unit), TestMethod]
        public void ChangeCurrentLoactionTerminalPerform()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);

            foreach (AutomationElement item in providerLocationLists)
            {
                var childs = AutoElement.GetAllChilderen(item);
                if (childs[0].Current.Name == GSRLocation2)
                {
                    UIAutoHelper.performSelectionItemPattern(item);
                    break;
                }

            }

            if (!AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, Perform_ByID);

                if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            //CloseTempraturePopup();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

        }

        [TestMethod]
        public void ChangeCurrentLocationTerminalCheckInForIntegration()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            //AutoAction.ClickUIItemById(appWin, "ConfigureLocationScreen.SelectProvider.ComboBox.Combo");
            var item = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("ConfigureLocationScreen.SelectProvider.ComboBox.Combo"));
            item.Select(1);
            //AutoAction.ClickUIItemByName(appWin,"Walgreens");
            AutoAction.ClickUIItemByName(appWin, "WAG6177");
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);

            if (!AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);

                if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]
        public void ChangeCurrentLocationTerminalPerformForIntegration()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            var item = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId("ConfigureLocationScreen.SelectProvider.ComboBox.Combo"));
            item.Select(1);
            AutoAction.ClickUIItemByName(appWin, "WAG6177");
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);
            
            if (!AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, Perform_ByID);

                if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            //CloseTempraturePopup();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]
        public void CheckAndChangeCheckInTerminalForIntegration()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.ExistsByClassNameNoWait(appWin, TempraturePopupHost_ByClass))
            {
                CloseTempraturePopup();
                ChangeCurrentLocationTerminalCheckInForIntegration();
            }
            else if (AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID))
            {
                ChangeCurrentLocationTerminalCheckInForIntegration();
            }
            else
            {
                Assert.IsTrue(AutoElement.ExistsByClassName(appWin, PerformRoomWaitingHost_ByClass));
            }
        }

        [TestMethod]
        public void CheckAndChangePerformTerminalForIntegration()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.ExistsByClassNameNoWait(appWin, PerformRoomWaitingHost_ByClass))
            {
                ChangeCurrentLocationTerminalPerformForIntegration();
                CloseTempraturePopup();
            }

            else
            {
                if (AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID))
                {
                    Assert.IsTrue(AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID));
                }

                else
                {
                    Assert.IsTrue(AutoElement.ExistsByClassNameNoWait(appWin, TempraturePopupHost_ByClass));
                }
            }
        }



        [TestMethod]
        public void CheckAndChangeToCheckInTerminal()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.ExistsByClassNameNoWait(appWin, TempraturePopupHost_ByClass))
            {
                CloseTempraturePopup();
                ChangeCurrentLoactionTerminalCheckIn();
            }
            else if (AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID))
            {
                ChangeCurrentLoactionTerminalCheckIn();
            }
            else
            {
                Assert.IsTrue(AutoElement.ExistsByClassName(appWin, PerformRoomWaitingHost_ByClass));
            }
        }

        [TestMethod]
        public void CheckAndChangeToPerformTerminal()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.ExistsByClassNameNoWait(appWin, PerformRoomWaitingHost_ByClass))
            {
                ChangeCurrentLoactionTerminalPerform();
                CloseTempraturePopup();
            }

            else
            {
                if (AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID))
                {
                    Assert.IsTrue(AutoElement.ExistsById(appWin, ScanReturnContainerHost_ByID));
                }

                else
                {
                    Assert.IsTrue(AutoElement.ExistsByClassNameNoWait(appWin, TempraturePopupHost_ByClass));
                }
            }
        }

        
        [TestMethod]
        public void CheckBothCheckInAdPerformTerminal()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);

            foreach (AutomationElement item in providerLocationLists)
            {
                var childs = AutoElement.GetAllChilderen(item);
                if (childs[0].Current.Name == GSRLocation2)
                {
                    UIAutoHelper.performSelectionItemPattern(item);
                    break;
                }
            }

            if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID) && AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }

            Assert.IsTrue(AutoElement.VisibleByClassName(appWin, AppointmentsHost_ByClass));
            Assert.IsTrue(AutoElement.VisibleById(appWin, ScanReturnContainerHost_ByID));
        }

        //set the location as GSR LOcation 3
        public void CheckBothCheckInAdPerformTerminal(string GSRLoc3)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);
            string locname = "";
            foreach (AutomationElement item in providerLocationLists)
            {
                var childs = AutoElement.GetAllChilderen(item);
                locname = childs[0].Current.Name;
                if (locname.Contains(GSRLoc3))
                {
                    UIAutoHelper.performSelectionItemPattern(item);
                    break;
                }
            }

            if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID) && AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else if (AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                AutoAction.ClickCheckBoxById(appWin, Perform_ByID);
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }

            Assert.IsTrue(AutoElement.VisibleByClassName(appWin, AppointmentsHost_ByClass));
            Assert.IsTrue(AutoElement.VisibleById(appWin, ScanReturnContainerHost_ByID));
        }


        [TestMethod]
        public void CloseTempraturePopup()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var id = UtilityClass.GetRandomNumber(1, 100).ToString();
            if (AutoElement.ExistsByIdNoWait(appWin, TempPopupCancel_ById))
            {
                if (AutoElement.EnabledById(appWin, TempPopupCancel_ById))
                {
                    AutoAction.ClickButtonById(appWin, TempPopupCancel_ById);
                }
                else
                {
                    AutoAction.SetTextById(appWin, RoomId_ByID, id);
                    AutoAction.SetTextById(appWin, RoomTemp_ByID, id);
                    AutoAction.SetTextById(appWin, RefrigeratorID_ByID, id);
                    AutoAction.SetTextById(appWin, RefrigeratorTemp_ByID, id);
                    AutoAction.SetTextById(appWin, Refrigerator1ID_ByID, id);
                    AutoAction.SetTextById(appWin, Refrigerator1Temp_ByID, id);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, TempPopupOk_ByID);
                }

            }
            else
            {
                Assert.IsTrue(true, "Perform terminal is visible");
            }



        }

        //[TestMethod]
        //public void InvalidBarcode()
        //{
        //    ScanReturncontainerInvalidBarcode("1111122222");
        //}

        public void ScanReturncontainerInvalidBarcode(string invalidBarCode)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ScanReturnContainer_ByID);
            AutoAction.SetTextById(appWin, ScanReturnContainerBarcode_ByID, invalidBarCode);
            Assert.IsTrue(AutoElement.VisibleById(appWin, InvalidBarcodeMessage_ByID));
            AutoAction.ClickButtonById(appWin, OkButton_ByID);
            AutoAction.ClickButtonById(appWin, ReturnContainerCloseButton_ByID);
        }

        [TestMethod]
        public void ScanReturncontainerInvalidBarcode()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ScanReturnContainer_ByID);
            string invalidReturnContainerBarcode = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();

            AutoAction.SetTextById(appWin, ScanReturnContainerBarcode_ByID, invalidReturnContainerBarcode);
            //Thread.Sleep(3 * WaitTime);
            Assert.IsTrue(AutoElement.VisibleById(appWin, InvalidBarcodeMessage_ByID));
            AutoAction.ClickButtonById(appWin, OkButton_ByID);
            AutoAction.ClickButtonById(appWin, ReturnContainerCloseButton_ByID);
        }

        //[TestMethod]
        //public void ReturnContainer()
        //{
        //    ScanReturnContainer("7575757575");
        //}


        public void ScanReturnContainer(string barCode)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ScanReturnContainer_ByID);
            AutoAction.SetTextById(appWin, ScanReturnContainerBarcode_ByID, barCode);
            Assert.IsTrue(AutoElement.VisibleById(appWin, ReturnContainerHost_ByID));
            //Thread.Sleep(3 * WaitTime);
            if (AutoElement.VisibleById(appWin, ReturnContainerUnknownCheckbox_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, ReturnContainerUnknownCheckbox_ByID);
                AutoAction.SendTabKey();
                //Thread.Sleep(3 * WaitTime);
                AutoAction.ClickButtonById(appWin, ReturnContainerSubmit_ByID);
                Thread.Sleep(3 * WaitTime);
                Assert.IsFalse(AutoElement.ExistsById(appWin, ReturnContainerHost_ByID));
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ReturnContainerSubmit_ByID);
                Thread.Sleep(3 * WaitTime);
                Assert.IsFalse(AutoElement.ExistsById(appWin, ReturnContainerHost_ByID));
            }
            //AutoAction.ClickCheckBoxById(appWin,ReturnContainerUnknownCheckbox_ByID);
            //AutoAction.SendTabKey();
            ////Thread.Sleep(3 * WaitTime);
            //AutoAction.ClickButtonById(appWin,ReturnContainerSubmit_ByID);
            //Thread.Sleep(3 * WaitTime);
            //Assert.IsFalse(AutoElement.ExistsById(appWin, ReturnContainerHost_ByID));
        }



        [TestMethod]
        public void ClickReturnContainer()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, PerformModel.ReturnContainer_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, ReturnContainerView_ByID));
        }

        [TestMethod]
        public void Return()
        {
            ReturnContainer("2502502502");
        }

        public void ReturnContainer(string barCode)
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, PerformModel.Barcode_ByID, barCode);
            Assert.IsTrue(AutoElement.VisibleById(appWin, DashboardModel.ReturnContainerHost_ByID), "BarCode is Invalid");
            AutoAction.ClickUIItemById(appWin, DashboardModel.ReturnContainerUnknownCheckbox_ByID);
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, DashboardModel.ReturnContainerSubmit_ByID);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PerformModel.ReturnContainerLists_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {

                var status = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(PerformModel.ContainerReturnedX_ByID, i));
                Assert.AreEqual(status, PerformModel.ContainerReturned);
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(PerformModel.ScannedBarcodeX_ByID, i)));
            }
        }


        [TestCategory(AppSettings.Unit), TestMethod]
        public void CancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionRequired = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var guestOrders = actionRequired.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));
            var currentName = guestOrders.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            string name = currentName[1].Current.Name;
            AutoAction.ClickButtonById(appWin, CancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            actionRequired = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            guestOrders = actionRequired.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));
            currentName = guestOrders.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            if (name == currentName[1].Current.Name)
            {
                Assert.Fail("Guest is not deleted");
            }


        }

        [TestCategory(AppSettings.Unit), TestMethod]
        public void CancelVisitPerform()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionRequired = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var guestOrders = actionRequired.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, PerformGuestName_Name));
            var currentName = guestOrders.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            string name = currentName[1].Current.Name;
            AutoAction.ClickButtonById(appWin, CancelVisit_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            actionRequired = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            guestOrders = actionRequired.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, PerformGuestName_Name));
            currentName = guestOrders.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            if (name == currentName[1].Current.Name)
            {
                Assert.Fail("Guest is not deleted");
            }


        }


        public void GuestSearchForSignatureRequirement(BasicInfoModel basicInfo)
        {
            var itemSelected = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var name = AutoElement.GetElementNameById(appWin, GuestName_ByID);
            check.NavigateToDashboard();
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            //var actionRequired = appWin.GetElement(SearchCriteria.ByAutomationId(ActionsRequired_ByID));
            //var listView = actionRequired.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, ListBox_ByClass));
            //var guestOrders = actionRequired.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));

            int listItemCount;
            if (actionItems.Count != 0)
            {
                do
                {
                    listItemCount = actionItems.Count;

                    foreach (AutomationElement item in actionItems)
                    {

                        //var listItemTask = item.FindAll(TreeScope.Descendants,new PropertyCondition(AutomationElement.NameProperty,GuestOrders_ByName));
                        var listItemTask = item.FindAll(TreeScope.Descendants, Condition.TrueCondition);

                        if (name == listItemTask[1].Current.Name)
                        {
                            UIAutoHelper.ScrollIntoView(item);
                            UIAutoHelper.performSelectionItemPattern(item);
                            itemSelected = true;
                            break;
                        }
                    }
                    if (itemSelected)
                    {
                        break;
                    }
                    UIAutoHelper.ScrollIntoView(actionItems[listItemCount - 1]);
                    Thread.Sleep(5000);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);

                } while (listItemCount != actionItems.Count);

            }
            Assert.IsTrue(AutoElement.ExistsById(appWin, GuestFormsModel.GuestFormsHost_ByID));
        }

        [TestMethod]
        public void Print()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutomationElement rootElement = AutomationElement.RootElement;
            var uiWindow = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, AppWindowName));

            AutomationElement printButton = null;
            do
            {
                Thread.Sleep(WaitTime);
                AndCondition printButtonCondition = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, Print_ByName),
                    new PropertyCondition(AutomationElement.ClassNameProperty, Button_ByClass));

                printButton = uiWindow.FindFirst(TreeScope.Descendants, printButtonCondition);

            } while (printButton == null);
            //var xps = AutoElement.GetElementByName(appWin,XPSDocument_ByName);
            //UIAutoHelper.performInvokePattern(xps);
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
            //var fileSave = AutoElement.GetElementByName(appWin,FileSave_ByName);
            //UIAutoHelper.performInvokePattern(fileSave);
            AutoAction.ClickUIItemByName(appWin, FileSave_ByName);
            Thread.Sleep(2 * WaitTime);
        }


        //CTC-20:Try to click on any option from Print forms screen and print
        [TestMethod]
        public void PrintForms()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, PrintForms_ByID);

            var host = AutoElement.GetElementByClassName(appWin, PrintFormsPopUp_ByClass);
            var items = AutoElement.GetAllChilderen(host);

            //var acknowledge = AutoElement.GetElementByName(appWin, AcknowledgementofPrivacyPractices_ByName);
            //UIAutoHelper.performInvokePattern(acknowledge);
            AutoAction.ClickButtonByName(appWin, AcknowledgementofPrivacyPractices_ByName);
            Print();

            AutoAction.ClickButtonByName(appWin, NoticeOfPrivacyPractices_ByName);
            Print();

            AutoAction.ClickButtonByName(appWin, DirectTesting_ByName);
            Print();

            AutoAction.ClickButtonByName(appWin, ManualProcessing_ByName);
            Print();

            UIAutoHelper.performInvokePattern(items[1]);
        }

        //[TestMethod]
        //public void ClearVisitsCheckin()
        //{
        //    LoginTests login = new LoginTests();
        //    PaymentTests payment = new PaymentTests();
        //    CheckInTests checkin = new CheckInTests();
        //    string lastProcessedGuestName = "";
        //    string lastGuestName = "";
        //    string currentName = "";
        //    login.LaunchApplication();
        //    login.LoginValid();
        //    List<string> guests = new List<string>();
        //    var appWin = AutoElement.GetWindowByName(AppWindowName);
        //    var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
        //    var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);

        //    do
        //    {
        //        foreach (AutomationElement actionItem in actionItems)
        //        {
        //            UIAutoHelper.ScrollIntoView(actionItem);
        //            var items = AutoElement.GetAllChilderen(actionItem);
        //            currentName = items[1].Current.Name;
        //            if (!guests.Contains(currentName))
        //            {
        //                guests.Add(currentName);
        //                UIAutoHelper.performInvokePattern(items[7]);
        //                var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
        //                reason.Select(UtilityClass.GetRandomNumber(0, 6));
        //                AutoAction.ClickButtonById(appWin, Yes_ByID);
        //                Thread.Sleep(3000);
        //                if (AutoElement.ExistsByIdNoWait(appWin, Yes_ByID))
        //                {
        //                    MouseHelper.MoveToAndClickById(appWin, Yes_ByID);

        //                }
        //                Thread.Sleep(10000);
        //            }
        //        }
        //        actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
        //    } while (true);


        //}

        [TestMethod]
        public void ClearVisitsCheckin()
        {
            LoginTests login = new LoginTests();
            PaymentTests payment = new PaymentTests();
            CheckInTests checkin = new CheckInTests();
            string lastProcessedGuestName = "";
            string lastGuestName = "";

            login.LaunchApplication();
            login.LoginValid();
            List<string> guests = new List<string>();

            string path = @"C:\Users\selangovan\CheckIn.txt";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                guests.Add(s);
            }

            do
            {
                var appWin = AutoElement.GetWindowByName(AppWindowName);
                var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
                var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                int count = 0;
                do
                {
                    bool deleted = false;
                    foreach (AutomationElement actionItem in actionItems)
                    {

                        count++;

                        UIAutoHelper.ScrollIntoView(actionItem);
                        Thread.Sleep(1000);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        var actionRequired = items[4].Current.Name;
                        lastProcessedGuestName = items[1].Current.Name;
                        if (actionRequired == OrdersRejected_ByName || actionRequired == OrdersReady_ByName || actionRequired == GuestSignature_ByName || actionRequired == CompleteCheckIn_ByName || actionRequired == TranscriptionInProgress_ByName)
                        {
                            if (!guests.Contains(lastProcessedGuestName))
                            {

                                guests.Add(lastProcessedGuestName);
                                File.WriteAllLines(path, guests);
                                //UIAutoHelper.performSelectionItemPattern(actionItem);
                                UIAutoHelper.performInvokePattern(items[7]);

                                //   checkin.CancelVisit();
                                var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
                                reason.Select(UtilityClass.GetRandomNumber(0, 6));
                                AutoAction.ClickButtonById(appWin, Yes_ByID);
                                Thread.Sleep(3000);
                                deleted = true;
                                break;
                            }


                        }
                        else
                        {
                            if (!guests.Contains(lastProcessedGuestName))
                            {
                                guests.Add(lastProcessedGuestName);
                                File.WriteAllLines(path, guests);
                                UIAutoHelper.performSelectionItemPattern(actionItem);
                                Thread.Sleep(5000);
                                if (AutoElement.ExistsByIdNoWait(appWin, PaymentModel.ConfirmRefund_ByID))
                                {
                                    AutoAction.ClickButtonById(appWin, PaymentModel.ConfirmRefund_ByID);
                                    AutoAction.ClickButtonById(appWin, PaymentModel.Finish_ByID);
                                    AutoAction.ClickButtonById(appWin, PaymentModel.OK_ByID);
                                    AutoAction.ClickButtonById(appWin, Yes_ByID);
                                    Thread.Sleep(3000);
                                }
                                else if (AutoElement.VisibleByIdNoWait(appWin, CheckInModel.CancelVisit_ByID))
                                {
                                    AutoAction.ClickButtonById(appWin, CheckInModel.CancelVisit_ByID);
                                    var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
                                    reason.Select(UtilityClass.GetRandomNumber(0, 6));
                                    AutoAction.ClickButtonById(appWin, Yes_ByID);
                                    Thread.Sleep(3000);
                                }
                                deleted = true;
                                break;
                            }
                        }
                    }
                    if (deleted)
                    {
                        break;
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);


                } while (true);

                var tempItems = AutoElement.GetAllChilderen(actionItems[actionItems.Count - 1]);
                lastGuestName = tempItems[1].Current.Name;
                login.LaunchApplication();
                login.LoginValid();
            } while (true);

        }

        [TestMethod]
        public void ClearVisitPerform()
        {
            LoginTests login = new LoginTests();
            PaymentTests payment = new PaymentTests();
            CheckInTests checkin = new CheckInTests();
            string lastProcessedGuestName = "";
            //login.LaunchApplication();
            //login.LoginValid();
            List<string> guests = new List<string>();

            string path = @"C:\Users\selangovan\Perform.txt";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                guests.Add(s);
            }
            bool run;
            do
            {
                run = true;
                var appWin = AutoElement.GetWindowByName(AppWindowName);
                var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
                var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                do
                {
                    Thread.Sleep(3000);
                    bool deleted = false;
                    foreach (AutomationElement actionItem in actionItems)
                    {

                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        lastProcessedGuestName = items[1].Current.Name;

                        if (!guests.Contains(lastProcessedGuestName))
                        {
                            guests.Add(lastProcessedGuestName);
                            File.WriteAllLines(path, guests);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            Thread.Sleep(3000);
                            AutoAction.ClickButtonById(appWin, CheckInTests.CancelVisit_ByID);
                            Thread.Sleep(1000);
                            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
                            Thread.Sleep(1000);
                            reason.Select(UtilityClass.GetRandomNumber(0, 6));
                            Thread.Sleep(1000);
                            AutoAction.ClickButtonById(appWin, Yes_ByID);
                            Thread.Sleep(1000);
                            AutoAction.ClickButtonById(appWin, Yes_ByID);
                            Thread.Sleep(1000);
                            AutoAction.WaitTillVisibleById(appWin.AutomationElement, ActionsRequired_ByID);
                            deleted = true;
                            break;
                        }
                    }
                    if (deleted)
                    {
                        break;
                    }

                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (true);
                //login.LaunchApplication();
                //login.LoginValid();
                if (actionItems == null)
                {
                    run = false;
                }

            } while (run);



        }


        [TestMethod]
        public void GuestStatus()
        {
            BasicInfoModel basic = new BasicInfoModel();
            basic.FirstName = "Automation";
            basic.LastName = "AAEGS";
            //CheckReadyForCollection(basic);
            //CheckInProgress(basic);
            //CancelVisitPerformTerminal(basic);
            //CancelVisitCheckinInitiatedByPerform(basic);
            //SearchGuestInPerformRoomWaiting(basic);
            //CheckGuestInPerformRoomWaiting(basic);
            //CancelVisitCheckInOrdersReady(basic);
            //SelectGuestInVisitReport(basic);
            //IsGuestDisplayedInDashboard(basic);
            //CheckGuestCompleteAdjustmentAndNavigateToGuestInfo(basic);
            //CheckGuestInPerformRoomWaiting(basic);
            //CheckGuestForPleaseCompleteCheckIn(basic);
            //CheckGuestForProcessRefund(basic);
            CheckGuestInPerformRoom(basic);
        }

        //check a particular guest/patient task is 'Ready for Collection'
        public void CheckReadyForCollection(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            string task = "";
            int count;
            bool guest = false;
            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;

                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (performGuestName == name)
                        {
                            Assert.IsTrue(task == ReadyForCollection, "Guest is in In Progress state");
                            guest = true;
                            break;
                        }
                    }
                    if (guest)
                    {
                        break;
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);



            }
            if (guest == false)
            {
                Assert.Fail("Guest is not found");
            }

        }

        public void CheckInProgress(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            string task = "";
            int count;
            bool guest = false;
            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;

                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (performGuestName == name)
                        {
                            Assert.IsTrue(task == InProgress, "Guest is in ReadyforCollection state");
                            guest = true;
                            break;
                        }
                    }
                    if (guest)
                    {
                        break;
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);

            }
            if (guest == false)
            {
                Assert.Fail("Guest is not found");
            }
        }

        public void CheckGTTSessionExpired(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            string task = "";
            int count;
            bool guest = false;
            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;

                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (performGuestName == name)
                        {
                            Assert.IsTrue(task == GTTSeesionExpired, "GTT session not expired");
                            guest = true;
                            break;
                        }
                    }
                    if (guest)
                    {
                        break;
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);

            }
            if (guest == false)
            {
                Assert.Fail("Guest is not found");
            }
        }

        [TestMethod]
        public void VerifyCancelButtonCheckIn()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        if (items[4].Current.Name == PleaseCompleteAdjustment)
                        {
                            if (!items[7].Current.IsOffscreen)
                            {
                                Assert.Fail("Cancel button visible");
                            }
                        }
                        else
                        {
                            if (!items[7].Current.IsEnabled || items[7].Current.AutomationId != CancelVisit_ByID || items[7].Current.IsOffscreen)
                            {
                                Assert.Fail("Cancel button is not found/enabled/visible");
                            }
                        }

                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);
            }

            else
            {
                Assert.Fail("No guest are available in dashboard");
            }
        }

        /// <summary>
        /// Need to change based on the action displayed for action items
        /// </summary>
        [TestMethod]
        public void VerifyCancelButtonNotDisplayedCheckIn()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        if (items[4].Current.Name == PleaseCompleteAdjustment)
                        {
                            if (!items[7].Current.IsOffscreen)
                            {
                                Assert.Fail("Cancel button visible");
                            }
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);
            }

            else
            {
                Assert.Fail("No guest are available in dashboard");
            }


        }

        [TestMethod]
        public void VerifyCancelButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        if (!items[9].Current.IsEnabled || items[9].Current.AutomationId != CancelVisit_ByID || items[9].Current.IsOffscreen)
                        {
                            Assert.Fail("Cancel button is not found/enabled/visible");
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }

            else
            {
                Assert.Fail("No guest are available in dashboard");
            }
        }

        //Cancel visit when the patient is in Ready for collection state -- in Perform Host and check the patient is in Checkin HOST
        public void CancelVisitPerformTerminal(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            bool deleted = false;
            int count;
            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;
                        if (performGuestName == name)
                        {
                            UIAutoHelper.performInvokePattern(items[9]);

                            //var cancelVisitHost = AutoElement.GetElementById(appWin,CancelVisitHost_ByID);
                            //var cancelItems = AutoElement.GetAllChilderen(cancelVisitHost);
                            //UIAutoHelper.performInvokePattern(cancelItems[1]);


                            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
                            reason.Select(UtilityClass.GetRandomNumber(0, 20));
                            AutoAction.ClickButtonById(appWin, Yes_ByID);

                            var cancelVisitHost = AutoElement.GetElementByClassName(appWin, RefundInitiatePopup_ByClass);
                            var item = AutoElement.GetAllChilderen(cancelVisitHost);
                            var refundItems = item[3].Current.Name;
                            var message1 = item[4].Current.Name;
                            var message2 = item[5].Current.Name;
                            Assert.AreEqual(refundItems, RefundInitiated, "Refund is not initiated");
                            Assert.AreEqual(message1, PartialRefund, "message 1 is not displayed");
                            Assert.AreEqual(message2, ProcessRefund, "message2 is not displayed");

                            AutoAction.ClickButtonById(appWin, Yes_ByID);

                            Assert.IsTrue(AutoElement.VisibleById(appWin, ActionsRequired_ByID));
                            deleted = true;
                            break;
                        }
                    }
                    if (deleted)
                    {
                        break;
                    }

                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
            bool checkinGuestFound = false;
            if (deleted == true)
            {

                ChangeCurrentLoactionTerminalCheckIn();
                //var appWin = AutoElement.GetWindowByName(AppWindowName);
                actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
                var checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                string checkinGuestName = "";
                int countItems;
                do
                {
                    countItems = checkinGuest.Count;
                    foreach (AutomationElement guestItem in checkinGuest)
                    {
                        UIAutoHelper.ScrollIntoView(guestItem);
                        var items = AutoElement.GetAllChilderen(guestItem);
                        checkinGuestName = items[1].Current.Name;
                        if (checkinGuestName == name)
                        {
                            checkinGuestFound = true;
                            break;
                        }
                    }
                    checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (countItems != checkinGuest.Count);
            }
            if (checkinGuestFound == false)
            {
                Assert.Fail("Guest is not found in checkin terminal");
            }

        }

        //After a cancel visit of the patient in perform mode, check for the same patien in checkin... process refund.... after refund, confirm the patient is not in checkin host
        public void CancelVisitCheckinInitiatedByPerform(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            string checkinGuestName = "";
            string task = "";

            int count;
            bool deleted = false;
            if (actionItems.Count != 0)
            {

                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        checkinGuestName = items[1].Current.Name;
                        task = items[4].Current.Name;

                        if (checkinGuestName == name && task == ProcessRefund_ByName)
                        {
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            var refundHost = AutoElement.GetElementById(appWin, PaymentModel.PaymentHost_ByID);
                            var confirmrefund = AutoElement.GetAllChilderen(refundHost);
                            var refund = confirmrefund[9].Current.Name;
                            AutoAction.ClickUIItemByName(appWin, refund);
                            //AutoAction.ClickCheckBoxById(appWin, PaymentModel.ConfirmRefund_ByID);
                            AutoAction.SendTabKey();
                            AutoAction.ClickButtonById(appWin, PaymentModel.Finish_ByID);
                            AutoAction.ClickButtonById(appWin, PaymentModel.OK_ByID);
                            Assert.IsTrue(AutoElement.VisibleById(appWin, ActionsRequired_ByID));
                            deleted = true;
                            break;
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);

                } while (count != actionItems.Count);
            }
            bool checkinGuestFound = false;
            if (deleted == true)
            {
                actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
                var checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                string guestName = "";
                int countItems;

                do
                {
                    countItems = checkinGuest.Count;
                    foreach (AutomationElement guestItem in checkinGuest)
                    {
                        UIAutoHelper.ScrollIntoView(guestItem);
                        var items = AutoElement.GetAllChilderen(guestItem);
                        guestName = items[1].Current.Name;
                        if (guestName == name)
                        {
                            checkinGuestFound = true;
                            break;
                        }
                    }
                    checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (countItems != checkinGuest.Count);
            }
            if (checkinGuestFound == true)
            {
                Assert.Fail("Guest is not deleted");
            }

        }

        //Check the Cacel Visit patient in specific host in checkin mode
        public void checkCancelVisitPatientinPerform(BasicInfoModel basicInfo,string host)
        {
            ChangeCurrentLoactionTerminalCheckIn();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            bool checkinGuestFound = false;
            //var appWin = AutoElement.GetWindowByName(AppWindowName);
            actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var checkinGuest = AutoElement.GetElementCollectionByName(actionHost, host);
            string checkinGuestName = "";
            int countItems;
            do
            {
                countItems = checkinGuest.Count;
                foreach (AutomationElement guestItem in checkinGuest)
                {
                    UIAutoHelper.ScrollIntoView(guestItem);
                    var items = AutoElement.GetAllChilderen(guestItem);
                    checkinGuestName = items[0].Current.Name;
                    if (checkinGuestName == name)
                    {
                        checkinGuestFound = true;
                        break;
                    }
                }
                checkinGuest = AutoElement.GetElementCollectionByName(actionHost, host);
            } while (countItems != checkinGuest.Count);

            Assert.IsTrue(checkinGuestFound == false, "Guest is found in Perform Room after refund");

        }

        public void SearchGuestInPerformRoomWaiting(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementByClassName(appWin, PerformRoomWaitingHost_ByClass);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, WaitingGuestName_ByName);
            string waitingGuest = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        waitingGuest = items[0].Current.Name;

                        if (waitingGuest == name)
                        {
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            Assert.IsTrue(AutoElement.VisibleById(appWin, PaymentModel.MakeAdjustment_ByID));
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, WaitingGuestName_ByName);
                } while (count != actionItems.Count);

            }

        }

        public void CheckGuestInPerform(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;

                        if (performGuestName == name)
                        {
                            Assert.Fail("Guest is displayed in dashboard");

                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);

            }
        }

        public void CheckGuestInCheckIn(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            ChangeCurrentLoactionTerminalCheckIn();
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            string performGuestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;

                        if (performGuestName == name)
                        {
                            Assert.Fail("Guest is displayed in dashboard");

                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
        }

        public void CancelVisitCheckInOrdersReady(BasicInfoModel basicInfo)
        {
            CheckInTests checkIn = new CheckInTests();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            string checkinGuestName = "";
            string task = "";

            int count;
            bool deleted = false;
            if (actionItems.Count != 0)
            {

                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        checkinGuestName = items[1].Current.Name;
                        task = items[4].Current.Name;

                        if (checkinGuestName == name && task == OrdersReady)
                        {
                            UIAutoHelper.performInvokePattern(items[7]);
                            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
                            reason.Select(UtilityClass.GetRandomNumber(0, 20));
                            AutoAction.ClickButtonById(appWin, Yes_ByID);

                            deleted = true;
                            break;
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);

                } while (count != actionItems.Count);
            }
            bool checkinGuestFound = false;
            if (deleted == true)
            {
                actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
                var checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                string guestName = "";
                int countItems;
                //checkIn.NavigateToDashboard();

                do
                {
                    countItems = checkinGuest.Count;
                    foreach (AutomationElement guestItem in checkinGuest)
                    {
                        UIAutoHelper.ScrollIntoView(guestItem);
                        var items = AutoElement.GetAllChilderen(guestItem);
                        guestName = items[1].Current.Name;
                        if (guestName == name)
                        {
                            checkinGuestFound = true;
                            break;
                        }
                    }
                    checkinGuest = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (countItems != checkinGuest.Count);
            }
            if (checkinGuestFound == true)
            {
                Assert.Fail("Guest is not deleted");
            }
        }


        public void MoveToCheckInDetailsGuestInfo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;


                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(selected, "Unable to find the guest " + name);
            Assert.IsTrue(AutoElement.VisibleById(appWin, BasicInfoModel.BasicInfoHost_ByID));
        }

        public void MoveToPerformDetailsGuestInfo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(selected, "Unable to find the guest " + name);
            Assert.IsTrue(AutoElement.VisibleById(appWin, VerifyIdentification.VerifyIdentifiationHost_ByID));
        }

        public void MoveToPerformPrepareContainers(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(selected, "Unable to find the guest " + name);
            Assert.IsTrue(AutoElement.VisibleById(appWin, PrepareContainers.PrepareContainersHost_ByID)); 
        }


        public void MoveToPerformDetailsScanCollection(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(selected, "Unable to find the guest" + name);
            AutoAction.ClickButtonById(appWin, OtherPrintAndAttachLabelsTests.OtherContainersBarcodeOk_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, OtherPrintAndAttachLabelsTests.OtherContainersLabelsHost_ByID));
        }

        public void MoveToPerformDetailsVacutainerScanCollection(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(selected, "Unable to find the guest" + name);
            Assert.IsTrue(AutoElement.VisibleById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByClass));
        }



        [TestMethod]
        public void SelectVisitReport()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonByName(appWin, VisitReport_ByName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, VisitReportListItemsHost_ByID));
        }

        public void SelectGuestInVisitReport(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string fname = basicInfo.FirstName;
            string lname = basicInfo.LastName;
            var actionItems = AutoElement.GetElementCollectionByName(appWin, VisitReportListItem_ByName);
            var selected = false;
            string guestFirstName = "";
            string guestLastName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestLastName = items[0].Current.Name;
                        guestFirstName = items[1].Current.Name;

                        if (guestFirstName == fname && guestLastName == lname)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;


                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(appWin, VisitReportListItem_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(selected, "Unable to find the guest ");
            Assert.IsTrue(AutoElement.VisibleById(appWin, VisitReportModel.VisitReportHost_ByID));
        }

        //CTC-19: patient should be displayed under action required section when visit is pending
        public void IsGuestDisplayedInDashboard(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var selected = false;
            string guestName = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            //UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;


                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(selected, "Unable to find the guest " + name);
            //Assert.IsTrue(AutoElement.VisibleById(appWin, BasicInfoModel.BasicInfoHost_ByID));
        }

        //CTC-74: Verify the dashboard page,patient should display with status "Please complete adjustment and check-in".
        public void CheckGuestCompleteAdjustmentAndNavigateToGuestInfo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var selected = false;
            string guestName = "";
            string guestStatus = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        guestStatus = items[4].Current.Name;

                        if (guestName == name && guestStatus == PleaseCompleteAdjustment)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            selected = true;
                            break;


                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(selected, "Unable to find the guest " + name);
            Assert.IsTrue(AutoElement.VisibleById(appWin, BasicInfoModel.BasicInfoHost_ByID));
        }

        //CTC-75: Verify on clicking back to dashboard button user is displayed in perform room waiting section.
        public void CheckGuestInPerformRoomWaiting(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementByClassName(appWin, PerformRoomWaitingHost_ByClass);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, WaitingGuestName_ByName);
            string waitingGuest = "";
            int count;
            bool found = false;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        waitingGuest = items[0].Current.Name;

                        if (waitingGuest == name)
                        {
                            found = true;
                            break;
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, WaitingGuestName_ByName);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(found, "Unable to find the guest " + name);
        }


        //CTC-141: To Verify user views "Orders ready!please Complete the guest Checkin process"on the dashboard when moved to dash board after Guest info page
        public void CheckGuestForOrdersReady(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var found = false;
            string guestName = "";
            string guestStatus = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        guestStatus = items[4].Current.Name;

                        if (guestName == name && guestStatus == OrdersReady)
                        {
                            found = true;
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(found, "Unable to find the guest " + name);
        }


        //CTC-140: To Verify user views "Please Complete Check in" on the dashboard when moved to dash board after Guest info page
        public void CheckGuestForPleaseCompleteCheckIn(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var found = false;
            string guestName = "";
            string guestStatus = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        guestStatus = items[4].Current.Name;

                        if (guestName == name && guestStatus == CompleteCheckIn_ByName)
                        {
                            found = true;
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(found, "Unable to find the guest " + name);
        }

        //CTC-142: To verify user views "Please Process Refund and complete visit"on the dashboard when refund is initiated
        public void CheckGuestForProcessRefund(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
            var found = false;
            string guestName = "";
            string guestStatus = "";
            int count;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        guestStatus = items[4].Current.Name;

                        if (guestName == name && guestStatus == ProcessRefund_ByName)
                        {
                            found = true;
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, GuestOrders_ByName);
                } while (count != actionItems.Count);

            }
            Assert.IsTrue(found, "Unable to find the guest " + name);
        }

        [TestMethod]
        public void PerformSearchForGuestFieldValidation()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, LastName_ByID, "1234");
            AutoAction.SetTextById(appWin, FirstName_ByID, "1234");
            AutoAction.SetTextById(appWin, DOB_ByID, "2/29/2015");
            Assert.IsFalse(AutoElement.EnabledById(appWin, SearchButton_ByID));
        }

        [TestMethod]
        public void VerifyingFilterLocationOption()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CurrentLocation_ByID);
            AutoAction.SetTextById(appWin, FilterLocation_ByID, GSRLocation2);
            var providerLocationLists = AutoElement.GetElementCollectionByName(appWin, PscProviderLocation_ByName);

            foreach (AutomationElement item in providerLocationLists)
            {
                var childs = AutoElement.GetAllChilderen(item);
                if (childs[0].Current.Name == GSRLocation2)
                {
                    UIAutoHelper.performSelectionItemPattern(item);
                    break;
                }

            }

            if (!AutoElement.GetCheckBoxStateById(appWin, Perform_ByID))
            {
                AutoAction.ClickCheckBoxById(appWin, Perform_ByID);

                if (AutoElement.GetCheckBoxStateById(appWin, CheckIn_ByID))
                {
                    AutoAction.ClickCheckBoxById(appWin, CheckIn_ByID);
                }

                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            else
            {
                AutoAction.ClickButtonById(appWin, ApplyLocation_ByID);
            }
            //CloseTempraturePopup();
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }


        [TestMethod]
        public void GuestSearchResultCheck()
        {
            BasicInfoModel basic = new BasicInfoModel();
            basic.FirstName = "Automation";
            basic.LastName = "AAEFD";
            basic.DOB = "04/16/1991";
            basic.PhoneNo = "6666612842";
            //GuestSearchInProgress(basic);
            //SearchGuestByNameDOBForUpperCase(basic);
            //CheckGuestResultForCaseSensitive(basic);
            //CheckInProgressAndMoveToVerifyIdentificationPage(basic);
            //CheckInProgressAndMoveToPrepareContainersPage(basic);
            CheckInProgressAndMoveToPerformCollectionPage(basic);
        }

        public void GuestSearchInProgress(BasicInfoModel basicInfo)
        {
            //BasicInfoModel basicInfo = new BasicInfoModel();
            //SearchGuestByNameDOB(basicInfo);
            var guestFirstName = basicInfo.FirstName;
            var guestLastName = basicInfo.LastName;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guestResult = AutoElement.GetElementByName(appWin, PerformGuestList_ByName);
            var details = AutoElement.GetAllChilderen(guestResult);
            var fname = details[1].Current.Name;
            var lname = details[0].Current.Name;
            var status = details[7].Current.Name;
            Assert.AreEqual(fname, guestFirstName, "First name of the guest is invalid name");
            Assert.AreEqual(lname, guestLastName, "Last Name of the Guest is Invalid name");
            Assert.AreEqual(status, InProgress, "Guest is not in the In Progress state");
        }

        public void SearchGuestByNameDOBForUpperCase(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, LastName_ByID, basicInfo.LastName.ToUpper());
            AutoAction.SetTextById(appWin, FirstName_ByID, basicInfo.FirstName.ToUpper());
            AutoAction.SetTextById(appWin, DOB_ByID, basicInfo.DOB);
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        public void CheckInProgressAndMoveToVerifyIdentificationPage(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            var resultDisplayed = true;
            var selected = false;
            if (searchResults == null)
            {
                resultDisplayed = false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == basicInfo.LastName && details[1].Current.Name == basicInfo.FirstName && details[5].Current.Name == basicInfo.PhoneNo && details[7].Current.Name == InProgress)
                {
                    UIAutoHelper.performSelectionItemPattern(result);
                    selected = true;
                    Assert.IsTrue(AutoElement.VisibleById(appWin, VerifyIdentification.VerifyIdentifiationHost_ByID));
                }
            }
        }

        public void CheckInProgressAndMoveToPrepareContainersPage(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            var resultDisplayed = true;
            var selected = false;
            if (searchResults == null)
            {
                resultDisplayed = false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == basicInfo.LastName && details[1].Current.Name == basicInfo.FirstName && details[5].Current.Name == basicInfo.PhoneNo && details[7].Current.Name == InProgress)
                {
                    UIAutoHelper.performSelectionItemPattern(result);
                    selected = true;
                    Assert.IsTrue(AutoElement.VisibleById(appWin, PrepareContainers.PrepareContainersHost_ByID));
                }
            }
        }

        public void CheckInProgressAndMoveToPerformCollectionPage(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            var resultDisplayed = true;
            var selected = false;
            if (searchResults == null)
            {
                resultDisplayed = false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == basicInfo.LastName && details[1].Current.Name == basicInfo.FirstName && details[5].Current.Name == basicInfo.PhoneNo && details[7].Current.Name == InProgress)
                {
                    UIAutoHelper.performSelectionItemPattern(result);
                    selected = true;
                    Assert.IsTrue(AutoElement.VisibleById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByID));
                }
            }
        }

        public void CheckGuestInPerformRoom(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementByClassName(appWin, InPerformRoomHost_ByClass);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, InPerformRoomGuestName_ByName);
            string guestName = "";
            int count;
            bool found = false;

            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[0].Current.Name;

                        if (guestName == name)
                        {
                            found = true;
                            break;
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, InPerformRoomGuestName_ByName);
                } while (count != actionItems.Count);
            }
            Assert.IsTrue(found, "Unable to find the guest " + name);
        }

        [TestMethod]
        public void SampleSearch()
        {
            BasicInfoModel basic = new BasicInfoModel();
            basic.LastName = "aqz"; basic.FirstName = "benM";
            basic.DOB = "01/01/1990";
            //SearchGuestForGTTReadyForCollection(basic);
            SearchGuestForGTTUntilNextCollecion(basic);
        }


        public void SearchGuestForGTTReadyForCollection(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string fname = basicInfo.FirstName;
            string lname = basicInfo.LastName;
            var guestName = AutoElement.GetElementByName(appWin, PerformGuestList_ByName);
            var items = AutoElement.GetAllChilderen(guestName);
            var lastName = items[0].Current.Name;
            var firstName = items[1].Current.Name;
            var task = items[7].Current.Name;
            if (lastName == lname && firstName == fname)
            {
                Assert.AreEqual(task, GTTReadyForCollection, "GTT Ready for collection is not displayed for particular guest");
            }

        }

        public void SearchGuestForGTTUntilNextCollecion(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string fname = basicInfo.FirstName;
            string lname = basicInfo.LastName;
            var guestName = AutoElement.GetElementByName(appWin, PerformGuestList_ByName);
            var items = AutoElement.GetAllChilderen(guestName);
            var lastName = items[0].Current.Name;
            var firstName = items[1].Current.Name;
            var task = items[10].Current.Name;
            if (lastName == lname && firstName == fname)
            {
                Assert.AreEqual(task, GTTUntilNextCollection, "GTT until next collection is not displayed for particular guest");
            }
        }

        [TestMethod]
        public void SampleSearchGuest()
        {
            MELoginModel guest = new MELoginModel();
            guest.FirstName = "AAAAA";
            guest.LastName = "Auto";
            var dob = "(01/01/1990)";
            SearchAndSelectMEGuestByNameAndDOB(guest);
        }

        public void SearchAndSelectMEGuestByNameAndDOB(MELoginModel guest)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, LastName_ByID, guest.LastName);
            AutoAction.SetTextById(appWin, FirstName_ByID, guest.FirstName);
            AutoAction.SetTextById(appWin, DOB_ByID, "04/01/1990");
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);
            AutoAction.ClickUIItemByName(appWin, "Theranos.PSC.ServicesProxy.PscService.GuestSearchResult");
            //Assert.IsTrue(ISGuestSearchDisplayedCheckIn(guest));
        }

        public bool ISGuestSearchDisplayedCheckIn(MELoginModel guest)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, CheckInGuestList_ByName);
            if (searchResults == null)
            {
                return false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == guest.LastName && details[1].Current.Name == guest.FirstName)
                {
                    UIAutoHelper.performSelectionItemPattern(result);
                    return true;
                }
            }

            return false;
        }

        public void SearchAndSelectMEGuestByNameAndDOBInPerform(MELoginModel guest)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, LastName_ByID, guest.LastName);
            AutoAction.SetTextById(appWin, FirstName_ByID, guest.FirstName);           
            AutoAction.SetTextById(appWin, DOB_ByID, "(04/01/1990)");
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, SearchButton_ByID);
            AutoAction.ClickUIItemByName(appWin, "Theranos.PSC.UX.Model.Dashboard.Search.GuestSearchResultsInPerformEx" );
            //Assert.IsTrue(IsMEGuestDisplayedInSearchResultsPerform(guest));
        }


        public bool IsMEGuestDisplayedInSearchResultsPerform(MELoginModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchResults = AutoElement.GetElementCollectionByName(appWin, PerformGuestList_ByName);
            if (searchResults == null)
            {
                return false;
            }
            foreach (AutomationElement result in searchResults)
            {
                var details = AutoElement.GetAllChilderen(result);
                if (details[0].Current.Name == basicInfo.LastName && details[1].Current.Name == basicInfo.FirstName)
                {
                    UIAutoHelper.performSelectionItemPattern(result);
                    return true;
                }
            }

            return false;

        }

        [TestMethod]
        public void ConfirmCourierPickUp()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LoginModel.Menu_ByID);
            AutoAction.ClickButtonById(appWin, CourierPickButton_ByID);
            var courierHost = AutoElement.GetElementByClassName(appWin, CourierPickupHost_ByClass);
            var courierItems = AutoElement.GetAllChilderen(courierHost);
            var courierPickupMessage = courierItems[0].Current.Name;
            var userName = courierItems[1].Current.Name;
            var item = DateTime.Now.ToString("MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture);
            var courierDateTime = courierItems[2].Current.Name;
            var location = courierItems[3].Current.Name;
            var message1 = courierItems[4].Current.Name;
            var message2 = courierItems[5].Current.Name;

            Assert.AreEqual(courierPickupMessage, ConfirmCourierMessage_ByName, "Courier pick has not completed");
            Assert.AreEqual(userName, UserName_ByName, "Logged in user name is not displayed");
            Assert.AreEqual(courierDateTime, item, "date and time is not properly displayed");
            Assert.AreEqual(location, Location_ByName, "Location name is different from current location");
            UIAutoHelper.performInvokePattern(courierItems[7]);
            Assert.AreEqual(message1, ThankYou_ByName);
            Assert.AreEqual(message2, PickupConfirmed_ByName);
            UIAutoHelper.performInvokePattern(courierItems[6]);
        }


        [TestMethod]
        public void VerifyLastNameAndDOBMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var lname = appWin.GetElement(SearchCriteria.ByText("Last Name *")).Current.Name;
            Assert.AreEqual(lname,LastName,"* WaterMark is not displayed in the LastName textbox");
        }

        [TestMethod]
        public void VerifyPhoneNumberMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var phoneNo = appWin.GetElement(SearchCriteria.ByText("Phone Number *")).Current.Name;
            Assert.AreEqual(phoneNo,PhoneNumber,"* WaterMark is not displayed in the Phone number textbox");
        }


        [TestMethod]
        public void CheckGuestinDashboard()
        {
            var sample=CheckGuestDetailsinCheckDashboard();
            CheckAndChangeToPerformTerminal();
            var basic=CheckGuestInCheckInQueue();
            VerifyGuestInCheckInQueue(sample, basic);
        }

        public List<SampleBasicInfoModel> CheckGuestDetailsinCheckDashboard()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guests = AutoElement.GetElementById(appWin,ActionsRequired_ByID);
            var listView = AutoElement.GetElementByClassName(guests,ListBox_ByClass,TreeScope.Children);
            var guest = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass,TreeScope.Children);
            //List<SampleModel> basic = new List<SampleModel>();
            //SampleModel sample1 = new SampleModel();
            List<SampleBasicInfoModel> sample = new List<SampleBasicInfoModel>();

           
            foreach (AutomationElement patient in guest)
            {
                SampleBasicInfoModel basic1 = new SampleBasicInfoModel();
                basic1.count = guest.Count.ToString();
                var guestDetails = AutoElement.GetAllChilderen(patient);
                basic1.name = guestDetails[1].Current.Name;
                basic1.duration = guestDetails[5].Current.Name;
                sample.Add(basic1);
                //basic.Add(sample1);
            }
            return sample;
        }

        public List<SampleBasicInfoModel> CheckGuestInCheckInQueue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var checkinQueueHost = AutoElement.GetElementByClassName(appWin, "CheckinQueue");
            var listView = AutoElement.GetElementByClassName(checkinQueueHost, ListBox_ByClass, TreeScope.Children);
            var guest = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            List<SampleBasicInfoModel> sample1 = new List<SampleBasicInfoModel>();
            int count;
            do
            {
                count = guest.Count;
                foreach (AutomationElement patient in guest)
                {
                    UIAutoHelper.ScrollIntoView(patient);
                    SampleBasicInfoModel basic1 = new SampleBasicInfoModel();
                    basic1.count = guest.Count.ToString();
                    var guestDetails = AutoElement.GetAllChilderen(patient);
                    basic1.name = guestDetails[0].Current.Name;
                    basic1.duration = guestDetails[1].Current.Name;
                    sample1.Add(basic1);
                    //basic.Add(sample1);
                } UIAutoHelper.ScrollIntoView(guest[count-1]);
                guest = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            } while (count!=guest.Count);
            return sample1;
            //foreach (var item in sample)
            //{
            //    var count = item.count;
            //    var duration = item.duration;
            //    var name = item.name;
                
            //}
        }

        public void VerifyGuestInCheckInQueue(List<SampleBasicInfoModel> sample, List<SampleBasicInfoModel> basic)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            foreach (var item in sample)
            {
                 var count = item.count;
                 var duration = item.duration;
                 var name = item.name;
                 foreach (var items in basic)
                 {
                     var checkinQueueCount = items.count;
                     var checkinQueueduration = item.duration;
                     var checkinQueueName = items.name;
                     Assert.AreEqual(count,checkinQueueCount);
                     Assert.AreEqual(duration,checkinQueueduration);
                     Assert.AreEqual(name,checkinQueueName);
                 }
            }
        }

        public void VerifyGuestReadyForCollectionInOrder(List<SampleBasicInfoModel> basic)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basic)
            {                
                //var fname=item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[3].Current.Name;

                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            Assert.AreEqual(task,ReadyForCollection);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }

        public void VerifyGuestInProgressInOrder(List<SampleBasicInfoModel> basic)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basic)
            {
                //var fname = item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            Assert.AreEqual(task, InProgress);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }

        public void VerifyGuestGTTReadyForCollectionInOrder(List<SampleBasicInfoModel> basic)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basic)
            {
                //var fname = item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            Assert.AreEqual(task, GTTReadyForCollection);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }

        public void VerifyGuestGTTUntilNextCollectionInOrder(List<SampleBasicInfoModel> basic)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basic)
            {
                //var fname = item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[6].Current.Name;
                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            Assert.AreEqual(task, GTTUntilNextCollection);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }

        public void VerifyGuestNotInPerformAfterVisitComplete(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string name = basicInfo.FirstName + " " + basicInfo.LastName;
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            string performGuestName = "";
            int count;
            if (actionItems.Count != 0)
            {
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        performGuestName = items[1].Current.Name;
                        if (performGuestName == name)
                        {
                            Assert.Fail("Guest is still displayed in the Perform dashboard after completing the visit");                            
                        }
                    }
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }


        public void SelectGuestInPerformTerminal(List<SampleBasicInfoModel> basicInfo)
        {
            CheckInTests checkIn = new CheckInTests();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basicInfo)
            {
                //var fname = item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            checkIn.NavigateToDashboard();
                            //Assert.AreEqual(task, InProgress);
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }

        public void SelectGTTReadyForCollectionGuest(List<SampleBasicInfoModel> basicInfo)
        {
            VerifyIdentificationTests verifyIdentification = new VerifyIdentificationTests();
            PerformTests perform = new PerformTests();
            DashboardTests dashboard = new DashboardTests();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
            var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
            int count;
            string guestName = "";
            string task = "";
            foreach (var item in basicInfo)
            {
                //var fname = item.FirstName;
                //var lname = item.LastName;
                var name = item.name;
                do
                {
                    count = actionItems.Count;
                    foreach (AutomationElement actionItem in actionItems)
                    {
                        UIAutoHelper.ScrollIntoView(actionItem);
                        var items = AutoElement.GetAllChilderen(actionItem);
                        guestName = items[1].Current.Name;
                        task = items[3].Current.Name;
                        if (guestName == name)
                        {
                            UIAutoHelper.ScrollIntoView(actionItem);
                            UIAutoHelper.performSelectionItemPattern(actionItem);
                            verifyIdentification.ScanPhotoID();
                            verifyIdentification.MoveToGlucoseDrink();
                            perform.ClickNextButton();
                            perform.StartTimer();
                            dashboard.CloseTempraturePopup();
                            break;

                        }
                    } UIAutoHelper.ScrollIntoView(actionItems[count - 1]);
                    actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
                } while (count != actionItems.Count);
            }
        }


        [TestMethod]
        public void VerifyReturnContainerLinkIsDisplayed()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleByName(appWin, "RETURN CONTAINER"));
        }

        //public void CheckGuestResultForCaseSensitive(BasicInfoModel basicInfo)
        //{
        //    SearchGuestByNameDOBForUpperCase(basicInfo);
        //    Assert.IsTrue(IsGuestDisplayedInSearchResultsPerform(basicInfo));
        //}


        //    public void CheckInProgressGuestOrder()
        //    {
        //        var appWin = AutoElement.GetWindowByName(AppWindowName);
        //        //string name = basicInfo.FirstName + " " + basicInfo.LastName;
        //        var actionHost = AutoElement.GetElementById(appWin, ActionsRequired_ByID);
        //        var actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
        //        var selected = false;
        //        string time = "";
        //        int count;

        //        if (actionItems.Count!=0)
        //        {
        //            do
        //            {
        //                count = actionItems.Count;

        //                foreach (AutomationElement actionItem in actionItems)
        //                {
        //                     UIAutoHelper.ScrollIntoView(actionItem);
        //                    var items = AutoElement.GetAllChilderen(actionItem);
        //                    time = items[1].Current.Name;
        //                    foreach(AutomationElement actionItem in actionItems)
        //                    {

        //                    }
        //                    //task = items[3].Current.Name;                   
        //                    if (time==time)
        //                    {

        //                    }
        //                }
        //                if (guest)
        //                {
        //                    break;
        //                }
        //                actionItems = AutoElement.GetElementCollectionByName(actionHost, PerformGuestName_Name);
        //            } while (count != actionItems.Count);

        //    }








        //    //[TestCategory(AppSettings.Unit), TestMethod]
        //    //public void SearchForPaymentCompletedGuest()
        //    //{            
        //    //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppSettings.AppWindowName));
        //    //    var guest = appWin.Get(SearchCriteria.ByAutomationId(GuestName_ByID)).Name;
        //    //    pay.BackToDashboard();

        //    //    var actionRequired = appWin.GetElement(SearchCriteria.ByAutomationId(ActionsRequired_ByID));
        //    //    var guestOrders = actionRequired.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));

        //    //    int listItemCount;
        //    //    if (guestOrders.Count != 0)
        //    //    {
        //    //        do
        //    //        {
        //    //            listItemCount = guestOrders.Count;

        //    //            foreach (AutomationElement item in guestOrders)
        //    //            {

        //    //                //var listItemTask = item.FindAll(TreeScope.Descendants,new PropertyCondition(AutomationElement.NameProperty,GuestOrders_ByName));
        //    //                var listItemTask = item.FindAll(TreeScope.Descendants, Condition.TrueCondition);
        //    //                UIAutoHelper.ScrollIntoView(item);
        //    //                if (guest == listItemTask[1].Current.Name)
        //    //                {
        //    //                    Assert.Fail("Guest is still in the Actions Required");   
        //    //                }
        //    //            }
        //    //            UIAutoHelper.ScrollIntoView(guestOrders[listItemCount - 1]);
        //    //            Thread.Sleep(5000);
        //    //            guestOrders = actionRequired.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, GuestOrders_ByName));

        //    //        } while (listItemCount != guestOrders.Count);
        //    //    }
        //    //}
    }
}

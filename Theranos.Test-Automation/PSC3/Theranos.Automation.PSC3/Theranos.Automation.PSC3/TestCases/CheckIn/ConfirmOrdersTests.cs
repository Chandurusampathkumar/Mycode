
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.AutoStack.Utility;
using System.Threading;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.Features;
using SuperMario2.Model;
using System.Text.RegularExpressions;

namespace Theranos.Automation.PSC3.TestCases.CheckIn
{
    [TestClass]
    public class ConfirmOrdersTests : ConfirmOrdersModel
    {

        [TestMethod]
        public void ConfirmOrdersMandatory()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            if (next.Enabled)
            {
                Assert.Fail("Next button is enabled");
            }
        }
        [TestMethod]
        public void TranscriptionOrderMandatory()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var pending = appWin.GetElement(SearchCriteria.ByAutomationId(PendingOrders_ByID));
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            if (pending.Current.IsOffscreen||next.Enabled)
            {
                Assert.Fail("Next button is enabled");
            }               
            
        }

        
        /// <summary>
        /// CTC-60: Verify user is able to review the order details.
        /// </summary>
        [TestMethod]
        public void OrderReview()
        {
            //bool isPriceShown = false;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var labOrderName = AutoElement.GetElementByName(appWin, LabOrder_ByName);
            //UIAutoHelper.performSelectionItemPattern(labOrderName);
            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            AutoAction.ClickCheckBoxById(appWin, Description_ByID);
            Thread.Sleep(2*WaitTime);
            //var reviewReason = AutoElement.GetElementByName(appWin,GuestOrderView_ByName);
            //UIAutoHelper.performInvokePattern(reviewReason);
            AutoAction.ClickUIItemByName(appWin, GuestOrderView_ByName);
            Thread.Sleep(2*WaitTime);
          //  appWin = AutoElement.GetWindowByName(AppWindowName);
            //Assert.IsTrue(AutoElement.VisibleByName(appWin,Price_ByName));
            var item = appWin.GetElement(SearchCriteria.ByText(Price_ByName));
            Assert.IsTrue(item.Current.IsOffscreen);
            SaveOrderDetails();

        }


        [TestMethod]
        public void CheckOrders()
        {
            CheckInProgress(2);
        }


        public void CheckInProgress(int orderNo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            var orders = AutoElement.GetAllChilderen(host);

            string orderName = "";

            var items = AutoElement.GetAllChilderen(orders[orders.Count-orderNo]);
            var orderType = AutoElement.GetAllChilderen(items[1]);
            orderName = orderType[3].Current.Name;
            if (orderName != PSCCloud)
            {
                Assert.Fail("SM2 lab order is not displayed");
            }      

            Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, CheckInformCollect_ByID));
            Assert.IsFalse(AutoElement.EnabledById(appWin,Next_ByID));
        }



        [TestMethod]
        public void CheckForSM2Order()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var host = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            var orders = AutoElement.GetElementByClassName(appWin, GenericLabOrder_ByClass);

            string orderName = "";

            var items = AutoElement.GetAllChilderen(orders);
            //var orderType = AutoElement.GetAllChilderen(items[1]);
            orderName = items[5].Current.Name;
            if (orderName!=PSCCloud)
            {
                Assert.IsTrue(AutoElement.VisibleById(appWin, CheckInformCollect_ByID));
            }
            else
            {
                Assert.Fail("SM2 Order is not deleted");
            }
        }


        [TestMethod]
        public void RemoveOrderInProgress()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,LabOrderList_ByID);
            var orders = AutoElement.GetAllChilderen(host);

            string item1 = "";
            string item2 = "";

            var items = AutoElement.GetAllChilderen(orders[0]);
            var orderType = AutoElement.GetAllChilderen(items[1]);
            item1 = orderType[3].Current.Name;
            if (item1!=PSCCloud)
            {
                Assert.Fail("SM2 lab order is not displayed");                                                  
            }

            items = AutoElement.GetAllChilderen(orders[1]);
            orderType = AutoElement.GetAllChilderen(items[1]);
            item2 = orderType[3].Current.Name;
            if (item2!=DirectTesting)
            {
                Assert.Fail("Direct Testing lab order is not displayed");
            }

            AutoAction.ClickCheckBoxById(appWin, OrdersCheckBoxX_ByID);
            Assert.IsTrue(AutoElement.VisibleByIdNoWait(appWin,CheckInformCollect_ByID));
        }



        [TestMethod]
        public void RemoveOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var check = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(ActiveOrdersCheck_ByID));
            if (check.Checked)
            {
                AutoAction.ClickCheckBoxById(appWin, ActiveOrdersCheck_ByID);
            }
            else
            {
                Assert.Fail("Orders are already removed");
            }
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            var checkInform = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(CheckInformCollect_ByID));
            if (next.Enabled||checkInform.Visible)
            {
                Assert.Fail("Next button is Enabled or CheckInformcollected is visible");
            }

        }

        /// <summary>
        /// CTC-62: Verify user is able to delete the order.
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteOrder()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));

            var confirmOrderHost = appWin.GetElement(SearchCriteria.ByClassName(ConfirmOrder_ByClass));
            var labOrders = AutoElement.GetElementCollectionByName(confirmOrderHost, LabOrder_ByName);
            var labOrdersCount = labOrders.Count;
            
            Assert.IsNotNull(labOrders,"No Orders are available to delete");
            //var labOrderName = AutoElement.GetElementByName(appWin, LabOrder_ByName);
            //UIAutoHelper.performSelectionItemPattern(labOrderName);
            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            AutoAction.ClickButtonById(appWin, DeleteOrder_ByID);
            Thread.Sleep(2*WaitTime);
            labOrders = AutoElement.GetElementCollectionByName(confirmOrderHost, LabOrder_ByName);
            var currentLabOrdersCount = labOrders.Count;
            if (currentLabOrdersCount != labOrdersCount - 1)
            {
                Assert.Fail("Unable to delete the first lab order");
            }

         }
        /// <summary>
        /// check on 'I have informed guest for all collection method' check box
        /// </summary>
        [TestMethod]
        public void ClickCheckInformCollectMethod()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
           
            Assert.IsTrue(AutoElement.EnabledById(appWin, Next_ByID));
        }

        

        /// <summary>
        /// CTC63:Verify user is able confirm the collection method information to guest.
        /// </summary>
        [TestCategory(AppSettings.Unit),TestMethod()]
        public void CheckInformCollectMethod()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin,CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin,Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,SummaryModel.SummaryHost_ByID));            
        }

        [TestMethod]
        public void SaveOrderDetails()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, SaveOrder_ByID);
            //Assert.IsTrue(!AutoElement.VisibleByIdNoWait(appWin, TestList_ByID));
        }


        //CTC-61: Verify user is able to remove tests in the order.
        [TestMethod]
        public void RemoveTest()
        {

            //var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var testsList = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            //var tests = AutoElement.GetElementCollectionByName(testsList, LabOrder_ByName);
            //int count = tests.Count;
            //var item = AutoElement.GetCheckBoxById(appWin, UtilityClass.GetListItemId(CheckBoxX_ByID, count - testNumber));
            //AutoAction.ClickUIItemById(appWin, UtilityClass.GetListItemId(CheckBoxX_ByID, count - testNumber));
            //Assert.IsTrue(!item.Checked, "Order is not removed", +testNumber);  

            var appWin = AutoElement.GetWindowByName(AppWindowName);


            AutomationElement rootElement = AutomationElement.RootElement;
            var windows = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            //var windows = rootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty,AppWindowName));

            //var labOrderName = AutoElement.GetElementByName(appWin, LabOrder_ByName);
            //UIAutoHelper.performSelectionItemPattern(labOrderName);

            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            var orderDetail = AutoElement.GetElementById(windows, TestList_ByID);
            //var orderDetail = windows.FindFirst(TreeScope.Descendants,new PropertyCondition(AutomationElement.AutomationIdProperty,OrderDetails_ByID));
            var test = AutoElement.GetElementByName(orderDetail, TestListItem_ByName);
            //var test = orderDetail.FindFirst(TreeScope.Descendants,new PropertyCondition(AutomationElement.NameProperty,TestsLists_ByName));
            var item = AutoElement.GetElementByClassName(test, CheckBox_ByClass, TreeScope.Children);
            //var item = test.FindFirst(TreeScope.Children,new PropertyCondition(AutomationElement.ClassNameProperty,CPTCheckbox_ByClass));

            if (!UIAutoHelper.IsElementToggledOn(item))
            {
                Assert.Fail("First test has already been removed");
            }
            else
            {
                UIAutoHelper.performTogglePattern(item);
            }
            AutoAction.ClickButtonById(appWin, SaveOrder_ByID);

            //UIAutoHelper.performSelectionItemPattern(labOrderName);
            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            if (UIAutoHelper.IsElementToggledOn(item))
            {
                Assert.Fail("Test has not removed");
            }
            AutoAction.ClickButtonById(appWin, Cancel_ByID);
        }

       
        public void RemoveTestInActiveOrder(string cptCode)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            if((AutoElement.VisibleById(appWin, TestList_ByID)))
            {
                RemoveTest(cptCode);
                SaveOrderDetails();

            }
            else
            {
                Assert.Fail("When Active lab order is selected, Order Details screen is not displayed");
            }
        }

       
        public void RemoveTest(string cptCode)
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var removed = false;
            var testsList = AutoElement.GetElementById(appWin, TestList_ByID);
            var tests = AutoElement.GetElementCollectionByName(testsList, TestListItem_ByName);
            //int count = tests.Count;

            foreach (AutomationElement test in tests)
            {
                var testDetails = AutoElement.GetAllChilderen(test);
                if (testDetails[0].Current.Name==cptCode)
                {
                    if (!UIAutoHelper.IsElementToggledOn(testDetails[0]))
                    {
                        Assert.Fail("Test has already been removed. Test No: ", cptCode);
                    }
                    else
                    {
                        UIAutoHelper.performTogglePattern(testDetails[0]);
                    }
                    removed = true;
                    break;
                }
            }
            Assert.IsTrue(removed);

          
           
           
        }



        [TestMethod()]
        public void remo()
        {
            RemoveTest("2");
        }


        [TestMethod]
        public void ClinicianOrderRemoveTest()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutomationElement rootElement = AutomationElement.RootElement;
            var windows = AutoElement.GetElementByName(rootElement, AppWindowName, TreeScope.Children);
            var ordersName = AutoElement.GetElementCollectionByName(appWin,LabOrder_ByName);
            var name = "";
            int count;

            if (ordersName.Count!=0)
            {
                do
                {
                    count = ordersName.Count;
                    foreach (AutomationElement orderName in ordersName)
                    {
                        UIAutoHelper.ScrollIntoView(orderName);
                        var items = AutoElement.GetAllChilderen(orderName);
                        var order = AutoElement.GetElementByClassName(orderName, GenericLabOrder_ByClass);
                        var itemName = AutoElement.GetAllChilderen(order);
                        name = itemName[1].Current.Name;
                        if (name!=DirectTesting)
                        {
                            UIAutoHelper.performSelectionItemPattern(orderName);
                            var orderDetail = AutoElement.GetElementById(windows, TestList_ByID);
                            var test = AutoElement.GetElementByName(orderDetail, TestListItem_ByName);
                            var item = AutoElement.GetElementByClassName(test, CheckBox_ByClass, TreeScope.Children);

                            if (!UIAutoHelper.IsElementToggledOn(item))
                            {
                                Assert.Fail("First test has already been removed");
                            }
                            else
                            {
                                UIAutoHelper.performTogglePattern(item);
                            }
                            AutoAction.ClickButtonById(appWin, SaveOrder_ByID);

                            UIAutoHelper.performSelectionItemPattern(orderName);
                            if (UIAutoHelper.IsElementToggledOn(item))
                            {
                                Assert.Fail("Test has not removed");
                            }
                            AutoAction.ClickButtonById(appWin, Cancel_ByID);
                        }
                        
                    }
                    AutoElement.GetElementCollectionByName(appWin, LabOrder_ByName);
                } while (count!=ordersName.Count);
                
            }

        }
        
        //[TestMethod]
        //public void OrderPrice()
        //{
        //    DisplayOrderPrice(1);                      
        //}
        
        //Incomplete
        public void DisplayOrderPrice(int orderNo)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var labOrderHost = appWin.GetElement(SearchCriteria.ByAutomationId(LabOrderList_ByID));
            var labOrderList = labOrderHost.FindAll(TreeScope.Children, Condition.TrueCondition);
            var count = labOrderList.Count;

            UIAutoHelper.performSelectionItemPattern(labOrderList[orderNo-1]);
            AutoAction.ClickUIItemById(appWin, Description_ByID);
            AutoAction.ClickUIItemByName(appWin, GuestOrderView_ByName);
                                  
        }

        //CTC-65: Under fasting instructions,"Fasted for "x" hours test" with radio button,"yes","no" ,"not sure"  should be displayed
        [TestMethod]
        public void CheckFastingRequirementIsDisplayed()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin,FastingBeforeTest_ByID));
            Assert.IsTrue(AutoElement.VisibleById(appWin,FastingYes_ByID));
            Assert.IsTrue(AutoElement.VisibleById(appWin,FastingNo_ByID));
            Assert.IsTrue(AutoElement.VisibleById(appWin,FastingNotSure_ByID));
        }

        [TestMethod]
        public void CheckFastingRequirementIsNotDisplayed()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, NoFastingRequirement_ByID));
        }

        [TestMethod]
        public void CheckEmergencyContact()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.VisibleByClassName(appWin,GoToGuestInfoPopup_ByClass));            
            AutoAction.ClickButtonById(appWin,GoToGuestInfo_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, GuestInfoPage_ByID));
        }

        [TestMethod]
        public void CheckEmergencyContactAndCancelVisit()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.VisibleByClassName(appWin,GoToGuestInfoPopup_ByClass));
            AutoAction.ClickButtonById(appWin, CancelVisit_ById);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            Thread.Sleep(5 * WaitTime);
            Assert.IsTrue(AutoElement.VisibleById(appWin, ActionsRequired_ByID));
            //var host = appWin.GetElement(SearchCriteria.ByAutomationId(ActionsRequired_ByID));
            //Assert.IsNotNull(host);
        }

        //[TestMethod]
        //public void OrderDate()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    List<string> dateName = new List<string>();
        //    var host = appWin.GetElement(SearchCriteria.ByAutomationId(CheckInModel.ActiveLabOrdersList_ByID));
        //    var labOrders = host.FindAll(TreeScope.Children,Condition.TrueCondition);
        //    var count = labOrders.Count;
        //    var date = host.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, OrderDate_ByClass));
        //    foreach (AutomationElement item in date)
        //    {
        //        dateName.Add(item.Current.Name);
        //    }
        //    Actions.ClickElementByName(appWin, CheckInModel.ConfirmOrders_ByName);
        //    List<string> orderDateName = new List<string>();
        //    var labOrderHost = appWin.GetElement(SearchCriteria.ByAutomationId(LabOrderList_ByID));
        //    var orders = labOrderHost.FindAll(TreeScope.Children,Condition.TrueCondition);
        //    var orderCount = orders.Count;
        //    var orderdate = labOrderHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, OrderDate_ByClass));
        //    foreach (AutomationElement items in orderdate)
        //    {
        //        orderDateName.Add(items.Current.Name);
        //    }

        //    if (!dateName.SequenceEqual(orderDateName))
        //    {
        //        Assert.Fail("Dates are not equal");
        //    }         
        //}

        [TestMethod]
        public void OrderDate()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            List<string> orderType = new List<string>();
            List<string> dateName = new List<string>();
            var host = AutoElement.GetElementById(appWin,CheckInModel.ActiveLabOrdersList_ByID);
            //var host = appWin.GetElement(SearchCriteria.ByAutomationId(CheckInModel.ActiveLabOrdersList_ByID));
            var labOrders = host.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement item in labOrders)
            {
                var orderElements = item.FindAll(TreeScope.Children, Condition.TrueCondition);
                if (orderElements[1].Current.ClassName == "PaperLabOrderTranscriptionStatus")
                {
                    var dateType = item.FindAll(TreeScope.Children, Condition.TrueCondition);
                    var transcribedDateName = dateType[1].FindAll(TreeScope.Children, Condition.TrueCondition);
                    orderType.Add(transcribedDateName[1].Current.Name);
                    //var dateType = appWin.GetElement(SearchCriteria.ByClassName(TranscribedOrderDate_ByClass));
                    //var transcribedDateName = dateType.FindAll(TreeScope.Children, Condition.TrueCondition);
                    //orderType.Add(transcribedDateName[1].Current.Name);
                }
                else
                {
                    var itemCollection = item.FindAll(TreeScope.Children, Condition.TrueCondition);
                    orderType.Add(itemCollection[1].Current.Name);                   
                }
            }

            //AutoAction.ClickUIItemByName(appWin, CheckInModel.ConfirmOrders_ByName);
            var labOrderHost = AutoElement.GetElementById(appWin,LabOrderList_ByID);
            //var labOrderHost = appWin.GetElement(SearchCriteria.ByAutomationId(LabOrderList_ByID));
            var orders = labOrderHost.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement items in orders)
            {
                var confirmOrdersElement = items.FindAll(TreeScope.Children,Condition.TrueCondition);
                if (confirmOrdersElement[2].Current.ClassName == "PaperLabOrderTranscriptionStatus")
                {
                    var confirmOrdersDate = items.FindAll(TreeScope.Children, Condition.TrueCondition);
                    var confirmOrdersTranscribedDateName = confirmOrdersDate[2].FindAll(TreeScope.Children,Condition.TrueCondition);
                    dateName.Add(confirmOrdersTranscribedDateName[1].Current.Name);
                }
                else
                {
                    var confirmOrdersDateType = items.FindAll(TreeScope.Children, Condition.TrueCondition);
                    dateName.Add(confirmOrdersDateType[2].Current.Name);
                }
            }

            if (!orderType.SequenceEqual(dateName))
            {
                Assert.Fail("Lab Orders Date are not equal");
            }
        }
        /// <summary>
        /// Old name: ConfirmFasting
        /// </summary>
        [TestMethod]
        public void FastingYes()
        {
            CheckFastingRequirementIsDisplayed();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin,FastingYes_ByID);
        }

        /// <summary>
        /// Old name:ConfirmFastingIfAvailable
        /// </summary>
        [TestMethod]
        public void FastingYesIfAvailable()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var fastingYes = AutoElement.GetElementById(appWin, FastingYes_ByID);
            if (!fastingYes.Current.IsOffscreen)
            {
                AutoAction.ClickRadioButtonById(appWin, FastingYes_ByID);    
            }
            
        }

        [TestMethod]
        public void FastingHoursNotSure()
        {
            CheckFastingRequirementIsDisplayed();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingNotSure_ByID);
        }

        [TestMethod]
        public void FastingHoursNo()
        {
            CheckFastingRequirementIsDisplayed();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingNo_ByID);
        }

        [TestMethod]
        public void ClickNextButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.SummaryHost_ByID));
        }

        //CTC-65: In the confirm orders page,under active orders fasting column fasting should be displayed correctly to the respective tests.
        [TestMethod]
        public void CheckFastingInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var fastingHours = AutoElement.GetElementById(appWin, Fasting_ByID);
            var fastingDetails = AutoElement.GetAllChilderen(fastingHours);
            var hours = fastingDetails[1].Current.Name;
            //string hours = "Fasting 10 Hours";
            AutoAction.ClickButtonByName(appWin, CheckInModel.AddLabOrder_ByName);
            var labOrder = AutoElement.GetElementByName(appWin, CheckInModel.LabOrder_ByName);
            var fasting = AutoElement.GetElementByClassName(labOrder, CheckInModel.Fasting_ByClass);
            var timeDetails = AutoElement.GetAllChilderen(fasting);
            var time = timeDetails[1].Current.Name;
            if (time!=hours)
            {
                Assert.Fail("Fasting hours is not displayed correctly");
            }

        }

        //CTC-89: When we did not add fasting hours manually, for some tests ex:80061, 80063... default minimum fasting hours (8 hrs) shall be displayed
        //CTC-108; CTC-120: When test is 80053, default fasting hrs shall be 8 under fasting instructions
        //CTC-109; CTC-121: When test is 80048, default fasting hrs shall be 8 under fasting instructions
        //CTC-110; CTC-122: When test is 80069, default fasting hrs shall be 8 under fasting instructions
        //CTC-111; CTC-123: When test is 82947, default fasting hrs shall be 8 under fasting instructions
        //CTC-112; CTC-124: When test is T700320, default fasting hrs shall be 8 under fasting instructions
        //CTC-113; CTC-125: When test is T700321, default fasting hrs shall be 8 under fasting instructions
        //CTC-114; CTC-126: When test is T700322, default fasting hrs shall be 8 under fasting instructions
        //CTC-115; CTC-127: When test is T700324, default fasting hrs shall be 8 under fasting instructions
        //CTC-116; CTC-128: When test is T700254, default fasting hrs shall be 8 under fasting instructions
        //CTC-117; CTC-129: When test is T700255, default fasting hrs shall be 8 under fasting instructions
        //CTC-118; CTC-130: When test is 84478, default fasting hrs shall be 8 under fasting instructions
        //CTC-119; CTC-131: When test is 80061, default fasting hrs shall be 8 under fasting instructions

        [TestMethod]
        public void ChkForDefaultFastingHrsInActiveOdrs()
        {
            //Check 8 hrs displayed under 'ACTIVE ORDER'... Fasting column
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var fastingHours = AutoElement.GetElementById(appWin, Fasting_ByID);
            var fastingDetails = AutoElement.GetAllChilderen(fastingHours);
            var hours = fastingDetails[1].Current.Name;
            Assert.IsTrue((hours.ToString().Contains("Fasting 8 Hours")), "Default testing hours (8 hrs) did not displayed");

            //Check under 'FASTING INSTRUCTIONS'
            Assert.IsTrue(AutoElement.VisibleById(appWin, FastingBeforeTest_ByID));
            var fastHrsDetails = AutoElement.GetElementById(appWin, FastingBeforeTest_ByID);
            var fastMsg = fastHrsDetails.Current.Name;
            Assert.IsTrue(fastMsg.Equals("Has guest fasted for 8 Hours before test?"), "Minimum fasting hrs does not display by default");
            Assert.IsTrue(AutoElement.VisibleById(appWin, FastingYes_ByID));
            Assert.IsTrue(AutoElement.VisibleById(appWin, FastingNo_ByID));
            Assert.IsTrue(AutoElement.VisibleById(appWin, FastingNotSure_ByID));


        }




        public void ChangePatientCollectionPreference(string collection)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ModifyPreference_ById);

            if (collection.Equals(ContainerModel.Venous))
            {
                AutoAction.ClickRadioButtonById(appWin, SelectVenousDraw_ByID);
            }
            else if (collection.Equals(ContainerModel.Fingerstick))
            {
                AutoAction.ClickRadioButtonById(appWin, SelectFingerstick_ByID);
            }
            AutoAction.ClickButtonById(appWin, Save_ByID);
        }


      
        public void CheckContainers(HashSet<string> expectedContainers)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
           
            HashSet<string> presentContainers = new HashSet<string>();

            var bloodSelection = appWin.Get<Label>(SearchCriteria.ByAutomationId(BloodSelectionLabel_ByID));
            var urine = appWin.Get<Label>(SearchCriteria.ByAutomationId(UrineContainerLabel_ByID));
            var swab = appWin.Get<Label>(SearchCriteria.ByAutomationId(SwabContainerLabel_ByID));
            var stool = appWin.Get<Label>(SearchCriteria.ByAutomationId(StoolContainerLabel_ByID));

            if (bloodSelection.Visible)
            {
                if (bloodSelection.Name == VenousDraw_ByName)
                {
                    presentContainers.Add(ContainerModel.Venous);
                }
                else if (bloodSelection.Name == Fingerstick_ByName)
                {
                    presentContainers.Add(ContainerModel.Fingerstick);
                }
            }

            if (urine.Visible)
            {
                presentContainers.Add(ContainerModel.Urine);
            }

            if (swab.Visible)
            {
                presentContainers.Add(ContainerModel.Swab);
            }

            if (stool.Visible)
            {
                presentContainers.Add(ContainerModel.Stool);
            }

            if (!expectedContainers.SetEquals(presentContainers))
            {
                Assert.Fail("Expected and present containers doesn't match Expected Containers: " + String.Join(", ", expectedContainers) + " Present Containers: " + String.Join(", ", presentContainers));
            }
        }

        [TestMethod]
        public void CheckInformCollectMethodGTTInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            var host = AutoElement.GetElementById(appWin,GTTInstructionPopup_ByID);
            
            var items = AutoElement.GetAllChilderen(host);
            var gttCheck = items[16];

            UIAutoHelper.performTogglePattern(gttCheck); 
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, GTTDone_ByID);
           
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.SummaryHost_ByID));        
           
        }

        [TestMethod]
        public void GTTValidationError()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
                       
            Assert.IsTrue(AutoElement.VisibleById(appWin,Message_ByID));
            AutoAction.ClickButtonById(appWin,Ok_ByID);
        }

        //[TestMethod]
        //public void CustomOrder()
        //{
        //    //RemoveOrder(2);
        //    OpenLabOrderDetails(1);
        //}

        public void RemoveOrder(int orderNumber)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var ordersList = AutoElement.GetElementById(appWin,LabOrderList_ByID);
            var orders = AutoElement.GetElementCollectionByName(ordersList,LabOrder_ByName);
            int count = orders.Count;
            var item = AutoElement.GetCheckBoxById(appWin, UtilityClass.GetListItemId(OrdersCheckBoxX_ByID, count - orderNumber));
            AutoAction.ClickUIItemById(appWin, UtilityClass.GetListItemId(OrdersCheckBoxX_ByID, count-orderNumber));
            Assert.IsTrue(!item.Checked, "Order is not removed", +orderNumber);            
        }


        public void OpenLabOrderDetails(int orderNumber)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var ordersList = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            var orders = AutoElement.GetElementCollectionByName(ordersList, LabOrder_ByName);
            int count = orders.Count;
            var order = orders[count - orderNumber];
            MouseHelper.MoveToAndClick(order);
            //UIAutoHelper.performSelectionItemPattern(order);
            Assert.IsTrue(AutoElement.VisibleById(appWin,TestList_ByID));
        }

     
        [TestMethod]
        public void CheckAndSetHeightRequirement()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,HeightRequirementHost_ByID));
            var feet = UtilityClass.GetRandomNumber(1, 10).ToString();
            var inches = UtilityClass.GetRandomNumber(1, 10).ToString(); 
            AutoAction.SetTextById(appWin,FeetBox_ByID,feet);
            AutoAction.SetTextById(appWin,InchesBox_ByID,inches);
            AutoAction.ClickButtonById(appWin,HeightRequirementDone_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.SummaryHost_ByID));
        }

        //CTC-101: When patient age is above 18 and test is 80048, height requirement pop up shall not display
        //CTC-102: When patient age is above 18 and test is 80053, height requirement pop up shall not display
        //CTC-103: When patient age is above 18 and test is 82565, height requirement pop up shall not display
        //CTC-104: When patient age is above 18 and test is 80069, height requirement pop up shall not display
        //CTC-105: for other tests, regardless of patient age height requriement shall never pop up --> direct order
        //CTC-106: For other tests, regardless of patient age, height requirement shall never pop up --> clinician order
        [TestMethod]
        public void CheckHeightRequirementIsNotDisplayed()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, CheckInformCollect_ByID);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            //Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, HeightRequirementHost_ByID));
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.SummaryHost_ByID));
        }

        [TestMethod]
        public void SelectAllOrders()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.GetCheckBoxStateById(appWin,ActiveOrdersCheck_ByID))
            {
                Assert.Fail("Order is already selected");
            }
            else
            {
                AutoAction.ClickCheckBoxById(appWin, ActiveOrdersCheck_ByID);
            }

            var checkInform = AutoElement.GetCheckBoxById(appWin,CheckInformCollect_ByID);
            if (!checkInform.Visible)
            {
                Assert.Fail("Check inform collection is not visible");
            }
        }

        [TestMethod]
        public void SelectDoNotcollectBlood()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,ModifyPreference_ById);
            AutoAction.ClickRadioButtonById(appWin,Donotcollectblood_ByID);
            AutoAction.ClickButtonById(appWin,Save_ByID);

            Assert.IsTrue(AutoElement.VisibleById(appWin,Ok_ByID));
            AutoAction.ClickButtonById(appWin,Ok_ByID);
            Assert.IsFalse(AutoElement.EnabledById(appWin,Next_ByID));
        }

        [TestMethod]
        public void SelectVenousDraw()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ModifyPreference_ById);
            AutoAction.ClickRadioButtonById(appWin, SelectVenousDraw_ByID);
            AutoAction.ClickButtonById(appWin, Save_ByID);

            Assert.IsTrue(AutoElement.VisibleById(appWin, Ok_ByID));
            AutoAction.ClickButtonById(appWin, Ok_ByID);
            Assert.IsFalse(AutoElement.EnabledById(appWin, Next_ByID));
        }

        [TestMethod]
        public void ChangeToVenousDrawCollection()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ModifyPreference_ById);
            if (!(AutoElement.VisibleById(appWin, SelectVenousDraw_ByID)) || !(AutoElement.VisibleById(appWin, SelectFingerstick_ByID)))
            {
               
                 AutoAction.ClickButtonById(appWin, Save_ByID);
            }
            else
            {
                AutoAction.ClickRadioButtonById(appWin, SelectVenousDraw_ByID);
                AutoAction.ClickButtonById(appWin, Save_ByID);
            }
           
        }

        [TestMethod]
        public void StandingOrder()
        {
            CheckStandingOrder(2);
        }


        public void CheckStandingOrder(int orderNo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            var orders = AutoElement.GetAllChilderen(host);

            string orderName = "";

            var items = AutoElement.GetAllChilderen(orders[orders.Count - orderNo]);
            var orderType = AutoElement.GetAllChilderen(items[1]);
            orderName = orderType[5].Current.Name;
            Assert.AreEqual(orderName,Standing,"Standing order is not displayed in the confirm orders page");
        }

        //CTC-69;  CTC-70: Verify "Standing " is displayed for Standing lab order in confirm orders page
        [TestMethod]
        public void CheckStandingOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, LabOrderList_ByID);
            var labOrder = AutoElement.GetElementByClassName(host, GenericLabOrder_ByClass);
            var items = AutoElement.GetAllChilderen(labOrder);
            var orders = items[5].Current.Name;
            Assert.AreEqual(orders, Standing, "Standing is not displayed for Standing lab order in confirm orders page");

            AutoAction.ClickButtonByName(appWin, CheckInModel.AddLabOrder_ByName);
            var labOrders = AutoElement.GetElementByName(appWin, CheckInModel.LabOrder_ByName);
            var order = AutoElement.GetElementByClassName(labOrders,GenericLabOrder_ByClass);
            var item = AutoElement.GetAllChilderen(order);
            var ordersName = item[5].Current.Name;

            Assert.AreEqual(orders,ordersName,"Standing order is not displayed");

            //string orderName = "";

            //var items = AutoElement.GetAllChilderen(orders[orders.Count - orderNo]);
            //var orderType = AutoElement.GetAllChilderen(items[1]);
            //orderName = orderType[5].Current.Name;
        }

        [TestMethod]
        public void CheckForUrineCollectionType()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, UrineContainerLabel_ByID),"Urine Collection is not displayed");
        }

        [TestMethod]
        public void CheckForSwabCollectionType()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin,SwabContainerLabel_ByID),"Swab collection is not displayed");
        }

        [TestMethod]
        public void CheckForStoolCollectionType()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin,StoolContainerLabel_ByID),"Stool collection is not displayed");
        }

        [TestMethod]
        public void SampleOrderDetails()
        {
            Collectionpro collect = new Collectionpro();
            collect.Physician = "abc Balaji";
            collect.CPT = "82340";
            collect.FastingDetails = "No";
            collect.FastingHour = "8";
            OrderDetailsFromSM2(collect);
            //DirectOrderDetailsFromSM2(collect);
        }


        public void OrderDetailsFromSM2(Collectionpro orderDetails)
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            //var appWin = AutoElement.GetWindowByName(AppWindowName);
            var physicianName = orderDetails.Physician;
            var cpt = orderDetails.CPT;
            var fasting = orderDetails.FastingDetails;
            var fastingHours = orderDetails.FastingHour;

            Thread.Sleep(5000);
            AutoAction.ClickUIItemByName(appWin,LabOrder_ByName);
            
            var labOrderDetails = AutoElement.GetElementByClassName(appWin,GenericLabOrder_ByClass);            
            var physicianItems = AutoElement.GetAllChilderen(labOrderDetails);            
            var clinicianame = physicianItems[1].Current.Name;
            var orderType = physicianItems[5].Current.Name;
            
            var fastingInstruction = AutoElement.GetElementByClassName(appWin,FastingInstruction_ByClass);
            var fastingItems = AutoElement.GetAllChilderen(fastingInstruction);
            var fastingNo = fastingItems[0].Current.Name;
            var fastingYes = fastingItems[1].Current.Name;
            var fastingYesOut = Regex.Replace(fastingYes,"[^0-9]+",string.Empty);

            var cptList = AutoElement.GetElementByName(appWin, TestListItem_ByName);
            var cptListItems = AutoElement.GetAllChilderen(cptList);
            var cptCode = cptListItems[0].Current.Name;

            Assert.AreEqual(clinicianame,physicianName,"Physician name doesn't match with SM2 Physician name");
            Assert.AreEqual(orderType,PSCCloud);

            if (fasting=="No")
            {
                Assert.IsTrue(AutoElement.VisibleByName(appWin,NoFasting_ByName));
            }
            else
            {
                Assert.AreEqual(fastingYesOut, fastingHours);
            }

            Assert.AreEqual(cptCode,cpt,"CPT code doesn't match with SM2 CPT code");
            SaveOrderDetails();
            
            
        }


        [TestMethod]
        public void CheckForDirect()
        {
            var value=IsDirectTesting();
        }
        public bool IsDirectTesting()
        {
            Thread.Sleep(8000);
            //var appWin = AutoElement.GetWindowByName(AppWindowName);
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            Thread.Sleep(5000);
            var order = AutoElement.GetElementByClassName(appWin,GenericLabOrder_ByClass);
            var orderItems = AutoElement.GetAllChilderen(order);
            var test = orderItems[3].Current.IsOffscreen;
            
            if (test!=false)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void DirectOrderDetailsFromSM2(Collectionpro orderDetails)
        {
            Thread.Sleep(8000);
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            //var appWin = AutoElement.GetWindowByName(AppWindowName);
            var cpt = orderDetails.CPT;

            AutoAction.ClickUIItemByName(appWin, LabOrder_ByName);
            var labOrderDetails = AutoElement.GetElementByClassName(appWin, GenericLabOrder_ByClass);
            var orderItems = AutoElement.GetAllChilderen(labOrderDetails);
            var directTesting = orderItems[3].Current.Name;

            var cptList = AutoElement.GetElementByName(appWin, TestListItem_ByName);
            var cptListItems = AutoElement.GetAllChilderen(cptList);
            var cptCode = cptListItems[0].Current.Name;

            Assert.AreEqual(directTesting,DirectTesting,"Direct Testing is not displayed");
            Assert.AreEqual(cptCode, cpt, "CPT code doesn't match with SM2 CPT code");
            SaveOrderDetails();

        }

        public void CheckForOrderDetailsFromME(string code)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemByName(appWin, "Theranos.PSC.UX.Model.Order.LabOrderEx");
            var labOrderDetails = AutoElement.GetElementByClassName(appWin, GenericLabOrder_ByClass);
            var orderItems = AutoElement.GetAllChilderen(labOrderDetails);
            var ME = orderItems[5].Current.Name;

            var cptList = AutoElement.GetElementByName(appWin, TestListItem_ByName);
            var cptListItems = AutoElement.GetAllChilderen(cptList);
            var cptCode = cptListItems[0].Current.Name;

            Assert.AreEqual(ME, "Mobile/Web","ME Orders is not displayed");
            Assert.AreEqual(cptCode, code, "CPT code is not valid code from .ME");
            SaveOrderDetails();
        }

        //Check application thows unavailable tests error message for tests 82140 - Ammonia
        [TestMethod]
        public void CheckErrorForAmmonia()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            string ErrorMessage = AutoElement.GetElementNameById(appWin, Msg_ByID);
            
            if (ErrorMessage.Contains("82140-Ammonia") && ErrorMessage.Contains("tests are removed from this visit"))
               
                Assert.IsTrue(true);
            else
                Assert.Fail("Application does not shows Tests Unavailability error for 82140 test");
           
        }

         //check the latest order (ie order added at last)is checked by default in the confirm orders page
        public void IsLatestOrderChecked(string CName)
        
        {
            
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var latestOrder = AutoElement.GetElementByClassName(appWin, GenericLabOrder_ByClass);
            var clinicianDetails = AutoElement.GetAllChilderen(latestOrder);
            string clinicianName = clinicianDetails[1].Current.Name;

            bool checkboxState = AutoElement.GetCheckBoxStateById(appWin, UtilityClass.GetListItemId(OrdersCheckBoxX_ByID, 0));
            if (clinicianName.Equals(CName))
                Assert.IsTrue(checkboxState,"Latest Order Is not checked by default in the confirm order page");
            else
                Assert.Fail("Latest Order is not been checked");

        }
        
          

    }
}

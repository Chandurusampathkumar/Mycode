
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.AutoStack;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;


namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder
{
    [TestClass]
    public class AddLabOrderTests:AddLabOrderModel
    {
        

        /// <summary>
        /// Verify user is able to scan lab order for sending an order to SM for Transcription.
        /// </summary>
        [TestMethod]
        public void ScanSendForTranscription()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,ActiveLabOrders_ByID);
            //var host = appWin.GetElement(SearchCriteria.ByAutomationId(ActiveLabOrders_ByID));
            //AutomationElementCollection busyBox = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            appWin.WaitWhileBusy();            
            //do
            //{
            //    wait = false;
            //    Thread.Sleep(WaitTime);
            //    foreach (AutomationElement itemInner in busyBox)
            //    {
            //        if(!itemInner.Current.IsOffscreen) 
            //        {
            //            wait=true;
            //            break;
            //        }
            //    }
            //} while (wait);
            ////Check dynamically does the ManualTranscription_ById is enabled or not. If needed update the Framework Library
            AutoAction.ClickButtonById(appWin, SendTranscription_ByID);
            var startTranscription = appWin.Get<Button>(SearchCriteria.ByAutomationId(StartTranscription_ByID));
            if (startTranscription.Enabled)
            {
                Assert.Fail("Start Transcription button is enabled");
            }
            AutoAction.ClickButtonById(appWin, Scan_ByID);            
            //Catch and continue used since busyBox may be closed during sleep.
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement,BusyBox_ByClass);
            //try
            //{
            //    do
            //    {
            //        wait = false;
            //        Thread.Sleep(2*WaitTime);
            //        foreach (AutomationElement itemInner in busyBox)
            //        {
            //            if (!itemInner.Current.IsOffscreen)
            //            {
            //                wait = true;
            //                break;
            //            }
            //        }
            //    } while (wait);
            //}
            //catch (Exception)
            //{
                
            //}
            AutoAction.ClickButtonById(appWin, StartTranscription_ByID);
            //Actions.ClickElementByName(appWin, Next_ByName);
            //busyBox = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            //do
            //{
            //    wait = false;
            //    Thread.Sleep(5*WaitTime);
            //    foreach (AutomationElement itemInner in busyBox)
            //    {
            //        if (!itemInner.Current.IsOffscreen)
            //        {
            //            wait = true;
            //            break;
            //        }
            //    }
            //} while (wait);
            //var guestHost = appWin.GetElement(SearchCriteria.ByAutomationId(AddGuestModel.GuestInfoScreen_ByID));
            //Assert.IsNotNull(guestHost, "Unable to reach AddGuestInfo Page");
       }

        /// <summary>
        /// Verify user is able to scan lab order for Clinician Order.
        /// </summary>
        [TestMethod]
        public void ScanClinicianOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var searchBox = AutoElement.GetElementById(appWin,ActiveLabOrders_ByID);
            //AutomationElementCollection busyBox = searchBox.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            //do
            //{
            //    wait = false;
            //    Thread.Sleep(5* WaitTime);
            //    //Test and try to remove following code in Staging 
            //    busyBox = searchBox.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            //    foreach (AutomationElement itemInner in busyBox)
            //    {
            //        if (!itemInner.Current.IsOffscreen)
            //        {
            //            wait = true;
            //            break;
            //        }
            //    }
            //} while (wait);
            //Check dynamically does the ManualTranscription_ById is enabled or not. If needed update the Framework Library


            AutoAction.ClickUIItemById(appWin, ManualTranscription_ById);           
            //While adding more than a order, element moves to offscreen.
            //var clinicianOrderLabel = appWin.GetElement(SearchCriteria.ByText(ClinicianOrder_ByName));
            //var clinicianOrderButton = TreeWalker.RawViewWalker.GetParent(clinicianOrderLabel);
            //UIAutoHelper.performInvokePattern(clinicianOrderButton);
            Thread.Sleep(1000);
            MouseHelper.MoveToAndClickByName(appWin, ClinicianOrder_ByName);
           // Actions.ClickElementByName(appWin, );
            //var clinicianNextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(ClinicianNextButton_ByID));
            //if (clinicianNextButton.Enabled)
            //{
            //    Assert.Fail("Next button is enabled");
            //}
            AutoAction.ClickButtonById(appWin,Scan_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            ////Catch and continue used since busyBox may be closed during sleep. 
            //try
            //{
            //    do
            //    {
            //        Thread.Sleep(100);
            //        foreach (AutomationElement itemInner in busyBox)
            //        {
            //            if (!itemInner.Current.IsOffscreen)
            //            {
            //                wait = true;
            //                break;
            //            }
            //        }
            //    } while (wait);
            //}
            //catch (Exception)
            //{

            //}
            AutoAction.ClickButtonById(appWin,ClinicianNextButton_ByID);
            
           
            Assert.IsTrue(AutoElement.ExistsById(appWin,ClinicianModel.ClinicianHost_ByID));
            //var clinicianHost = appWin.GetElement(SearchCriteria.ByAutomationId(ClinicianModel.ClinicianHost_ByID));
            //Assert.IsNotNull(clinicianHost, "Unable to reach clinician info page");
        }

        /// <summary>
        /// Verify user is able to scan lab order for Direct Testing
        /// </summary>
        [TestMethod]
        public void ScanDirectTesting()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var activeLabOrdersHost = AutoElement.GetElementById(appWin, ActiveLabOrders_ByID);
            //AutomationElementCollection busyBox = activeLabOrdersHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            //do
            //{
            //    wait = false;
            //    Thread.Sleep(5*WaitTime);
            //    //Check and remove in production environment
            //    busyBox = activeLabOrdersHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            //    foreach (AutomationElement itemInner in busyBox)
            //    {
            //        if (!itemInner.Current.IsOffscreen)
            //        {
            //            wait = true;
            //            break;
            //        }
            //    }
            //} while (wait);
            //Check dynamically does the ManualTranscription_ById is enabled or not. If needed update the Framework Library

            AutoAction.ClickUIItemById(appWin, ManualTranscription_ById);
            Thread.Sleep(WaitTime);
            //While adding more than a order, element moves to offscreen.

            //var directTestingLabel = appWin.GetElement(SearchCriteria.ByText(DirectTesting_ByName));
            //var directtestingButton = TreeWalker.ControlViewWalker.GetParent(directTestingLabel);
            //UIAutoHelper.performInvokePattern(directtestingButton);

    //        Condition conditions = new AndCondition(
    //new PropertyCondition(AutomationElement.IsOffscreenProperty, false),
    //new PropertyCondition(AutomationElement.NameProperty, DirectTesting_ByName));
    ////new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty,true));
    //        var directtestingButton = activeLabOrdersHost.FindFirst(TreeScope.Descendants, conditions);

    //        UIAutoHelper.performInvokePattern(directtestingButton);
            MouseHelper.MoveToAndClickByName(appWin, DirectTesting_ByName);
            //Actions.ClickElementByName(appWin, DirectTesting_ByName);
            //var directNextButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(NextButtonDirect_ByID));
            //if (directNextButton.Enabled)
            //{
            //    Assert.Fail("Next button is enabled");
            //}
            //Thread.Sleep(5 * WaitTime);
            AutoAction.ClickButtonById(appWin, Scan_ByID);
            //wait = false;
            ////Catch and continue used since busyBox may be closed during sleep. 
            ////Need to update code. Check with iteminner or busybox for null value
            //try
            //{
            //    do
            //    {
            //        Thread.Sleep(WaitTime);
            //        foreach (AutomationElement itemInner in busyBox)
            //        {
            //            if (!itemInner.Current.IsOffscreen)
            //            {
            //                wait = true;
            //                break;
            //            }
            //        }
            //    } while (wait);
            //}
            //catch (Exception)
            //{

            //}
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            AutoAction.ClickButtonById(appWin, NextButtonDirect_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, CPTModel.CPTHost_ByID), "Unable to reach add test page");
            //var testHost = appWin.GetElement(SearchCriteria.ByAutomationId(CPTModel.CPTHost_ByID));
            //Assert.IsNotNull(testHost, "Unable to reach add test page");
        }

        public void ScanDirectTestingInvokePattern()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, ManualTranscription_ById);
            Thread.Sleep(WaitTime);
            
            AutoAction.ClickUIItemByName(appWin, DirectTesting_ByName);
            AutoAction.ClickButtonById(appWin, Scan_ByID);

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            AutoAction.ClickButtonById(appWin, NextButtonDirect_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, CPTModel.CPTHost_ByID), "Unable to reach add test page");

        }

        /// <summary>
        ///CTC-42: Verify user is able to cancel an order from any page during Check-In process
        /// </summary>
        [TestMethod]
        public void CancelOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            if (AutoElement.ExistsById(appWin,DirectTestingCancelOrder_ByID))
            {
                AutoAction.ClickButtonById(appWin,DirectTestingCancelOrder_ByID);
            }
           
            else if (AutoElement.ExistsById(appWin, SendForTranscriptionCancelOrderTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, SendForTranscriptionCancelOrderTranscription_ByID);
            }
            
            else if (AutoElement.ExistsById(appWin, ClinicianScanCancelTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, ClinicianScanCancelTranscription_ByID);
            }

            else if (AutoElement.ExistsById(appWin, ClinicianDetailCancelTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, ClinicianDetailCancelTranscription_ByID);
            }
            
            else                                                                                            //Clinician Test Page      
            {
                AutoAction.ClickButtonById(appWin, ClinicianTestCancelTranscription_ByID);
            }

            Assert.IsTrue(AutoElement.ExistsById(appWin,SendTranscription_ByID));
            Assert.IsTrue(AutoElement.ExistsById(appWin,NewOrder_ByID));
        }

        /// <summary>
        /// CTC-43: Verify user is able to delete an order.
        /// CTC-136; CTC-137
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod]
        public void DeleteOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var addLabOrderHost = AutoElement.GetElementById(appWin,ActiveLabOrders_ByID);
            //var addLabOrderHost = appWin.GetElement(SearchCriteria.ByAutomationId(ActiveLabOrders_ByID));
            var labOrders = AutoElement.GetElementCollectionByName(addLabOrderHost,LabOrders_ByName);
            //var labOrders = addLabOrderHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, LabOrders_ByName));
            var labOrdersCount = labOrders.Count;

            Condition conditions = new AndCondition(
                new PropertyCondition(AutomationElement.IsOffscreenProperty, false),
                new PropertyCondition(AutomationElement.ClassNameProperty,Button_ByClass)); 
          
            var deleteButton = labOrders[0].FindFirst(TreeScope.Descendants,conditions);
            UIAutoHelper.performInvokePattern(deleteButton);
            AutoAction.ClickButtonById(appWin, OkButton_ByID);
            Thread.Sleep(WaitTime);
            labOrders = AutoElement.GetElementCollectionByName(addLabOrderHost, LabOrders_ByName); 
            var currentLabOrdersCount = labOrders.Count;
            if (currentLabOrdersCount!=labOrdersCount-1)
            {
                Assert.Fail("Unable to delete the first lab order");
            }
        }

        /// <summary>
        /// Verify user is able submit an clinician or direct testing order to transcription.
        /// </summary>

        //[TestCategory(AppSettings.Unit), TestMethod]
        //public void SumbitForTranscriptionDirect()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    Actions.ClickElementByAutomationID(appWin, DirectTestingSubmitForTranscription_ByID);
        //    var newOrder = appWin.GetElement(SearchCriteria.ByAutomationId(NewOrder_ByID));
        //    Assert.IsNotNull(newOrder);
        //}

        //[TestCategory(AppSettings.Unit), TestMethod]
        //public void SumbitForTranscriptionClinician()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    Actions.ClickElementByAutomationID(appWin, ClinicianScanSumbitForTranscription_ByID);
        //    var newOrder = appWin.GetElement(SearchCriteria.ByAutomationId(NewOrder_ByID));
        //    Assert.IsNotNull(newOrder);
        //}

        //[TestCategory(AppSettings.Unit), TestMethod]
        //public void SumbitForTranscriptionClinicianDetail()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    Actions.ClickElementByAutomationID(appWin, ClinicianDetailSubmitForTranscription_ByID);
        //    var newOrder = appWin.GetElement(SearchCriteria.ByAutomationId(NewOrder_ByID));
        //    Assert.IsNotNull(newOrder);
        //}


        //[TestCategory(AppSettings.Unit), TestMethod]
        //public void SumbitForTranscriptionClinicianTest()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    Actions.ClickButtonByAutomationID(appWin, ClinicianTestSubmitForTranscription_ByID);
        //    var newOrder = appWin.GetElement(SearchCriteria.ByAutomationId(NewOrder_ByID));
        //    Assert.IsNotNull(newOrder);
        //}

        [TestMethod]
        public void EnterNotes()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.VisibleByClassName(appWin,"PopupAddTransctiptionNotes"))
            {
                var notes = AutoElement.GetElementByClassName(appWin,"PopupAddTransctiptionNotes");
                var items = AutoElement.GetAllChilderen(notes);
                UIAutoHelper.performInvokePattern(items[5]);
            }
        }

        [TestMethod]
        public void SumbitForTranscription()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.ExistsByIdNoWait(appWin, DirectTestingSubmitForTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, DirectTestingSubmitForTranscription_ByID);
                EnterNotes();
            }
            
            else if (AutoElement.ExistsByIdNoWait(appWin, ClinicianScanSumbitForTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, ClinicianScanSumbitForTranscription_ByID);
                EnterNotes();
            }
           
            else if (AutoElement.ExistsByIdNoWait(appWin, ClinicianDetailSubmitForTranscription_ByID))
            {
                AutoAction.ClickButtonById(appWin, ClinicianDetailSubmitForTranscription_ByID);
                EnterNotes();
            }
           
            else                                                                                            //Clinician Test Page      
            {
                AutoAction.ClickButtonById(appWin, ClinicianTestSubmitForTranscription_ByID);
                EnterNotes();
            }
            Assert.IsTrue(AutoElement.ExistsById(appWin, NewOrder_ByID));
        }


        /// <summary>
        /// PSC3-TS-109	MoveToGuestInfo
        /// </summary>
        [TestMethod]
        public void ClickNextButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,BasicInfoModel.GuestInfoHost_ByID),"Unable to navigate to GuestInfo Page");
        }

        [TestMethod]
        public void AddNewOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NewOrder_ByID);
            Assert.IsTrue(AutoElement.VisibleByIdNoWait(appWin, SendTranscription_ByID), "Add new order page is not displayed");
        }

        [TestMethod]
        public void CheckAndAddNewOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var newLabOrder = appWin.Get<Button>(SearchCriteria.ByAutomationId(NewOrder_ByID));
            if (newLabOrder.Visible)
            {
                AutoAction.ClickButtonById(appWin, NewOrder_ByID);
                Assert.IsTrue(AutoElement.VisibleByIdNoWait(appWin, SendTranscription_ByID), "Add new order page is not displayed");
            }
            
        }

        public void DeleteLabOrder(int orderNo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,ActiveLabOrdersList_ById);
            var orders = AutoElement.GetAllChilderen(host);
            
            var items = AutoElement.GetAllChilderen(orders[orders.Count-orderNo]);            
            UIAutoHelper.performInvokePattern(items[3]);         
            
            AutoAction.ClickButtonById(appWin,SystemOk_ByID);
        }

        //CTC:96: To verify user is able to "cancel the lab order" after scanning through "send for transcription" link.
        [TestMethod]
        public void ScanAndCancelSendForTranscriptionOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin, ActiveLabOrders_ByID);
            appWin.WaitWhileBusy();

            AutoAction.ClickButtonById(appWin, SendTranscription_ByID);
            var startTranscription = appWin.Get<Button>(SearchCriteria.ByAutomationId(StartTranscription_ByID));
            if (startTranscription.Enabled)
            {
                Assert.Fail("Start Transcription button is enabled");
            }
            AutoAction.ClickButtonById(appWin, Scan_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            AutoAction.ClickButtonById(appWin, SendForTranscriptionCancelOrderTranscription_ByID);

            Assert.IsTrue(AutoElement.ExistsById(appWin, SendTranscription_ByID));
            Assert.IsTrue(AutoElement.ExistsById(appWin, NewOrder_ByID));
        }

        //CTC-139: To Verify user is not able to move to dashboard after scanning  transcribed lab order
        [TestMethod]
        public void ScanDirectTestingAndNavigateToDashboard()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, ManualTranscription_ById);
            Thread.Sleep(WaitTime);

            MouseHelper.MoveToAndClickByName(appWin, DirectTesting_ByName);
            AutoAction.ClickButtonById(appWin, Scan_ByID);                     
            
            var navigationBar = appWin.GetElement(SearchCriteria.ByAutomationId(NavigationBar_ById));
            var backToDashboardImage = navigationBar.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, Image_ByClass));
            var backToDashboardButton = TreeWalker.RawViewWalker.GetParent(backToDashboardImage);
            UIAutoHelper.performInvokePattern(backToDashboardButton);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, "Discard Manual Order Confirmation"), "Discard Confirmation pop up has not come");
            AutoAction.ClickButtonById(appWin,SystemOk_ByID);
            //AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardModel.ActionsRequired_ByID);
            //AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            Assert.IsTrue(AutoElement.ExistsById(appWin, DashboardModel.DashboardHost_ByID));
        }

        [TestMethod]
        public void ScanMultipageSM2LabORder()
        {
            
                var appWin = AutoElement.GetWindowByName(AppWindowName);
                var host = AutoElement.GetElementById(appWin, ActiveLabOrders_ByID);
                //var host = appWin.GetElement(SearchCriteria.ByAutomationId(ActiveLabOrders_ByID));
                //AutomationElementCollection busyBox = host.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
                appWin.WaitWhileBusy();

                ////Check dynamically does the ManualTranscription_ById is enabled or not. If needed update the Framework Library
                AutoAction.ClickButtonById(appWin, SendTranscription_ByID);
                var startTranscription = appWin.Get<Button>(SearchCriteria.ByAutomationId(StartTranscription_ByID));
                if (startTranscription.Enabled)
                {
                    Assert.Fail("Start Transcription button is enabled");
                }
                AutoAction.ClickButtonById(appWin, Scan_ByID);
                //Catch and continue used since busyBox may be closed during sleep.
                AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]        
        public void SelectMultiplePage()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);          
            var labOrder = AutoElement.GetElementById(appWin, ScannedPaperOrderScreen_ByID);
            var items = AutoElement.GetAllChilderen(labOrder);
            UIAutoHelper.performInvokePattern(items[0]);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
        }

        [TestMethod]
        public void SelectSendForTranscription()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);          
            AutoAction.ClickButtonById(appWin, StartTranscription_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,ActiveLabOrders_ByID));
        }
    }
}

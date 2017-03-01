using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.Perform;
using Theranos.Automation.PSC3.TestCases;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.TestCases.Perform;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests;
using Theranos.Automation.PSC3.Models;
using System.Windows.Automation;
using Theranos.Automation.AutoStack.Utility;

namespace Theranos.Automation.PSC3.TestCases.ME
{
    [TestClass]
    public class VisitCompletionTests:PSC3Model
    {
        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();

        CheckInTests checkIn = new CheckInTests();

        AddLabOrderTests addLabOrder = new AddLabOrderTests();
        ClinicianTests clinician = new ClinicianTests();
        CPTTests cpt = new CPTTests();
        ICDTests icd = new ICDTests();
        OrderInstructionsTests orderInstructions = new OrderInstructionsTests();

        AddressTests address = new AddressTests();
        BasicInfoTests basicInfo = new BasicInfoTests();
        ContactTests contact = new ContactTests();
        InsuranceTests insurance = new InsuranceTests();

        GuestFormsTests guestForms = new GuestFormsTests();
        ConfirmOrdersTests confirmOrders = new ConfirmOrdersTests();
        PaymentTests payment = new PaymentTests();
        SummaryTests summary = new SummaryTests();

        PerformTests perform = new PerformTests();
        VerifyIdentificationTests verifyIdentification = new VerifyIdentificationTests();
        PrepareContainersTests prepareContainers = new PrepareContainersTests();

        NanotainersPreScanTests nanoPreScan = new NanotainersPreScanTests();
        NanotainersSampleCollectionTests nanoSample = new NanotainersSampleCollectionTests();
        NanotainersScanCollectionTests nanoScan = new NanotainersScanCollectionTests();

        VacutainersPrintAndAttachLabelsTests vacuPrint = new VacutainersPrintAndAttachLabelsTests();
        VacutainersSampleCollectionTests vacuSample = new VacutainersSampleCollectionTests();
        VacutainersScanCollectionTests vacuScan = new VacutainersScanCollectionTests();

        OtherPrintAndAttachLabelsTests otherPrint = new OtherPrintAndAttachLabelsTests();
        OtherScanCollectionTests otherScan = new OtherScanCollectionTests();

        VisitSummaryTests performSummary = new VisitSummaryTests();
        PerformTests performTest = new PerformTests();

        [TestMethod]
        public void GuestSearch()
        {
            visit("Ab","Autoone","01011991");
        }

        public void visit(string firstName,string lastname,string DOB)
        {
            //login.LoginValid();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var searchBox = AutoElement.GetElementById(appWin, DashboardModel.SearchBox_ByID);

            AutoAction.SetTextById(appWin, DashboardModel.LastName_ByID, lastname);
            AutoAction.SetTextById(appWin, DashboardModel.FirstName_ByID, firstName);
            AutoAction.SetTextById(appWin, DashboardModel.DOB_ByID, DOB);
            AutoAction.SendTabKey();

            string inputData = "FirstName: " + firstName + ", LastName: " + lastname + ", DOB: " + DOB;
            AutoAction.ClickButtonById(appWin, DashboardModel.SearchButton_ByID);

            appWin.WaitWhileBusy();
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);


            //var resultFound = false;
            var listView = AutoElement.GetElementByClassName(searchBox, ListBox_ByClass, TreeScope.Children);
            var listViewItems = AutoElement.GetElementCollectionByClassName(listView, ListBoxItem_ByClass, TreeScope.Children);
            foreach (AutomationElement itemInner in listViewItems)
            {
                var details = AutoElement.GetElementCollectionByClassName(itemInner, TextBlock_ByClass);
                //if (lastname == details[0].Current.Name && firstName == details[2].Current.Name)
                //{
                //    resultFound = true;
                    UIAutoHelper.performSelectionItemPattern(itemInner);

                //}
            }
            //Assert.IsTrue(resultFound, "No results has been found for the data, " + inputData);

            addLabOrder.ClickNextButton();
            AutoAction.SetTextById(appWin,BasicInfoModel.PhoneNo_ByAutoID,"1234567890");
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }
    }
}

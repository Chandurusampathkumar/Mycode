using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios.TrainingScenario
{
    [TestClass]
    public class RemoveTests:PSC3Model
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
        public void RemoveTest01()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255","GTT2");
            cpt.AddTestWithCode("84443", "TSH");
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.AddTestWithCode("82310", "Calcium");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(1);
            confirmOrders.RemoveTest("84443");
            confirmOrders.RemoveTest("T700276");
            confirmOrders.SaveOrderDetails();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void RemoveTest02()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT1");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("82270", "Occult blood Screen");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(1);
            confirmOrders.RemoveTest("T700257");
            confirmOrders.SaveOrderDetails();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void RemoveTest03()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84132","Potassium");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("82270", "Occult blood Screen");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(2);
            confirmOrders.RemoveTest("82270");
            confirmOrders.SaveOrderDetails();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void RemoveTest04()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84295","Sodium");
            cpt.AddTestWithCode("83036","Hemoglobin");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82150","Amylase");
            cpt.AddTestWithCode("86780","Syphilis Screen");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(1);
            confirmOrders.RemoveTest("83036");
            confirmOrders.SaveOrderDetails();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void RemoveTest05()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84295", "Sodium");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86225","DNA");
            cpt.AddTestWithCode("84479", "Thyroid Uptake");
            cpt.AddTestWithCode("82272", "Occult 1 Card");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(2);
            confirmOrders.RemoveTest("84479");
            confirmOrders.SaveOrderDetails();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void RemoveOrderTemp()
        {
            login.LaunchApplication();
            login.LoginValid();
            //dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84295", "Sodium");
            cpt.AddTestWithCode("87046", "Stool Culture");            
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86225", "DNA");
            cpt.AddTestWithCode("84479", "Thyroid Uptake");
            cpt.AddTestWithCode("82272", "Occult 1 Card");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("82270", "Occult blood Screen");
            cpt.AddTestWithCode("83036", "Hemoglobin");
            cpt.AddTestWithCode("82947", "Glucose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.OpenLabOrderDetails(3);
            confirmOrders.RemoveTest("82270");
            confirmOrders.RemoveTest("T700255");
            confirmOrders.SaveOrderDetails();
            confirmOrders.RemoveOrder(1);
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();

        }
    }
}

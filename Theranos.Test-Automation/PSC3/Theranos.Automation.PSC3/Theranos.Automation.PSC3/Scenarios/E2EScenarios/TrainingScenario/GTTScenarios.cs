using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class GTTScenarios:PSC3Model
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
        public void GTT1Hour()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToGlucoseDrink();

            perform.VerifyForGTT1Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            dashboard.CloseTempraturePopup();
            Thread.Sleep(480000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGreyTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
        }


        //TC - 52
        [TestMethod]
        public void GTT1HourWithSodium()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT1");
            cpt.AddTestWithCode("84295","Sodium");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToGlucoseDrink();

            perform.VerifyForGTT1Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            dashboard.CloseTempraturePopup();
            Thread.Sleep(480000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGreyTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
        }

        [TestMethod]
        public void GTTScenarioForTimeExpire1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToGlucoseDrink();

            perform.VerifyForGTT1Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            dashboard.CloseTempraturePopup();
            Thread.Sleep(650000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.CheckCollectionPeroidExpiredAndCancelVisit();
            dashboard.CloseTempraturePopup();
        }

        [TestMethod]
        public void GTTScenarioForTimeExpire2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToGlucoseDrink();

            perform.VerifyForGTT1Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            dashboard.CloseTempraturePopup();
            Thread.Sleep(650000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.CheckCollectionPeroidExpiredAndContinueVisit();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
        }

        [TestMethod]
        public void GTT2Hour()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToGlucoseDrink();
            perform.VerifyForGTT2Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            //dashboard.CloseTempraturePopup();
            Thread.Sleep(480000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToStartTimer();
            perform.StartTimer();
            //dashboard.CloseTempraturePopup();
            Thread.Sleep(420000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
        }

        [TestMethod]
        public void GTT3Hour()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700254", "GTT3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToGlucoseDrink();
            perform.VerifyForGTT3Hour();
            perform.ClickNextButton();
            perform.StartTimer();
            //dashboard.CloseTempraturePopup();
            Thread.Sleep(480000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToStartTimer();
            perform.StartTimer();
            //dashboard.CloseTempraturePopup();
            Thread.Sleep(420000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToStartTimer();
            perform.StartTimer();
            //dashboard.CloseTempraturePopup();
            Thread.Sleep(310000);
            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
        }

        [TestMethod]
        public void GTTValidation()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("T700254", "GTT3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.GTTValidationError();
            checkIn.CancelVisit();
        }
    }
}

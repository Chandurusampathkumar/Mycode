using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.Perform;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;
using Theranos.Automation.PSC3.TestCases;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.TestCases.Perform;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests;

namespace Theranos.Automation.PSC3.Scenarios.CheckinScenario
{
    [TestClass]
    public class CheckInScenarioAparna: PSC3Model
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

        [TestMethod]
        public void ApMethod01()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.ChangeCurrentLoactionTerminalCheckIn();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80055", "Obse Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.ChangeCurrentLoactionTerminalPerform();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerLavender, 2);
            expected.Add(PrepareContainers.ContainerGoldTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
        }
    }
}

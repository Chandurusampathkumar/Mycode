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

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios
{
    [TestClass]
    public class SmokeTestScenarios:PSC3Model
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
        public void SmokeTestScenario1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84443", "TSH");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            //cpt.AddTestWithCode("82340","Calcium, urine");
            cpt.AddTestWithCode("82947", "Glucose");
            icd.AddICDByCode();
            icd.AddICDByName();
            //icd10.AddICD10ByCode();
            //icd10.ADDICD10ByName();
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            insurance.AddInsurancePrimary();
            insurance.AddInsuranceOther();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();

            guestForms.ConfirmGuestSign();
            confirmOrders.OrderReview();
            confirmOrders.OpenLabOrderDetails(1);
            confirmOrders.RemoveTest("84443");
            confirmOrders.DeleteOrder();
            confirmOrders.ChangePatientCollectionPreference("Venous");
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintPaymentSummary();
            summary.Insurance();
            summary.Pay();
            payment.EditVisit();
            summary.SelfPay();
            summary.Pay();
            payment.FullRefund();
            login.Logout();
        }


        [TestMethod]
        public void SmokeTestScenario2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85379", "D-Dimer");
            cpt.AddTestWithCode("84443", "TSH");
            cpt.AddTestWithCode("86480", "QFT");
            cpt.AddTestWithCode("T700308", "B-Cell");
            cpt.AddTestWithCode("87536", "HIV1");
            cpt.AddTestWithCode("83655", "Tan Top");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.AddTestWithCode("82436", "Chloride, urine");
            cpt.AddTestWithCode("T700276", "Swab Collection");
            cpt.AddTestWithCode("82272", "Stool 1");
            cpt.AddTestWithCode("82270", "Stool 3");
            cpt.AddTestWithCode("87177", "Stool kit A");
            cpt.AddTestWithCode("87046", "Stool kit B");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            expected.Add(PrepareContainers.ContainerGoldTop, 1);
            expected.Add(PrepareContainers.ContainerQFTGrey, 1);
            expected.Add(PrepareContainers.ContainerQFTRed, 1);
            expected.Add(PrepareContainers.ContainerQFTPurple, 1);
            expected.Add(PrepareContainers.ContainerLavender, 1);
            expected.Add(PrepareContainers.ContainerPearlTop, 1);
            expected.Add(PrepareContainers.ContainerTanTop, 1);
            expected.Add(PrepareContainers.Container24HourUrineKit, 1);
            expected.Add(PrepareContainers.ContainerUrineKit, 1);
            expected.Add(PrepareContainers.ContainerSwabKit, 1);
            expected.Add(PrepareContainers.ContainerStoolCard1, 1);
            expected.Add(PrepareContainers.ContainerStoolCard3, 1);
            expected.Add(PrepareContainers.ContainerStoolCollectionKitA, 1);
            expected.Add(PrepareContainers.ContainerStoolCollectionKitB, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.MoveToOtherContainersWithoutCentrifuge();

            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodesButtonMandatory();
            otherScan.CompleteScanCollection();
            performSummary.Finish();

            foreach (KeyValuePair<string, bool> barCode in barCodes)
            {


                if (barCode.Value == true)
                {
                    dashboard.ScanReturnContainer(barCode.Key);
                }

                else
                {
                    dashboard.ScanReturncontainerInvalidBarcode(barCode.Key);
                }

            }
        }

        [TestMethod]
        public void SmokeTestScenario3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintPaymentSummary();
            summary.Pay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestPhoneNo(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();
            checkIn.NavigateToDashboard();
            dashboard.CheckInProgress(guestInfo);
            dashboard.CancelVisitPerformTerminal(guestInfo);
            dashboard.CancelVisitCheckinInitiatedByPerform(guestInfo);
        }

        [TestMethod]
        public void SmokeTestScenario4()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            addLabOrder.SumbitForTranscription();
            addLabOrder.ClickNextButton();

            basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.PrintPrivacyPracticeForm();
            guestForms.ConfirmGuestSign();

            confirmOrders.SelectDoNotcollectBlood();
            checkIn.CancelVisit();
        }
    }
}

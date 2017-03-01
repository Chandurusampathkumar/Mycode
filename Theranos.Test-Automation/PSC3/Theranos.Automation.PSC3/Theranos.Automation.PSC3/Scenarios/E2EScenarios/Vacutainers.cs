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
namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios
{
    [TestClass]
    public class Vacutainers:PSC3Model
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
        public void LightBlueTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("85379", "D-Dimer");
            cpt.AddTestWithCode("85385", "Fibrinogen");
            cpt.AddTestWithCode("85730", "PTT");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.CheckDiscardTubeLightBlueTop();
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerLightBlueTop, VacutainersSampleCollection.Instruction3to4Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.VacutainersCheckLabels(1);
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.VerifyForLightBlueTopScancollectionInstruction();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
        }

        [TestMethod]
        public void GoldTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84443", "TSH");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGoldTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerGoldTop, VacutainersSampleCollection.Instruction5Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.VerifyForGoldTopScanCollectionInstruction();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void MintTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82784", "IgA, IgG, IgM");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerMintTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.MintTop, VacutainersSampleCollection.Instruction8Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void QFTTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86480", "quantiferon");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerQFTGrey, 1);
            expected.Add(PrepareContainers.ContainerQFTPurple, 1);
            expected.Add(PrepareContainers.ContainerQFTRed, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.OFTWithMintTop();
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerQFTGrey, VacutainersSampleCollection.Instruction10Times);
            expectedInstruction.Add(VacutainersSampleCollection.ContainerQFTPurple, VacutainersSampleCollection.Instruction10Times);
            expectedInstruction.Add(VacutainersSampleCollection.ContainerQFTRed, VacutainersSampleCollection.Instruction10Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.VacutainersCheckLabels(3);
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.VerifyForQFTScanCollectionInstruction();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void LavenderTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("83036", "HBA1C");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerLavender, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerLavender, VacutainersSampleCollection.Instruction8Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.VerifyForLavenderTubeScanCollectionInstruction();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void PearlTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86703", "HIV");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerPearlTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerPearlTop, VacutainersSampleCollection.Instruction8Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void TanTop()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("83655", "Lead");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerTanTop, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.TanTopWithDiscardTube();
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerTanTop, VacutainersSampleCollection.Instruction8Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        [TestMethod]
        public void TBNK()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700308", "B Cell, Total Count");
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

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerLavender, 1);
            prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            expectedInstruction.Add(VacutainersSampleCollection.ContainerLavender, VacutainersSampleCollection.Instruction8Times);
            vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }
    }
}

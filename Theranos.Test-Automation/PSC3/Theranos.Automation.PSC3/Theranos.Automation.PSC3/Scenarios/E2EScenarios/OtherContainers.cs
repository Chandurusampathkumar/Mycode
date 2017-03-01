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
    public class OtherContainers:PSC3Model
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
        public void UrineContainer()
        {

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            expected.Add(PrepareContainers.ContainerUrineKit, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            //otherPrint.OtherContainersCheckLabels(1);
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodesButtonMandatory();
            otherScan.CompleteScanCollection();
            performSummary.Finish();
            dashboard.CheckGuestInPerform(guestInfo);


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
            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturnContainer(barCode);
            //}

            //dashboard.CheckGuestInCheckIn(guestInfo);
        }

        [TestMethod]
        public void UrineContainer24Hour()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82436", "Chloride, Urine");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            expected.Add(PrepareContainers.Container24HourUrineKit, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodes();
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
            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturnContainer(barCode);
            //}
        }

        [TestMethod]
        public void stool1Container()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82272", "Stool1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            expected.Add(PrepareContainers.ContainerStoolCard1, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
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

            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturnContainer(barCode);
            //}
        }

        [TestMethod]
        public void Stool3Container()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82270", "Stool3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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

            verifyIdentification.HardwareMalfunctioning();
            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerStoolCard3, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodes();
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

            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturnContainer(barCode);
            //}
        }

        [TestMethod]
        public void SwabContainer()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700276", "Swab Collection");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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

            verifyIdentification.HardwareMalfunctioning();
            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerSwabKit, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
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
            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturnContainer(barCode);
            //}
        }

        [TestMethod]
        public void StoolKitAContainer()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("87177", "Stool KitA");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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

            verifyIdentification.HardwareMalfunctioning();
            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerStoolCollectionKitA, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodes();
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
            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturncontainerInvalidBarcode(barCode);
            //}      
        }

        [TestMethod]
        public void StoolKitBContainer()
        {
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("87046", "Stool KitB");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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

            verifyIdentification.HardwareMalfunctioning();
            verifyIdentification.MoveToPrepareContainers();
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerStoolCollectionKitB, 1);
            prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersCheckLabels(1);
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

            //foreach (var barCode in barCodes)
            //{
            //    dashboard.ScanReturncontainerInvalidBarcode(barCode);
            //}        
        }
    }
}

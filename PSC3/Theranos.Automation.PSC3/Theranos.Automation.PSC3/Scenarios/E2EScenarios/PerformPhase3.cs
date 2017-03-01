using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack;
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
    public class PerformPhase3:PSC3Model
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
        public void CheckContainersForLipidPanelAndStoolKitA()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("87177", "StoolKitA");
            cpt.AddTestWithCode("80061", "Lipid Panel");
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
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGoldTop, 1);
            expected.Add(PrepareContainers.ContainerStoolCollectionKitA,1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void PerformScenarioForPanelTest()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("80048", "BMP");
            cpt.AddTestWithCode("80055", "Obstetric panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();
            dashboard.VerifyGuestNotInPerformAfterVisitComplete(guestInfo);
        }

        [TestMethod]
        public void CheckContainersForSwabAndCalciumUrine()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700276", "swab");
            cpt.AddTestWithCode("82340", "calcium urine");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerSwabKit, 1);
            expected.Add(PrepareContainers.Container24HourUrineKit, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContainersForStool3AndStool1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82270", "stool3");
            cpt.AddTestWithCode("82272", "stool1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerStoolCard3, 1);
            expected.Add(PrepareContainers.ContainerStoolCard1, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContaienrsForUrineAndStool1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.AddTestWithCode("82272", "stool1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerUrineKit, 1);
            expected.Add(PrepareContainers.ContainerStoolCard1, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContainersForStool3AndGTT2Hour()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("82270", "stool3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGreyTop, 1);
            expected.Add(PrepareContainers.ContainerStoolCard3, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContainersForStool1AndGTT2Hour()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("82272", "stool1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGreyTop, 1);
            expected.Add(PrepareContainers.ContainerStoolCard1, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContainersForGTT2HourAndStoolA()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.AddTestWithCode("87177", "stoolA");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(PrepareContainers.ContainerGreyTop, 1);
            expected.Add(PrepareContainers.ContainerStoolCollectionKitA, 1);
            prepareContainers.VerifyContainers(expected);
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckContainersAndInstructionsForBMP()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
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


        //TC - 182 : BCell Total Count (T700308) test should display 'Store in Room Temperature' in scan collection page
        [TestMethod]
        public void CheckStoInRoomTempForBCellTC()
        {
            //Checkin with BCell Total Count Test
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700308", "BCell");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            //Navigate to Perform and select the same patient
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerGoldTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            //Dictionary<string, string> expectedInstruction = new Dictionary<string, string>();
            //expectedInstruction.Add(VacutainersSampleCollection.ContainerGoldTop, VacutainersSampleCollection.Instruction5Times);
            //vacuSample.CheckCollectSamplesInstruction(expectedInstruction);
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.VerifyForTBNKLavenderTopScanCollectionInstruction();           //verify 'store in Room Temperature' displayed in scan collection page
            checkIn.NavigateToDashboard();
            
        }

        //TC - 195 -- create two tests Urine and Swab... return one container...  check for the patient in dashboard.. return another container
        [TestMethod]
        public void ReturnContainerOnebyOne()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82340", "Urine");
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            
            dashboard.CheckAndChangeToPerformTerminal();

            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionOtherContainers();

            otherPrint.OtherContainersHandleBarcodePrintingError();
            //otherPrint.OtherContainersCheckLabels(1);
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodes();
            otherScan.CompleteScanCollection();
            performSummary.Finish();
            dashboard.CheckGuestInPerform(guestInfo);

            //return one container out of two and check whether the patient is displayed in dashboard for the 2nd container
            foreach (KeyValuePair<string, bool> barCode in barCodes)
            {

                bool container1returned = false;
                if (barCode.Value == true)
                {
                    dashboard.ScanReturnContainer(barCode.Key);
                    container1returned = true;
                }

                else
                {
                    dashboard.ScanReturncontainerInvalidBarcode(barCode.Key);
                }
                if (container1returned)
                {
                    dashboard.SearchCheckedInGuestNameDOB(guestInfo);
                    dashboard.VerifyReturnContainerLinkIsDisplayed();
                    break;
                    
                }
                checkIn.NavigateToDashboard();


            }
       }

        //TC - 205 -- create a patient with two vacutainer test and enter same barcode for both test scan colletion page ... check the app behavior
        [TestMethod]
        public void SameBarcodeForTwoVacutainer()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85379", "Dimer");
            cpt.AddTestWithCode("84443", "TSH");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();


            dashboard.CheckAndChangeToPerformTerminal();

            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();

            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanSameBarCodes();
            checkIn.NavigateToDashboard();
        }

        //TC - 205 -- create a patient with two vacutainer test and enter same barcode for both test scan colletion page ... check the app behavior
        [TestMethod]
        public void SameBarcodeForTwoOtherContainer()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.AddTestWithCode("81001", "Urine");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();


            dashboard.CheckAndChangeToPerformTerminal();

            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();
            
            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            otherScan.ScanSameBarCodes();
            checkIn.NavigateToDashboard();
        }

        //TC - 206 -- add some test... remove one in confirm order page... verify that is not present in prepare container page
        [TestMethod]
        public void RemTestInConfrmOdrCheckInPrePContainerPage()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85379", "Dimer");
            cpt.AddTestWithCode("84443", "TSH");
            cpt.AddTestWithCode("81001", "Urine");
            cpt.AddTestWithCode("T700276", "Swab");
            

            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.RemoveTestInActiveOrder("81001");
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();


            dashboard.CheckAndChangeToPerformTerminal();

            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.VerifyVacutainer_OtherContainers();
            checkIn.NavigateToDashboard();
            
           
        }


        //TC - 210 -- Change current Location to GSR Location3... add Dimer,PTT tests... check scan barcode page show special handling message or not
        [TestMethod]
        public void ChangeLoc3CheckSpecialHanMsgInScanColl()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckBothCheckInAdPerformTerminal(DashboardModel.GSRLocation3);
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85379", "Dimer");
            cpt.AddTestWithCode("85730", "PTT");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndNavigateToVerifyIdentification();
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();

            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.VerifyForSpecialHandling();
            checkIn.NavigateToDashboard();
            
        }

        //TC - 213 -- click on the Print Extra Labels and Make sure the app does not crash
        [TestMethod]
        public void CheckAppCrashWhenClkVacPrntExtraLbl()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckBothCheckInAdPerformTerminal(DashboardModel.GSRLocation3);
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85379", "Dimer");
            cpt.AddTestWithCode("85730", "PTT");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndNavigateToVerifyIdentification();
            //payment.BackToDashboard();


            //dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();

            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.ClkVacPrntExtraLabelChkApp();
            
            checkIn.NavigateToDashboard();

        }

        //TC - 213 -- click on the Print Extra Labels and Make sure the app does not crash
        [TestMethod]
        public void CheckAppCrashWhenClkOthrPrntExtraLbl()
        {
            //create a visit in check in mode
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();


            dashboard.CheckAndChangeToPerformTerminal();

            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.ClkOthrPrntExtraLabelChkApp();
            
            checkIn.NavigateToDashboard();
        }

        
        [TestMethod]
        public void CheckGuestInOrderScenario1()
        {
            List<SampleBasicInfoModel> basic = new List<SampleBasicInfoModel>();
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            for (int i = 0; i < 2; i++)
            {
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestByCode();
                cpt.SaveDetails();
                addLabOrder.ClickNextButton();
                var guest = basicInfo.AddAndReturnBasicInfo();
                basic.Add(guest);
                address.AddMailingAddress();
                address.AddBillingAddress();
                contact.AddEmergencyContact();
                basicInfo.VerifyGuestID();
                guestForms.ConfirmGuestSign();
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethod();
                summary.PrintAndPay();
                payment.BackToDashboard();
            }
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.VerifyGuestReadyForCollectionInOrder(basic);
        }

        //PTC - 61 Patients of perform workflow -inprogress should be displayed in order by their visit time in ascending order.
        [TestMethod]
        public void CheckGuestInOrderScenario2()
        {
            List<SampleBasicInfoModel> basic = new List<SampleBasicInfoModel>();
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            for (int i = 0; i < 2; i++)
            {
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestByCode();
                cpt.SaveDetails();
                addLabOrder.ClickNextButton();
                var guest = basicInfo.AddAndReturnBasicInfo();
                basic.Add(guest);
                address.AddMailingAddress();
                address.AddBillingAddress();
                contact.AddEmergencyContact();
                basicInfo.VerifyGuestID();
                guestForms.ConfirmGuestSign();
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethod();
                summary.PrintAndPay();
                payment.BackToDashboard();
            }
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SelectGuestInPerformTerminal(basic);
            Thread.Sleep(2000);
            dashboard.VerifyGuestInProgressInOrder(basic);
        }

        //PTC - 62 Verify guest details are displayed order by wait time (as longest wait time first) for  "GTT ready for collection".
        [TestMethod]
        public void CheckGuestInOrderScenario3()
        {
            List<SampleBasicInfoModel> basic = new List<SampleBasicInfoModel>();
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            for (int i = 0; i < 2; i++)
            {
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestWithCode("T700257", "GTT1");
                cpt.SaveDetails();
                addLabOrder.ClickNextButton();
                var guest = basicInfo.AddAndReturnBasicInfo();
                basic.Add(guest);
                address.AddMailingAddress();
                address.AddBillingAddress();
                contact.AddEmergencyContact();
                basicInfo.VerifyGuestID();
                guestForms.ConfirmGuestSign();
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethodGTTInstruction();
                summary.PrintAndPay();
                payment.BackToDashboard();
            }
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.VerifyGuestGTTReadyForCollectionInOrder(basic);
        }

        [TestMethod]
        public void CheckGuestInOrderScenario4()
        {
            List<SampleBasicInfoModel> basic = new List<SampleBasicInfoModel>();
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            for (int i = 0; i < 2; i++)
            {
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestWithCode("T700257", "GTT1");
                cpt.SaveDetails();
                addLabOrder.ClickNextButton();
                var guest = basicInfo.AddAndReturnBasicInfo();
                basic.Add(guest);
                address.AddMailingAddress();
                address.AddBillingAddress();
                contact.AddEmergencyContact();
                basicInfo.VerifyGuestID();
                guestForms.ConfirmGuestSign();
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethodGTTInstruction();
                summary.PrintAndPay();
                payment.BackToDashboard();
            }
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SelectGTTReadyForCollectionGuest(basic);
            dashboard.VerifyGuestGTTUntilNextCollectionInOrder(basic);
        }
            
    }
}

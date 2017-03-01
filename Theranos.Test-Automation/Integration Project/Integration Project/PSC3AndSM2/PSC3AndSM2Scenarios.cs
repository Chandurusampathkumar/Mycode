using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.PSC3.TestCases;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.TestCases.Perform;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests;
using Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests;
using SuperMario2;
using Integration_Project.Model;
using Theranos.Automation.LIS.TestCases;
using Theranos.Automation.LIS.Models;

using System.Collections.Generic;
using LoginTests = Theranos.Automation.PSC3.TestCases.LoginTests;
using System.Threading;

namespace Integration_Project.PSC3AndSM2
{
    [TestClass]
    public class PSC3AndSM2Scenarios:IntegrationModel
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
        Scenario sm2 = new Scenario();
        SM2Login sm2login = new SM2Login();
        LabOrderProcess labOrder = new LabOrderProcess();

        LISLoginTests _login = new LISLoginTests();
        AccessionsTests Accessions = new AccessionsTests();
        AccessionTests1 Accession = new AccessionTests1();



        /// <summary>
        /// Creating a new guest in PSC 3.0 with Send For Transcription Order.
        /// Processing the Lab Order with Clinician Order in SM2.
        /// Completing the visit in PSC3.
        /// and Updating Result in LIS.
        /// </summary>
        [TestMethod]
        public void PSC3AndSM2ClinicianOrder()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanSendForTranscription();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            var mailId = basicInfo.EnterEmailID(guestInfo);
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ConfirmOrdersMandatory();

            sm2login.LaunchApplicationSM2();
            //labOrder.L4ScanBucket();
            labOrder.CheckScanBucketGuestName(guestInfo);
            var orderDetails = labOrder.LabOrderSubmit();
            labOrder.SM2LogOut();

            var orderType = confirmOrders.IsDirectTesting();
            confirmOrders.OrderDetailsFromSM2(orderDetails);
            confirmOrders.FastingYesIfAvailable();
            //confirmOrders.ChangeToVenousDrawCollection();           
            confirmOrders.CheckInformCollectMethod();

            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodesButtonMandatory();
            otherScan.CompleteScanCollection();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();

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
            login.Logout();

            _login.LaunchApplication();
            _login.SampleLoginValidNoLogOut();
            Accession.FinishLabOrderInLisScenario(orderType, guestInfo);
            //Accessions.FinishLabOrderInLis(orderType,guestInfo);
           
        }

      
        /// <summary>
        /// Creating a new guest in PSC 3.0 with Send For Transcription Order.
        /// Processing the Lab Order with Direct Testing Order in SM2.
        /// Completing the visit in PSC3.
        /// and Updating Result in LIS.
        /// </summary>
        [TestMethod]
        public void PSC3AndSM2WithDirectOrder()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanSendForTranscription();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            var mailId = basicInfo.EnterEmailID(guestInfo);
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddAndReturnEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ConfirmOrdersMandatory();

            sm2login.LaunchApplicationSM2();
            labOrder.ScanBucketDirectOrder(guestInfo);
            var orderDetails = labOrder.DirectLabOrderSubmit();
            labOrder.SM2LogOut();

            Thread.Sleep(10000);
            checkIn.MoveToGuestForms();
            guestForms.ClickNextButton();
            confirmOrders.DirectOrderDetailsFromSM2(orderDetails); 
            var orderType = confirmOrders.IsDirectTesting();           
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();

            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            var barCodes = otherScan.ScanBarCodesButtonMandatory();
            otherScan.CompleteScanCollection();
            performSummary.Finish();
            dashboard.CloseTempraturePopup();

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
            login.Logout();

            _login.LaunchApplication();
            _login.SampleLoginValidNoLogOut();
            Accession.FinishLabOrderInLisScenario(orderType, guestInfo);
        }

        [TestMethod]
        public void PSC3AndSM2IntegrationScenario()
        {
            PSC3AndSM2ClinicianOrder();
            PSC3AndSM2WithDirectOrder();
        }

       
      
        

        //LIS Via Direct Mode and Physician Mode

        //[TestMethod()]
        //public void LisDirectorModeTestScenario()
        //{
        //    _login.LaunchApplication();
        //    _login.LoginValidNoLogOut();
        //    Accessions.FinishLabOrderInLis(true, AccessionsModel.SampleTestPatientNameString, "test", new DateTime(1991, 02, 10));
        //}
        //[TestMethod()]
        //public void LisPhysicianModeTestScenario()
        //{
        //    _login.LaunchApplication();
        //    _login.LoginValidNoLogOut();
        //    Accessions.FinishLabOrderInLis(false, AccessionsModel.SampleTestPatientNameString, "test", new DateTime(1991, 02, 10));
        //}

    }
}

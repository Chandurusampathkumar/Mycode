using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
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
    public class PerformPhase2:PSC3Model
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
        public void NanotainerUnableToCollect()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            dashboard.CheckReadyForCollection(guestInfo);
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            //  verifyIdentification.VerifyBasicInfo(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            if (IsNanotainerEnabled)
            {

                prepareContainers.MoveToPerformCollectionNanotainers();

                var barCodes = nanoPreScan.PreScanNanotainer();
                nanoPreScan.MoveToCollectSamples();
                nanoSample.MoveToScanCollection();
                nanoScan.NanotainerUnableToCollect();
            }

            else
            {
                prepareContainers.MoveToPerformCollectionVacutainers();

                vacuSample.CollectionComplete();
                vacuPrint.HandleBarcodePrintingError();
                vacuPrint.MoveToScanCollection();
                vacuScan.VacutainerUnableToCollect();       //TC 187, 188 covered in that method
            }

        }

        [TestMethod]
        public void VacutainerUnableToCollect()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("83003", "Growth Hormone");
            //cpt.AddTestWithCode("82784", "IgA, IgG, IgM");
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
            dashboard.CheckReadyForCollection(guestInfo);
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.VacutainerUnableToCollect();
        }

        [TestMethod]
        public void OtherContainerUnableToCollect()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("81001", "Urinalysis");
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
            dashboard.CheckReadyForCollection(guestInfo);
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionOtherContainers();

            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            otherScan.OtherContainerUnableToCollect();
        }

        //[TestMethod]
        //public void NanotainerButtonMandatory()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("82947", "Gulcose");
        //    cpt.AddTestWithCode("85025", "CBC");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.FastingYes();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.CheckReadyForCollection(guestInfo);
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    //  verifyIdentification.VerifyBasicInfo(guestInfo);
        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    if (IsNanotainerEnabled)
        //    {
        //        prepareContainers.MoveToPerformCollectionNanotainers();

        //        var barCodes = nanoPreScan.PreScanNanotainerButtonMandatory();
        //        nanoPreScan.MoveToCollectSamples();
        //        nanoSample.MoveToScanCollection();
        //        nanoScan.PostScanNanotainerButtonMandatory(barCodes);
        //        nanoScan.MoveToFinishWithoutCentrifuge();  
        //    }

        //    else
        //    {
        //        prepareContainers.MoveToPerformCollectionVacutainers();

        //        vacuSample.CollectionComplete();
        //        vacuPrint.HandleBarcodePrintingError();
        //        vacuPrint.MoveToScanCollection();
        //        vacuScan.ScanBarCodesButtonMandatory();
        //        vacuScan.MoveToFinishWithoutCentrifuge();
        //    }
           

        //    performSummary.Finish();
        //}

        //[TestMethod]
        //public void VacutainerButtonMandatory()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("82150", "Amylase");
        //    cpt.AddTestWithCode("85730", "PTT");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.CheckReadyForCollection(guestInfo);
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionVacutainers();

        //    vacuSample.CollectionComplete();
        //    vacuPrint.HandleBarcodePrintingError();
        //    vacuPrint.MoveToScanCollection();
        //    vacuScan.ScanBarCodesButtonMandatory();
        //    vacuScan.MoveToFinishWithoutCentrifuge();
        //    performSummary.Finish();
        //}

        //[TestMethod]
        //public void OtherContainersButtonMandatory()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("81001", "Urinalysis");
        //    cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea, DNA Qualitative");
        //    cpt.AddTestWithCode("87046", "Stool Culture");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.CheckReadyForCollection(guestInfo);
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionOtherContainers();

        //    otherPrint.OtherContainersHandleBarcodePrintingError();
        //    otherPrint.OtherContainersMoveToScanCollection();
        //    var barCodes = otherScan.ScanBarCodesButtonMandatory();
        //    otherScan.CompleteScanCollection();
        //    performSummary.Finish();
        //}

        [TestMethod]
        public void CancelVisit1()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            dashboard.CheckReadyForCollection(guestInfo);
            dashboard.CancelVisitPerformTerminal(guestInfo);
            dashboard.CancelVisitCheckinInitiatedByPerform(guestInfo);
        }
        //TC - 192 -- after cancel visit, check the patient is not present in perform room waiting as well as in Inperform 
        [TestMethod]
        public void CancelVisit2()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();
            
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
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
            checkIn.NavigateToDashboard();
            dashboard.CheckInProgress(guestInfo);
            dashboard.CancelVisitPerformTerminal(guestInfo);
            dashboard.CancelVisitCheckinInitiatedByPerform(guestInfo);
            dashboard.checkCancelVisitPatientinPerform(guestInfo, DashboardModel.WaitingGuestName_ByName);      //check the patient name in perform room wainting
            dashboard.checkCancelVisitPatientinPerform(guestInfo, DashboardModel.InPerformRoomGuestName_ByName); // check the patient name in InPerform


        }

        //[TestMethod]
        //public void LightBlueTopWithDiscardTube()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("85379", "D-dimer");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.CheckReadyForCollection(guestInfo);
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionVacutainers();
        //    prepareContainers.CheckDiscardTubeLightBlueTop();

        //    vacuSample.CollectionComplete();
        //    vacuPrint.HandleBarcodePrintingError();
        //    vacuPrint.MoveToScanCollection();
        //    vacuScan.ScanBarCodesButtonMandatory();
        //    vacuScan.MoveToFinishWithoutCentrifuge();
        //    performSummary.Finish();
        //}

        //[TestMethod]
        //public void TanTopWithDiscardTube()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("83655", "Lead");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.CheckReadyForCollection(guestInfo);
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();
        //    prepareContainers.TanTopWithDiscardTube();
        //    prepareContainers.MoveToPerformCollectionVacutainers();
            

        //    vacuSample.CollectionComplete();
        //    vacuPrint.HandleBarcodePrintingError();
        //    vacuPrint.MoveToScanCollection();
        //    vacuScan.ScanBarCodesButtonMandatory();
        //    vacuScan.MoveToFinishWithoutCentrifuge();
        //    performSummary.Finish();
        //}

        [TestMethod]
        public void TanTopWithoutDiscardTube()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84443", "TSH");
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
            dashboard.CheckReadyForCollection(guestInfo);
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionVacutainers();
            prepareContainers.TanTopWithoutDiscardTube();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodesButtonMandatory();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
        }
       
    }
}

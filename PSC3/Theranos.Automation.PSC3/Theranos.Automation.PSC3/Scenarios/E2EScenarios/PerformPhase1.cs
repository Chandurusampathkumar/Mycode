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
    public class PerformPhase1:PSC3Model
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

        /// <summary>
        /// To verify user is able to collect sample in Green Nanotainer container and complete the visit successfully.
        /// </summary>
        [TestMethod()]
        public void NanotainerGreen1()
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
            
          //  verifyIdentification.VerifyBasicInfo(guestInfo);
            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            if (IsNanotainerEnabled)
            {
                //Verify Containers
                Dictionary<string, int> expected = new Dictionary<string, int>();
                expected.Add(PrepareContainers.ContainerNanotainerGreen, 1);
                prepareContainers.VerifyContainers(expected);
                prepareContainers.MoveToPerformCollectionNanotainers();
                nanoPreScan.PreScanInvalidGreenBarCode1();
                nanoPreScan.PreScanInvalidGreenBarCode2();
                var barCodes = nanoPreScan.PreScanNanotainerButtonMandatory();
                nanoPreScan.MoveToCollectSamples();
                //CheckNanotainerInstruction
                nanoSample.CheckNanotainerInstruction(1);
                nanoSample.MoveToScanCollection();
                nanoScan.PostScanInvalidGreenBarCode1();
                nanoScan.PostScanInvalidGreenBarCode2();
                nanoScan.PostScanNanotainerButtonMandatory(barCodes);
                nanoScan.PostScanNanotainerInstruction();
                nanoScan.MoveToFinishWithoutCentrifuge();
            }
            else
            {
                prepareContainers.MoveToPerformCollectionVacutainers();
                vacuSample.CollectionComplete();
                vacuPrint.HandleBarcodePrintingError();
                vacuPrint.MoveToScanCollection();
                vacuScan.ScanBarCodes();
                vacuScan.MoveToFinishWithoutCentrifuge();                
            }

            performSummary.Finish();

        }

        //[TestMethod()]
        //public void NanotainerGreen2()
        //{
        //    if (IsNanotainerEnabled)
        //    {
        //        BasicInfoModel guestInfo = new BasicInfoModel();

        //        login.LaunchApplication();
        //        login.LoginValid();
        //        dashboard.CheckAndChangeToCheckInTerminal();
        //        dashboard.SearchAndAddByNameDOB();
        //        addLabOrder.ScanDirectTesting();
        //        cpt.AddTestWithCode("82947", "Gulcose");
        //        cpt.SaveDetails();
        //        addLabOrder.ClickNextButton();
        //        guestInfo = basicInfo.AddAndReturnGuestInfo();
        //        address.AddMailingAddress();
        //        address.AddBillingAddress();
        //        contact.AddEmergencyContact();
        //        basicInfo.VerifyGuestID();
        //        guestForms.ConfirmGuestSign();
        //        confirmOrders.FastingYes();
        //        confirmOrders.CheckInformCollectMethod();
        //        summary.PrintAndPay();
        //        payment.BackToDashboard();

        //        dashboard.CheckAndChangeToPerformTerminal();
        //        dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //        //  verifyIdentification.VerifyBasicInfo(guestInfo);
        //        verifyIdentification.ScanPhotoID();
        //        verifyIdentification.MoveToPrepareContainers();


        //        //Verify Containers
        //        Dictionary<string, int> expected = new Dictionary<string, int>();
        //        expected.Add(PrepareContainers.ContainerNanotainerGreen, 1);
        //        prepareContainers.VerifyContainers(expected);
        //        prepareContainers.MoveToPerformCollectionNanotainers();
        //        nanoPreScan.PreScanInvalidGreenBarCode2();
        //        var barCodes = nanoPreScan.PreScanNanotainer();
        //        nanoPreScan.MoveToCollectSamples();
        //        //CheckNanotainerInstruction
        //        nanoSample.CheckNanotainerInstruction(1);
        //        nanoSample.MoveToScanCollection();
        //        nanoScan.PostScanInvalidGreenBarCode2();
        //        nanoScan.PostScanNanotainer(barCodes);
        //        nanoScan.PostScanNanotainerInstruction();
        //        nanoScan.MoveToFinishWithoutCentrifuge();

        //        performSummary.Finish();
        //    }
        //    else
        //    {
        //        TestContext.WriteLine("This scenario is skipped since nanotainer module is disabled.");
        //    }

        //}
        
        /// <summary>
        /// To verify user is able to collect sample in Purple nanotainer container and complete the visit successfully.
        /// </summary>
        [TestMethod]
        public void NanotainerPurple1()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("85025", "CBC");
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

            if (IsNanotainerEnabled)
            {
                //Verify Containers
                Dictionary<string, int> expected = new Dictionary<string, int>();
                expected.Add(PrepareContainers.ContainerNanotainerPurple, 1);
                prepareContainers.VerifyContainers(expected);
                prepareContainers.MoveToPerformCollectionNanotainers();
                nanoPreScan.PreScanInvalidPurpleBarcode1();
                nanoPreScan.PreScanInvalidPurpleBarCode2();
                var barCodes = nanoPreScan.PreScanNanotainerButtonMandatory();
                nanoPreScan.MoveToCollectSamples();
                //CheckNanotainerInstruction
                nanoSample.CheckNanotainerInstruction(1);
                nanoSample.MoveToScanCollection();
                nanoScan.PostScanInvalidPurpleBarcode1();
                nanoScan.PostScanInvalidPurpleBarCode2();
                nanoScan.PostScanNanotainerButtonMandatory(barCodes);
                nanoScan.PostScanNanotainerInstruction();
                nanoScan.MoveToFinishWithoutCentrifuge();
            }
            else
            {
                prepareContainers.MoveToPerformCollectionVacutainers();
                vacuSample.CollectionComplete();
                vacuPrint.HandleBarcodePrintingError();
                vacuPrint.MoveToScanCollection();
                vacuScan.ScanBarCodes();
                vacuScan.MoveToFinishWithoutCentrifuge();
            }

            performSummary.Finish();

        }


        //[TestMethod]
        //public void NanotainerPurple2()
        //{
        //    if (IsNanotainerEnabled)
        //    {
        //        BasicInfoModel guestInfo = new BasicInfoModel();

        //        login.LaunchApplication();
        //        login.LoginValid();
        //        dashboard.CheckAndChangeToCheckInTerminal();
        //        dashboard.SearchAndAddByNameDOB();
        //        addLabOrder.ScanDirectTesting();
        //        cpt.AddTestWithCode("85025", "CBC");
        //        cpt.SaveDetails();
        //        addLabOrder.ClickNextButton();
        //        guestInfo = basicInfo.AddAndReturnGuestInfo();
        //        address.AddMailingAddress();
        //        address.AddBillingAddress();
        //        contact.AddEmergencyContact();
        //        basicInfo.VerifyGuestID();
        //        guestForms.ConfirmGuestSign();
        //        confirmOrders.CheckInformCollectMethod();
        //        summary.PrintAndPay();
        //        payment.BackToDashboard();

        //        dashboard.CheckAndChangeToPerformTerminal();
        //        dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //        verifyIdentification.ScanPhotoID();
        //        verifyIdentification.MoveToPrepareContainers();

        //        //Verify Containers
        //        Dictionary<string, int> expected = new Dictionary<string, int>();
        //        expected.Add(PrepareContainers.ContainerNanotainerPurple, 1);
        //        prepareContainers.VerifyContainers(expected);
        //        prepareContainers.MoveToPerformCollectionNanotainers();
        //        nanoPreScan.PreScanInvalidPurpleBarCode2();
        //        var barCodes = nanoPreScan.PreScanNanotainer();
        //        nanoPreScan.MoveToCollectSamples();
        //        //CheckNanotainerInstruction
        //        nanoSample.CheckNanotainerInstruction(1);
        //        nanoSample.MoveToScanCollection();
        //        nanoScan.PostScanInvalidPurpleBarCode2();
        //        nanoScan.PostScanNanotainer(barCodes);
        //        nanoScan.PostScanNanotainerInstruction();
        //        nanoScan.MoveToFinishWithoutCentrifuge();


        //        performSummary.Finish();
        //    }

        //    else
        //    {
        //        TestContext.WriteLine("This Scenario is skipped since Nanotainer module is disabled");
        //    }

        //}

        [TestMethod]
        public void Nanotainer()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.AddTestWithCode("85025", "CBC");
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
            
            if (IsNanotainerEnabled)
	        {

                Dictionary<string, int> expected = new Dictionary<string, int>();
                expected.Add(PrepareContainers.ContainerNanotainerGreen, 1);
                expected.Add(PrepareContainers.ContainerNanotainerPurple, 1);
                prepareContainers.VerifyContainers(expected);
                prepareContainers.MoveToPerformCollectionNanotainers();

                var barCodes = nanoPreScan.PreScanNanotainer();
                nanoPreScan.MoveToCollectSamples();
                nanoSample.CheckNanotainerInstruction(2);
                nanoSample.MoveToScanCollection();
                nanoScan.PostScanNanotainer(barCodes);
                nanoScan.PostScanNanotainerInstruction();
                nanoScan.MoveToFinishWithoutCentrifuge();
	        }          

            else
            {
                prepareContainers.MoveToPerformCollectionVacutainers();
                vacuSample.CollectionComplete();
                vacuPrint.HandleBarcodePrintingError();
                vacuPrint.MoveToScanCollection();
                vacuScan.ScanBarCodes();
                vacuScan.MoveToFinishWithoutCentrifuge();
            }

            performSummary.Finish();
        }


        ///// <summary>
        ///// To verify user is able to collect sample in Vacutainer container and complete the visit successfully.
        ///// </summary>
        //[TestMethod]
        //public void Vacutainer1()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("82150", "Amylase");
        //    cpt.AddTestWithCode("T700299", "HIV 1/2 screen w/ Reflex");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPayCancel();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionVacutainers();

        //    vacuSample.CollectionComplete();
        //    vacuPrint.HandleBarcodePrintingError();
        //    vacuPrint.VacutainersCheckLabels(2);
        //    vacuPrint.MoveToScanCollection();
        //    vacuScan.ScanBarCodes();
        //    vacuScan.MoveToFinishWithoutCentrifuge();
        //    performSummary.Finish();

        //}

        //[TestMethod]
        //public void Vacutainer2()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("80048", "BMP");
        //    cpt.AddTestWithCode("80053", "CMP");
        //    cpt.AddTestWithCode("80055", "Obstetric Panel");
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
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionVacutainers();

        //    vacuSample.CollectionComplete();
        //    vacuPrint.HandleBarcodePrintingError();
        //    vacuPrint.VacutainersCheckLabels(5);
        //    vacuPrint.MoveToScanCollection();
        //    vacuScan.ScanBarCodes();
        //    vacuScan.MoveToFinishWithoutCentrifuge();
        //    performSummary.Finish();
        //}

        ///// <summary>
        ///// To verify user is able to collect sample in other containers and complete the visit successfully. 
        ///// Also verify return container workflow
        ///// </summary>
        //[TestMethod]
        //public void OtherContainers1()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("81001", "Urinalysis");
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
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionOtherContainers();

        //    otherPrint.OtherContainersHandleBarcodePrintingError();
        //    otherPrint.OtherContainersCheckLabels(1);
        //    otherPrint.OtherContainersMoveToScanCollection();
        //    var barCodes = otherScan.ScanBarCodes();
        //    otherScan.CompleteScanCollection();
        //    performSummary.Finish();

        //    foreach (var barCode in barCodes)
        //    {
        //        dashboard.ScanReturnContainer(barCode);
        //    }

        //    dashboard.ScanReturncontainerInvalidBarcode(barCodes[0]);

        //}


        //[TestMethod]
        //public void OtherContainers2()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("81001", "Urinalysis");
        //    cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea, DNA Qualitative");
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
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionOtherContainers();

        //    otherPrint.OtherContainersHandleBarcodePrintingError();
        //    otherPrint.OtherContainersCheckLabels(2);
        //    otherPrint.OtherContainersMoveToScanCollection();
        //    var barCodes = otherScan.ScanBarCodes();
        //    otherScan.CompleteScanCollection();
        //    performSummary.Finish();

        //    foreach (var barCode in barCodes)
        //    {
        //        dashboard.ScanReturnContainer(barCode);
        //    }
        //}


        //[TestMethod]
        //public void OtherContainers3()
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
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionOtherContainers();

        //    otherPrint.OtherContainersHandleBarcodePrintingError();
        //    otherPrint.OtherContainersCheckLabels(3);
        //    otherPrint.OtherContainersMoveToScanCollection();
        //    var barCodes = otherScan.ScanBarCodes();
        //    otherScan.CompleteScanCollection();
        //    performSummary.Finish();

        //    foreach (var barCode in barCodes)
        //    {
        //        dashboard.ScanReturnContainer(barCode);
        //    }
        //}

        /// <summary>
        /// To verify functionality of post scan barcode validation during nanotainer collection
        /// </summary>
        [TestMethod]
        public void PostScanValidationNanotainer()
        {
            if (IsNanotainerEnabled)
            {
                BasicInfoModel guestInfo = new BasicInfoModel();

                login.LaunchApplication();
                login.LoginValid();
                dashboard.CheckAndChangeToCheckInTerminal();
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestWithCode("85025", "CBC");
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

                prepareContainers.MoveToPerformCollectionNanotainers();

                var barCodes = nanoPreScan.PreScanNanotainer();
                nanoPreScan.MoveToCollectSamples();
                nanoSample.MoveToScanCollection();
                nanoScan.PostScanNanotainer();
                nanoScan.MoveToFinishWithoutCentrifuge();

                performSummary.Finish();   
            }

            else
            {
                TestContext.WriteLine("This Scenario is skipped since NAnotainer module is disabled");
            }
            

        }

        /// <summary>
        /// To verify user able to collect sample by using the option "Switch to Venous draw" and complete the visit successfully
        /// </summary>
        [TestMethod]
        public void SwitchToVenousDraw()
        {

            if (IsNanotainerEnabled)
            {
                BasicInfoModel guestInfo = new BasicInfoModel();

                login.LaunchApplication();
                login.LoginValid();
                dashboard.CheckAndChangeToCheckInTerminal();
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestWithCode("85025", "CBC");
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

                //  verifyIdentification.VerifyBasicInfo(guestInfo);
                verifyIdentification.ScanPhotoID();
                verifyIdentification.MoveToPrepareContainers();
                prepareContainers.SwitchToVenousDraw();
                prepareContainers.MoveToPerformCollectionVacutainers();

                vacuSample.CollectionComplete();
                vacuPrint.HandleBarcodePrintingError();
                vacuPrint.MoveToScanCollection();
                vacuScan.ScanBarCodes();
                vacuScan.MoveToFinishWithoutCentrifuge();
                performSummary.Finish(); 
            }

            else
            {
                TestContext.WriteLine("This Scenario is skipped since Switching to venous draw is disabled");
            }
           

        }

        /// <summary>
        /// To verify user able to collect sample by using the option "Switch to Fingerstick" and complete the visit successfully
        /// </summary>
        [TestMethod]
        public void SwitchToFingerstick()
        {

            if (IsNanotainerEnabled)
            {
                BasicInfoModel guestInfo = new BasicInfoModel();

                login.LaunchApplication();
                login.LoginValid();
                dashboard.CheckAndChangeToCheckInTerminal();
                dashboard.SearchAndAddByNameDOB();
                addLabOrder.ScanDirectTesting();
                cpt.AddTestWithCode("85025", "CBC");
                cpt.AddTestWithCode("83003", "Growth Hormone");
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

                //  verifyIdentification.VerifyBasicInfo(guestInfo);
                verifyIdentification.ScanPhotoID();
                verifyIdentification.MoveToPrepareContainers();
                prepareContainers.SwitchToFingerStickRemoveTest();
                prepareContainers.MoveToPerformCollectionNanotainers();

                var barCodes = nanoPreScan.PreScanNanotainer();
                nanoPreScan.MoveToCollectSamples();
                nanoSample.MoveToScanCollection();
                nanoScan.PostScanNanotainer(barCodes);
                nanoScan.MoveToFinishWithoutCentrifuge();

                performSummary.Finish();
            }

            else
            {
                TestContext.WriteLine("This Scenario is skipped since Switch to FingerStick is disabled");
            }
            

        }

        [TestMethod]
        public void ScheduledVacutainer()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTestingInvokePattern();
            cpt.AddTestWithCode("82150", "Amylase");
            cpt.AddTestWithCode("T700308", "B cell Total Count");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.VacutainersCheckLabels(2);
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();

        }

        //[TestMethod()]
        //public void TestOrder()
        //{
        //    BasicInfoModel guestInfo = new BasicInfoModel();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();
        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestWithCode("86480", "Gulcose");
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();
        //    guestInfo = basicInfo.AddAndReturnGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();
        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.ConfirmFasting();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.Pay();
        //    payment.BackToDashboard();

        //    dashboard.CheckAndChangeToPerformTerminal();
        //    dashboard.SearchCheckedInGuestNameDOB(guestInfo);

        //    //  verifyIdentification.VerifyBasicInfo(guestInfo);
        //    verifyIdentification.ScanPhotoID();
        //    verifyIdentification.MoveToPrepareContainers();

        //    prepareContainers.MoveToPerformCollectionNanotainers();

        //    var barCodes = nanoPreScan.PreScanNanotainer();
        //    nanoPreScan.MoveToCollectSamples();
        //    nanoSample.MoveToScanCollection();
        //    nanoScan.PostScanNanotainer(barCodes);
        //    nanoScan.MoveToFinishWithoutCentrifuge();

        //    performSummary.Finish();

        //}
    }
}

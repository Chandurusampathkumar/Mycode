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
using Theranos.Automation.PSC3.Models.Features;
using Theranos.Automation.PSC3.TestCases.FeaturesTests;

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios
{
    [TestClass]
    public class AssayMapping:PSC3Model
    {
        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();
        ContainerTests container = new ContainerTests();
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

        /// <summary>
        ///  86480 : Tuberculosis QuantiFERON: Accn#: 8721
        /// </summary>
        [TestMethod()]
        public void AssayMapping01()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86480", "Tuberculosis QuantiFERON");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            ExpectedContainers.Add(PrepareContainers.ContainerQFTGrey);
            ExpectedContainers.Add(PrepareContainers.ContainerQFTRed);
            ExpectedContainers.Add(PrepareContainers.ContainerQFTPurple);
            prepareContainers.VerifyContainers(ExpectedContainers);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();
            
        }


        /// <summary>
        ///   86225 : dsDNA +  T700276: Venous Draw (Gold SST) + Swab :  Accn#: 8747
        /// </summary>
        [TestMethod()]
        public void AssayMapping02()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86225", "dsDNA");
            cpt.AddTestWithCode("T700276", "Chlamydia, Swab Collection");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerSwabKit);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerGoldTop, 1);
            ////expected.Add(PrepareContainers.)
            prepareContainers.VerifyContainers(ExpectedContainers);

            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToOtherContainersWithoutCentrifuge();

            otherPrint.OtherContainersHandleBarcodePrintingError();
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

        /// <summary>
        ///  85013: Hematocrit(HCT) +  85025 CBC +  85004 WBC : Accn#: 8737
        /// </summary>
        [TestMethod()]
        public void AssayMapping03()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("85013", "Hematocrit(HCT) ");
            cpt.AddTestWithCode("85025", "CBC");
            cpt.AddTestWithCode("85004", "WBC");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerNanotainerPurple);                   
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionNanotainers();

            var barCodes = nanoPreScan.PreScanNanotainer();
            nanoPreScan.MoveToCollectSamples();
            nanoSample.MoveToScanCollection();
            nanoScan.PostScanNanotainer(barCodes);
            nanoScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  83880 : BNP : Pearl Tube : Accn#: 8722
        /// </summary>
        [TestMethod()]
        public void AssayMapping04()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("83880", "BNP");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerPearlTop);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            
            performSummary.Finish();

        }

        /// <summary>
        ///  82024 : ACTH  +  T700271 (Chlamydia/Gonorrhea/HIV ): Accn#: 8723
        /// </summary>
        [TestMethod()]
        public void AssayMapping05()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82024", "ACTH");
            cpt.AddTestWithCode("T700271", "(Chlamydia/Gonorrhea/HIV )");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerPearlTop);
            ExpectedContainers.Add(PrepareContainers.ContainerUrineKit);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerGoldTop, 1);
            ////expected.Add(PrepareContainers.)
            //prepareContainers.VerifyContainers(expected);

            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToOtherContainersWithoutCentrifuge();

            otherPrint.OtherContainersHandleBarcodePrintingError();
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

        /// <summary>
        /// 86300 (CA 15-3) + 84481:  FT3: Accn#: 8735
        /// </summary>
        [TestMethod()]
        public void AssayMapping06()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("86300", "CA 15-3");
            cpt.AddTestWithCode("84481", "FT3");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);   
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  82150 : Amylase +  T700299 : HIV 1/2 screen w/ Reflex: Gold + Pearl : Accn#: 8732
        /// </summary>
        [TestMethod()]
        public void AssayMapping07()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82150", "Amylase");
            cpt.AddTestWithCode("T700299", " HIV 1/2 screen w/ Reflex: Gold + Pearl");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerPearlTop);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  84403 ( Testosterone, Total) :Accn#:  8727 
        /// </summary>
        [TestMethod()]
        public void AssayMapping08()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84403", " Testosterone, Total");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///   80178 : Lithium + 86803 ( Hepatitis C (HCV)) : Gold SST : Accn#: 8734
        /// </summary>
        [TestMethod()]
        public void AssayMapping09()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80178", "Lithium");
            cpt.AddTestWithCode("86803", "Hepatitis C (HCV)");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            //Lavender container is removed. Refer: http://srw072ca:8080/tfs/DefaultCollection/Theranos.PSC3/_workItems#id=12990&triage=true&fullScreen=false&_a=edit
            //ExpectedContainers.Add(PrepareContainers.ContainerLavender);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  87522 : Hepatitis C, RNA + 85013 Hematocrit (HCT): Gold + Lavender: Accn#: 8733
        /// </summary>
        [TestMethod()]
        public void AssayMapping10()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("87522", "Hepatitis C, RNA ");
            cpt.AddTestWithCode("85013", "Hematocrit (HCT)");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerLavender);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  84402 : Testosterone, Free : Accn#: 8604 - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping11()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84402", "Testosterone, Free");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerMintTop);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        /// T700271 + T700263:  Chlamydia/Gohorrhea/ HIV screen : Accn#: 8605 - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping12()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700271", " Chlamydia/Gohorrhea/ HIV screen");
            cpt.AddTestWithCode("T700263", "Chlamydia/Gohorrhea panel, DNA, Qualitative");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerPearlTop);
            ExpectedContainers.Add(PrepareContainers.ContainerUrineKit);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToOtherContainersWithoutCentrifuge();

            otherPrint.OtherContainersHandleBarcodePrintingError();
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

        /// <summary>
        ///  85025 : Switch to Venous draw on CheckIn : Accn#: 8749 : - - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping13()
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
            container.ChangePatientCollectionPreference(ContainerModel.Venous);
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            //Refer: http://srw072ca:8080/tfs/DefaultCollection/Theranos.PSC3/_workItems#id=12991&triage=true&fullScreen=false&_a=edit
            ExpectedContainers.Add(PrepareContainers.ContainerLavender);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionNanotainers();

            var barCodes = nanoPreScan.PreScanNanotainer();
            nanoPreScan.MoveToCollectSamples();
            nanoSample.MoveToScanCollection();
            nanoScan.PostScanNanotainer(barCodes);
            nanoScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }


        /// <summary>
        ///  80061  + 82465 Cholesterol + 80069 Renal Function Panel + 82482 Cholinesterase : Gold + Light Green:  Accn#: 8752 - - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping14()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80061", "Liquid Panel");
            cpt.AddTestWithCode("82465", "Cholesterol");
            cpt.AddTestWithCode("80069", "Renal Function Panel");
            cpt.AddTestWithCode("82482", "Cholinesterase");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerMintTop);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  80061 + 85025 + 80048: Switch to Finger Stick for Step # : Light Green Mint + Lavender: Accn#: 8754 -  - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping15()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80061", " Liquid Panel");
            cpt.AddTestWithCode("85025", "CBC");
            cpt.AddTestWithCode("80048", " BMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            container.ChangePatientCollectionPreference(ContainerModel.Fingerstick);
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerMintTop);
            ExpectedContainers.Add(PrepareContainers.ContainerLavender);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();

        }

        /// <summary>
        ///  (80048) BMP + (80053)CMP  + (85025) CBC :  (Check for sodium + potassium + chloride : mapped to 1 CTN purple) : Accn#: 8742 - - Pass
        /// </summary>
        [TestMethod()]
        public void AssayMapping23()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.AddTestWithCode("80053", "CMP");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerNanotainerGreen);
            ExpectedContainers.Add(PrepareContainers.ContainerNanotainerPurple);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionNanotainers();
            var barCodes = nanoPreScan.PreScanNanotainer();
            nanoPreScan.MoveToCollectSamples();
            nanoSample.MoveToScanCollection();
            nanoScan.PostScanNanotainer(barCodes);
            nanoScan.MoveToFinishWithoutCentrifuge();
            
            performSummary.Finish();


        }


        /// <summary>
        /// (80048) BMP + (80053)CMP + (80055)Obstetric Panel : Accn#: 8744
        /// </summary>
        [TestMethod()]
        public void AssayMapping24()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("80055", "Obstetric Panel");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerMintTop);
            ExpectedContainers.Add(PrepareContainers.ContainerLavender);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();

            performSummary.Finish();


        }


        /// <summary>
        /// 87046 : Stool Culture(Salmonella, Shigella, Campylabacter, E.Coli 0157) + T700263 :Chlamydia/Gonorrhea DNA + 82436 : Chloride, Urine + 83525: Insulin + T700273: TSH
        /// </summary>
        [TestMethod()]
        public void AssayMapping25()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.AddTestWithCode("T700263", "Chlamydia/Gonorrhea DNA");
            cpt.AddTestWithCode("82436", "Chloride, Urine");
            cpt.AddTestWithCode("83525", "Insulin");
            cpt.AddTestWithCode("T700273", "TSH");
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

            Thread.Sleep(3000);
            TakeScreenShot();
            HashSet<string> ExpectedContainers = new HashSet<string>();
            ExpectedContainers.Add(PrepareContainers.ContainerGoldTop);
            ExpectedContainers.Add(PrepareContainers.ContainerStoolCollectionKitB);
            ExpectedContainers.Add(PrepareContainers.Container24HourUrineKit);
            ExpectedContainers.Add(PrepareContainers.ContainerUrineKit);
            prepareContainers.VerifyContainers(ExpectedContainers);
            //Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add(PrepareContainers.ContainerLightBlueTop, 1);
            //prepareContainers.VerifyContainers(expected);
            prepareContainers.MoveToPerformCollectionVacutainers();

            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToOtherContainersWithoutCentrifuge();

            otherPrint.OtherContainersHandleBarcodePrintingError();
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


    }
}

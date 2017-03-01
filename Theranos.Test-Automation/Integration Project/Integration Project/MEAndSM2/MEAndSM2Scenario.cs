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
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.MeWeb;


namespace Integration_Project.MEAndSM2
{
    [TestClass]
    public class MEAndSM2Scenario:IntegrationModel
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
        CreateAccountPage account = new CreateAccountPage();
        YopActivation activate = new YopActivation();
        LoginValidation meLogin = new LoginValidation();
        DashBoardOrder dashboardOrder = new DashBoardOrder();
        UploadOrders upload = new UploadOrders();

        [TestMethod]
        public void MEAndSM2ClinicianTesting()
        {
            LaunchActivity.launchapp();
            account.CreateAccount(LaunchActivity.driver);
            activate.ActivateYopmail();
            LaunchActivity.launchapp();
            var userInfo=meLogin.LoginSignUpUserProvisional(LaunchActivity.driver);
            dashboardOrder.DashBoardOrders(LaunchActivity.driver);
            upload.CaptureImage(LaunchActivity.driver);
            upload.CheckUploadOrderCreated(LaunchActivity.driver);


            sm2login.LaunchApplicationSM2();
            var dob=labOrder.CheckUserUploadGuestName(userInfo);
            var orderDetails = labOrder.LabOrderSubmit();
            labOrder.SM2LogOut();


            login.LaunchApplication();
            dashboard.SearchAndSelectMEGuestByNameAndDOB(userInfo,dob);
            addLabOrder.ClickNextButton();
            basicInfo.EnterPhoneNumber();
            basicInfo.EnterEmailForME(userInfo);
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.OrderDetailsFromSM2(orderDetails);
            var orderType = confirmOrders.IsDirectTesting();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchAndSelectMEGuestByNameAndDOBInPerform(userInfo,dob);

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
            Accession.FinishLabOrderForMEInLisScenario(orderType, userInfo);
        }

        [TestMethod]
        public void MEAndSM2DirectTesting()
        {
            LaunchActivity.launchapp();
            account.CreateAccount(LaunchActivity.driver);
            activate.ActivateYopmail();
            LaunchActivity.launchapp();
            var userInfo = meLogin.LoginSignUpUserProvisional(LaunchActivity.driver);
            dashboardOrder.DashBoardOrders(LaunchActivity.driver);
            var code=dashboardOrder.AddParticularCptTest(LaunchActivity.driver,"82340");
            dashboardOrder.TestMenuPageAddTest(LaunchActivity.driver);
            dashboardOrder.TestMenuProvisionAccout(LaunchActivity.driver);
            dashboardOrder.CreateOrderFromOrders(LaunchActivity.driver);
            dashboardOrder.ActiveOrders(LaunchActivity.driver);
            meLogin.LogOut(LaunchActivity.driver);

            login.LaunchApplication();
            //dashboard.SearchAndSelectMEGuestByNameAndDOB(userInfo, dob);
            addLabOrder.ClickNextButton();
            basicInfo.EnterPhoneNumber();
            basicInfo.EnterEmailForME(userInfo);
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckForOrderDetailsFromME(code);
            var orderType = confirmOrders.IsDirectTesting();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            //dashboard.SearchAndSelectMEGuestByNameAndDOBInPerform(userInfo, dob);

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
            Accession.FinishLabOrderForMEInLisScenario(orderType, userInfo);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack.Utility;
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

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios.TrainingScenario
{
    [TestClass]
    public class EditVisitScenario:PSC3Model
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


        //CTC-79:The system must allow patient information to be edited.
        [TestMethod]
        public void EditVisit01()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            confirmOrders.RemoveOrder(2);
            confirmOrders.RemoveOrder(3);
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();

            dashboard.SearchGuestInPerformRoomWaiting(guestInfo);
            payment.EditVisit();
            checkIn.MoveToGuestInfo();

            BasicInfoModel originalGuestInfo = guestInfo;
            guestInfo.FirstName = guestInfo.FirstName + "EditA";
            guestInfo.LastName = guestInfo.LastName + "EditA";
            guestInfo.MI = "A";
            guestInfo.PhoneNo = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();
            guestInfo.DOB = "'01021990";
            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestDetails(guestInfo);
            basicInfo.BackToAddLabOrder();

            addLabOrder.DeleteLabOrder(1);
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.SelectAllOrders();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.Pay();
            payment.BackToDashboard();

            dashboard.SearchGuestInPerformRoomWaiting(guestInfo);
            payment.EditVisit();
            checkIn.MoveToGuestInfo();

            guestInfo.FirstName = guestInfo.FirstName.Replace("EditA", "EditB");
            guestInfo.LastName = guestInfo.LastName.Replace("EditA", "EditB");
            guestInfo.MI = guestInfo.MI.Replace("A", "B");
            guestInfo.PhoneNo = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();
            guestInfo.DOB = guestInfo.DOB.Replace("'01021990", "'01031991");
            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestDetails(guestInfo);

            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ClickNextButton();
            summary.PayAfterEdit();
            payment.BackToDashboard();

        }

        [TestMethod]
        public void EditVisit02()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84443", "TSH");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
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


            BasicInfoModel originalGuestInfo = guestInfo;
            guestInfo.FirstName = guestInfo.FirstName + "EditA";
            guestInfo.LastName = guestInfo.LastName + "EditA";
            guestInfo.MI = "A";
            guestInfo.DOB = "'01021990";
            verifyIdentification.AddGuestInfo(guestInfo);
            verifyIdentification.VerifyGuestDetails(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.BackToVerifyIdentification();

            guestInfo.FirstName = guestInfo.FirstName.Replace("EditA", "EditB");
            guestInfo.LastName = guestInfo.LastName.Replace("EditA", "EditB");
            guestInfo.MI = guestInfo.MI.Replace("A", "B");            
            guestInfo.DOB = guestInfo.DOB.Replace("'01021990", "'01031991");
            verifyIdentification.AddGuestInfo(guestInfo);
            verifyIdentification.VerifyGuestDetails(guestInfo);

            verifyIdentification.MoveToPrepareContainers();
            prepareContainers.MoveToPerformCollectionVacutainers();
            vacuSample.CollectionComplete();
            vacuPrint.HandleBarcodePrintingError();
            vacuPrint.MoveToScanCollection();
            vacuScan.ScanBarCodes();
            vacuScan.MoveToFinishWithoutCentrifuge();
            performSummary.Finish();


        }


        [TestMethod]
        public void EditVisit03()
        {
            //BasicInfoModel guestInfo = new BasicInfoModel();

            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84443", "TSH");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            checkIn.NavigateToDashboard();
            dashboard.MoveToCheckInDetailsGuestInfo(guestInfo);

            BasicInfoModel originalGuestInfo = guestInfo;
            guestInfo.FirstName = guestInfo.FirstName + "EditA";
            guestInfo.LastName = guestInfo.LastName + "EditA";
            guestInfo.MI = "A";
            guestInfo.PhoneNo = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();
            guestInfo.DOB = "'01021990";


            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestDetails(guestInfo);
            basicInfo.BackToAddLabOrder();

            addLabOrder.AddNewOrder();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            guestInfo.FirstName = guestInfo.FirstName.Replace("EditA", "EditB");
            guestInfo.LastName = guestInfo.LastName.Replace("EditA", "EditB");
            guestInfo.MI = guestInfo.MI.Replace("A", "B");
            guestInfo.PhoneNo = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();
            guestInfo.DOB = guestInfo.DOB.Replace("'01021990", "'01031991");
            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestDetails(guestInfo);
            basicInfo.BackToAddLabOrder();
            addLabOrder.DeleteLabOrder(3);

            addLabOrder.ClickNextButton();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
        }


        [TestMethod]
        public void EditVisit04()
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

            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();

            dashboard.CheckAndChangeToPerformTerminal();
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);


            BasicInfoModel originalGuestInfo = guestInfo;
            guestInfo.FirstName = guestInfo.FirstName + "EditA";
            guestInfo.LastName = guestInfo.LastName + "EditA";
            guestInfo.MI = "A";
            verifyIdentification.AddGuestName(guestInfo);
            verifyIdentification.VerifyGuestName(guestInfo);
            checkIn.NavigateToDashboard();

            dashboard.MoveToPerformDetailsGuestInfo(guestInfo);
            guestInfo.DOB = "'01021990";
            verifyIdentification.AddGuestDOB(guestInfo);
            verifyIdentification.VerifyGuestDOB(guestInfo);

            verifyIdentification.ScanPhotoID();
            verifyIdentification.MoveToPrepareContainers();

            prepareContainers.MoveToPerformCollectionOtherContainers();
            otherPrint.OtherContainersHandleBarcodePrintingError();
            otherPrint.OtherContainersMoveToScanCollection();
            checkIn.NavigateToDashboard();

            dashboard.MoveToPerformDetailsScanCollection(guestInfo);
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

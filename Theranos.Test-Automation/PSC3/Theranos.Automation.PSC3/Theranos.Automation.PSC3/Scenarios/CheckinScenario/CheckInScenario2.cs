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

namespace Theranos.Automation.PSC3.Scenarios.CheckinScenario
{
    [TestClass]
    public class CheckInScenario2:PSC3Model
    {
        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();

        CheckInTests checkIn = new CheckInTests();

        AddLabOrderTests addLabOrder = new AddLabOrderTests();
        ClinicianTests clinician = new ClinicianTests();
        CPTTests cpt = new CPTTests();
        ICDTests icd = new ICDTests();
        ICD10Tests icd10 = new ICD10Tests();
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

       //CTC-42
        [TestMethod()]
        public void CancelOrderScenario()
        {
            login.LaunchApplication();
            login.LoginInvalidCredentials();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanAndCancelSendForTranscriptionOrder();   //CTC-96


            addLabOrder.ScanSendForTranscription();
            addLabOrder.AddNewOrder();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            addLabOrder.CancelOrder();
            addLabOrder.AddNewOrder();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            addLabOrder.CancelOrder();

        }

        [TestMethod()]
        public void CancelVisitScenario()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsName();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();
            cpt.AddTestByName();
            cpt.AddTestByName();
            icd.AddICDByCode();
            icd.AddICDByCode();
            icd.AddICDByName();         //CTC-54
            icd10.AddICD10ByCode();
            icd10.ADDICD10ByName();
            icd.RemoveICD();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            checkIn.CancelVisit();              //  CTC:59
            login.Logout();
        }

        //[TestMethod()]
        //public void ClinicianTestingScenario()
        //{
        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingEightHours();
        //    orderInstructions.StandingOrderDay();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingTenHours();
        //    orderInstructions.StandingOrderWeek();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingTwelveHours();
        //    orderInstructions.StandingOrderMonth();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingUnspecifiedHours();
        //    orderInstructions.StandingOrderDay();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingEightHours();            
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingTenHours();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingTwelveHours();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.FastingUnspecifiedHours();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();            
        //    orderInstructions.StandingOrderDay();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.StandingOrderWeek();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    orderInstructions.StandingOrderMonth();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();

        //    basicInfo.AddGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddGuardianContact();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();

        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.FastingYesIfAvailable();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();
        //    login.Logout();
        //}

        //[TestMethod()]
        //public void Dashboard()
        //{
        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchButtonMandatory();
        //    dashboard.SearchNewByNameDOB();
        //    login.Logout();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.SearchNewByPhoneNo();
        //    login.Logout();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.SearchExistingByNameDOB();
        //    login.Logout();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.SearchExistingByPhoneNo();
        //    login.Logout();

        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.PrintForms();
        //    dashboard.CancelVisit();
        //    login.Logout();
        //}
        //  CTC-43: clinician name,provider,and order instructions section should be entered successfully
        [TestMethod()]
        public void DeleteOrderScenario()
        {
            login.LaunchApplication();
            login.LoginInvalidCredentials();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanSendForTranscription();
            addLabOrder.AddNewOrder();
            
            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            icd.AddICDByCode();
            cpt.SaveDetails();

            addLabOrder.DeleteOrder();
            addLabOrder.DeleteOrder();
            addLabOrder.DeleteOrder();
        }

        //[TestMethod()]
        //public void DirectTestingScenario()
        //{
        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();

        //    basicInfo.AddGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddGuardianContact();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();

        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.FastingYesIfAvailable();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();
        //    login.Logout();
        //}
        

        [TestMethod]
        public void DeleteOrderScenario01()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();               
            clinician.ClinicianDetailsName();                       
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            basicInfo.BackToAddLabOrder();
            addLabOrder.DeleteOrder();              //CTC-137                

            addLabOrder.ScanDirectTesting();                
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            basicInfo.BackToAddLabOrder();
            addLabOrder.DeleteOrder();              //CTC-138

            addLabOrder.ScanClinicianOrder();



           
        }



        
        [TestMethod()]
        public void LanguageScenario()
        {
            login.LaunchApplication();
            login.ChangeLanguageToSpanishAndLogin();
            login.LaunchApplication();
            login.ChangeLanguageToEnglishAndLogin();
            login.LaunchApplication();
            login.ChangeLanguageToSpanishAndRestart();
            login.LaunchApplication();
            login.ChangeLanguageToEnglishAndRestart();
        }

        //CTC:01, CTC:02, CTC:03, CTC:04, CTC-08, CTC-09
        [TestMethod()]
        public void LoginTestsScenario()
        {
            login.LaunchApplication();
            login.LoginInvalidUserName();
            login.LaunchApplication();
            login.LoginInvalidPassword();
            login.LaunchApplication();
            login.LoginValid();
            login.Logout();
            login.LaunchApplication();
            login.UserNameRequired();
            login.LaunchApplication();
            login.PasswordRequired();
        }

        //[TestMethod()]
        //public void OrdersScenario()
        //{
        //    login.LaunchApplication();
        //    login.LoginValid();
        //    dashboard.CheckAndChangeToCheckInTerminal();
        //    dashboard.SearchAndAddByNameDOB();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByCode();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanDirectTesting();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.AddNewOrder();

        //    addLabOrder.ScanClinicianOrder();
        //    clinician.ClinicianDetailsName();
        //    clinician.MoveToTestPage();
        //    cpt.AddTestByName();
        //    cpt.SaveDetails();
        //    addLabOrder.ClickNextButton();

        //    basicInfo.AddGuestInfo();
        //    address.AddMailingAddress();
        //    address.AddBillingAddress();
        //    contact.AddGuardianContact();
        //    contact.AddEmergencyContact();
        //    basicInfo.VerifyGuestID();

        //    guestForms.ConfirmGuestSign();
        //    confirmOrders.FastingYesIfAvailable();
        //    confirmOrders.CheckInformCollectMethod();
        //    summary.PrintAndPay();
        //    payment.BackToDashboard();
        //    login.Logout();
        //}

        [TestMethod]
        public void EmergencyContactMandatory()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTestingAndNavigateToDashboard();          //CTC-139

            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();          
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();         
            confirmOrders.CheckEmergencyContact();
            contact.AddEmergencyContact();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ClickNextButton();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DoNotCollectBlood()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82570", "Creatinine,Urine");
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.AddTestWithCode("83655", "Lead");
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.SelectDoNotcollectBlood();
            checkIn.CancelVisit();
        }

       
    }
}

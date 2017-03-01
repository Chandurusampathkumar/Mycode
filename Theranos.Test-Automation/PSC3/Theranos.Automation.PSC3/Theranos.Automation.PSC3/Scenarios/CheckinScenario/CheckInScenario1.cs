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

namespace Theranos.Automation.PSC3.Scenarios.CheckinScenario
{
    [TestClass]
    public class CheckInScenario1:PSC3Model
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

        
        //This scenario does not refer any testcase as it is to update the App.config file and TestSettings file with current application Path and buildversion
        [TestMethod()]
        public void GeneralScenario()
        {
            login.LaunchApplication();
            login.GetAppCurPath();
            login.GetAppCurBuildVer();
            login.Logout();
        }


        [TestMethod()]
        public void CheckInScenario01()
        {
            login.LaunchApplication();

            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
        
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsName();
            orderInstructions.StandingOrderUnknown();       //CTC-57
            orderInstructions.RandomOrderInstructions();   //CTC-56
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();      //CTC-52
            cpt.AddTestByName();
            cpt.AddTestByName();
            icd.AddICDByCode();         //CTC-53
            icd.AddICDByCode();
            icd.AddICDByCode();
            icd.RemoveICD();            //CTC-55
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();       //CTC-93
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            contact.DeleteContact();
            contact.AddGuardianContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            dashboard.CheckGuestInPerformRoomWaiting(guestInfo);            //CTC-75
            login.Logout();
        }

        [TestMethod()]
        public void CheckInScenario02()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByPhoneNo();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();
            cpt.AddTestByName();
            cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            contact.DeleteContact();
            contact.AddGuardianContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod()]
        public void CheckInScenario03A()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByPhoneNo();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            //cpt.AddTestByCode();
            //cpt.RemoveTests();
            //cpt.AddTestByName();
            //cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            //insurance.AddInsuranceOther();
            ////insurance.EditInsurance();
            //insurance.DeleteInsurance();
            insurance.AddInsurancePrimary();

            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            //contact.DeleteContact();
            //contact.AddGuardianContact();
            basicInfo.VerifyGuestID();

            guestForms.PrintPrivacyPracticeForm();          //CTC-71
            guestForms.ConfirmGuestSign();                    //CTC-72
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintPaymentSummary();
            summary.PrintAndPay();
            payment.CancelRefund();                 //TC-214;  CTC-78
            login.Logout();
        }


        
        [TestMethod()]
        public void CheckInScenario03B()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByPhoneNo();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();
            cpt.AddTestByName();
            cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            insurance.AddInsuranceOther();
            //insurance.EditInsurance();
            insurance.DeleteInsurance();
            insurance.AddInsurancePrimary();

            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            contact.DeleteContact();
            contact.AddGuardianContact();
            basicInfo.VerifyGuestID();

            guestForms.PrintPrivacyPracticeForm();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintPaymentSummary();      //CTC-81
            summary.PrintAndPay();
            payment.FullRefund();               //CTC-76
            login.Logout();
        }

        [TestMethod()]
        public void CheckInScenario04()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsName();
            orderInstructions.RandomOrderInstructions();        //CTC-100
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();
            cpt.AddTestByName();
            cpt.AddTestByName();
            icd.AddICDByCode();
            icd.AddICDByCode();
            icd.AddICDByCode();
            icd.RemoveICD();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            contact.DeleteContact();
            contact.AddGuardianContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.OrderReview();                //CTC-60
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();            
            summary.PrintAndPay();
            payment.EditVisit();
            checkIn.NavigateToDashboard();
            login.Logout();
        }
        //CTC-44; CTC-48
        [TestMethod()]
        public void CheckInScenario05()
        {
            login.LaunchApplication();
            login.LoginInvalidCredentials();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.AddTestByName();
            addLabOrder.SumbitForTranscription();
            addLabOrder.AddNewOrder();
            addLabOrder.ScanSendForTranscription();
            addLabOrder.AddNewOrder();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();          //CTC-48
            clinician.MoveToTestPage();
            addLabOrder.SumbitForTranscription();    //CTC-44
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.RemoveOrder();
            checkIn.NavigateToDashboard();
            login.Logout();
        }
        //CTC-47
        [TestMethod()]
        public void CheckInScenario06()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.CPTTestMandatory();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailMandatory();
            clinician.ClinicianDetailsName(); clinician.MoveToTestPage();       //CTC-47
            cpt.CPTTestMandatory();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.BasicInfoMandatory();
            basicInfo.AddGuestInfo();
            basicInfo.NextButtonMandatory();
            address.AddMailingAddress();
            basicInfo.NextButtonMandatory();
            address.AddBillingAddress();
            basicInfo.NextButtonMandatory();
            contact.AddGuardianContact();
            basicInfo.NextButtonMandatory();
            contact.AddEmergencyContact();
            basicInfo.NextButtonMandatory();
            //contact.EditContact();
            basicInfo.VerifyGuestID();

            guestForms.GuestFormMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.ConfirmOrdersMandatory();
            confirmOrders.DeleteOrder();                    //CTC-62
            confirmOrders.RemoveTest();                     //CTC-61
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();       //CTC-63
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }
        
        [TestMethod()]
        public void CheckInScenario07()
        {
            login.LaunchApplication();
            login.LoginInvalidCredentials();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPIWithFavourites();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.AddTestByFavourites();      //CTC-51
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
        }

        [TestMethod()]
        public void CheckInScenario08()
        {
            login.LaunchApplication();
            login.LoginInvalidCredentials();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddGuardianContact();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod()]
        public void CheckInScenario09()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.AddTestByCode();
            cpt.RemoveTests();
            cpt.AddTestByName();        //CTC-50
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();            
            contact.AddEmergencyContact();
            basicInfo.CheckVerifyGuestIDCheckBox();
            
            checkIn.NavigateToDashboard();
            dashboard.CheckGuestForPleaseCompleteCheckIn(guestInfo);     //CTC-140
            
            basicInfo.ClickNextButton();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYes();
            confirmOrders.ClickCheckInformCollectMethod();
            checkIn.NavigateToDashboard();
            dashboard.CheckGuestForOrdersReady(guestInfo);              //CTC-141

            confirmOrders.ClickNextButton();
            summary.PrintAndPay();
            payment.clickFullRefund();
            checkIn.NavigateToDashboard();
            dashboard.CheckGuestForProcessRefund(guestInfo);            //CTC-142

            checkIn.MoveToAddLabOrder();
            checkIn.NavigateToDashboard();
        }

        [TestMethod]
        public void CheckInScenarioTemp()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            guestInfo.FirstName += "EditA";
            basicInfo.AddGuestInfo(guestInfo);
           
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();

        }
    }
}

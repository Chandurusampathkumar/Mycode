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

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios
{
    [TestClass]
    public class TrainingScenario1 : PSC3Model
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

        [TestMethod]
        public void InsuranceToSelfPay1()
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
            insurance.AddInsurancePrimary();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();
            summary.PrintAndPayInsurance();
            payment.EditVisit();

            summary.SelfPay();
            summary.Pay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void InsuranceToSelfPay2()
        {
            BasicInfoModel guestInfo = new BasicInfoModel();

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

            guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            insurance.AddInsurancePrimary();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();
            summary.PrintAndPayInsurance();
            payment.BackToDashboard();

            dashboard.SearchGuestInPerformRoomWaiting(guestInfo);
            payment.EditVisit();
            summary.SelfPay();
            summary.Pay();
            payment.BackToDashboard();
            login.Logout();
        }

        //CTC-86: If plan is Medicare A and B or any plan with "Medicare" in name, Payment Summary , ABN pop-up should be displayed.
        //CTC-87: If plan is Medicare A and B or any plan with "Medicare" in name, Payment Summary , ABN pop-up should be displayed and able to scan the form.
        [TestMethod]
        public void ABNInsurance()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsName();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            insurance.AddABNInsurance(InsuranceModel.MedicareAandB);  //CTC-86
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();                        //CTC-86
            summary.PrintAndPayABNInsurance();        //CTC-86  
            payment.BackToDashboard();
      
        }
    }
}

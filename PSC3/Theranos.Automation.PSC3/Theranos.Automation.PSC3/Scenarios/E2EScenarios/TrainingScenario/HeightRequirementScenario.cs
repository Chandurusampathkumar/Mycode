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

namespace Theranos.Automation.PSC3.Scenarios.E2EScenarios.TrainingScenario
{
    [TestClass]
    public class HeightRequirementScenario:PSC3Model
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
        public void DirectHeightRequirementScenario1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectHeightRequirementScenario2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectHeightRequirementScenario3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82565", "Creatinine");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectHeightRequirementScenario4()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80069", "Renal Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianHeightRequirementScenario1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.SaveDetails();            
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianHeightRequirementScenario2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianHeightRequirementScenario3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82565", "Creatinine");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianHeightRequirementScenario4()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80069", "Renal Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo=basicInfo.AddAndReturnGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckAndSetHeightRequirement();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        //CTC-105: For other tests, regardless of patient age, height requirement shall never pop up--> Direct order
        [TestMethod]
        public void DirectHeightRequirementNotDisplayed01()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestByCode();                //add any test other than 80048, 80053, 80069, 82565
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfoAgeLessThan18();  //set patient age under 18
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckHeightRequirementIsNotDisplayed();  //check height requirement not displayed
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        //CTC-106: For other tests, regardless of patient age, height requirement shall never pop up --> clinician order

        [TestMethod]
        public void ClinicianHeightRequirementNotDisplayed01()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.AddTestByCode();            //add any test other than 80048, 80053, 80069, 82565
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfoAgeLessThan18();         //set patient age under 18
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckHeightRequirementIsNotDisplayed();            //check height requirement not displayed
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectHeightRequirementNotDisplayed02()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");        //CTC-101
            cpt.AddTestWithCode("80053", "CMP");        //CTC-102
            cpt.AddTestWithCode("82565", "Creatinine");     //CTC-103
            cpt.AddTestWithCode("80069", "Renal Panel");    //CTC-104
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();              //CTC-101: Add patient with age above 18
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckHeightRequirementIsNotDisplayed();      //CTC-101, CTC-102, CTC103, CTC104: Height requirement not displayed with age above 18
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianHeightRequirementNotDisplayed02()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("82565", "Creatinine");
            cpt.AddTestWithCode("80069", "Renal Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckHeightRequirementIsNotDisplayed();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }
    }
}

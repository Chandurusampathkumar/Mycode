using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.Models.Features;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.TestCases.FeaturesTests;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.TestCases;

namespace Theranos.Automation.PSC3.Scenarios.CheckinScenario
{

    //CTC-89: To verify Fasting Requirement hours should be displayed under active lab order section for respective panels
    [TestClass]
    public class FastingRequirement:PSC3Model
    {
        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();
        CheckInTests checkIn = new CheckInTests();
        AddLabOrderTests addLabOrder = new AddLabOrderTests();
        ClinicianTests clinician = new ClinicianTests();
        OrderInstructionsTests orderInstructions = new OrderInstructionsTests();
        CPTTests cpt = new CPTTests();   
      
        AddressTests address = new AddressTests();
        BasicInfoTests basicInfo = new BasicInfoTests();
        ContactTests contact = new ContactTests();

        GuestFormsTests guestForms = new GuestFormsTests();
        ConfirmOrdersTests confirmOrders = new ConfirmOrdersTests();
        PaymentTests payment = new PaymentTests();
        SummaryTests summary = new SummaryTests();

        [TestMethod]
        public void DirectCMP()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80053","CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();            
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-108
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();           
        }

        [TestMethod]
        public void DirectBMP()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-89; CTC-109
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();     
        }

        [TestMethod]
        public void DirectRenal()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80069", "Renal Function");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-110
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectGlucose()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Glucose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-111
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectBasicHealth()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700320", "BasicHealth Starter");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-112
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectBasicHealthForWomen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700321", "BasicHealth for women");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-113
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectBasicHealthForMen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700322", "BasicHealth for men");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-114
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectDiabetes()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700324", "Diabetes Assessment");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-115
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectGTT3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700254", "GTT3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-116
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            //confirmOrders.CheckInformCollectMethod();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectGTT2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-117
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            //confirmOrders.CheckInformCollectMethod();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectTriGlycerides()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84478", "TriGlycerides");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-118
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void DirectLiquidPanel()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("80061", "LiquidPanel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-89;  //CTC-119
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }


        [TestMethod]
        public void ClinicianCMP()
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

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingInstruction();
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();                    //CTC-89; CTC-120
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianBMP()
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

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingInstruction();
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-121
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianRenal()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80069", "Renal Function");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingInstruction();
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-89; CTC-122
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianGlucose()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82947", "Glucose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-123
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianBasicHealth()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700320", "BasicHealth Starter");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-124
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianBasicHealthForWomen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700321", "BasicHealth for women");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-125
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicainBasicHealthForMen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700322", "BasicHealth for men");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();        //CTC-126
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CliniciantDiabetes()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700324", "Diabetes Assessment");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-127
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianGTT3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700254", "GTT3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-128
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            //confirmOrders.CheckInformCollectMethod();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianGTT2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-129
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            //confirmOrders.CheckInformCollectMethod();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicainTriGlycerides()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84478", "TriGlycerides");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();   //CTC-130
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void ClinicianLiquidPanel()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80061", "LiquidPanel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.CheckFastingInstruction();        //CTC-65
            confirmOrders.ChkForDefaultFastingHrsInActiveOdrs();            //CTC-131
            confirmOrders.CheckFastingRequirementIsDisplayed();     //CTC-65
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianCMP()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();           //CTC-99
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianBMP()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80048", "BMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicanRenal()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80069", "Renal Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianGlucose()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82947", "Glucose");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianBasicHealth()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700320", "Basic Health Starter");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianBasicHealthForWomen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700321", "Basic Health for women");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianBasicHealthForMen()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700322", "Basic Health for men");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianGTT3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700254", "GTT3");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianGTT2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianTriglycerides()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84478", "Triglycerides");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void CustomClinicianLiquidPanel()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80061", "Liquid Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsDisplayed();
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void OrderLevelFasting1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("83003", "Growth Hormone");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();            
            confirmOrders.FastingYes();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void OrderLevelFasting2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82150", "Amylase");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingHoursNotSure();
            checkIn.CancelVisit();
            login.Logout();

        }

        [TestMethod]
        public void OrderLevelFasting3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80178", "Lithium");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingHoursNotSure();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void OrderLevelFasting4()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("83525", "Insulin");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingHoursNo();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void OrdeLevelFasting5()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.RandomCustomFastingHours();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("84403", "Testosterone, Total");
            cpt.SaveDetails();
            addLabOrder.AddNewOrder();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("84402", "Testosterone, Free");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.RemoveOrder(1);
            confirmOrders.FastingHoursNotSure();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
            login.Logout();
        }
    }
}

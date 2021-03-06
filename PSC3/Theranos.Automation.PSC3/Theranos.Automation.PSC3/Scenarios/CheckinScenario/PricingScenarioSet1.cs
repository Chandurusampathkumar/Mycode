﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using Theranos.Automation.PSC3.Models.CheckIn;

namespace Theranos.Automation.PSC3.Scenarios.CheckinScenario
{
    [TestClass]
    public class PricingScenarioSet1 : PSC3Model
    {
        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();
        AddLabOrderTests labOrder = new AddLabOrderTests();
        ClinicianTests clinician = new ClinicianTests();
        OrderInstructionsTests instructions = new OrderInstructionsTests();
        CPTTests cpt = new CPTTests();
        ICDTests icd = new ICDTests();
        BasicInfoTests basicInfo = new BasicInfoTests();
        AddressTests address = new AddressTests();
        ContactTests contact = new ContactTests();
        GuestFormsTests guestForms = new GuestFormsTests();
        ConfirmOrdersTests confirmOrders = new ConfirmOrdersTests();
        SummaryTests summary = new SummaryTests();
        PaymentTests payment = new PaymentTests();

       
        [TestMethod]
        public void PricingSet1Visit1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            labOrder.ScanDirectTesting();        
            cpt.AddTestWithCode("87491", "Chlamydia");
            cpt.AddTestWithCode("87591", "Gonorrhea");
            cpt.AddTestWithCode("87340", "HB s Antigen");
            cpt.AddTestWithCode("86696", "Herpes Simplex 2");
            cpt.AddTestWithCode("86803", "HCV Ab");
            cpt.AddTestWithCode("86780", "Syphilis");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanDirectTesting();    
            cpt.AddTestWithCode("T700266", "Obstetric Panel + HIV");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            TakeScreenShot();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();           
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.CheckPricing("109.26");            
        }

        [TestMethod]
        public void PricingSet1Visit2()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            labOrder.ScanDirectTesting();    
            cpt.AddTestWithCode("86695", "Herpes Simplex 1");
            cpt.AddTestWithCode("87389", "HIV1/2");
            cpt.AddTestWithCode("86696", "Herpes Simplex 2");
            cpt.AddTestWithCode("86780", "Syphilis");
            cpt.AddTestWithCode("85025", "CBC w Auto Diff");            
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanDirectTesting();    
            cpt.AddTestWithCode("T700266", "Obstetric Panel + HIV");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanDirectTesting();    
            cpt.AddTestWithCode("87491", "Chlamydia");
            cpt.AddTestWithCode("87591", "Gonorrhea");
            cpt.AddTestWithCode("87340", "HB s Antigen");
            cpt.AddTestWithCode("86696", "Herpes Simplex 2");
            cpt.AddTestWithCode("86803", "HCV Ab");
            cpt.AddTestWithCode("86780", "Syphilis");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            TakeScreenShot();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.CheckPricing("90.02");
        }

        [TestMethod]
        public void PricingSet1Visit3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            labOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1063413177","John C Lincoln");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("86695", "Herpes Simplex 1");
            cpt.AddTestWithCode("87389", "HIV1/2");
            cpt.AddTestWithCode("86696", "Herpes Simplex 2");
            cpt.AddTestWithCode("86780", "Syphilis");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1417195868","Desert View Family Medicine");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("86317", "Rubella");
            cpt.AddTestWithCode("87340", "HB s Antigen");
            cpt.AddTestWithCode("85025", "CBC w Auto Diff");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1972707594", "Vitality Med Spa");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700266" , "Obstetric Panel + HIV");            
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1972707594", "Vitality Med Spa");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("85027", "CBC");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.AddNewOrder();

            labOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1396723243","Park Nicollet");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("87491", "Chlamydia");
            cpt.AddTestWithCode("87591", "Gonorrhea");
            cpt.AddTestWithCode("87340", "HB s Antigen");
            cpt.AddTestWithCode("86696", "Herpes Simplex 2");
            cpt.AddTestWithCode("86803", "HCV Ab");
            cpt.AddTestWithCode("86780", "Syphilis");
            cpt.SaveDetails();
            TakeScreenShot();
            labOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            TakeScreenShot();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.CheckPricing("148.5");
        }
              
    }
}

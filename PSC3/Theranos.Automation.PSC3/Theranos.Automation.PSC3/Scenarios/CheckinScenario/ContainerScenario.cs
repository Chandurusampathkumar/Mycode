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
    [TestClass]
    public class ContainerScenario : PSC3Model
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
        public void ContainerScenario1()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055" ,"Obstetric Panel");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

        }

        [TestMethod]
        public void ContainerScenario2()
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

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Fingerstick);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario3()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario4()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Swab);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario5()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoMale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario6()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Stool);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario7()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055", "Obstetric Panel");
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario8()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055", "Obstetric Panel");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario9()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Fingerstick);
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario10()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Swab);
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContianerScenario11()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Stool);
            expectedContainers.Add(ContainerModel.Urine);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario12()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055", "Obstetric Panel");
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            expectedContainers.Add(ContainerModel.Swab);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario13()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Fingerstick);
            expectedContainers.Add(ContainerModel.Swab);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario14()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Stool);
            expectedContainers.Add(ContainerModel.Swab);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario15()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055", "Obstetric Panel");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            expectedContainers.Add(ContainerModel.Stool);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario16()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Fingerstick);
            expectedContainers.Add(ContainerModel.Stool);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario17()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80055", "Obstetric Panel");
            cpt.AddTestWithCode("80053", "CMP");
            cpt.AddTestWithCode("81001", "Urinalysis");
            cpt.AddTestWithCode("T700276", "Chlamydia/Gonorrhea");
            cpt.AddTestWithCode("87046", "Stool Culture");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoFemale();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            expectedContainers.Add(ContainerModel.Urine);
            expectedContainers.Add(ContainerModel.Swab);
            expectedContainers.Add(ContainerModel.Stool);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario18()
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

            confirmOrders.ChangePatientCollectionPreference(ContainerModel.Venous);
            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario19()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            var randomPhysician = UtilityClass.GetRandomNumber(0, 1);
            if (randomPhysician == 0)
            {
                clinician.ClinicianDetailsWithNPI(ContainerModel.PhysicianWithVenousPreference1);
            }
            else
            {
                clinician.ClinicianDetailsWithNPI(ContainerModel.PhysicianWithVenousPreference2);
            }
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario20()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            var randomPhysician = UtilityClass.GetRandomNumber(0, 1);
            if (randomPhysician == 0)
            {
                clinician.ClinicianDetailsWithNPI(ContainerModel.ProviderWithVenousPreference1);
            }
            else
            {
                clinician.ClinicianDetailsWithNPI(ContainerModel.ProviderWithVenousPreference2);
            }
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();

            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();
        }

        [TestMethod]
        public void ContainerScenario21()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            var randomPhysician = UtilityClass.GetRandomNumber(0, 1);
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80053", "CMP");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            insurance.AddInsurance(ContainerModel.PayorWithVenousPreference);
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();


            HashSet<string> expectedContainers = new HashSet<string>();
            expectedContainers.Add(ContainerModel.Venous);
            confirmOrders.CheckContainers(expectedContainers);
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();
            summary.PrintAndPayInsurance();
            payment.BackToDashboard();
        }


    }
}

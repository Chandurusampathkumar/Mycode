
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.Models.Features;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;

namespace Theranos.Automation.PSC3.TestCases.FeaturesTests
{
    [TestClass]
    public class PricingTests:PricingModel
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

        public static List<PricingModel> Records;
        public static int lastVisitNo = 0;
        public static int lastOrderNo = 0;
        public static string totalCharge;


        [TestMethod()]
        public void InitializePricingSuite()
        {
            Records = CSVHelper.GetRecords<PricingModel>(InputFileName);
        }

        [TestCategory(AppSettings.SpecialSuite), TestMethod()]
        public void SelfV2PricingTest()
        {
            
            lastOrderNo = 0;
            foreach (var record in Records)
            {
                if (record.Scenario==SelfV2Scenario && lastVisitNo < Convert.ToInt32(record.Visit))
                {
                    lastVisitNo = Convert.ToInt32(record.Visit);
                    totalCharge = record.TotalCharge;
                    TestContext.WriteLine("Lab Visit No: "+lastVisitNo);
                    E2EforPricingTests(SelfV2Scenario);
                    break;
                }

            }
        }

        [TestCategory(AppSettings.SpecialSuite), TestMethod()]
        public void SelfV1PricingTest()
        {

            lastOrderNo = 0;
            foreach (var record in Records)
            {
                if (record.Scenario == SelfV1Scenario && lastVisitNo < Convert.ToInt32(record.Visit))
                {
                    lastVisitNo = Convert.ToInt32(record.Visit);
                    totalCharge = record.TotalCharge;
                    TestContext.WriteLine("Lab Visit No: " + lastVisitNo);
                    E2EforPricingTests(SelfV1Scenario);
                    break;
                }

            }
        }

        public void E2EforPricingTests(string scenario)
        {
            Dictionary<string, ClinicianModel> doctor = new Dictionary<string, ClinicianModel>();
            List<String> doctorAdded = new List<string>();
            int index;
            var clinicianRecords = CSVHelper.GetRecords<ClinicianModel>(ClinicianModel.InputFileName);
            for (int i = 1; i <= 6; i++)
            {
                do
                {
                    index = UtilityClass.GetRandomNumber(0, clinicianRecords.Count);   
                } while (doctorAdded.Contains(clinicianRecords[index].NPI));
                doctorAdded.Add(clinicianRecords[index].NPI);
                doctor.Add(i.ToString(), clinicianRecords[index]);
            }
            

            login.LaunchApplication();
            login.LoginValid();
            dashboard.SearchAndAddByNameDOB();
            foreach (var record in Records)
            {
                if (record.Scenario==scenario&& lastVisitNo == Convert.ToInt32(record.Visit) && lastOrderNo < Convert.ToInt32(record.Order))
                {
                    lastOrderNo = Convert.ToInt32(record.Order);
                    TestContext.WriteLine("LabOrderNo: " + lastOrderNo);
                    labOrder.CheckAndAddNewOrder();
                    TestContext.WriteLine("Doctor: "+record.Dr);
                    if (record.Dr==DoctorNA)
                    {
                        var random = UtilityClass.GetRandomNumber(0, 1);
                        if (random == 1)
                        {
                            labOrder.ScanClinicianOrder();
                            clinician.ClinicianDetailsNPI();
                            clinician.MoveToTestPage();
                        }
                        else
                        {
                            labOrder.ScanDirectTesting();
                        }
                    }
                    else
                    {
                        labOrder.ScanClinicianOrder();
                        TestContext.WriteLine("Doctor details: " + doctor[record.Dr].NPI + ", " + doctor[record.Dr].ClinicianName + ", " + doctor[record.Dr].ProviderName);
                        clinician.ClinicianDetailsWithNPI(doctor[record.Dr]);
                        clinician.MoveToTestPage();

                    }

                    
                    foreach (var innerRecord in Records)
                    {
                        if (innerRecord.Scenario == scenario && innerRecord.Visit == record.Visit && innerRecord.Order == record.Order)
                        {
                            TestContext.WriteLine("CPT Code: "+innerRecord.CPTCode+", CPT Name: "+innerRecord.CPTName);
                            cpt.AddTestWithCode(innerRecord.CPTCode, innerRecord.CPTName);
                        }                    
                    }
                    cpt.SaveDetails();
                    TakeScreenShot();

                }
               
            }
            labOrder.ClickNextButton();
            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.AddEmergencyContact();
            TakeScreenShot();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            //CheckPriceOfEachTest();
            //CheckContainers();
            TakeScreenShot();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            CheckPricing();
        }

        public void CheckPricing()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            var displayedAmount= appWin.Get<Label>(SearchCriteria.ByAutomationId(SummaryModel.AmountDue_ByID)).Name.Replace('$',' ').Trim();
            TestContext.WriteLine("Displayed total charge: " + displayedAmount);
            TestContext.WriteLine("Expected total charge: " + totalCharge);
            Assert.AreEqual(totalCharge,displayedAmount,"Expected total charge is not equal to the displayed total charge");
        }

    }
}

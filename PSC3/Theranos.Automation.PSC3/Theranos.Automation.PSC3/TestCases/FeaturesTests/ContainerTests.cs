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

namespace Theranos.Automation.PSC3.TestCases.FeaturesTests
{
    [TestClass]
    public class ContainerTests : ContainerModel
    {

        LoginTests login = new LoginTests();
        DashboardTests dashboard = new DashboardTests();
        AddLabOrderTests labOrder = new AddLabOrderTests();
        CheckInTests checkin = new CheckInTests();
        ClinicianTests clinician = new ClinicianTests();
        OrderInstructionsTests instructions = new OrderInstructionsTests();
        CPTTests cpt = new CPTTests();
        ICDTests icd = new ICDTests();
        BasicInfoTests basicInfo = new BasicInfoTests();
        AddressTests address = new AddressTests();
        ContactTests contact = new ContactTests();
        InsuranceTests insurance = new InsuranceTests();
        GuestFormsTests guestForms = new GuestFormsTests();
        ConfirmOrdersTests confirmOrders = new ConfirmOrdersTests();
        SummaryTests summary = new SummaryTests();
        PaymentTests payment = new PaymentTests();


        public static List<CPTModel> CurrentCPTList = new List<CPTModel>();
        public static List<ContainerModel> Records;
        public static Dictionary<string, bool> containerDictionary = new Dictionary<string, bool>();
        //public static string CPTCode = "";
        //public static string CPTName = "";
        public static int lastOrderNo = 0;
        public static string collectionList = "";
        public static string gender = "";
        public static string patientPreference = "";
        public static string physicianPreference = "";
        public static string providerLocationPreference = "";
        public static string payorPreference = "";
        public static string paymentMethod = "";
        //public static string Redraw = "";
        //public static string Container = "";

        [TestMethod()]
        public void InitializeContainerSuite()
        {
            Records = CSVHelper.GetRecords<ContainerModel>(InputFileName);
        }

        [TestCategory(AppSettings.SpecialSuite), TestMethod()]
        public void ContainerCloudTest()
        {
            
            int index = 0;
            for (; index < Records.Count; index++)
            {
                if (lastOrderNo < Convert.ToInt32(Records[index].LabOrderNo))
                {
                    CurrentCPTList.Clear();
                    lastOrderNo = Convert.ToInt32(Records[index].LabOrderNo);
                    collectionList = Records[index].Container;
                    gender = Records[index].Gender;
                    patientPreference = Records[index].PatientPreference;
                    physicianPreference = Records[index].PhysicianPreference;
                    providerLocationPreference = Records[index].ProviderLocationPreference;
                    payorPreference = Records[index].PayorPreference;
                    paymentMethod = Records[index].PaymentMethod;

                    foreach (var record in Records)
                    {
                        if (Records[index].LabOrderNo == record.LabOrderNo)
                        {
                            CPTModel cpt = new CPTModel();
                            cpt.CPTCode = record.CPTCode;
                            cpt.TestName = record.CPTName;
                            CurrentCPTList.Add(cpt);
                        }

                    }
                    E2EforContainerTests();

                    break;
                }



            }
        }

        [TestMethod()]
        public void E2EforContainerTests()
        {
            TestContext.WriteLine("LabOrderNo: "+  lastOrderNo.ToString());

            TestContext.WriteLine("Gender: "+gender);
            TestContext.WriteLine("Container List: "+collectionList);

            login.LaunchApplication();
            login.LoginValid();
            dashboard.SearchAndAddByNameDOB();
            labOrder.ScanClinicianOrder();
            if (physicianPreference == Venous)
            {
                var random = UtilityClass.GetRandomNumber(0, 1);
                if (random == 0)
                {
                    clinician.ClinicianDetailsWithNPI(PhysicianWithVenousPreference1);
                }
                else
                {
                    clinician.ClinicianDetailsWithNPI(PhysicianWithVenousPreference2);
                }
            }else if(providerLocationPreference==Venous)
            {
                var random = UtilityClass.GetRandomNumber(0, 1);
                if (random == 0)
                {
                    clinician.ClinicianDetailsWithNPI(ProviderWithVenousPreference1);
                }
                else
                {
                    clinician.ClinicianDetailsWithNPI(ProviderWithVenousPreference2);
                }
            }
            else
            {
                clinician.ClinicianDetailsName();
            }
            
            clinician.MoveToTestPage();

            foreach (var item in CurrentCPTList)
            {
                cpt.AddTestWithCode(item.CPTCode, item.TestName);
            }
            TakeScreenShot();
            cpt.SaveDetails();
            labOrder.ClickNextButton();

            if (gender == Male)
            {
                basicInfo.AddGuestInfoMale();
            }
            else if (gender == Female)
            {
                basicInfo.AddGuestInfoFemale();
            }
            else
            {
                basicInfo.AddGuestInfo();
            }


            address.AddMailingAddress();
            address.AddBillingAddress();
            TakeScreenShot();
            //contact.AddGuardianContact();
            //contact.AddEmergencyContact();
            if (payorPreference==Venous)
            {
                insurance.AddInsurance(PayorWithVenousPreference);
            }
            basicInfo.VerifyGuestID();
            
            guestForms.ConfirmGuestSign();
            if (patientPreference==Venous)
            {
                ChangePatientCollectionPreference(Venous);
            }
            else if (patientPreference == Fingerstick)
            {
                ChangePatientCollectionPreference(Fingerstick);
            }
            if (payorPreference==Venous)
            {
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethod();
                summary.Insurance();
                checkin.MoveToConfirmOrders();
                CheckContainers();
                TakeScreenShot();
                checkin.MoveToSummaryPage();
                summary.Pay();
                payment.BackToDashboard();
            }
            else
            {
                CheckContainers();
                TakeScreenShot();
                confirmOrders.FastingYesIfAvailable();
                confirmOrders.CheckInformCollectMethod();
                summary.Pay();
                payment.BackToDashboard();
            }
        }

        [TestMethod()]
        public void CheckContainers()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
            HashSet<string> expectedContainers = new HashSet<string>(collectionList.Split(','));
            HashSet<string> presentContainers = new HashSet<string>();

            var bloodSelection = appWin.Get<Label>(SearchCriteria.ByAutomationId(BloodSelectionLabel_ByID));
            var urine = appWin.Get<Label>(SearchCriteria.ByAutomationId(UrineContainerLabel_ByID));
            var swab = appWin.Get<Label>(SearchCriteria.ByAutomationId(SwabContainerLabel_ByID));
            var stool = appWin.Get<Label>(SearchCriteria.ByAutomationId(StoolContainerLabel_ByID));

            if (bloodSelection.Visible)
            {
                if (bloodSelection.Name == VenousDraw_ByName)
                {
                    presentContainers.Add(Venous);
                }
                else if (bloodSelection.Name == Fingerstick_ByName)
                {
                    presentContainers.Add(Fingerstick);
                }
            }

            if (urine.Visible)
            {
                presentContainers.Add(Urine);
            }

            if (swab.Visible)
            {
                presentContainers.Add(Swab);
            }

            if (stool.Visible)
            {
                presentContainers.Add(Stool);
            }

            if (!expectedContainers.SetEquals(presentContainers))
            {
                Assert.Fail("Expected and present containers doesn't match Expected Containers: " + String.Join(", " ,expectedContainers) + " Present Containers: " +String.Join(", ",presentContainers));
            }
        }

        //[TestMethod]
        //public void CollectionType()
        //{
        //    ChangeCollectionType(Venous);
        //}

        public void ChangePatientCollectionPreference(string collection)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ModifyPreference_ById);

            if (collection.Equals(Venous))
            {              
                AutoAction.ClickRadioButtonById(appWin,SelectVenousDraw_ByID);
            }
            else if(collection.Equals(Fingerstick))
            {
                AutoAction.ClickRadioButtonById(appWin, SelectVenousDraw_ByID);
            }
            AutoAction.ClickButtonById(appWin, Save_ByID);
        }

            


        
    }
}

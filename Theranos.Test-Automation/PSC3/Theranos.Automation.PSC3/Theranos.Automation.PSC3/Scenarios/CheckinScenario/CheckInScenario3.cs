using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack.Android.Utility;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.Models.CheckIn;
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
    public class CheckInScenario3:PSC3Model
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

        [TestMethod]
        public void BillMeLater()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
        
            dashboard.SearchAndAddByNameDOB();

            //addLabOrder.ScanDirectTesting();
            //cpt.AddTestByCode();
            //cpt.SaveDetails();
            //addLabOrder.ClickNextButton();
            addLabOrder.ScanSendForTranscription();                 //CTC-136... scenario starts here
            addLabOrder.ClickNextButton();

            basicInfo.CheckPhoneFields();           //CTC-94
            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.BackToAddLabOrder();
            addLabOrder.DeleteOrder();                          //CTC-136

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsName();                       //CTC-136... scenario ends here
            orderInstructions.VerifyForUnspecifiedCheckBox();
            clinician.MoveToTestPage();
            cpt.AddTestByCode();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            var contactInfo = contact.AddAndReturnGuardianContact();
            contact.CheckGuardianContactDuplicate(contactInfo);                 //CTC-135
            contact.AddMoreEmergencyContact();   // CTC-132
            contact.AddMoreEmergencyContact();
            contact.AddMoreGuardianContact();           //CTC-134
            contact.AddMoreGuardianContact();
            contact.AddGuardianContactLessThan18();             //CTC-95
            basicInfo.VerifyGuestID();

            guestForms.ClickBackButton();
            address.CheckMailingAndBillingAddress();
            basicInfo.ClickNextButton();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckForSM2Order();               //CTC-143
            confirmOrders.CheckInformCollectMethod();
            summary.Print();
            payment.BillMeLater();              //CTC-84
            payment.BackToDashboard();
            login.Logout();
        }


        [TestMethod]
        public void SelectVenousDraw()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();

            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("82947", "Gulcose");
            cpt.AddTestWithCode("83655", "Lead");
            cpt.AddTestWithCode("T700255", "GTT2");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            var contactInfo = contact.AddAndReturnEmergencyContact();
            contact.CheckEmergencyContactDuplicate(contactInfo);            //CTC-133
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.SelectDoNotcollectBlood();
            confirmOrders.SelectVenousDraw();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void RemovalOfSwabTest01()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();

            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.GuardianContactMandatory();
            
            guestForms.CheckGuestSign();
            guestForms.ClickNextButtonAndCheckForSwabTestRemoval();
            checkIn.CancelVisit();
        }

        [TestMethod]
        public void RemovalOfSwabTest02()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();

            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfoAgeLessThan18();
            address.AddMailingAddress();
            address.AddBillingAddress();
            contact.CheckNoGuardianContact();

            guestForms.CheckGuestSign();
            guestForms.ClickNextButtonAndCheckForSwabTestRemoval();
            checkIn.CancelVisit();
        }

        [TestMethod]
        public void CheckCollectionTypeForOtherContainers()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();

            dashboard.SearchAndAddByNameDOB();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();

            cpt.AddTestWithCode("82340","Calcium, Urine");
            cpt.AddTestWithCode("T700276","Swab");
            cpt.AddTestWithCode("82272", "Stool 1");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckForUrineCollectionType();
            confirmOrders.CheckForSwabCollectionType();
            confirmOrders.CheckForStoolCollectionType();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.VerifyForAmountDue();
            payment.ConfirmPayment();
            payment.BackToDashboard();
            login.Logout();    
        }

        [TestMethod]
        public void DeleteInsuranceFailure()
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
            checkIn.MoveToGuestInfo();
            insurance.DeleteInsuranceFailure();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ClickNextButton();
            summary.PrintAndPayInsurance();
            payment.BackToDashboard();
            login.Logout();
        }

        [TestMethod]
        public void EditGuestInfo()
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
            addLabOrder.ClickNextButton();
            var guestInfo=basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.FastingYesIfAvailable();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndCancel();
            checkIn.MoveToSummaryPage();
            checkIn.MoveToGuestInfo();

            BasicInfoModel originalGuestInfo = guestInfo;
            guestInfo.FirstName = guestInfo.FirstName + "EditA";
            guestInfo.LastName = guestInfo.LastName + "EditA";
            guestInfo.MI = "A";
            guestInfo.PhoneNo = UtilityClass.GetRandomNumber(10000, 99999).ToString() + UtilityClass.GetRandomNumber(10000, 99999).ToString();
            guestInfo.DOB = "'01021990";
            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestDetails(guestInfo);

            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ClickNextButton();
            summary.Pay();                              //CTC-82
            payment.BackToDashboard();
            login.Logout();
        }


        
        [TestMethod]
        public void SM2MultipageLabOrder()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanMultipageSM2LabORder();
            addLabOrder.SelectMultiplePage();
            addLabOrder.SelectMultiplePage();
            addLabOrder.SelectMultiplePage();
            addLabOrder.SelectSendForTranscription();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckForSM2Order();               //CTC-143 
        }

        [TestMethod]
        public void STIPanelPricing()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            //
            cpt.AddTestWithCode("T700265", "Heptatis B");           //TC- 231
            cpt.AddTestWithCode("T700230", "Syphilis Screen");      //TC- 231
            cpt.verifyaddedtest();                                  //TC- 231
            cpt.AddTestWithCode("T700263","DNA Qualitative");
            cpt.AddTestWithCode("T700271", "HIV screen");
            cpt.AddTestWithCode("T700297", "HIV with reflex");
            cpt.AddTestWithCode("T700276", "Swab");
            cpt.AddTestWithCode("87389", "HIV 1/2");
            cpt.AddTestWithCode("86695", "Herpes simplex1");
            cpt.AddTestWithCode("86696", "Herpes simples2");
            cpt.AddTestWithCode("86803", "Heptatis C");
            cpt.AddTestWithCode("87340", "Heptatis B");
            cpt.AddTestWithCode("87491", "Chlamydia");
            cpt.AddTestWithCode("87591", "Gonorreha");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.CheckAmountDueForSTIPanel();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();

        }

        [TestMethod]
        public void FastingRequirementNotDisplayed()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("82040", "Albumin");
            cpt.AddTestWithCode("82105", "Oncology");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.AddBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.CheckForAcknowledgeForm();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckFastingRequirementIsNotDisplayed();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPayCancel();
            payment.BackToDashboard();
            login.Logout();
        }
        //TC-167
        [TestMethod]
        public void CheckFullRefundForInsurancePay()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            insurance.AddInsurancePrimary();
            basicInfo.VerifyGuestID();

            //guestForms.CheckForAcknowledgeForm();
            guestForms.ConfirmGuestSign();
            //confirmOrders.CheckFastingRequirementIsNotDisplayed();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();
            summary.CheckPriceForInsurance();
            summary.PrintAndPayInsurance();
            payment.FullRefundInsurance();
            login.Logout();
        }

        //TC-39
        [TestMethod]
        public void OtherAsInsuranceProvider()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            insurance.AddOtherAsInsuranceProvider();

            login.Logout();
        }

        //CTC-88: check-in -User must be able to place the patient at any point during check-in workflow
        [TestMethod]
        public void BackToDashbrdAtanyPnt()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanDirectTesting();
            cpt.AddTestByName();
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            insurance.AddInsurancePrimary();
            contact.AddEmergencyContact();
            basicInfo.VerifyGuestID();

            guestForms.CheckGuestSign();
            guestForms.ClickBackButton();

            basicInfo.BackToAddLabOrder();
            checkIn.NavigateToDashboard();

        }
        
        //TC-163
        [TestMethod]
        public void RecreateVisitCheckin()
        {
            //create visit and complete checkin
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            //Patient is been selected from perform Room waiting and make full refund.. complete the visit
            dashboard.SearchGuestInPerformRoomWaiting(guestInfo);
            payment.FullRefund();

            //Search the same patient and complete the visit
            dashboard.SearchExistingByNameDOBCheckIn(guestInfo.FirstName, guestInfo.LastName, guestInfo.DOB, guestInfo.PhoneNo);
            addLabOrder.ClickNextButton();
            basicInfo.AddGuestInfo(guestInfo);
            basicInfo.VerifyGuestID();
            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.PrintAndPay();
            payment.BackToDashboard();

            //select the same patient from perform room waiting... Makeadjustment and edit the visit
            dashboard.SearchGuestInPerformRoomWaiting(guestInfo);
            payment.EditVisit();

            //check patient navigated to summary page and able to navigate back to AddLabOrder page 
            summary.ClickBackButton();
            guestForms.ClickBackButton();
            basicInfo.BackToAddLabOrder();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin, AddLabOrderModel.ActiveLabOrders_ByID), "When recreating visit checkin, cannot able to navigate back to Add Lab Order page from summary page");

        }
        
        //TC-176 - 
        [TestMethod]
        public void VisitWithUnavailableOrder()
        {
            //create visit and complete checkin
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.FastingRequirement();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "Glucose");
            cpt.AddTestWithCode("86706", "Hepatitis");
            cpt.AddTestWithCode("82140", "Ammonia");
            cpt.AddTestWithCode("T700267", "Reproductive");
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.AddTestWithCode("80055", "Obstetric");
            cpt.SaveDetails();

            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckErrorForAmmonia();

            //Check collection type presence in the confirmation window
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.VisibleById(appWin,ConfirmOrdersModel.BloodSelectionLabel_ByID),"Collection type not present");

            confirmOrders.CheckInformCollectMethodGTTInstruction();
            
            summary.PrintAndPay();
            payment.BackToDashboard();

           
        }

        //TC-199 - After Full Refund, added new order is been selected by default in the confirm order page
        [TestMethod]
        public void AfterFullRefundCurrentOrderChecked()
        {
            //create an order and make full refund
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            insurance.AddInsurancePrimary();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.Insurance();
            summary.CheckPriceForInsurance();
            summary.PrintAndPayInsurance();
            payment.CheckCancelVisitinMakeAdjustment();         //TC-213
            payment.FullRefundInsurance();

            //Create new order/visit for the same patient
            dashboard.SearchCheckedInGuestNameDOB(guestInfo);
            addLabOrder.AddNewOrder();
            addLabOrder.ScanClinicianOrder();
            ClinicianModel clinicialDetails = clinician.GetClinicianDetails();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("86706", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();
            guestForms.ClickNextButton();
            guestForms.ConfirmGuestSign();

            //check the latest order is been checked by default in the confirm orders page
            confirmOrders.IsLatestOrderChecked(clinicialDetails.ClinicianName);
            

            login.Logout();
        }

        //CTC-77: Verify user is able to edit the visit...Move to other pages by clicking add lab order,summary pages.
        //TC-216 - Patient shall be editable when order is standing order and order details should be visible in the confirm orders page
        [TestMethod]
        public void IsStandingOrderEditableandDetailsVisible()
        {
            //Create a standing order
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            orderInstructions.StandingOrderMonth();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.Pay();
            payment.EditVisit();                

            //edit visit...goto confirm orders page... check order details shows all the added order, description, price and it shows as STANDING
            summary.ClickBackButton();
            confirmOrders.OrderReview();
            confirmOrders.CheckStandingOrder();     //CTC-69; CTC-70

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var cptList = AutoElement.GetElementByName(appWin, ConfirmOrdersModel.TestListItem_ByName);
            var cptListItems = AutoElement.GetAllChilderen(cptList);
            var cptCode = cptListItems[0].Current.Name;

            Assert.AreEqual(cptCode, "80074", "CPT code doesn't match with SM2 CPT code");
            confirmOrders.SaveOrderDetails();
            login.Logout();
        }

        //TC-222- To verify GTT+Edit visit prompting guest to pay only once  it doesn’t ask guest to pay twice
        [TestMethod]
        public void CheckPaywithGTTpEdit()
        {
            //Create a order with GTT+VitaminD + Lipid
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700257", "GTT");
            cpt.AddTestWithCode("82306", "Vitamin D");
            cpt.AddTestWithCode("80061", "Lipid");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethodGTTInstruction();

            //TC-230 check 'panel pricing adjustment label and value present in the summary page
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, "Panel Pricing Adjustment:"));
            Assert.IsTrue(AutoElement.ExistsById(appWin, SummaryModel.PanelPricingAdjustment_ByID));

            summary.Pay();
            payment.EditVisit();

            //edit visit...goto confirm orders page... check, when clicking Pay Button in Summary, user is not asked to pay again...
            summary.ClickBackButton();
            confirmOrders.CheckInformCollectMethodGTTInstruction();
            summary.PayAfterEdit();
            
            login.Logout();
        }

        // Perform TC-179  : When 2 GTT tests are added, application should show GTTValidationError
        public void CheckGTTValidation()
        {
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("T700255", "GTT");
            cpt.AddTestWithCode("T700254", "GTT");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            basicInfo.AddGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.GTTValidationError();
            
            login.Logout();
        }

        //CTC-74 -  To verify while editing the visit," please verify guest id" is checked automatically in "Guest info" page.
        [TestMethod]
        public void WhenEditVisitCheckGuestIDChkbok()
        {
            //Create a standing order
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.Pay();
            payment.EditVisit();

            dashboard.CheckGuestCompleteAdjustmentAndNavigateToGuestInfo(guestInfo);
            basicInfo.CheckStatusOfVerifyGuestIDCheckBox();

        }

        //CTC-107  : To verify when user wish to add test after te payment by edit visit section system should prompt for payment collection in the summary page.
        [TestMethod]
        public void ChkAfterEditAddedOrderPrmtForDisplay()
        {
            //Create a standing order
            login.LaunchApplication();
            login.LoginValid();
            dashboard.CheckAndChangeToCheckInTerminal();
            dashboard.SearchAndAddByNameDOB();

            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsNPI();
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80074", "Hepatitis");
            cpt.SaveDetails();
            addLabOrder.ClickNextButton();

            BasicInfoModel guestInfo = basicInfo.AddAndReturnGuestInfo();
            address.AddMailingAddress();
            address.SetMailingAddressAsBillingAddress();
            basicInfo.VerifyGuestID();

            guestForms.ConfirmGuestSign();
            confirmOrders.CheckInformCollectMethod();
            summary.Pay();
            payment.EditVisit();

            checkIn.MoveToAddLabOrder();
            addLabOrder.AddNewOrder();
            addLabOrder.ScanClinicianOrder();
            clinician.ClinicianDetailsWithNPI("1982830436","Angela Felix");
            clinician.MoveToTestPage();
            cpt.AddTestWithCode("80061", "Lipid");
            cpt.SaveDetails();
            
            addLabOrder.ClickNextButton();
            basicInfo.ClickNextButton();
            guestForms.ClickNextButton();
            confirmOrders.ClickNextButton();

            summary.ChekRecentOdrAdded("Angela Felix");           //Check lab order which is added by edit visit shown in summary page
            summary.PayAfterEdit();
            login.Logout();
           
        }




      

    }
}

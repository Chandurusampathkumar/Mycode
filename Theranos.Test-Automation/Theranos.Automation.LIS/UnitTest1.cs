using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PscSoapApiAutomation.Model;
using ServiceTests.Auth;
using Theranos.Automation.AutoStack.Utility;
using UnitTestProject1.ServiceReference1;
using Microsoft.Office.Interop.Excel;
using Name = UnitTestProject1.ServiceReference1.Name;

//@Author  Fangming Lu

namespace PscSoapApiAutomation
{
    [TestClass]
    public class PscSoapAPIAutomationTest
    {
        IPscService client;

        [TestInitialize]
        public void Setup()
        {
            client = new PscServiceClient();
           
           using (new OperationContextScope(client.GetChannel()))
            {
                var response = client.Login("labtech@theranos.com", "Theranos#123", GetMacAddress());
                CookieSetterBehavior.Cookie = null;
                CookieSetterBehavior.Token = null;
                var authenticationResult = response.ResponseData;

                var properties = OperationContext.Current.IncomingMessageProperties;
                var responseProperty = (HttpResponseMessageProperty) properties[HttpResponseMessageProperty.Name];
                var cookie = responseProperty.Headers[HttpResponseHeader.SetCookie];
                CookieSetterBehavior.FormatAndSetCookie(cookie);
                CookieSetterBehavior.Token = authenticationResult.Token;
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            client.GetChannel().Abort();
        }
        [TestMethod]
        public void TestGetGuestsinCheckin()
        {
           var getGuestCheckinResponse = client.GetGuestsinCheckin();
           Console.WriteLine(getGuestCheckinResponse.ResponseData.Length);
           Console.WriteLine(getGuestCheckinResponse.ResponseCode);
           Console.WriteLine(getGuestCheckinResponse.ResponseData.Rank);
        }

        [TestMethod]
        public void TestFindGuests()
        {
            var getFindGuestsResponse = client.FindGuests(GetGuestSearchCriteria(), DateTime.Now);
            Console.WriteLine(getFindGuestsResponse.ResponseCode);
            var guestSearchResults = getFindGuestsResponse.ResponseData;
            guestSearchResults.ToList().ForEach(result => Console.WriteLine(result.FirstName + " " + result.LastName + ", ID: " + result.GuestId + "VisitId:" + result.VisitId));            
        }



        [TestMethod]
        public void TestFindDoctor()
        {
            Guid? id = null;
            var getFindDoctorResponse = client.FindDoctors("tom",id);
            Console.WriteLine(getFindDoctorResponse.ResponseData.First().Name.FirstName);
        }


        [TestMethod]
        public void TestCreatLabRequest()
        {

            var getCreateLabResponse = client.CreateLabRequest(GetGuestId(), OrderType.DirectTestingLisTranscribed);
            Console.WriteLine(getCreateLabResponse.ResponseCode);
            Console.WriteLine(getCreateLabResponse.ResponseData);
        }

        [TestMethod]
        public void TestGetDirectModeLabOrder()
        {
            var guestID = GetNewGuestID();
            var visitID = GetNewVisitID(guestID);
            var labID = GetLabOrderIdFromNewGuest(guestID);

            GuestLabOrderTranscription labOrderTranscription = new GuestLabOrderTranscription()
            {
                CptCodes = new[]
                {
                    new CptCodeFastingHours()
                    {
                        CptCodeId = getCPTId(80048)
                    }, new CptCodeFastingHours()
                    {
                        CptCodeId = getCPTId(80051)
                    } 
                
                }, OrderDate = new DateTimeOffset(new DateTime(2016, 1, 1))
            };
            client.SubmitManualTranscriptionForGuestLabOrder(labID, guestID, labOrderTranscription);
            client.AddLabOrderToVisit(labID, visitID);
            var getDirectModeLabOrderResponse = client.GetLabOrderCptDetails(labID, visitID, CptDescriptionRequestReason.GuestRequestToReviewTestDetails);
            Console.WriteLine(visitID + "," + labID + "," + guestID);
            //var getrespon = client.GetLabOrderCptSummaries(labID, visitID);
            //getrespon.ResponseData.ToList().ForEach(result => Console.WriteLine(result.CptCodeId + " CPT Code: " + result.CptCode + ", Price: " + result.Price + "Description:" + result.ShortDescription));
            Console.WriteLine(getDirectModeLabOrderResponse.ResponseData.First());
            getDirectModeLabOrderResponse.ResponseData.ToList().ForEach(result => Console.WriteLine(result.CptCodeId + " CPT Code: " + result.CptCodeId + ", Price: " + result.Price + "Description:" + result.Description));
        }

        [TestMethod]
        public void TestCheckInPhysicianModeLabOrderWithExcelPrice()
        {
            var guestID = GetNewGuestID();
            var visitID = GetNewVisitID(guestID);
            var labID = GetLabOrderIdFromNewGuest(guestID);
            var doctorId = GetDoctorId("tom");
            var providerId = GetProviderId();
            var locationId = GetLocationId(providerId);

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(CPTModel.InputFilePath);
            Worksheet excelSheet = wb.ActiveSheet;
            string test = excelSheet.Cells[1, 1].Value.ToString();
            string B = excelSheet.Cells[1, 3].Value.ToString();
            Console.WriteLine(excelSheet.Cells[1, 3].Value.ToString());
            string[] cptcodes = test.Split(' ').ToArray();
            Console.WriteLine(cptcodes);
            foreach (string cptcode in cptcodes)
            {
                Console.WriteLine(cptcode.Replace("  ", string.Empty));
            }
            wb.Close();
            var transcription = GetPhysicianLabOrderTranscription(doctorId, locationId, providerId);

            CptCodeFastingHours[] cptCodeFastingHourses = new CptCodeFastingHours[cptcodes.Length];
            for (int i = 0; i < cptcodes.Length; i++)
            {

                cptCodeFastingHourses[i] = new CptCodeFastingHours()
                {
                    CptCodeId = getCPTId(Int32.Parse(cptcodes[i]))
                };
            }
            transcription.CptCodes = cptCodeFastingHourses;
            
            client.UpdateContactInfo(guestID, GetContactInfo());
            client.UpdateMailingAddress(guestID, GetMailingAddress());
            client.UpdateBillingAddress(guestID, GetBillingAddress(GetMailingAddress()));
            client.SubmitManualTranscriptionForPhysicianLabOrder(labID, guestID, transcription);
            client.AddLabOrderToVisit(labID, visitID);

            var getDirectModeLabOrderResponse = client.GetLabOrderCptDetails(labID, visitID, CptDescriptionRequestReason.GuestRequestToReviewTestDetails);
            getDirectModeLabOrderResponse.ResponseData.ToList().ForEach(result => Console.WriteLine(result.CptCodeId + ", Price: " + result.Price + "Description:" + result.Description));
            client.GetCollectionTypesForDefaults(visitID);
            var getRmoveTestResponse = client.RemoveTestsIncludedInVisitButNotAvailableAtTheranos(visitID);
            getRmoveTestResponse.ResponseData.ToList().ForEach(result => Console.WriteLine(result.CptCodeId + " CPT Code: " + result.CptCode + ", Price: " + result.Price + "Description:" + result.ShortDescription));
          
            client.GetGttWorkflowDetails(visitID);
            client.IsGuestSignatureRequiredOnAbnForm(visitID);
            client.IsRequiredToCollectGuestHeightInfo(guestID, visitID);
            client.UpdateCollectionTypeInfo(visitID, GetCollectionTypeSelection());
            
            //step1
            GuestVisitState visitState = new GuestVisitState();
            visitState.Completed = false;
            visitState.IsCancellationRequestedInPerform = false;
            visitState.IsCancelled = false; 
            visitState.IsDropOff = false;
            visitState.IsRefundOrAmountDuePendingInPerform = false;

            var confirmOrderState = GetConfirmOrderState();
            visitState.ConfirmOrderState = confirmOrderState;

            var guestFormsState = GetGuestFormsState();
            visitState.GuestFormsState = guestFormsState;

            var guestInfoState = GetGuestInfoState();
            visitState.GuestInfoState = guestInfoState;

            var labOrderState = GetLabOrderState();
            visitState.LabOrderState = labOrderState;

            var orderSummaryState = GetOrderSummaryState();
            visitState.LabOrderSummaryState = orderSummaryState;

            var otherState = GetOtherState();
            visitState.OtherState = otherState;

            var paymentState = GetPaymentState();
            visitState.PaymentState = paymentState;

            var performState = GetPeformState();
            visitState.PerformState = performState;

            var workFlowState = GetWorkFlowState();
            visitState.WorkFlowState = workFlowState;

            client.UpdatedGuestVisitState(visitID, visitState);

            //step2
            workFlowState.CurrentStep = WorkflowStep.GuestForms;
            visitState.WorkFlowState = workFlowState;
            confirmOrderState.SelectedDrawType = DrawTypeSelection.VenousDraw;
            visitState.ConfirmOrderState = confirmOrderState;
            guestInfoState.IsGuestVerified = true;
            guestInfoState.Completed = true;
            visitState.GuestInfoState = guestInfoState;
            client.UpdatedGuestVisitState(visitID, visitState);


            //step3
            confirmOrderState.IsGuestAdvisedOfCollectionType = true;
            guestFormsState.IsAcknowledgementofPrivacyPracticesFormCollected = true;
            guestFormsState.Completed = true;
            workFlowState.CurrentStep = WorkflowStep.ConfirmOrders;
            visitState.ConfirmOrderState = confirmOrderState;
            visitState.GuestFormsState = guestFormsState;
            visitState.WorkFlowState = workFlowState;
            client.UpdatedGuestVisitState(visitID, visitState);

            //step4
            orderSummaryState.Completed = true;
            confirmOrderState.Completed = true;
            workFlowState.CurrentStep = WorkflowStep.Payment;
            visitState.ConfirmOrderState = confirmOrderState;
            visitState.LabOrderSummaryState = orderSummaryState;
            visitState.WorkFlowState = workFlowState;
            client.UpdatedGuestVisitState(visitID, visitState);

            client.UpdateCollectionTypeInfo(visitID, GetCollectionTypeSelection());
            client.RemoveTestsIncludedInVisitButNotAvailableAtTheranos(visitID);
            client.CheckAndRemoveChlamydiaGonorrheaSwabCollectionTestIfGuestIsUnderEighteenYears(visitID, guestID);
            client.VisitContainsMoreThanOneDistinctGttTest(visitID);
            client.IsGuestSignatureRequiredOnAbnForm(visitID);

            VisitPaymentSummary paymentSummary = new VisitPaymentSummary();
            var getLabOrderSummaryResponse = client.GetGuestVisitPaymentSummary(visitID, DateTimeOffset.Now);
            paymentSummary.AmountPaid = getLabOrderSummaryResponse.ResponseData.AmountDue;

            client.RegisterCashPaymentForVisit(guestID, paymentSummary);
            client.GetVisitPaymentBarcode(visitID, getLabOrderSummaryResponse.ResponseData.AmountDue);
            client.GetVisitPaymentBarcode(visitID, 0);
            client.SaveCheckinTime(visitID, DateTime.Now);

            paymentState.Completed = true;
            paymentState.IsPaymentCollected = true;
            visitState.PaymentState = paymentState;

            client.UpdatedGuestVisitState(visitID, visitState);
            PaymentSummarySnapShot snapShot = new PaymentSummarySnapShot();
            snapShot.GuestId = guestID;
            snapShot.VisitId = visitID;

            client.SavePaymentSummarySnapShot(snapShot);
            var actualAmount = getLabOrderSummaryResponse.ResponseData.AmountDue;
            Console.WriteLine(getLabOrderSummaryResponse.ResponseData.AmountDue);
            //Assert.AreEqual(records[i].Price, decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero), "The CPT " + records[i].CPTCode +" Expected Price Should Be $" + records[i].Price + " , But We Got $" + decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero));
            //decimal a = decimal.Parse(b.Replace(".",","));
            //Console.WriteLine(a);
            Assert.AreEqual(decimal.Parse(B), decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero), " Expected Price Should Be $" + decimal.Parse(B)+ " , But We Got $" + decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine(getLabOrderSummaryResponse.ResponseData.AmountPaid);


        }

        [TestMethod]
        public void TestAddTestsToVisit()
        {
            var getCreateGuestVistResponse = client.CreateGuestVisit(GetGuestId(), DateTime.Now);
            Console.WriteLine(getCreateGuestVistResponse.ResponseData);

            var getAddTestsToVisitResponse = client.AddTestsToVisit(getCreateGuestVistResponse.ResponseData, new long[80016], new AddRemoveTestReason());
            Console.WriteLine(getAddTestsToVisitResponse.ResponseCode);
        }

        [TestMethod]
        public void TestAddLabOrderToVisit()
        {
            var getCreateLabResponse = client.CreateLabRequest(GetGuestId(), OrderType.DirectTestingLisTranscribed);
            var getAddLabOrderToVisitResponse = client.AddLabOrderToVisit(getCreateLabResponse.ResponseData,GetVisitId());
            Console.WriteLine(getAddLabOrderToVisitResponse.ResponseCode);
        }

        [TestMethod]
        public void TestAddOpenLabOrdersToVisit()
        {
            var getAddOpenLabOrderToVisitResponse = client.AddOpenLabOrdersToVisit(GetGuestId(), GetVisitId());
            Console.WriteLine(getAddOpenLabOrderToVisitResponse.ExtensionData.ToString());
        }

        public Guid GetGuestId()
        {
            var getFindGuestsResponse = client.FindGuests(GetGuestSearchCriteria(), DateTime.Now);
            return getFindGuestsResponse.ResponseData.First().GuestId;
        }

        public Guid GetNewGuestID()
        {
            var getAddNewGuest = client.AddNewGuest(CreateGuestBasicInfo());
            return getAddNewGuest.ResponseData;
        }

        public Guid GetLabOrderId()
        {
            return client.CreateLabRequest(GetGuestId(), OrderType.DirectTestingLisTranscribed).ResponseData;
        }

        public Guid GetProviderId()
        {
            return client.FindProvidersByUserId().ResponseData.First().ProviderId;
        }

        public Guid GetLocationId(Guid providerId)
        {
            return client.FindProviderLocations(providerId).ResponseData.First().Id;
        }

        public Guid GetLabOrderIdFromNewGuest(Guid guestId)
        {
            return client.CreateLabRequest(guestId, OrderType.PhysicianOrderPscTranscribed).ResponseData;
        }

        public Guid GetVisitId()
        {
            var getFindGuestsResponse = client.FindGuests(GetGuestSearchCriteria(), DateTime.Now);
            return getFindGuestsResponse.ResponseData.First().VisitId.Value;
        }

        public Guid GetDoctorId(string doctorName)
        {
            return client.FindDoctors(doctorName, null).ResponseData.First().Id;
        }

        public Guid GetNewVisitID(Guid guestId)
        {
            var getCreateGuestVistResponse = client.CreateGuestVisit(guestId, DateTime.Now);
            return getCreateGuestVistResponse.ResponseData;
        }

        //public CptCodeFastingHours[] GetCptCodeFromWorkSheet(Guid doctorId,Guid locationId,Guid providerId)
        //{
            
        //    return cptCodeFastingHourses;
        //}

        public GuestInfoState GetGuestInfoState()
        {
            GuestInfoState guestInfoState = new GuestInfoState();
            guestInfoState.IsGuestVerified = true;
            guestInfoState.Completed = false;
            return guestInfoState;
        }
        public OtherState GetOtherState()
        {
            OtherState otherState = new OtherState();
            otherState.Completed = false;
            otherState.IsGttWorkFlowPending = false;
            otherState.IsSelfCheckIn = false;
            otherState.IsPendingVisitCreatedByAdmin = false;
            return otherState;
        }

        public LabOrderState GetLabOrderState()
        {
            LabOrderState labOrderState = new LabOrderState();
            labOrderState.Completed = true;
            labOrderState.IsOrderTranscriptionInProgress = false;
            labOrderState.IsOrderTransciptionCompletedSucessfully = false;
            labOrderState.IsOrderTransciptionStatusNotApplicable = false;
            labOrderState.IsOrderTranscriptionCompletedWithError = false;
            labOrderState.IsOrderTranscriptionNotStarted = false;
            return labOrderState;
        }

        public GuestFormsState GetGuestFormsState()
        {
            GuestFormsState guestFormsState = new GuestFormsState();
            guestFormsState.IsAcknowledgementofPrivacyPracticesFormCollected = false;
            guestFormsState.Completed = false;
            return guestFormsState;
        }

        public PaymentState GetPaymentState()
        {
            PaymentState paymentState = new PaymentState();
            paymentState.Completed = false;
            paymentState.IsPaymentCollected = false;
            return paymentState;
        }
        public PeformState GetPeformState()
        {
            PeformState performState = new PeformState();  //spelling error
            performState.Completed = false;
            performState.CurrentDrawNumber = DrawNumber.T0;
            performState.IsCtnSaveStepCompleted = false;
            performState.IsVacutainerSaveStepCompleted = false;
            performState.T0DrawUnableToCollectAllContainers = false;
            return performState;
        }

        public WorkFlowState GetWorkFlowState()
        {
            WorkFlowState workFlowState = new WorkFlowState();
            workFlowState.CurrentStep = WorkflowStep.GuestInfo;
            workFlowState.HasGuestBeenInformedOfGttInstructions = false;
            return workFlowState;
        }

        public ConfirmOrderState GetConfirmOrderState()
        {
            ConfirmOrderState confirmOrderState = new ConfirmOrderState();
            confirmOrderState.Completed = false;
            confirmOrderState.GttDrawType = DrawTypeSelection.VenousDraw;
            confirmOrderState.SelectedDrawType = DrawTypeSelection.VenousDraw;
            confirmOrderState.HasUserSelectedCollectionType = false;
            confirmOrderState.HasDirectTestingOrders = false;
            confirmOrderState.HasRedrawOrders = false;
            confirmOrderState.IsDrawTypeNotOverridable = true;
            confirmOrderState.IsGuestAdvisedOfCollectionType = false;
            confirmOrderState.StoolSelected = true;
            confirmOrderState.SwabSelected = true;
            confirmOrderState.UrineSelected = true;
            return confirmOrderState;
        }
        public LabOrderSummaryState GetOrderSummaryState()
        {
            LabOrderSummaryState orderSummaryState = new LabOrderSummaryState();
            orderSummaryState.Completed = false;
            orderSummaryState.IsAbnFormCollected = false;
            return orderSummaryState;
        }

        public Address GetBillingAddress(Address mailingAddress)
        {
            Address billingAddress = new Address();
            billingAddress.IsBillingAddress = true;
            billingAddress.IsMailingAddress = false;
            billingAddress.City = mailingAddress.City;
            billingAddress.State = mailingAddress.State;
            billingAddress.Street1 = mailingAddress.Street1;
            billingAddress.Street2 = mailingAddress.Street2;
            billingAddress.Zip = mailingAddress.Zip;
            return billingAddress;
        }
        public Address GetMailingAddress()
        {
            Address mailingAddress = new Address();
            mailingAddress.City = "Sunnyvale";
            mailingAddress.IsMailingAddress = true;
            mailingAddress.IsBillingAddress = false;
            mailingAddress.Street1 = "123";
            mailingAddress.State = "CA";
            mailingAddress.Zip = "94086";
            mailingAddress.Street2 = "sda ave";
            return mailingAddress;
        }
        public ContactInfo GetContactInfo()
        {
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.IsEmergencyContact = true;
            contactInfo.Name = new Name() { FirstName = "dasd", LastName = "wqe" };
            contactInfo.IsGuardian = true;
            contactInfo.Relationship = "Brother";
            contactInfo.Email = "test@gmail.com";
            contactInfo.PhoneNumber = new Phone() { Number = "1233212132", NumberType = PhoneNumberType.Mobile };
            return contactInfo;
        }

        public CollectionTypeSelection GetCollectionTypeSelection()
        {
            CollectionTypeSelection selection = new CollectionTypeSelection();
            selection.DrawType = DrawTypeSelection.VenousDraw;
            selection.GttDrawType = DrawTypeSelection.FingerStick;
            selection.IsStoolSelected = true;
            selection.IsSwabSelected = true;
            selection.IsUrineSelected = true;
            selection.IsDrawTypeNotOverridable = false;
            return selection;
        }

        public GuestBasicInfo CreateGuestBasicInfo()
        {
            GuestBasicInfo newGuest = new GuestBasicInfo();
            newGuest.Dob = new DateTime(1991, 02, 10);
            newGuest.Name = new Name{ FirstName = RandomString(5), LastName = "test" };
            Console.WriteLine(newGuest.Name.FirstName);
            newGuest.Email = "dasd@gmail.com";
            newGuest.ZipCode = "94085";
            newGuest.Gender = Gender.Male;
            newGuest.Phone1 = new Phone { Number = "1233212132", NumberType = PhoneNumberType.Mobile };
            return newGuest;
        }

        public GuestSearchCriteria GetGuestSearchCriteria()
        {
            DateTime guestDob = new DateTime(1991, 02, 10);
            GuestSearchCriteria targetGuest = new GuestSearchCriteria();
            targetGuest.FirstName = "fangming";
            targetGuest.LastName = "test";
            targetGuest.PhoneNumber = "1233211234";
            targetGuest.Dob = guestDob;
            return targetGuest;
        }
        public PhysicianLabOrderTranscription GetPhysicianLabOrderTranscription(Guid doctorId,Guid locationId,Guid providerId)
        {
            PhysicianLabOrderTranscription transcription = new PhysicianLabOrderTranscription();

            transcription.DrawType = DrawType.Unspecified;
            //transcription.FastingHours = 2;
            transcription.DoctorId = doctorId;
            transcription.LocationId = locationId;
            transcription.ProviderId = providerId;
            //optional for transcription
            //transcription.FastingHours = -1;
            transcription.ShouldCcGuest = false;
            transcription.ShouldCcPhysician = false;
            transcription.StandingOrderExpiration = DateTime.Now;
            transcription.StandingOrderNumberOfTimes = 0;
            transcription.IsFastingRequired = false;
            transcription.IsStandingOrder = false;
            transcription.CcPhysicianId = null;
            return transcription;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int getCPTId(int cptCode)
        {
            return client.FindCptCodes(cptCode.ToString()).ResponseData.First().Id;
        }

        public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            var sMacAddress = String.Empty;

            if (nics.Any())
            {
                var adapter = nics
                    .Where(p => p.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    .OrderBy(nic => nic.GetIPProperties().GetIPv4Properties().Index)
                    .FirstOrDefault() ?? nics.FirstOrDefault();

                if (adapter != null)
                {
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }

            }
            return sMacAddress;
        }     
    }

    public static class Extensions
    {
        public static IContextChannel GetChannel(this IPscService receiveService)
        {
            return ((ClientBase<IPscService>)receiveService).InnerChannel;
        }
    }    
}

//var records = CSVHelper.GetRecords<CPTModel>(CPTModel.InputFileName);
//int i = UtilityClass.GetRandomNumber(0, records.Count);
//string inputData = "";
//inputData = "CPT Code: " + records[i].CPTCode + ", Test Name: " + records[i].TestName + ", Price: " + records[i].Price;
//Console.WriteLine("CPT Records : " + inputData);
//string[] cptCodes = records[i].CPTCode.Split(' ').ToArray();

//var cellValue = (string)(excelWorksheet.Cells[10, 2] as Excel.Range).Value;
//string[] cptCodes = records[i].CPTCode.Split(' ').ToArray();



//transcription.CptCodes = new[]
//{

//    new CptCodeFastingHours()
//    {
//        //CptCodeId = getCPTId(Int32.Parse(records[i].CPTCode))
//        CptCodeId =  getCPTId(87491)
//    }
//    //new CptCodeFastingHours()
//    //{
//    //    CptCodeId = getCPTId(87591)
//    //},
//    //new CptCodeFastingHours()
//    //{
//    //    CptCodeId = getCPTId(87389)
//    //},
//    //new CptCodeFastingHours()
//    //{
//    //    CptCodeId = getCPTId(87536)
//    //}
//};





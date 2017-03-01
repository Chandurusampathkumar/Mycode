using System;
using System.IO;
using System.Linq;
using PscSoapApiAutomation.Model;
using PscSoapApiAutomation.PSC3API;
using Microsoft.Office.Interop.Excel;
using PscSoapApiAutomation.Model;
using Name = PscSoapApiAutomation.PSC3API.Name;


//@author  Fangming Lu 

namespace PscSoapApiAutomation.Scripts
{
    public class VisitHelper:TestBase

    {
        private readonly IPscService _client;

        public VisitHelper(IPscService pscService)
        {
            _client = pscService;
        }

        public Guid GetNewGuestId()
        {
            var getAddNewGuest = _client.AddNewGuest(CreateGuestBasicInfo());
            return getAddNewGuest.ResponseData;
        }
        //public Guid GetGuestId()
        //{
        //    var getFindGuestsResponse = _client.FindGuests(GetGuestSearchCriteria(), DateTime.Now);
        //    return getFindGuestsResponse.ResponseData.First().GuestId;
        //}
        //public Guid GetLabOrderId()
        //{
        //    return _client.CreateLabRequest(GetGuestId(), OrderType.DirectTestingLisTranscribed).ResponseData;
        //}

        public Guid GetProviderId()
        {
            return _client.FindProvidersByUserId().ResponseData.First().ProviderId;
        }

        public Guid GetLocationId(Guid providerId)
        {
            return _client.FindProviderLocations(providerId).ResponseData.First().Id;
        }

        public Guid GetLabOrderIdFromNewGuest(Guid guestId,bool isDirectMode)
        {
            if (isDirectMode)
            {
                return _client.CreateLabRequest(guestId, OrderType.DirectTestingPscTranscribed).ResponseData;
            }
            return _client.CreateLabRequest(guestId, OrderType.PhysicianOrderPscTranscribed).ResponseData;
        }

        //public Guid GetVisitId()
        //{
        //    var getFindGuestsResponse = _client.FindGuests(GetGuestSearchCriteria(), DateTime.Now);
        //    return getFindGuestsResponse.ResponseData.First().VisitId.Value;
        //}

        public Guid GetDoctorId(string doctorName)
        {
            return _client.FindDoctors(doctorName, null).ResponseData.First().Id;
        }

        public Guid GetNewVisitId(Guid guestId)
        {
            var getCreateGuestVistResponse = _client.CreateGuestVisit(guestId, DateTime.Now);
            return getCreateGuestVistResponse.ResponseData;
        }
        public GuestInfoState GetGuestInfoState()
        {
            var guestInfoState = new GuestInfoState
            {
                IsGuestVerified = true,
                Completed = false
            };
            return guestInfoState;
        }
        public OtherState GetOtherState()
        {
            var otherState = new OtherState
            {
                Completed = false,
                IsGttWorkFlowPending = false,
                IsSelfCheckIn = false,
                IsPendingVisitCreatedByAdmin = false
            };
            return otherState;
        }

        public LabOrderState GetLabOrderState()
        {
            var labOrderState = new LabOrderState
            {
                Completed = true,
                IsOrderTranscriptionInProgress = false,
                IsOrderTransciptionCompletedSucessfully = false,
                IsOrderTransciptionStatusNotApplicable = false,
                IsOrderTranscriptionCompletedWithError = false,
                IsOrderTranscriptionNotStarted = false
            };
            return labOrderState;
        }

        public GuestFormsState GetGuestFormsState()
        {
            var guestFormsState = new GuestFormsState
            {
                IsAcknowledgementofPrivacyPracticesFormCollected = false,
                Completed = false
            };
            return guestFormsState;
        }

        public PaymentState GetPaymentState()
        {
            var paymentState = new PaymentState
            {
                Completed = false,
                IsPaymentCollected = false
            };
            return paymentState;
        }
        public PeformState GetPeformState()
        {
            var performState = new PeformState //spelling error
            {
                Completed = false,
                CurrentDrawNumber = DrawNumber.T0,
                IsCtnSaveStepCompleted = false,
                IsVacutainerSaveStepCompleted = false,
                T0DrawUnableToCollectAllContainers = false
            }; 
            return performState;
        }

        public WorkFlowState GetWorkFlowState()
        {
            var workFlowState = new WorkFlowState
            {
                CurrentStep = WorkflowStep.GuestInfo,
                HasGuestBeenInformedOfGttInstructions = false
            };
            return workFlowState;
        }

        public ConfirmOrderState GetConfirmOrderState(bool hasDirectMode)
        {
            var confirmOrderState = new ConfirmOrderState
            {
                Completed = false,
                GttDrawType = DrawTypeSelection.VenousDraw,
                SelectedDrawType = DrawTypeSelection.VenousDraw,
                HasUserSelectedCollectionType = false,
                HasDirectTestingOrders = hasDirectMode,
                HasRedrawOrders = false,
                IsDrawTypeNotOverridable = true,
                IsGuestAdvisedOfCollectionType = false,
                StoolSelected = true,
                SwabSelected = true,
                UrineSelected = true
            };
            return confirmOrderState;
        }
        public LabOrderSummaryState GetOrderSummaryState()
        {
            var orderSummaryState = new LabOrderSummaryState
            {
                Completed = false,
                IsAbnFormCollected = false
            };
            return orderSummaryState;
        }

        public Address GetBillingAddress(Address mailingAddress)
        {
            var billingAddress = new Address
            {
                IsBillingAddress = true,
                IsMailingAddress = false,
                City = mailingAddress.City,
                State = mailingAddress.State,
                Street1 = mailingAddress.Street1,
                Street2 = mailingAddress.Street2,
                Zip = mailingAddress.Zip
            };
            return billingAddress;
        }
        public Address GetMailingAddress()
        {
            var mailingAddress = new Address
            {
                City = "Sunnyvale",
                IsMailingAddress = true,
                IsBillingAddress = false,
                Street1 = "123",
                State = "CA",
                Zip = "94086",
                Street2 = "sda ave"
            };
            return mailingAddress;
        }
        public ContactInfo GetContactInfo()
        {
            var contactInfo = new ContactInfo
            {
                IsEmergencyContact = true,
                Name = new Name() {FirstName = "Steve", LastName = "Jobs"},
                IsGuardian = true,
                Relationship = "Brother",
                Email = "test@gmail.com",
                PhoneNumber = new Phone() {Number = "1233212132", NumberType = PhoneNumberType.Mobile}
            };
            return contactInfo;
        }

        public CollectionTypeSelection GetCollectionTypeSelection()
        {
            var selection = new CollectionTypeSelection
            {
                DrawType = DrawTypeSelection.VenousDraw,
                GttDrawType = DrawTypeSelection.FingerStick,
                IsStoolSelected = true,
                IsSwabSelected = true,
                IsUrineSelected = true,
                IsDrawTypeNotOverridable = false
            };
            return selection;
        }

        public GuestBasicInfo CreateGuestBasicInfo()
        {
            var newGuest = new GuestBasicInfo
            {
                Dob = new DateTime(1991, 02, 10),
                Name = new Name {FirstName = RandomString(5), LastName = "test"}
            };
            Console.WriteLine("Patient's Name is : "+newGuest.Name.FirstName + " " + newGuest.Name.LastName );
            WriteToFile("Patient's Name is : " + newGuest.Name.FirstName + " " + newGuest.Name.LastName);
            newGuest.Email = "dasd@gmail.com";
            newGuest.ZipCode = "94085";
            newGuest.Gender = Gender.Male;
            newGuest.Phone1 = new Phone
            {
                Number = "1233212132",
                NumberType = PhoneNumberType.Mobile
            };
            return newGuest;
        }
        public string[] ReadCptCodeFromExcelFile()
        {
            var excel = new Application();
            var wb = excel.Workbooks.Open(CptModel.InputFilePath);
            Worksheet excelSheet = wb.ActiveSheet;
            string[] cptcodes = new string[excelSheet.Rows.Count];
            for (var i = 1; i < excelSheet.Rows.Count; i++)
            {
                if (excelSheet.Cells[i, 2].Value == null)
                {
                    break;
                }
                cptcodes[i-1] = excelSheet.Cells[i, 2].Value.ToString();

            }
            cptcodes = cptcodes.Where(c => c != null).ToArray();
            cptcodes.ToList().ForEach(
                    result =>
                        Console.WriteLine("Added CPT Code " + result.ToString()));
        
            cptcodes.ToList().ForEach(
                    result =>
                        WriteToFile("Added CPT Code " + result.ToString()));
            
            //string test = excelSheet.Cells[1, 1].Value.ToString();
            //string expectedPrice = excelSheet.Cells[1, 3].Value.ToString();
            //Console.WriteLine(excelSheet.Cells[1, 3].Value.ToString());
            //var cptcodes = test.Split(' ').ToArray();
            //foreach (var cptcode in cptcodes)
            //{
            //    Console.WriteLine(cptcode.Replace("  ", string.Empty));
            //}
            wb.Close();
            return cptcodes;
        }
        public CptCodeFastingHours[] GetCptCodeFastingHours(string[] cptcodes)
        {
            var cptCodeFastingHourses = new CptCodeFastingHours[cptcodes.Length];
            for (var i = 0; i < cptcodes.Length; i++)
            {
                cptCodeFastingHourses[i] = new CptCodeFastingHours()
                {
                    CptCodeId = GetCptId(cptcodes[i])
                };
            }
            return cptCodeFastingHourses;
        }
        public GuestLabOrderTranscription GetGuestLabOrderTranscription(string[] cptcodes)
        {
            var labOrderTranscription = new GuestLabOrderTranscription()
            {

                CptCodes = GetCptCodeFastingHours(cptcodes),
                OrderDate = new DateTimeOffset(new DateTime(2016, 1, 1))
            };
            return labOrderTranscription;
        }

        public GuestVisitState GetNewGuestVisitState()
        {
            var visitState = new GuestVisitState
            {
                Completed = false,
                IsCancellationRequestedInPerform = false,
                IsCancelled = false,
                IsDropOff = false,
                IsRefundOrAmountDuePendingInPerform = false
            };
            return visitState;
        }

        //public GuestSearchCriteria GetGuestSearchCriteria()
        //{
        //    var guestDob = new DateTime(1991, 02, 10);
        //    var targetGuest = new GuestSearchCriteria
        //    {
        //        FirstName = "fangming",
        //        LastName = "test",
        //        PhoneNumber = "1233211234",
        //        Dob = guestDob
        //    };
        //    return targetGuest;
        //}
        public PhysicianLabOrderTranscription GetPhysicianLabOrderTranscription(Guid doctorId, Guid locationId, Guid providerId)
        {
            var transcription = new PhysicianLabOrderTranscription
            {
                DrawType = DrawType.Unspecified,
                DoctorId = doctorId,
                LocationId = locationId,
                ProviderId = providerId,
                ShouldCcGuest = false,
                ShouldCcPhysician = false,
                StandingOrderExpiration = DateTime.Now,
                StandingOrderNumberOfTimes = 0,
                IsFastingRequired = false,
                IsStandingOrder = false,
                CcPhysicianId = null
            };

            //transcription.FastingHours = 2;
            //optional for transcription
            //transcription.FastingHours = -1;
            return transcription;
        }
        public static string RandomString(int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(CptModel.CharsForRandom, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int GetCptId(string cptCode)
        {
            return _client.FindCptCodes(cptCode).ResponseData.First().Id;
        }

        public void WriteToFile(string createText)
        {
            string path = @"C:\Users\flu\Source\Workspaces\Theranos.Test-Automation\PSC3SoapAPITesting\TestResults.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(createText + Environment.NewLine);
                    sw.Close();
                }	
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(createText + Environment.NewLine);
                    sw.Close();
                }

            }
        }







        public CptCodeFastingHours[] GetSingleCptCodeFastingHours(string cptcode)
        {
            var cptCodeFastingHourses = new CptCodeFastingHours[1];

            cptCodeFastingHourses[0] = new CptCodeFastingHours()
            {
                CptCodeId = GetCptId(cptcode)
            };

            return cptCodeFastingHourses;
        }
        public GuestLabOrderTranscription GetGuestLabOrderTranscriptionWithSingleCptCode(string cptcode)
        {
            var labOrderTranscription = new GuestLabOrderTranscription()
            {

                CptCodes = GetSingleCptCodeFastingHours(cptcode),
                OrderDate = new DateTimeOffset(new DateTime(2016, 1, 1))
            };
            return labOrderTranscription;
        }



        public string ReadSingleCptCodeFromExcelFile(int row)
        {
            var excel = new Application();
            var wb = excel.Workbooks.Open(CptModel.InputFilePath);
            Worksheet excelSheet = wb.ActiveSheet;

            string cptcode = excelSheet.Cells[row, 2].Value.ToString();

            WriteToFile("Added CPT Code " + cptcode);

            wb.Close();
            return cptcode;
        }


    }
}
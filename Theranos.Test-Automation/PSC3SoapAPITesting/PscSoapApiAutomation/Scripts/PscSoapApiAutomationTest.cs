using System;
using System.Linq;
using PscSoapApiAutomation.PSC3API;

//@Author  Fangming Lu

namespace PscSoapApiAutomation.Scripts
{
    public class PscSoapApiAutomationTest : TestBase
    {
        private IPscService _client;
        private VisitHelper _helper;

        public PscSoapApiAutomationTest()
        {
        }

        public PscSoapApiAutomationTest(IPscService client, VisitHelper helper)
        {
            _client = client;
            _helper = helper;
        }

        public void SubmitDirectModeLabOrderWithExcelPrice(Guid visitId, Guid guestId, Guid labId, GuestLabOrderTranscription labOrderTranscription)
        {
            _client.SaveVisitLogTime(visitId, DateTimeOffset.Now, VisitTimeLogType.CheckinStartTime);
            _client.UpdateContactInfo(guestId, _helper.GetContactInfo());
            _client.UpdateMailingAddress(guestId, _helper.GetMailingAddress());
            _client.UpdateBillingAddress(guestId, _helper.GetBillingAddress(_helper.GetMailingAddress()));
            _client.SubmitManualTranscriptionForGuestLabOrder(labId, guestId, labOrderTranscription);
            _client.AddLabOrderToVisit(labId, visitId);
            var getDirectModeLabOrderResponse = _client.GetLabOrderCptDetails(labId, visitId,
                CptDescriptionRequestReason.GuestRequestToReviewTestDetails);
            getDirectModeLabOrderResponse.ResponseData.ToList()
                .ForEach(
                    result =>
                        Console.WriteLine("CPT Id is " + result.CptCodeId + " , Price : " + result.Price + ", Description : " +
                                          result.Description));
        }

        public void SubmitPhysicianModeLabOrderWithExcelPrice(Guid guestId, Guid visitId, Guid labId, Guid doctorId, Guid providerId, Guid locationId, PhysicianLabOrderTranscription transcription)
        {
            _client.UpdateContactInfo(guestId, _helper.GetContactInfo());
            _client.UpdateMailingAddress(guestId, _helper.GetMailingAddress());
            _client.UpdateBillingAddress(guestId, _helper.GetBillingAddress(_helper.GetMailingAddress()));
            _client.SubmitManualTranscriptionForPhysicianLabOrder(labId, guestId, transcription);
            _client.AddLabOrderToVisit(labId, visitId);

            var getDirectModeLabOrderResponse = _client.GetLabOrderCptDetails(labId, visitId,
                CptDescriptionRequestReason.GuestRequestToReviewTestDetails);
            getDirectModeLabOrderResponse.ResponseData.ToList()
                .ForEach(
                    result =>
                        Console.WriteLine("CPT Id is "+result.CptCodeId + " , Price : " + result.Price + ", Description : " +
                                          result.Description));
            getDirectModeLabOrderResponse.ResponseData.ToList()
                .ForEach(
                    result =>
                        _helper.WriteToFile("CPT Id is " + result.CptCodeId + " , Price : " + result.Price + ", Description : " +
                                          result.Description));
            _client.GetCollectionTypesForDefaults(visitId);
            
            var getRmoveTestResponse = _client.RemoveTestsIncludedInVisitButNotAvailableAtTheranos(visitId);
            getRmoveTestResponse.ResponseData.ToList()
                .ForEach(
                    result =>
                        Console.WriteLine("Removed Test CPT Id Is : "+result.CptCodeId + " CPT Code: " + result.CptCode + ", Price : " + result.Price +
                                          "Description : " + result.ShortDescription));
            getRmoveTestResponse.ResponseData.ToList()
                .ForEach(
                    result =>
                        _helper.WriteToFile("Removed Test CPT Id Is : "+result.CptCodeId + " CPT Code: " + result.CptCode + ", Price : " + result.Price +
                                          "Description : " + result.ShortDescription));
            
        }

        public GuestVisitState FinishFormsAndUpdateVisitState(GuestVisitState visitState,Guid guestId,Guid visitId,bool isDirectMode)
        {
            //this method can explain how check-in workflow works
            var confirmOrderState = _helper.GetConfirmOrderState(isDirectMode);
            visitState.ConfirmOrderState = confirmOrderState;
            var guestFormsState = _helper.GetGuestFormsState();
            visitState.GuestFormsState = guestFormsState;
            var guestInfoState = _helper.GetGuestInfoState();
            visitState.GuestInfoState = guestInfoState;
            var labOrderState = _helper.GetLabOrderState();
            visitState.LabOrderState = labOrderState;
            var orderSummaryState = _helper.GetOrderSummaryState();
            visitState.LabOrderSummaryState = orderSummaryState;
            var otherState = _helper.GetOtherState();
            visitState.OtherState = otherState;
            var paymentState = _helper.GetPaymentState();
            visitState.PaymentState = paymentState;
            var performState = _helper.GetPeformState();
            visitState.PerformState = performState;
            var workFlowState = _helper.GetWorkFlowState();
            visitState.WorkFlowState = workFlowState;
            _client.UpdatedGuestVisitState(visitId, visitState);

            //step2
            workFlowState.CurrentStep = WorkflowStep.GuestForms;
            visitState.WorkFlowState = workFlowState;
            confirmOrderState.SelectedDrawType = DrawTypeSelection.VenousDraw;
            visitState.ConfirmOrderState = confirmOrderState;
            guestInfoState.IsGuestVerified = true;
            guestInfoState.Completed = true;
            visitState.GuestInfoState = guestInfoState;
            _client.UpdatedGuestVisitState(visitId, visitState);

            //step3
            confirmOrderState.IsGuestAdvisedOfCollectionType = true;
            guestFormsState.IsAcknowledgementofPrivacyPracticesFormCollected = true;
            guestFormsState.Completed = true;
            workFlowState.CurrentStep = WorkflowStep.ConfirmOrders;
            visitState.ConfirmOrderState = confirmOrderState;
            visitState.GuestFormsState = guestFormsState;
            visitState.WorkFlowState = workFlowState;
            _client.UpdatedGuestVisitState(visitId, visitState);

            //step4
            orderSummaryState.Completed = true;
            confirmOrderState.Completed = true;
            workFlowState.CurrentStep = WorkflowStep.Payment;
            visitState.ConfirmOrderState = confirmOrderState;
            visitState.LabOrderSummaryState = orderSummaryState;
            visitState.WorkFlowState = workFlowState;
            _client.UpdatedGuestVisitState(visitId, visitState);
            _client.UpdateCollectionTypeInfo(visitId, _helper.GetCollectionTypeSelection());
            _client.RemoveTestsIncludedInVisitButNotAvailableAtTheranos(visitId);
            _client.CheckAndRemoveChlamydiaGonorrheaSwabCollectionTestIfGuestIsUnderEighteenYears(visitId, guestId);
            _client.VisitContainsMoreThanOneDistinctGttTest(visitId);
            _client.IsGuestSignatureRequiredOnAbnForm(visitId);
            return visitState;
        }


        public void FinishCheckInFlow(GuestVisitState visitState,Guid guestId, Guid labId, Guid visitId,
            bool isDirectMode, int numberOfBarcodes,long accessionNumber)
        {
            _client.GetGttWorkflowDetails(visitId);
            _client.IsGuestSignatureRequiredOnAbnForm(visitId);
            _client.IsRequiredToCollectGuestHeightInfo(guestId, visitId);
            _client.UpdateCollectionTypeInfo(visitId, _helper.GetCollectionTypeSelection());

            //step1
            visitState = FinishFormsAndUpdateVisitState(visitState,guestId,visitId,isDirectMode);
            var paymentState = visitState.PaymentState;
            var paymentSummary = new VisitPaymentSummary();
            var getLabOrderSummaryResponse = _client.GetGuestVisitPaymentSummary(visitId, DateTimeOffset.Now);
            accessionNumber = getLabOrderSummaryResponse.ResponseData.AccessionNumber;
            Console.WriteLine("Accession Number For This Visit Is " + accessionNumber);
            _helper.WriteToFile("Accession Number For This Visit Is " + accessionNumber);

            paymentSummary.AmountPaid = getLabOrderSummaryResponse.ResponseData.AmountDue;
            _client.RegisterCashPaymentForVisit(guestId, paymentSummary);
            _client.GetVisitPaymentBarcode(visitId, getLabOrderSummaryResponse.ResponseData.AmountDue);
            _client.GetVisitPaymentBarcode(visitId, 0);
            _client.SaveCheckinTime(visitId, DateTime.Now);
            paymentState.Completed = true;
            paymentState.IsPaymentCollected = true;
            visitState.PaymentState = paymentState;
            _client.UpdatedGuestVisitState(visitId, visitState);
            var snapShot = new PaymentSummarySnapShot
            {
                GuestId = guestId,
                VisitId = visitId
            };
            _client.SavePaymentSummarySnapShot(snapShot);
            //var actualAmount = getLabOrderSummaryResponse.ResponseData.AmountDue;
            Console.WriteLine("The Amount that needs to be paid is "+getLabOrderSummaryResponse.ResponseData.AmountDue);
            _helper.WriteToFile("The Amount that needs to be paid is " + getLabOrderSummaryResponse.ResponseData.AmountDue);

            //if (expectedPrice != null)
            //{
            //    Assert.AreEqual(decimal.Parse(expectedPrice), decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero), " Expected Price Should Be $" + decimal.Parse(expectedPrice) + " , But We Got $" + decimal.Round(actualAmount, 2, MidpointRounding.AwayFromZero));
            //}
            _client.SaveVisitLogTime(visitId, DateTimeOffset.Now, VisitTimeLogType.CheckinEndTime);

        }

        public void FinishPerformFlow(GuestVisitState visitState, Guid visitId, bool isDirectMode)
        {
            _client.SaveVisitLogTime(visitId, DateTimeOffset.Now, VisitTimeLogType.PerformStartTime);
            var workFlowState = visitState.WorkFlowState;
            var performState = visitState.PerformState;

            workFlowState.CurrentStep = WorkflowStep.Perform;
            visitState.WorkFlowState = workFlowState;
            _client.UpdatedGuestVisitState(visitId, visitState);
            if (isDirectMode)
            {
                var picture = new GuestPhoto2
                {
                    VisitId = visitId,
                    ImageData = new byte[] { 0x0 }
                };
                _client.SaveGuestPicture(picture);
                _client.UpdatedGuestVisitState(visitId, visitState);
                _client.GetGuestPicture(visitId);
            }
            performState.IsPerformStarted = true;

            workFlowState.CurrentStep = WorkflowStep.PerformCollection;
            visitState.WorkFlowState = workFlowState;
            visitState.PerformState = performState;
            _client.UpdatedGuestVisitState(visitId, visitState);
            var containers = _client.GetContainersForVisit(visitId).ResponseData.Containers;
            var barcodes = _client.GetNewBarcodes(containers.Length).ResponseData;
            for (var i = 0; i < barcodes.Length; i++)
            {
                containers[i].BarcodeNumber = barcodes[i];
                containers[i].CollectionStartTime = DateTimeOffset.Now;
                containers[i].CollectionEndTime = DateTimeOffset.Now;
                _client.ValidateBarcode(barcodes[i]);
                containers[i].Status = VisitContainerStatus.Completed;
                Console.WriteLine("Container Name: " + containers[i].Metadata.Name +
                    " , Container Id : " + containers[i].Metadata.ContainerId +
                    " , Container Type: " + containers[i].Metadata.ContainerType +
                    ", Container Status : " + containers[i].Status);
                _helper.WriteToFile("Container Name: " + containers[i].Metadata.Name +
                    " , Container Id : " + containers[i].Metadata.ContainerId +
                    " , Container Type: " + containers[i].Metadata.ContainerType +
                    ", Container Status : " + containers[i].Status)
                ;
            }
            _client.SaveGuestVisitContainers(containers, visitId);
            performState.CurrentDrawNumber = DrawNumber.T1;
            performState.IsOtherContainerSaveStepCompleted = false;
            performState.IsVacutainerSaveStepCompleted = false;
            performState.T0DrawUnableToCollectAllContainers = false;
            performState.IsCtnSaveStepCompleted = false;
            visitState.PerformState = performState;
            _client.UpdatedGuestVisitState(visitId, visitState);
            _client.SaveVisitLogTime(visitId, DateTimeOffset.Now, VisitTimeLogType.PerformEndTime);
            _client.TryCompleteVisit(visitId, DateTimeOffset.Now);
            performState.IsVacutainerSaveStepCompleted = false;
            workFlowState.CurrentStep = WorkflowStep.PerformVisitSummary;
            visitState.PerformState = performState;
            visitState.WorkFlowState = workFlowState;
            _client.UpdatedGuestVisitState(visitId, visitState);

        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Theranos.Automation.PSC3.Models
{
    public class DashboardModel:PSC3Model
    {
        public const string DashboardHost_ByID = "DashboardScreen";

        public const string CheckInGuestSearchHost_ByID = "DashboardScreen.GuestSearchResults";
        public const string GuestSearchHost_ByClass = "GuestSearch";
        public const string CheckInGuestList_ByName = "Theranos.PSC.ServicesProxy.PscService.GuestSearchResult";
        public const string SearchBox_ByID = "DashboardScreen.GuestSearchResults";
        public const string LastName_ByID = "DashboardScreen.GuestSearch.LastName.Text";
        public const string LastNameHost_ByID = "DashboardScreen.GuestSearch.LastName";
        public const string FirstName_ByID = "DashboardScreen.GuestSearch.FirstName.Text";
        public const string DOB_ByID = "DashboardScreen.GuestSearch.DOB";
        public const string PhoneNo_ByID = "DashboardScreen.GuestSearch.PhoneNumber.Text";
        public const string PhoneNumberHost_ByID = "DashboardScreen.GuestSearch.PhoneNumber";
        public const string SearchButton_ByID = "DashboardScreen.GuestSearch.Search.Button";
        public const string NewGuestLink_ByID = "DashboardScreen.GuestSearchResults.AddNewGuestLink.Button";
        public const string NewGuestName_ByName = "+ ADD NEW GUEST";//TODO: AutomationId Available 
        public const string LastNameMandatory_ByName = "Last Name *";
        public const string LastNameMandatory_ByID = "WaterMark";

        public const string NewGuestName_ByID = "DashboardScreen.GuestSearchResults.AddNewGuest.Button";
      
        public const string SlideMenu_ByID = "ButtonMenu";
        public const string CurrentLocation_ByName = "Current Location";

        public const string CurrentLocation_ByID = "MainMenu.CurrentLocation.Button";

        public const string GSRLocation2 = "GSR Location2";
        public const string GSRLocation3 = "GSR Location 3";
        public const string FilterLocation_ByID="ConfigureLocationScreen.SearchLocation.Criteria.Text";
        //public const string StoreNumber_ByName = "GSR Location2";
        public const string CheckIn_ByName = "Check-In";
        public const string CheckIn_ByID = "LogoutPopup.Checkin.Checkbox";

        public const string Perform_ByName = "Perform";
        public const string Perform_ByID = "LogoutPopup.Perform.Checkbox";

        public const string ApplyLocation_ByName = "APPLY NEW LOCATION";
        public const string ApplyLocation_ByID = "LogoutPopup.ApplyLocation.Button";
        public const string PscProviderLocation_ByName = "Theranos.PSC.ServicesProxy.PscService.PscProviderLocation";

        
        public const string PerformRoomWaitingHost_ByClass = "PerformRoomWaiting";
        public const string WaitingGuestName_ByName = "Theranos.PSC.UX.Model.Dashboard.Perform.GuestPendingPerformEx";

        public const string InPerformRoomHost_ByClass = "InPerformRoom";
        public const string InPerformRoomGuestName_ByName = "Theranos.PSC.ServicesProxy.PscService.GuestInPerform";


        public const string CancelLocation_ByID = "LogoutPopup.Cancel.Button";

        public const string ActionsRequired_ByID = "ActionRequired";
        public const string GuestOrders_ByName = "Theranos.PSC.UX.Model.Dashboard.Checkin.GuestPendingCheckinActionEx";
        public const string CancelVisit_ByID = "DashboardScreen.ActionsRequired.CancelVisit.Button";
        public const string Reason_ByID = "CancelVisitPopup.SelectReason.Combobox.Combo";
        public const string Yes_ByID = "CancelVisitPopup.Yes.button";

        public const string GuestName_ByID = "CheckinStepsControl.GuestName.Label";
        public const string SignatureRequired_ByName = "Please get the guest's signature on required forms";

        public const string PrintFormsPopUp_ByClass = "PopupPrintForms";
        public const string PrintForms_ByID = "MainMenu.PrintForms.Button";
        public const string AcknowledgementofPrivacyPractices_ByName="Acknowledgement of Privacy Practices";
        public const string NoticeOfPrivacyPractices_ByName = "Notice of Privacy Practices";
        public const string ProcessRefund_ByName = "Please process refund and complete visit";
        public const string OrdersReady = "Orders Ready! Please complete the guest check-in process";

        public const string OrdersRejected_ByName = "Orders Rejected! Further action may be required";
        public const string OrdersReady_ByName = "Orders Ready! Please complete the guest check-in process";
        public const string GuestSignature_ByName = "Please get the guest's signature on required forms";
        public const string CompleteCheckIn_ByName = "Please complete check-in";
        public const string TranscriptionInProgress_ByName = "Transcription in progress...";

        public const string DirectTesting_ByName = "Direct Testing";
        public const string ManualProcessing_ByName = "Manual Processing";

        public const string PleaseCompleteAdjustment = "Please complete adjustment and check-in";

        public const string CourierPickupHost_ByClass = "PopupCourierPickup";
        public const string CourierPickButton_ByID = "MainMenu.CourierPickup.Button";
        public const string UserName_ByName = "GSR Powerperform";
        public const string ConfirmCourierMessage_ByName="Confirm the courier pickup has been completed";
        public const string Location_ByName = "GSR Location2";
        public const string ThankYou_ByName = "Thank You!";
        public const string PickupConfirmed_ByName="Your pickup has been confirmed.";

        //PerformTerminal
        public const string TempraturePopupHost_ByClass = "PopupTempLog";
        public const string RoomId_ByID = "TempLogPopup.Log.ItemsControl.0.Id.Textbox.Text";
        public const string RoomTemp_ByID = "TempLogPopup.Log.ItemsControl.0.Temperature.Textbox.Text";
        public const string RefrigeratorID_ByID = "TempLogPopup.Log.ItemsControl.1.Id.Textbox.Text";
        public const string RefrigeratorTemp_ByID = "TempLogPopup.Log.ItemsControl.1.Temperature.Textbox.Text";
        public const string Refrigerator1ID_ByID = "TempLogPopup.Log.ItemsControl.2.Id.Textbox.Text";
        public const string Refrigerator1Temp_ByID = "TempLogPopup.Log.ItemsControl.2.Temperature.Textbox.Text";
        public const string TempPopupOk_ByID = "TempLogPopup.OK.Button";
        public const string TempPopupCancel_ById = "TempLogPopup.Cancel.Button";

        public const string RefundInitiated = "Refund Initiated";
        public const string PartialRefund = "Please send the guest back to checkin for a partial refund.";
        public const string ProcessRefund= "The visit will not be completed until the refund has been processed.";
        public const string CancelVisitHost_ByID = "CancelVisitPopup.Screen";
        public const string RefundInitiatePopup_ByClass = "PopupRefundInitiated";
        public const string ReadyForCollection = "Ready for Collection";
        public const string InProgress = "In Progress";
        public const string GTTReadyForCollection = "GTT: Ready for Collection";
        public const string GTTUntilNextCollection = "Until Next Collection";
        public const string GTTExpired = "GTT: Ready for Collection (Expired, Next Collection)";
        public const string GTTSeesionExpired = "GTT: Ready for Collection (Expired)";
        public const string ScanReturnContainerHost_ByID = "ScanReturnContainer.Screen";
        public const string ScanReturnContainer_ByID = "ScanReturnContainer.Button";
        public const string ScanReturnContainerBarcode_ByID = "ScanReturnContainerBarcode.Barcode.TextBox.Text";
        public const string PerformGuestName_Name = "Theranos.PSC.UX.Model.Dashboard.Perform.GuestPendingActionInPerformEx";
        public const string PerformGuestSearchHost_ByID = "GridSearchResults";
        public const string PerformGuestList_ByName = "Theranos.PSC.UX.Model.Dashboard.Search.GuestSearchResultsInPerformEx";

        public const string InvalidBarcodeMessage_ByID = "TbMessage";
        public const string OkButton_ByID = "SystemOK.OK.Button";
        public const string ReturnContainerPopUp_ByID = "ScanReturnContainerBarcode.Screen";
        public const string ReturnContainerHost_ByID = "ReturnBarcode.BarcodeScanned.Screen";
        public const string ReturnContainerImage_ByID = "ReturnBarcode.BarcodeScanned.ContainerImage.Image";
        public const string ReturnContainerName_ByID = "ReturnBarcode.BarcodeScanned.ContainerName.Text";
        public const string ReturnContainerBarcode_ByID = "ReturnBarcode.BarcodeScanned.Barcode.Text";
        public const string ReturnContainerDate_ByID = "ReturnBarcode.BarcodeScanned.CollectionTime.Date.Text";
        public const string ReturnContainerTime_ByID = "ReturnBarcode.BarcodeScanned.CollectionTime.Time.Text";
        public const string ReturnContainerCloseButton_ByID = "ScanReturnContainerBarcode.Close.Button";
        public const string ReturnContainerUnknownCheckbox_ByID = "ReturnBarcode.BarcodeScanned.CollectionTimeUnknown.Checkbox";
        public const string ReturnContainerScannedCloseButton_ByID = "ReturnBarcode.BarcodeScanned.Close.BUtton";
        public const string ReturnContainerSubmit_ByID = "ReturnBarcode.BarcodeScanned.Submit.Button";
        public const string ReturnContainerView_ByID = "ReturnContaienrView.screen";

        
        public const string VisitReport_ByID = "MainMenu.FieldReport.Button";
        public const string VisitReport_ByName = "Visit Reports";
        public const string VisitReportListItemsHost_ByID = "VisitReportScreen";
        public const string VisitReportListItem_ByName = "Theranos.PSC.ServicesProxy.PscService.VisitReportItem";
        public const string NotStarted = "NotStarted";

        public const string AppointmentsHost_ByClass = "Appointments";
        public const string LastName = "Last Name *";
        public const string PhoneNumber = "Phone Number *";
        
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn
{
    public class ConfirmOrdersModel:PSC3Model
    {

        public const string ConfirmOrder_ByClass = "ConfirmOrders";
        public const string LabOrder_ByName = "Theranos.PSC.UX.Model.Order.PaperLabOrderEx";

        public const string ConfirmOrdersHost_ByID = "ConfirmOrders.Screen";

        public const string ActiveOrdersCheck_ByID = "ActiveOrders.SelectAll.CheckBox";      

        public const string LabOrderList_ByID = "ActiveOrders.Orders.List";
        public const string Description_ByName = "DESCRIPTION";
        public const string Description_ByID = "CheckBox";

        public const string InProgress = "In Progress";
        public const string PSCCloud = "PSC Cloud";
        public const string DirectTesting = "Direct Testing";
        public const string Standing = "Standing";

        public const string OrdersCheckBoxX_ByID = "ActiveOrders.Orders.List.$.SelectOrder.CheckBox";

        public const string GuestOrderView_ByName = "Guest requests to review test details";

        public const string CheckInformCollect = "I have informed the guest of all collection methods.";//TODO:specify it is by class or name or ID
        public const string CheckInformCollect_ByID = "CollectionType.ConfirmWithGuest.Button";
        public const string Next_ByID = "ConfirmOrders.ActiveLabOrders.Next.Button";

        public const string PendingOrders_ByID = "CollectionType.PendingOrders.Label";
        
        public const string DeleteOrder_ByName = "DELETE ORDER";
        public const string DeleteOrder_ByID = "PopupOrderDetails.Delete.Button";

        public const string SaveOrder_ByID = "PopupOrderDetails.Save.Button";

        public const string Cancel_ByID = "PopupOrderDetails.Cancel.Button";

        public const string OrderCheck_ByName = "ORDER";

        //public const string CPTCheckbox_ByClass = "CheckBox";
        public const string TestListItem_ByName = "Theranos.PSC.UX.Model.Order.CptSummaryAndDetailMerge";
        public const string TestList_ByID = "PopupOrderDetails.Screen";
       
        public const string Price_ByName = "-";

        public const string GenericLabOrder_ByClass = "GenericLabOrderEntry";

        public const string OrderDate_ByClass = "GenericLabOrderDate";
        public const string TranscribedOrderDate_ByClass = "PaperLabOrderTranscriptionStatus";

        public const string Fasting_ByClass = "GenericLabOrderFastingInstructions";
        public const string Fasting_ByID = "ActiveOrders.Orders.List.0.FastingInstructions.Control";

        public const string NoFastingRequirement_ByID = "ActiveOrders.FastingNotRequired.Label";

        public const string FastingBeforeTest_ByID = "ActiveOrders.MinimumFastingHours.Label";
        public const string FastingYes_ByID = "ActiveOrders.HasFasted.Yes.RadioButton";
        public const string FastingNo_ByID = "ActiveOrders.HasFasted.No.RadioButton";
        public const string FastingNotSure_ByID = "ActiveOrders.HasFasted.NotSure.RadioButton";

        public const string CollectionTypeHost_ByID = "FlippingControl";
        public const string ModifyPreference_ById = "CollectionType.Edit.Button";
        public const string Save_ByID = "CollectionType.Save.Button";

        public const string VenousDraw_ByName = "Venous Draw";
        public const string Fingerstick_ByName = "Fingerstick";

        public const string GTTInstructionPopup_ByID = "PopupGttInstruction";
        
        public const string GTTDone_ByID = "PopupGttInstruction.Done.Button";

        public const string HeightRequirementHost_ByID = "HeightRequirement.Popup";
        public const string FeetBox_ByID = "HeightRequirement.Feet.TextBox.Text";
        public const string InchesBox_ByID = "HeightRequirement.Inches.TextBox.Text";
        public const string HeightRequirementCancel_ByID = "HeightRequirement.Cancel.Button";
        public const string HeightRequirementDone_ByID = "HeightRequirement.Done.Button";

        public const string FastingInstruction_ByClass = "GenericLabOrderFastingInstructions";
        public const string NoFasting_ByName = "No Fasting Required";
        public const string YesFasting_ByName = "Fasting 1 Hours";

        
        //Selecting the collection type
        public const string SelectFingerstick_ByID = "CollectionType.FingerStick.RadioButton";
        public const string SelectVenousDraw_ByID = "CollectionType.VenousDraw.RadioButton";
        public const string Donotcollectblood_ByID = "CollectionType.DoNotCollectBlood.RadioButton";

        public const string UrineContainer_ByID = "CollectionType.UrineSelection.Checkbox";
        public const string SwabContainer_ByID = "CollectionType.SwabSelection.Checkbox";
        public const string StoolContainer_ByID = "CollectionType.StoolSelection.Checkbox";

        public const string Ok_ByID = "SystemOK.OK.Button";
        public const string SystemOkScreen_ByID = "SystemOK.Screen";
        public const string Message_ByID = "TbMessageDetail";
        public const string Msg_ByID = "TbMessage";
        



        //Blood Sample labels
        public const string BloodSelectionLabel_ByID = "CollectionType.BloodSelection.Label";
        public const string UrineContainerLabel_ByID = "CollectionType.UrineSelection.Label";
        public const string SwabContainerLabel_ByID = "CollectionType.SwabSelection.Label";
        public const string StoolContainerLabel_ByID = "CollectionType.StoolSelection.Label";

        public const string GoToGuestInfoPopup_ByClass = "PopupGuardianOrEmergencyContactRequired";
        public const string GoToGuestInfo_ByID = "PopupGttInstruction.Cancel.Button";
        public const string CancelVisit_ById = "PopupGttInstruction.Done.Button";
        public const string GuestInfoPage_ByID = "GuestInfoScreen.Screen";
        public const string Reason_ByID = "CancelVisitPopup.SelectReason.Combobox.Combo";
        public const string Yes_ByID = "CancelVisitPopup.Yes.button";
        public const string ActionsRequired_ByID = "ActionRequired";

    }
}

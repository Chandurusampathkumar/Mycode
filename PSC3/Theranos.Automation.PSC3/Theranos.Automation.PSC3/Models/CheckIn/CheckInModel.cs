using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn
{
    public class CheckInModel:PSC3Model
    {
        public static string[] Reasons = { "Patient Requested to cancel visit", "Patient Physically unable to complete visit", "Patient Left Service Center", "Required Specimen Container(s) unavailable", "Patient refuses to sign consent form", "Other", "RFUND" };

        public const string CancelVisit_ByName = "CANCEL VISIT";
        public const string CancelVisit_ByID = "CheckinStepsControl.CancelVisit.Command";

        public const string CancelPopup_ByClass = "PopupCancelVisit";
        public const string CancelPopup_ByID = "CancelVisitPopup.Screen";

        public const string Reason_ByID = "CancelVisitPopup.SelectReason.Combobox.Combo";

        public const string Yes_ByName = "YES";
        public const string Yes_ByID = "CancelVisitPopup.Yes.button";

        public const string No_ByID = "CancelVisitPopup.No.Button";               
      
        public const string AddLabOrder_ByName = "Add Lab Order";
        public const string NewOrder_ByID = "GuestInfo.ActiveLabOrders.ScanPaperOrders.Button";

        public const string GuestName_ByID = "CheckinStepsControl.GuestName.Label";
        public const string GuestOrders_ByName = "Theranos.PSC.UX.Model.Dashboard.Checkin.GuestPendingCheckinActionEx";

        public const string GuestInfo_ByName = "Guest Info";  
        public const string GuestForms_ByName = "Guest Forms";       
        public const string ConfirmOrders_ByName="Confirm Orders";       
        public const string Summary_ByName = "Summary";

        public const string ActiveLabOrdersList_ByID = "ActiveLabOrdersScreen.ActiveLabOrders.List";
        public const string LabOrder_ByName = "Theranos.PSC.UX.Model.Order.PaperLabOrderEx";
        public const string Fasting_ByClass = "GenericLabOrderFastingInstructions";
       
    }
}

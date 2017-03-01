using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn
{

    public class PaymentModel:PSC3Model
    {
        public const string BackToDashboard_ByName = "BACK TO DASHBOARD";
        public const string BackToDashboard_ByID = "PaymentComplete.Dashboard.Button";

        public const string DashboardHost_ByID = "DashboardScreen";

        public const string PaymentHost_ByID = "ProviderPayment.Refund.Screen";

        public const string MakeAdjustment_ByID = "PaymentComplete.MakeAdjustment.Button";
        public const string MakeAdjustmentHost_ByID = "MakeAdjustmentPopup.Screen";

        public const string FullRefund_ByName = "FULL REFUND";
        public const string FullRefund_ByID = "MakeAdjustmentPopup.FullRefund.Button";

        public const string ConfirmRefund_ByName = "Confirm Refund";
        public const string ConfirmRefund_ByID = "ProviderPayment.Refund.ConfirmRefund.Button";

        public const string Finish_ByID = "ProviderPayment.Refund.Finish.Button";
        public const string RefundComplete_ByName = "Information: Full Refund Complete";
        public const string FullRefundCompleteMsg = "TbMessage";

        public const string EditVisit_ByName = "EDIT VISIT";
        public const string EditVidit_ByID="MakeAdjustmentPopup.EndVisit.Button";

        public const string Pay_ByID = "Summary.Next.Button";

        public const string Cancel_ByID = "ProviderPayment.Refund.Cancel.Button";

        public const string PrintPaymentSummary="ProviderPayment.Refund.PrintPaymentSummary.Button";

        public const string OK_ByID = "SystemOK.OK.Button";
        public const string ScanID_ByName = "or Scan ID";

        public const string BillMeLater_ByID = "ProviderPayment.Charge.BillMeLater.CheckBox";

        public const string Amount_ByID = "ProviderPayment.Charge.AmountDue.Label";
        public const string ConfirmPayment_ByID = "ProviderPayment.Charge.ConfirmPayment.CheckBox";


    }
}

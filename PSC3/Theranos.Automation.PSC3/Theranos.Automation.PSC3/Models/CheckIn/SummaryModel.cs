using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn
{
    public class SummaryModel:PSC3Model
    {
        public const string SummaryHost_ByID = "Summary.Screen";

        public const string Insurance_ByID = "Summary.AllOrders.PaymentMethod.Insurance.RadioButton";
        public const string SelfPay_ByID = "Summary.AllOrders.PaymentMethod.SelfPay.RadioButton";

        //OrdersList 
        public const string OrdersList_ByName = "Theranos.PSC.UX.Model.Order.LabOrderSummaryEx";
        public const string OrderName_ByID = "Summary.Orders.List.0.Order.Control";
        public const string OrderDate_ByID = "Summary.Orders.List.0.OrderDate.Control";
        public const string OrderTests_ByID = "Summary.Orders.List.0.OrderTestsAndPanels.Control";
        public const string OrderInsurance_ByID = "Summary.Orders.List.0.Order.Insurance.RadioButton";
        public const string OrderSelfPay_ByID = "Summary.Orders.List.0.Order.SelfPay.RadioButton";
        public const string OrderPrice_ByID = "Summary.Orders.List.0.Order.OutOfPocket.Label";
        public const string OrderCopay_ByID = "Summary.Orders.List.0.Order.Copay.Label";

        //AmountDetails
        public const string SubTotal_ById = "Summary.SubTotal.Label";
        public const string DuplicateTestAdjustment_ByID = "Summary.DuplicateTestAdjustmentAmount.Label";
        public const string CappedPricingAdjustment_ByID = "Summary.CappedPricingAdjustmentAmount.Label";
        public const string PanelPricingAdjustment_ByID = "Summary.RegularPanelDiscount.Label";
        public const string AmountDue_ByID = "Summary.AmountDue.Label";

        public const string Pay_ByName = "PAY"; //TODO: AutomationId Available 
        public const string Pay_ByID = "Summary.Next.Button";
        public const string BackButton_ByID = "Summary.Back.Button";

        public const string PaymentChangeScreen_ByID = "ProviderPayment.Charge.Screen";

        public const string ConfirmPayment_ByName = "Confirm Payment";
        public const string ConfirmPayment_ByID = "ProviderPayment.Charge.ConfirmPayment.CheckBox";

        public const string BillMeLater_ByID = "ProviderPayment.Charge.BillMeLater.CheckBox";

        public const string Finish_ByID = "ProviderPayment.Charge.Next.Button";
        public const string PaymentComplete_ByName = "Check-in Complete";
        public const string ChargeAmount_ByName = "1. Charge Amount";

        public const string PrintPaymentSummary_ByName = "PRINT PAYMENT SUMMARY";
        public const string PrintPaymentSummary_ByID = "Summary.PrintPaymentSumamry.Button";

        //Payment Page
        public const string PrintPayment_ByID = "ProviderPayment.Charge.PrintPaymentSummary.Button";

        //ABN Form
        public const string ABNPrintFormPopUp_ByID = "PopupABNRequired.Screen";
        public const string ABNFormNext_ByID = "PopupABNRequired.Next.Buttton";
        public const string ABNFormCancel_ByID = "PopupABNRequired.Cancel.Buttton";
        public const string ABNPrintForm_ByID = "PopupABNRequired.PrintABN.Button";

        public const string ScanABNForm_ByID = "ScanPaperOrder.Scan.Button";
        public const string ScanABNFormNext_ByID = "ScanABNForm.Next.Button";
        public const string ScanABNFormBcack_ByID = "ScanABNForm.Back.Button";

        public const string ABNDoneButton_ByID = "PopupAbn.Done.Button";
        public const string ABNBackButton_ByID = "PopupAbn.Back.Button";

        public const string STIPrice_ByID = "$59.95";


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class AddLabOrderModel : PSC3Model
    {

        //General
        public const string ActiveLabOrders_ByClass = "ActiveLabOrdersHost";
        public const string ActiveLabOrders_ByID = "ActiveLabOrders.Screen";
        public const string ActiveLabOrdersList_ById = "ActiveLabOrdersScreen.ActiveLabOrders.List";
        public const string Next_ByID = "GuestInfo.ActiveLabOrders.Next.Button";
        public const string OrderTranscriptionHost_ByID = "OrderTranscriptionScreen";
        public const string ScannedPaperOrderScreen_ByID = "ScanPaperOrder.Screen";

        public const string DirectTesting = "Direct Testing";
        public const string SystemHost_ByID = "SystemOK.Screen";
        public const string SystemOk_ByID = "SystemOK.OK.Button";

        //Page 1
        public const string SendTranscription_ByName = "SEND FOR TRANSCRIPTION";
        public const string SendTranscription_ByID = "ActiveLabOrders.SendForTranscription.Button";

        public const string ManualTranscription_ById = "ManualTranscriptionImage";

        public const string ClinicianOrder_ByName = "Clinician Order";
        public const string ClinicianOrder_ByID = "ActiveLabOrders.SelfTranscribeCommand.Button";

        public const string DirectTesting_ByName = "Direct Testing";
        public const string DirectTesting_ByID = "ActiveLabOrders.SelfTranscribeCommand.Button";


        //Page 2
        public const string Scan_ByName = "SCAN";
        public const string Scan_ByID = "ScanPaperOrder.Scan.Button";

        //Send for Transcription
        public const string StartTranscription_ByID = "AddOrder.GuestOrder.AutoTranscribedOrder.NextPage.Button";
        public const string SendForTranscriptionCancelOrderTranscription_ByID = "AddOrder.GuestOrder.AutoTranscribedOrder.CancelOrder.Button";

        //Clinician Page1
        public const string CancelTranscription_ByName = "CANCEL TRANSCRIPTION";
        public const string ClinicianScanCancelTranscription_ByID = "TranscriptionPage1.CancelTranscription.Button";
        public const string ClinicianScanSumbitForTranscription_ByID = "TranscriptionPage1.SubmitForTranscription.Button";
        public const string ClinicianNextButton_ByID = "TranscriptionPage1.Next.Button";

        //Clinician Page2
        public const string ClinicianDetailCancelTranscription_ByID = "TranscriptionPage2.CancelTranscription.Button";
        public const string ClinicianDetailSubmitForTranscription_ByID = "TranscriptionPage2.SubmitForTranscription.Button";
        public const string ClinicianDetailsNextButton_ByID = "TranscriptionPage2.Next.Button";
        public const string BackButton_ByID = "TranscriptionPage2.Back.Button";

        //Clinician page3
        public const string ClinicianTestCancelTranscription_ByID = "TranscriptionPage3.CancelTranscription.Button";
        public const string ClinicianTestSubmitForTranscription_ByID = "TranscriptionPage3.SubmitForTranscription.Button";
        public const string ClinicianSave_ByID = "TranscriptionPage3.Save.Button";

        public const string NewOrder_ByID = "GuestInfo.ActiveLabOrders.ScanPaperOrders.Button";

        public const string LabOrders_ByName = "Theranos.PSC.UX.Model.Order.PaperLabOrderEx";
        public const string LabOrderDate_ByClass = "GenericLabOrderDate";
        public const string OkButton_ByID = "SystemOK.OK.Button";

        public const string SubmitForTranscription_ByName = "submit for transcription";//TODO: AutomationId Available for directing only and not available for Clinician Order

        //Direct Testing 
        public const string DirectTestingSubmitForTranscription_ByID = "AddOrder.GuestOrder.GuestOrderPage1.SubmitForTranscription.Button";
        public const string NextButtonDirect_ByID = "AddOrder.GuestOrder.GuestOrderPage1.NextPage.Button";
        public const string DirectTestingCancelOrder_ByID = "AddOrder.GuestOrder.GuestOrderPage1.CancelOrder.Button";
    }
}

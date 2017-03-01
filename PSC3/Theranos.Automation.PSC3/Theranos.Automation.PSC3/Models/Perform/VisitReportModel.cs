using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform
{
    public class VisitReportModel:PSC3Model
    {
        public const string ComboBox_ByID = ".Combo";
        public const string VisitReportHost_ByID = "VisitReportHost.Screen";
        public const string ITIssueHost_ByID = "VisitReportHost.ItIssues.Control";
        public const string ITIssuesYes_ByID = "VisitReportHost.ItIssues.Control.Yes.RadioButton";
        public const string ITIssueNo_ByID = "VisitReportHost.ItIssues.Control.No.RadioButton";
        public const string ITIssueCancelX_ByID = "VisitReportHost.ItIssues.Control.ReportedIssues.ItemsControl.$.CancelReportedIssue.Button";
        public const string ITIssueReasonX_ByID = "VisitReportHost.ItIssues.Control.ReportedIssues.ItemsControl.$.ReportedIssue.Label";
        public const string ITIssueCombobox_ByID = "VisitReportHost.ItIssues.Control.Issues.Combobox";
        public const string ITIssueRemove_ByID = "VisitReportHost.ItIssues.Control.RemoveOtherIssues.Button";
        public const string ITIssueOtherReason_ById = "VisitReportHost.ItIssues.Control.OtherIssues.Textbox.Text";

        public const string ApplicationIssueHost_ByID = "VisitReportHost.ApplicationReported.Control";
        public const string ApplicationIssuesYes_ById = "VisitReportHost.ApplicationReported.Control.Yes.RadioButton";
        public const string ApplicationIssueNo_ByID = "VisitReportHost.ApplicationReported.Control.No.RadioButton";
        public const string ApplicationIssueCancelX_ByID = "VisitReportHost.ApplicationReported.Control.ReportedIssues.ItemsControl.$.CancelReportedIssue.Button";
        public const string ApplicationIssueReasonX_ByID = "VisitReportHost.ApplicationReported.Control.ReportedIssues.ItemsControl.$.ReportedIssue.Label";
        public const string ApplicationIssueCombobox_ByID = "VisitReportHost.ApplicationReported.Control.Issues.Combobox";
        public const string ApplicationIssueRemove_ByID = "VisitReportHost.ApplicationReported.Control.RemoveOtherIssues.Button";
        public const string ApplicationIssueOtherReason_ByID = "VisitReportHost.ApplicationReported.Control.OtherIssues.Textbox.Text";

        public const string CustomerSupportIssueHost_ByID = "VisitReportHost.CustomerSupportIssues.Control";
        public const string CustomerSupportIssuesYes_ByID = "VisitReportHost.CustomerSupportIssues.Control.Yes.RadioButton";
        public const string CustomerSupportIssueNo_ByID = "VisitReportHost.CustomerSupportIssues.Control.No.RadioButton";
        public const string CustomerSupportIssueCancelX_ByID = "VisitReportHost.CustomerSupportIssues.Control.ReportedIssues.ItemsControl.$.CancelReportedIssue.Button";
        public const string CustomerSupportIssueReasonX_ByID = "VisitReportHost.CustomerSupportIssues.Control.ReportedIssues.ItemsControl.$.ReportedIssue.Label";
        public const string CustomerSupportIssueCombobox_ByID = "VisitReportHost.CustomerSupportIssues.Control.Issues.Combobox";
        public const string CustomerSupportIssueRemove_ByID = "VisitReportHost.CustomerSupportIssues.Control.RemoveOtherIssues.Button";
        public const string CustomerSupportIssueOtherReason_ByID = "VisitReportHost.CustomerSupportIssues.Control.OtherIssues.Textbox.Text";

        public const string WaitTimeIssueHost_ByID = "VisitReportHost.WaitTimeReportedIssues.Control";
        public const string WaitTimeIssueYes_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.Yes.RadioButton";
        public const string WaitTimeIssueNo_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.No.RadioButton";
        public const string WaitTimeIssueCancelX_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.ReportedIssues.ItemsControl.$.CancelReportedIssue.Button";
        public const string WaitTimeIssueReasonX_ById = "VisitReportHost.WaitTimeReportedIssues.Control.ReportedIssues.ItemsControl.$.ReportedIssue.Label";
        public const string WaitTimeIssueCombobox_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.Issues.Combobox";
        public const string WaitTimeIssueRemove_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.RemoveOtherIssues.Button";
        public const string WaitTimeIssueOtherReason_ByID = "VisitReportHost.WaitTimeReportedIssues.Control.OtherIssues.Textbox.Text";

        public const string NeedlesUsedHost_ByID = "VisitReportHost.NeedleCountIssue.Control";
        public const string NeedlesUsedCombobox_ByID = "VisitReportHost.NeedleCountIssue.Control.NumberUsed.Combobox";
        public const string NeedlesUsedCancelX_ByID = "VisitReportHost.NeedleCountIssue.Control.ReportedIssues.ItemsControl.$.CancelReportedIssue.Button";
        public const string NeedlesUsedReasonsCombobox_ById = "VisitReportHost.NeedleCountIssue.Control.Issues.Combobox";
        public const string NeedlesUsedOtherReason_ByID = "VisitReportHost.NeedleCountIssue.Control.OtherIssue.Textbox.Text";

        public const string GuestName_ByID = "VisitReportStepsControl.GuestName.Label";
        public const string GuestDOB_ByID = "VisitReportStepsControl.DateOfBirth.TextBlock";

        public const string VisitSummary_ByID = "VisitReportHost.VisitSummary.TextBox";
        public const string Save_ByID = "VisitReportHost.Save.Button";
        public const string Complete_ByID = "VisitReportHost.Complete.Button";


        //IT issue reasons
        public const string ITReason1 = "Login issue";
        public const string ITReason2 = "Printer not defaulted correctly";
        public const string ITReason3 = "Printer out of paper / toner";
        public const string ITReason4 = "Printer unplugged / off";
        public const string ITReason5 = "Slow connectivity";
        public const string ITReason6 = "System outage";
        public const string ITReason7 = "Other";


        //Application Issue reason
        public const string AppReason1="Error message";
        public const string AppReason2="Incorrect information / instructions prompted";
        public const string AppReason3="Login issue";
        public const string AppReason4="Scanning issue";
        public const string AppReason5="Slow application";
        public const string AppReason6="WAG Tech uncomfortable with PSC application";
        public const string AppReason7 = "Other";

        //Customersupport issue reason
        public const string CustomerReason1="Confusion on issue with CS";
        public const string CustomerReason2="CS not answering phone";
        public const string CustomerReason3="CS providing incorrect info";
        public const string CustomerReason4="Order not in system";
        public const string CustomerReason5 = "Other";

        //Waittime issue
        public const string WaitReason1="Previous guest in perform";
        public const string WaitReason2="Shared space being utilized by WAG";
        public const string WaitReason3="Short staffing (Theranos)";
        public const string WaitReason4="Short staffing (WAG)";
        public const string WaitReason5 = "Other";

        //Needles reason
        public const string NeedleReason1="Blood Flow Stopped";
        public const string NeedleReason2="Flash Only";
        public const string NeedleReason3="Guest dehydrated";
        public const string NeedleReason4="Guest insists on particular vein / spot";
        public const string NeedleReason5="Guest lacks viable veins";
        public const string NeedleReason6="Improper anchoring of needle";
        public const string NeedleReason7="Improper use of tourniquet";
        public const string NeedleReason8="Incorrect collection container";
        public const string NeedleReason9="No Flash";
        public const string NeedleReason10="Not anchoring vein";
        public const string NeedleReason11="Pediatric/special needs/etc.";
        public const string NeedleReason12="Poor vein selection";
        public const string NeedleReason13="Rushing through procedure";
        public const string NeedleReason14="Vein rolled / collapsed";
        public const string NeedleReason15 = "Other";
    }
}

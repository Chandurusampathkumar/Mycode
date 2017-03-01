using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class OrderInstructionsModel:PSC3Model
    {
        public const string InputFileName="OrderInstructionsDataSet.csv";

        public const string OrderInstructionsHost_ByID = "OrderingInstructions.Screen";

        public const string FastingRequiredYes_ByID = "OrderingInstructions.FastingRequired.RadioButton";
        public const string FastingRequiredNo_ByID = "OrderingInstructions.FastingNotrequired.RadioButton";
        public const string FastingHours_ByID = "OrderingInstructions.FastingHours.Textbox.Text";
        public const string FastingUnspecified_ByID = "OrderingInstructions.UnspecifiedFastingHours.Checkbox";
        public const string StandingOrderYes_ByID = "OrderingInstructions.StandingOrderYes.RadioButton";
        public const string StandingOrderRecurrence_ByID = "OrderingInstructions.StandingOrderRecurrence.TextBox.Text";
        public const string StandingOrderFrequency_ByID = "OrderingInstructions.StandingOrderFrequency.ComboBox.Combo";
        public const string Date_ByID = "OrderingInstructions.StandingOrderExpirationDate.TextBox.Text";
        public const string VenousCollection_ByID = "OrderingInstructions.CollectionTypeVenousDraw.RadioButton";
        public const string FingerStickCollection_ByID = "OrderingInstructions.CollectionTypeFingerStick.RadioButton";
        public const string UnSpecifiedCollection_ByID = "OrderingInstructions.CollectionTypeUnspecified.RadioButton";

        public const string UnspecifiedHours_ByID = "OrderingInstructions.UnspecifiedFastingHours.Checkbox";
        public const string FastingHours8_ByID = "OrderingInstructions.FastingOptions.ItemsControl.0.FastingOption.Button";
        public const string FastingHours10_ByID = "OrderingInstructions.FastingOptions.ItemsControl.1.FastingOption.Button";
        public const string FastingHours12_ByID = "OrderingInstructions.FastingOptions.ItemsControl.2.FastingOption.Button";
        public const string FastingHoursCustom_ByID = "OrderingInstructions.FastingOptions.ItemsControl.3.FastingOption.Button";
        public const string FastingHoursEdit_ByID = "OrderingInstructions.FastingHours.TextBox";        
        public const string ClinicianDetailsNextButton_ByID = "TranscriptionPage2.Next.Button";
        
        public const string Day_ByName = "Day";
        public const string Week_ByName = "Week";
        public const string Month_ByName = "Month";
        public const string Unknown_ByName = "Unknown";

        public const string Venous = "Venous";
        public const string Fingerstick = "Fingerstick";

        public string IsFastingRequired { get; set; }
        public string FastingHours { get; set; }
        public string IsStandingOrder { get; set; }
        public string StandingOrderRecurrence { get; set; }
        public string StandingOrderFrequency { get; set; }
        public string CollectionType { get; set; }



    }
}

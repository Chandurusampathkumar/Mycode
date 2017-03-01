using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform
{
    public class PerformModel:PSC3Model
    {
        public const string VerifyIdentifiationHost_ByID = "VerifyIdentification.Screen";
        public const string CancelVisit_ByID = "CheckinStepsControl.CancelVisit.Command";
        public const string Reason_ByID = "CancelVisitPopup.SelectReason.Combobox.Combo";
        public const string Yes_ByID = "CancelVisitPopup.Yes.button";
        public const string PerformHost_ByID = "CheckinStepsControl.Screen";
        public const string GuestName_ByID = "CheckinStepsControl.GuestName.Label";
        public const string GuestDOB_ByID = "CheckinStepsControl.DateOfBirth.TextBlock";
        public const string GuestGender = "CheckinStepsControl.Gender.TextBlock";
        public const string GuestEmail_ByID = "CheckinStepsControl.Email.TextBlock"; 
        public const string Start_ByID = "StartCentrifuge.Start.Button";
        public const string RemindMeLater_ByID = "StartCentrifuge.RemindMeLater.Button";

        public const string InProgress = "In Progress";

        public const string ReturnContainerHost_ByID = "ReturnContaienrView.screen";
        public const string ReturnContainer_ByID = "PerformSearchResults.List.0.ReturnContainer.Button";
        public const string Barcode_ByID = "ReturnContainerScreen.EnterManualBarcode.TextBox.Text";
        public const string ReturnContainerLists_ByName = "Theranos.PSC.UX.Model.Perform.ReturnContainerEx";
        public const string ContainerReturnedX_ByID = "ReturnContainerScreen.ReturnContainerList.ItemsControl.0.ReturnContaienrScreen.ReturnedStatus.Label";
        public const string ScannedBarcodeX_ByID = "ReturnContainerScreen.ReturnContainerList.ItemsControl.0.ReturnContaienrScree.ScannedBarcode.Label";
        public const string ContainerReturned = "Container Returned";


        //GTT
        public const string GlucoseDrinkHost_ByID = "GlucoseDrink.Screen";

        public const string GlucoseDrinkMessage_ByID="GlucoseDrinkScreen.DrinkMessage.TextBlock";
        
        public const string GlucoseDrinkNextButton_ByID = "GlucoseDrinkScreen.Next.Button";
        public const string GlucoseDrinkBackButton_ByID = "GlucoseDrinkScreen.Back.Button";
        
        public const string GTTTimerNextButton_ByID = "StartGttTimer.Next.Button";
        public const string GTTTimerBackButton_ByID = "StartGttTimer.Back.Button";

        public const string GTTTimerHost_ByID = "StartGttTimer.Screen";
        public const string GTTStarttime_ByID = "StartGttTimer.ReturnText.TextBlock";


        public const string GTT1Hour = "Drink 50g of Glucose Drink";
        public const string GTT2Hour = "Drink 75g of Glucose Drink";
        public const string GTT3Hour="Drink 100g of Glucose Drink";



    }
}

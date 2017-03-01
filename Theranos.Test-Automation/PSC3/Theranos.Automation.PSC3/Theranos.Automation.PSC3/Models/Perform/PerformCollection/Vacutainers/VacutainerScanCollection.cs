using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers
{
    public class VacutainerScanCollection:PerformModel
    {
        public const string VacutainerScanCollectionHost_ByClass = "PerformVacutainerScan";
        public const string VacutainerScanCollectionHost_ByID = "VacutainerScan.Screen";

        public const string VacutainersScanCollectionList_ByName = "Theranos.PSC.UX.Model.Perform.VisitContainerEx";

        //List1
        public const string VacutainersScanCollectionImageX_ByID = "VacutainerScan.ItemsControl.$.ContainerImage.Image";
        public const string VacutainersScanColectionNameX_ByID = "VacutainerScan.ItemsControl.$.ContainerName.Text";
        public const string VacutainersScanCollectionPleaseScanX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.PleaseScan.Label";
        public const string VacutainersScanCollectionBarcodeX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.BarcodeEntry.TextBox.Text";
        public const string VacutainersScanCollectionBarcodeErrorX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.BarcodeEntry.TextBox.ErrorMessage.Text";
        public const string VacutainersScanCollectionFlagButtonX_ByID = "VacutainerScan.ItemsControl.$.SamplecollectionIncomplete.Button";
        public const string VacutainerScanCollectionUnableToCollectX_ByID = "SampleCollectIncompleteMenu.SampleCollectIncompleteReason.ListBox.$.SampleCollectIncompleteReason.UnableToCollect.Button";
        public const string VacutainersScanCollectionRescanX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.Rescan.Button";
        public const string VacutainersScanCollectionEnteredBarcodeX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.EnteredBarcodeNumber.Text";
        public const string VacutainersScancollectionErrorMessageX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.ErrorMessage.Label";
        public const string VacutainersScanCollectionUnableToCollectMessageX_ByID = "VacutainerScan.ItemsControl.$.ContentControl.UnableToCollect.Label";
        public const string UnableToCollect = "Unable to Collect";

        public const string LightBlueTopScanCollectionInstruction_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.Instruction.Text";
        public const string GoldTopScanCollectionInstruction_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.ClotInstruction.Text";
        public const string QFTTopScanCollectionInstructionX_ByID = ".QFTInstruction.Text";
        public const string LavenderTopTBNKScanCollectionInstruction_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.Instruction.Text";
        public const string LavenderTopScanCollectionInstruction_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.PlaceInRefrigerator.Text";
        public const string PearlTopScanCollectionInstruction_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.PlaceInCentrifuge.Text";
        public const string TanTopScanCollection_ByID = "VacutainerScan.ItemsControl.0.ContentControl.PostScanInstructiosn.ContentControl.Instruction.Text";

        public const string StoreInRoomTemprature = "Store in Room Temperature.";
        public const string ColtFor15To30Minutes = "1. Clot for 15-30 Min.\r\n2. Then, place into Centrifuge.";
        public const string QFTTubes = "Store all 3 QFT tubes together, in a separate bag from other specimens.\r\nStore at Room Temperature.";
        public const string PlaceIntoCentrifuge = "Place into Centrifuge.";
        public const string PlaceIntoRefrigerator = "Place into Refrigerator.";

        public const string VacutainersScanCollectionNext_ByID = "VacutainerScanScreen.Next.Button";
        public const string VacutainersScancollectionBack_ByID = "VacutainersScanScreen.Back.Button";

        public const string VacutainersStartCentrifuge_ByID = "StartCentrifuge.Start.Button";
        public const string VacutainersRemindMeLater_ByID = "StartCentrifuge.RemindMeLater.Button";

        public const string VacutainersScanCollectionSpecHandlErrMsg_ByID = "VacutainerScan.ItemsControl.$.ContentControl.PostScanInstructiosn.ContentControl.ShowCourierNotification.Button";
        public const string SpecialHandlingWind_ByClass = "PopupCourierNotification";

    }
}

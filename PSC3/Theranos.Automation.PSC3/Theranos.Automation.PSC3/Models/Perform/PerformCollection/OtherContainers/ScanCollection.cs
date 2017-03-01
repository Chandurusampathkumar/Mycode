using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.PSC3.Models.Perform;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers
{
    public class ScanCollection:PerformModel
    {
        public const string OtherContainersScanCollectionHost_ByID = "PerformOtherContainersScan.Screen";
        public const string ScanCollectionOtherContainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitContainerEx";
        //PrepareContainers.ContainerUrineKit ,PrepareContainers.Container24HourUrineKit,PrepareContainers.ContainerSwabKit,PrepareContainers.ContainerStoolCard1,PrepareContainers.ContainerStoolCard3
        //public List<string> ReturnContinerEnabled=
   

        //List1
        public const string OtherContainersImageX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContainerImage.Image";
        public const string OtherContainersNameX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContainerName.Text";
        public const string OtherContainersPleaseScanX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.PleaseScan.Text";
        public const string OtherContainersBarCodeX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.EnterBarcode.TextBox.Text";
        public const string OtherContainersBarCodeErrorX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.EnterBarcode.TextBox.ErrorMessage.Text";
        public const string OtherContainersRescanX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.Rescan.Button";
        public const string OtherContainersEnteredBarcodeX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.EnteredBarcode.Text";
        public const string OtherContainersReadyForGuestX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.ReadyForGuest.Text";
        public const string OtherContainersFlagX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.SamplecollectionIncomplete.Button";
        public const string OtherContainerUnableToCollectButtonX_ByID = "SampleCollectIncompleteMenu.SampleCollectIncompleteReason.ListBox.$.SampleCollectIncompleteReason.UnableToCollect.Button";
        public const string OtherContainersUnableToCollectX_ByID = "PerformOtherContainersScan.OtherContainers.List.0.ContentControl.UnableToCollect.Text";
        public const string OtherContainersScanErrorX_ByID = "PerformOtherContainersScan.OtherContainers.List.$.ContentControl.ScanError.Text";
        public const string UnableToCollect = "Unable to Collect";
        public const string ReadyForGuest = "Ready for guest.";

        public const string UrineKit = "Urine Collection Kit";
        public const string SwabKit = "Swab Kit";
        public const string UrineKit24 = "24 Hour Urine Kit";
        ////List2
        //public const string OtherContainersImage1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContainerImage.Image";
        //public const string OtherContainersName1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContainerName.Text";
        //public const string OtherContainersPleaseScan1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.PleaseScan.Text";
        //public const string OtherContainersBarCode1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.EnterBarcode.TextBox.Text";
        //public const string OtherContainersBarCodeError1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.EnterBarcode.TextBox.ErrorMessage.Text";
        //public const string OtherContainersRescan1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.Rescan.Button";
        //public const string OtherContainersEnteredBarcode1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.EnteredBarcode.Text";
        //public const string OtherContainersReadyForGuest1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.ContentControl.ReadyForGuest.Text";
        //public const string OtherContainersFlag1_ByID = "PerformOtherContainersScan.OtherContainers.List.1.UnableToCollect.Button";

        ////List3
        //public const string OtherContainersImage2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContainerImage.Image";
        //public const string OtherContainersName2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContainerName.Text";
        //public const string OtherContainersPleaseScan2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.PleaseScan.Text";
        //public const string OtherContainersBarCode2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.EnterBarcode.TextBox.Text";
        //public const string OtherContainersBarCodeError2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.EnterBarcode.TextBox.ErrorMessage.Text";
        //public const string OtherContainersRescan2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.Rescan.Button";
        //public const string OtherContainersEnteredBarcode2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.EnteredBarcode.Text";
        //public const string OtherContainersReadyForGuest2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.ContentControl.ReadyForGuest.Text";
        //public const string OtherContainersFlag2_ByID = "PerformOtherContainersScan.OtherContainers.List.2.UnableToCollect.Button";

        public const string OtherContainersScanBackButton_ById = "GuestInfo.ActiveLabOrders.Back.Button";
        public const string OtherContainersScanNextButton_ByID = "GuestInfo.ActiveLabOrders.Next.Button";
    }
}

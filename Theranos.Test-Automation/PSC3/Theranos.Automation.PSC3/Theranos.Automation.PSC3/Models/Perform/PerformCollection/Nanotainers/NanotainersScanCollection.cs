using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Nanotainers
{
    public class NanotainersScanCollection:PerformModel
    {
        public const string NanotainersPostscanHost_ByID = "NanotainersPostScan.Screen";
        public const string PostscanNanotainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitNanotainerEx";


        public const string NanotainersPostscanImageX_ByID = "NanotainersPostScan.ContainerList.List.$.ContainerImage.Image";
        public const string NanotainersPostscanNameX_ByID = "NanotainersPostScan.ContainerList.List.$.ContainerName.Image";
        public const string NanotainersPostscanPleasescanX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.PleaseScan.Text";
        public const string NanotainersPostscanBarcodeX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.EnterBarcode.TextBox.Text";
        public const string NanotainersPostScanEnteredBarCodeX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.PostScanInstructionsOne.Text";
        public const string NanotainersPostscanErrorMessageX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.ErrorMessage.Text";
        public const string NanotainersPostscanPlaceintoCentrifugeX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.PostScanInstructionsOne.Text";
        public const string NanotainersPostscanPlaceintoRefrigeratorX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.PostScanInstructionsTwo.Text";
        public const string NanotainersPostscanFlagX_ByID = "NanotainersPostScan.ContainerList.List.$.FlagUnableToCollect.Button";
        public const string NanotainersPostscanUnableToCollectX_ByID = "NanotainersPostScan.ContainerList.List.$.ContentControl.UnableToCollect.Text";
        public const string UnableToCollect = "Unable to Collect";
        public const string PlaceInRefrigerator = "Place into Refrigerator.";
        public const string PlaceInCentrifuge = "Place into Centrifuge.";

        ////List1
        //public const string NanotainersPostscanImage_ByID = "NanotainersPostScan.ContainerList.List.0.ContainerImage.Image";
        //public const string NanotainersPostscanName_ByID = "NanotainersPostScan.ContainerList.List.0.ContainerName.Image";
        //public const string NanotainersPostscanPleasescan_ByID = "NanotainersPostScan.ContainerList.List.0.ContentControl.PleaseScan.Text";
        //public const string NanotainersPostscanBarcode_ByID = "NanotainersPostScan.ContainerList.List.0.ContentControl.EnterBarcode.TextBox.Text";
        //public const string NanotainersPostscanBarcodeError_ByID = "NanotainersPostScan.ContainerList.List.0.ContentControl.EnterBarcode.TextBox.ErrorMessage.Text";
        //public const string NanotainersPostscanPlaceintoCentrifuge_ByID = "NanotainersPostScan.ContainerList.List.0.ContentControl.PostScanInstructionsOne.Text";
        //public const string NanotainersPostscanPlaceintoRefrigerator_ByID = "NanotainersPostScan.ContainerList.List.0.ContentControl.PostScanInstructionsTwo.Text";
        //public const string NanotainersPostscanFlag_ByID = "NanotainersPostScan.ContainerList.List.0.FlagUnableToCollect.Button";

        ////List2
        //public const string NanotainersPostscanImage1_ByID = "NanotainersPostScan.ContainerList.List.1.ContainerImage.Image";
        //public const string NanotainersPostscanName1_ByID = "NanotainersPostScan.ContainerList.List.1.ContainerName.Image";
        //public const string NanotainersPostscanPleasescan1_ByID = "NanotainersPostScan.ContainerList.List.1.ContentControl.PleaseScan.Text";
        //public const string NanotainersPostscanBarcode1_ByID = "NanotainersPostScan.ContainerList.List.1.ContentControl.EnterBarcode.TextBox.Text";
        //public const string NanotainersPostscanBarcodeError1_ByID = "NanotainersPostScan.ContainerList.List.1.ContentControl.EnterBarcode.TextBox.ErrorMessage.Text";
        //public const string NanotainersPostscanPlaceintoCentrifuge1_ByID = "NanotainersPostScan.ContainerList.List.1.ContentControl.PostScanInstructionsOne.Text";
        //public const string NanotainersPostscanPlaceintoRefrigerator1_ByID = "NanotainersPostScan.ContainerList.List.1.ContentControl.PostScanInstructionsTwo.Text";
        //public const string NanotainersPostscanFlag1_ByID = "NanotainersPostScan.ContainerList.List.1.FlagUnableToCollect.Button";

        public const string NewBarCodeConfirm_ByID = "SystemConfirmation.Confirm.Button";
        public const string NewBarCodeCancel_ByID = "SystemConfirmation.Cancel.Button";

        public const string NewContainerScanPopupOkButton_ByID = "OkButton";//new ID needed
        public const string NewContainerScanPopupCancelButton_ByID = "CancelButton";//new ID needed

        public const string NanotainersPostscanNextButton_ByID = "NanotainersPostScan.Next.Button";
        public const string NanotainersPostscanBackButton_ByID = "NanotainersPostScan.Back.Button";       
    }
}

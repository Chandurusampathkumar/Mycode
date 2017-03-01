using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Nanotainers
{
    public class PrescanNanotainers:PerformModel
    {
        public const string PrescanHost_ByID = "NanotainersPreScan.Screen";
        public const string NanotainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitNanotainerEx";
        public const string NanotainerGreen = "Nanotainer (Green)";
        public const string NanotainerPurple = "Nanotainer (Purple)";

        public const string NanotainerPurpleInvalidBarCodeErrorMessage = "Please scan a valid Purple Nanotainer barcode.";
        public const string NanotainerGreenInvalidBarCodeErrorMessage = "Please scan a valid Green Nanotainer barcode.";


        public const string NanotainersPrescanImageX_ByID = "NanotainerPreScan.Containers.List.$.ContainerImage.Image";
        public const string NanotainersPrescanNameX_ByID = "NanotainerPreScan.Containers.List.$.ContainerName.Text";
        public const string NanotainersPrescanPleaseScanX_ByID = "NanotainerPreScan.Containers.List.$.ContentControl.PleaseScan.Text";
        public const string NanotainersPrescanBarcodeX_ByID = "NanotainerPreScan.Containers.List.$.ContentControl.EnterBarcodeNumber.TextBox.Text";
        public const string NanotainersPrescanBarcodeErrorX_ByID = "NanotainerPreScan.Containers.List.$.ContentControl.ErrorMessage.Text";
        public const string NanotainersPrescanEnteredBarcodeX_ByID = "NanotainerPreScan.Containers.List.$.ContentControl.EnteredBarcode.Text";
        

        ////List1
        //public const string NanotainersPrescanImage_ByID = "NanotainerPreScan.Containers.List.0.ContainerImage.Image";
        //public const string NanotainersPrescanName_ByID = "NanotainerPreScan.Containers.List.0.ContainerName.Text";
        //public const string NanotainersPrescanPleaseScan_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.PleaseScan.Text";
        //public const string NanotainersPrescanBarcode_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnterBarcodeNumber.TextBox.Text";
        //public const string NanotainersPrescanBarcodeError_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnterBarcodeNumber.TextBox.ErrorMessage.Text";
        //public const string NanotainersPrescanEnteredBarcode_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnteredBarcode.Text";

        ////List2
        //public const string NanotainersPrescanImage1_ByID = "NanotainerPreScan.Containers.List.0.ContainerImage.Image";
        //public const string NanotainersPrescanName1_ByID = "NanotainerPreScan.Containers.List.0.ContainerName.Text";
        //public const string NanotainersPrescanPleaseScan1_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.PleaseScan.Text";
        //public const string NanotainersPrescanBarcode1_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnterBarcodeNumber.TextBox.Text";
        //public const string NanotainersPrescanBarcodeError1_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnterBarcodeNumber.TextBox.ErrorMessage.Text";
        //public const string NanotainersPrescanEnteredBarcode1_ByID = "NanotainerPreScan.Containers.List.0.ContentControl.EnteredBarcode.Text";

        public const string NanotainersPrescanNext_ByID = "NanotainersPreScan.Next.Button";
        public const string NanotainersPrescanBack_ByID = "NanotainersPreScan.Back.Button";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform
{
    public class VerifyIdentification:PerformModel
    {       
        public const string VerifyGuestInfoHost_ByID = "VerifyGuestInformation.Screen";
        public const string PhotoScreenHost_ById = "Photo.screen";
        public const string ScanPhotoIDHost_ByID = "ScanPhotoId.Screen";

        public const string FirstName_ById = "VerifyGuestInformation.FirstName.TextBox.Text";
        public const string FirstNameError_ByID = "VerifyGuestInformation.FirstName.TextBox.ErrorMessage.Text";

        public const string MiddleName_ByID = "VerifyGuestInformation.MiddleInitial.TextBox.Text";
        public const string MiddleNameError_ByID = "VerifyGuestInformation.MiddleInitial.TextBox.ErrorMessage.Text";

        public const string LastName_ByID = "VerifyGuestInformation.LastName.TextBox.Text";
        public const string LastNameError_ByID = "VerifyGuestInformation.LastName.TextBox.ErrorMessage.Text";

        public const string Suffix_ByID = "VerifyGuestInformation.NameSuffix.TextBox.Text";
        public const string SuffixError_ByID = "VerifyGuestInformation.NameSuffix.TextBox.ErrorMessage.Text";

        public const string DOB_ByID = "PopupGuardianScreen.DOB.TextBox";

        public const string GenderMale_ById = "VerifyGuestInformation.IsMale.RadioButton";
        public const string GenderFemale_ByID = "VerifyGuestInformation.IsFemale.RadioButton";

        public const string EmailID_ByID = "VerifyGuestInformation.EmailAddress.TextBox.Text";
        public const string EmailIDError_ByID = "VerifyGuestInformation.EmailAddress.TextBox.ErrorMessage.Text";

        public const string GuestHasNoEmail_ByID = "VerifyGuestInformation.NoEmailAvailable.CheckBox";

        public const string TakePhoto_ByID = "Photo.TakePhoto.Button";
        public const string RetakePhoto_ByID = "Photo.RetakePhoto.Button";
        public const string Capture_ByID = "Photo.Capture.Button";
        public const string ScanPhoto_ByName = "SCAN PHOTO ID";
        public const string ScanPhoto_ByID = "Photo.ScanPhotoId.Button";
        public const string ScannedImage_ByID = "Photo.GuestPhoto.Image";

        public const string ClickToScan_ByID = "PopupScanPhotoId.ScanId.Button";
        public const string ScannedPhotoImage_ByID = "ScanPhotoId.ScannedPhoto.Image";
        public const string RescanPhotoImage_ByID = "ScanPhotoId.Rescan.Button";
        public const string HardwareMalfunctioning_ByID = "ScanPhotoId.HardwareMalfunctioning.Button";
        public const string Cancel_ByID = "ScanPhotoId.Cancel.Button";
        public const string Submit_ByID = "ScanPhotoId.Submit.Button";
        public const string GuestCheckBox_ByID = "ScanPhotoId.HardwareMalfunctioningCheckbox.Checkbox";

        public const string Next_ByID = "VerifyIdentification.Next.Button";

    }
}

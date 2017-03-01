using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class InsuranceModel : AddGuestModel
    {
        public const string InputFileName = "InsuranceDataSet.csv";

        public const string AddCard_ByName = "+ ADD CARD";
        public const string AddCard_ByID = "GuestInfoScreen.AddCard.Button";
        public const string InsuranceHost_ByID = "InsuranceScreen.Screen";


        public const string InsuranceListItem_ByName = "Theranos.PSC.UX.Model.Guest.InsuranceEx";
        public const string InsuranceScreen_ByID = "PopupAddEditInsuranceScreen.Screen";
        public const string Text_ByClass = "TextBlock";

        public const string FrontCardScan_ByID = "PopupAddEditInsuranceScreen.ScanCardFront.Button";
        public const string FrontCardRotateLeft_ByID = "PopupAddEditInsuranceScreen.RotateFrontImageLeft.Button";
        public const string FrontCardRotateRight_ByID = "PopupAddEditInsuranceScreen.RotateFrontImageRight.Button";
        public const string FrontCardRescan_ByID = "PopupAddEditInsuranceScreen.RescanFrontOfCard.Button";
        public const string FrontCardImage_ByID = "PopupAddEditInsuranceScreen.FrontOfCard.Image";

        public const string BackCardScan_ByID = "PopupAddEditInsuranceScreen.ScanCardBack.Button";
        public const string BackCardRotateLeft_ByID = "PopupAddEditInsuranceScreen.RotateBackImageLeft.Button";
        public const string BackCardRotateRight_ByID = "PopupAddEditInsuranceScreen.RotateBackImageRight.Button";
        public const string BackCardRescan_ById = "PopupAddEditInsuranceScreen.RescanBackOfCard.Button";
        public const string BackCardImage_ByID = "PopupAddEditInsuranceScreen.BackOfCard.Image";

        public const string FirstName_ByID = "PopupAddEditInsuranceScreen.FirstName.TextBox.Text";
        public const string FirstNameError_ByID = "PopupAddEditInsuranceScreen.FirstName.TextBox.ErrorMessage.Text";

        public const string LastName_ByID = "PopupAddEditInsuranceScreen.LastName.TextBox.Text";
        public const string LastNameError_ByID = "PopupAddEditInsuranceScreen.LastName.TextBox.ErrorMessage.Text";

        public const string DOB_ByID = "PopupAddEditInsuranceScreen.DOB.TextBox";

        //Automation ID for Insurance List Item is to be updated.
        public const string InsuranceProvider_ByID = "PopupAddEditInsuranceScreen.InsuranceProviderList.List.TextBox";
        public const string OtherInsuranceProvider_ByID = "PopupAddEditInsuranceScreen.OtherProviderName.TextBox";
        public const string InsuranceProviderList_ByID = "PopupAddEditInsuranceScreen.InsuranceProviderList.List";


        public const string InsuranceProviderListItem_ByName = "Theranos.PSC.ServicesProxy.PscService.LookupItem";

        public const string MedicareAandB = "Medicare A and B";



        public const string PolicyNumber_ByID = "PopupAddEditInsuranceScreen.PolicyNumber.TextBox.Text";
        public const string PolicyNumberError_ByID = "PopupAddEditInsuranceScreen.PolicyNumber.TextBox.ErrorMessage.Text";

        public const string PrimaryInsurance_ByID = "PopupAddEditInsuranceScreen.IsPrimaryInsurance.RadioButton";
        public const string OtherInsurance_ByID = "PopupAddEditInsuranceScreen.IsOtherInsurance.RadioButton";

        public const string DeleteInsurance_ByID = "PopupAddEditInsuranceScreen.DeleteInsurance.Button";
        public const string CancelInsurance_ByID = "PopupAddEditInsuranceScreen.CancelScreen.Button";
        public const string SaveInsurance_ByID = "PopupAddEditInsuranceScreen.SaveInsurance.Button";

        public const string PrimaryInsurance = "Primary";
        public const string OtherInsurance = "Other";

        public const string Popup_ByName = "PopupWindow";
        public const string OkPopUp_ByID = "SystemOK.Screen";
        public const string Ok_ByID = "SystemOK.OK.Button";

        public InsuranceModel()
        {

        }

        public InsuranceModel(string insuranceProvider, string insuranceType)
        {
            InsuranceProvider = insuranceProvider;
            InsuranceType = insuranceType;
        }

        public string InsuranceProvider { get; set; }
        public string Policy { get; set; }
        public string InsuranceType { get; set; }




    }
}

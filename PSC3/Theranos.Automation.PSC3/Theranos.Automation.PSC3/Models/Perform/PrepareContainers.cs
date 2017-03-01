using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform
{
    public class PrepareContainers:PerformModel
    {
        public const string PrepareContainersHost_ByID = "PrepareContainers.Screen";
        public const string SwitchContainersRemoveTestHost_ByID = "PopupSwitchContainersTestsRemoved.Screen";
        public const string SwitchContainersNoTestChange_ByID = "PopupSwitchContainerNoTestChange.Screen";

        public const string EditContainers_ByID = "PrepareContainers.EditContainers.Button";
        public const string SwitchToVenous_ByID = "PrepareContainers.SwitchToVenousDraw.Button";
        public const string SwitchToFingerstick_ByID = "PrepareContainers.SwitchToNanotainers.Button";

        public const string RemoveTestCancelSwitch_ByID = "PopupSwitchContainersTestsRemoved.Cancel.Button";
        public const string RemoveTestConfirmSwitch_ByID = "PopupSwitchContainersTestsRemoved.Confirm.Button";
        public const string TestName1_ByID = "PopupSwitchContainersTestsRemoved.Tests.List.0.CptCode.Text";
        public const string TestName2_ByID = "PopupSwitchContainersTestsRemoved.Tests.List.1.CptCode.Text";
        public const string TestName3_ByID = "PopupSwitchContainersTestsRemoved.Tests.List.2.CptCode.Text";

        public const string NoTestChangeCancel_ByID = "PopupSwitchContainerNoTestChange.Cancel.Button";
        public const string NoTestChangeConfirm_ByID = "PopupSwitchContainerNoTestChange.Confirm.Button";

        public const string NanotainersImageX_ByID = "PrepareContainers.Nanotainers.List.$.ContainerImage.Image";
        public const string NanotainersCountX_ByID = "PrepareContainers.Nanotainers.List.$.ContainerCount.Text";
        public const string NanotainersNameX_ByID = "PrepareContainers.Nanotainers.List.$.ContainerName.Text";

        ////NanotainersList1
        //public const string NanotainersImage_ByID = "PrepareContainers.Nanotainers.List.0.ContainerImage.Image";
        //public const string NanotainersCount_ByID = "PrepareContainers.Nanotainers.List.0.ContainerCount.Text";
        //public const string NanotainersName_ByID = "PrepareContainers.Nanotainers.List.0.ContainerName.Text";

        ////NanotainersList2
        //public const string NanotainersImage1_ByID = "PrepareContainers.Nanotainers.List.1.ContainerImage.Image";
        //public const string NanotainersCount1_ByID = "PrepareContainers.Nanotainers.List.1.ContainerCount.Text";
        //public const string NanotainersName1_ByID = "PrepareContainers.Nanotainers.List.0.ContainerName.Text";

        public const string VacutainersImageX_ByID = "PrepareContainers.VacutainersList.List.$.ContainerImage.Image";
        public const string VacutainersCountX_ByID = "PrepareContainers.VacutainersList.List.$.ContainerCount.Text";
        public const string VacutainersNameX_ByID = "PrepareContainers.VacutainersList.List.$.ContainerName.Text";
        public const string VacutainerDiscardTubeX_ByID = "PrepareContainers.VacutainersList.List.$.DiscardTube.Text";

        public const string ContainerLightBlueTop = "Light Blue Tube";
        public const string ContainerGoldTop = "Gold (SST) Tube";
        public const string ContainerMintTop = "Light Green (Mint) Tube";
        public const string ContainerQFTGrey = "QFT (Grey)";
        public const string ContainerQFTRed = "QFT (Red)";
        public const string ContainerQFTPurple = "QFT (Purple)";
        public const string ContainerPearlTop = "Pearl Tube";
        public const string ContainerTanTop = "Tan Tube";
        public const string ContainerLavender = "Lavender Tube";
        public const string ContainerGreyTop = "Grey Tube";
        public const string ContainerUrineKit = "Urine Collection Kit";
        public const string Container24HourUrineKit = "24 Hour Urine Kit";
        public const string ContainerSwabKit = "Swab Kit";
        public const string ContainerStoolCard1 = "Stool - 1 Card";
        public const string ContainerStoolCard3 = "Stool - 3 Card";
        public const string ContainerStoolCollectionKitA = "Stool Collection Kit A";
        public const string ContainerStoolCollectionKitB = "Stool Collection Kit B";
        public const string ContainerNanotainerPurple = "Nanotainer (Purple)";
        public const string ContainerNanotainerGreen = "Nanotainer (Green)";
        public const string DiscardTube = "+1 Discard Tube";
        public const string MintTube = "+1 Mint Top Discard Tube";

        ////VacutainersList1
        //public const string VacutainersImage_ByID = "PrepareContainers.VacutainersList.List.0.ContainerImage.Image";
        //public const string VacutainersCount_ByID = "PrepareContainers.VacutainersList.List.0.ContainerCount.Text";
        //public const string VacutainersName_ByID = "PrepareContainers.VacutainersList.List.0.ContainerName.Text";

        ////VacutainersList2
        //public const string VacutainersImage1_ByID = "PrepareContainers.VacutainersList.List.1.ContainerImage.Image";
        //public const string VacutainersCount1_ByID = "PrepareContainers.VacutainersList.List.1.ContainerCount.Text";
        //public const string VacutainersName1_ByID = "PrepareContainers.VacutainersList.List.1.ContainerName.Text";

        public const string OtherContainersImageX_ByID = "PrepareContainers.OtherContainers.List.$.ContainerImage.Image";
        public const string OtherContainersCountX_ByID = "PrepareContainers.OtherContainers.List.$.ContainerCount.Text";
        public const string OtherContainersNameX_ByID = "PrepareContainers.OtherContainers.List.$.ContainerName.Text";


        ////OtherContainersList1
        //public const string OtherContainersImage_ByID = "PrepareContainers.OtherContainers.List.0.ContainerImage.Image";
        //public const string OtherContainersCount_ByID = "PrepareContainers.OtherContainers.List.0.ContainerCount.Text";
        //public const string OtherContainersName_ByID = "PrepareContainers.OtherContainers.List.0.ContainerName.Text";

        ////OtherContainersList2
        //public const string OtherContainersImage1_ByID = "PrepareContainers.OtherContainers.List.1.ContainerImage.Image";
        //public const string OtherContainersCount1_ByID = "PrepareContainers.OtherContainers.List.1.ContainerCount.Text";
        //public const string OtherContainersName1_ByID = "PrepareContainers.OtherContainers.List.1.ContainerName.Text";

        ////OtherContainersList3
        //public const string OtherContainersImage2_ByID = "PrepareContainers.OtherContainers.List.2.ContainerImage.Image";
        //public const string OtherContainersCount2_ByID = "PrepareContainers.OtherContainers.List.2.ContainerCount.Text";
        //public const string OtherContainersName2_ByID = "PrepareContainers.OtherContainers.List.2.ContainerName.Text";

        public const string Next_ByID = "GuestInfo.ActiveLabOrders.Next.Button";
        public const string Back_ByID = "GuestInfo.ActiveLabOrders.Back.Button";

        //GTT
        public const string CollectionPeriodExpiredPopup_ById = "CollectionPeriodExpired.Popup";
        public const string ContinueWithVisit_ByID = "CollectionPeriodExpired.ContinueWithVisit.RadioButton";
        public const string CollectionExpiredCancelVisit_ByID = "CollectionPeriodExpired.CancelVisit.RadioButton";
        public const string CollectionPeriodExpiredReason_ById = "CollectionPeriodExpired.SelectReason.ComboBox.Combo";
        public const string CollectionPeriodExpiredOk_ByID = "CollectionPeriodExpired.OK.Button";
        public const string CollectionPeriodExpiredContinue_ByID = "CollectionPeriodExpired.ContinueWithVisit.RadioButton";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers
{
    public class PrintAttachLabels:PerformModel
    {
        public const string OtherContainersLabelsHost_ByID = "OtherContainers.PrintAttachlabels.Screen";
        public const string OtherContainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitContainerEx";

        //List1
        public const string OtherContainersImage_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.0.ContainerImage.Image";
        public const string OtherContainersName_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.0.ContainerName.Text";

        //List2
        public const string OtherContainersImage1_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.1.ContainerImage.Image";
        public const string OtherContainersName1_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.0.ContainerName.Text";

        //List3
        public const string OtherContainersImage2_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.2.ContainerImage.Image";
        public const string OtherContainersName2_ByID = "OtherContainers.PrintAndAttachLabels.ItemsControl.2.ContainerName.Text";

        public const string LabelsCount_ByID = "PrintLabelsControl.LabelCount.text";

        public const string PrintAndAttachhost_ByName = "PrintExtraBarcodeLabelsControl";

        public const string OtherContainersBarcodeOk_ByID = "SystemOK.OK.Button";

        public const string PrintBackButton_ByID = "OtherContainers.PrintAndAttachLabel.Back.Button";
        public const string PrintNextButton_ByID = "OtherContainers.PrintAndAttachLabel.Next.Button";

        public const string PrintAndAttachDecrement_ByID = "PrintLabelsControl.LabelCount.DecrementCount.Button";
        public const string PrintAndAttachIncrement_ByID = "PrintLabelsControl.LabelCount.IncrementCount.Button";
        public const string PrintAndAttachExtraLabelCount_ByID = "PrintLabelsControl.LabelCount.ExtraLabelCount.Text";
        public const string PrintAndAttachPrintExtraLabel_ByID = "PrintLabelsControl.PrintExtraLabel.Button";
    }
}

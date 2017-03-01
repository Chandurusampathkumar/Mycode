using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers
{
    public class PrintAndAttachLabels:PerformModel
    {
        public const string LabelsHost_ByClass = "PerformVacutainerPrintLabels";
        public const string LabelsHost_ByID = "Vacutainers.PrintLabel.Screen";
        public const string LabelsVacutainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitContainerEx";
        //List1
        public const string PrintAndAttachVacutainersImage_ByID = "Vacutainers.PrintLabel.ItemsControl.0.ContainerImage.Image";
        public const string PrintAndAttachVacutainersName_ByID = "Vacutainers.PrintLabel.ItemsControl.0.ContainerName.Text";

        //List2
        public const string PrintAndAttachVacutainersImage1_ByID = "Vacutainers.PrintLabel.ItemsControl.1.ContainerImage.Image";
        public const string PrintAndAttachVacutainersName1_ByID = "Vacutainers.PrintLabel.ItemsControl.1.ContainerName.Text";

        public const string PrintAndAttachHost_ByClass = "PrintExtraBarcodeLabelsControl";
        public const string PrintAndAttachHost_ByID = "PrintLabelsControl.Screen";
        public const string PrintAndAttachLabelsCount_ByID = "PrintLabelsControl.LabelCount.text";
        public const string PrintAndAttachDecrement_ByID = "PrintLabelsControl.LabelCount.DecrementCount.Button";
        public const string PrintAndAttachIncrement_ByID = "PrintLabelsControl.LabelCount.IncrementCount.Button";
        public const string PrintAndAttachExtraLabelCount_ByID = "PrintLabelsControl.LabelCount.ExtraLabelCount.Text";
        public const string PrintAndAttachPrintExtraLabel_ByID = "PrintLabelsControl.PrintExtraLabel.Button";

        public const string VacutainersBarcodeOk_ByID = "SystemOK.OK.Button";       

        public const string LabelsBackButton_ByID = "Vacutainers.PrintLabel.Back.Button";
        public const string LabelsNextButton_ByID = "Vacutainers.PrintLabel.Next.Button";
    }
}

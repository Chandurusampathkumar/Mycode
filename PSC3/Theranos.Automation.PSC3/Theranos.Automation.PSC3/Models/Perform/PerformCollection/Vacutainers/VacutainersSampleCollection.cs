using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers
{
    public class  VacutainersSampleCollection:PerformModel
    {
        public const string VacutainersSampleCollectionHost_ByClass = "PerformVacutainerCollectSamples";
        public const string VacutainersSampleCollectionHost_ByID = "Vacutainers.CollectSamples.Screen";
        public const string VacutainersList_ByName = "Theranos.PSC.UX.Model.Perform.VisitContainerEx";

        public const string VacutainersSampleCollectionImageX_ByID = "Vacutainers.CollectSamples.ItemsControl.$.ContainerImage.Image";
        public const string VacutainersSampleCollectionNameX_ByID = "Vacutainers.CollectSamples.ItemsControl.$.ContainerName.Text";
        public const string VacutainersSampleCollectionInstructionX_ByID = "Vacutainers.CollectSamples.ItemsControl.$.PostCollectionInstruction.Text";

        ////List1
        //public const string VacutainersSampleCollectionImage_ByID = "Vacutainers.CollectSamples.ItemsControl.0.ContainerImage.Image";
        //public const string VacutainersSampleCollectionName_ByID = "Vacutainers.CollectSamples.ItemsControl.0.ContainerName.Text";
        //public const string VacutainersSampleCollectionInstruction_ByID = "Vacutainers.CollectSamples.ItemsControl.0.PostCollectionInstruction.Text";

        ////List2
        //public const string VacutainersSampleCollectionImage1_ByID = "Vacutainers.CollectSamples.ItemsControl.1.ContainerImage.Image";
        //public const string VacutainersSampleCollectionName1_ByID = "Vacutainers.CollectSamples.ItemsControl.1.ContainerName.Text";
        //public const string VacutainersSampleCollectionInstruction1_ByID = "Vacutainers.CollectSamples.ItemsControl.1.PostCollectionInstruction.Text";

        public const string ContainerLightBlueTop = "Light Blue Tube";
        public const string Instruction3to4Times = "Invert 3-4 times.";

        public const string ContainerGoldTop = "Gold (SST) Tube";
        public const string Instruction5Times = "Invert 5 times.";

        public const string MintTop = "Light Green (Mint) Tube";
        public const string Instruction8Times = "Invert 8 times.";

        public const string ContainerQFTGrey = "QFT (Grey)";
        public const string ContainerQFTRed = "QFT (Red)";
        public const string ContainerQFTPurple = "QFT (Purple)";
        public const string Instruction10Times = "Shake firmly 10 times. Make sure entire inner surface of the tube is coated with specimen.";

        public const string ContainerLavender = "Lavender Tube";

        public const string ContainerPearlTop = "Pearl Tube";

        public const string ContainerTanTop = "Tan Tube";


        public const string VacutainersSampleCollectionBack_ByID = "Vacutainers.CollectSamples.Back.Button";
        public const string VacutainersSampleCollectionNext_ByID = "Vacutainers.CollectSamples.Next.Button";
    }
}

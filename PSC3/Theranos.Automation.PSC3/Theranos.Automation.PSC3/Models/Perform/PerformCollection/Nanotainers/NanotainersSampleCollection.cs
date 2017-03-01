using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform.PerformCollection.Nanotainers
{
    public class NanotainersSampleCollection:PerformModel
    {
        public const string SampleCollectionHost_ByID = "Nanotainers.PerformCollection.Screen";
        public const string SampleCollectionNanotainersListName_ByName = "Theranos.PSC.UX.Model.Perform.VisitNanotainerEx";

        public const string NanotainerSampleCollectionMessage="If collection fails, continue with successful samples and click Collection Complete.";

        public const string SampleCollectionNanotainersImageX_ByID = "Nanotainers.PerformCollection.ItemsControl.$.ContainerImage.Image";
        public const string SampleCollectionNanotainersNameX_ByID = "Nanotainers.PerformCollection.ItemsControl.$.ContainerName.Text";

        //List1
        //public const string SampleCollectionNanotainersImage_ByID = "Nanotainers.PerformCollection.ItemsControl.0.ContainerImage.Image";
        //public const string SampleCollectionNanotainersName_ByID = "Nanotainers.PerformCollection.ItemsControl.0.ContainerName.Text";

        ////List2
        //public const string SampleCollectionNanotainersImage1_ByID = "Nanotainers.PerformCollection.ItemsControl.1.ContainerImage.Image";
        //public const string SampleCollectionNanotainersName1_ByID = "Nanotainers.PerformCollection.ItemsControl.1.ContainerName.Text";

        public const string CollectionInstruction_ByID = "Nanotainers.PerformCollection.CollectionInstructions.Text";

        public const string SampleCollectionNext_ByID = "Nanotainers.PerformCollection.Next.Button";
        public const string SampleCollectionBack_ByID = "Nanotainers.PerformCollection.Back.Button";
    }
}

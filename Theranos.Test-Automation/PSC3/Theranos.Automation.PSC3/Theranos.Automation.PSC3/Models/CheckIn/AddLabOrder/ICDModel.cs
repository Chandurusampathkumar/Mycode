
namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class ICDModel: PSC3Model
    {
        public const string InputFileName = "ICDDataSet.csv";
        public const string ICDHost_ByClass = "Icd9";
        public const string ICDHost_ByID = "ICD9.Screen";

        public const string ICD9_ByID = "ICD9.Screen.ICD9.Radiobutton";

        public const string ICDListItem_ByName = "Theranos.PSC.ServicesProxy.PscService.IcdInfo";

        public const string ICD9TestName_ByID = "ICD9.IcdSearch.TextBoxAndListBox.TextBox";


        public string ICDCode { get; set; }
        public string ICDName { get; set; }

    }
}

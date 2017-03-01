
namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class CPTModel:PSC3Model
    {
        public const string InputFileName = "CPTDataSet.csv";

        public const string CPTHost_ByClass = "TestsAndPanels";
        public const string CPTHost_ByID = "TestsAndPanels.Screen";
        public const string ICDHost_ByID = "ICD9.Screen";  

        public const string CPTListItem_ByName = "Theranos.PSC.ServicesProxy.PscService.CptInfo";

        public const string TestName_ByID = "TestsAndPanels.TestSearch.TextBoxAndListBox.TextBox";

        public const string SaveDirectTesting_ById = "AddOrder.GuestOrder.GuestOrderPage1.CompleteOrder.Button";

        public const string ClinicianSave_ByID = "TranscriptionPage3.Save.Button";

        public string CPTCode{get;set;}
        public string TestName{get;set;}
        public string Price{get;set;}
     
    }
}

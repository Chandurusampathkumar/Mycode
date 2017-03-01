
namespace Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder
{
    public class ClinicianModel: PSC3Model
    {
        public const string InputFileName = "ClinicianDataSet.csv";

        public const string ClinicianHost_ByClass = "Clinician";
        public const string ClinicianHost_ByID = "Clinician.screen";

        public const string OrderInstructionsHost_ByID = "OrderingInstructions.Screen";

        public const string ClinicianListItem_ByName = "Theranos.PSC.UX.Model.Order.DoctorInfoEx";
        public const string Locations_ByName = "Location *";
        public const string LocationListItem_ByName = "Theranos.PSC.ServicesProxy.PscService.ProviderLocation";
        public const string ClinicianList_ByID = "Clinician.FindClinician.list";
        public const string Clinician_ByID = "Clinician.FindClinician.list.TextBox";

        public const string Provider_ByID = "Clinician.Providers.Combobox.Combo";
        public const string Location_ByID = "Clinician.Location.Combobox.Combo";
        public const string PhysicianNotes_ById = "Clinician.Notes.TextBox";

        


        public const string Next_ByID= "TranscriptionPage2.Next.Button";

        public ClinicianModel()
        {

        }

        public ClinicianModel(string clinicianName, string npi, string providerName, string locationName)
        {
            ClinicianName = clinicianName;
            NPI = npi;
            ProviderName=providerName;
            LocationName=locationName;
            
        }

        public string ClinicianName { get; set; }
        public string NPI { get; set; }
        public string ProviderName { get; set; }
        public string LocationName { get; set; }
        public string HasFavourites { get; set; }

    }
}

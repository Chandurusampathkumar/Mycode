using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;

namespace Theranos.Automation.PSC3.Models.Features
{
    public class ContainerModel:ConfirmOrdersModel
    {
        public const string InputFileName = "ContanierDataSet.csv";

        public const string Male = "M";
        public const string Female = "F";
        public const string Any = "Any";
        public const string Venous ="Venous";
        public const string Fingerstick ="Fingerstick";
        public const string Urine ="Urine";
        public const string Swab="Swab";
        public const string Stool = "Stool";
        public const string Insurance = "Insurance";

        public static ClinicianModel PhysicianWithVenousPreference1 = new ClinicianModel("Borgersen", "1891120762", "Angel Pediatrics", "Angel Pediatrics");
        public static ClinicianModel PhysicianWithVenousPreference2 = new ClinicianModel("Cooper", "1275512782", "Arizona Medical Services", "Arizona Medical Services");

        public static ClinicianModel ProviderWithVenousPreference1 = new ClinicianModel("Bandla", "1710134762", "Banner Health", "BHCLC Dobson 402");
        public static ClinicianModel ProviderWithVenousPreference2 = new ClinicianModel("Singh", "1942401807", "Arizona Gastrointestinal Associates", "Arrowhead Gastroenterology");

        public static InsuranceModel PayorWithVenousPreference = new InsuranceModel("Sanford Health Plan", InsuranceModel.PrimaryInsurance);
        
        public string LabOrderNo { get; set; }
        public string CPTCode { get; set; }
        public string CPTName { get; set; }
        public string Gender { get; set; }
        public string PatientPreference { get; set; }
        public string PhysicianPreference { get; set; }
        public string ProviderLocationPreference { get; set; }
        public string PayorPreference { get; set; }
        public string PaymentMethod { get; set; }
        public string Redraw { get; set; }
        public string Container { get; set; }
    }
}

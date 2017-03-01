using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class ProfileURNs
    {
        public const string getPatientData = "/Profile/GetPatientData";
        public const string getDoctorList = "/Profile/GetDoctorList";
        public const string getInsuranceCompanies = "/Profile/GetInsuranceCompanies";
        public const string getPatientInsurances = "/Profile/GetPatientInsurances";
        public const string getEmergencyContacts = "/Profile/GetEmergencyContacts";
        public const string getGuardianInfo = "/Profile/GetGuardianInfo";
        public const string getPatientDoctors = "/Profile/GetPatientDoctors";
        public const string getMedicalHistory = "/Profile/GetMedicalHistory";
        public const string setBasicPatientInfo = "/Profile/SetBasicPatientInfo";
        public const string updatePatientEmailAddress = "/Profile/UpdatePatientEmailAddress";
        public const string setPatientInsurance = "/Profile/SetPatientInsurance";
        public const string setPatientEmergencyContacts = "/Profile/SetPatientEmergencyContacts";
        public const string deleteEmergencyContact = "/Profile/DeleteEmergencyContact";
        public const string setPatientGuardianInfo = "/Profile/SetPatientGuardianInfo";
        public const string deletePatientGuardianInfo = "/Profile/DeletePatientGuardianInfo";
        public const string setPatientDoctor = "/Profile/SetPatientDoctor";
        public const string deletePatientDoctor = "/Profile/DeletePatientDoctor";
        public const string setPatientInsuranceImage = "/Profile/SetPatientInsuranceImage";
        public const string setPatientInsuranceImageAndDecode = "/Profile/SetPatientInsuranceImageAndDecode";
        public const string getPatientInsuranceImage  = "/Profile/GetPatientInsuranceImage";
        public const string saveDeviceToUserProfile  = "/Profile/SaveDeviceToUserProfile";
        public const string deleteDeviceFromUserProfile  = "/Profile/DeleteDeviceFromUserProfile";
        public const string deactivateDeviceFromUserProfile  = "/Profile/DeactivateDeviceFromUserProfile";
        public const string getUserDeviceInfo  = "/Profile/GetUserDeviceInfo";
        public const string getApplicationInfo = "/Profile/GetApplicationInfo";
        public const string validateZipCode = "/Profile/ValidateZipCode";

    }
}

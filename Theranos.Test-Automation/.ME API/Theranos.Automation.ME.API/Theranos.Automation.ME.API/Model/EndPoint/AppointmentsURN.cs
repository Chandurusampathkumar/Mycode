using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class AppointmentsURN
    {
        public static string CancelAppointment = "/Appointments/CancelAppointment";
        public static string GetPatientAppointments ="/Appointments/GetPatientAppointments";
        public static string SaveAppointment ="/Appointments/SaveAppointment";
        public static string GetAvailableTimeSlots ="/Appointments/GetAvailableTimeSlots";
        public static string GetFastingInfo ="/Appointments/GetFastingInfo";
        public static string EarlyCheckInPatient ="/Appointments/EarlyCheckInPatient";
        public static string GeoCheckInPatient ="/Appointments/GeoCheckInPatient";
        public static string UpdateEarlyCheckIn ="/Appointments/UpdateEarlyCheckIn";
        public static string CancelEarlyCheckIn ="/Appointments/CancelEarlyCheckIn";
        public static string SaveCheckInConsentForm ="/Appointments/SaveCheckInConsentForm";
        public static string GetListOfServices = "/Appointments/GetListOfServices";
    }
}

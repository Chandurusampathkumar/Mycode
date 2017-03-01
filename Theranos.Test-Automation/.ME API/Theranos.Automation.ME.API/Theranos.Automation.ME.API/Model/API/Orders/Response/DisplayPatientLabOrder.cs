using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.External;

namespace Theranos.Automation.ME.API.Model.API.Orders.Response
{
    public class DisplayPatientLabOrder
    {
        public List<DisplayPatientLabTest> Tests { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string DoctorFirstName { get; set; }
        public Guid? DoctorId { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorMiddleName { get; set; }
        public string DoctorSuffix { get; set; }
        public string DoctorTitle { get; set; }
        public string DoctorsNotes { get; set; }
        public int EarlyCheckInId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string FastingReq { get; set; }
        public bool HasEarlyCheckedIn { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSelfOrdered { get; set; }
        public bool IsShoppingCart { get; set; }
        public Guid? LabOrderId { get; set; }
        public string LabOrderName { get; set; }
        public string LabOrderStatus { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string Location { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderEffectiveDate { get; set; }
        public string OrderSource { get; set; }
        public string PhysicianEmailAddress { get; set; }
        public string PhysicianFaxNumber { get; set; }
        public string PhysicianPhoneNumber { get; set; }
        public string PhysicianProviderName { get; set; }
    //    public List<PatientLabTest> Tests { get; set; }
        public string TranscriptionErrorMessage { get; set; }
        public string TranscriptionStatus { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.External
{
    public class DisplayPatientVisitDetails
    {
        public DateTime? ResultsEta { get; set; }
        public DateTime? ExternalTAT { get; set; }
        public DateTime? InternalTAT { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Guid? PatientVisitId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? ResultReleaseDate { get; set; }
        public Guid? RetailLocationId { get; set; }
        public decimal TotalInvoiceAmount { get; set; }
        public DateTime? VisitCompletedOn { get; set; }
        public string VisitDrawType { get; set; }
        public List<Guid> VisitLabRequestIds { get; set; }
        public List<Tuple<int, int, string>> VisitLabTestInfo { get; set; }
        public string VisitLocationCity { get; set; }
        public string VisitLocationPostalCode { get; set; }
        public string VisitLocationState { get; set; }
        public string VisitLocationStreet { get; set; }
        public string VisitProvider { get; set; }
        public string VisitStatus { get; set; }
        public int? VisitTurnaroundTime { get; set; }
    }
}

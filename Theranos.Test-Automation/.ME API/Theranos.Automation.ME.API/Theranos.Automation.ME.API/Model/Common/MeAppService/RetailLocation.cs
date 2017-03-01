using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class RetailLocation
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public bool Is24HourLocation { get; set; }
        public bool IsSpecimenCollected { get; set; }
        public decimal Latitude { get; set; }
        public string LocationFax { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationPhone { get; set; }
        public decimal Longitude { get; set; }
        public string ProviderName { get; set; }
        public string ServicesOffered { get; set; }
        public string State { get; set; }
        public string StoreHours { get; set; }
        public TimeZoneData TimeZone { get; set; }
        public string URL { get; set; }
        public string Zip { get; set; }
    }
}

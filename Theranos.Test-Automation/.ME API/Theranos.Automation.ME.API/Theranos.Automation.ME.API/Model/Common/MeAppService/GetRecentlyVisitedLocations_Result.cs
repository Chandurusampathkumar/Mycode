using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class GetRecentlyVisitedLocations_Result
    {
        public string City { get; set; }
        public int? FavoriteId { get; set; }
        public decimal? GeoLatitude { get; set; }
        public decimal? GeoLongitude { get; set; }
        public bool Is24HourLocation { get; set; }
        public string LocationFax { get; set; }
        public string OtherDesignation { get; set; }
        public string PostalCode { get; set; }
        public Guid ProviderLocationId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderProvidedILocationId { get; set; }
        public string ServiceOffered { get; set; }
        public bool? SpecimenCollected { get; set; }
        public string State { get; set; }
        public string StoreHours { get; set; }
    }
}

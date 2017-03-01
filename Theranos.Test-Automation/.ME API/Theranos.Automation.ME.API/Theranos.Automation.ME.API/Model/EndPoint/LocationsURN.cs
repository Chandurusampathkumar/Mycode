using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class LocationsURN
    {
        public const string getStoreLocations = "/Locations/GetStoreLocations";
        public const string getLocations = "/Locations/GetLocations";
        public const string getRecentlyVisitedLocations = "/Locations/GetRecentlyVisitedLocations";
        public const string setPatientFavoriteLocation = "/Locations/SetPatientFavoriteLocation";
        public const string deletePatientFavoriteLocation = "/Locations/DeletePatientFavoriteLocation";
        public const string getPatientFavoriteLocations = "/Locations/GetPatientFavoriteLocations";
        public const string getHolidayInfo = "/Locations/GetHolidayInfo";
    }
}

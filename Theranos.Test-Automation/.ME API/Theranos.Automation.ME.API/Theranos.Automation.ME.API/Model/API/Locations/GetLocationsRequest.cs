using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Locations
{
    public class GetLocationsRequest
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }
        public bool CoordinatesOnly { get; set; }
        public string AuthToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.API.Physicians
{
    public class PhysicianResponse
    {
        public string UniqueId { get; set; }
        public string DisplayName {get;set;}
        public string Credentials {get;set;}
        public string specialty { get; set; }
        public string PracticeName {get;set;}
        public string Address1 {get;set;}
        public string Address2 {get;set;}
        public string City {get;set;}
        public string State{get;set;}
        public string Country{get;set;}
        public string Zip{get;set;}
        public string DisplayPhone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public string DistanceUnits { get; set; }
    }
}

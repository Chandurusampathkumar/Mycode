using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Locations
{
    public class DeletePatientFavoriteLocationRequest
    {
        public List<Guid> locationIds { get; set; }
        public string authToken { get; set; }
    }
}

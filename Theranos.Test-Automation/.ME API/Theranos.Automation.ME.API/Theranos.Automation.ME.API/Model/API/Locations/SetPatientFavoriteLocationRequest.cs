using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Locations
{
    public class SetPatientFavoriteLocationRequest
    {
        public List<Guid> LocationIds { get; set; }
        public string AuthToken { get; set; }
    }
}

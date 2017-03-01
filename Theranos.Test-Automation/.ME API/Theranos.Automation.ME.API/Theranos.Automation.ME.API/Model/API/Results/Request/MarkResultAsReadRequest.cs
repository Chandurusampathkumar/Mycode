using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.API.Results.Request
{
    public class MarkResultAsReadRequest
    {
        public int TestId { get; set; }
        public Guid ResultId { get; set; }
        public string AuthToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.MeAppService;

namespace Theranos.Automation.ME.API.Model.Common
{
    public class DisplayEnumResultValue
    {
        public string LOINCCode { get; set; }
        public Guid ResultId { get; set; }
        public string ResultComments { get; set; }
        public string ResultName { get; set; }
        public string ResultValue { get; set; }
        public string ResultState { get; set; }
        public string ReferenceRange { get; set; }
        public bool IsMarkedAsRead { get; set; }
        public DateTime ResultReleaseDate { get; set; }
        public string LOINCNotes { get; set; }
        public bool IsValid { get; set; }
        public int LOINCDisplayOrder { get; set; }
        public string ResultFlag { get; set; }
        public string DisplayRange { get; set; }
    }
}

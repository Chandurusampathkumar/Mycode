using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.External
{
    public class TestSetInfo
    {
        public int TestSetId { get; set; }
        public string TestSetName { get; set; }
        public int LabTestId{get;set;}
        public bool IsDuplicate{get;set;}
    }
}

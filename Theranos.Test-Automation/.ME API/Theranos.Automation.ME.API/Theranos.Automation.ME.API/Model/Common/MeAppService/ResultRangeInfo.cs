using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class ResultRangeInfo
    {
        public bool IsValueAbnormal { get; set; }
        public bool IsValueIndeterminate { get; set; }
        public string RangeSegment { get; set; }
        public string RangeSegmentDisplayValue { get; set; }
        public bool ShouldRaiseAFlag { get; set; }
    }
}

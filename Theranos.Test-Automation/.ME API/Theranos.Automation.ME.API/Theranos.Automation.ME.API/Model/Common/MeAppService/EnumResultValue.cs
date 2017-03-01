using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    public class EnumResultValue
    {
        public string CriticalHigh { get; set; }
        public string CriticalLow { get; set; }
        public string DisplayValue { get; set; }
        public string High { get; set; }
        public bool IsAbnormal { get; set; }
        public bool IsCritical { get; set; }
        public bool IsIndeterminate { get; set; }
        public bool IsMarkedAsRead { get; set; }
        public string LOINCCode { get; set; }
        public int LOINCDisplayOrder { get; set; }
        public string LOINCNotes { get; set; }
        public string Low { get; set; }
        public string Normal { get; set; }
        public ResultRangeInfo RangeInfo { get; set; }
        public string RefRangeString { get; set; }
        public string ResultComments { get; set; }
        public Guid ResultId { get; set; }
        public string ResultName { get; set; }
        public string ResultRange { get; set; }
        public DateTime ResultReleaseDate { get; set; }
        public string ResultValue { get; set; }
        public bool SuppressRefRange { get; set; }
    }
}

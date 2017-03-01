using System;

namespace Theranos.Automation.PSC3.Base
{
    public class ReportModel
    {
        public string TestName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Double ExecutionTime { get; set; }
        public string Result { get; set; }
        public string InputData { get; set; }
        public string Notes { get; set; }
        public string SnapshotPath { get; set; }

        //public string Time { get; set; }
        //public string TestName { get; set; }
        //public string Result { get; set; }
        //public string InputData { get; set; }


    }
}

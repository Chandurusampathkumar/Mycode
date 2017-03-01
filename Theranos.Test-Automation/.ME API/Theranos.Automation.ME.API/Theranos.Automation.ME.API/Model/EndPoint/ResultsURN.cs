using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class ResultsURN
    {
        public const string getPatientLabResults = "/Results/GetPatientLabResults";
        public const string markResultAsRead = "/Results/MarkResultAsRead";
        public const string getResultReport = "/Results/GetResultReport";
        public const string getPatientVisitInfoDetails = "/Results/GetPatientVisitInfoDetails";
        public const string getVisitLabOrderTurnaroundTime = "/Results/GetVisitLabOrderTurnaroundTime";
        public const string getVisitPaymentSummary = "/Results/GetVisitPaymentSummary";
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Results.Request;
using Theranos.Automation.ME.API.Model.API.Results.Response;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using RestSharp;
using Theranos.Automation.ME.API.Model.API.General.Response;

namespace Theranos.Automation.ME.API.Scripts
{
    public class ResultsScripts : RestSharpLib
    {

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-GetPatientLabResults
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetPatientLabResultsRequest && Response : GetPatientLabResultsDisplayResponse

        public GetPatientLabResultsDisplayResponse getPatientLabResults(RestClient client, object Json)
        {
            string urn = ResultsURN.getPatientLabResults;
            var request = constructPostRequest(urn, Json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getPatientLabResults Resp " + response);
            var result = JsonConvert.DeserializeObject<GetPatientLabResultsDisplayResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-MarkResultAsRead
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: MarkResultAsReadRequest && Response : BaseResponse

        public BaseResponse markResultAsRead(RestClient client, object json)
        {
            string urn = ResultsURN.markResultAsRead;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine("markResultAsRead Resp " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-GetPatientVisitInfoDetails
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetPatientVisitInfoDetailsRequest && Response : GetPatientVisitInfoDetailsResponse

        public GetPatientVisitInfoDetailsResponse getPatientVisitInfoDetails(RestClient client, object json)
        {
            string urn = ResultsURN.getPatientVisitInfoDetails;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getPatientVisitInfoDetails Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetPatientVisitInfoDetailsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-GetResultReport
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetResultReportRequest && Response : GetResultReportResponse

        public GetResultReportResponse getResultReport(RestClient client, object json)
        {
            string urn = ResultsURN.getResultReport;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            //   Console.WriteLine(" getResultReport Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetResultReportResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-GetResultReport
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetVisitLabOrderTurnaroundTimeRequest && Response : GetVisitLabOrderTurnaroundTimeResponse

        public GetVisitLabOrderTurnaroundTimeResponse getVisitLabOrderTurnaroundTime(RestClient client, object json)
        {
            string urn = ResultsURN.getVisitLabOrderTurnaroundTime;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine("getVisitLabOrderTurnaroundtime response : " + response);
            var result = JsonConvert.DeserializeObject<GetVisitLabOrderTurnaroundTimeResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;

        }
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Results-GetResultReport
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetVisitPaymentSummaryRequest && Response : GetVisitPaymentSummaryResponse

        public GetVisitPaymentSummaryResponse getVisitPaymentSummary(RestClient client, object json)
        {
            String urn = ResultsURN.getVisitPaymentSummary;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine("getVisitPaymentSummary : " + response);
            var result = JsonConvert.DeserializeObject<GetVisitPaymentSummaryResponse>(response);
            string assertMessage = (urn + "Failed. Response is :" + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;

        }
    }
}

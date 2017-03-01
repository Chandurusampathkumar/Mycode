using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Theranos.Automation.ME.API.Model.API.Orders.Response;
using Theranos.Automation.ME.API.Model.API.Orders.Request;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.General.Request;
using Theranos.Automation.ME.API.Model.API.General.Response;
using Theranos.Automation.ME.API.Model.API.Profile.Request;
using Theranos.Automation.ME.API.Model.API.Profile.Response;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.EndPoint;

namespace Theranos.Automation.ME.API.Scripts
{
    public class OrdersScripts:RestSharpLib
    {
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-GetSelfOrderableStates
        /// </summary>
        /// <param name="client"></param>
        /// <param name="obj"></param>
        ///  Request: AuthRequest && Response : GetSelfOrderableStatesResponse

        public GetSelfOrderableStatesResponse getSelfOrderableStates(RestClient client, object obj)
        {
            string urn = OrdersURN.getSelfOrderableStates;
            var request = constructPostRequest(urn, obj);
            var response = executeAsync(client, request);
            Console.WriteLine("getSelfOrderableStates Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetSelfOrderableStatesResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-GetPatientOrderableTests
        /// </summary>
        /// <param name="client"></param>
        /// <param name="obj"></param>
        ///  Request: GetPatientOrderableTestsRequest && Response : GetPatientOrderableTestsResponse

        public GetPatientOrderableTestsResponse getPatientOrderableTests(RestClient client, object obj)
       {
           string urn = OrdersURN.getPatientOrderableTests;
           var request = constructPostRequest(urn, obj);
           var response = executeAsync(client, request);
           var result = JsonConvert.DeserializeObject<GetPatientOrderableTestsResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           Console.WriteLine("From getPatientOrderableTests - No.Of orderable Tests: " + result.Tests.Count);
           return result;
       }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-GetLabOrders
        /// </summary>
       /// <param name="client"></param>
       /// <param name="obj"></param>
        ///  Request: GetLabOrdersRequest && Response : GetLabOrdersResponse

       public GetLabOrdersResponse getLabOrders(RestClient client, object obj)
        {
            string urn = OrdersURN.getLabOrders;
            var request = constructPostRequest(urn, obj);
            var response = executeAsync(client, request);
           // Console.WriteLine(" GetLabOrders Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetLabOrdersResponse>(response);
            Console.WriteLine("From getLabOrders : Total No. of Orders from all sources & Results = " + result.LabOrders.Count);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue( result.Code==0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-DeleteLabOrder
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: DeleteLabOrderRequest && Response : BaseResponse

       public BaseResponse deleteLabOrder(RestClient client, object json)
        {
            string urn = OrdersURN.deleteLabOrder;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" deleteLabOrder Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-SubmitPatientTests
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: SubmitPatientTestsRequest && Response : SubmitPatientTestsResponse

       public SubmitPatientTestsResponse submitPatientTests(RestClient client, object json)
        {
            string urn = OrdersURN.submitPatientTests;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" submitPatientTests Resp : " + response);
            var result = JsonConvert.DeserializeObject<SubmitPatientTestsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-SubmitLabOrderImage
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: SubmitLabOrderImageRequest && Response : SubmitLabOrderImageResponse

        public SubmitLabOrderImageResponse submitLabOrderImage(RestClient client, object json)
        {
            string urn = OrdersURN.submitLabOrderImage;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" submitLabOrderImage Resp : " + response);
            var result = JsonConvert.DeserializeObject<SubmitLabOrderImageResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Orders-RemoveRejectedLabOrderFromList
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: RemoveRejectedLabOrderFromListRequest && Response : .BaseResponse

        public BaseResponse removeRejectedLabOrderFromList(RestClient client,object json)
        {
            string urn = OrdersURN.removeRejectedLabOrderFromList;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" removeRejectedLabOrderFromList Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

    }
}

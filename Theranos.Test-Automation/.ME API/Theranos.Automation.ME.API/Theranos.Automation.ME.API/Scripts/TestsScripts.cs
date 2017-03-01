using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.API.Tests.Response;
using Theranos.Automation.ME.API.Model.API.Tests.Request;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.EndPoint;

namespace Theranos.Automation.ME.API.Scripts
{
    public class TestsScripts : RestSharpLib
    {
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Tests-GetAllTests
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: AuthRequest && Response : GetAllTestsResponse

        public GetAllTestsResponse getAllTests(RestClient client, object obj)
        {
            string urn = TestsURN.getAllTests;
            var request = constructPostRequest(urn, obj);
            var response = executeAsync(client, request);
            Console.WriteLine("getAllTests Resp" + response);
            var result = JsonConvert.DeserializeObject<GetAllTestsResponse>(response);
            //if(result.Tests.Count!=0)
            //{
            //    throw (new Exception("Tests/getAllTests Failed. This service still using v4 response type."));
            //}
            Console.WriteLine("Total No. of Cpts: {0}",result.Cpts.Count);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Tests-GetCptPanelMembers
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetCptPanelMembersRequest && Response : GetCptPanelMembersResponse

        public GetCptPanelMembersResponse getCptPanelMembers(RestClient client, object json)
        {
            string urn = TestsURN.getCptPanelMembers;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine("getCptPanelMembers Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetCptPanelMembersResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Tests-GetCptInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetCptInfoRequest && Response : GetCptInfoResponse

        public GetCptInfoResponse getCptInfo(RestClient client, object json)
        {
            string urn = TestsURN.getCptInfo;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine("getCptInfo Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetCptInfoResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Tests-GetPanelDetails
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetPanelDetailsRequest && Response : GetPanelDetailsResponse

        public GetPanelDetailsResponse getPanelDetails(RestClient client, object json)
        {
            string urn = TestsURN.getPanelDetails;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
        //  Console.WriteLine(" getPanelDetails Resp : "+response);
            var result = JsonConvert.DeserializeObject<GetPanelDetailsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            Console.WriteLine(" getPanelDetails Completed");
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Tests-GetAdvertisedTests
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetAdvertisedTestsRequest && Response : GetAdvertisedTestsResponse

        public GetAdvertisedTestsResponse getAdvertisedTests(RestClient client, object json)
        {
            string urn = TestsURN.getAdvertisedTests;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
             Console.WriteLine(" getAdvertisedTests Resp : "+response);
            var result = JsonConvert.DeserializeObject<GetAdvertisedTestsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
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
using Theranos.Automation.ME.API.Model.API.Physicians;
using Theranos.Automation.ME.API.Model.API.Others;

namespace Theranos.Automation.ME.API.Scripts
{
    public class OthersScripts : RestSharpLib
    {
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-ApiStatus
        /// </summary>
        /// <param name="client"></param>
        
        public string apiStatus(RestClient client)
        {
            string urn = OthersURN.ApiStatus;
            var request = constructGetRequest(urn);
            var response = executeAsync(client, request);
            Console.WriteLine(" apiStatus Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return response;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-Home-ApiStatus
        /// </summary>
        /// <param name="client"></param>
        
        public string homeApiStatus(RestClient client)
        {
            string urn = OthersURN.Home_ApiStatus;
            var request = constructGetRequest(urn);
            var response = executeAsync(client, request);
            Console.WriteLine(" Home/ApiStatus Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            return response;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-Home
        /// </summary>
        /// <param name="client"></param>
        
        public string homeGET(RestClient client)
        {
            string urn = OthersURN.Home;
            var request = constructGetRequest(urn);
            var response = executeAsync(client, request);
            Console.WriteLine(" GET/Home Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            return response;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-Home
        /// </summary>
        /// <param name="client"></param>
        
        public string homePOST(RestClient client)
        {
            string urn = OthersURN.Home;
            object obj = new { };
            var request = constructPostRequest(urn, obj);
            var response = executeAsync(client, request);
            Console.WriteLine(" POST/Home Resp : " + response);
            return response;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-Physicians_longitude_latitude_minDistance_maxDistance_unit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="latit"></param>
        /// <param name="longit"></param>
        /// <param name="maxDist"></param>
        /// <param name="distanceUnit"></param>
        /// Request URLSegments Model: GetPhysiciansRequest && Response : PhysicianResponse

        public List<PhysicianResponse> getPhysicians(RestClient client, double latit, double longit, double maxDist, string distanceUnit)
        {
            string urn = OthersURN.getPhysicians;     // Need to mention condition
            var request = constructGetRequest(urn);
            request.AddParameter("latitude", latit,ParameterType.UrlSegment);
            request.AddParameter("longitude", longit, ParameterType.UrlSegment);
            request.AddParameter("maxDistance", maxDist, ParameterType.UrlSegment);
            request.AddParameter("unit", distanceUnit, ParameterType.UrlSegment);
            var response = executeAsync(client, request);
            Console.WriteLine(" getPhysiciansRequest Resp : " + response);
            var result = JsonConvert.DeserializeObject<List<PhysicianResponse>>(response);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-TextContent
        /// </summary>
        /// <param name="client"></param>
        /// Response : TextContentResponse

        public TextContentResponse textContent(RestClient client)
        {
            string urn = OthersURN.TextContent;
            var request = constructGetRequest(urn);
            var response = executeAsync(client, request);
            Console.WriteLine(" TextContent Resp : " + response);
            var result = JsonConvert.DeserializeObject<TextContentResponse>(response);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/GET-TextContent/GetAll
        /// </summary>
        /// <param name="client"></param>
        /// Response : TextContentResponse

        public TextContentResponse textContentGetAll(RestClient client)
        {
            string urn = OthersURN.TextContentGetAll;
            var request = constructGetRequest(urn);
            var response = executeAsync(client, request);
            Console.WriteLine(" TextContent Resp : " + response);
            var result = JsonConvert.DeserializeObject<TextContentResponse>(response);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-TextCatalog
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        /// Request : GetTextCatalogItemsRequest && Response : GetTextCatalogItemsResponse
        
        public GetTextCatalogItemsResponse textCatalog(RestClient client,object json)
        {
            string urn = OthersURN.TextCatalog;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" textCatalog Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetTextCatalogItemsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-TextCatalog-GetItems
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        /// Request : GetTextCatalogItemsRequest && Response : GetTextCatalogItemsResponse

        public GetTextCatalogItemsResponse textCatalogGetItems(RestClient client, object json)
        {
            string urn = OthersURN.TextCatalogGetItems;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" textCatalogGetItems Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetTextCatalogItemsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
    }
}

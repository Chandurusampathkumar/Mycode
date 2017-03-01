using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Locations;
using Theranos.Automation.ME.API.Model.API.General.Response;

namespace Theranos.Automation.ME.API.Scripts
{
    public class LocationsScripts : RestSharpLib
    {

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-GetStoreLocations
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetStoreLocationsRequest && Response : GetStoreLocationsResponse

        public GetStoreLocationsResponse getStoreLocations(RestClient client, object json)
        {
            string urn = LocationsURN.getStoreLocations;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetStoreLocationsResponse>(response);
            Console.WriteLine(" getStoreLocations : No of Locations with in Range : " + result.locations.Count);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-GetRecentlyVisitedLocations
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: AuthRequest && Response : GetRecentlyVisitedLocationsResponse

        public GetRecentlyVisitedLocationsResponse GetRecentlyVisitedLocations(RestClient client, object json)
        {
            string urn = LocationsURN.getRecentlyVisitedLocations;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getRecentlyVisitedLocations Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetRecentlyVisitedLocationsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-GetRecentlyVisitedLocations
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: AuthRequest && Response : GetStoreLocationsResponse

        public GetStoreLocationsResponse getPatientFavoriteLocations(RestClient client, object json)
        {
            string urn = LocationsURN.getPatientFavoriteLocations;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getPatientFavoriteLocations Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetStoreLocationsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-GetLocations
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetLocationsRequest && Response : GetStoreLocationsResponse

        public GetStoreLocationsResponse getLocations(RestClient client, object json)
        {
            string urn = LocationsURN.getLocations;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetStoreLocationsResponse>(response);
            Console.WriteLine(" getLocations : No of Locations with in Range : " + result.locations.Count);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-DeletePatientFavoriteLocation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: DeletePatientFavoriteLocationRequest && Response : BaseResponse

        public BaseResponse deletePatientFavoriteLocation(RestClient client, object json)
        {
            string urn=LocationsURN.deletePatientFavoriteLocation;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" deletePatientFavoriteLocation Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-SetPatientFavoriteLocation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: SetPatientFavoriteLocationRequest && Response : BaseResponse

        public BaseResponse setPatientFavoriteLocation(RestClient client, object json)
        {
            string urn = LocationsURN.setPatientFavoriteLocation;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" setPatientFavoriteLocation Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
         

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Locations-GetHolidayInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GetHolidayInfoRequest && Response : GetHolidayInfoResponse

        public GetHolidayInfoResponse getHolidayInfo(RestClient client, object json)
        {
            string urn = LocationsURN.getHolidayInfo;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getHolidayInfo Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetHolidayInfoResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
    }
}

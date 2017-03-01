using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Appointments;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Model.API.General.Response;

namespace Theranos.Automation.ME.API.Scripts
{
    public class AppointmentScripts : RestSharpLib
    {
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-GetListOfServices
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request:GetListOfServicesRequest && Response : GetListOfServicesResponse

        public GetListOfServicesResponse getListOfServices(RestClient client, object json)
        {
            string urn = AppointmentsURN.GetListOfServices;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getListOfServicesResponse Resp : "+response);
            var result = JsonConvert.DeserializeObject<GetListOfServicesResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue( result.Code==0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-GetAvailableTimeSlots
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request:GetAvailableTimeSlotsRequest && Response : GetAvailableTimeSlotsResponse

        public GetAvailableTimeSlotsResponse getAvailableTimeSlots(RestClient client, object json)
        {
            string urn = AppointmentsURN.GetAvailableTimeSlots;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" GetAvailableTimeSlots Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetAvailableTimeSlotsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-GetFastingInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request:GetFastingInfoRequest && Response : GetFastingInfoResponse

        public GetFastingInfoResponse getFastingInfo(RestClient client, object json)
        {
            string urn = AppointmentsURN.GetFastingInfo;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" getFastingInfo Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetFastingInfoResponse>(response);
           
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-GetPatientAppointments
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request:AuthRequest && Response : GetPatientAppointmentsResponse

        public GetPatientAppointmentsResponse getPatientAppointments(RestClient client, object json)
        {
            string urn = AppointmentsURN.GetPatientAppointments;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" GetPatientAppointments Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetPatientAppointmentsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-SaveAppointment
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: SaveAppointmentRequest && Response : SaveAppointmentResponse

        public SaveAppointmentResponse saveAppointment(RestClient client, object json)
       {
            string urn = AppointmentsURN.SaveAppointment;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" saveAppointment Resp : " + response);
            var result = JsonConvert.DeserializeObject<SaveAppointmentResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
       }

        public string saveAppointmentWithJsonString(RestClient client,string json)
       {
           string urn = AppointmentsURN.SaveAppointment;
           var request = constructPostRequest(urn, json);
           var response = executeAsync(client, request);
           Console.WriteLine(" saveAppointment Resp : " + response);
           var result = JsonConvert.DeserializeObject<SaveAppointmentResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           return response;
       }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-CancelAppointment
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: CancelAppointmentRequest && Response : BaseResponse

        public BaseResponse cancelAppointment(RestClient client, object json)
       {
           string urn = AppointmentsURN.CancelAppointment;
           var request = constructPostRequest(urn, json);
           var response = executeAsync(client, request);
           Console.WriteLine(" CancelAppointment Resp : " + response);
           var result = JsonConvert.DeserializeObject<BaseResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           return result;
       }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-EarlyCheckInPatient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: EarlyCheckInPatientRequest && Response : EarlyCheckInPatientResponse

        public EarlyCheckInPatientResponse earlyCheckInPatient(RestClient client, object json)
       {
           string urn = AppointmentsURN.EarlyCheckInPatient;
           var request = constructPostRequest(urn, json);
           var response = executeAsync(client, request);
           Console.WriteLine(" EarlyCheckInPatient Resp : " + response);
           var result = JsonConvert.DeserializeObject<EarlyCheckInPatientResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           return result;
       }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-UpdateEarlyCheckIn
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: UpdateEarlyCheckInRequest && Response : BaseResponse

        public BaseResponse updateEarlyCheckIn(RestClient client, object json)
        {
           string urn=AppointmentsURN.UpdateEarlyCheckIn;
           var request = constructPostRequest(urn, json);
           var response = executeAsync(client, request);
           Console.WriteLine(" UpdateEarlyCheckIn Resp : " + response);
           var result = JsonConvert.DeserializeObject<BaseResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-CancelEarlyCheckIn
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: CancelEarlyCheckInRequest && Response : BaseResponse

        public BaseResponse cancelEarlyCheckIn(RestClient client, object json)
        {
            string urn = AppointmentsURN.CancelEarlyCheckIn;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" CancelEarlyCheckIn Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-SaveCheckInConsentForm
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: SaveCheckInConsentFormRequest && Response : BaseResponse

        public BaseResponse saveCheckInConsentForm(RestClient client, object json)
        {
            string urn = AppointmentsURN.SaveCheckInConsentForm;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" saveCheckInConsentForm Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Appointments-GeoCheckInPatient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="json"></param>
        ///  Request: GeoCheckInPatientRequest && Response : BaseResponse

        public BaseResponse geoCheckInPatient(RestClient client, object json)
        {
            string urn = AppointmentsURN.GeoCheckInPatient;
            var request = constructPostRequest(urn, json);
            var response = executeAsync(client, request);
            Console.WriteLine(" saveCheckInConsentForm Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
    }
}

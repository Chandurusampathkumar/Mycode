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


namespace Theranos.Automation.ME.API.Scripts
{

    public class ProfileScripts : RestSharpLib
    {

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetInsuranceCompanies
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="insuranceCompany"></param>
        /// <returns></returns>
        public GetInsuranceCompaniesResponse getInsuranceCompanies(string authToken,InsuranceCo insuranceCompany=null)
        {
            var response = PostRequestWithCookies<GetInsuranceCompaniesRequest>("Profile/GetInsuranceCompanies", new GetInsuranceCompaniesRequest(authToken, insuranceCompany)).Result;
            Console.WriteLine(" getInsuranceCompanies Resp : " + response);
            var insuranceCompanyResponse = JsonConvert.DeserializeObject<GetInsuranceCompaniesResponse>(response);
            var assertMessage = String.Format("GetDoctorList Failed. Code: {0}, Message: {1}", insuranceCompanyResponse.Code, insuranceCompanyResponse.Message);
            Assert.IsTrue(insuranceCompanyResponse.Code == ErrorCodes.SUCCESS, assertMessage);
            return insuranceCompanyResponse;
        }

     
// ------------------------------------------------------------------------------------------------------------------------ //
       
 /*      
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-SetBasicPatientInfo
        /// </summary>
        /// <param name="URN"></param>
        /// <param name="basicInfo"></param>
        /// <param name="authToken"></param>
        ///  Request: SetBasicPatientInfoRequest && Response : BaseResponse
       
        public BaseResponse setBasicPatientInfo(string URN,PatientBasicInfo basicInfo,string authToken)
        {
                  // AddressDataSetAPI.csv is required
            var respRaw = PostRequestWithCookies<SetBasicPatientInfoRequest>(URN, new SetBasicPatientInfoRequest(authToken,basicInfo)).Result;
            var basicPatientInfo = JsonConvert.DeserializeObject<BaseResponse>(respRaw);
            Console.WriteLine(" Code is : {0} Message is : {1} ", basicPatientInfo.Code, basicPatientInfo.Message);
            var assertMessage = String.Format("getpatientDoctors Failed. Code: {0}, Message: {1}", basicPatientInfo.Code, basicPatientInfo.Message);
            Assert.IsTrue(basicPatientInfo.Code == 0, assertMessage);
            return basicPatientInfo;
        }
*/
      
//-------------------------------------------RestSharp---------------------------------------------------------//

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetInsuranceCompanies
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: GetInsuranceCompaniesRequest && Response : GetInsuranceCompaniesResponse

        public GetInsuranceCompaniesResponse getInsuranceCompanies(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.getInsuranceCompanies;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetInsuranceCompaniesResponse>(response);
            Console.WriteLine(" getInsuranceCompanies Resp : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }



        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetEmergencyContacts
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: AuthRequest && Response : GetEmergencyContactsResponse

        public GetEmergencyContactsResponse getEmergencyContacts(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.getEmergencyContacts;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetEmergencyContactsResponse>(response);
            Console.WriteLine(" getEmergencyContacts Resp : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


         /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetPatientData
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        public GetPatientDataResponse GetPatientData(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.getPatientData;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetPatientDataResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetDoctorList
        /// </summary>
        /// <param name="URN"></param>
        /// <param name="basicInfo"></param>
        /// <param name="jsonObject"></param>
        ///  Request: GetDoctorListRequest && Response : GetDoctorListResponse

        public GetDoctorListResponse getDoctorList(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.getDoctorList;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
        //  Console.WriteLine(" getDoctorList Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetDoctorListResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetGuardianInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: AuthRequest && Response : GetGuardianInfoResponse

        public GetGuardianInfoResponse getGuardianInfo(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.getGuardianInfo;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" getGuardianInfo Resp " + response);
            var result = JsonConvert.DeserializeObject<GetGuardianInfoResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetPatientDoctors
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: AuthRequest && Response : GetPatientDoctors
        
        public GetPatientDoctors getPatientDoctors(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.getPatientDoctors;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine("GetPatientDoctors" + response);
            var result = JsonConvert.DeserializeObject<GetPatientDoctors>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetMedicalHistory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: AuthRequest && Response : GetMedicalHistoryResponse

        public GetMedicalHistoryResponse getMedicalHistory(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.getMedicalHistory;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" getMedicalHistory : " + response);
            var result = JsonConvert.DeserializeObject<GetMedicalHistoryResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

       
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-DeleteEmergencyContact
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: DeleteEmergencyContactRequest && Response : BaseResponse

        public BaseResponse deleteEmergencyContact(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.deleteEmergencyContact;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" deleteEmergencyContact : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-DeletePatientGuardianInfo
        /// </summary>
       /// <param name="client"></param>
       /// <param name="jsonObject"></param>
        ///  Request: DeletePatientGuardianInfoRequest && Response : BaseResponse

        public BaseResponse DeletePatientGuardianInfo(RestClient client, object jsonObject)
       {
           string urn = ProfileURNs.deletePatientGuardianInfo;
           var request = constructPostRequest(urn, jsonObject);
           var response = executeAsync(client, request);
           Console.WriteLine(" DeletePatientGuardianInfo Resp : " + response);
           var result = JsonConvert.DeserializeObject<BaseResponse>(response);
           string assertMessage = (urn + " Failed. Response is : " + response);
           Assert.IsTrue(result.Code == 0, assertMessage);
           return result;
       }

       
        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-ValidateZipCode
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: SetPatientDoctorRequest && Response : BaseResponse

        public BaseResponse validateZipCode(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.validateZipCode;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" validateZipCode Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-GetPatientInsurances
        /// </summary>
        /// <param name="URN"></param>
        /// <param name="basicInfo"></param>
        /// <param name="jsonObject"></param>
        ///  Request: AuthRequest && Response : GetPatientInsurancesResponse

        public GetPatientInsurancesResponse getPatientInsurances(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.getPatientInsurances;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" getPatientInsurances Resp : " + response);
            var result = JsonConvert.DeserializeObject<GetPatientInsurancesResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-UpdatePatientEmailAddress
        /// </summary>
        /// <param name="URN"></param>
        /// <param name="basicInfo"></param>
        /// <param name="jsonObject"></param>
        ///  Request: UpdatePatientEmailAddressRequest && Response : BaseResponse

        public BaseResponse updatePatientEmailAddress(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.updatePatientEmailAddress;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" updatePatientEmailAddress Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-SetPatientDoctor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: SetPatientDoctorRequest && Response : BaseResponse

        public BaseResponse setPatientDoctor(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.setPatientDoctor;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" setPatientDoctor Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-SetPatientEmergencyContacts
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: SetPatientEmergencyContactsRequest && Response : SetPatientEmergencyContactsResponse

        public SetPatientEmergencyContactsResponse setPatientEmergencyContacts(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.setPatientEmergencyContacts;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" setPatientEmergencyContacts Resp : " + response);
            var result = JsonConvert.DeserializeObject<SetPatientEmergencyContactsResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-SetPatientGuardianInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: SetPatientGuardianInfoRequest && Response : SetPatientGuardianInfoResponse

        public SetPatientGuardianInfoResponse setPatientGuardianInfo(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.setPatientGuardianInfo;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" SetPatientGuardianInfo Resp : " + response);
            var result = JsonConvert.DeserializeObject<SetPatientGuardianInfoResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-DeletePatientDoctor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: DeletePatientDoctorRequest && Response : BaseResponse
        
        public BaseResponse deletePatientDoctor(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.deletePatientDoctor;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" deletePatientDoctor Resp : " + response);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Profile-SetPatientInsurance
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Request: SetPatientInsuranceRequest && Response : SetPatientInsuranceResponse
        
        public SetPatientInsuranceResponse setPatientInsurance(RestClient client,object jsonObject)
        {
            string urn = ProfileURNs.setPatientInsurance;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            Console.WriteLine(" setPatientInsurance Resp : " + response);
            var result = JsonConvert.DeserializeObject<SetPatientInsuranceResponse>(response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Profile-SetBasicPatientInfo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: SetBasicPatientInfoRequest && Response : BaseResponse

        public BaseResponse setBasicPatientInfo(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.setBasicPatientInfo;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" setBasicPatientInfo Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Profile-SetPatientInsuranceImage
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: SetPatientInsuranceImageRequest && Response : SetPatientInsuranceImageResponse

        public SetPatientInsuranceImageResponse setPatientInsuranceImage(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.setPatientInsuranceImage;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<SetPatientInsuranceImageResponse>(response);
            Console.WriteLine(" setPatientInsuranceImage Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;

        }

        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Profile-GetPatientInsuranceImage
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: GetPatientInsuranceImageRequest && Response : GetPatientInsuranceImageResponse

        public GetPatientInsuranceImageResponse getPatientInsuranceImage(RestClient client, object jsonObject)
        {
            string urn = ProfileURNs.getPatientInsuranceImage;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetPatientInsuranceImageResponse>(response);
            Console.WriteLine("From GetPatientInsuranceImage: ImageId : " + result.ImageId);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
    }
}

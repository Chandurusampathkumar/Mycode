using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using RestSharp.Reflection;
using RestSharp.Validation;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Text;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using Theranos.Automation.ME.API.Model.API.General.Request;
using Theranos.Automation.ME.API.Model.API.General.Response;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.Data;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.Web.WebTestScripts;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Interactions;


namespace Theranos.Automation.ME.API.Scripts
{
    public class AccountScripts : RestSharpLib
    {

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-Login
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : LoginRequest && Response : WebLoginResponse

        public WebLoginResponse loginForAuthToken(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.login;
            var request = constructPostRequest(urn, jsonObject);
            Console.WriteLine("Json Object: " + jsonObject);
            var loginData = JsonConvert.SerializeObject(jsonObject);
            Console.WriteLine("URI : " + APIbase + urn);
            Console.WriteLine("Login Credentials : " + loginData);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<WebLoginResponse>(response);
            Console.WriteLine("Login Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        // Login Using Json string

        public string loginWithJsonString(RestClient client, string jString)
        {
            string urn = AccountURNs.login;
            var request = constructPostRequest(urn, jString);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<WebLoginResponse>(response);
            Console.WriteLine("Login Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return response;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-Logout
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : AuthRequest && Response : BaseResponse

        public BaseResponse logout(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.logout;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" Logout Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-FindUserByEmail
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : FindUserByEmailRequest && Response : BaseResponse

        public BaseResponse findUserByEmail(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.findUserByEmail;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" findUserByEmail Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-SendEmailForRetrieveUserName
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : SendEmailForRetrieveUserNameRequest && Response : CommunicateToUserResponse

        public CommunicateToUserResponse sendEmailForRetrieveUserName(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.sendEmailForRetriveUsername;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            Console.WriteLine(" sendEmailForRetrieveUserName Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-GetAccountEmailAddress
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : AuthRequest && Response : GetAccountEmailAddressResponse

        public GetAccountEmailAddressResponse getAccountEmailAddress(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.getAccountEmailAddress;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetAccountEmailAddressResponse>(response);
            Console.WriteLine(" getAccountEmailAddress Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-SendEmailForPasswordReset
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request : SendEmailForPasswordResetRequest && Response : CommunicateToUserResponse

        public CommunicateToUserResponse sendEmailForPasswordReset(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.sendEmailForPasswordReset;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            Console.WriteLine(" sendEmailForPasswordReset Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-WebLogin
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: WebLoginRequest && Response : CommunicateToUserResponse

        public CommunicateToUserResponse webLogin(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.webLogin;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            int resultCode = (int)result.Code;
            // Console.WriteLine(" webLogin Response : " + response);
            string errortMessage = (urn + " Failed. Response is : " + response);
            if (resultCode == 301)   // If user logs in first time on a device
            {
                Console.WriteLine("Two step Authentication triggered");
                Console.WriteLine(" WebLogin Response : " + response);
            }
            else if (resultCode == 0)  // if user logs in as returning user
            {
                Console.WriteLine(" Weblogin Resp : " + response);
            }
            else
            {
                throw (new Exception(errortMessage));
            }
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-WebLoginWithPin
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: WebLoginWithPinRequest && Response : WebLoginResponse

        public WebLoginResponse webLoginWithPin(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.webLoginWithPin;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<WebLoginResponse>(response);
            Console.WriteLine(" webLoginWithPin Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);

            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-ChangePassword
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: UserIdPassword && Response : BaseResponse

        public BaseResponse changePassword(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.changePassword;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" changePassword Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-SendActivationEmail
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: SendActivationEmailRequest && Response : CommunicateToUserResponse

        public CommunicateToUserResponse sendActivationEmail(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.sendActivationEmail;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            Console.WriteLine(" sendActivationEmail Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-GetSecurityQuestions
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: GetSecurityQuestionsRequest && Response : GetSecurityQuestionsResponse

        public GetSecurityQuestionsResponse getSecurityQuestions(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.getSecurityQuestion;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetSecurityQuestionsResponse>(response);
            Console.WriteLine(" getSecurityQuestions Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-ResetPassword
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: UserIdPassword && Response : BaseResponse

        public BaseResponse resetPassword(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.resetPassword;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" resetPassword Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-CreateShellUserAccount
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: UserCreationInfo && Response : CommunicateToUserResponse

        public CommunicateToUserResponse createShellUserAccount(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.createShellUserAccount;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            Console.WriteLine(" createShellUserAccount Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v4/Help/Api/POST-Account-Activate_activationCode
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        ///  Response : BaseResponse

        public BaseResponse activate_activationCode(RestClient client, string code)
        {
            string urn = AccountURNs.activate_ActivationCode;
            var request = constructPostRequest(urn);
            request.AddParameter("activationCode", code, ParameterType.UrlSegment);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" Account_activate_activationCode Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Account-ResendProfilePin
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: PatientBasicInfo && Response : CommunicateToUserResponse

        public CommunicateToUserResponse resendProfilePin(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.createShellUserAccount;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<CommunicateToUserResponse>(response);
            Console.WriteLine(" resendProfilePin Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }


        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Account-LinkUserToARecord
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: LinkRecordInfo && Response : BaseResponse

        public BaseResponse linkUserToARecord(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.linkUserToARecord;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine(" linkUserToARecord Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        /// <summary>
        /// http://alpha:1212/api/v5/Help/Api/POST-Account-SendMessageForContactInfoUpdate
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonObject"></param>
        /// Request: ContactInfoUpdateRequest && Response : UserMessageResponse

        public UserMessageResponse sendMessageForContactInfoUpdate(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.SendMessageForContactInfoUpdate;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<UserMessageResponse>(response);
            Console.WriteLine(" sendMessageForContactInfoUpdate Response : " + response);
            string assertMessage = (urn + " Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }

        public GetSecurityQuestionsResponse getSecurityQuestionsAuthenticated(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.getSecurityQuestionsAuthenticated;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<GetSecurityQuestionsResponse>(response);
            Console.WriteLine("getSecurityQuestionsResponse : " + response);
            string assertMessage = (urn + "Failed. Response is : " + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;

        }
        public BaseResponse changeSecurityQuestions(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.changeSecurityQuestions;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine("ChangeSecurityQestions :" + response);
            string assertMessage = (urn + "Failed.Response is :" + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
        public UserMessageResponse resendMessageForContactInfoUpdate(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.ResendMessageForContactInfoUpdate;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<UserMessageResponse>(response);
            Console.WriteLine("resendmessageforContactInfoupdate :" + response);
            string assertMessage = (urn + "Failed.Response is" + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;
        }
        public BaseResponse cancelContactInfoUpdate(RestClient client, object jsonObject)
        {
            string urn = AccountURNs.CancelcontactinfoUpdate;
            var request = constructPostRequest(urn, jsonObject);
            var response = executeAsync(client, request);
            var result = JsonConvert.DeserializeObject<BaseResponse>(response);
            Console.WriteLine("resendmessageforContactInfoupdate :" + response);
            string assertMessage = (urn + "Failed.Response is" + response);
            Assert.IsTrue(result.Code == 0, assertMessage);
            return result;

        }
    }
}

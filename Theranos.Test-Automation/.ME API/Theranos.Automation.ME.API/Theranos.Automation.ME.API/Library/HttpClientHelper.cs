using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Library
{
    public class HttpClientHelper:LibrarySettings
    {
        public static string ContentType = "application/JSON";

        public static CookieCollection AuthCookies = null;
        public static Cookie sessionCookie=null;
        
        public static async Task<string> PostRequestWithCookies<T>(string urlPath, T jsonParameters)
        {
            if (AuthCookies == null)
            {
                throw new Exception("No Cookies are available");
            }

            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            
            handler.CookieContainer.Add(AuthCookies); 
            HttpResponseMessage response = await client.PostAsJsonAsync<T>(urlPath, jsonParameters);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }


        public static async Task<string> PostRequestWithoutCookies<T>(string urlPath, T jsonParameters)
        {

            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            HttpResponseMessage response = await client.PostAsJsonAsync<T>(urlPath, jsonParameters);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }

        public static async Task<string> PostRequestWithCookies(string urlPath)
        {
            if (AuthCookies == null)
            {
                throw new Exception("No Cookies are available");
            }
            var handler = new HttpClientHandler();
            handler.CookieContainer.Add(AuthCookies);
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            HttpResponseMessage response = await client.PostAsync(urlPath, null);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostRequestWithoutCookies(string urlPath)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsync(urlPath, null);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }

        public static async Task<string> PostRequestAndSaveCookies<T>(string urlPath, T jsonParameters)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync<T>(urlPath, jsonParameters);
            //response.EnsureSuccessStatusCode();

            AuthCookies = handler.CookieContainer.GetCookies(client.BaseAddress);
            
            return await response.Content.ReadAsStringAsync();

        }

        public static void ClearCookies()
        {
            AuthCookies = null;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------//

        public static async Task<string> PostRequest_WithCookies<T>(string urlPath, T jsonParameters,CookieCollection cCollection)
        {
            if (cCollection.Count == 0)
            {
                throw new Exception("No Cookies are available");
            }
            CookieContainer cookiecon = new System.Net.CookieContainer();
            
            foreach (Cookie cok in cCollection)
            {
                sessionCookie =new Cookie(cok.Name,cok.Value,cok.Path,cok.Domain);
                Console.WriteLine("Cookie Name : {0} Value {1} Path {2} domain {3} ", cok.Name,cok.Value,cok.Path,cok.Domain);
            }
            Uri target = new Uri("http://alpha:1212/api/v4");
            cookiecon.Add(sessionCookie);
            var handler = new HttpClientHandler();
            handler.UseCookies = true;
            handler.CookieContainer.Add(sessionCookie);
            handler.CookieContainer.Add(target, sessionCookie);
            handler.CookieContainer.GetCookieHeader(target);
            
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(EndPoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = await client.PostAsJsonAsync<T>(urlPath, jsonParameters);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
 
    }
}


// Old Code

        //public static string SessionKey = "ASP.NET_SessionId";
        //public static string SessionValue = null;
//    public static string Request(string urlPath, string jsonParameters,Verb method)
//{

//
//var httpWebRequest = (HttpWebRequest)WebRequest.Create(EndPoint + urlPath);
//    httpWebRequest.ContentType = "text/json";
//    httpWebRequest.Method = "POST";

//    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
//    {
//        string json = "{\"x\":\"true\"}";

//        streamWriter.Write(jsonParameters);
//        streamWriter.Flush();
//    }

//    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
//    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
//    {
//        var result = streamReader.ReadToEnd();
//        return result;
//    }
//


//    var request = (HttpWebRequest)WebRequest.Create(EndPoint + urlPath);
//    request.Method = method.ToString();
//    request.ContentLength = 0;
//    request.ContentType = ContentType;
//    if (!string.IsNullOrEmpty(SessionValue))
//    {
//        request.Headers.Add(SessionKey, SessionValue);
//    }



//    if (!string.IsNullOrEmpty(jsonParameters))
//    {
//        request.ContentLength = Encoding.UTF8.GetByteCount(jsonParameters);
//        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
//        {
//            streamWriter.Write(jsonParameters);
//        }    
//    }

//    using (var response = (HttpWebResponse)request.GetResponse())
//    {
//        var responseValue = string.Empty;

//        if (response.StatusCode != HttpStatusCode.OK)
//        {
//            var message = String.Format("Failed: Received HTTP {0}", response.StatusCode);
//            Assert.Fail(message);
//        }

//        using (var responseStream = response.GetResponseStream())
//        {
//            if (responseStream != null)
//                using (var reader = new StreamReader(responseStream))
//                {
//                    responseValue = reader.ReadToEnd();
//                }
//        }

//        string sessionValue = response.Headers.Get("Set-Cookie");
//        if (sessionValue!=null)
//        {   
//            SessionValue=sessionValue.Split('=',';')[1];
//        }

//        return responseValue;
//    }
//}
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace ServiceTests.Auth
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CookieSetterBehavior : Attribute, IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public static string Cookie;
        public static string Token;


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new MyMessageInspector());
        }

        internal class MyMessageInspector : IClientMessageInspector
        {
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                object requestProperty = new HttpRequestMessageProperty();
                if (!request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out requestProperty))
                {
                    requestProperty = new HttpRequestMessageProperty();
                    request.Properties.Add(
                        HttpRequestMessageProperty.Name, requestProperty);
                }
                HttpRequestMessageProperty p = (HttpRequestMessageProperty)requestProperty;
                p.Headers.Add(HttpRequestHeader.Cookie, Cookie);
                request.Headers.Add(MessageHeader.CreateHeader("token", "http://schemas.theranos.com/psc", Token));

                var testCaseDescription = GetMethodBase();
                //Adding Test Descriptions
                if (testCaseDescription != null)
                {
                    request.Headers.Add(MessageHeader.CreateHeader("TestCaseId", "http://schemas.theranos.com/psc", testCaseDescription.TestCaseId));
                    request.Headers.Add(MessageHeader.CreateHeader("TestDescription", "http://schemas.theranos.com/psc", testCaseDescription.TestDescription));
                    request.Headers.Add(MessageHeader.CreateHeader("IsNegativeCase", "http://schemas.theranos.com/psc", testCaseDescription.IsNegativeCase.ToString()));
                    request.Headers.Add(MessageHeader.CreateHeader("MethodDescription", "http://schemas.theranos.com/psc", testCaseDescription.MethodDescription));

                }

                return Guid.NewGuid();
            }

            private TestCaseDescription  GetMethodBase()
            {
                var stackTrace = new StackTrace();
                foreach (var stackFrame in stackTrace.GetFrames())
                {
                    MethodBase methodBase = stackFrame.GetMethod();
                    Object[] attributes = methodBase.GetCustomAttributes(
                        typeof (TestCaseDescription), false);
                    if (attributes.Length >= 1)
                    {
                        return (TestCaseDescription) attributes.First();
                    }
                }
                return null;
            }


            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }
        }

        public static void FormatAndSetCookie(string input)
        {
            string[] cookies = input.Split(new[] { ',', ';' });
            var buffer = new StringBuilder(input.Length * 10);
            foreach (string entry in cookies)
            {
                if (entry.IndexOf("=") > 0 && !entry.Trim().StartsWith("path") && !entry.Trim().StartsWith("expires"))
                {
                    buffer.Append(entry).Append("; ");
                }
            }
            if (buffer.Length > 0)
            {
                buffer.Remove(buffer.Length - 2, 2);
            }

            Cookie = buffer.ToString();
        }
    }
}
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ServiceTests.Auth
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class TokenSetterBehavior : Attribute, IEndpointBehavior
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

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new MyMessageInspector());
        }

        internal class MyMessageInspector : IClientMessageInspector
        {
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                string token = "Hello";
                request.Headers.Add(MessageHeader.CreateHeader("token", "http://schemas.theranos.com/psc", token));
                return Guid.NewGuid();
            }


            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }
        }
    }
}
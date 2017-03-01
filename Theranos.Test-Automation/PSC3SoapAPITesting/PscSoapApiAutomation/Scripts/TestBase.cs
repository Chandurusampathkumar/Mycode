using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PscSoapApiAutomation.PSC3API;
using ServiceTests.Auth;

//@author Fangming Lu

namespace PscSoapApiAutomation.Scripts
{
    public abstract class TestBase
    {
        public IPscService PscService { get; private set; }
    
        public virtual void Setup()
        {
            PscService = new PscServiceClient();

            using (new OperationContextScope(PscService.GetChannel()))
            {
                var response = PscService.Login("labtech@theranos.com", "Theranos#123", GetMacAddress());
                CookieSetterBehavior.Cookie = null;
                CookieSetterBehavior.Token = null;
                var authenticationResult = response.ResponseData;

                var properties = OperationContext.Current.IncomingMessageProperties;
                var responseProperty = (HttpResponseMessageProperty)properties[HttpResponseMessageProperty.Name];
                var cookie = responseProperty.Headers[HttpResponseHeader.SetCookie];
                CookieSetterBehavior.FormatAndSetCookie(cookie);
                CookieSetterBehavior.Token = authenticationResult.Token;
            }
        }

        [TearDown]
        public void TearDown()
        {
            PscService.GetChannel().Abort();
        }
                public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            var sMacAddress = String.Empty;

            if (nics.Any())
            {
                var adapter = nics
                    .Where(p => p.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    .OrderBy(nic => nic.GetIPProperties().GetIPv4Properties().Index)
                    .FirstOrDefault() ?? nics.FirstOrDefault();

                if (adapter != null)
                {
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }

            }
            return sMacAddress;
        }     
    }

    public static class Extensions
    {
        public static IContextChannel GetChannel(this IPscService receiveService)
        {
            return ((ClientBase<IPscService>)receiveService).InnerChannel;
        }
    }    
    
}

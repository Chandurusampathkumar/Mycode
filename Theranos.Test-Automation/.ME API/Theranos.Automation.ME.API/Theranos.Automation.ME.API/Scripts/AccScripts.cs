using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Model.EndPoint;
using RestSharp;
using RestSharp.Extensions;

namespace Theranos.Automation.ME.API.Scripts
{
    public class AccScripts:RestSharpLib
    {
        public RestRequest login(object JsonObject)
        {
            var request = constructRequest("Account/Login", JsonObject);
            return request;
        }

    }
}

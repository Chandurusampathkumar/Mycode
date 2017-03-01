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


namespace Theranos.Automation.ME.API.Scripts
{
    public class ProScripts:RestSharpLib
    {
        public RestRequest getEmergencyContacts(object JsonObject)
        {
           
            var request = constructRequest("Profile/GetEmergencyContacts", JsonObject);
            return request;
        }
    }
}

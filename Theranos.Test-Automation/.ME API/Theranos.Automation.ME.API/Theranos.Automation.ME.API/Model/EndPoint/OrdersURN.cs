using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class OrdersURN
    {
        public const string getSelfOrderableStates = "/Orders/GetSelfOrderableStates";
        public const string getPatientOrderableTests = "/Orders/GetPatientOrderableTests";
        public const string submitPatientTests ="/Orders/SubmitPatientTests";
        public const string deleteLabOrder ="/Orders/DeleteLabOrder";
        public const string getLabOrders ="/Orders/GetLabOrders";
        public const string submitLabOrderImage ="/Orders/SubmitLabOrderImage";
        public const string removeRejectedLabOrderFromList  = "/Orders/RemoveRejectedLabOrderFromList";
    }
}

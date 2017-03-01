using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class OthersURN
    {

        // API
        public const string ApiStatus = "/ApiStatus";
        public const string Home = "/Home";
        public const string Home_ApiStatus = "/Home/ApiStatus";
        // Physicians
        public const string getPhysicians = "/Physicians?longitude={longitude}&latitude={latitude}&minDistance={minDistance}&maxDistance={maxDistance}&unit={unit}";
        // TextCatalog
        public const string TextCatalog = "/TextCatalog";
        public const string TextCatalogGetItems = "TextCatalog/GetItems";
        // TextContent
        public const string TextContent = "/TextContent";
        public const string TextContentGetAll = "/TextContent/GetAll";
        // LegalForms
        public const string LegalForms = "/LegalForms?id={id}";
        public const string LegalFormsGetForm = "/LegalForms/GetForm/{id}";
    }
}

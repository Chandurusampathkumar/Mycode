using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.Models;

namespace Theranos.Automation.ME.API.Model.API.Others
{
    public class GetTextCatalogItemsRequest
    {
        public List<TextCatalogItemRequest> Items { get; set; }
        public string Locale { get; set; }
        public DateTime ModifiedSince { get; set; }
        public bool GetInactiveItems { get; set; }
    }
}

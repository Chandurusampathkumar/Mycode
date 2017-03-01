using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Model.Common.Models;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;

namespace Theranos.Automation.ME.API.Model.API.Others
{
    public class GetTextCatalogItemsResponse
    {
        public List<TextCatalogItem> CatalogItems { get; set; }
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}

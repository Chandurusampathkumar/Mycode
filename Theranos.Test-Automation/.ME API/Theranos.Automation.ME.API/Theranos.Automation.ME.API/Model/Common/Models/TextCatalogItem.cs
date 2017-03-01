using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.Models
{
    public class TextCatalogItem
    {
        public string Id { get; set; }  // The string is supposed to be "MongoDB.Bson.ObjectId"
        public string Category { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public string LocalizedValue { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.Models
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.Models.CustomPanel
    /// </summary>
    public class CustomPanel
    {
        public string CptCode { get; set; }
        public decimal TheranosPrice { get; set; }
        public List<Dictionary<string, dynamic>> Prices { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TheranosId { get; set; }
        public bool IsVisible { get; set; }
        public string AtAGlance { get; set; }
        public string TestSample { get; set; }
        public string TheTest { get; set; }
        public string CommonQuestions { get; set; }
        public string AaccGuid { get; set; }
        public bool WebVisible { get; set; }
    }
}

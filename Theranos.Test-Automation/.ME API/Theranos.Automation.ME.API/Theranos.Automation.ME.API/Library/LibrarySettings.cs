using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Library
{
    public class LibrarySettings
    {
        public TestContext TestContext { get; set; }
        public static string EndPoint = @ConfigurationManager.AppSettings["EndPoint"];
    }
}

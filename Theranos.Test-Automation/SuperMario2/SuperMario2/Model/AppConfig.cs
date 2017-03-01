using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;

namespace SuperMario2.Model
{
    class AppConfig
    {
        public static string ServerAddress = ConfigurationManager.AppSettings["ServerAddress"];
        public static string SM2App = @ConfigurationManager.AppSettings["SM2App"];
    }
}

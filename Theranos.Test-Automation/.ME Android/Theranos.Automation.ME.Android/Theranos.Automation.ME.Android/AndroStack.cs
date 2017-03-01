using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;

namespace Theranos.Automation.ME.Android
{
    public class AndroStack
    {
        public static int CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeout"]);
        public static int ImplicitTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitTimeout"]);

        public static string ServerAddress = ConfigurationManager.AppSettings["ServerAddress"];
        public static string Password = @ConfigurationManager.AppSettings["password"];


        public static string ApkPath = @ConfigurationManager.AppSettings["ApkPath"];
        public static string TestEnvironment = ConfigurationManager.AppSettings["MEAndroidEnvironment"];
        public static string InputDirectoryDev = @ConfigurationManager.AppSettings["MEAndroidDevDataDirectory"];
        public static string InputDirectoryProd = @ConfigurationManager.AppSettings["MEAndroidProdDataDirectory"];

        public static string appiumserverpath = @ConfigurationManager.AppSettings["AppiumFilepath"];
        public static string startserver = @ConfigurationManager.AppSettings["Startcmd"];
        public static string Adbpath = @ConfigurationManager.AppSettings["adblocation"];
        public static string LaunchEmulator = @ConfigurationManager.AppSettings["EmulatorlaunchCMD"];
        public static string Closeapp = @ConfigurationManager.AppSettings["Appclose"];
        public static string Emulatorunlock = @ConfigurationManager.AppSettings["unlockemulator"];
        
     

        public const string ProductionEnvironment = "Live";
        public const string DevelopmentEnvironment = "Dev";

        public const int WaitTime = 1000;

        public static string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        public static string UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        public static string GetInputDirectoryDev()
        {
            return Path.Combine(UserHome, InputDirectoryDev);
        }

        public static string GetOutputDirectoryDev()
        {
            return Path.Combine(UserHome, InputDirectoryDev);
        }
        
    }
}

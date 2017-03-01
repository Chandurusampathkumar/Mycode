using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;

namespace Theranos.Automation.AutoStack
{
    public class AutoStack
    {
        public static int Interval = Convert.ToInt32(ConfigurationManager.AppSettings["Interval"]);
        public static int MaxWait = Convert.ToInt32(ConfigurationManager.AppSettings["MaxWait"]);

        public static DateTime StartTime;

        public static void Wait()
        {
            Thread.Sleep(Interval);
        }

        public static bool IsMaxWaitNotElapsed()
        {
            if ((DateTime.Now - StartTime).TotalSeconds <= MaxWait)
            {
                return true;
            }
            return false;
        }

        public static string AppName = @ConfigurationManager.AppSettings["AppName"];
        //public static string AppWindowName = @ConfigurationManager.AppSettings["AppWindowName"];
        public static string AppPath = @ConfigurationManager.AppSettings["AppPath"];

        //SM2

        public static string SM2AppName = @ConfigurationManager.AppSettings["SM2AppName"];
        //public static string AppWindowName = @ConfigurationManager.AppSettings["AppWindowName"];
        public static string SM2AppPath = @ConfigurationManager.AppSettings["SM2AppPath"];

        //LIS

        public static string LISAppName = @ConfigurationManager.AppSettings["LISAppName"];
        public static string LISAppWindowName = @ConfigurationManager.AppSettings["LISAppWindowName"];
        public static string LISAppPath = @ConfigurationManager.AppSettings["LISAppPath"];

        public static string TestEnvironment = ConfigurationManager.AppSettings["Environment"];
        public static string InputDirectoryDev = @ConfigurationManager.AppSettings["DevDataDirectory"];
        public static string InputDirectoryProd = @ConfigurationManager.AppSettings["ProdDataDirectory"];
        public static string InputDirectoryIntegration = @ConfigurationManager.AppSettings["IntegrationDataDirectory"];

        public const string ProductionEnvironment = "Live";
        public const string DevelopmentEnvironment = "Dev";
        public const string IntegrationEnvironment = "Integration";
        





        public const int WaitTime = 1000;

        public static string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        public static string UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        public static string GetAppPath()
        {
            return Path.Combine(StartMenu, AppPath);
        }

        //SM2 APP path
        public static string GetAppPathSM2()
        {
            return Path.Combine(StartMenu, SM2AppPath);
        }

        //LIS App path
        public static string GetLISAppPath()
        {
            return Path.Combine(StartMenu, LISAppPath);
        }

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

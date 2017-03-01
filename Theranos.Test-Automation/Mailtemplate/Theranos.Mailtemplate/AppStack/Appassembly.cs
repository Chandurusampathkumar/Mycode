using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Theranos.Mailtemplate.Report.Mail;

namespace Theranos.Mailtemplate.AppStack
{
    [TestClass]
    public class Appassembly
    {


        public static string IntegrationFile = @ConfigurationManager.AppSettings["IPTrxfilepath"];
        public static string IntergrationExFile = @ConfigurationManager.AppSettings["IPTrxExitedfilepath"];
        public static string MEAndroidFile = @ConfigurationManager.AppSettings["MEAndroidTrxfilepath"];
        public static string MEAndrodExFile = @ConfigurationManager.AppSettings["MEAndroidTrxExitedfilepath"];
        public static string PSCFile = @ConfigurationManager.AppSettings["PSCTrxfilepath"];
        public static string PSCexistedFile = @ConfigurationManager.AppSettings["PSCTrxExitedfilepath"];
        public static string MEWebFile = @ConfigurationManager.AppSettings["MEWebTrxfilepath"];
        public static string MEWebexistedFile = @ConfigurationManager.AppSettings["MEWebTrxExitedfilepath"];
        public static string MEWebAPIFile = @ConfigurationManager.AppSettings["MEWebAPITrxfilepath"];
        public static string MEWebAPIexistedFile = @ConfigurationManager.AppSettings["MEWebAPITrxExitedfilepath"];
        public static string Mailtemp = @ConfigurationManager.AppSettings["Mailtemplatefilepath"];
        public static string filepath = string.Empty;
        public static string appfolderpath = string.Empty;
        public static string MailSubject = string.Empty;
        public static string android = "Theranos.Automation.ME.Android";
        public static string psc = "Theranos.Automation.PSC3";
        public static string integrationprofile = "Integration.Project";
        public static string Mailtemplateproject = "Theranos.Mailtemplate";
        public static string MEWebProject = "Theranos.Automation.ME.Web";
        public static string MEAPI = "Theranos.Automation.ME.API";
        public static string EndP = @ConfigurationManager.AppSettings["EndPoint"];

        
        [TestMethod]
        public static string Getapplicationname()
        {
            var appname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string name = appname.ToString();
            return appname;
        }
        [TestMethod]
        public static void setappFilepath(string appreportfilepath)
        {
            //string filepath = assemblyname.Getapplicationname();
            //string filepath = Getapplicationname();

            //string android = "Theranos.Automation.ME.Android";
            //string psc = "Theranos.Automation.PSC3";
            //string integrationprofile = "Integration Project";
            //string Mailtemplateproject = "Theranos.Mailtemplate";
            //string MEWebProject = "Theranos.Automation.ME.Web";
            //string MEAPI = "Theranos.Automation.ME.API";

            if (android == appreportfilepath)
            {
                appfolderpath = MEAndroidFile;

            }
            else if (psc == appreportfilepath)
            {
                appfolderpath = PSCFile;

            }
            else if (integrationprofile == appreportfilepath)
            {
                appfolderpath = IntegrationFile;
            }
            else if (MEWebProject == appreportfilepath)
            {
                appfolderpath = MEWebFile;
            }
            else if (MEAPI == appreportfilepath)
            {
                appfolderpath = MEWebAPIFile;
            }
            else if (Mailtemplateproject == appreportfilepath)
            {
                appfolderpath = Mailtemp;
            }

        }


        [TestMethod]
        public static void setappSubject(string appreportfilepath)
        {
            //string filepath = assemblyname.Getapplicationname();
            //string filepath = Getapplicationname();

            string androidsubject = ".ME.Android";
            string pscsubject = "PSC3.0";
            string integrationsubject = "Integration Project";
            string Mailtemplatesubject = "Theranos.Mailtemplate";
            string MEWebsubject = ".MEWeb";
           // string MEAPIsubject = ".MEAPI";

            if (android == appreportfilepath)
            {
                MailSubject = androidsubject;

            }
            else if (psc == appreportfilepath)
            {
                MailSubject = pscsubject;

            }
            else if (integrationprofile == appreportfilepath)
            {
                MailSubject = integrationsubject;
            }
            else if (MEWebProject == appreportfilepath)
            {
                MailSubject = MEWebsubject;
            }
            else if (MEAPI == appreportfilepath)
            {
                //MailSubject = MEAPIsubject;
                switch (EndP)
                {
                    case ("http://alpha:1212/api/v5"):
                        MailSubject = ".MEAPI_Alpha";
                        break;
                    case ("http://externalme/meapi/v5"):
                        MailSubject = ".MEAPI_Beta";
                        break;
                    case ("https://labcheckinstg.theranos.com/meapi/v5"):
                        MailSubject = ".MEAPI_Staging";
                        break;
                    case ("https://labcheckin.theranos.com/meapi/v5"):
                        MailSubject = ".MEAPI_Production";
                        break;
                }
            }
            else if (Mailtemplateproject == appreportfilepath)
            {
                MailSubject = Mailtemplatesubject;
            }

        }

        [TestMethod]
        public void setapp_path()
        {
            setappFilepath(Getapplicationname());
        }

        public void subjectContent()
        {
            setappSubject(Getapplicationname());
         
        }

        }
}

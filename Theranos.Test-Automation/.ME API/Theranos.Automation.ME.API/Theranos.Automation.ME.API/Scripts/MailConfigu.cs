using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Mailtemplate.Report.Mail;
using Theranos.Mailtemplate.AppStack;

namespace Theranos.Automation.ME.API.Scripts
{
    [TestClass]
    public class MailConfigu
    {
        Mailtrigger MT = new Mailtrigger();
        public string chanduru = "chanduru.sampathkumar@gsr-inc.com";
        public string fangming = "flu@theranos.com";
        public string vimal = "vnair@theranos.com";
        public string Kanchan = "Kjindal@theranos.com";

        public static string GetapplicationnameAPI()
        {
            var appname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            return appname;
        }
        [TestMethod]
        public void APIapp()
        {
            Appassembly.setappFilepath(GetapplicationnameAPI());
        }

        public void subjectContent()
        {
            Appassembly.setappSubject(GetapplicationnameAPI());

        }
        [TestMethod]
        public void AutomationTestresult()
        {
            APIapp();
            subjectContent();
            MT.getfilename();
            MT.convertTRX_HTML();
            MT.sendingmail(chanduru, fangming, vimal, Kanchan);
        }
    }
}

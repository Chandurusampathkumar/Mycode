using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;

namespace Theranos.Automation.ME.Web.WebTestScripts.NeedHelp
{
    [TestClass]
    public class ResendActivationLink : WebActionLib
    {
        //TC- 36, 37 ,38, 39
        WebActionLib help = new WebActionLib();
        WorkingActivationLink activate = new WorkingActivationLink();
       
        /// <summary>
        /// TC-37
        /// </summary>
      
        public void resendactivaton(String username , String errormsglocator)
        {
                    
            help.ClearTextByxpath(Ele_ResetPassword_Usernamefield_xpath);
            help.sendTextByXpath(Ele_ResetPassword_Usernamefield_xpath, username);
            Thread.Sleep(3000);
            help.clickElementByXpath(Ele_ResetPassword_Submit_Xpath);
            help.waitForElement("xpath", errormsglocator, 50);
            String errormsg = help.getTextByXpath(errormsglocator);
            Console.WriteLine("Resend activation link"+errormsg);

        }
      
        /// <summary>
        /// TC- 36 and TC- 38
        /// </summary>
        [TestMethod]
        public void resendactivaton_Invalidusername_Scenario()
        {
           
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByLinkText(Ele_NeedHelp_ResendActivation_linktext);
            resendactivaton(TD_wrong_username, Ele_ResendActivationlink_notificationmsg_ForInvaliduser_xpath); 
            help.quitWebDriver();
        }

        /// <summary>
        /// TC- 39
        /// </summary>

        [TestMethod]
        public void resendactivaton_NonActivatedusername_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            activate.activationLink();
            help.quitWebDriver();
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByLinkText(Ele_NeedHelp_ResendActivation_linktext);
           
            resendactivaton(ReadExcel.NewUserName, Ele_ResendActivationlink_notificationmsg_Forvaliduser_xpath); 
            Thread.Sleep(2000);
            help.quitWebDriver();
        }

        /// <summary>
        /// Tc-50
        /// </summary>
        [TestMethod]
        public void resendactivaton_Activatedusername_Scenario()
        {

            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByLinkText(Ele_NeedHelp_ResendActivation_linktext);

            resendactivaton(ReadExcel.NewUserName, Ele_ResendActivationlink_notificationmsg_ForInvaliduser_xpath); //37
            help.quitWebDriver();
           
        }
    }
}

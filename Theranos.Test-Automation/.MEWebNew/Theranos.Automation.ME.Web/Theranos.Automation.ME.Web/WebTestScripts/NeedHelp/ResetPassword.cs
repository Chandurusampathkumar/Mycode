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
   public class ResetPassword :WebActionLib
    {
        //TC- 032
        WebActionLib help = new WebActionLib();
        WorkingActivationLink activate = new WorkingActivationLink();

        public String resetpasscommonfunction(String username , String msgXpath)
        {
           
            help.ClearTextByxpath(Ele_ResetPassword_Usernamefield_xpath);
            help.sendTextByXpath(Ele_ResetPassword_Usernamefield_xpath, username);
            Thread.Sleep(3000);
            help.clickElementByXpath(Ele_ResetPassword_Submit_Xpath);
            string value = help.getTextByXpath(msgXpath);
           
            return value;
        }
       
        [TestMethod]
        public void resetpassword_validusername_Scenario()
        {
            //TC-033 for valid username
            
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            string value = resetpasscommonfunction(ReadExcel.NewUserName, Ele_Resetpassword_notificationmsg_Forvaliduser_xpath);
           
            Console.WriteLine("Value of web is=" + value);
            help.quitWebDriver();
        }

        [TestMethod]
        public void resetpassword_invalidusername_Scenario()
        {
            //TC- 32
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            //TC-034 for invalid username
            string actualvalue = resetpasscommonfunction(TD_wrong_username, Ele_Resetpassword_notificationmsg_ForInvaliduser_xpath);

            string expected = "A profile with the entered username does not exist. Please try again.";
            Console.WriteLine("actualvalue=====" + actualvalue);
            ///  Assert.AreEqual(expected, actualvalue);
            help.quitWebDriver();
        }
        /// <summary>
        /// TC-035 for not activated username
        /// </summary>
        [TestMethod]
        public void resetpassword_nonactivatedusername_Scenario()
        {
            
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            activate.activationLink();
            help.quitWebDriver();
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            Thread.Sleep(2000);
            //string expected1 = "Your account has not yet been activated. We've sent you an email with a new activation link.";
            string actualvalue1 = resetpasscommonfunction(ReadExcel.NewUserName, Ele_Resetpassword_notificationmsg_ForInvaliduser_xpath);
          
            /// Assert.AreEqual(expected1, actualvalue1);
            help.quitWebDriver();
        }
    }
}
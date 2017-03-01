using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.SignIn;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class Signin_TestSuits : WebActionLib
    {
        WebActionLib ti = new WebActionLib();

        SignIn_With_Invalid_UserName signin = new SignIn_With_Invalid_UserName();
        Multiple_Login_Attempts_Warning_Message mlawm = new Multiple_Login_Attempts_Warning_Message();
        Multiple_LoginAttempts_Lockout_Message mlalm = new Multiple_LoginAttempts_Lockout_Message();
        Locked_Account la = new Locked_Account();
       

        [TestMethod]
        public void signintestsuits()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "new");

            signin.signInWithInvalidUsername_scenario();

            mlawm.multipleLoginAttemptsWarningMessage_Scenario();

            mlalm.MultipleLoginAttemptsLockedOutMessage_Scenario();

            la.lockedAccount_Scenario();

         
        }
    }
}

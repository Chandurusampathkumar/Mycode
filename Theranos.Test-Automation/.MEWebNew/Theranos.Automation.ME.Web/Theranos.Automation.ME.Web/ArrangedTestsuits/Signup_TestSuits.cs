using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;
using Theranos.Automation.ME.Web.ExcelReader;
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class Signup_TestSuits:WebActionLib
    {
        WorkingActivationLink wal = new WorkingActivationLink();
        ExistedUsername eu = new ExistedUsername();
        Multiple_Activations ma = new Multiple_Activations();
        SignUp.SignUp su = new SignUp.SignUp();
        LogInWithOutActivaton lwoal = new LogInWithOutActivaton();

        [TestMethod]
        public void signuptestsuits()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "new");

            su.signUp_Scenario();

            wal.activationLink_Scenario();

            ma.multipleActivations_Scenario();

            eu.existedUsername_Scenario();
         
            lwoal.loginWithoutActivations_scenario();
        }
    }
}

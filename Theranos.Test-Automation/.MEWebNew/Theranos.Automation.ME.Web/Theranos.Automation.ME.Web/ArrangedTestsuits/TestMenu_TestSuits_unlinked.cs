using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
   public class TestMenu_TestSuits_unlinked:WebActionLib
    {
       AccountLinking_Afteradding_Testtocart testcart = new AccountLinking_Afteradding_Testtocart();
       AccountLinking_Settings_TesteMenu_Addtocart_Resendcode resendcode = new AccountLinking_Settings_TesteMenu_Addtocart_Resendcode();
       Signup_OrderMenu_LinkAccount_InvalidVisitcode visitcode = new Signup_OrderMenu_LinkAccount_InvalidVisitcode();
       Signup_ResultMenu_LinkAccount resltmenu = new Signup_ResultMenu_LinkAccount();
   //    Signup_OrderMenu_LinkAccount_Clickhere clickhere = new Signup_OrderMenu_LinkAccount_Clickhere();
    //   TestMenu_Verify_ErrorStatement_ByWrongUser_credentials errorststement = new TestMenu_Verify_ErrorStatement_ByWrongUser_credentials();
      
       [TestMethod]
       public void testmenutestsuits_unlinked()
       {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
           signin_forUnlinked();
           testcart.account_linking_after_testtocart_Scenario();///un
           visitcode.signupOrderMenuLinkAccountinvalidvisitcode_Scenario();
           resltmenu.signupResultMenuLinkAccount_Scenario();  //unl                                                    


       }
        [TestMethod]
       public void signin_forUnlinked()
       {
           //// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");

           WebActionLib unlink = new WebActionLib();
           unlink.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
           unlink.maximizeWindow();
           Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
           unlink.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName);
           unlink.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
           unlink.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);

       }
    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
    
    [TestClass]
    public class AccountLinking_OrdersPage_ResendCode:WebActionLib
    {
        WebActionLib odr = new WebActionLib();

        public void accountLinkingOrdersPageResendCode()
        {
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            odr.clickElementByXpath(Ele_DashBoard_Order_Xpath);  // Click Test Menu
            Thread.Sleep(4000);
            Scenario_Functions.resendvisitcode();
            string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
            Scenario_Functions.entervisitcode(psicode);      
        }

        /// <summary>
        /// TC-046
        /// </summary>
        [TestMethod]
        public void accountLinking_DashboardEntervisitcode()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            odr.clickElementByLinkText(Ele_Dashboard_Entervisitcode_linktext);
            Thread.Sleep(4000);
            Scenario_Functions.entervisitcode(ReadExcel.numerics);
            string errormsg = odr.getText(Ele_Entervisitcode_errormsg_invaliddata_xpath);
            Console.WriteLine("Error Msg"+errormsg);
            string excpected =  "The visit code does not match your basic information. Make sure you used the right visit code or request a new one by selecting 'Resend code'";
            Assert.AreEqual(excpected, errormsg);
            odr.quitWebDriver();
        }

        /// <summary>
        /// TC-007
        /// </summary>
        [TestMethod]
        public void accountLinkingOrdersPageResendCode_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            accountLinkingOrdersPageResendCode();
            odr.quitWebDriver();
        }

        public void transcribedOrder()
        {
            odr.clickElementByXpath(Ele_DashBoard_Order_Xpath);
            Thread.Sleep(2000);
            odr.clickElementByXpath(Ele_Orderpage_ReadyOrderTesting_Xpath);
            odr.clickElementByXpath(Ele_Orderpage_transribe_testname_Xpath);
            var visible = Driver.FindElement(By.XPath(Ele_Orderpage_transribe_testcartBtn_Xpath));
            Assert.IsFalse(visible.Enabled);
        }

        /// <summary>
        /// TC-047
        /// </summary>
        [TestMethod]
        public void orderdetails_for_transcribed()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            transcribedOrder();
            odr.quitWebDriver();
        }
    }
}

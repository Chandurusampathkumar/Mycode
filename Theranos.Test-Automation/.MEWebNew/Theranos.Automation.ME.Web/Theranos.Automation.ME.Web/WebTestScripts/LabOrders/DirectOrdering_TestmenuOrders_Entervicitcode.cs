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
namespace Theranos.Automation.ME.Web.WebTestScripts.LabOrders
{
    [TestClass]
    public class DirectOrdering_TestmenuOrders_Entervicitcode : WebActionLib
    {
        // Testcase for Tc-016
        WebActionLib unlink = new WebActionLib();
        
        public void directOrderingTestmenuOrdersByLinkAccount()
        {
            Thread.Sleep(4000);
            unlink.waitForElement("linktext", Ele_DashBoard_Test_linktext, 30);
         
            Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);
            Scenario_Functions.resendvisitcode();
            string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
          
            Scenario_Functions.entervisitcode(psicode);
         
           // link.clickElementByXpath(Ele_DashBoard_Order_Xpath);
            //String previouscount = link.getTextByXpath(Element_Ordernumbers_Count_Xpath);
           // Console.WriteLine(previouscount);
            Scenario_Functions.creatingorder();
            // link.clickElementByXpath(Ele_DashBoard_Order_Xpath);
            //String aftercount = link.getTextByXpath(Element_Ordernumbers_Count_Xpath);
           // Console.WriteLine(aftercount);
            }
        [TestMethod]
        public void directOrderingTestmenuOrdersByLinkAccount_Scenario()
        {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
           Scenario_Functions.signin_forUnlinked();
           Thread.Sleep(3000);
           directOrderingTestmenuOrdersByLinkAccount();
           unlink.quitWebDriver();
        }
    }
}

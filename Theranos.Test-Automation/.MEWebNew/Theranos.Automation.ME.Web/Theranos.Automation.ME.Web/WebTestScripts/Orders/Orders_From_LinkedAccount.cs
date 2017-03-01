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

namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
                        // TC-043
    [TestClass]
    public class Orders_From_LinkedAccount:WebActionLib
    {
        WebActionLib won = new WebActionLib();
    
        public void ordersFromLinkedAccount()
        {
           
           // won.WaitForElementByXpathToLoad(Ele_DashBoard_TestMenu_Xpath, 40);
            won.clickElementByLinkText(Ele_DashBoard_Test_linktext);  // Click Test Menu
           // won.WaitForElementByXpathTo_Clickable(Ele_DashBoard_Test_xpath, 30);
            //  won.clickElementByXpath(Ele_TestMenu_TestSearchIcon_Xpath);
            Driver.Navigate().Refresh();
          //  Thread.Sleep(5000);
           /// waitForElement("xpath", Ele_TestMenu_SearchIcon_xpath, 50);
           //  won.clickElementByXpath(Ele_TestMenu_SearchIcon_xpath);
            //won.sendTextById(Ele_TestMenu_TestSearchField_Id, TD_Testname1);    // submit Testname in search box
            Thread.Sleep(3000);
             won.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            won.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            won.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, TD_Testname1);
            Thread.Sleep(3000);
          //  waitForElement("xpath", Ele_TestMenu_SearchResult_Xpath, 50);
            won.clickElementByXpath(Ele_TestMenu_SearchResult_Xpath);    // Click on search result
            Thread.Sleep(5000);
            //waitForElement("xpath", Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
            won.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);   
                                                                                   // Click on add to cart
            Scenario_Functions.creatingorder();           
        }

        [TestMethod]
        public void ordersFromLinkedAccount_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            ordersFromLinkedAccount();
            won.quitWebDriver();
        }

    }
}

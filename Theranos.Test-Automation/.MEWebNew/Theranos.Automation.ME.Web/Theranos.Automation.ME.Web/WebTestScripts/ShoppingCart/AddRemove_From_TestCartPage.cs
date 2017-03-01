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
using OpenQA.Selenium.Interactions;
using Theranos.Automation.ME.Web.ExcelReader;


namespace Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart
{
    [TestClass]
    public class AddRemove_From_TestCartPage : WebActionLib
    {
        //TC-060
        WebActionLib addAndremove = new WebActionLib();

        public void AddandRemovetest()
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            String cartstatuslabel = Scenario_Functions.shoppingcartverification();
            // String Actualcartstatus = "There are no items in your shopping cart. You can add tests and panels from the test menu.";
            //Console.WriteLine(Actualcartstatus);
            //  Assert.Equals(cartstatuslabel, Actualcartstatus);
            Thread.Sleep(3000);
           // waitForElement("xpath", Ele_Myorders_TestmenuLink_xpath, 50);
            //   addAndremove.waitForElementByNameToLoad(Ele_Myorders_TestmenuLink_xpath, 100);
            addAndremove.clickElementByXpath(Ele_Myorders_TestmenuLink_xpath);

            List<String> testnames = new List<string>();
            testnames.Add(TD_Testname1);
            //  testnames.Add(TD_Testname2);
            //testnames.Add("Alanine Aminotransferase (ALT/SGPT)");

            for (int i = 0; i < testnames.Count; i++)
            {
                //Thread.Sleep(3000);
                waitForElement("classname", Ele_TestMenu_SearchIcon_Classname, 50);
                // addAndremove.waitForElementByNameToLoad(Ele_TestMenu_SearchIcon_Classname, 50);
                addAndremove.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
                addAndremove.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, testnames[i]);
                addAndremove.clickElementByXpath(Ele_TestMenu_Suggested_Testtype_Xpath);
                ///Thread.Sleep(3000);
                waitForElement("xpath", Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
                //  addAndremove.waitForElementByNameToLoad(Ele_Testmenu_SelectedTest_Xpath, 50);
                addAndremove.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);
                addAndremove.clickElementByLinkText(Ele_DashBoard_Test_linktext);
                ///addAndremove.clickElementByXpath(Ele_DashBoard_TestMenu_Xpath);
                waitForElement("xpath", Ele_DashBoard_Myorders_Xpath, 50);
                //Thread.Sleep(4000);
                addAndremove.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);
                Thread.Sleep(4000);
                Driver.Navigate().Refresh();
                addAndremove.mousehoverById("icon-close");
               
                addAndremove.clickElementByClassName("remove-test-icon");
                Thread.Sleep(2000);
            }

            addAndremove.clickElementByXpath(Ele_Myorders_TestmenuLink_xpath);

        }
        [TestMethod]
        public void AddandRemovetest_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            AddandRemovetest();
            addAndremove.quitWebDriver();
        }

    }
}

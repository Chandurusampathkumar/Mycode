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


namespace Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart
{
    [TestClass]
    public class AddingTest_ToCart_TotalTest : WebActionLib
    {
        // TC- 056
        WebActionLib addingtest = new WebActionLib();
       
        public void countingCartTest()
        {
            List<String> addedtestnames = new List<string>();
            List<String> addedtestprice = new List<string>();

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            //TC-055
            String cartstatuslabel = Scenario_Functions.shoppingcartverification();
            // String Actualcartstatus = "There are no items in your shopping cart. You can add tests and panels from the test menu.";
            //Console.WriteLine(Actualcartstatus);
            //  Assert.Equals(cartstatuslabel, Actualcartstatus);
            //            addingtest.waitForElementByNameToVisible(Ele_Myorders_TestmenuLink_xpath, 50);
            Thread.Sleep(2000);
            addingtest.clickElementByXpath(Ele_Myorders_TestmenuLink_xpath);

            List<String> testnames = new List<string>();
            testnames.Add(TD_Testname1);
         //   testnames.Add("Adenovirus DNA, Quantitative");
            //testnames.Add("Alanine Aminotransferase (ALT/SGPT)");

            for (int i = 0; i < testnames.Count; i++)
            {
                waitForElement("classname", Ele_TestMenu_SearchIcon_Classname, 50);
                ///Thread.Sleep(2000);
                //  addingtest.waitForElementByNameToVisible(Ele_TestMenu_SearchIcon_Classname, 50);
                addingtest.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
                addingtest.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, testnames[i]);
                addingtest.clickElementByXpath(Ele_TestMenu_Suggested_Testtype_Xpath);
                //Thread.Sleep(3000);
                waitForElement("xpath", Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
                ///                addingtest.waitForElementByNameToVisible(Ele_Testmenu_SelectedTest_Xpath, 50);
                addingtest.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);
                addingtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            }
            addingtest.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);
            ///////     addingtest.clickElementByXpath(Ele_DashBoard_ShoppingCart_Xpath);
        
            for (int i = 1; i < (testnames.Count + 1); i++)
            {
                Thread.Sleep(3000);
                String name1 = addingtest.getTextByXpath("html/body/div[4]/ui-view[3]/section[2]/div["+i+"]/div[1]");
                ///here displyaing the price of test it covers Tc-058
                Driver.Navigate().Refresh();
                String name = addingtest.getTextByXpath("html/body/div[4]/ui-view[3]/section[2]/div["+i+"]/div[2]");
                Driver.Navigate().Refresh();
                addedtestnames.Add(name1);
                addedtestprice.Add(name);
            }
            addedtestnames.ForEach(Console.WriteLine);
            addedtestprice.ForEach(Console.WriteLine);
            //here creating orders from cart it covers Tc-057 and TC-059
            Scenario_Functions.creatingorder();
        }

        [TestMethod]
        public void countingCartTest_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            countingCartTest();
            addingtest.quitWebDriver();
        }


        /// <summary>
        /// 78
        /// </summary>
        [TestMethod]
        public void cartverification_twoaccount()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Scenario_Functions.addtesttocart_Bytestmenu_linked(TD_Testname1);
            addingtest.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);

            addingtest.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
            addingtest.clickElementByLinkText(Ele_Dashboard_Logout_linktext);
            addingtest.quitWebDriver();

            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Thread.Sleep(5000);
            addingtest.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);

            addingtest.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
            addingtest.clickElementByLinkText(Ele_Dashboard_Logout_linktext);
            addingtest.quitWebDriver();


        }

        
    }
}

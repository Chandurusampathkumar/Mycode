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

namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenuAll
{
    [TestClass]
    public class SearchSingleTest_DisplayTest : WebActionLib
    {
        //This covers Tc-064 ,  Tc-065
        WebActionLib searchtest = new WebActionLib();


        public void searchandisplayTest(String testtype)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //  searchtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            //  Thread.Sleep(4000);
            //   waitForElement("classname", Ele_TestMenu_SearchIcon_Classname, 50);
            searchtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            Driver.Navigate().Refresh();
            searchtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            Thread.Sleep(3000);
            searchtest.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            searchtest.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, testtype);
            String suggestedtest = searchtest.getTextByXpath(Ele_TestMenu_SearchResult_wholetest_xpath);

            Console.WriteLine("Test type" + suggestedtest);
            ////This covers Tc-066
            searchtest.clickElementByXpath(Ele_TestMenu_Suggested_Testtype_Xpath);
            String testname = searchtest.getTextByXpath("html/body/div[4]/ui-view[3]/div[1]/div/div[3]/div/div/div[1]/div");

            Console.WriteLine("Details of test" + testname);
            String testprice = searchtest.getTextByXpath(Ele_Testdisplayed_Price_xpath);
            Console.WriteLine("Test Price==" + testprice);
          }
      
        //TC-69
        [TestMethod]
        public void switchbetweenthreetabs()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            searchandisplayTest(TestBY_name);

            waitForElement("xpath", Ele_TestMenu_Overview_Xpath, 50);
            searchtest.clickElementByXpath(Ele_TestMenu_Overview_Xpath);
            String buttonattribute = Driver.FindElement(By.XPath(Ele_TestMenu_Overview_Xpath)).GetAttribute("class");
            Console.WriteLine("buttonattribute===" + buttonattribute);
            searchtest.clickElementByXpath(Ele_TestMenu_TheTest_Xpath);
            String buttonattribute2 = Driver.FindElement(By.XPath(Ele_TestMenu_TheTest_Xpath)).GetAttribute("class");
            Console.WriteLine("buttonattribute2===" + buttonattribute2);
            searchtest.clickElementByXpath(Ele_TestMenu_CommonQuestion_Xpath);
            String buttonattribute3 = Driver.FindElement(By.XPath(Ele_TestMenu_CommonQuestion_Xpath)).GetAttribute("class");
            Console.WriteLine("buttonattribute3====" + buttonattribute3);
            searchtest.quitWebDriver();
        }
        //TC-66
        [TestMethod]
        public void searchtestby_Marketcode()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            searchandisplayTest(TestBY_marketcode);
            searchtest.quitWebDriver();
        }


        //TC-67
        [TestMethod]
        public void searchtestby_CPTcode()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            searchandisplayTest(TestBY_cptcode);
            searchtest.quitWebDriver();
        }

        //TC-68
        [TestMethod]
        public void searchtestby_name()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            searchandisplayTest(TestBY_name);
            searchtest.quitWebDriver();
        }

        //TC-65
         [TestMethod]
        public void searchtestbyname_list()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
             
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
          
            searchtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            Driver.Navigate().Refresh();
            searchtest.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            Thread.Sleep(3000);
            searchtest.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            searchtest.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, "urine");

            String list = searchtest.getTextByXpath("html/body/div[4]/ui-view[3]/section[1]/div[2]/div/div");
            Console.WriteLine("Test list" + list);
            searchtest.quitWebDriver();
        }


         /// <summary>
         /// TC-70
         /// </summary>
         [TestMethod]
         public void Verify_addedtests()
         {
             ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
             Scenario_Functions.signInWithVerification();

             List<String> testnames = new List<string>();
             testnames.Add(TD_Testname1);
             testnames.Add(TD_Testname2);
             for (int i = 0; i < testnames.Count; i++)
             {
                 searchandisplayTest(testnames[i]);

                 waitForElement("xpath", Ele_TestMenu_Overview_Xpath, 50);
                 //  searchtest.clickElementByXpath(Ele_TestMenu_Overview_Xpath);
                 String buttonattribute = Driver.FindElement(By.XPath(Ele_TestMenu_Overview_Xpath)).GetAttribute("class");
                 Assert.AreEqual("active", buttonattribute);
               //  Console.WriteLine("buttonattribute===" + buttonattribute);

                 searchtest.waitForElement("xpath", Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
                 searchtest.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);

             }
                     
             searchtest.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);

             for (int i = 1; i < (testnames.Count + 1); i++)
             {
                 Thread.Sleep(3000);
                 String name1 = searchtest.getTextByXpath("html/body/div[4]/ui-view[3]/section[2]/div[" + i + "]/div[1]");
              
                 Assert.AreEqual(testnames[i-1], name1);
                 Driver.Navigate().Refresh();
             }

             searchtest.quitWebDriver();
         }

    }
}
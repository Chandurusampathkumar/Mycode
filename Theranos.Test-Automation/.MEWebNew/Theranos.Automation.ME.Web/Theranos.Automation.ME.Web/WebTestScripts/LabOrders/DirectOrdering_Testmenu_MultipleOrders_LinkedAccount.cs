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
using OpenQA.Selenium.Support.UI;


namespace Theranos.Automation.ME.Web.WebTestScripts.LabOrders
{
    [TestClass]
    public class DirectOrdering_Testmenu_MultipleOrders_LinkedAccount : WebActionLib
    {
       
        WebActionLib link = new WebActionLib();

        public void directOrderingTestmenuMultpleOrdersLinkedAccount()
        {
            List<String> testnames = new List<string>();
            testnames.Add(TD_Testname1);
            //testnames.Add(TD_Testname2);
            // testnames.Add(TD_Testname4);
            // reapeate  for three times
            for (int i = 0; i < testnames.Count; i++)
            {
                Scenario_Functions.addtesttocart_Bytestmenu_linked(testnames[i]);
                Scenario_Functions.creatingorder();
            }

        }
        /// <summary>
        /// Testcase for Tc-018
        /// </summary>
        [TestMethod]
        public void directOrderingTestmenuMultpleOrdersLinkedAccount_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            directOrderingTestmenuMultpleOrdersLinkedAccount();
            link.quitWebDriver();
        }

        /// <summary>
        /// TC-79
        /// </summary>
        [TestMethod]
        public void createorder_check_CA()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();

            List<String> testnames = new List<string>();
            testnames.Add(TD_Testname1);
            //testnames.Add(TD_Testname2);
            // testnames.Add(TD_Testname4);
            // reapeate  for three times
            for (int i = 0; i< testnames.Count; i++)
            {
                Scenario_Functions.addtesttocart_Bytestmenu_linked(testnames[i]);
                creatingorder();
            }
            link.quitWebDriver();
        }

        public static void creatingorder()
        {
            WebActionLib link = new WebActionLib();
            Thread.Sleep(5000);
            link.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);
            Thread.Sleep(3000);
            link.clickElementByClassName(Ele_ShoppingCart_CreateOrder_Classname);  // Click on create order
         
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

            var listvalue = Driver.FindElement(By.XPath(Ele_CreatingAnOrder_State_Xpath));

            var AllDropDownList = listvalue.FindElements(By.XPath("//option"));
            
            var sel = new SelectElement(listvalue);
            int one = AllDropDownList.Count;
            Console.WriteLine("one====" + one);

            Boolean value = false;

            for (int i = 0; i < one; i++)
            {
                Console.WriteLine("AllDropDownList[i].Text---------" + AllDropDownList[i].Text);

                sel.SelectByIndex(i);

                if (AllDropDownList[i].Text == "Select state")
                {
                    value = true;
                }
                else if (AllDropDownList[i].Text == "AZ")
                {
                    value = true;
                }
                else if (AllDropDownList[i].Text == "CA")
                {
                    value = true;
                    Assert.IsFalse(value);
                }
            }

            link.clickElementByXpath(Ele_CreatingAnOrder_Next_Xpath);            
            link.clickElementByXpath(Ele_CreatingAnOrder_CreateOrder_Xpath);  
            Thread.Sleep(5000);
        }

    }
}

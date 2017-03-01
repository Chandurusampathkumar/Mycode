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
    public class TestMenu_Scroll_AllTestTypes : WebActionLib
    {
        //TC=064
        WebActionLib addAndremove = new WebActionLib();
      
        public void scrolltestetype()
        {   
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            addAndremove.clickElementByLinkText(Ele_DashBoard_Test_linktext);

            //By.LinkText("Theranos.com")            
            IWebElement ele1 = Driver.FindElement(By.XPath("html/body/div[4]/ui-view[3]/section[3]/div/div[2]/div[1]/div"));
            IList<IWebElement> ele = ele1.FindElements(By.ClassName("row"));
            Console.WriteLine(ele.Count);
            for(int i=0; i <ele.Count; i++){
                String print = ele[i].Text;
                Console.WriteLine(print);
            }
            Thread.Sleep(5000);
            IWebElement element = Driver.FindElement(By.ClassName("row"));
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 1500)");
       }
        [TestMethod]
        public void scrolltestetype_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            scrolltestetype();
            addAndremove.quitWebDriver();
        }
    }
}

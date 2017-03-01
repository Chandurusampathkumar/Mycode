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
using OpenQA.Selenium.Support.UI;


namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
    [TestClass]
    public class Order_From_UnlinkedaAccount : WebActionLib
    {
         

        WebActionLib order = new WebActionLib();

        public void orderFromUnlinkedAccount()
        {
           // Thread.Sleep(3000);
            WebActionLib unlink = new WebActionLib();
          
            unlink.clickElementByLinkText(Ele_DashBoard_Test_linktext);
      
            unlink.WaitForElementByXpathTo_Clickable(Ele_Testmenu_EntertestinSearchbox_Xpath, 60);
     
            unlink.clickElementByXpath(Ele_Testmenu_EntertestinSearchbox_Xpath);
            unlink.sendTextById(Ele_TestMenu_TestSearchField_Id, TD_Testname1);
            unlink.WaitForElementByXpathTo_Clickable(Ele_TestMenu_SearchResult_Xpath, 30); // submit text in search box
            unlink.clickElementByXpath(Ele_TestMenu_SearchResult_Xpath);    // Click on search result

            unlink.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);
            Thread.Sleep(3000);
            order.clickElementByXpath(Ele_CreateProfile_NoButton_Xpath);

            Thread.Sleep(5000);
            order.sendTextByName(Ele_CreateProfile_FirstName_Name, ReadExcel.FirstName+"A");
            order.sendTextByName(Ele_CreateProfile_LastName_Name, ReadExcel.LastName+"A");

            string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
            string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
            string value3 = ReadExcel.Dateofbirth.Substring(4, 4);

            //IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            //js.ExecuteScript("document.getElementByName('month')");

            ////Then Select required value
            //SelectElement dropdown = new SelectElement(Driver.FindElement(By.Name("month")));
            //dropdown.SelectByIndex(8);


            //js.ExecuteScript("document.getElementByName('day')");

            ////Then Select required value
            //SelectElement dropdown1 = new SelectElement(Driver.FindElement(By.Name("day")));
            //dropdown1.SelectByIndex(30);

            order.selectListByIndex(Ele_ProvisionalAcc_createProfile_month_xpath, Int32.Parse(value1));
            order.selectListByIndex(Ele_ProvisionalAcc_createProfile_day_xpath, Int32.Parse(value2));
            order.selectListBytext(Ele_ProvisionalAcc_createProfile_year_xpath, value3);

            if (ReadExcel.Gender.ToLower().Equals("male"))
            {
                order.clickElementByXpath(".//*[@id='male']/label");
            }else{
                order.clickElementByXpath(".//*[@id='female']/label");
            }
            order.sendTextByName("mobile", "8989898989");
            order.sendTextByName("address1", "Bahwan IT Park, 2nd Floor, East Wing,148, Rajiv Gandhi Salai ");
            order.sendTextByName("address2", "(OMR), Okkiyam Thoraipakkam, Chennai, Tamil Nadu 600097");
            order.sendTextByName("city", "arizona");
            order.selectListBytext(Ele_CreatingAnOrder_State_Xpath, "AZ");
            order.sendTextByName("zip", "85001");
            order.clickElementByLinkText("Submit");

            order.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);      // open shopping cart
            order.clickElementByClassName(Ele_ShoppingCart_CreateOrder_Classname);  // Click on create order
            order.selectListBytext(Ele_CreatingAnOrder_State_Xpath, "AZ");    // Select state from dropdown
            order.clickElementByXpath(Ele_CreatingAnOrder_Next_Xpath);      //  Click on Next
            order.clickElementByXpath(Ele_CreatingAnOrder_CreateOrder_Xpath);  // Click Create Order
        }

        /// <summary>
        /// TC-042
        /// </summary>
        [TestMethod]
        public void orderFromUnlinkedAccount_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            orderFromUnlinkedAccount();
            order.quitWebDriver();
        }
    }
}

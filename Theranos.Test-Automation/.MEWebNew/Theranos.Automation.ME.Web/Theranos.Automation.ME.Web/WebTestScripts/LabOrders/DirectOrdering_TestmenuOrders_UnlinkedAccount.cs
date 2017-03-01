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
    public class DirectOrdering_TestmenuOrders_UnlinkedAccount : WebActionLib
    {
        // Testcase for Tc-015
        WebActionLib won = new WebActionLib();

        public void directordering_testmenuorders()
        {

          //  string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
            Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);
            /*
             * numerics data is used fod invalid visit code. 
             * */
            entervisitcode_errormsg(ReadExcel.numerics);
            String errormsg = won.getTextByXpath(Element_SignIn_unlinkAccount_Errormessage_Xpath);
            Console.WriteLine("Expected ==" + errormsg);
        }

        public static void entervisitcode_errormsg(String Visicode)
        {
            WebActionLib unlink = new WebActionLib();
            unlink.sendTextByXpath(Ele_Order_LinkAcount_Entervisitcode_xpath, Visicode);
            unlink.sendTextByName(Ele_Order_LinkAcount_EnterFirstName_Name, TD_wrong_pscfirstname);
            unlink.sendTextByName(Ele_Order_LinkAcount_EnterLastName_Name, TD_wrong_pscfirstname);
          
            string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
            string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
            string value3 = ReadExcel.Dateofbirth.Substring(4, 4);


            unlink.selectListByIndex(Ele_resendvisitcode_monthdropdown_xpath, Int32.Parse(value1));
            unlink.selectListByIndex(Ele_resendvisitcode_Daydropdown_xpath, Int32.Parse(value2));
            unlink.selectListBytext(Ele_resendvisitcode_Yeardropdown_xpath, value3);
            unlink.clickElementByXpath(Ele_Order_LinkAcount_Submitbutton_xpath);

        }
        [TestMethod]
        public void directordering_testmenuorders_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2 , false, "Old");
            Scenario_Functions.signin_forUnlinked();
            directordering_testmenuorders();
            won.quitWebDriver();
        }
    }
}

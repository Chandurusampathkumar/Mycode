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

using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.ExcelReader;


namespace Theranos.Automation.ME.Web.WebTestScripts.ResendVisitcode
{
      [TestClass]
    public class ResendVisitCode : WebActionLib
    {
          ////TC- 52, 53
        WebActionLib link = new WebActionLib();

        [TestMethod]
       public void resendvisitcode_firstname()
       {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
           Scenario_Functions.signin_forUnlinked();
           Thread.Sleep(5000);
           Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);
           List<String> wronguser = new List<string>();
           wronguser.Add(ReadExcel.specialchar);
           wronguser.Add(ReadExcel.numerics);
           wronguser.Add(ReadExcel.morethanfifty);

           WebActionLib unlink = new WebActionLib();
           unlink.clickElementByLinkText(Ele_LinkAccount_ClickHere_LinkText); // click on resend visit code


           string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
           string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
           string value3 = ReadExcel.Dateofbirth.Substring(4, 4);


           unlink.selectListByIndex(Ele_resendvisitcode_monthdropdown_xpath, Int32.Parse(value1));
           unlink.selectListByIndex(Ele_resendvisitcode_Daydropdown_xpath, Int32.Parse(value2));
           unlink.selectListBytext(Ele_resendvisitcode_Yeardropdown_xpath, value3);

           unlink.sendTextByName(Ele_CreateProfile_LastName_Name, ReadExcel.LastName);
           for (int i = 0; i < wronguser.Count; i++)
           {
             
               unlink.sendTextByName(Ele_CreateProfile_FirstName_Name, wronguser[i]);
              
               Thread.Sleep(2000);
               unlink.waitForElement("xpath", Ele_Order_LinkAcount_Submitbutton_xpath, 50);
               unlink.clickElementByXpath(Ele_Order_LinkAcount_Submitbutton_xpath);  
               
               //String firstnameerrormsg = unlink.getTextByXpath("html/body/div/div/div/section/form/div/div[1]/md-input-container/div/div");
               //Console.WriteLine("ErrorMessage====" + firstnameerrormsg);
               //String lastnameerrormsg = unlink.getTextByXpath("html/body/div/div/div/section/form/div/div[2]/md-input-container/div/div");
               //Console.WriteLine("ErrorMessage====" + lastnameerrormsg);

               unlink.ClearTextByName(Ele_CreateProfile_FirstName_Name);
              // unlink.ClearTextByName(Ele_CreateProfile_LastName_Name);
             
           }
           unlink.quitWebDriver();
       }

          [TestMethod]
       public void resendvisitcode_lastname()
       {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
           Scenario_Functions.signin_forUnlinked();
           Thread.Sleep(5000);
           Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);

           List<String> wronguser = new List<string>();
           wronguser.Add(ReadExcel.specialchar);
           wronguser.Add(ReadExcel.numerics);
           wronguser.Add(ReadExcel.morethanfifty);

           WebActionLib unlink = new WebActionLib();
           unlink.clickElementByLinkText(Ele_LinkAccount_ClickHere_LinkText); // click on resend visit code

           string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
           string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
           string value3 = ReadExcel.Dateofbirth.Substring(4, 4);


           unlink.selectListByIndex(Ele_resendvisitcode_monthdropdown_xpath, Int32.Parse(value1));
           unlink.selectListByIndex(Ele_resendvisitcode_Daydropdown_xpath, Int32.Parse(value2));
           unlink.selectListBytext(Ele_resendvisitcode_Yeardropdown_xpath, value3);

           unlink.sendTextByName(Ele_CreateProfile_FirstName_Name, ReadExcel.FirstName);
           for (int i = 0; i < wronguser.Count; i++)
           {
             
               unlink.sendTextByName(Ele_CreateProfile_LastName_Name, wronguser[i]);
       
               Thread.Sleep(2000);
               unlink.waitForElement("xpath", Ele_Order_LinkAcount_Submitbutton_xpath, 50);
               unlink.clickElementByXpath(Ele_Order_LinkAcount_Submitbutton_xpath);

               //String firstnameerrormsg = unlink.getTextByXpath("html/body/div/div/div/section/form/div/div[1]/md-input-container/div/div");
               //Console.WriteLine("ErrorMessage====" + firstnameerrormsg);
               //String lastnameerrormsg = unlink.getTextByXpath("html/body/div/div/div/section/form/div/div[2]/md-input-container/div/div");
               //Console.WriteLine("ErrorMessage====" + lastnameerrormsg);

               unlink.ClearTextByName(Ele_CreateProfile_LastName_Name);
            
           }
           unlink.quitWebDriver();
       }
          /// <summary>
          /// Tc-50
          /// </summary>
          [TestMethod]
          public void resendvisicode_Pagevisible()
          {
              Scenario_Functions.signin_forUnlinked();
              link.clickElementByLinkText(Ele_Dashboard_Entervisitcode_linktext);

              String val = link.getTextByXpath(Ele_Resendvisitpage_Lable_xpath);
              Assert.AreEqual("Resend Visit Code", val);

              Scenario_Functions.resendvisitcode();
              link.quitWebDriver();
          }
    }
}

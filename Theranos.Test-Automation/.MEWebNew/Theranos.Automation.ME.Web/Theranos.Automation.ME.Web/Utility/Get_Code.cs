using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using OpenQA.Selenium.Interactions;

namespace Theranos.Automation.ME.Web.Utility
{
    public class Get_Code : WebActionLib
    {
        //public static string getVerificationmailnet(string Email_to_Verify, string url_Of_Mail)
        //{

        //        WebActionLib co = new WebActionLib();
        //        string VerifiCode;
        //        co.switchToNewTab();
        //        co.passUrlToAddressBar(url_Of_Mail);
        //        Thread.Sleep(1100);

        //        co.ClearTextByid("https://www.mailinator.com/");
        //        co.sendTextByXpath(".//*[@id='inboxfield']", Email_to_Verify); // Submit email Id
        //        co.clickElementByXpath("html/body/section[1]/div/div[3]/div[2]/div[2]/div[1]/span/button");
        //        co.sendTextByXpath(".//*[@id='publicinboxfield']", Email_to_Verify); // Submit email Id
        //        co.clickElementByXpath(".//*[@id='publicInboxCtrl']/div[1]/div[3]/div/div/button");
        //   }


        public static string getVerificationCode(string Email_to_Verify, string url_Of_Mail)
        {

            try
            {
                WebActionLib co = new WebActionLib();
                string VerifiCode;
                co.switchToNewTab();
                co.passUrlToAddressBar(url_Of_Mail);
                Thread.Sleep(1100);
              
                co.WaitForElementByIdTo_Clickable(Ele_Yop_MailField_Id, 30);
                co.ClearTextByid(Ele_Yop_MailField_Id);
                co.sendTextById(Ele_Yop_MailField_Id, Email_to_Verify); // Submit email Id
                Thread.Sleep(1050);
                co.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
              
                co.WaitForElementByIdTo_Clickable(Ele_Yop_MailBodyFreame_Id, 30);
                co.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));
                VerifiCode = co.getTextByXpath(Ele_Yop_ActivationCode_Xpath);  // Returns activation Code
                
                co.closeCurrentTab();  // close mail and focus switched to two step authentication page
                return VerifiCode;
            }
            catch (Exception e)
            {
                Console.WriteLine("captcha " + e);
                WebActionLib co = new WebActionLib();
                string VerifiCode;
                co.switchToNewTab();
                co.passUrlToAddressBar(url_Of_Mail);
                co.WaitForElementByIdTo_Clickable(Ele_Yop_MailField_Id, 30);
                co.ClearTextByid(Ele_Yop_MailField_Id);
                co.sendTextById(Ele_Yop_MailField_Id, Email_to_Verify); // Submit email Id

                co.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
                co.clickElementByClassName("recaptcha-checkbox-checkmark");
                co.WaitForElementByIdTo_Clickable(Ele_Yop_MailBodyFreame_Id, 30);
                co.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));
                VerifiCode = co.getTextByXpath(Ele_Yop_ActivationCode_Xpath);  // Returns activation Code
                Thread.Sleep(1000);
                co.closeCurrentTab();
                return VerifiCode;
            }

        }

        public static string getPSIcode(string url_Of_Mail, string Email_to_Verify)
        {
            WebActionLib co = new WebActionLib();
            string PSIcode;
            co.switchToNewTab();
            co.passUrlToAddressBar(url_Of_Mail);
            co.waitForElement("id",Ele_Yop_MailField_Id, 30);
            co.ClearTextByid(Ele_Yop_MailField_Id);
            co.sendTextById(Ele_Yop_MailField_Id, Email_to_Verify); // Submit email Id
            co.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
            co.WaitForElementByIdTo_Clickable(Ele_Yop_MailBodyFreame_Id, 30);
            co.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));
            PSIcode = co.getTextByXpath(Ele_YopMailbody_PSIcode_Xpath);  // Returns PSI Code
            Thread.Sleep(1000);
            co.closeCurrentTab();  // close mail and focus switched to two step authentication page
            return PSIcode;

        }

        public static void YopMailRestPasswordLink(string Email_to_Verify, string url_Of_Mail)
        {

            WebActionLib resetlink = new WebActionLib();
            resetlink.switchToNewTab();
            resetlink.passUrlToAddressBar(url_Of_Mail);
            resetlink.WaitForElementByIdTo_Clickable(Ele_Yop_MailField_Id, 30);
            resetlink.sendTextById(Ele_Yop_MailField_Id, Email_to_Verify); // Submit email Id
            resetlink.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
            resetlink.WaitForElementByIdTo_Clickable(Ele_Yop_MailBodyFreame_Id, 30);
            resetlink.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));
            resetlink.clickElementByXpath(Ele_Yopmail_ResetPasswordLink_xpath);

        }
        public void YopMailsendemailcaptcha(string url_Of_Mail, string Email_to_Verify )
        {
                   
                WebActionLib Wl = new WebActionLib();
                Wl.switchToNewTab();
                Wl.passUrlToAddressBar(url_Of_Mail);
                Thread.Sleep(5000);
                Wl.sendTextById(Ele_Yop_MailField_Id, Email_to_Verify); // Submit email Id
                Wl.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
                Thread.Sleep(4000);
                Wl.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));

                Wl.controlClickByXpath(Ele_Yop_ClickActivate_Xpath);
          }
    }
}

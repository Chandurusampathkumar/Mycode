using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.ExcelReader;
using System.Text.RegularExpressions;

namespace Theranos.Automation.ME.Web.Web
{
    public class Scenario_Functions : WebActionLib
    {

        public static void signInWithVerification()
        {
            /// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            WebActionLib sg = new WebActionLib();
            sg.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            sg.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            sg.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName); ///ReadExcel.NewUserName
            sg.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            sg.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);

            string verificationcode = Get_Code.getVerificationCode(ReadExcel.Email, TD_yopmail_Page_Url);
            System.Diagnostics.Debug.WriteLine(verificationcode);
            sg.sendTextByXpath(Ele_SignIn_TwoStepAuthField_Xpath, verificationcode);  // Pass activation code to the field

            sg.clickElementByXpath(Ele_SignIn_TwoStepAuth_Done_Xpath);    // Click on done
            Thread.Sleep(10000);
        }

        public static void signin_forLinkedaccount()
        {
            //// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            WebActionLib unlink = new WebActionLib();
            unlink.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            unlink.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            unlink.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName);
            unlink.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            Thread.Sleep(2000);
            unlink.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
            Thread.Sleep(10000);
        }

        public static void signin_forUnlinked()
        {
            //// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");

            WebActionLib unlink = new WebActionLib();
            unlink.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            unlink.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            unlink.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName);
            unlink.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            Thread.Sleep(2000);
            unlink.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
              Thread.Sleep(10000);
        }

        public static void VerificationWithoutinitialize()
        {
            ///  ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            WebActionLib link = new WebActionLib();
            link.clickElementByXpath(Ele_LoginButton_Xpath);
            link.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName);
            link.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            link.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);

            //   string verificationcode = Get_Code.getVerificationCode(ReadExcel.Email, TD_yopmail_Page_Url);
            //   System.Diagnostics.Debug.WriteLine(verificationcode);
            //            link.sendTextByXpath(Ele_SignIn_TwoStepAuthField_Xpath, verificationcode);  // Pass activation code to the field

            //link.clickElementByXpath(Ele_SignIn_TwoStepAuth_Done_Xpath);    // Click on done

        }

        public static void entervisitcode(String Visicode)
        {
            /// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            WebActionLib unlink = new WebActionLib();
            unlink.sendTextByXpath(Ele_Order_LinkAcount_Entervisitcode_xpath, Visicode);
            unlink.sendTextByName(Ele_Order_LinkAcount_EnterFirstName_Name, ReadExcel.FirstName);
            unlink.sendTextByName(Ele_Order_LinkAcount_EnterLastName_Name, ReadExcel.LastName);

            string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
            string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
            string value3 = ReadExcel.Dateofbirth.Substring(4, 4);


            unlink.selectListByIndex(Ele_resendvisitcode_monthdropdown_xpath, Int32.Parse(value1));
            unlink.selectListByIndex(Ele_resendvisitcode_Daydropdown_xpath, Int32.Parse(value2));
            unlink.selectListBytext(Ele_resendvisitcode_Yeardropdown_xpath, value3);
            Thread.Sleep(6000);
            unlink.clickElementByXpath(Ele_Order_LinkAcount_Submitbutton_xpath);
            Thread.Sleep(6000);
        }

        public static void resendvisitcode()
        {
            /// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            WebActionLib unlink = new WebActionLib();
            Thread.Sleep(3000);
            unlink.clickElementByLinkText(Ele_LinkAccount_ClickHere_LinkText); // click on resend visit code
            unlink.sendTextByName(Ele_CreateProfile_FirstName_Name, ReadExcel.FirstName);
            unlink.sendTextByName(Ele_CreateProfile_LastName_Name, ReadExcel.LastName);

            string value1 = ReadExcel.Dateofbirth.Substring(0, 2);
            string value2 = ReadExcel.Dateofbirth.Substring(2, 2);
            string value3 = ReadExcel.Dateofbirth.Substring(4, 4);


            unlink.selectListByIndex(Ele_resendvisitcode_monthdropdown_xpath, Int32.Parse(value1));
            unlink.selectListByIndex(Ele_resendvisitcode_Daydropdown_xpath, Int32.Parse(value2));
            unlink.selectListBytext(Ele_resendvisitcode_Yeardropdown_xpath, value3);
            Thread.Sleep(6000);
            unlink.clickElementByXpath(Ele_Order_LinkAcount_Submitbutton_xpath);
            Thread.Sleep(6000);
        }

        public static void addtesttocart_Bytestmenu_unlinked(String testName)
        {
            WebActionLib unlink = new WebActionLib();
            // Thread.Sleep(3000);
            // unlink.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            ///  Driver.Navigate().Refresh();         
            unlink.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            // unlink.waitForElement("classname", Ele_TestMenu_SearchIcon_Classname, 50);
            unlink.WaitForElementByXpathTo_Clickable(Ele_Testmenu_EntertestinSearchbox_Xpath, 60);
            //unlink.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            unlink.clickElementByXpath(Ele_Testmenu_EntertestinSearchbox_Xpath);
            unlink.sendTextById(Ele_TestMenu_TestSearchField_Id, testName);
            unlink.WaitForElementByXpathTo_Clickable(Ele_TestMenu_SearchResult_Xpath, 30); // submit text in search box
            unlink.clickElementByXpath(Ele_TestMenu_SearchResult_Xpath);    // Click on search result
          
            unlink.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);
            Thread.Sleep(3000);
            unlink.clickElementByXpath(Ele_TestMenu_CreateProfile_Yesbutton_Xpath);

        }

        public static void addtesttocart_Bytestmenu_linked(String testName)
        {
            WebActionLib link = new WebActionLib();
            // Thread.Sleep(4000);
            //  link.WaitForElementByXpathTo_Clickable(Ele_DashBoard_Test_xpath, 50);
            // Driver.Navigate().Refresh();
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            link.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            /// link.clickElementByXpath(Ele_DashBoard_TestMenu_Xpath);
            ///link.waitForElementByNameToVisible(Ele_TestMenu_SearchIcon_xpath, 50);
            //Thread.Sleep(3000);
            //link.clickElementByXpath(Ele_TestMenu_searchbox_Xpath2);
            Driver.Navigate().Refresh();
            link.clickElementByLinkText(Ele_DashBoard_Test_linktext);
            Thread.Sleep(3000);
         //   link.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            link.WaitForElementByXpathTo_Clickable(Ele_Testmenu_EntertestinSearchbox_Xpath, 60);
            //unlink.clickElementByClassName(Ele_TestMenu_SearchIcon_Classname);
            link.clickElementByXpath(Ele_Testmenu_EntertestinSearchbox_Xpath);
           
            link.sendTextByXpath(Ele_SearchTesttype_Textbox_Xpath, testName);
            link.WaitForElementByXpathTo_Clickable(Ele_TestMenu_Suggested_Testtype_Xpath, 50);
            //link.WaitForElementByXpathToLoad // submit text in search box
            //link.(Ele_TestMenu_SearchResult_Xpath);    // Click on search result

            link.clickElementByXpath(Ele_TestMenu_Suggested_Testtype_Xpath);
            link.WaitForElementByXpathTo_Clickable(Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
            Thread.Sleep(5000);
           // link.waitForElement("xpath", Ele_TestMenu_Selectedtest_cartIcon_Xpath, 50);
            link.clickElementByXpath(Ele_TestMenu_Selectedtest_cartIcon_Xpath);
        }

        public static void creatingorder()
        {
            WebActionLib link = new WebActionLib();
            Thread.Sleep(5000);
            //  link.waitForElement("xpath", Ele_DashBoard_Myorders_Xpath, 50);
            link.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);
            ///link.clickElementByXpath(Ele_DashBoard_ShoppingCart_Xpath);      // open shopping cart
            Thread.Sleep(3000);
            link.clickElementByClassName(Ele_ShoppingCart_CreateOrder_Classname);  // Click on create order
            link.selectListBytext(Ele_CreatingAnOrder_State_Xpath, "AZ");          // Select state from dropdown
            link.clickElementByXpath(Ele_CreatingAnOrder_Next_Xpath);             //  Click on Next
            link.clickElementByXpath(Ele_CreatingAnOrder_CreateOrder_Xpath);   // Click Create Order
            Thread.Sleep(5000);
        }

        public static void needHelp_Loginpage()
        {
            //  ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            WebActionLib help = new WebActionLib();
            help.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);  // Launch Url
            help.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            help.waitForElement("xpath", Ele_NeedHelp_Xpath, 50);
            help.clickElementByXpath(Ele_NeedHelp_Xpath);

        }

        public static void needHelpToRetriveUsername_notification(String mail)
        {

            WebActionLib help = new WebActionLib();
            Scenario_Functions.needHelp_Loginpage();
            help.clickElementByXpath(Ele_NeedHelp_RetriveUsername_xpath);
            help.sendTextByName(Ele_Retrive_EmailTextbox_Name, mail);
            //Thread.Sleep(3000);
            help.waitForElement("xpath", Ele_RetriveUsernameMailSent_submitbutton_xpath, 50);
            Thread.Sleep(2000);
            help.clickElementByXpath(Ele_RetriveUsernameMailSent_submitbutton_xpath);
        }

        public static String shoppingcartverification()
        {
            WebActionLib cart = new WebActionLib();
            // cart.clickElementByXpath(Ele_DashBoard_ShoppingCart_Xpath2);
            //Thread.Sleep(8000);
            // cart.WaitForElementByXpathTo_Clickable(Ele_DashBoard_Myorders_Xpath, 50);
            //   Driver.Navigate().Refresh();
            cart.clickElementByXpath(Ele_DashBoard_Myorders_Xpath);
            String cartstatuslabel = cart.getTextByXpath(Ele_Emptycartlabel_xpath);
            return cartstatuslabel;
        }

    }
}

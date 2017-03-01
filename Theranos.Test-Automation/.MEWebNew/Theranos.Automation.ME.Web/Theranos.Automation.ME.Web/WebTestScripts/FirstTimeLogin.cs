//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using Theranos.Automation.ME.Web;
//using System.Threading;
//using System.Configuration;
//using System.Collections.Generic;


//namespace Theranos.Automation.ME.Web
//{
//    [TestClass]
//    public class FirstTimeLogin:WebActionLib
//    {
//        LoginWeb Log = new LoginWeb();
//        WebActionLib WebLib = new WebActionLib();
//        public static string AppName = @ConfigurationManager.AppSettings["UserName"];
//        public static string AppPwd = @ConfigurationManager.AppSettings["PassWord"];
        

//        [TestMethod]
//        public void NewLogin()
//        {
//            try { 
//            //Log.Initialize();
//            //string username = AppName + StringGenerator.RandomString(2);
//            //string password = AppPwd;
//            //WebLib.WaitForElementLoad(LoginUserName_ByXpath,20);
//            //string currentwindow =WebActionLib.Driver.CurrentWindowHandle;
//            //List<string> w = new List<string>(Driver.WindowHandles);
//            //WebLib.SetText(LoginUserName_ByXpath, "gsrchg");
//            //WebLib.WaitForElementLoad(LoginPassword_Byxpath, 8);
//            //WebLib.SetText(LoginPassword_Byxpath, AppPwd);
//            //WebLib.clickbuttonbyxpath(WebME.SubmitBtn_ByXpath);
//            var code = GetActivateCode("jk2112@yopmail.com");
//            WebLib.wait();
//            //Driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            
            
//            //List<string> ww = new List<string>(WebActionLib.Driver.WindowHandles);
//            ////WebActionLib.Driver.SwitchTo().Window(currentwindow);
//            //WebLib.WaitForElementLoad(VerificationCode_ByXpath, 15);
//            //WebLib.SetText(VerificationCode_ByXpath, code);
//            //WebLib.clickbuttonbyxpath(Ver_Done_ByXpath);
//            }
//            catch (Exception e)
//            {
//                String sMessage = e.Message; throw new Exception(sMessage);
//            }

//        }
        

//        [TestMethod]
//        public void ActivateLink()
//        {
//            try { 
//            String MailUrl = "http://www.yopmail.com/en/";
//            WebActionLib.Driver = new FirefoxDriver();
//            WebActionLib.Driver.Navigate().GoToUrl(MailUrl);
//            WebLib.Windowmaximize();
//            WebLib.SetText(Yopemail_ByXpath, LoginWeb.appusername + "@Yopmail.com");
//            WebLib.wait();
//            WebLib.clickbuttonbyxpath(yopBtn_ByXpath);
//            WebLib.WaitForElementByXpathTo_Clickable(Yopemail_ByXpath, 20);
//            WebLib.SwitchFrame(Frame_ByID);
//            WebLib.clickbuttonbyxpath(Activatelink_ByXpath);
//            }
//            catch (Exception e)
//            {
//                String sMessage = e.Message; throw new Exception(sMessage);
//            }
//        }

//        [TestMethod]
//        public string GetActivateCode(string emailaddress )
//        {
//            try { 
//            var driver2 = WebActionLib.Driver;
//            String MailUrl = "http://www.yopmail.com/en/";
//            WebActionLib.Driver = new FirefoxDriver();          
//            WebActionLib.Driver.Navigate().GoToUrl(MailUrl);
//            WebLib.Windowmaximize();
//            //WebLib.SetText(Yopemail_ByXpath, LoginWeb.appusername + "@Yopmail.com");
//            WebLib.SetText(Yopemail_ByXpath, emailaddress);
//            WebLib.wait();
//            WebLib.clickbuttonbyxpath(yopBtn_ByXpath);
//            WebLib.WaitForElementByXpathTo_Clickable(Yopemail_ByXpath, 20);
//            WebLib.SwitchFrame(Frame_ByID);
//            var code=  WebLib.getText(ActivateCode_ByXpath);
//            return code;
//            }
//            catch (Exception e)
//            {
//                String sMessage = e.Message; throw new Exception(sMessage);
//            }

//        }
//    }
//}

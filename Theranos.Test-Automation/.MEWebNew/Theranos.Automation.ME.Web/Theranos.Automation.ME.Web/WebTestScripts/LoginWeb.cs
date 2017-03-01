using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using Theranos.Automation.ME.Web.Utility;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web
{
    [TestClass]
    public class LoginWeb : WebActionLib
    {
       // WebActionLib WebLib = new WebActionLib();
       // public static string AppName = @ConfigurationManager.AppSettings["UserName"];
       // public static string AppPath = @ConfigurationManager.AppSettings["Email"];
       // public static string apppassword = @ConfigurationManager.AppSettings["Password"];
       // public static string appusername = AppName + StringGenerator.RandomString(2);

       //[TestMethod]
       // public void SignupTest()
       // {
       //     String mailextension = "https://www.mailinator.com/";
       //     WebLib.WaitForElementByXpathTo_Clickable(WebME.SignUp_ByXpath, 240);
       //     WebLib.clickbuttonbyxpath(WebME.SignUp_ByXpath);
       //     WebLib.SetTextByName(WebME.Email_ByName, appusername + mailextension);
       //     WebLib.SetText(WebME.SignUpUserName_ByXpath, appusername);
       //     //WebLib.SetText(SignUpUserName_ByXpath, "QAZZTest");
       //     WebLib.SetText(SignUpPassword_ByXpath, apppassword);
       //     WebLib.clickbuttonbyxpath(AccCheckBox_ByXpath);
       //     WebLib.SetText(WebME.Acc_FirstQuestionAnwser_ByXpath, "QATest1");
       //     WebLib.SetText(WebME.Acc_SecondQuestionAnwser_ByXpath, "QATest1");
       //     WebLib.SetText(WebME.Acc_ThirdQuestionAnwser_ByXpath, "QATest1");
       //     WebLib.clickbuttonbyxpath(Security_AccCheckBox_ByXpath);
       //     WebLib.clickbuttonbyxpath(WebME.CreateAccout_ByXpath);

       // }

       // [TestMethod]
       // public void ActivateYopmail()
       // {
       //     String MailUrl = "http://www.yopmail.com/en/";
       //     WebActionLib.Driver = new FirefoxDriver();
       //     WebActionLib.Driver.Navigate().GoToUrl(MailUrl);
       //     WebLib.Windowmaximize();
       //     WebLib.SetText(Yopemail_ByXpath, appusername+"@Yopmail.com");
       //     WebLib.wait();
       //     WebLib.clickbuttonbyxpath(yopBtn_ByXpath);
       //     WebLib.WaitForElementByXpathTo_Clickable(Yopemail_ByXpath, 20);
       //     WebLib.SwitchFrame(Frame_ByID);
       //     WebLib.clickbuttonbyxpath(Activatelink_ByXpath);         
       //     string currentwindow = Driver.CurrentWindowHandle;
       //     List<string> w = new List<string>(Driver.WindowHandles);
       //     Driver.SwitchTo().Window(w[1]);
       //     //WebLib.WaitForElementLoad(SignUp_ByXpath,25);
       //     WebLib.wait();
       //     WebLib.clickbuttonbyxpath(SignUp_ByXpath);
       //     WebLib.WaitForElementByXpathTo_Clickable(LoginUserName_ByXpath, 15);
       //     WebLib.SetText(LoginUserName_ByXpath, appusername);
       //     WebLib.WaitForElementByXpathTo_Clickable(LoginPassword_Byxpath, 15);
       //     WebLib.SetText(LoginPassword_Byxpath, apppassword);
       //     WebLib.WaitForElementByXpathTo_Clickable(SubmitBtn_ByXpath, 10);
       //     WebLib.clickbuttonbyxpath(WebME.SubmitBtn_ByXpath);
       //     Thread.Sleep(10000);
       // }

       //   [TestMethod]
       // public void CleanUp()
       // {
       //     WebActionLib.Driver.Close();
       //     Console.WriteLine("Closed the browser");
       // }
        public void SignupTest()
        {
            WebActionLib sg = new WebActionLib();
            sg.launchBrowserWithUrl("Firefox", "https://www.mailinator.com/");
            sg.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            sg.sendTextByName(".//*[@id='inboxfield']", ""); ///ReadExcel.NewUserName

            sg.clickElementByXpath(".//*[@id='row_public_1460026727-200011674137-omkar']/div[2]/div[2]/div");

            string verificationcode = Get_Code.getVerificationCode(ReadExcel.Email, TD_yopmail_Page_Url);
            System.Diagnostics.Debug.WriteLine(verificationcode);
            sg.sendTextByXpath(Ele_SignIn_TwoStepAuthField_Xpath, verificationcode);  // Pass activation code to the field

            sg.clickElementByXpath(Ele_SignIn_TwoStepAuth_Done_Xpath);    // Click on done
            Thread.Sleep(10000);
        }
    }
}



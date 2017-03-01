using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.Android;
using OpenQA.Selenium.Appium.Android;
using Theranos.Automation.ME.Android.Model;
using OpenQA.Selenium;

namespace Theranos.Automation.ME.Android.TestScripts
{

    public class About : MELoginModel
    {
        ActionLib Wib = new ActionLib();


        public void Aboutpage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, About_ByName);
            Wib.WaitForElementLoad_Byid(driver, Company_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);
        }

        public void ThirdPartyPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, About_ByName);
            Wib.WaitForElementLoad_Byid(driver, ThirdParty_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, ThirdParty_ById);
            Wib.WaitForElementLoad_Byid(driver, InsideThirdParty2_ById, AndroStack.ImplicitTimeout);
            var sa1 = Wib.getText_byID(driver, InsideThirdParty_ById);
            var sa2 = Wib.getText_byID(driver, InsideThirdParty2_ById);
            driver.ScrollTo("JodaTime");
            var sa3 = Wib.getText_byID(driver, InsideThirdParty3_ById);
            var sa4 = Wib.getText_byID(driver, InsideThirdParty4_ById);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);

        }
        public void PrivacyPolicyPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, About_ByName);
            Wib.WaitForElementLoad_Byid(driver, Privacy_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Privacy_ById);
            Wib.WaitForElementLoad_ByName(driver, Privacy_ByName, AndroStack.ImplicitTimeout);
            //var sample = driver.FindElements(By.ClassName("android.view.View"));
            //var sa1 = sample[17].Text;
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);

        }
        public void SecurityPage(AndroidDriver<AndroidElement> driver) 
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, About_ByName);
            Wib.WaitForElementLoad_Byid(driver, Security_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Security_ById);
            Wib.WaitForElementLoad_ByName(driver, Security_ByName, AndroStack.ImplicitTimeout);
            //var sample = driver.FindElements(By.ClassName("android.view.View"));
            //var sa1 = sample[17].Text;
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);

        }
        public void TermPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, About_ByName);
            Wib.WaitForElementLoad_Byid(driver, TermUse_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, TermUse_ById);
            Wib.WaitForElementLoad_ByName(driver, TermUse_ByName, AndroStack.ImplicitTimeout);
            //var sample = driver.FindElements(By.ClassName("android.view.View"));
            //var sa1 = sample[17].Text;
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, About_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);

        }

    }
}
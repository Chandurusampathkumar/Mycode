using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts
{
    public class Centers : MEAccountModel
    {
        ActionLib Wib = new ActionLib();

        public void CheckNearLocation(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, FindCenter_ById);
            Wib.WaitForElementLoad_ByName(driver, FindCenter_ByName, AndroStack.ImplicitTimeout);
            var Center = Wib.getText_byID(driver, TheranosCenter_ById);
            var Distance = Wib.getText_byID(driver, TheransoDistance_ById);
            var SecondLocation = Wib.getText_byID(driver, TheranosSecondName_ById);
            var CenterAddress = Wib.getText_byID(driver, TheranosAddress_ById);
            Assert.AreEqual(TheranosCenter_ByName, Center);
            Assert.AreEqual(TheranosDistance_ByName, Distance);
            Assert.AreEqual(TheranosSecondName_ByName, SecondLocation);
            Assert.AreEqual(TheranosAddress_ByName, CenterAddress);
            var ClassN = driver.FindElements(By.ClassName("android.widget.LinearLayout"));
            var subclass = ClassN[1].FindElements(By.ClassName("android.widget.RelativeLayout"));
            var Center2 = subclass[1].FindElement(By.Id(TheranosCenter_ById)).Text;
            var Distance2 = subclass[1].FindElement(By.Id(TheransoDistance_ById)).Text;
            var SecondLocation2 = subclass[1].FindElement(By.Id(TheranosSecondName_ById)).Text;
            var CenterAddress2 = subclass[1].FindElement(By.Id(TheranosAddress_ById)).Text;
            Assert.AreEqual(TheranosCenter_ByName, Center2);
            Assert.AreEqual(TheranosDistance2_ByName, Distance2);
            Assert.AreEqual(TheranosSecondName_ByName, SecondLocation2);
            Assert.AreEqual(TheranosAddress2_ByName, CenterAddress2);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
        }
        public void SelectedCenterIsDisplayed(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, FindCenter_ById);
            Wib.WaitForElementLoad_ByName(driver, FindCenter_ByName, AndroStack.ImplicitTimeout);           
            var ClassN = driver.FindElements(By.ClassName("android.widget.LinearLayout"));
            var subclass = ClassN[1].FindElements(By.ClassName("android.widget.RelativeLayout"));
            var Center2 = subclass[0].FindElement(By.Id(TheranosCenter_ById)).Text;
            var Distance2 = subclass[0].FindElement(By.Id(TheransoDistance_ById)).Text;
            var SecondLocation2 = subclass[0].FindElement(By.Id(TheranosSecondName_ById)).Text;
            //var CenterAddress2 = subclass[0].FindElement(By.Id(TheranosAddress_ById)).Text;
            subclass[0].FindElement(By.Id(TheranosCenter_ById)).Click();
            Wib.WaitForElementLoad_Byid(driver, SaveIcon_ById, AndroStack.ImplicitTimeout);
            var Center = Wib.getText_byID(driver, TheranosCenter_ById);           
            var SecondLocation = Wib.getText_byID(driver, TheranosSecondName_ById);
            var CenterAddress = Wib.getText_byID(driver, CenterAddress_ById);
            Assert.AreEqual(Center2, Center);
            Assert.AreEqual(SecondLocation2, SecondLocation);
            Assert.AreEqual(CenterAddress_ByName, CenterAddress);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, FindCenter_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
        }


        public void CenterSearchLocation(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, FindCenter_ById);
            Wib.WaitForElementLoad_ByName(driver, FindCenter_ByName, AndroStack.ImplicitTimeout);
            var Center = Wib.getText_byID(driver, FindCenterPage_ById);
            Wib.clickButton_Byid(driver, Search_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchLocation_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchLocation_ByName, "Arizona");
            Wib.WaitForElementLoad_ByName(driver, ArizonaUnitedStates_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ArizonaUnitedStates_ByName);
            Wib.WaitForElementLoad_ByName(driver, ArizonaResult_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts
{
    [TestClass]
    public class DashBoardUser : MEAccountModel
    {
        ActionLib Wib = new ActionLib();

        public void FindCenterFromDashBoard(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, FindCenter_ById);
            Wib.WaitForElementLoad_ByName(driver, FindCenter_ByName, AndroStack.ImplicitTimeout);
            var Center = Wib.getText_byID(driver, FindCenterPage_ById);
            Assert.AreEqual(FindCenter_ByName, Center);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);

        }

        public void DashBoardtoOrderPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, DashBoardOrder_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, DashBoardOrder_ById);
            Wib.WaitForElementLoad_ByName(driver, OrderPage_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, FindCenterPage_ById);
            Assert.AreEqual(OrderPage_ByName, CheckCondition);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);

        }
        public void DashBoardToResultPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, DashBoardResult_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, DashBoardResult_ById);
            Wib.WaitForElementLoad_ByName(driver, ResultPage_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, FindCenterPage_ById);
            Assert.AreEqual(ResultPage_ByName, CheckCondition);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);



        }
    }
}
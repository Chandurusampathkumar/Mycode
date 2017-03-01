using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Threading;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts
{

    public class UploadOrders : Orders
    {
        ActionLib Wib = new ActionLib();
        DashBoardOrder Orders = new DashBoardOrder();
      
        public int BeforeUploadCount;


        public void CaptureImage(AndroidDriver<AndroidElement> driver)
        {
            BeforeUploadCount = driver.FindElements(By.Name(PendingOrder_ByName)).Count;
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, AddBtn_byId);
            Wib.WaitForElementLoad_ByName(driver, Add_SelectFromMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Add_Upload_ByName);
            Boolean IsPopupPresent = driver.FindElements(By.Name(No_ByName)).Count > 0;
            //Boolean IsPopupPresent2 = driver.FindElements(By.Name(Ok_ByName)).Count > 0;
            if (IsPopupPresent == true)
            {
                Assert.IsTrue(true, "Asking to link the account");
                Orders.TestMenuProvisionAccout(driver);
            }

            Wib.wait(driver);
            driver.Navigate().Back();
            Wib.WaitForElementLoad_Byid(driver, UploadCameraTitle_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(UploadCameraTitle_ById)).Count > 0;
            if (IsPresent == true)
            {
                Assert.IsTrue(true, "Inside upload Page");
            }
            else
            {
                Assert.Fail();
            }

            Wib.WaitForElementLoad_Byid(driver, CameraTakePicture_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CameraTakePicture_ById);
            Wib.WaitForElementLoad_Byid(driver, CameraUsePhoto_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CameraUsePhoto_ById);
            Wib.WaitForElementLoad_Byid(driver, CameraDone_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CameraDone_ById);
            Wib.WaitForElementLoad_Byid(driver, PopUploadSubmitBtn_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, PopUploadSubmitBtn_ById);
            Wib.WaitForElementLoad_ByName(driver, MenuOrderBtn_ByName, AndroStack.ImplicitTimeout);
        }
        
        public void CheckUploadOrderCreated(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MenuOrderBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByName(driver, PendingOrder_ByName, AndroStack.ImplicitTimeout);
            var AfterUploadCount = driver.FindElements(By.Name(PendingOrder_ByName)).Count;
            if (AfterUploadCount > BeforeUploadCount)
            {
                Assert.IsTrue(true, "Uploaded the order successfully !");
            }
            else
            {
                Assert.Fail("Order not uploaded successfully !");
            }
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
        }
    }
}
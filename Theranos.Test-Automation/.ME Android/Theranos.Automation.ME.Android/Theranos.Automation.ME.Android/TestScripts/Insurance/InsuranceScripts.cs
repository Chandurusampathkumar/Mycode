using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts.Insurance
{
    [TestClass]
    public class InsuranceScripts : MEAccountModel
    {
        ActionLib Wib = new ActionLib();

        public void InsurancePage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Insurance_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Insurance_ByName);
            Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
            Assert.IsTrue(true, "Inside the Insurance Page.");

        }
        public void AddInsurancepage(AndroidDriver<AndroidElement> driver)
        {
            if (ExcelValues.NewUserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Boolean IsFirstInsurance = driver.FindElements(By.Id(InsuranceIcon_ById)).Count > 0;
            if (IsFirstInsurance == true)
            {
                var CountBeforeAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddInsurance_ById);
                Wib.WaitForElementLoad_ByName(driver, AddInsurance_ByName, AndroStack.ImplicitTimeout);
                driver.Navigate().Back();
                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, SelectInsuranceProvider_ByName);
                Wib.WaitForElementLoad_ByName(driver, SearchProviders_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, Addprovider_ById);
                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                Wib.SetText_ByName(driver, InsuredId_ByName, ExcelValues.InsureId);
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);

                var CountAfterAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                if (CountBeforeAddInsurance.Count == CountAfterAddInsurance.Count)
                {
                    Assert.IsTrue(true, "Insurance added successfully !");
                    Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                var CountBeforeAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddInsurance_ById);
                Wib.WaitForElementLoad_ByName(driver, AddInsurance_ByName, AndroStack.ImplicitTimeout);
                driver.Navigate().Back();
                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, SelectInsuranceProvider_ByName);
                Wib.WaitForElementLoad_ByName(driver, SearchProviders_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, Addprovider_ById);
                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                Wib.SetText_ByName(driver, InsuredId_ByName, ExcelValues.InsureId);
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);

                var CountAfterAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                if (CountAfterAddInsurance.Count > CountBeforeAddInsurance.Count)
                {
                    Assert.IsTrue(true, "Insurance added successfully !");
                    Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
                }
                else
                {
                    Assert.Fail();
                }
            }

        }
        public void RemoveInsurance(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Insurance_ByName, AndroStack.ImplicitTimeout);
            var CountBeforeRemoveInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
            Boolean IsNoInsurancePresent = driver.FindElements(By.Id(InsuranceIcon_ById)).Count > 0;
            if (IsNoInsurancePresent == false)
            {
                var Lists = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Lists[3].Click();
                Wib.WaitForElementLoad_ByName(driver, EditInsurance_ByName, AndroStack.ImplicitTimeout);
                driver.ScrollTo(RemoveInsurance_ByName);
                Wib.ElementClickable_Byid(driver, RemoveInsurance_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, RemoveInsurance_ById);
                Wib.WaitForElementLoad_ByName(driver, RemoveBtn_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, RemoveBtn_ByName);
                Wib.WaitForElementLoad_ByName(driver, Insurance_ByName, AndroStack.ImplicitTimeout);
            }
            else
            {
                Assert.Fail("No Insurance is to remove");

            }
            Boolean CheckCondition = driver.FindElements(By.Id(InsuranceIcon_ById)).Count > 0;
            var CountAfterRemoveInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
            if (CountAfterRemoveInsurance.Count == CountBeforeRemoveInsurance.Count)
            {
                if (CheckCondition == true)
                {
                    Assert.IsTrue(true, "Insurance is removed succesfully and no other Insurance is present");
                    Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
                }
            }
            else
            {
                Assert.IsTrue(true, "Insurance is removed succesfully");
                Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            }

        }
        public void SelectedInsuranceDisplayed(AndroidDriver<AndroidElement> driver)
        {
            if (ExcelValues.NewUserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Boolean IsFirstInsurance = driver.FindElements(By.Id(InsuranceIcon_ById)).Count > 0;
            if (IsFirstInsurance == true)
            {
                var CountBeforeAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddInsurance_ById);
                Wib.WaitForElementLoad_ByName(driver, AddInsurance_ByName, AndroStack.ImplicitTimeout);
                driver.Navigate().Back();
                var InputCollection = driver.FindElements(By.Id(Input_ById));
                var FirstName = InputCollection[0].Text;
                var LastName = InputCollection[1].Text;
                var Subscriber = "Subscriber:" + " " + FirstName + " " + LastName;
                Wib.clickButton_ByName(driver, SelectInsuranceProvider_ByName);
                Wib.WaitForElementLoad_ByName(driver, SearchProviders_ByName, AndroStack.ImplicitTimeout);
                Wib.SetText_ByName(driver, SearchProviders_ByName, Provider_ByName);
                var IsProviderPresent = driver.FindElements(By.Name(Provider_ByName)).Count >= 2;
                if (IsProviderPresent == true)
                {
                    var Provider = driver.FindElements(By.Name(Provider_ByName));
                    Provider[1].Click();
                }
                else
                {
                    Assert.Fail("No provider is present");
                }

                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byID(driver, DisplayProvider_ById);
                Assert.AreEqual(Provider_ByName, CheckCondition);
                Wib.SetText_ByName(driver, InsuredId_ByName, ExcelValues.InsureId);
                var InsuredId = "Insured ID:" + " " + ExcelValues.InsureId;
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                var DisplayedProvider = Wib.getText_byID(driver, Provider__ById);
                var DisplayedSubscriber = Wib.getText_byID(driver, DisplayedSubscriber_ById);
                var DisplayedInsured = Wib.getText_byID(driver, DisplayedInsured_ById);
                Assert.AreEqual(Provider_ByName, DisplayedProvider);
                Assert.AreEqual(Subscriber, DisplayedSubscriber);
                Assert.AreEqual(InsuredId, DisplayedInsured);
                var CountAfterAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                if (CountBeforeAddInsurance.Count == CountAfterAddInsurance.Count)
                {
                    Assert.IsTrue(true, "Insurance added successfully !");
                    Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                var CountBeforeAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddInsurance_ById);
                Wib.WaitForElementLoad_ByName(driver, AddInsurance_ByName, AndroStack.ImplicitTimeout);
                driver.Navigate().Back();
                var InputCollection = driver.FindElements(By.Id(Input_ById));
                var FirstName = InputCollection[0].Text;
                var LastName = InputCollection[1].Text;
                var Subscriber = "Subscriber:" + " " + FirstName + " " + LastName;
                Wib.clickButton_ByName(driver, SelectInsuranceProvider_ByName);
                Wib.WaitForElementLoad_ByName(driver, SearchProviders_ByName, AndroStack.ImplicitTimeout);
                Wib.SetText_ByName(driver, SearchProviders_ByName, Provider_ByName);
                var IsProviderPresent = driver.FindElements(By.Name(Provider_ByName)).Count >= 2;
                if (IsProviderPresent == true)
                {
                    var Provider = driver.FindElements(By.Name(Provider_ByName));
                    Provider[1].Click();
                }
                else
                {
                    Assert.Fail("No provider is present");
                }

                Wib.WaitForElementLoad_ByName(driver, InsuredId_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byID(driver, DisplayProvider_ById);
                Assert.AreEqual(Provider_ByName, CheckCondition);
                Wib.SetText_ByName(driver, InsuredId_ByName, ExcelValues.InsureId);
                var InsuredId = "Insured ID:" + " " + ExcelValues.InsureId;
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_Byid(driver, AddInsurance_ById, AndroStack.ImplicitTimeout);
                var DisplayedProvider = Wib.getText_byID(driver, Provider__ById);
                var DisplayedSubscriber = Wib.getText_byID(driver, DisplayedSubscriber_ById);
                var DisplayedInsured = Wib.getText_byID(driver, DisplayedInsured_ById);
                Assert.AreEqual(Provider_ByName, DisplayedProvider);
                Assert.AreEqual(Subscriber, DisplayedSubscriber);
                Assert.AreEqual(InsuredId, DisplayedInsured);
                var CountAfterAddInsurance = driver.FindElements(By.ClassName(ContactsList_Byclass));
                if (CountAfterAddInsurance.Count > CountBeforeAddInsurance.Count)
                {
                    Assert.IsTrue(true, "Insurance added successfully !");
                    Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
                }
                else
                {
                    Assert.Fail();
                }

            }
        }
    }
}
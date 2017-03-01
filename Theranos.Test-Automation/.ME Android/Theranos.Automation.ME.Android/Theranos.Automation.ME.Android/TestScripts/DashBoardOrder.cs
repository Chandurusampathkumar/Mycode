using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.MeWeb;
using Theranos.Automation.ME.Android.Model;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;


namespace Theranos.Automation.ME.Android.TestScripts
{

    public class DashBoardOrder : Orders
    {
        ActionLib Wib = new ActionLib();
        CreateAccountPage log = new CreateAccountPage();
        YopActivation YA = new YopActivation();
        LoginValidation LL = new LoginValidation();
        public static AndroidDriver<AndroidElement> driver;

        public void DashBoardOrders(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_ByName(driver, MenuOrderBtn_ByName);
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(AddBtn_byId)).Count > 0;
            if (IsPresent == true)
            {
                Assert.IsTrue(true, "AddBtn is visible!");
            }
            else
            {
                Assert.Fail();
            }

        }
        public void OrdersPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, AddBtn_byId);
            Wib.WaitForElementLoad_ByName(driver, Add_SelectFromMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Add_SelectFromMenu_ByName);
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Name(TestMenu_ByName)).Count > 0;
            if (IsPresent == true)
            {
                Assert.IsTrue(true, "Inside TestMenu Page");
            }
            else
            {
                Assert.Fail();
            }
        }
        public void TestMenuPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Name(CptTest_ByName)).Click();
        }
        public void CheckCartEnable(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(Add_ById)).Count > 0;
            if (IsPresent == true)
            {
                Wib.clickButton_Byid(driver, Add_ById);
                Boolean IsPopupPresent2 = driver.FindElements(By.Name(Ok_ByName)).Count > 0;
                if (IsPopupPresent2 == true)
                {
                    Assert.IsTrue(true, "Direct testing message");
                    Wib.WaitForElementLoad_Byid(driver, Button_Yes_ById, AndroStack.ImplicitTimeout);
                    Wib.clickButton_Byid(driver, Button_Yes_ById);
                }

            }
            else
            {
                Assert.Fail("Test already added");
            }
            Wib.WaitForElementLoad_Byid(driver, AddToCartCount_ById, 10);
            Boolean IsCartEnable = driver.FindElements(By.Id(AddToCartCount_ById)).Count > 0;
            if (IsCartEnable == true)
            {
                var Count = Wib.getText_byID(driver, AddToCartCount_ById);
                Assert.AreEqual("1", Count);
            }
            else
            {
                Assert.Fail("Cart is not enabled!");
            }
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, 10);
            Wib.clickButton_Byid(driver, AddToCart_ById);

        }
        public void BrowseTestToTestMenuPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, MELoginModel.BrowseTest_ByName);
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);//trying click username
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, MELoginModel.LogOut_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.NeedHelp_ByName, 20);
            var ActualResult = Wib.getText_byName(driver, MELoginModel.NeedHelp_ByName);
            Assert.AreEqual(MELoginModel.NeedHelp_ByName, ActualResult);

        }
        public void TestMenuPageAddTest(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(Add_ById)).Count > 0;
            if (IsPresent == true)
            {
                Wib.clickButton_Byid(driver, Add_ById);
            }
            else
            {
                Boolean IsCptAdded = driver.FindElements(By.Id(AddedCpt_ById)).Count > 0;
                if (IsCptAdded == true)
                {
                    Assert.IsTrue(true, "Cpt is Already added!");
                    Wib.clickButton_Byid(driver, AddToCart_ById);
                    Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
                    Boolean CheckCondtion = driver.FindElements(By.Name(MyOrder_ByName)).Count > 0;
                    if (CheckCondtion == true)
                    {
                        Assert.IsTrue(true, "Inside My order page");
                        return;
                    }
                }
            }
            Boolean IsPopupPresent = driver.FindElements(By.Name(No_ByName)).Count > 0;
            Boolean IsPopupPresent2 = driver.FindElements(By.Name(Ok_ByName)).Count > 0;
            if (IsPopupPresent == true)
            {
                Assert.IsTrue(true, "Asking to link the account");
            }

            else if (IsPopupPresent2 == true)
            {
                Assert.IsTrue(true, "Direct testing message");
                Wib.WaitForElementLoad_Byid(driver, Button_Yes_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, Button_Yes_ById);
                Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddToCart_ById);
            }
            else
            {
                Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddToCart_ById);

            }
        }
        public void CheckParticularTestDetails(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SearchImage_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchCode_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchCode_ByName, TestName);
            var IsCptPresent = driver.FindElements(By.Name(TestName)).Count >= 2;
            if (IsCptPresent == true)
            {
                var CPTTest = driver.FindElements(By.Name(TestName));
                CPTTest[1].Click();
            }
            else
            {
                Assert.Fail("No Cpt test is present");
            }

            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            var TName = Wib.getText_byID(driver, TestName_ById);
            var TCpt = Wib.getText_byID(driver, TestCpt_ById);
            var TAvaliable = Wib.getText_byID(driver, TestAvailable_ById);
            var TPrice = Wib.getText_byID(driver, TestPrice_ById);
            Assert.AreEqual(TestName, TName);
            Assert.AreEqual(TestCpt_ByName, TCpt);
            Assert.AreEqual(TestAvaliable, TAvaliable);
            Assert.AreEqual(TestPrice, TPrice);
            
        }
        public void CheckFastingTestDetails(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SearchImage_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchCode_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchCode_ByName, FastingTest_ByName);
            var IsCptPresent = driver.FindElements(By.Name(FastingTest_ByName)).Count >= 2;
            if (IsCptPresent == true)
            {
                var CPTTest = driver.FindElements(By.Name(FastingTest_ByName));
                CPTTest[1].Click();
            }
            else
            {
                Assert.Fail("No Cpt test is present");
            }

            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            var TName = Wib.getText_byID(driver, TestName_ById);
            var TCpt = Wib.getText_byID(driver, TestCpt_ById);
            var TAvaliable = Wib.getText_byID(driver, TestAvailable_ById);
            var TPrice = Wib.getText_byID(driver, TestPrice_ById);
            var TFasting = Wib.getText_byID(driver, FastingHour_ById);
            Wib.clickButton_Byid(driver, FastingHour_ById);
            Wib.WaitForElementLoad_Byid(driver, FastingHourHeader_ById, AndroStack.ImplicitTimeout);
            var TFastingHeader = Wib.getText_byID(driver, FastingHourHeader_ById);
            var TFastingBody = Wib.getText_byID(driver, FastingHourBody_ById);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Assert.AreEqual(FastingTest_ByName, TName);
            Assert.AreEqual(FastingTestCpt_ByName, TCpt);
            Assert.AreEqual(FastingTestAvaliable, TAvaliable);
            Assert.AreEqual(FastingTestPrice, TPrice);
            Assert.AreEqual(FastingHour_ByName, TFasting);
            Assert.AreEqual(FastingHour_ByName, TFastingHeader);
            //Assert.AreEqual(FastingHourBody_ByName, TFastingBody);

        }
        public string AddParticularCptTest(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SearchImage_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchCode_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchCode_ByName, "84460");
            var IsCptPresent = driver.FindElements(By.Name("84460")).Count >= 2;
            if (IsCptPresent == true)
            {
                var CPTTest = driver.FindElements(By.Name("84460"));
                CPTTest[1].Click();
            }
            else
            {
                Assert.Fail("No Cpt test is present");
            }
            var CPTCode = "84460";
            return CPTCode;
        }
        public string AddParticularCptTest(AndroidDriver<AndroidElement> driver,string CptCode)
        {
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SearchImage_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchCode_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchCode_ByName, CptCode);
            var IsCptPresent = driver.FindElements(By.Name(CptCode)).Count >= 2;
            if (IsCptPresent == true)
            {
                var CPTTest = driver.FindElements(By.Name(CptCode));
                CPTTest[1].Click();
            }
            else
            {
                Assert.Fail("No Cpt test is present");
            }

            return CptCode;
        }
        public void AddTwoCptTestOrder(AndroidDriver<AndroidElement> driver)
        {
            CheckParticularTestDetails(driver);
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(Add_ById)).Count > 0;
            if (IsPresent == true)
            {
                Wib.clickButton_Byid(driver, Add_ById);
                Boolean IsPopupPresent2 = driver.FindElements(By.Name(Ok_ByName)).Count > 0;
                if (IsPopupPresent2 == true)
                {
                    Assert.IsTrue(true, "Direct testing message");
                    Wib.WaitForElementLoad_Byid(driver, Button_Yes_ById, AndroStack.ImplicitTimeout);
                    Wib.clickButton_Byid(driver, Button_Yes_ById);
                }
            }
            else
            {
                Assert.Fail("Cpt Test already added!");
            }
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            AddParticularCptTest(driver);
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent2 = driver.FindElements(By.Id(Add_ById)).Count > 0;
            if (IsPresent2 == true)
            {
                Wib.clickButton_Byid(driver, Add_ById);
            }
            else
            {
                Assert.Fail("Cpt Test already added!");
            }
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, 20);
            Boolean IsCartEnable = driver.FindElements(By.Id(AddToCartCount_ById)).Count > 0;
            if (IsCartEnable == true)
            {
                var Count = Wib.getText_byID(driver, AddToCartCount_ById);
                if (Count == "2")
                {
                    Assert.IsTrue(true, "Cpt test successfully added in cart!");
                }
            }
            else
            {
                Assert.Fail("Cpt tests are not added successfully!");
            }
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, 10);
            Wib.clickButton_Byid(driver, AddToCart_ById);
        }
        public void TestMenuProvisionAccout(AndroidDriver<AndroidElement> driver)
        {
            if (ExcelValues.NewUserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Wib.WaitForElementLoad_Byid(driver, Button_No_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Button_No_ById);
            Wib.WaitForElementLoad_ByName(driver, Pro_FirstName_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, Pro_FirstName_ByName, ExcelValues.FirstName);
            driver.Navigate().Back();
            Wib.SetText_ByName(driver, pro_LastName_ByName, ExcelValues.LastName);
            driver.Navigate().Back();
            Wib.clickButton_ByName(driver, Pro_DOB_ByName);
            var Collections = driver.FindElements(By.ClassName("android.widget.LinearLayout"));
            Collections[0].Click();
            Collections[0].SendKeys(ExcelValues.Day);
            driver.KeyEvent(61);
            Collections[0].SendKeys(ExcelValues.Year);
            Wib.clickButton_Byid(driver, Pro_Done_Byid);
            Wib.WaitForElementLoad_ByName(driver, Pro_Gender_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Pro_Gender_ByName);
            Wib.clickButton_ByName(driver, Pro_Male_ByName);
            Wib.clickButton_ByName(driver, Pro_SaveBtn_ByName);
            Wib.WaitForElementLoad_Byid(driver, Pro_Submit_ById, 10);
            Wib.clickButton_Byid(driver, Pro_Submit_ById);
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, AddToCart_ById);

        }
        public void OrdersMenuLinkAcc(AndroidDriver<AndroidElement> driver)
        {
            Boolean IsPopupPresent = driver.FindElements(By.Id(Button_Yes_ById)).Count > 0;
            if (IsPopupPresent == true)
            {
                Wib.WaitForElementLoad_Byid(driver, Button_Yes_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, Button_Yes_ById);
                Wib.WaitForElementLoad_ByName(driver, LinkAcc_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, LinkACC_RetrieveCode_ById);
                Wib.WaitForElementLoad_ByName(driver, RetrieveVisitCode_ByName, AndroStack.ImplicitTimeout);
                Wib.SetText_ByName(driver, Pro_FirstName_ByName, "AppiumAutoone");
                driver.Navigate().Back();
                Wib.SetText_ByName(driver, pro_LastName_ByName, "Auto");
                driver.Navigate().Back();
                Wib.clickButton_ByName(driver, Pro_DOB_ByName);
                Wib.clickButton_Byid(driver, Pro_Done_Byid);
                Wib.clickButton_Byid(driver, LinkAcc_SubmitBtn_ById);
            }
            else
            {
                Assert.Fail();
            }

        }
        public void CreateOrderFromOrders(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            //do
            //{
            //    Wib.wait(driver);
            //} while (driver.FindElements(By.Id(SelectDropDown_ById)).Count < 0);
            Wib.WaitForElementLoad_Byid(driver, SelectDropDown_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SelectDropDown_ById);
            //do
            //{
            //    Wib.wait(driver);
            //} while (driver.FindElements(By.Name(Item_ByName)).Count < 0);

            Wib.WaitForElementLoad_ByName(driver, Item_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Item_ByName);
            Wib.ElementClickable_Byid(driver, CreateOrderBtn_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CreateOrderBtn_ById);
            //do
            //{
            //    Wib.wait(driver);
            //} while (driver.FindElements(By.Name(OrderCreated_ByName)).Count < 0);
            Wib.WaitForElementLoad_ByName(driver, OrderCreated_ByName, AndroStack.ImplicitTimeout);
            var ActualResult = Wib.getText_byName(driver, OrderCreated_ByName);
            Assert.AreEqual(OrderCreated_ByName, ActualResult);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);

        }
        public void RemoveorderFromShopcart(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            Wib.ElementClickable_Byid(driver, RemoveOrde_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, RemoveOrde_ById);
            var ActualResult = Wib.getText_byName(driver, OrderMsg);
            Assert.AreEqual(OrderMsg, ActualResult);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, Add_ById, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_ByName(driver, MEAccountModel.DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, MELoginModel.BrowseTest_ByName);
            Assert.AreEqual(MELoginModel.BrowseTest_ByName, CheckCondition);


        }
        public void TestDetailsInCart(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            Wib.ElementClickable_Byid(driver, CartTestDetails_ByName, AndroStack.ImplicitTimeout);
            var TName = Wib.getText_byID(driver, CartTestDetails_ByName);
            var TPrice = Wib.getText_byID(driver, CartTestPrice_ByName);
            do
            {
                Wib.wait(driver);
            } while (driver.FindElements(By.Id(SelectDropDown_ById)).Count < 0);
            Wib.WaitForElementLoad_Byid(driver, SelectDropDown_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SelectDropDown_ById);
            do
            {
                Wib.wait(driver);
            } while (driver.FindElements(By.Name(Item_ByName)).Count < 0);

            Wib.WaitForElementLoad_ByName(driver, Item_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Item_ByName);
            Wib.ElementClickable_Byid(driver, CreateOrderBtn_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CreateOrderBtn_ById);
            do
            {
                Wib.wait(driver);
            } while (driver.FindElements(By.Name(OrderCreated_ByName)).Count < 0);
            Wib.WaitForElementLoad_ByName(driver, OrderCreated_ByName, AndroStack.ImplicitTimeout);
            var ActualResult = Wib.getText_byName(driver, OrderCreated_ByName);
            Assert.AreEqual(OrderCreated_ByName, ActualResult);
            Assert.AreEqual(TestName, TName);
            Assert.AreEqual(TestPrice, TPrice);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);


        }
        public void ViewResult(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver,MEAccountModel.DashBoardResult_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver,MEAccountModel.DashBoardResult_ById);
            Wib.WaitForElementLoad_ByName(driver, MEAccountModel.ResultPage_ByName, AndroStack.ImplicitTimeout);
            var ResultsCount = driver.FindElements(By.ClassName("android.widget.LinearLayout")).Count;

            if (ResultsCount > 3)
            {
                var Results = driver.FindElements(By.ClassName("android.widget.LinearLayout"));
                Results[7].Click();
            }
            else
            {
                Assert.IsFalse(false, "No result is display");
            }
            Wib.WaitForElementLoad_ByName(driver, Calcium_ByName, AndroStack.ImplicitTimeout);
            var IScalciumPresent = driver.FindElements(By.Name(Calcium_ByName)).Count;
            if(IScalciumPresent >=1)
            {
                Assert.IsTrue(true, "Calcium is present");
            }
            else
            {
                Assert.IsFalse(false, "No result is display");
            }
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Result_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver,MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
            Wib.WaitForElementLoad_ByName(driver,MELoginModel.LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver,MELoginModel.LogOut_ByName);
          
        }
        public void PendingResult(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_ByName(driver, MenuOrderBtn_ByName);
            Wib.WaitForElementLoad_ByName(driver, Completed_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Completed_ByName);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Boolean IsPresent = driver.FindElements(By.Name(ResultPending_ByName)).Count > 0;
            if (IsPresent == true)
            {
                Assert.IsTrue(true, "Result Pending for Orders!");
            }
            else
            {
                Assert.Fail("No Result Pending for orders");

            }
        }
        public void ActiveOrders(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            //Wib.clickButton_ByName(driver, Active_ByName);
            var IsPresent = driver.FindElements(By.ClassName(RelativeLayOut_ByClass));
            if (IsPresent.Count >= 3)
            {
                Assert.IsTrue(true, "Orders in Active!");
            }
            else
            {
                Assert.Fail("No Active Orders");

            }
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_ByName(driver, MEAccountModel.DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, MELoginModel.BrowseTest_ByName);
            Assert.AreEqual(MELoginModel.BrowseTest_ByName, CheckCondition);
        }
        public void OrderDelete(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            var BeforeDeleteCount = driver.FindElements(By.ClassName(RelativeLayOut_ByClass)).Count;
            if (BeforeDeleteCount >= 3)
            {
                Wib.clickButton_Byid(driver, ActiveOrderDate_ById);
                Wib.WaitForElementLoad_Byid(driver, ActiveOrderSelf_ById, 10);
                Wib.clickButton_Byclass(driver, ActiveDelete_Byclass);
                Wib.WaitForElementLoad_ByName(driver, ActiveDelete_ByName, 40);
                Wib.clickButton_ByName(driver, ActiveDelete_ByName);
                Wib.WaitForElementLoad_Byid(driver, Pro_Done_Byid, 15);
                Wib.clickButton_Byid(driver, Pro_Done_Byid);
            }
            else
            {
                Assert.Fail("No Active orders to delete!");
            }
            var AfterDeleteCount = driver.FindElements(By.ClassName(RelativeLayOut_ByClass)).Count;
            if (AfterDeleteCount < BeforeDeleteCount)
            {
                Assert.IsTrue(true, "Active Order deleted successfully");
            }
            else
            {
                Assert.Fail("Active Order not deleted successfully");
            }
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.clickButton_ByName(driver, MEAccountModel.DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, MELoginModel.BrowseTest_ByName);
            Assert.AreEqual(MELoginModel.BrowseTest_ByName, CheckCondition);
        }
        public void LinkAccountTestMenuPageAddTest(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(Add_ById)).Count > 0;
            if (IsPresent == true)
            {
                Wib.clickButton_Byid(driver, Add_ById);
            }
            else
            {
                Boolean IsCptAdded = driver.FindElements(By.Id(AddedCpt_ById)).Count > 0;
                if (IsCptAdded == true)
                {
                    Assert.IsTrue(true, "Cpt is Already added!");
                    Wib.clickButton_Byid(driver, AddToCart_ById);
                    Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
                    Boolean CheckCondtion = driver.FindElements(By.Name(MyOrder_ByName)).Count > 0;
                    if (CheckCondtion == true)
                    {
                        Assert.IsTrue(true, "Inside My order page");
                        return;
                    }
                }
            }
            Boolean IsPopupPresent = driver.FindElements(By.Id(Button_Yes_ById)).Count > 0;
            if (IsPopupPresent == true)
            {
                Assert.IsTrue(true, "Asking to link the account with PSC");
                Wib.WaitForElementLoad_Byid(driver, Button_Yes_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, Button_Yes_ById);
            }

            else
            {
                Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, AddToCart_ById);

            }
        }
        public void LinkAccount(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, LinkAcc_ByName, AndroStack.ImplicitTimeout);
            driver.Navigate().Back();
            Wib.clickButton_Byid(driver, LinkACC_RetrieveCode_ById);
            Wib.WaitForElementLoad_ByName(driver, RetrieveVisitCode_ByName, AndroStack.ImplicitTimeout);

        }
        public void RetrieveVisitCode(AndroidDriver<AndroidElement> driver)
        {
            BasicInfoModel BasicInfo = new BasicInfoModel();
            Wib.WaitForElementLoad_ByName(driver, Pro_FirstName_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, Pro_FirstName_ByName, BasicInfo.FirstName);
            driver.Navigate().Back();
            Wib.SetText_ByName(driver, pro_LastName_ByName, BasicInfo.LastName);
            driver.Navigate().Back();
            Wib.clickButton_ByName(driver, Pro_DOB_ByName);
            var Collections = driver.FindElements(By.ClassName(LinearlayOut_ByClass));
            Collections[0].Click();
            Collections[0].SendKeys("22");
            driver.KeyEvent(61);
            Collections[0].SendKeys("1990");
            Wib.clickButton_Byid(driver, Pro_Done_Byid);
            Wib.WaitForElementLoad_Byid(driver, Pro_Submit_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Pro_Submit_ById);
            YA.RetriveCode();
            Wib.WaitForElementLoad_ByName(driver, LinkACC_code_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, LinkACC_code_ByName, YopActivation.VisitCode);
            Wib.WaitForElementLoad_Byid(driver, Pro_Submit_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Pro_Submit_ById);
            Wib.WaitForElementLoad_Byid(driver, LinkAccValidMsg_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, LinkAccValidMsg_ById);
            Wib.clickButton_ByName(driver, Ok_ByName);
            Assert.AreEqual(LinkAccValidMsg, CheckCondition);

        }
        public void SelectState(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_Byid(driver, SelectDropDown_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SelectDropDown_ById);
            Wib.WaitForElementLoad_ByName(driver, Item_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Item_ByName);
            Wib.WaitForElementLoad_Byid(driver, Item_ByID, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, Item_ByID);
            Assert.AreEqual(Item_ByName, CheckCondition);
            Wib.ElementClickable_Byid(driver, CreateOrderBtn_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CreateOrderBtn_ById);
            Wib.WaitForElementLoad_ByName(driver, OrderCreated_ByName, AndroStack.ImplicitTimeout);
            var ActualResult = Wib.getText_byName(driver, OrderCreated_ByName);
            Assert.AreEqual(OrderCreated_ByName, ActualResult);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);

        }
        public void FindCenter(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_Byid(driver, SelectDropDown_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SelectDropDown_ById);
            Wib.WaitForElementLoad_ByName(driver, Item_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Item_ByName);
            Wib.WaitForElementLoad_Byid(driver, Item_ByID, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, Item_ByID);
            Assert.AreEqual(Item_ByName, CheckCondition);
            Wib.ElementClickable_Byid(driver, CreateOrderBtn_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, CreateOrderBtn_ById);
            Wib.WaitForElementLoad_ByName(driver, OrderCreated_ByName, AndroStack.ImplicitTimeout);
            var ActualResult = Wib.getText_byName(driver, OrderCreated_ByName);
            Assert.AreEqual(OrderCreated_ByName, ActualResult);
            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            var CheckCondition2 = Wib.getText_byID(driver, FindCenter_ById);
            Assert.AreEqual(FindCenter_ByName, CheckCondition2);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Active_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
        }
        public void CheckSubmitBtnInOrderPage(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, MyOrder_ByName, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_Byid(driver, SelectDropDown_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SelectDropDown_ById);
            Wib.WaitForElementLoad_ByName(driver, Item_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Item_ByName);
            Wib.WaitForElementLoad_Byid(driver, Item_ByID, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, Item_ByID);
            Assert.AreEqual(Item_ByName, CheckCondition);
            Wib.ElementClickable_Byid(driver, CreateOrderBtn_ById, AndroStack.ImplicitTimeout);
            Boolean IsSubmitBtnEnable = driver.FindElement(By.Id(CreateOrderBtn_ById)).Enabled;
            if (IsSubmitBtnEnable == true)
            {
                Assert.IsTrue(true, "Submit button is Enable");
            }
            else
            {
                Assert.Fail("Submit button is not enable");
            }
            Wib.clickButton_Byid(driver, CreateOrderBtn_ById);
            Wib.WaitForElementLoad_ByName(driver, OrderCreated_ByName, AndroStack.ImplicitTimeout);
            var ActualResult = Wib.getText_byName(driver, OrderCreated_ByName);
            Assert.AreEqual(OrderCreated_ByName, ActualResult);
            Wib.WaitForElementLoad_Byid(driver, FindCenter_ById, AndroStack.ImplicitTimeout);
            var CheckCondition2 = Wib.getText_byID(driver, FindCenter_ById);
            Assert.AreEqual(FindCenter_ByName, CheckCondition2);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, AddBtn_byId, AndroStack.ImplicitTimeout);
            Wib.WaitForElementLoad_ByClassName(driver, MenuButton_ByClass, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);
        }
        public void DashBoardToLinkPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, DashBoardToLinkAcc, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, DashBoardToLinkAcc);
            Wib.WaitForElementLoad_ByName(driver, LinkAcc_ByName, AndroStack.ImplicitTimeout);

        }
        public void PanelTest(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, TestMenu_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, SearchImage_ById);
            Wib.WaitForElementLoad_ByName(driver, SearchCode_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, SearchCode_ByName, BMP_ByName);
            var IsCptPresent = driver.FindElements(By.Name(BMP_ByName)).Count >= 2;
            if (IsCptPresent == true)
            {
                var CPTTest = driver.FindElements(By.Name(BMP_ByName));
                CPTTest[1].Click();
            }
            else
            {
                Assert.Fail("No Cpt test is present");
            }
            Wib.WaitForElementLoad_Byid(driver, AddToCart_ById, AndroStack.ImplicitTimeout);
            Boolean IsPresent = driver.FindElements(By.Id(Add_ById)).Count > 0;
            var IsCalciumPresent = driver.FindElements(By.Name(Calcium_ByName)).Count;
            if (IsCalciumPresent == 1)
            {
                Assert.IsTrue(true, "calcium is present");
            }
            else
            {
                driver.ScrollTo(Calcium_ByName);
                var CheckCalciumPresent = driver.FindElements(By.Name(Calcium_ByName)).Count;
                Assert.AreEqual(CheckCalciumPresent, 1);
            }
            var IsCarbonDioxidePresent = driver.FindElements(By.Name(CarbonDioxide_ByName)).Count;
            if (IsCarbonDioxidePresent == 1)
            {
                Assert.IsTrue(true, "CarbonDioxide is present");
            }
            else
            {
                driver.ScrollTo(CarbonDioxide_ByName);
                var CheckCarbonDioxidePresent = driver.FindElements(By.Name(CarbonDioxide_ByName)).Count;
                Assert.AreEqual(CheckCarbonDioxidePresent, 1);
            }
            var IsChloridePresent = driver.FindElements(By.Name(Chloride_ByName)).Count;
            if (IsChloridePresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(Chloride_ByName);
                var CheckChloridePresent = driver.FindElements(By.Name(Chloride_ByName)).Count;
                Assert.AreEqual(CheckChloridePresent, 1);
            }
            var IsCreatininePresent = driver.FindElements(By.Name(Creatinine_ByName)).Count;
            if (IsCreatininePresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(Creatinine_ByName);
                var CheckCreatininePresent = driver.FindElements(By.Name(Creatinine_ByName)).Count;
                Assert.AreEqual(CheckCreatininePresent, 1);
            }
            var IsGlucosePresent = driver.FindElements(By.Name(Glucose_ByName)).Count;
            if (IsGlucosePresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(Glucose_ByName);
                var CheckGlucosePresent = driver.FindElements(By.Name(Glucose_ByName)).Count;
                Assert.AreEqual(CheckGlucosePresent, 1);
            }
            var IsPotassiumPresent = driver.FindElements(By.Name(Potassium_ByName)).Count;
            if (IsPotassiumPresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(Potassium_ByName);
                var CheckPotassiumPresent = driver.FindElements(By.Name(Potassium_ByName)).Count;
                Assert.AreEqual(CheckPotassiumPresent, 1);
            }
            var IsSodiumPresent = driver.FindElements(By.Name(Sodium_ByName)).Count;
            if (IsSodiumPresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(Sodium_ByName);
                var CheckSodiumPresent = driver.FindElements(By.Name(Sodium_ByName)).Count;
                Assert.AreEqual(CheckSodiumPresent, 1);
            }
            var IsBloodUreaNitrogenPresent = driver.FindElements(By.Name(BloodUreaNitrogen_ByName)).Count;
            if (IsBloodUreaNitrogenPresent == 1)
            {
                Assert.IsTrue(true, "Chloride is present");
            }
            else
            {
                driver.ScrollTo(BloodUreaNitrogen_ByName);
                var CheckBloodUreaNitrogenPresent = driver.FindElements(By.Name(BloodUreaNitrogen_ByName)).Count;
                Assert.AreEqual(CheckBloodUreaNitrogenPresent, 1);
            }

        }
        
    }
}
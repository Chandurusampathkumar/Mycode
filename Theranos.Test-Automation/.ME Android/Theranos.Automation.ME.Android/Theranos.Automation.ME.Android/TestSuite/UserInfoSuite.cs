using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestSuite
{
    [TestClass]
    public class UserInfoSuite : ScreenShot
    {
        LoginValidation LS = new LoginValidation();
        DashBoardUser US = new DashBoardUser();
        DashBoardOrder OS = new DashBoardOrder();
        UploadOrders Upload = new UploadOrders();

        [TestMethod]
        public void UserInfo()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void RemoveOrderFromCart()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.RemoveorderFromShopcart(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void DashBoardToTestMenuPage()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.BrowseTestToTestMenuPage(LaunchActivity.driver);

        }
        [TestMethod]
        public void CheckCartEnable()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.CheckCartEnable(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void CheckAddedTestDetails()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void ActiveOrderDelete()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.OrderDelete(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void CheckPanelTest()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.PanelTest(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void AddTestWithCPT()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.AddParticularCptTest(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);



        }
        [TestMethod]
        public void CheckFastingTestDetails()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckFastingTestDetails(LaunchActivity.driver);         
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void CheckTestDisplayInCart()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.TestDetailsInCart(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void TwoCptTest()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.AddTwoCptTestOrder(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void ProvisionAccount()
        {
            LaunchActivity.launchapp();
            LS.LoginSignUpUserProvisional(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
          var test=OS.AddParticularCptTest(LaunchActivity.driver);
            //OS.TestMenuPage(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.TestMenuProvisionAccout(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void ProvisionAccountUploadOrder()
        {
            LaunchActivity.launchapp();
           var test= LS.LoginSignUpUserProvisional(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            Upload.CaptureImage(LaunchActivity.driver);
            Upload.CheckUploadOrderCreated(LaunchActivity.driver);
            LS.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void LinkAccountFromPSC()
        {
            LaunchActivity.launchapp();
            LS.LoginSignUpUserProvisional(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.TestMenuPage(LaunchActivity.driver);
            OS.LinkAccountTestMenuPageAddTest(LaunchActivity.driver);
            OS.LinkAccount(LaunchActivity.driver);
            OS.RetrieveVisitCode(LaunchActivity.driver);
            OS.LinkAccountTestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);
            LaunchActivity.AfterAll();
        }
        [TestMethod]
        public void CheckStateIsAdded()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.CheckParticularTestDetails(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.SelectState(LaunchActivity.driver);
            LS.DirectLogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void CheckCenterIsDisplayed()
        {
            LaunchActivity.launchapp();
            LS.LoginLinkedAcc(LaunchActivity.driver);
            OS.DashBoardOrders(LaunchActivity.driver);
            OS.OrdersPage(LaunchActivity.driver);
            OS.AddParticularCptTest(LaunchActivity.driver);
            OS.TestMenuPageAddTest(LaunchActivity.driver);
            OS.CheckSubmitBtnInOrderPage(LaunchActivity.driver);
            LS.DirectLogOut(LaunchActivity.driver);

        }
        [TestMethod]
        public void DashBoardToLinkAccount()
        {
            LaunchActivity.launchapp();
            LS.LoginSignUpUserProvisional(LaunchActivity.driver);
            OS.DashBoardToLinkPage(LaunchActivity.driver);
            OS.LinkAccount(LaunchActivity.driver);
            OS.RetrieveVisitCode(LaunchActivity.driver);
            OS.LinkAccountTestMenuPageAddTest(LaunchActivity.driver);
            OS.CreateOrderFromOrders(LaunchActivity.driver);
            OS.ActiveOrders(LaunchActivity.driver);
            LS.LogOut(LaunchActivity.driver);

        }
    }
}
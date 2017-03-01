using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestScenarios
{
    [TestClass]
    public class Accountsceanrios : ScreenShot
    {
        LoginValidation LV = new LoginValidation();
        AccountScripts AS = new AccountScripts();
        DashBoardUser DS = new DashBoardUser();
        Centers Center = new Centers();
        DashBoardOrder order = new DashBoardOrder();

        [TestMethod]
        public void ACC_AccountUserName()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.AccountUserName(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_PasswordUpdate()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.AccountPasswordUpdate(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_AccountEmailUpdate()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.AccountEmailUpdate(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_AccountInvalidEmail()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.AccountInvalidEmail(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_PasscodeValidation()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.PasscodeValidation(LaunchActivity.driver);

        }
        [TestMethod]
        public void ACC_PasscodeReset()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.AccountPasscodeReset(LaunchActivity.driver);

        }

        [TestMethod]
        public void ACC_PasswordCondition()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.CheckPasswordCondition(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_InvalidPasswordCondition()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.CheckInvalidPasswordValidation(LaunchActivity.driver);
            AS.AccountToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void DashBoardtoFindCenter()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            DS.FindCenterFromDashBoard(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void CenterSearchResults() 
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Center.CenterSearchLocation(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void CheckCenterLocations()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Center.CheckNearLocation(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void CheckCenterLocationsIsDislayed()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            Center.SelectedCenterIsDisplayed(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void DashBoardtoOrderPage()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            DS.DashBoardtoOrderPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void DashBoardtoResultPage()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            DS.DashBoardToResultPage(LaunchActivity.driver);
            LV.DirectLogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void DashBoardToViewResult()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            order.ViewResult(LaunchActivity.driver);
            
        }
    }
}
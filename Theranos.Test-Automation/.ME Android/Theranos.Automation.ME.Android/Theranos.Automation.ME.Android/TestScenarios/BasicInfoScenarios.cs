using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScripts;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.TestScripts.BasicInfo;
using Theranos.Automation.ME.Android.Utility;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

namespace Theranos.Automation.ME.Android.TestScenarios
{
    [TestClass]
    public class BasicInfoScenarios : ScreenShot
    {
        BasicInfoScripts BI = new BasicInfoScripts();
        LoginValidation LV = new LoginValidation();
        AccountScripts AS = new AccountScripts();

        [TestMethod]
        public void ACC_BasicInfoScripts()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.BasicinfoUserName(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_BasicInfoDateOfBirth()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.BasicInfoDateOfBirth(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_BasicInfoGender()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.BasicInfoGender(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_LinkedAccountMailingAddress()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.LinkedAccountMailingAddress(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_ProvisionalAccountMailingAddress()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.ProvisionalAccountMailingAddress(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_LinkedAccountBasicInfoPage()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.LinkedAccountBasicInfoPage(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_BasicInfoMobile()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.BasicInfoPage(LaunchActivity.driver);
            BI.BasicInfoMobile(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void ACC_AddEmergencyContactspage()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.EmergencyContactsPage(LaunchActivity.driver);
            BI.AddEmergencyContactspage(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_EditEmergencyContact()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.EmergencyContactsPage(LaunchActivity.driver);
            BI.EditEmergencyContact(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }
        [TestMethod]
        public void ACC_RemoveEmergencyValidation()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.EmergencyContactsPage(LaunchActivity.driver);
            BI.RemoveEmergencyValidation(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void ACC_RemoveEmergencyContact()
        {
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            BI.EmergencyContactsPage(LaunchActivity.driver);
            BI.RemoveEmergencyContact(LaunchActivity.driver);
            BI.BasicInfoToDashBoard(LaunchActivity.driver);
            LV.LogOut(LaunchActivity.driver);
        }

        [TestMethod]
        public void LinkACC_CheckAccountEmail()
        {
            BasicInfoModel Basic = new BasicInfoModel();
            LaunchActivity.launchapp();
            LV.LoginLinkedAcc(LaunchActivity.driver);
            AS.AccountPage(LaunchActivity.driver);
            AS.CheckAccountEmailAddress(LaunchActivity.driver, Basic);
            LV.DirectLogOut(LaunchActivity.driver);
        }
    }

}
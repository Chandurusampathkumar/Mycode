
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White.UIItems;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.Perform;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using System.Collections.Generic;



namespace Theranos.Automation.PSC3.TestCases.Perform
{
    [TestClass]
    public class VerifyIdentificationTests : VerifyIdentification
    {
        
        public void VerifyGuestDetails(BasicInfoModel basicInfo)
        {
            //Update Method
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            var fname = AutoElement.GetTextBoxValueById(appWin, FirstName_ById);
            Assert.AreEqual(basicInfo.FirstName.Trim(), fname, "First name is not edited");

            var lname = AutoElement.GetTextBoxValueById(appWin, LastName_ByID);
            Assert.AreEqual(basicInfo.LastName.Trim(), lname, "Last name is not edited");

            var mname = AutoElement.GetTextBoxValueById(appWin, MiddleName_ByID);
            Assert.AreEqual(basicInfo.MI.Trim(), mname, "Middle name is not edited");
                        
            var dob = AutoElement.GetTextBoxValueById(appWin, DOB_ByID);

            Assert.AreEqual(basicInfo.DOB.Substring(1), dob.Replace("/", ""), "dob not edited");

           // var fname = AutoElement.GetTextBoxValueById(appWin, FirstName_ById);
           // var lname = AutoElement.GetTextBoxValueById(appWin, LastName_ByID);
           // var middleName = AutoElement.GetTextBoxValueById(appWin, MiddleName_ByID);
           //// var suffix = AutoElement.GetTextBoxValueById(appWin, Suffix_ByID);
           // var dob = AutoElement.GetTextBoxValueById(appWin, DOB_ByID);
           // var email = AutoElement.GetTextBoxValueById(appWin, EmailID_ByID);

            //if ((basic.FirstName).Equals(fname) || (basic.LastName).Equals(lname) || (basic.MI).Equals(middleName) || (Convert.ToDateTime(basic.DOB)).Equals(Convert.ToDateTime(dob.Replace('/', '-')))) ;
            //{
            //    Assert.Fail();
            //}
        }

        public void VerifyGuestName(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            var fname = AutoElement.GetTextBoxValueById(appWin, FirstName_ById);
            Assert.AreEqual(basicInfo.FirstName.Trim(), fname, "First name is not edited");

            var lname = AutoElement.GetTextBoxValueById(appWin, LastName_ByID);
            Assert.AreEqual(basicInfo.LastName.Trim(), lname, "Last name is not edited");

            var mname = AutoElement.GetTextBoxValueById(appWin, MiddleName_ByID);
            Assert.AreEqual(basicInfo.MI.Trim(), mname, "Middle name is not edited");
        }

        public void VerifyGuestDOB(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            var dob = AutoElement.GetTextBoxValueById(appWin, DOB_ByID);
            
            Assert.AreEqual(basicInfo.DOB.Substring(1), dob.Replace("/", ""), "dob not edited");
        }

        [TestCategory(AppSettings.Unit), TestMethod()]
        public void MoveToPrepareContainers()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, PrepareContainers.PrepareContainersHost_ByID));
        }

        [TestCategory(AppSettings.Unit), TestMethod()]
        public void ScanPhotoID()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,ScanPhoto_ByID);
            Thread.Sleep(5*WaitTime);
            AutoAction.ClickButtonById(appWin,ClickToScan_ByID);
            AutoAction.ClickButtonById(appWin,Submit_ByID);
            Assert.IsTrue(AutoElement.EnabledById(appWin,Next_ByID));
        }

        [TestCategory(AppSettings.Unit), TestMethod()]
        public void HardwareMalfunctioning()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, ScanPhoto_ByID);
            AutoAction.ClickButtonById(appWin, HardwareMalfunctioning_ByID);
            AutoAction.ClickCheckBoxById(appWin, GuestCheckBox_ByID);
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, Submit_ByID);
            Assert.IsTrue(AutoElement.EnabledById(appWin, Next_ByID));
        }


        public void AddGuestInfo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.SetTextById(appWin, FirstName_ById, basicInfo.FirstName);
            AutoAction.SetTextById(appWin, LastName_ByID, basicInfo.LastName);
            AutoAction.SetTextById(appWin, MiddleName_ByID, basicInfo.MI);
            AutoAction.SetTextValuePatternById(appWin, DOB_ByID, basicInfo.DOB.Substring(1)); 
        }

        public void AddGuestName(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.SetTextById(appWin, FirstName_ById, basicInfo.FirstName);
            AutoAction.SetTextById(appWin, LastName_ByID, basicInfo.LastName);
            AutoAction.SetTextById(appWin, MiddleName_ByID, basicInfo.MI);
        }

        public void AddGuestDOB(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.SetTextById(appWin, DOB_ByID, basicInfo.DOB.Substring(1)); 
        }

        [TestMethod]
        public void MoveToGlucoseDrink()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, GlucoseDrinkHost_ByID));
        }

      
}
}

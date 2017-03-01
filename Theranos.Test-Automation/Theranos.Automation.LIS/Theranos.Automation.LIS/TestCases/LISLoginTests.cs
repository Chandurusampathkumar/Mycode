using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.AutoStack;

//@Author Fangming Lu

namespace Theranos.Automation.LIS.TestCases
{
    [TestClass]
    public class LISLoginTests : LoginModel
    {
        public Application App = null;
        public Window LisAppWin;

        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LaunchApplication()
        {
            CloseApp();
            var path = GetLISAppPath();
            Application.Launch(path);
            do
            {
                try
                {
                    LisAppWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(LISAppWindowName));
                }
                catch (Exception ex)
                {
                    // ignored
                }
            } while (LisAppWin == null);

        }
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void CloseApp()
        {
            foreach (var proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }
        }


        /// <summary>
        /// Verify user is able to login using valid username and password.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LoginValid()
        {
            var LisAppWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(LisAppWin, UserNameById, QaUserNameString);
            AutoAction.SetTextById(LisAppWin, PasswordById, QaPasswordString);
            AutoAction.ClickButtonById(LisAppWin, SubmitById);
            Thread.Sleep(5000);
            if (LisAppWin.Exists(SearchCriteria.ByText(NotGoToPendingListButtonByName)))
            {
                AutoAction.ClickButtonByName(LisAppWin, NotGoToPendingListButtonByName);
            }
            else
            {
                AutoAction.WaitTillVisibleById(LisAppWin.AutomationElement, LogOutButtonById);

                AutoAction.ClickButtonById(LisAppWin, LogOutButtonById);
            } 
//            Thread.Sleep(8000);
//            foreach (Process proc in Process.GetProcessesByName(LISAppWindowName))
//            {
//                proc.Kill();
//            }
        }


        /// <summary>
        /// Verify mandatory warning message is displayed in username field when password is only entered.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void UserNameRequired()
        {

            var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(appWin, PasswordById, QaPasswordString);
            AutoAction.ClickButtonById(appWin, SubmitById);
            var warningText = appWin.GetElement(SearchCriteria.ByText(UserNameWarningTextByName));
            Assert.AreEqual(UserNameWarningTextByName, warningText.Current.Name, "Proper warning message not displayed");
            Thread.Sleep(1000);
            foreach (Process proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }

        }
        /// <summary>
        /// Verify mandatory message is displayed in password field when username is only entered.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void PasswordRequired()
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(appWin, UserNameById, QaUserNameString);
            AutoAction.ClickButtonById(appWin, SubmitById);

            var warningText = appWin.GetElement(SearchCriteria.ByText(UserPasswordWarningTextByName));
            Assert.AreEqual(UserPasswordWarningTextByName, warningText.Current.Name, "Proper warning message not displayed");
            Thread.Sleep(1000);
            foreach (Process proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }

        }

        /// <summary>
        /// Verify user is not able to login using invalid username and invalid password.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LoginInvalidCredentials()
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);

            AutoAction.SetTextById(appWin, UserNameById, InValidUserNameOrPasswordString);
            AutoAction.SetTextById(appWin, PasswordById, InValidUserNameOrPasswordString);
            AutoAction.ClickButtonById(appWin, SubmitById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, OkButtonById);
            Thread.Sleep(1000);
            AutoAction.ClickButtonById(appWin, OkButtonById);
            Thread.Sleep(1000);
            foreach (Process proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }
        }

        /// <summary>
        /// Verify user is not able to login using invalid username and valid password of other user.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LoginInvalidUserName()
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(appWin, UserNameById, InValidUserNameOrPasswordString);
            AutoAction.SetTextById(appWin, PasswordById, QaPasswordString);
            AutoAction.ClickButtonById(appWin, SubmitById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, OkButtonById);
            Thread.Sleep(1000);
            AutoAction.ClickButtonById(appWin, OkButtonById);
            Thread.Sleep(1000);
            foreach (var proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }

            
        }

        /// <summary>
        /// Verify user is not able to login using valid username and invalid password.
        /// </summary>
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LoginInvalidPassword()
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);

            AutoAction.SetTextById(appWin, UserNameById, QaUserNameString);
            AutoAction.SetTextById(appWin, PasswordById, InValidUserNameOrPasswordString);
            AutoAction.ClickButtonById(appWin, SubmitById);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, OkButtonById);
            Thread.Sleep(1000);
            AutoAction.ClickButtonById(appWin, OkButtonById);
            Thread.Sleep(1000);
            foreach (var proc in Process.GetProcessesByName(LISAppWindowName))
            {
                proc.Kill();
            }
        }
        [TestCategory(AppSettings.Unit), TestMethod()]
        public void LoginValidNoLogOut()
        {
            var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(appWin, UserNameById, QaUserNameString);
            AutoAction.SetTextById(appWin, PasswordById, QaPasswordString);
            AutoAction.ClickButtonById(appWin, SubmitById);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
//            AutoAction.WaitTillVisibleById(appWin.AutomationElement, NotGoToPendingListButtonById);
            Thread.Sleep(5000);
            if (appWin.Exists(SearchCriteria.ByText(NotGoToPendingListButtonByName)))
            {
                AutoAction.ClickButtonByName(appWin, NotGoToPendingListButtonByName);
            }
            Thread.Sleep(3000);
            //if (appWin.Exists(SearchCriteria.ByAutomationId(AddModel.ButtonPopUpOK)))
            //{
            //    AutoAction.ClickButtonById(appWin, AddModel.ButtonPopUpOK);
            //}
        }

        [TestCategory(AppSettings.Unit), TestMethod()]
        public void SampleLoginValidNoLogOut()
        {
            var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(LISAppWindowName));
            //var appWin = AutoElement.GetWindowByName(LISAppWindowName);
            AutoAction.SetTextById(appWin, UserNameById, "gsrlis@theranos.com");
            AutoAction.SetTextById(appWin, PasswordById, "Theranos1@");
            AutoAction.ClickButtonById(appWin, SubmitById);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            //AutoAction.WaitTillVisibleById(appWin.AutomationElement, NotGoToPendingListButtonById);
            Thread.Sleep(5000);
            if (appWin.Exists(SearchCriteria.ByText(NotGoToPendingListButtonByName)))
            {
                AutoAction.ClickButtonByName(appWin, NotGoToPendingListButtonByName);
            }
            //"Common.WPFMessageBox.CustomOk.Button"
            Thread.Sleep(3000);
            if (appWin.Exists(SearchCriteria.ByAutomationId("Common.WPFMessageBox.CustomOk.Button")))
            {
                AutoAction.ClickButtonById(appWin, "Common.WPFMessageBox.CustomOk.Button");
            }
        }
    }
}

//these code use for login button cannot valid issue

//  Mouse.Instance.Location = new System.Windows.Point(Mouse.Instance.Location.X + 20, Mouse.Instance.Location.Y);

 //           Mouse.Instance.Click();


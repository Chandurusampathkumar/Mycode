using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using SuperMario2.TestStackMethod;
using System.IO;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Xml.Linq;


namespace Theranos.Automation.PSC3.TestCases
{
    [TestClass]
    public class LoginTests : LoginModel
    {
        //Test Checkin
        public TestStack.White.Application app = null;
        public Window appWin;
        public static string trxfilepath = @ConfigurationManager.AppSettings["configufilepath"];
        //String trxfilepath = @"C:\Users\chanduru.s\AppData\Local\Apps\2.0\";
        XmlDocument doc = new XmlDocument();



        [TestMethod]
        public void LaunchApplication()
        {
            CloseApp();
            var path = GetAppPath();
            Application manager = Application.Launch(path);
            Thread.Sleep(5000);
            var updatee = TestStackWhite.GetwindowByTitle(LoginModel.UpdateAvailablePopup_ByName);
            //var installWindow = TestStackWhite.GetwindowByTitle(LoginModel.InstallationPopup_ByName);
            var isntallWindow = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(InstallationPopup_ByName));

            if (updatee != null)
            {

                var updateW = TestStackWhite.GetwindowByTitle(UpdateAvailablePopup_ByName);
                TestStackWhite.ClickButtonByAutoid(updateW, UpdateOk_ByID);
            }


            else if (isntallWindow != null)
            {
                var install = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(InstallationPopup_ByName));
                TestStackWhite.ClickButtonByAutoid(install, InstallButton_ByID);
            }

            do
            {
                try
                {
                    appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
                }
                catch (Exception ex)
                {
                    string NoteExceptionType = ex.StackTrace;
                }

            } while (appWin == null);

            GetAppCurPath();
            GetAppCurBuildVer();
                        

        }



        //Test
        //[TestMethod]
        //public void PasswordEncryptionValidation()
        //{
        //    appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    var password = appWin.GetElement(SearchCriteria.ByAutomationId(Password_ByID));
        //    if (!password.Current.IsPassword)
        //    {
        //        Assert.Fail("Password is not encrypted");
        //    }
        //}

        /// <summary>
        /// CTC-08" Verify user is able to login using valid username and password.
        /// CTC-91: Log-in-Application should not display true text within the password field.
        /// </summary>
        [TestMethod]
        public void LoginValid()
        {
            string name = "";
            string nameInDashboard = "";
            string inputData = "";
            //Thread.Sleep(1000);
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.ValidCredentials)
                {
                    AutoAction.SetTextById(appWin, UserName_ByID, item.UserName);
                    AutoAction.SetTextValuePatternById(appWin, Password_ByID, item.Password);

                    var username = AutoElement.GetElementById(appWin, UserName_ByID);
                    if (username.Current.IsPassword)
                    {
                        Assert.Fail("UserName is masked");
                    }

                    var password = AutoElement.GetElementById(appWin, Password_ByID);
                    if (!password.Current.IsPassword)           //check whether the encrypted passwored displayed...
                    {
                        Assert.Fail("Password is not masked");
                    }

                    name = item.Name;
                    inputData = "UserName: " + item.UserName + ", Password: " + item.Password + ", Name: " + item.Name;
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, Submit_ByID);
                    break;
                }
            }

            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            AutoAction.WaitTillVisibleById(appWin.AutomationElement, DashboardModel.DashboardHost_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            nameInDashboard = appWin.Get<Label>(SearchCriteria.ByAutomationId(ScreenName_ByID)).Name;
            Assert.AreEqual(name, nameInDashboard, true, "Login not successful for the data, " + inputData);

        }

        [TestMethod]
        public void LoginValidForME()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.SetTextById(appWin, UserName_ByID, "gsrpscsuperbot@theranos.com");
            AutoAction.SetTextValuePatternById(appWin, Password_ByID, "Theranos1@");
            AutoAction.SendTabKey();
            AutoAction.ClickButtonById(appWin, Submit_ByID);

        }

        /// <summary>
        /// Verify user is not able to login using invalid username and invalid password.
        /// </summary>
        [TestMethod]
        public void LoginInvalidCredentials()
        {
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var loadingBox = AutoElement.GetElementById(appWin,Loading_ByID);
            AutomationElement warningText = null;
            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.InvalidCredentials)
                {
                    AutoAction.SetTextById(appWin, UserName_ByID, item.UserName);
                    AutoAction.SetTextById(appWin, Password_ByID, item.Password);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, Submit_ByID);
                    inputData = "UserName: " + item.UserName + ", Password: " + item.Password + ", Name: " + item.Name;
                    break;
                }
            }


            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!loadingBox.Current.IsOffscreen);

            warningText = appWin.GetElement(SearchCriteria.ByAutomationId(PasswordWarning_ByID));

            Assert.IsNotNull(warningText, "Able to login for the following data, " + inputData);

        }

        [TestMethod]
        public void summa()
        {
            Console.WriteLine("sdfasdfsdf");
        }

        /// <summary>
        /// CTC-01: Verify user is not able to login using invalid username and valid password of other user.
        /// </summary>
        [TestMethod]
        public void LoginInvalidUserName()
        {
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var loadingBox = AutoElement.GetElementById(appWin, Loading_ByID);
            AutomationElement warningText = null;
            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.InvalidUserName)
                {
                    AutoAction.SetTextById(appWin, UserName_ByID, item.UserName);
                    AutoAction.SetTextById(appWin, Password_ByID, item.Password);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, Submit_ByID);
                    inputData = "UserName: " + item.UserName + ", Password: " + item.Password + ", Name: " + item.Name;
                    break;
                }
            }
            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!loadingBox.Current.IsOffscreen);

            warningText = appWin.GetElement(SearchCriteria.ByAutomationId(PasswordWarning_ByID));
            Assert.IsNotNull(warningText, "Able to login for the following data, " + inputData);

        }

        /// <summary>
        /// CTC-02: Verify user is not able to login using valid username and invalid password.
        /// </summary>
        [TestMethod]
        public void LoginInvalidPassword()
        {
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var loadingBox = AutoElement.GetElementById(appWin, Loading_ByID);
            AutomationElement warningText = null;
            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.InvalidPassword)
                {
                    AutoAction.SetTextById(appWin, UserName_ByID, item.UserName);
                    AutoAction.SetTextById(appWin, Password_ByID, item.Password);
                    AutoAction.SendTabKey();
                    AutoAction.ClickButtonById(appWin, Submit_ByID);
                    inputData = "UserName: " + item.UserName + ", Password: " + item.Password + ", Name: " + item.Name;
                    break;
                }
            }
            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!loadingBox.Current.IsOffscreen);

            warningText = appWin.GetElement(SearchCriteria.ByAutomationId(PasswordWarning_ByID));
            Assert.IsNotNull(warningText, "Able to login for the following data, " + inputData);

        }

        /// <summary>
        /// CTC-04: Verify mandatory message is displayed in password field and login button is not enabled when username is only entered.
        /// </summary>
        [TestMethod]
        public void PasswordRequired()
        {
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var loadingBox = AutoElement.GetElementById(appWin, Loading_ByID);
            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.ValidCredentials)
                {
                    AutoAction.SetTextById(appWin, UserName_ByID, item.UserName);
                    AutoAction.SendTabKey();
                    inputData = "UserName: " + item.UserName;
                    break;
                }
            }
            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!loadingBox.Current.IsOffscreen);

            var warningText = appWin.Get<Label>(SearchCriteria.ByAutomationId(PasswordWarning_ByID));
            Assert.AreEqual(PasswordRequiredText, warningText.Name, "Proper warning message not displayed for the data, " + inputData);

            var loginButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Submit_ByID));
            Assert.IsFalse(loginButton.Enabled, "Login button is enabled for the data, " + inputData);

        }

        /// <summary>
        ///CTC-03: Verify mandatory warning message is displayed in username field and login button is not enabled when password is only entered.
        /// </summary>
        [TestMethod]
        public void UserNameRequired()
        {
            var records = CSVHelper.GetRecords<LoginModel>(InputFileName);
            string inputData = "";
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var loadingBox = AutoElement.GetElementById(appWin, Loading_ByID);
            foreach (var item in records)
            {
                if (item.CredentialsType == LoginModel.ValidCredentials)
                {

                    AutoAction.SetTextById(appWin, Password_ByID, item.Password);
                    AutoAction.SendTabKey();
                    inputData = "UserName: " + item.UserName + "Password: " + item.Password;
                    break;
                }
            }
            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //} while (!loadingBox.Current.IsOffscreen);

            var warningText = appWin.GetElement(SearchCriteria.ByAutomationId(UserNameWarning_ByID));
            Assert.AreEqual(UserNameRequiredText, warningText.Current.Name, "Proper warning message not displayed for the data, " + inputData);

            var loginButton = appWin.Get<Button>(SearchCriteria.ByAutomationId(Submit_ByID));
            Assert.IsFalse(loginButton.Enabled, "Login button is enabled for the data, " + inputData);

        }


        [TestMethod]
        public void PasswordReset()
        {

        }

        /// <summary>
        /// CTC-09:Verify user is able to log out the application successfully
        /// </summary>
        [TestMethod]
        public void Logout()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Menu_ByID);
            AutoAction.ClickButtonById(appWin, MenuLogOut_ByID);
            appWin.WaitWhileBusy();
            AutoAction.ClickButtonById(appWin, LogOut_ByID);
            AutomationElement userId = null;

            //var loginScreen = AutoElement.GetElementById(appWin,Loading_ByID);
            //var loginScreen = appWin.GetElement(SearchCriteria.ByAutomationId(Loading_ByID));
            AutoAction.WaitForBusyBoxById(appWin.AutomationElement, Loading_ByID);
            //do
            //{
            //    Thread.Sleep(WaitTime);
            //    loginScreen = AutoElement.GetElementById(appWin, Loading_ByID);
            //} while (loginScreen==null);

            userId = AutoElement.GetElementById(appWin, UserName_ByID);
            Assert.IsNotNull(userId, "Logout is not successful");
        }

        [TestMethod]
        public void CloseApp()
        {
            foreach (Process proc in Process.GetProcessesByName(AppName))
            {
                proc.Kill();
            }
        }

        // CTC:05 : Change the language to Spanish
        public void ChangeLanguageToSpanish()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LanguageButton_ByID);
            AutoAction.ClickButtonById(appWin, Spanish_ByID);
            var currentLanguage = appWin.Get<Label>(SearchCriteria.ByAutomationId(TxtLanguage_ByID)).Name;
            Assert.AreEqual(Spanish_ByName, currentLanguage, true, "Unable to change language");
        }

        //CTC-05: Change the language to english
        public void ChangeLanguageToEnglish()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, LanguageButton_ByID);
            AutoAction.ClickButtonById(appWin, English_ByID);
            var currentLanguage = appWin.Get<Label>(SearchCriteria.ByAutomationId(TxtLanguage_ByID)).Name;
            Assert.AreEqual(English_ByName, currentLanguage, true, "Unable to change language");
        }

        /// <summary>
        /// CTC-05: Verify user is able to select the spanish language and the spanish language is displayed throughout the application.
        /// </summary>
        [TestMethod]
        public void ChangeLanguageToSpanishAndLogin()
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            ChangeLanguageToSpanish();
            LoginValid();
            Assert.IsTrue(AutoElement.ExistsByName(appWin, ActionRequired_ByName_ES));
        }

        /// <summary>
        /// CTC-05: Verify user is able to select the english language and the english language is displayed throughout the application.
        /// </summary>
        [TestMethod]
        public void ChangeLanguageToEnglishAndLogin()
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            ChangeLanguageToEnglish();
            LoginValid();
            Assert.IsTrue(AutoElement.ExistsByName(appWin, ActionRequired_ByName_EN));
        }

        /// <summary>
        /// CTC-05: Verify user is able to select the spanish language and the spanish language is retained even after restarting the application.
        /// </summary>
        [TestMethod]
        public void ChangeLanguageToSpanishAndRestart()
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            ChangeLanguageToSpanish();
            LaunchApplication();
            LoginValid();
            appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, ActionRequired_ByName_ES));
        }

        /// <summary>
        /// CTC-05: Verify user is able to select the english language and the english language is retained even after restarting the application.
        /// </summary>
        [TestMethod]
        public void ChangeLanguageToEnglishAndRestart()
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            ChangeLanguageToEnglish();
            LaunchApplication();
            LoginValid();
            appWin = AutoElement.GetWindowByName(AppWindowName);
            Assert.IsTrue(AutoElement.ExistsByName(appWin, ActionRequired_ByName_EN));
        }

        //update app.config AppPath with application's current path
        [TestMethod]
        public void GetAppCurPath()
        {
            //get applications current path
            string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string temp = @"\Programs\Theranos\";
            temp = temp.TrimStart(Path.DirectorySeparatorChar);
            temp = temp.TrimStart(Path.AltDirectorySeparatorChar);
            temp = Path.Combine(StartMenu, temp);

            string[] CurPath = Directory.GetFiles(temp, "PSC*.appref-ms", SearchOption.AllDirectories);
            string fullPath = CurPath[0];
            int AppPathIndex = fullPath.IndexOf(@"\Programs\Theranos\");
            string CurAppPath = fullPath.Substring(AppPathIndex);
            CurAppPath = CurAppPath.TrimStart(Path.DirectorySeparatorChar);
            CurAppPath = CurAppPath.TrimStart(Path.AltDirectorySeparatorChar);


            //get app.config path - in th current app path should be modified
            string UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            temp = @"\Source\Workspaces\Theranos.Test-Automation\PSC3\Theranos.Automation.PSC3\Theranos.Automation.PSC3\app.config";
            temp = temp.TrimStart(Path.DirectorySeparatorChar);
            temp = temp.TrimStart(Path.AltDirectorySeparatorChar);
            string AppConfigPath = Path.Combine(UserHome, temp);

            
            //modify the app.config path

            //string appPath = System.IO.Path.GetDirectoryName((Assembly.GetExecutingAssembly().Location);
            //string configFile = System.IO.Path.Combine(appPath, "app.config");
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = AppConfigPath;
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["AppPath"].Value = CurAppPath;
            config.Save();




        }
        //Get Application Latest Build Version, update the same in PSC3.testssettings--Description field.
        [TestMethod]
        public void GetAppCurBuildVer()
        {
          
            //get the testssetting file path... 
            
            string UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string temp = @"\Source\Workspaces\Theranos.Test-Automation\PSC3\Theranos.Automation.PSC3\Theranos.Automation.PSC3\PSC3.testsettings";
            temp = temp.TrimStart(Path.DirectorySeparatorChar);
            temp = temp.TrimStart(Path.AltDirectorySeparatorChar);
            string fileLoc = Path.Combine(UserHome, temp);

            //focus Description field of testssetting file

            XNamespace xns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
            XDocument doc = XDocument.Load(fileLoc);
            var nodes = doc.Element(xns + "TestSettings");
            var node = nodes.Element(xns + "Description");

            //get the latest build version, update the same in Description field of testssettings file

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var VerInfo = AutoElement.GetElementById(appWin, AppVer);
            string VersionInfo = VerInfo.Current.Name.ToString();
            VersionInfo = VersionInfo.Substring(VersionInfo.IndexOf("Version"));
            node.Value = "Build " + VersionInfo;
            doc.Save(fileLoc);

            
            //XmlDocument doc = new XmlDocument();
            //doc.Load(fileLoc);
            //foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            //    if (node.Name == "Description")
            //    {
            //        node.InnerText = node.InnerText + "jack";
            //    }
            //doc.Save(fileLoc);
        }

        

        [TestMethod]
        public void UpdateConfigufile()
        {
            string filepath = string.Empty;
            try
            {
                //string[] filePaths = Directory.GetFiles(trxfilepath, "*.xml", SearchOption.AllDirectories);
                var filePaths = Directory.GetFiles(trxfilepath.Replace("\\", "\\\\"), "*.*", SearchOption.AllDirectories);
                foreach (var item in filePaths)
                {
                    if (item.Contains("PSC3.UX.QA.exe.config"))
                    {
                        filepath = item;
                        break;
                    }
                }
                doc.Load(filepath);

                XmlNodeList xmlnode = doc.GetElementsByTagName("appSettings");


                foreach (XmlNode xn in xmlnode)
                {

                    if (xn["add"] != null || xn["Key"] != null)
                    {
                        if (xn["add"].Attributes["key"].Value == "ScannerMode")
                        {
                            xn["add"].Attributes["value"].Value = "Test";
                        }
                        if (xn["inlineXML"] != null)
                        {
                            //ContentCount++;
                            // fpfilename = Guid.NewGuid() + ".html";

                        }
                    }
                }


                doc.Save(filepath);
            }
            catch
            {
            }
        }

    }
}

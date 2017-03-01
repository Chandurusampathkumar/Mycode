using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models
{
    public class LoginModel:PSC3Model
    {
        public const string InputFileName = "LoginDataSet.csv";

        public const string Loading_ByID = "LoadingScreen";

        public const string UserName_ByID = "Login.Login.Username.Text";
        public const string Password_ByID = "Login.Login.Password.Password";
        public const string Submit_ByID = "Login.Login.Button";

        public const string DashboardHost_ByClass = "DashboardHost";//TODO: AutomationId Available 
        public const string DashboardHost_ByID = "DashboardScreen";

        public const string ScreenName_ByID = "TxtName";

        public const string UserNameWarning_ByID = "Login.Login.Username.ErrorMessage.Text";
        public const string PasswordWarning_ByID = "Login.Login.Password.ErrorMessage.Text";

        public const string Menu_ByID = "MainMenu.Button";
        public const string LogOut_ByName = "LOG OUT";
        public const string MenuLogOut_ByID="MainMenu.LogOut.Button";
        public const string LogOut_ByID = "LogoutPopup.LogOut.Button";
        public const string CancelLogOut_ByID = "LogoutPopup.Cancel.Button";


        public const string LanguageButton_ByID = "ButtonLanguage";
        public const string TxtLanguage_ByID="TxtLanguage";

        public const string Spanish_ByID = "LanguageMenu.Languages.ListBox.1.LanguageOption.español.Button";
        public const string English_ByID = "LanguageMenu.Languages.ListBox.0.LanguageOption.English.Button";

        public const string English_ByName = "ENGLISH";
        public const string Spanish_ByName = "ESPAÑOL";
               
        public const string Dashboard_ByName_ES = "Salpicadero";
        public const string Dashboard_ByName_EN = "Dashboard";

        public const string ActionRequired_ByName_ES = "ACCIONES REQUERIDAS";
        public const string ActionRequired_ByName_EN = "ACTIONS REQUIRED";

        public const string UserNameRequiredText = "A username is required";
        public const string PasswordRequiredText = "A password is required";

        public const string UpdateAvailablePopup_ByName = "Update Available";
        public const string UpdateOk_ByID = "btnOk";

        public const string InstallationPopup_ByName = "TrustManagerDialog";
        public const string InstallButton_ByID = "btnInstall";

        public const string AppVer = "TbVersion";

        //public const string Priority_ByName = "PRIORIDAD";


        //Credentials Type
        public const string ValidCredentials = "VALID";
        public const string InvalidCredentials = "INVALID";
        public const string InvalidUserName = "INVALID USERNAME";
        public const string InvalidPassword = "INVALID PASSWORD";

        //Properties to read data from CSV
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string CredentialsType { get; set; }
    }
}

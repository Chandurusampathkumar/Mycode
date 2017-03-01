

//@Author Fangming Lu


namespace Theranos.Automation.LIS.Models
{
    public class LoginModel : LISModel
    {
        public const string InputFileName = "LoginDataSet.csv";
        public const string QaUserNameString = "labdirector@theranos.com";
        public const string QaPasswordString = "1701Users#123";
        public const string InValidUserNameOrPasswordString = "23123sadsa";
        public const string UserNameById = "Login.TxtUserName.Text";
        public const string PasswordById = "Login.Password.PasswordBox";
        public const string SubmitById = "Login.Login.Button";
        public const string ForgotPasswordById = "Login.ForgotPassword.Button";
        public const string LoginScreenByClass = "Window";
        public const string UserNameWarningTextByName = "User name required";
        public const string UserPasswordWarningTextByName = "Password Required";
        public const string LoginErrorScreenByName = "Error";
        public const string LoginErrorScreenByClass = "Window";
        public const string PendingCasesAlertScreenByClass = "Window";
        public const string PendingCasesAlertScreenByName = "Alert";
        public const string GoToPendingListButtonByName = "To Pending List";
        public const string GoToPendingListButtonById = "RedButton";
        //public const string NotGoToPendingListButtonById = "GrayButton";
        public const string NotGoToPendingListButtonByName = "Not Now";
        public const string NotGoToPendingListButtonById = "Common.WPFMessageBox.SecondCustomMessage.Button";
        public const string LogOutButtonById = "Logout.Button";
        public const string OkButtonById = "OkButton";
        public const string Yes = "YES";
        public const string No = "NO";
        public const string Confirmation = "Confirmation";
        public const string DashboardByName = "Dashboard";
        public const string TabItemByClass = "TabItem";
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

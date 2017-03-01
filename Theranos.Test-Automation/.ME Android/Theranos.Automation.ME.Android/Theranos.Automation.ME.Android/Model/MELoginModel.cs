
namespace Theranos.Automation.ME.Android.Model
{
    public class MELoginModel 
    {
        public static string PasscodePage_ByName = "This passcode makes it easier for you to log into your app and should be different from the one you've set up for your device.";
        public static string WrongPasscode_ByName = "Passcode did not match.\r\nPlease try again.";
        public static string Code = "1000";
        public static string Title_Id = "com.theranos.me:id/lock_title";

        public static string CsvFile = "NewAccount.csv";
        public static string UserName_ById = "com.theranos.me:id/login_username_edit";
        public static string Password_ById = "com.theranos.me:id/login_password_edit";

        public static string MenuUsername_ById = "com.theranos.me:id/menu_item_text";
        public static string DashBoardResult_ById = "com.theranos.me:id/dashboard_results";
        public static string BrowseTest_ByName = "Browse Tests";

        public static string Valid_ByName = "Valid";
        public static string InValid_ByName = "InValid";
        public static string InValidEmail_ByName = "InValidEmail";
        public static string InValidUserName_ByName = "InValidUserName";
        public static string InValidPassword_ByName = "InValidPassword";
        public static string InValidCredentials_ByName = "InValidCredentials";
        public static string InActivateAccount_ByName = "InActivateAccount";
        public static string BlockedAccount_ByName = "BlockedAccount";
        public static string AgeValid_ByName = "Age";

        public static string LoginButton_ById = "com.theranos.me:id/bottom_button_text";

        public static string CreateAccount_ById = "com.theranos.me:id/login_signup_btn";
        public static string SevenCharPsdByName = "Therano";
        public static string NoUpperr_ByName = "theranos1!";
        public static string NoLowerChar_ByName = "THERANOS1@";
        public static string NoNumeric_ByName = "Theanos!!";

        public static string Email_ByName = "Email";
        public static string Container_Email_ValidMsg_ById = "com.theranos.me:id/sign_up_email";
        public static string Email_errmsg_ById = "com.theranos.me:id/cv_inputbase_error_msg";

        public static string EmailErrMsg = "Must be valid email address!";
        public static string UsernameSpecialChac = "Special characters and spaces not allowed.";

        public static string Password_container_ByID = "com.theranos.me:id/sign_up_password_requirements";
        public static string PassWord_CBZero = "Minimum 8 characters";
        public static string PassWord_CBone = "At least one uppercase and one lowercase letter";
        public static string PassWord_CBtwo = "At least one numeric character"; 


        public static string NewUsername_ByName = "Username";
        public static string Password_ByName = "Password";
        public static string CheckBox_ById = "com.theranos.me:id/age_checkbox";

        public static string UserNameMess_byName = "This username already exists, please try again.";
        public static string Message_byName = "Existing Username";

        public static string ContinueBtn_ById = "com.theranos.me:id/submit_btn";//same id is used for submit alos.

        public static string Email_byID = "com.theranos.me:id/sign_up_email";
        public static string Target_ByName = "Accessing your personal results requires an account. To get started, please enter the info below.";
        public static string Securityone_ById = "com.theranos.me:id/security_question_answer";
        public static string Securitytwo_ById = "com.theranos.me:id/security_question_2_answer";
        public static string Securitythree_ById = "com.theranos.me:id/security_question_3_answer";
        public static string Ans_byName = "Your answer";//commom name 

        public static string Codde_ByXpath = "com.theranos.me:id/indicator_set";

        public static string LogOut_ByName = "Log Out";

        public static string NeedHelp_ById = "com.theranos.me:id/login_forgot_btn";
        public static string NeedHelp_ByName = "Need help logging in?";
        public static string InValidMSg_ByName = "Invalid username or password.";
        public static string InValidMSg_ById = "com.theranos.me:id/tvCrouton";
        public static string VerifyAcc_ByName = "Verify Your Account";
        public static string VerifyAcc_ById = "com.theranos.me:id/tk_title";//use same id for accout block
        public static string VerifyAcc_OkBtn_ByName = "OK";//use same id for account lock
        public static string VerifyAcc_ResendBtn_ByName = "Resend Email";
        public static string AccountBlock_ByName = "Account Locked";

        public static string UnLinkAccount_ByName = "gsrautoy";
        public static string SignUp_ByName = "Sign Up";

        //Yopmail elements
        public static string Yopemail_ByXpath = ".//*[@id='login']";
        public static string yopBtn_ByXpath = ".//*[@id='f']/table/tbody/tr[1]/td[3]/input";
        public static string Activatelink_ByXpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a/span";
        public static string ActivateLinkURL_ByXpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a";
        public static string ActivateCode_ByXpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/span";
        public static string Frame_ByID = "ifmail";
        public static string ActivateSuccessfully_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div[1]";

        public static string About_ByName = "About";
        public static string Company_ById = "com.theranos.me:id/about_company";
        public static string Security_ById = "com.theranos.me:id/about_security";
        public static string Security_ByName = "Security & Data Policy";
        public static string Privacy_ById = "com.theranos.me:id/about_privacy";
        public static string Privacy_ByName = "Privacy Policy";
        public static string TermUse_ById = "com.theranos.me:id/about_tos";
        public static string TermUse_ByName = "Terms of Use";
        public static string ThirdParty_ById = "com.theranos.me:id/about_third_party";
        public static string Contacts_ById = "com.theranos.me:id/about_contact_us";
        public static string InsideThirdParty_ById = "com.theranos.me:id/third_party_notices_header";
        public static string InsideThirdParty2_ById = "com.theranos.me:id/third_party_notices_lab_tests_online";
        public static string InsideThirdParty3_ById = "com.theranos.me:id/third_party_notices_joda_time";
        public static string InsideThirdParty4_ById = "com.theranos.me:id/third_party_notices_apache";


        public string Physician { get; set; }
        public string Provider { get; set; }
        public string Location { get; set; } 
        public string LastName { get; set; }
        public string FastingHour { get; set; }
        public string StandingOrder { get; set; }
        public string ICD { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    } 
}
 
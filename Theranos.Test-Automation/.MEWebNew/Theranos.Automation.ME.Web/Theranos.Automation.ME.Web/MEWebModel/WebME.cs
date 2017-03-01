using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Theranos.Automation.ME.Web
{
    public class WebME
    {
        
  /* Xpath of Elements */

        public static string Ele_SignIn_SignUpLink_ByXpath = "html/body/div/ui-view/nav/div/div/div/ul/li/a[contains(text(),'Sign Up')]";
        public static string Ele_SignIn_SignIn_ByXpath = "html/body/div/ui-view/div/div/form/div/button[contains(text(),'Sign in')]";
        public static string Ele_SignIn_NotActivated_ErrorCard_Xpath = ".//*[@id='error-card']/p[1]";
        public static string Ele_SignIn_InvalidUsername_ErrorCard_Xpath = ".//*[@id='error-card']/p[1]";
        public static string Ele_SignUp_ExistedUser_Error_ByXpPath = "//*[@name='userName']//following::div[1]/div[1]";
        public static string Ele_SignIn_TwoStepAuthField_Xpath = "//*[@name='loginForm2']/div[3]//input";
        public static string Ele_SignIn_TwoStepAuth_Done_Xpath = "//*[@class='signup-btn']/input[@value='Done']";
        public static string Ele_SignUp_PasswordField_ByXpath = "//*[@id='password']//*[@name='password'][1]";
        public static string Ele_SignUp_CreateAccount_ByXpath = "html/body/div[4]/ui-view[3]/div/section[2]/div[2]/ng-form/section/div/button[contains(text(),'Create Account')]";
        public static string Ele_Yop_ClickActivate_Xpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a/span";
        public static string Ele_Yop_ActivationCode_Xpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/span";
        public static string Ele_YopMailbody_PSIcode_Xpath = ".//*[@id='mailmillieu']/div/table/tbody/tr/td/table/tbody/tr/td/span";
        public static string Ele_ActivatedPage_Login_ByXpath = ".//*[@id='MeAppContainer']//a[contains(text(),'Log In')]";
        public static string Ele_ActivatedPage_SuccessMessage_ByXpath = ".//*[@id='MeAppContainer']//div[contains(text(),'Activation Successful')]";
        public static string Ele_CreateProfile_Submit_Xpath = "//*[@class='modal-footer']/button[contains(text(),'Submit')]";
        public static string Ele_CreatingAnOrder_State_Xpath = "//*[@name='state']";
        public static string Ele_CreatingAnOrder_Next_Xpath = "//*[@name='state']/following::button[contains(text(),'Next')]";
        public static string Ele_CreatingAnOrder_CreateOrder_Xpath = "//button[contains(text(),'Back')]//following::button[contains(text(),'Create Order')]";
        public static string Ele_CreatingAnOrder_Back_Xpath = "//button[contains(text(),'Back')]";
        public static string Ele_SettingsAcc_Username_Xpath = "html/body/div[4]/ui-view[3]/section[1]/div/div/div/div/div/div/div[1]/span[2][contains(@class,'ng-binding')]";
        public static string Ele_SettingsAcc_ChangePassword_Xpath = "//*[@name='password']/following::div[1]";


/////////
        public static string Ele_TestMenu_SearchResult_wholetest_xpath =  "html/body/div[4]/ui-view[3]/section[1]/div[2]/div/div/div";
        public static string Ele_SignIn_InvalidCredentials_ErrorCard_Xpath = ".//*[@id='error-card']/p[1]";
       //// public static string Ele_DashBoard_TestMenu_Xpath = ".//*[@id='MeAppContainer']/ui-view/nav/div/div/div/ul/li/a[contains(text(),'Test Menu')]";
        public static string Ele_TestMenu_SearchResult_Xpath = ".//*[@id='MeAppContainer']/ui-view/section/div/div/div/div/div/div[contains(@class,'description col-xs-11 ng-binding')]";
        public static string Ele_TestMenu_TestSearchIcon_Xpath = ".//*[@id='MeAppContainer']/ui-view/section/div/div/div/div[contains(@class,'search-box')]";
        public static string Ele_CreateProfile_NoButton_Xpath = "html/body/div/div/div/div/button[contains(text(),'No')]";
        public static string Ele_CreateProfile_YesButton_Xpath = "html/body/div/div/div/div/button[contains(text(),'Yes')]";
        public static string Ele_NeedHelp_Xpath = "html/body/div/ui-view/div/div/div/button[contains(text(),'Need Help?')]";
        public static string Ele_NeedHelp_RetriveUsername_xpath = "html/body/div/div/div/div/div/a[contains(text(),'Retrieve Username')]";
        public static string Ele_NeedHelp_PageLable_xpath = "html/body/div/div/div/div/div/div/div/h4[contains(text(), 'Need help?')]";
        public static string Ele_DashBoard_Order_Xpath = "html/body/div/ui-view/nav/div/div/div/ul/li/a[text()='Orders']";
        public static string Ele_Order_LinkAcount_Entervisitcode_xpath = "html/body/div/div/div/div/section/form/div/div/div/div/input[contains(@name,'visitCode')]";
        public static string Ele_Order_LinkAcount_Submitbutton_xpath = "html/body/div/div/div/div/section/form/div/button[contains(text(),'Submit')]";
        public static string Ele_TestMenu_AddtoCart_Xpath = ".//*[@id='MeAppContainer']/ui-view/div/div/div/div/div/div/div/div/button[contains(@class,'btn button-cart')]";
        public static string Ele_ProileIcon_Settings_EditPassword_Xpath = "html/body/div[4]/ui-view[3]/section[2]/div/div/div[2]/div/div/div[3]/form/div/div/span";
        public static string Ele_TestMenu_Selectedtest_cartIcon_Xpath = "html/body/div/ui-view/div/div/div/div/div/div/div/div/button[contains(@type,'button')]";
            //"html/body/div/ui-view/div/div/div/div/div/div/div/div/button[contains(@class,'btn button-cart')]";
       //// public static string Ele_Testmenu_SelectedTest_Xpath = "html/body/div/ui-view/div/div/div/div/div/div/div/div/button[contains(@class,'btn button-cart')]";
        public static string Ele_Testmenu_EntertestinSearchbox_Xpath = "html/body/div[4]/ui-view[3]/section[1]/div[1]/div/div/div/div[1]";
        public static string Ele_TestMenu_CreateProfile_Yesbutton_Xpath = "html/body/div/div/div/div/button[contains(text(),'Yes')]";
        public static string Ele_NeedHelp_ResetPassword_Xpath = "html/body/div/div/div/div/div/a[contains(text(),'Reset Password')]";
        public static string Ele_ResetPassword_Usernamefield_xpath = "html/body/div/ui-view/div/div/div/form/div/input[contains(@name,'username')]";
        public static string Ele_ResetPassword_Submit_Xpath = "html/body/div/ui-view/div/div/div/form/input[contains(@value,'Submit')]";
        public static string Ele_Yopmail_ResetPasswordLink_xpath = "html/body/div/div/div/table/tbody/tr/td/table/tbody/tr/td/a/span[contains(text(),'Reset Password')]";

        public static string Element_changePassword_Youranswerfield_Xpath = "html/body/div[4]/ui-view[3]/div/section/div/div[2]/form/div[2]/input[contains(@name,'answer')]";
        public static string Element_changePassword_newpasswordField_Xpath = "html/body/div/ui-view/div/section/div/div/form/th-password-field/div/div/input[contains(@name,'password')]";
        public static string Element_changePassword_ContinueButton_Xpath = "html/body/div/ui-view/div/section/div/div/form/input";
        public static string Element_SignIn_unlinkAccount_Errormessage_Xpath = "html/body/div/div/div/div/section/div/div/div/p[contains(@ng-bind,'message')]";
        public static string Element_Ordernumbers_Count_Xpath = "html/body/div/ui-view/div/section/div/div/div/div/div/p[contains(@class,'hero-number mod-active ng-binding')]";
        public static string Ele_TestMenu_SearchIcon_xpath= ".//*[@id='MeAppContainer']/ui-view/section[1]/div/div/div[contains(@class,'search-bar')]";
        public static string Ele_orders_UploadButton_xpath = "html/body/div/ui-view/div/section/div/div/div/div/th-lab-order-upload/form/input[contains(@class,'file-upload')]";
        public static string Ele_RetriveUsernameMailSent_Notification_xpath = ".//*[@id='MeAppContainer']/ui-view/div/div/div/p[contains(@translate,'RETRIEVE_USERNAME.EMAIL_SENT')]";
        public static string Ele_RetriveUsernameMailSent_submitbutton_xpath = "html/body/div/ui-view/div/div/div/form/input[contains(@type,'submit')]";
        public static string Ele_Emptycartlabel_xpath = "html/body/div/ui-view/section/div/h3";
        public static string Ele_DashBoard_Myorders_Xpath = "html/body/div/ui-view/nav/div/div/div/ul/li/a[contains(text(),'My Order')]";
        public static string Ele_DashBoard_ShoppingCart_Xpath = "html/body/div[4]/ui-view[1]/nav/div/div/div[2]/ul/li[4]/a";
        public static string Ele_Myorders_TestmenuLink_xpath = "html/body/div/ui-view/section/div/h3/a[contains(text(),'test menu.')]";
        public static string Ele_TestMenu_Suggested_Testtype_Xpath = "html/body/div/ui-view/section/div/div/div/div[contains(@class,'test col-xs-12 ng-scope')]";
      //  public static string Ele_DashBoard_Test_xpath = "html/body/div/ui-view/nav/div/div/div/ul/li/a[contains(text(),'Tests')]";
        public static string Ele_SearchTesttype_Textbox_Xpath = "html/body/div/ui-view/section/div/div/div/div/input[contains(@id,'search-input')]";
        public static string Ele_Testdisplayed_Price_xpath = "html/body/div[4]/ui-view[3]/div[1]/div/div[3]/div/div/div[2]/div/div/button/span/span[1]";
        public static string Ele_Testdisplayed_Details_xpath = "html/body/div[4]/ui-view[3]/div[1]/div/div[3]/div/div/div[1]/div";
        public static string Ele_TestMenu_Overview_Xpath = "html/body/div/ui-view/div/div/div/div/div/ul/li[contains(text(),'Overview')]";
        public static string Ele_TestMenu_TheTest_Xpath = "html/body/div/ui-view/div/div/div/div/div/ul/li[contains(text(),'The Test')]";
        public static string Ele_TestMenu_CommonQuestion_Xpath = "html/body/div/ui-view/div/div/div/div/div/ul/li[contains(text(),'Common Questions')]";
        public static string Ele_TestMenu_searchbox_Xpath2 = "html/body/div[4]/ui-view[3]/section[1]/div[1]/div/div/div/div[1]";
        public static string Ele_TestMenu_searchbox_Xpath = "html/body/div[4]/ui-view[3]/section[1]/div[1]/div/div/div";
        public static string Ele_changePassword_newpassword_xpath = "html/body/div[6]/div/div/div/div[2]/form/div/th-password-field/div[1]/md-input-container/input";      
        public static string Ele_changePassword_submitbutton_xpath = "html/body/div[6]/div/div/div/div[2]/form/input";
        public static string Ele_Accountlink_Gendermale_Xpath = "html/body/div/div/div/section/form/div/div/span/select";
        public static string Ele_LoginButton_Xpath = "html/body/div/ui-view/nav/div/div/div/ul/li/a[contains(text(),'Log In')]";
        public static string Ele_Forgetpassword_msg_xpath = "html/body/div/ui-view/div/section/div/div[contains(@class,'messagebox')]";
        public static string Ele_Restlink_Wrongdata_errormsg_xpath= "html/body/div[4]/ui-view[3]/div/section/div/div[1]/p";
        public static string Ele_RetriveUserName_nonActivatedMailId_xpath = "html/body/div[4]/ui-view[3]/div/div/div[1]/div/p";
        public static string Ele_RetriveUserName_ActivatedMailId_xpath = "html/body/div[4]/ui-view[3]/div/div/div[2]/p";
        public static string Ele_RetriveUserName_NonActivatedMailId_xpath = "html/body/div[4]/ui-view[3]/div/div/div[2]/p";
        public static string Ele_Resetpassword_notificationmsg_ForInvaliduser_xpath = "html/body/div[4]/ui-view[3]/div/div/div[1]/div/p";
        public static string Ele_Resetpassword_notificationmsg_Forvaliduser_xpath = "html/body/div[4]/ui-view[3]/div/div/div[2]/p";
        public static string Ele_ResendActivationlink_notificationmsg_Forvaliduser_xpath = "html/body/div[4]/ui-view[3]/div/div/div[2]/p";
        public static string Ele_ResendActivationlink_notificationmsg_ForInvaliduser_xpath = "html/body/div[4]/ui-view[3]/div/div/div[1]/div/p";
        public static string Ele_Changepassword_minEightchar_Xpath = ".//*[@id='MeAppContainer']/ui-view[3]/section[2]/div/div/div[2]/div/div/div[3]/form/div/div[2]/div[1]/ng-transclude/div/div[2]/div[2]/th-password-field/div[2]";
        public static string Ele_Orderpage_ReadyOrderTesting_Xpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[3]/div/div[3]/th-active-order-card[1]/div";
        public static string Ele_Orderpage_transribe_testname_Xpath = "html/body/div[4]/ui-view[3]/div/div[2]/div/div/div[2]/section/div[1]/div/span[2]";
        public static string Ele_Orderpage_transribe_testcartBtn_Xpath = "html/body/div[4]/ui-view[3]/div[1]/div/div[3]/div/div/div[2]/div/div/button";
        public static string Ele_Orderpage_ReadyOrderOPtion_Delete_Xpath = "html/body/div/ui-view/div/div/div/div/div/div/div/div/div/span/ul/li/a[contains(text(),'Delete Order')]";
        public static string Ele_settings_changepassword_newpassword_xpath = "html/body/div/div/div/div/div/form/div/th-password-field/div/md-input-container/input[contains(@name,'password')]";
        public static string Ele_settings_changepassword_editicon_xpath = "//*[@name='password']/following::div[1]";
        public static string Ele_settings_changepassword_minimumcharError_xpath= "html/body/div/div/div/div/div/form/div/th-password-field/div[contains(text(),'Minimum 8 characters')]";
        public static string Ele_resendvisitcode_monthdropdown_xpath =  "html/body/div/div/div/div/section/form/div/th-date-select/div/div/div/div/select[contains(@name,'month')]";
        public static string Ele_resendvisitcode_Daydropdown_xpath = "html/body/div/div/div/div/section/form/div/th-date-select/div/div/div/div/select[contains(@name,'day')]";
        public static string Ele_resendvisitcode_Yeardropdown_xpath = "html/body/div/div/div/div/section/form/div/th-date-select/div/div/div/div/select[contains(@name,'year')]";
        public static string Ele_trustmebrowsercheckbox_xpath = "html/body/div[4]/ui-view[3]/div/div/div/form/div[4]/label/input";
        public static string Ele_errormessage_required_xpath = "html/body/div[4]/ui-view[3]/div/section[2]/div[2]/ng-form/section/div/div[1]/div";
        public static string Ele_Resendvisitpage_Lable_xpath = "html/body/div[6]/div/div/div/div/div/span[2]";
        public static string Ele_Entervisitcode_errormsg_invaliddata_xpath = "html/body/div[6]/div/div/div/section/div/div/div[1]/p";
        public static string Ele_Settingpage_usernamedisplay_xpath = ".//*[@id='MeAppContainer']/ui-view[3]/section[1]/div/div/div/div/div/div/div[1]/span[2]";
    
        public static string Ele_ProvisionalAcc_createProfile_month_xpath = ".//div/select[contains(@name,'month')]";
        public static string Ele_ProvisionalAcc_createProfile_day_xpath = ".//div/select[contains(@name,'day')]";
        public static string Ele_ProvisionalAcc_createProfile_year_xpath = ".//div/select[contains(@name,'year')]";


        /* -------------------------------------------------------------------------------------------------------------------------------- */

  /*Other locators of various Elements */

        public static string Ele_SignUp_Email_ByName = "emailAddress";
        public static string Ele_Signup_UserName_ByName = "userName";
        public static string Ele_Signup_ques1_ByName = "answer1";
        public static string Ele_Signup_ques2_BYName = "answer2";
        public static string Ele_Signup_ques3_ByName = "answer3";
        public static string Ele_Signup_Atleat13_ID = "over13";
        public static string Ele_Yop_MailField_Id = "login";
        public static string Ele_Yop_CheckInbox_Class = "sbut";
        public static string Ele_Yop_ClickOnMail_Class = "1m";
        public static string Ele_Yop_MailBodyFreame_Id = "ifmail";
        public static string Ele_Yop_InBoxFrame_Id = "ifinbox";
        public static string Ele_SignIn_TwoStepAuthField_Name = "authCode";
        public static string Ele_SignIn_UsernameFileld_Name = "username";
        public static string Ele_SignIn_PasswordField_Name = "password";
        public static string Ele_SignIn_Profile_className = "nav-settings";
        public static string Ele_Dashboard_ProfileIcon_Classname = "dropdown-toggle";
        public static string Ele_Dashboard_Settings_Linktext = "Settings";
        public static string Ele_TestMenu_SearchIcon_Classname = "i-search";
        public static string Ele_CreateProfile_FirstName_Name = "firstName";
        public static string Ele_CreateProfile_LastName_Name = "lastName";
        public static string Ele_CreateProfile_Gender_Name = "gender";
        public static string Ele_CreateProfile_DateOfBirth_Name = "dob";
        
        public static string Ele_ShoppingCart_CreateOrder_Classname = "cart-submit";
        public static string Ele_SettingsChangePassword_CurrentPassword_Name = "currentPassword";
        public static string Ele_SettingsChangePassword_NewPassword_Name = "password";
        public static string Ele_SettingsNewpassword_Hiddeneyeicon_xpath = ".//*[@id='icon-eye']";
        public static string Ele_LinkAccount_ClickHere_LinkText = "click here to resend.";
        public static string Ele_Retrive_EmailTextbox_Name= "email";
        public static string Ele_SettingsChangePassword_Editbtn_xpath = "html/body/div/ui-view/section/div/div/div/div/div/div[3]/form/div/div/span[contains(@ng-click,'onSelect()')]";
         public static string Ele_SettingsChangePassword_Savebtn_xpath= ".//*[@id='MeAppContainer']/ui-view/section/div/div/div/div/div/div/form/div/div/div/div/div/input[contains(@value,'Save')]";
        //////////////////////////////
        public static string Ele_TestMenu_TestSearchIcon_Id = "icon-nav-search";
        public static string Ele_TestMenu_TestSearchField_Id = "search-input";
        public static string Ele_Order_LinkAcount_EnterFirstName_Name = "firstName";
        public static string Ele_Order_LinkAcount_EnterLastName_Name = "lastName";
        public static string Ele_Order_LinkAccounte_DateOfBirth_Name = "dob";
        public static string Ele_RetriveUserName_WrongMailId_ID =  "error-card";
        public static string Ele_changePasswordEdit_ClassName = "settings-info-input-edit";
        public static string Ele_changePassword_currentpassword_Name = "currentPassword";
        public static string Ele_NeedHelp_ResendActivation_linktext = "Resend Link";
        public static string Ele_Orderpage_readyorder_options_classname = "card-options-container";
        public static string Ele_DashBoard_Test_linktext = "Tests";
        public static string Ele_signup_createaccount_linktext = "Create Account";
        public static string Ele_Dashboard_Entervisitcode_linktext =  "Enter your Visit Code";
        public static string Ele_Dashboard_Logout_linktext = "Logout";
     /* -------------------------------------------------------------------------------------------------------------------------------- */

 /* Test Data for fields */
        public static string TD_wrong_pscfirstname = "Abcd1234";
        public static string TD_wrong_psclastname = "Abcd1234";
        public static string TD_password_valid = "Abcd1234";
        public static string TD_wrongmailid = "Abcdef123dsgsag@ypomail.com";
        public static string TD_wrong_username = "Abcdef123dsgsagypomailcom";
        public static string TD_commonmailID_twouser = "gsrchban16@yopmail.com";

      //   public static string TD_password_valid2 = "Abcd2345";
      //  public static string TD_password_Lessthen8 = "Abcd123";
       // public static string TD_email_Activated_Linked= "1d1@yopmail.com";
        //public static string TD_email_Activated_Unlinked = "1o1@yopmail.com";
        //public static string TD_answer1 = "answer1";
       // public static string TD_answer2 = "answer2";
        //public static string TD_answer3 = "answer3";
        public static string TD_SignIn_Page_Url = "http://alpha:96/me/login";
        public static string TD_DashBoard_Page_Url = "http://alpha:96/me/dashboard";
        public static string TD_yopmail_Page_Url = "http://www.yopmail.com/";
        public static string TD_Activation_SuccessMessage = "Activation Successful";
       // public static string TD_SignUP_ExistedUsername1 = "1d1";
       // public static string TD_ExistedUserName = "1d1";
        //public static string TD_ExistedUserName2 = "as12as"; 
        //public static string TD_Username_Invalid1 = "as8457$avlm";
        //public static string TD_Username_Locked = "zxy115";
        public static string TD_InvalidUsername_ErrorMessage = "Invalid username or password.";
        public static string TD_SignIn_AccountLockAlert_BeforeFinalAttempt = "You have 1 login attempt left before your account is temporarily disabled";
        public static string TD_SignIn_AccountLocked_OfterFinalAttempt = "Your account has been locked. Contact us at support@theranos.com.";

        ////////////////////////
        public static string TD_invalidAnswer = "answer";
        public static string TD_InvalidPassword = "ABcd123";
        public static string TD_InvalidPassword2 = "ABcd12345";
        public static string TD_Validusername = "GSRAutowebuser1";
        //public static string TD_Testname1 = "Blood Type (ABO/RhD)";
        //public static string TD_ExistedUserName3 = "Lmno1234";
        //public static string TD_ExistedMailid = "lmno";
        ///public static string TD_Existedpassword = "Lmno1234";
       // public static string TD_UnlinkedAccount_Username = "Pqrs1234";
       /// public static string TD_UnlinkedAccount_Password = "Pqrs1234";
       // public static string TD_Testdata_Filepath = @"C:\Users\omkar.krishnamurthy\Desktop\TestDataForWebAutomation.xlsx";
        public static string TD_Testdata_Filepath = @"C:\Testdataforweb\PSCdata.xlsx";
        public static string TD_UploadFilepath = "C:\\Users\\omkar.krishnamurthy\\Desktop\\Tulips.jpg";
        public static string screenshotpath = @"C:\Users\omkar.krishnamurthy\Source\Workspaces\Theranos.Test-Automation\.MEWebNew\Theranos.Automation.ME.Web\Theranos.Automation.ME.Web\bin\Debug\Screenshots\";
       
/* -------------------------------------------------------------------------------------------------------------------------------- */
        //URL for various pages

        public static string TD_URL_NeedHelp_RetriverUsername = "http://alpha:96/me/retrieve-username";


        
/* -------------------------------------------------------------------------------------------------------------------------------- */
       //Test codes ...
        public static string TD_Testcode1 = "ALT1";
        public static string TestBY_cptcode = "82040";
        public static string TestBY_name = "Albumin";
        public static string TestBY_marketcode = "ALB1";
        
        // All Types of Test Names
   // public static string TD_Testname1 = "ACTH (Corticotropin)";
    public static string TD_Testname2 = "Adenovirus DNA, Quantitative";
    public static string TD_Testname1 = "Alanine Aminotransferase (ALT/SGPT)";
    public static string TD_Testname4 = "Albumin";
    public static string TD_Testname5 = "Alkaline Phosphatase (ALP)";
    public static string TD_Testname6 = "Alpha-1-Acid Glycoprotein";
    public static string TD_Testname7 = "Alpha-1-Antitrypsin, Total";
    public static string TD_Testname8 = "Alpha-Fetoprotein (AFP), Maternal";
    public static string TD_Testname9 = "Alpha-Fetoprotein (AFP), Oncology";
    public static string TD_Testname10 = "Amphetamines";
    public static string TD_Testname11 = "Amylase";
    public static string TD_Testname12 = "Androstenedione";
    public static string TD_Testname13 = "Anemia Assessment";
    public static string TD_Testname14 = "Anti-Mullerian Hormone (AMH)";
    public static string TD_Testname15 = "Antibody Detection, RBC";
    public static string TD_Testname16 = "Antinuclear Antibodies, Screen (ANA) with reflex to confirmation";
    public static string TD_Testname17 = "Apolipoprotein (apo A-1, apo B)";
    public static string TD_Testname18 = "Apolipoprotein A-1 (apo A-1)";
    public static string TD_Testname19 = "Apolipoprotein B (apo B)";
    public static string TD_Testname21 = "Aspartate Aminotransferase (AST/SGOT)";
    public static string TD_Testname22 = "B Cell, Total Count";
    public static string TD_Testname23 = "Barbiturates, Urine";
    public static string TD_Testname24 = "Basic Metabolic Panel (BMP)";
    public static string TD_Testname25 = "BasicHealth for men";
    public static string TD_Testname26 = "BasicHealth for women";
    public static string TD_Testname27 = "BasicHealth Starter";
    public static string TD_Testname28 = "Benzodiazepines, Urine";
    public static string TD_Testname29 = "Beta-2 Microglobulin";
    public static string TD_Testname30 = "Bilirubin, Direct";
    public static string TD_Testname31 = "Bilirubin, Total";
    public static string TD_Testname32 = "Blood Type (ABO/RhD)";
    public static string TD_Testname33 = "Blood Urea Nitrogen (BUN)";
    public static string TD_Testname34 = "Borrelia Antibody (Lyme Disease)";
    public static string TD_Testname35 = "Brain Natriuretic peptide (BNP)";
    public static string TD_Testname36 = "C-Peptide";
    public static string TD_Testname37 = "C-Reactive Protein (CRP)";
    public static string TD_Testname38 = "C-Reactive Protein, High Sensitivity (hsCRP)";
    public static string TD_Testname39 = "Calcitonin";
    public static string TD_Testname40 = "Calcium";
    public static string TD_Testname41 = "Calcium, Urine";
    public static string TD_Testname42 = "Cancer Antigen 125 (CA 125)";
    public static string TD_Testname43 = "Cancer Antigen 15-3 (CA 15-3)";
    public static string TD_Testname44 = "Cancer Antigen 27.29 (CA 27.29)";
    public static string TD_Testname45 = "Cancer Antigen-GI (CA 19-9)";
    public static string TD_Testname46 = "Carbon Dioxide";
    public static string TD_Testname47 = "Carcinoembryonic Antigen (CEA)";
    public static string TD_Testname48 = "Cardiolipin Antibody (ACA), IgG";
    public static string TD_Testname49 = "CBC (Complete Blood Count) with Auto Differential";
    public static string TD_Testname50 = "CBC (Complete Blood Count) with Auto Differential with reflex to Manual Diff & Smear";
    public static string TD_Testname51 = "CBC (Complete Blood Count), no Diff";
    public static string TD_Testname52 = "CD4 Absolute Count";
    public static string TD_Testname53 = "CD4 Absolute Count with Percent (Lymphocyte Subset Panel 3)";
    public static string TD_Testname54 = "CD4, CD8 Absolute Count with Ratio";
    public static string TD_Testname55 = "CD4, CD8 Absolute Count with Ratio and Percent (Lymphocyte Subset Panel 2)";
    public static string TD_Testname56 = "Celiac Panel";
    public static string TD_Testname57 = "Chlamydia Trachomatis, DNA, Qualitative";
    public static string TD_Testname58 = "Chlamydia/Gonorrhea Panel, DNA, Qualitative";
    public static string TD_Testname59 = "Chlamydia/Gonorrhea/HIV screen with confirmation";
    public static string TD_Testname60 = "Chloride";
    public static string TD_Testname61 = "Chloride, Urine";
    public static string TD_Testname62 = "Cholesterol  ";
    public static string TD_Testname63 = "Cholinesterase";
    public static string TD_Testname64 = "Cocaine";
    public static string TD_Testname65 = "Complement Component 3 antigen";
    public static string TD_Testname66 = "Complement Component 4 antigen";
    public static string TD_Testname67 = "Comprehensive Metabolic Panel (CMP)";
    public static string TD_Testname68 = "Cortisol, Total";
    public static string TD_Testname69 = "Creatine Kinase";
    public static string TD_Testname70 = "Creatinine";
    public static string TD_Testname71 = "Creatinine, Urine";
    public static string TD_Testname72 = "Cyclic Citrullinated Peptide (CCP) Antibody, IgG";
    public static string TD_Testname73 = "Cyclosporine A";
    public static string TD_Testname74 = "Cystatin C";
    public static string TD_Testname75 = "Cytomegalovirus (CMV) Antibody, IgG";
    public static string TD_Testname76 = "Cytomegalovirus (CMV) Antibody, IgG";
    public static string TD_Testname77 = "D-Dimer, Quantitative";
    public static string TD_Testname78 = "Deamidated Gliadin Peptide (DGP) Antibody, IgA";
    public static string TD_Testname79 = "Deamidated Gliadin Peptide (DGP) Antibody, IgG";
    public static string TD_Testname80 = "Dehydroepiandrosterone Sulfate (DHEA-S)";
    public static string TD_Testname81 = "Deoxypyridinoline crosslinks (DPD) (Collagen crosslinks), Urine ";
    public static string TD_Testname82 = "Diabetes Assessment";
    public static string TD_Testname83 = "Double-stranded DNA (dsDNA) Antibody, IgG";
    public static string TD_Testname84 = "Drug Screen Panel";
    public static string TD_Testname85 = "E. coli Shiga-like toxin with reflex to E. coli O157 culture";
    public static string TD_Testname86 = "EBV Early D Antigen (EA-D) IgG";
    public static string TD_Testname87 = "EBV Nuclear Antibody, IgG";
    public static string TD_Testname88 = "EBV Viral Capsid Antigen (VCA) - IgG";
    public static string TD_Testname89 = "EBV Viral Capsid Antigen (VCA) - IgM";
    public static string TD_Testname90 = "Ecstasy (MDMA)";
    public static string TD_Testname91 = "Electrolytes Panel";
    public static string TD_Testname92= "Endomysial Antibody (EMA), IgA";
    public static string TD_Testname93 = "Endomysial Antibody (EMA), IgG";
    public static string TD_Testname94 = "Epstein-Barr (EBV) Antibody Panel ";
    public static string TD_Testname95 = "Erythrocyte Sedimentation Rate (ESR/Sed Rate)";
    public static string TD_Testname96 = "Estradiol";
    public static string TD_Testname97 = "Estriol, unconjugated";
    public static string TD_Testname98= "Estrone";
    public static string TD_Testname99= "Ethanol";
    public static string TD_Testname100 = "Extractable Nuclear Antigen Antibodies (ENA Panel) (RNP, Smith, SSA, SSB, SCO-70,  JO-1)";
    public static string TD_Testname101= "Ferritin  ";
    public static string TD_Testname102 = "Fibrinogen";
    public static string TD_Testname103 = "Folate (Folic acid)";
    public static string TD_Testname104 = "Follicle Stimulating Hormone (FSH)";
    public static string TD_Testname105 = "Gamma-Glutamyltransferase (GGT)";
    public static string TD_Testname106= "Gastrin";
    public static string TD_Testname107 = "Glucose";
    public static string TD_Testname108 = "Glucose Tolerance Test (GTT), 2hr, 75g";
    public static string TD_Testname109= "Glucose Tolerance Test (GTT), 3hr, 100g";
    public static string TD_Testname110 = "Glucose Tolerance Test (GTT), Gestational Screen, 1hr, 50g";
    public static string TD_Testname111 = "Growth Hormone (HGH)";
    public static string TD_Testname112 = "Haptoglobin";
    public static string TD_Testname113 = "hCG - Chorionic Gonadotropin (Maternal), Blood Quantitative";
    public static string TD_Testname114 = "hCG - Chorionic Gonadotropin (Pregnancy Test), Urine Qualitative";
    public static string TD_Testname115 = "Helicobacter Pylori (H. Pylori), IgG";
    public static string TD_Testname116 = "";
    public static string TD_Testname117 = "";
    public static string TD_Testname118 = "";
    public static string TD_Testname119 = "";
    public static string TD_Testname120 = "";
    public static string TD_Testname121 = "";
    public static string TD_Testname122 = "";
    public static string TD_Testname123 = "";
    public static string TD_Testname124 = "";
    public static string TD_Testname125= "";
    public static string TD_Testname126 = "";
    public static string TD_Testname127 = "";
    public static string TD_Testname128 = "";
    public static string TD_Testname129 = "";
    public static string TD_Testname130 = "";
    public static string TD_Testname131= "";
    public static string TD_Testname132= "";
    public static string TD_Testname133= "";
    public static string TD_Testname134 = "";
    public static string TD_Testname135 = "";
    public static string TD_Testname136 = "";
    public static string TD_Testname137 = "";
    public static string TD_Testname138= "";
    public static string TD_Testname139 = "";
    public static string TD_Testname140 = "";
    public static string TD_Testname141 = "";
    public static string TD_Testname142 = "";
    public static string TD_Testname143 = "";
    public static string TD_Testname144 = "";
    public static string TD_Testname145 = "";
    public static string TD_Testname146 = "";
    public static string TD_Testname147 = "";
    public static string TD_Testname148 = "";
    public static string TD_Testname149 = "";
    public static string TD_Testname150 = "";
    public static string TD_Testname151 = "";
    public static string TD_Testname152 = "";
    public static string TD_Testname153 = "";
    public static string TD_Testname154 = "";
    public static string TD_Testname155 = "";
    public static string TD_Testname156 = "";
    public static string TD_Testname157 = "";
    public static string TD_Testname158 = "";
    public static string TD_Testname159 = "";
    public static string TD_Testname160 = "";
    public static string TD_Testname161 = "";
    public static string TD_Testname162 = "";
    public static string TD_Testname163 = "";
    public static string TD_Testname164 = "";
    public static string TD_Testname165 = "";
    public static string TD_Testname166 = "";
    public static string TD_Testname167 = "";
    public static string TD_Testname169 = "";
    public static string TD_Testname170 = "";
    public static string TD_Testname171 = "";
    public static string TD_Testname172 = "";
    public static string TD_Testname173 = "";
/*************************************************************************************************************************************/

        public static string SignUpUserName_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/form[1]/section/md-input-container[2]/input[1]";
        public static string SignUpPassword_ByXpath = ".//*[@id='password']/div[1]/md-input-container/input[1]";

        public static string LoginUserName_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/form/div[1]/md-input-container/input[1]";
        public static string LoginPassword_Byxpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/form/div[2]/md-input-container/input[1]";
             

        public static string Email_ByName = "emailAddress";
        public static string Acc_Username_ByName = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/form[1]/section/md-input-container[2]/input[1]";
        public static string Acc_Passwor_ByName = "password";
                
        //First time login in brower
        public static string VerificationCode_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/div/form/div[3]/md-input-container/input[1]";
        public static string Ver_CheckBoc_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/div/form/div[4]/md-checkbox/div[1]";
        public static string Ver_Done_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/div/form/div[5]/input";

        

       public static string SignUp_ByXpath = ".//*[@id='MeAppContainer']/ui-view[1]/nav/div/div/div[2]/ul/li/a";

       public static string UserName_ByXpath = ".//*[@id='input_16']";
       public static string PassWord_ByXpath = ".//*[@id='input_17']";
       public static string SubmitBtn_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/div/form/div[3]/input";

       public static string AccEmail_ByXpath = ".//*[@id='input_26']";
       public static string AccUserName_ByXpath = ".//*[@id='input_27']";
       public static string AccPassword_ByXpath = ".//*[@id='input_31']";
       public static string AccCheckBox_ByXpath = ".//*[@id='password']/div[6]/md-checkbox/div[1]";

       public static string SecurityAns1_ByXpath = ".//*[@id='input_28']";
       public static string SecurityAns2_ByXpath = ".//*[@id='input_29']";
       public static string SecurityAns3_ByXpath = ".//*[@id='input_30']";
       public static string Security_AccCheckBox_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/section/md-input-container/md-checkbox/div[1]";

       public static string CreateAccout_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/section/button";


       public static string R_LinkResend_ByXpath = "html/body/div[6]/div/div/div/section/form/div[1]/div[1]/a";
       public static string Resend_FirstName_ByXpath = ".//*[@id='input_43']";
       public static string Resend_PassWord_ByXpath = ".//*[@id='input_44']";
       public static string Resend_DOB_ByXpath = ".//*[@id='input_45']";
       public static string Resend_SubmitBtn_ByXpath = "html/body/div[6]/div/div/div/section/form/div[3]/button";
       
                                                    
       public static string ResultBtn_ByXpath = ".//*[@id='MeAppContainer']/ui-view[1]/nav/div/div/div[2]/ul/li[3]/a";
       public static string EnterVisitCode_ByXpath = ".//*[@id='input_38']";
       public static string R_FirstName_ByXpath = ".//*[@id='input_39']";
       public static string R_LastName_ByXpath = ".//*[@id='input_40']";
       public static string R_DOB_ByXpath = ".//*[@id='input_41']";
       public static string R_SubmitBtn_Xpath = "html/body/div[6]/div/div/div/section/form/div[3]/button";
       public static string DownloadResult_ByXpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[3]/div/div/div[2]/div[1]/div/div[2]/div/div";//this is for first result.
       public static string Download_PWD_ByXpath = ".//*[@id='input_52']";
       public static string Download_SUbmitBtn = "html/body/div[6]/div/div/div/div[2]/form/input";

     

       public static string Yopemail_ByXpath = ".//*[@id='login']";
       public static string yopBtn_ByXpath = ".//*[@id='f']/table/tbody/tr[1]/td[3]/input";
       public static string Activatelink_ByXpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a/span";
       public static string ActivateCode_ByXpath = ".//*[@id='mailmillieu']/div[2]/table/tbody/tr[1]/td/table/tbody/tr[2]/td/span";
       public static string Frame_ByID = "ifmail";                             

       //Signup Functional follow 

       public static string ACC_Email_ByXpath = ".//*[@id='input_2']";
       public static string Acc_Username_ByXpath = ".//*[@id='input_3']";
       public static string Acc_Password_ByXpath = ".//*[@id='input_7']";
       public static string Acc_FirstQuestionAnwser_ByXpath = ".//*[@id='input_4']";
       public static string Acc_SecondQuestionAnwser_ByXpath = ".//*[@id='input_5']";
       public static string Acc_ThirdQuestionAnwser_ByXpath = ".//*[@id='input_6']";
       public static string Acc_Singup_Checkbox_Xpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/section/md-input-container/md-checkbox/div[1]";
       public static string Acc_CreateAccountSubmit_Xpath = ".//*[@id='MeAppContainer']/ui-view[3]/div/section[1]/div[2]/ng-form/section/button";
    }
}

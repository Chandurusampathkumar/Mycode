using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.EndPoint
{
    public class AccountURNs
    {
        public static string account_ActivationCode = "/Account?activationCode={activationCode}";    // ActivationCode Needs to be parameterised
        public static string login = "/Account/Login";
        public static string webLogin = "/Account/WebLogin";
        public static string webLoginWithPin = "/Account/WebLoginWithPin";
        public static string logout = "/Account/Logout";
        public static string changePassword = "/Account/ChangePassword";
        public static string resetPassword = "/Account/ResetPassword";
        public static string findUserByEmail = "/Account/FindUserByEmail";
        public static string createShellUserAccount = "/Account/CreateShellUserAccount";
        public static string resendProfilePin = "/Account/ResendProfilePin";
        public static string linkUserToARecord = "/Account/LinkUserToARecord";
        public static string sendActivationEmail = "/Account/SendActivationEmail";
        public static string activate_ActivationCode = "/Account/Activate?activationCode={activationCode}";  // ActivationCode Needs to be parameterised
        public static string sendEmailForPasswordReset = "/Account/SendEmailForPasswordReset";
        public static string sendEmailForRetriveUsername = "/Account/SendEmailForRetrieveUserName";
        public static string getSecurityQuestion = "/Account/GetSecurityQuestions";
        public static string getAccountEmailAddress = "/Account/GetAccountEmailAddress";
        public static string setBasicPatientInfo = "/Account/SetBasicPatientInfo";
        public static string SendMessageForContactInfoUpdate = "/Account/SendMessageForContactInfoUpdate";
        public static string ResendMessageForContactInfoUpdate = "/Account/ResendMessageForContactInfoUpdate";
        public static string getSecurityQuestionsAuthenticated = "/Account/GetSecurityQuestionsAuthenticated";
        public static string changeSecurityQuestions = "/Account/ChangeSecurityQuestions";
        public static string VerifycontactinfoUpdate = "/Account/VerifyContactInfoUpdate";
        public static string CancelcontactinfoUpdate = "/Account/CancelContactInfoUpdate";
    }
}

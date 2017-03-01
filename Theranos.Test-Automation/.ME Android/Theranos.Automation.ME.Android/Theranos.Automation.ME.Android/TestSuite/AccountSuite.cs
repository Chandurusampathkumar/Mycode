using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.TestScenarios;

namespace Theranos.Automation.ME.Android.TestSuite
{
    public class AccountSuite : Accountsceanrios
    {

        public void Accounttestsuite()
        {
            ACC_AccountUserName();
            ACC_PasswordUpdate();
            ACC_AccountEmailUpdate();
            ACC_AccountInvalidEmail();
            ACC_PasscodeValidation();

        }
    }
}

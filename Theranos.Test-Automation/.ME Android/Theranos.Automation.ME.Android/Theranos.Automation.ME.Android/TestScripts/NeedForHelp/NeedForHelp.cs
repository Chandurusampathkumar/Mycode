using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts.NeedForHelp
{

    public class NeedForHelp : NeedModel
    {
        ActionLib Wib = new ActionLib();

        /// <summary>
        /// This method to check whether valid message displayed after entering username
        /// </summary>
        /// <param name="driver"></param>
        public void ActivationLink(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResendActivationLink_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResendActivationLink_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterUserName_ByName, NonActiveateUser);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.AreEqual(ActivateLink_ByName, Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);

        }
        /// <summary>
        /// This method for resend activation email with depended method (createAccountPage)
        /// </summary>
        /// <param name="driver"></param>

        public void ResendActivationLink(AndroidDriver<AndroidElement> driver) 
        {

            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResendActivationLink_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResendActivationLink_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterUserName_ByName, ExcelValues.NewUserName);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.IsNotNull(Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);

        }

        public void ResetPasswordValidUser(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResetPassword_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResetPassword_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterUserName_ByName, ValidUserName);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.AreEqual(ValidPasswordMsg_ByName, Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);


        }

        public void ResetPasswordInValidUser(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResetPassword_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResetPassword_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterUserName_ByName, InvalidUserName);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.AreEqual(InValidPasswordMsg_ByName, Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);

        }

        public void RetrieveActiveUserName(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, RetrieveUserName_ByName);
            Wib.WaitForElementLoad_ByName(driver, RetrieveUserName_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterEmailAddress_ByName, ActiveUserEmail_ByName);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.AreEqual(ActiveUserName_ByName, Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);

        }

        public void RetrieveNonActiveUserName(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, NeedHelp_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelpPage_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, RetrieveUserName_ByName);
            Wib.WaitForElementLoad_ByName(driver, RetrieveUserName_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, EnterEmailAddress_ByName, NonActiveUserEmail_ByName);
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, Message_ById, AndroStack.ImplicitTimeout);
            var Checkconditon = Wib.getText_byID(driver, Message_ById);
            Assert.AreEqual(NonActiveUserMsg_ByName, Checkconditon);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);
            Wib.clickButton_Byclass(driver, ImageBtn_ByClass);

        }
    }
}

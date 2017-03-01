using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.LabOrders;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;
using Theranos.Automation.ME.Web.WebTestScripts.NeedHelp;
using Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart;
using Theranos.Automation.ME.Web.WebTestScripts.SignIn;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.WebTestScripts.Settings;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenuAll;
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class Alltestcases : WebActionLib
    {
        DirectOrdering_Testmenu_MultipleOrders_LinkedAccount directorder = new DirectOrdering_Testmenu_MultipleOrders_LinkedAccount();
        UploadLaborder uploadlaborder = new UploadLaborder();
        NeedToHelpPageDisplay nth = new NeedToHelpPageDisplay();
        RetrieveUsername_Page rup = new RetrieveUsername_Page();
        ForgetPassword fp = new ForgetPassword();
        Orders_From_LinkedAccount ofl = new Orders_From_LinkedAccount();
   //     Username_Display und = new Username_Display();
        Username_Unchangable unu = new Username_Unchangable();
        Emptyshoppingcart esc = new Emptyshoppingcart();
        AddRemove_From_TestCartPage arfc = new AddRemove_From_TestCartPage();
        AddingTest_ToCart_TotalTest attc = new AddingTest_ToCart_TotalTest();
        Signup_OrderMenu_LinkAccount_Clickhere clickhere = new Signup_OrderMenu_LinkAccount_Clickhere();
        AccountLinking_Settings_TesteMenu_Addtocart_Resendcode resendcode = new AccountLinking_Settings_TesteMenu_Addtocart_Resendcode();
        SearchSingleTest_DisplayTest displytest = new SearchSingleTest_DisplayTest();
        TestMenu_Scroll_AllTestTypes alltesttypes = new TestMenu_Scroll_AllTestTypes();

        DirectOrdering_TestmenuOrders_Entervicitcode entervisitcode = new DirectOrdering_TestmenuOrders_Entervicitcode();
        DirectOrdering_TestmenuOrders_resendvisitcode resendvisitcode = new DirectOrdering_TestmenuOrders_resendvisitcode();
        DirectOrdering_TestmenuOrders_UnlinkedAccount unlinkacnt = new DirectOrdering_TestmenuOrders_UnlinkedAccount();
        MultipleOrders_ByUploadingOrders uploadorder = new MultipleOrders_ByUploadingOrders();

        AccountLinking_OrdersPage_ResendCode aloprc = new AccountLinking_OrdersPage_ResendCode();
        Order_From_UnlinkedaAccount ofu = new Order_From_UnlinkedaAccount();
        SignIn_With_Invalid_UserName signin = new SignIn_With_Invalid_UserName();
        Multiple_Login_Attempts_Warning_Message mlawm = new Multiple_Login_Attempts_Warning_Message();
        Multiple_LoginAttempts_Lockout_Message mlalm = new Multiple_LoginAttempts_Lockout_Message();
        Locked_Account la = new Locked_Account();
        WorkingActivationLink wal = new WorkingActivationLink();
        ExistedUsername eu = new ExistedUsername();
        Multiple_Activations ma = new Multiple_Activations();
        SignUp.SignUp su = new SignUp.SignUp();
        LogInWithOutActivaton lwoal = new LogInWithOutActivaton();

        AccountLinking_Afteradding_Testtocart testcart = new AccountLinking_Afteradding_Testtocart();
        Signup_OrderMenu_LinkAccount_InvalidVisitcode visitcode = new Signup_OrderMenu_LinkAccount_InvalidVisitcode();
        Signup_ResultMenu_LinkAccount resltmenu = new Signup_ResultMenu_LinkAccount();
   
        [TestMethod]
        public void alltestcases()
        {

        //    ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

           // directorder.directOrderingTestmenuMultpleOrdersLinkedAccount_Scenario();

            //uploadlaborder.uploadLaborders_scenario();

        //    nth.needtohelppagedisplay_Scenario();

         // rup.needHelpToRetriveUsername_Scenario();

         // run.needHelpToRetriveUsernamenotification_Scenario();

         // retn.retriveUsername_wrongmailidnotification_Scenario();

         ////////  //  fp.forgetpassword_Scenario();

        //   ofl.ordersFromLinkedAccount_scenario();

         // und.usernameDisplay_Scenario();

         // unu.usernameUnchangable_Scenario();

         //   esc.emptyshoppingcart_Scenario();

         // attc.countingCartTest_scenario();

        //  arfc.AddandRemovetest_Scenario();

         // displytest.searchandisplayTest_Scenario();

         // alltesttypes.scrolltestetype_Scenario();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         //   ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");

            resendcode.accountLinking_settings_testeMenu_addtocart_resendcode_Scenario(); //link

            clickhere.signupOrderMenuLinkAccountClickhere_scenario(); //link

            entervisitcode.directOrderingTestmenuOrdersByLinkAccount_Scenario(); //unlink

            resendvisitcode.directOrderingTestmenuByresendvisitcode_Scenario();  //unlink

            unlinkacnt.directordering_testmenuorders_Scenario();  //unlink

            aloprc.accountLinkingOrdersPageResendCode_Scenario();

           

            testcart.account_linking_after_testtocart_Scenario();///un

            visitcode.signupOrderMenuLinkAccountinvalidvisitcode_Scenario();

            resltmenu.signupResultMenuLinkAccount_Scenario();  //unl    

            //take at last
            ofu.orderFromUnlinkedAccount_Scenario();
   
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///    ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "");

           // signin.signInWithInvalidUsername_scenario();

           // mlawm.multipleLoginAttemptsWarningMessage_Scenario();

           // mlalm.MultipleLoginAttemptsLockedOutMessage_Scenario();

           // la.lockedAccount_Scenario();

           // su.signUp_Scenario();

           // wal.activationLink_Scenario();

           // ma.multipleActivations_Scenario();

           //eu.existedUsername_Scenario();

           //lwoal.loginWithoutActivations_scenario();

        }
    }
}

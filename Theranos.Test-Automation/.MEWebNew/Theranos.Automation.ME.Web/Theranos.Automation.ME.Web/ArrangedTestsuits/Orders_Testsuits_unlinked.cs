using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class Orders_Testsuits_unlinked : WebActionLib
    {
        AccountLinking_OrdersPage_ResendCode aloprc = new AccountLinking_OrdersPage_ResendCode();
        Order_From_UnlinkedaAccount ofu = new Order_From_UnlinkedaAccount();
        Orders_From_LinkedAccount ofl = new Orders_From_LinkedAccount();

        [TestMethod]
        public void ordertestsuit_unlinked()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");

            aloprc.accountLinkingOrdersPageResendCode_Scenario();

            ofu.orderFromUnlinkedAccount_Scenario();

        }
    }
}

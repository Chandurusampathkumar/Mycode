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
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class LabOrders_TestSuitsforUnlinked:WebActionLib
    {
        DirectOrdering_TestmenuOrders_Entervicitcode entervisitcode = new DirectOrdering_TestmenuOrders_Entervicitcode();
        DirectOrdering_TestmenuOrders_resendvisitcode resendvisitcode = new DirectOrdering_TestmenuOrders_resendvisitcode();
        DirectOrdering_TestmenuOrders_UnlinkedAccount unlinkacnt = new DirectOrdering_TestmenuOrders_UnlinkedAccount();
     
        [TestMethod]
        public void labordertestsuits_Unlinked()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            entervisitcode.directOrderingTestmenuOrdersByLinkAccount_Scenario(); //unlink
            resendvisitcode.directOrderingTestmenuByresendvisitcode_Scenario();  //unlink
            unlinkacnt.directordering_testmenuorders_Scenario();  //unlink
        }
    }
}


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.LIS.TestCases;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

//@Author Fangming Lu

namespace Theranos.Automation.LIS.Scenarios
{

    [TestClass]
    public class AccessionsScenario : LISModel
    {
        private readonly LISLoginTests _login = new LISLoginTests();
        public readonly AccessionsTests Accessions = new AccessionsTests();
        public readonly AccessionTests1 Acc = new AccessionTests1();

        [TestMethod()]
        public void LisDirectModeTestScenario()
        {
            _login.LaunchApplication();
            _login.LoginValidNoLogOut();
            Accessions.FinishLabOrderInLis(true, AccessionsModel.SampleTestPatientNameString, "test", new DateTime(1991, 02, 10));
        }
        //[TestMethod()]
        //public void LisPhysicianModeTestScenario()
        //{
        //    _login.LaunchApplication();
        //    _login.LoginValidNoLogOut();
        //    Accessions.FinishLabOrderInLis(false, AccessionsModel.SampleTestPatientNameString, "test", new DateTime(1991, 02, 10));
        //}

       

    }
}

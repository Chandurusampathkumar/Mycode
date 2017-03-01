using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMario2
{
    [TestClass]
    public class Scenario
    {
        SM2Login LG = new SM2Login();
        LabOrderProcess LP = new LabOrderProcess();

        [TestMethod]
        public void MEAndSM2()
        {
            //LG.SM2loginpage();
            //LG.LaunchApplicationSM2();
            //LP.L4UseruploadBucket();
            LP.GuestName();           
            LP.LabOrderSubmit();
            LP.SM2LogOut();

            //for (int i = 0; i < 15; i++)
            //{
            //    LP.L4UseruploadBucket();
            //    LP.LabOrderSubmit();
            //}

        }

        [TestMethod]
        public void PSC3AndSM2()
        {
            LG.LaunchApplicationSM2();
            //LG.SM2loginpage();
            //LP.L4ScanBucket();
            LP.GuestName();
            LP.LabOrderSubmit();
            LP.SM2LogOut();

        }

        [TestMethod]
        public void PSC3AndSM2DirectOrder()
        {
            LG.LaunchApplicationSM2();
            LP.GuestName();
            var cpt = LP.DirectLabOrderSubmit();
            LP.SM2LogOut();
        }

    }
}

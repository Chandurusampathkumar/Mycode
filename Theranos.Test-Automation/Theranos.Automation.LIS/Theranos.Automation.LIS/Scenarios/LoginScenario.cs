using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Theranos.Automation.LIS.Models;
using Theranos.Automation.LIS.TestCases;

//@Author Fangming Lu

namespace Theranos.Automation.LIS.Scenarios
{
    [TestClass]
    public class LoginScenario : LISModel
    {
        LISLoginTests login = new LISLoginTests();

        [TestMethod()]
        public void LoginScenario1()
        {
            login.LaunchApplication();
            login.LoginValid();
        }
        [TestMethod()]
        public void LoginScenario2()
        {
            Thread.Sleep(1000);
            login.LaunchApplication();
            login.UserNameRequired();
        }
        [TestMethod()]
        public void LoginScenario3()
        {
            Thread.Sleep(1000);
            login.LaunchApplication();
            login.PasswordRequired();
        }
        [TestMethod()]
        public void LoginScenario4()
        {
            Thread.Sleep(1000);
            login.LaunchApplication();
            login.LoginInvalidCredentials();
        }
        [TestMethod()]
        public void LoginScenario5()
        {
            login.LaunchApplication();
            login.LoginInvalidPassword();
        }
        [TestMethod()]
        public void LoginScenario6()
        {
            Thread.Sleep(1000);
            login.LaunchApplication();
            login.LoginInvalidUserName();
        }
    }
}

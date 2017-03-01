using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario2.TestStackMethod;
using SuperMario2.Model;
using TestStack.White.UIItems.WindowItems;
using SuperMario2.Model.ExcelnPut;
using System.Diagnostics;
using TestStack.White;
using Theranos.Automation.AutoStack;

namespace SuperMario2
{
    [TestClass]
    public class SM2Login : TestStackWhite
    {
        LabOrderProcess LP = new LabOrderProcess();
        public Window appWinSM2;
        public TestStack.White.Application appSM2 = null;
        public static string SM2AppWindowName = "Theranos.SuperMario-QA";

        [TestMethod]
        public void LaunchApplicationSM2()
        {
            CloseApp();
            var smpath = GetAppPathSM2();
            Application manager = Application.Launch(smpath);
            if (ExcelValues.UserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            System.Threading.Thread.Sleep(5000);
            var updatee = GetwindowByTitle(SM2LoginModel.buildUpdate);
            if (updatee != null)
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (GetwindowByTitle(SM2LoginModel.buildUpdate) == null);
                var updateW = GetwindowByTitle(SM2LoginModel.buildUpdate);
                ClickButtonByAutoid(updateW, SM2LoginModel.buildupdateokbtn);
                WaitTillWindowAppear(SM2LoginModel.Lwindow);
                Window Login = GetwindowByTitle(SM2LoginModel.Lwindow);
                Login.WaitWhileBusy();
                SettextByAutoId(Login, ExcelValues.UserName, SM2LoginModel.Ltextbox);
                SettextByAutoId(Login, ExcelValues.Password, SM2LoginModel.Lpassword);
                ClickButtonByAutoid(Login, SM2LoginModel.Lokbutton);
                //LP.CheckUserLogin();
                WaitTillWindowAppear(SM2LoginModel.TheranoMario);

            }
            else
            {
                WaitTillWindowAppear(SM2LoginModel.Lwindow);
                Window Login = GetwindowByTitle(SM2LoginModel.Lwindow);
                //Window Login = GetwindowByTitle("Theranos.SuperMario - QA");
                Login.WaitWhileBusy();
                SettextByAutoId(Login, ExcelValues.UserName, SM2LoginModel.Ltextbox);
                SettextByAutoId(Login, ExcelValues.Password, SM2LoginModel.Lpassword);
                ClickButtonByAutoid(Login, SM2LoginModel.Lokbutton);
                //LP.CheckUserLogin();
                WaitTillWindowAppear(SM2LoginModel.TheranoMario);
            }

        }

        [TestMethod]
        public void CloseApp()
        {
            foreach (Process proc in Process.GetProcessesByName(SM2AppWindowName))
            {
                proc.Kill();
            }
        }

        //[TestMethod]
        //public void SM2loginpage()
        //{
        //    //AppLaunch();
        //    //LaunchApplicationSM2();
        //    if (ExcelValues.UserName == string.Empty)
        //    {
        //        ExcelValues.Excelindexvalue();
        //    }
        //    var updatee = GetwindowByTitle(LoginModel.buildUpdate);
        //    if (updatee != null)
        //    {
        //        do
        //        {
        //            System.Threading.Thread.Sleep(1000);
        //        } while (GetwindowByTitle(LoginModel.buildUpdate) == null);
        //        var updateW = GetwindowByTitle(LoginModel.buildUpdate);
        //        ClickButtonByAutoid(updateW, LoginModel.buildupdateokbtn);
        //        WaitTillWindowAppear(LoginModel.Lwindow);
        //        Window Login = GetwindowByTitle(LoginModel.Lwindow);
        //        Login.WaitWhileBusy();
        //        SettextByAutoId(Login, ExcelValues.UserName, LoginModel.Ltextbox);
        //        SettextByAutoId(Login, ExcelValues.Password, LoginModel.Lpassword);
        //        ClickButtonByAutoid(Login, LoginModel.Lokbutton);
        //        WaitTillWindowAppear(LoginModel.TheranoMario);

        //    }
        //    else
        //    {
        //        WaitTillWindowAppear(LoginModel.Lwindow);
        //        Window Login = GetwindowByTitle(LoginModel.Lwindow);
        //        //Window Login = GetwindowByTitle("Theranos.SuperMario - QA");
        //        Login.WaitWhileBusy();
        //        SettextByAutoId(Login, ExcelValues.UserName, LoginModel.Ltextbox);
        //        SettextByAutoId(Login, ExcelValues.Password, LoginModel.Lpassword);
        //        ClickButtonByAutoid(Login, LoginModel.Lokbutton);
        //        WaitTillWindowAppear(LoginModel.TheranoMario);
        //    }
        //}
    }
}

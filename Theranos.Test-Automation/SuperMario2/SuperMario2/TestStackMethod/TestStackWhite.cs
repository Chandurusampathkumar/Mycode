using SuperMario2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.AutoStack;
using Theranos.Automation.AutoStack.Utility;
using System.Diagnostics;

namespace SuperMario2.TestStackMethod
{
    public class TestStackWhite : AutoStack
    {
        public Window appWinSM2;
        public TestStack.White.Application appSM2 = null;
        public static string SM2AppWindowName = "Theranos.SuperMario-QA";

        public void WaitTillWindowAppear(String Name)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (GetwindowByTitle(Name) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for window Name : " + Name + " Exception is " + sMessage);

            }

        }
        public void WaitTillTBAppearByAutoid(Window mainw, String Automationid)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (mainw.Get<TextBox>(SearchCriteria.ByAutomationId(Automationid)) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for textbox id : " + Automationid + " Exception is " + sMessage);

            }
        }
        public void waitTillTBAppear_ByName(Window mainw, String TextBoxName)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);

                } while (mainw.Get<TextBox>(SearchCriteria.ByText(TextBoxName)) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for textbox name : " + TextBoxName + " Exception is " + sMessage);

            }
        }

        public void WaitTillBtnAppearByAutoid(Window mainw, String Automationid)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (mainw.Get<Button>(SearchCriteria.ByAutomationId(Automationid)) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for button id: " + Automationid + " Exception is " + sMessage);

            }
        }
        public void WaitTillBtnAppearByName(Window mainw, String Text)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } 
                while (mainw.Get<Button>(SearchCriteria.ByText(Text)) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for button text: " + Text + " Exception is " + sMessage);

            }
        }
        public void WaitTillRadioBtnAppearByAutoid(Window mainw, String Automationid)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (mainw.Get<RadioButton>(SearchCriteria.ByAutomationId(Automationid)) == null);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for radiobutton id: " + Automationid + " Exception is " + sMessage);

            }
        }
        public void Loading_Isvisible(Window Mainw)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (Mainw.Get<Label>(SearchCriteria.ByText(LabOrder.Loading_Image_ByName)).Visible);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for App window " + Mainw + " Exception is " + sMessage);

            }

        }


        public void AppLaunch()
        {
            try
            {
                Application.Launch(AppConfig.SM2App);
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for App launch" + " Exception is " + sMessage);

            }


            if (GetwindowByTitle(SM2LoginModel.Application_Install) != null)//Sometime new window appear for asking build update.So implement this logic///
            {
                var appW = GetwindowByTitle(SM2LoginModel.Application_Install);
                ClickButtonByAutoid(appW, SM2LoginModel.Application_Install_Btn);
            }


        }


        
        public static Window GetwindowByTitle(String Windowname)
        {
            try
            {
                return Desktop.Instance.Windows().Find(obj => obj.Title.Contains(Windowname));
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for App window title" + Windowname + " Exception is " + sMessage);

            }


        }

        public static void SettextByAutoId(Window Mainw, String value1, String Automationid)
        {

            try
            {
                var t = (TextBox)Mainw.Get(SearchCriteria.ByAutomationId(Automationid));
                //System.Threading.Thread.Sleep(1000);
                t.SetValue(value1);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for automation id" + Automationid + " Exception is " + sMessage);

            }
        }

        public static void SetTextByName(Window Mainw, String value1, String Nameproy)
        {
            try
            {
                var t = (TextBox)Mainw.Get(SearchCriteria.ByText(Nameproy));

                t.SetValue(value1);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for text box name" + Nameproy + " Exception is " + sMessage);

            }

        }
        public static void Lable_SetTextByName(Window Mainw, String value1, String Nameproy)
        {
            try
            {
                var t = (Label)Mainw.Get(SearchCriteria.ByText(Nameproy));

                t.SetValue(value1);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for label name" + Nameproy + " Exception is " + sMessage);

            }

        }

        public static void ClickButtonByAutoid(Window mainw, String Automationid)
        {
            try
            {
                var b = (Button)mainw.Get(SearchCriteria.ByAutomationId(Automationid));
               
                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for button id" + Automationid + " Exception is " + sMessage);

            }
        }

        public static void ClickButtonByName(Window mainw, String Nameproy)
        {
            try
            {
                var b = (Button)mainw.Get(SearchCriteria.ByText(Nameproy));

                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for button name" + Nameproy + " Exception is " + sMessage);

            }
        }
        public static void ClickImgBtnByAutoid(Window mainw, String Automationid)
        {
            try
            {
                var b = (Image)mainw.Get(SearchCriteria.ByAutomationId(Automationid));

                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for image button id" + Automationid + " Exception is " + sMessage);

            }
        }

        public static void ClickRadioBtnByAutoid(Window mainw, String Automationid)
        {
            try
            {
                var b = (RadioButton)mainw.Get(SearchCriteria.ByAutomationId(Automationid));

                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for radiobutton id" + Automationid + " Exception is " + sMessage);

            }

        }

        public static void ClickRadioBtnByName(Window mainw, String Nameproy)
        {
            try
            {
                var b = (RadioButton)mainw.Get(SearchCriteria.ByText(Nameproy));

                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for radiobutton name" + Nameproy + " Exception is " + sMessage);

            }
        }

        public static void ClickRadioBtnmoremenu(Window mainw, String Nameproy, String autoid)
        {
            try
            {
                var b = (RadioButton)mainw.Get(SearchCriteria.ByAutomationId(autoid).AndByText(Nameproy));

                b.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for radiobutton name or id" + Nameproy + autoid + " Exception is " + sMessage);

            }
        }


        public static void LoadingIsVisble(Window Mainw, String Name)
        {
            try
            {
                do
                {
                    System.Threading.Thread.Sleep(1000);
                } while (Mainw.Get<Label>(SearchCriteria.ByText(Name)).Visible);
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for window or name" + Mainw + Name + " Exception is " + sMessage);

            }
        }

        public static void GetListBox_ByAutoid(Window Mainw, String Automationid)
        {
            try
            {
                Mainw.Get<ListBox>(SearchCriteria.ByAutomationId(Automationid));
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for listbox id" + Automationid + " Exception is " + sMessage);

            }
        }

        public static void ClickListItem_ByClassName(Window Mainw, String ClassName)
        {
            try
            {
                var c = Mainw.Get<ListItem>(SearchCriteria.ByClassName(ClassName));
                c.DoubleClick();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for listbox classname" + ClassName + " Exception is " + sMessage);

            }
        }

        public static void ClickCheckBox_ByAutoid(Window mainw, String Automationid)
        {
            try
            {
                var c = (CheckBox)mainw.Get(SearchCriteria.ByAutomationId(Automationid));

                c.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for checkbox id" + Automationid + " Exception is " + sMessage);

            }

        }
        public static void ClickCheckBox_ByText(Window mainw, String Name)
        {
            try
            {
                var c = (CheckBox)mainw.Get(SearchCriteria.ByAutomationId(Name));

                c.Click();
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Failed While waiting for checkbox name" + Name + " Exception is " + sMessage);

            }

        }

        //public static void popupwindow(Window mainw,String autoid,String autoidd,String rele )
        //{
        //    var pop = (Window)mainw.Get(SearchCriteria.ByAutomationId(autoid));

        //    var popupmenu = (Window)pop.Get(SearchCriteria.ByAutomationId(autoidd));

        //    var releaseBTn = popupmenu.Get(SearchCriteria.ByText(rele));

        //    releaseBTn.Click();



        public void InvokeControl(AutomationElement targetControl)
        {
            InvokePattern invokePattern = null;

            try
            {
                invokePattern =
                    targetControl.GetCurrentPattern(InvokePattern.Pattern)
                    as InvokePattern;
            }
            catch (ElementNotEnabledException)
            {
                // Object is not enabled
                return;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the InvokePattern control pattern
                return;
            }

            invokePattern.Invoke();
        }
        public TogglePattern GetTogglePattern(AutomationElement targetControl)
        {
            TogglePattern togglePattern = null;

            try
            {
                togglePattern =
                    targetControl.GetCurrentPattern(TogglePattern.Pattern)
                    as TogglePattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the TogglePattern control pattern
                return null;
            }

            return togglePattern;
        }
    }
}

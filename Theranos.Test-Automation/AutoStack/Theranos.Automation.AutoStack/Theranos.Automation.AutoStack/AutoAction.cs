using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack.Utility.Input;

namespace Theranos.Automation.AutoStack
{
    public class AutoAction:AutoStack
    {
        public static void ClickButtonById(Window appWin, string buttonId)
        {
            Button button = AutoElement.GetButtonById(appWin, buttonId);

            if (AutoElement.EnabledById(appWin,buttonId))
            {
                if (AutoElement.VisibleById(appWin,buttonId))
                {
                    //UIAutoHelper.performInvokePattern(button.AutomationElement);
                    button.Click();
                }
                else
                {
                    throw new AutomationException(buttonId + " is not visible", Environment.StackTrace);
                }
            }
            else
            {
                throw new ElementNotEnabledException(buttonId + " is not enabled");
            }
        }

        public static void ClickButtonByName(Window appWin, string buttonName)
        {
            Button button = AutoElement.GetButtonByName(appWin, buttonName);

            if (AutoElement.EnabledByName(appWin, buttonName))
            {
                if (AutoElement.VisibleByName(appWin, buttonName))
                {
                    //UIAutoHelper.performInvokePattern(button.AutomationElement);
                    button.Click();
                }
                else
                {
                    throw new AutomationException(buttonName + " is not visible", Environment.StackTrace);
                }
            }
            else
            {
                throw new ElementNotEnabledException(buttonName + " is not enabled");
            }
        }

        public static void ClickCheckBoxById(Window appWin, string checkBoxId)
        {
            CheckBox checkBox = AutoElement.GetCheckBoxById(appWin, checkBoxId);

            if (AutoElement.EnabledById(appWin,checkBoxId))
            {
                if(AutoElement.VisibleById(appWin,checkBoxId))
                {
                    UIAutoHelper.performTogglePattern(checkBox.AutomationElement);
                }
                else
                {
                    throw new AutomationException(checkBoxId + " is not visible", Environment.StackTrace);
                }
            }
            else
            {
                throw new ElementNotAvailableException(checkBoxId + " is not enabled");
            }
        }

        public static void ClickRadioButtonById(Window appWin, string radioButtonId)
        {
            RadioButton radioButton = AutoElement.GetRadioButtonById(appWin, radioButtonId);

            if(AutoElement.EnabledById(appWin,radioButtonId))
            {
                if(AutoElement.VisibleById(appWin,radioButtonId))
                {
                    UIAutoHelper.performSelectionItemPattern(radioButton.AutomationElement);
                }
                else
                {
                    throw new AutomationException(radioButtonId + " is not visible", Environment.StackTrace);
                }
            }
             else
            {
                throw new ElementNotAvailableException(radioButtonId + " is not enabled");
            }
        }




        public static void ClickUIItemById(Window appWin, string uiItemId)
        {
            IUIItem uiItem = AutoElement.GetUIItemById(appWin, uiItemId);

            if (AutoElement.EnabledById(appWin, uiItemId))
            {
                uiItem.Click();
            }
            else
                throw new ElementNotEnabledException(uiItemId + "is not enabled");

        }

        public static void ClickUIItemByName(Window appWin, string uiItemName)
        {
            IUIItem uiItem = AutoElement.GetUIItemByName(appWin, uiItemName);

            if (AutoElement.EnabledByName(appWin, uiItemName))
            {
                uiItem.Click();
            }
            else
                throw new ElementNotEnabledException(uiItemName + "is not enabled");

        }

        public static void SetTextById(Window appWin, string textBoxId, string text)
        {
            TextBox textBox = AutoElement.GetTextBoxById(appWin, textBoxId);
            UIAutoHelper.performTextPattern(textBox.AutomationElement, text);

        }

        public static void SetTextValuePatternById(Window appWin, string textBoxId, string text)
        {
            TextBox textBox = AutoElement.GetTextBoxById(appWin, textBoxId);
            UIAutoHelper.performValuePattern(textBox.AutomationElement, text);

        }

        //public static void ClearTextBox(Window appWin, string textBoxId)
        //{
        //    var textBox = AutoElement.GetTextBoxById(appWin, textBoxId);

        //}

        public static void SendTabKey()
        {
            Keyboard.Press(Key.Tab);
        }

        public static void WaitForBusyBoxByClassName(AutomationElement rootElement, string busyBoxClass)
        {
            AutomationElementCollection busyBoxCollection = AutoElement.GetElementCollectionByClassName(rootElement, busyBoxClass);
            bool wait;
            do
            {
                wait = false;
                foreach (AutomationElement busyBox in busyBoxCollection)
                {
                    if (!busyBox.Current.IsOffscreen)
                    {
                        wait = true;
                        break;
                    }
                }    
            } while (wait);
            
        }

        public static void WaitForBusyBoxById(AutomationElement rootElement, string busyBoxId)
        {
            AutomationElementCollection busyBoxCollection = AutoElement.GetElementCollectionById(rootElement, busyBoxId);
            bool wait;
            do
            {
                wait = false;
                foreach (AutomationElement busyBox in busyBoxCollection)
                {
                    if (!busyBox.Current.IsOffscreen)
                    {
                        wait = true;
                        break;
                    }
                }
            } while (wait);

        }

        public static void WaitTillVisibleById(AutomationElement rootElement, string elementId)
        {
            var element = AutoElement.GetElementById(rootElement, elementId);
            StartTime = DateTime.Now;
            do
            {

            } while (element.Current.IsOffscreen && IsMaxWaitNotElapsed());

        }

        public static void WaitTillVisibleByName(AutomationElement rootElement, string elementName)
        {
            var element = AutoElement.GetElementByName(rootElement, elementName);
            StartTime = DateTime.Now;
            do
            {
            } while (element.Current.IsOffscreen && IsMaxWaitNotElapsed());
        }
    }
}

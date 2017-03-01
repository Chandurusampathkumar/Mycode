using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.AutoStack.Utility.Input;



namespace Theranos.Automation.AutoStack.Utility
{
    public class UIAutoHelper
    {
        public static void performValuePattern(AutomationElement element, string text)
        {
            AutomationPattern[] patterns = element.GetSupportedPatterns();
            object valuePattern = null;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
                ((ValuePattern)valuePattern).SetValue(text);
            else
                throw new InvalidOperationException("Element only supports Value Pattern");

        }

        public static void performTextPattern(AutomationElement element, string text)
        {
            AutomationPattern[] patterns = element.GetSupportedPatterns();
            object textPattern = null;
            if (element.TryGetCurrentPattern(TextPattern.Pattern, out textPattern))
            {
                //((TextPattern)textPattern).
                element.SetFocus();
                SendKeys.SendWait(text);
            }
            else
                throw new InvalidOperationException("Element only supports Text Pattern");

        }



        public static void ScrollIntoView(AutomationElement element)
        {
            AutomationPattern[] patterns = element.GetSupportedPatterns();
            object scrollItemPattern = null;
            if (element.TryGetCurrentPattern(ScrollItemPattern.Pattern, out scrollItemPattern))
            {
                ((ScrollItemPattern)scrollItemPattern).ScrollIntoView();
                
            }
            else
                throw new InvalidOperationException("Element doesn't support scroll pattern");
        }

        public static void performInvokePattern(AutomationElement element)
        {

           // AutomationPattern[] patterns = element.GetSupportedPatterns();
            object invokePattern = null;
            if (element.TryGetCurrentPattern(InvokePattern.Pattern, out invokePattern))
            {
                ((InvokePattern)invokePattern).Invoke();
            }
            else
            {
                throw new InvalidOperationException("Element doesn't support invoke pattern");
            }

        }

        /// <summary> 
        /// Gets the toggle state of an element in the target application. 
        /// </summary> 
        /// <param name="element">The target element.</param>
        public static bool IsElementToggledOn(AutomationElement element)
        {
            if (element == null)
            {
                // TODO: Invalid parameter error handling. 
                return false;
            }

            Object objPattern;
            TogglePattern togPattern;
            if (true == element.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
            {
                togPattern = objPattern as TogglePattern;
                return togPattern.Current.ToggleState == ToggleState.On;
            }
            // TODO: Object doesn't support TogglePattern error handling. 
            return false;
        }

        public static void performTogglePattern(AutomationElement element)
        {
         //   AutomationPattern[] patterns = element.GetSupportedPatterns();
            object togglePattern = null;
            if (element.TryGetCurrentPattern(TogglePattern.Pattern, out togglePattern))
            {
                ((TogglePattern)togglePattern).Toggle();
            }
            else
            {
                throw new InvalidOperationException("Element doesn't support toggle pattern");
            }
        }

        public static void performSelectionItemPattern(AutomationElement element)
        {
         //   AutomationPattern[] patterns = element.GetSupportedPatterns();
            object selectionItemPattern = null;
            if (element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectionItemPattern))
            {
                ((SelectionItemPattern)selectionItemPattern).Select();
                
            }
            else
            {
                throw new InvalidOperationException("Element doesn't support SelectionItem pattern");
            }

        }




        public static void ScrollTillEnd(AutomationElement element, string listItemName)
        {
            AutomationElementCollection listItems = element.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, listItemName));
            int itemsCount;
            do
            {
                itemsCount = listItems.Count;
                ScrollIntoView(listItems[itemsCount - 1]);
                listItems = element.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, listItemName));

            } while (itemsCount != listItems.Count);
        }

        public static void ClickElement(AutomationElement element)
        {
            if (element != null)
            {
                if (element.Current.ControlType.Equals(ControlType.Button))
                {
                    InvokePattern pattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    pattern.Invoke();
                    Thread.Sleep(1000);
                }
                else if (element.Current.ControlType.Equals(ControlType.RadioButton))
                {
                    SelectionItemPattern pattern = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    pattern.Select();
                    Thread.Sleep(1000);
                }
                else
                {
                    InvokePattern pattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    pattern.Invoke();
                    Thread.Sleep(1000);
                }
            }
        }

        //public static void SelectFromDropdown(Window appWin, String editBoxId, AutomationElement spinner, String popUpClass, String listItemName, String itemName)
        //{
        //    //appWin.Focus(DisplayState.Maximized);
        //    //  Actions.SetFocusOnWindow(appWin);
        //    // var textBox = TreeWalker.RawViewWalker.GetFirstChild(editBox);
        //    // SetText(editBox, itemName.Trim().Split(' ')[0]);
        //    //  Actions.SetTextByAutomationID(appWin, editBoxId, itemName.Trim().Split(' ')[0]);
        //    do
        //    {
        //        Thread.Sleep(5 * WaitTime);
        //    } while (!spinner.Current.IsOffscreen);
        //    var itemSelected = false;
        //    var listBox = appWin.GetElement(SearchCriteria.ByClassName(popUpClass));
        //    AutomationElementCollection listItems = listBox.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, listItemName));
        //    int itemsCount;
        //    if (listItems.Count != 0)
        //    {
        //        do
        //        {
        //            itemsCount = listItems.Count;

        //            foreach (AutomationElement item in listItems)
        //            {
        //                var text = TreeWalker.RawViewWalker.GetFirstChild(item);
        //                if (text.Current.Name == itemName)
        //                {
        //                    UIAutoHelper.ScrollIntoView(item);
        //                    UIAutoHelper.performSelectionItemPattern(item);
        //                    Actions.SendTABToWindow(appWin);

        //                    itemSelected = true;
        //                    break;
        //                }
        //            }

        //            if (itemSelected)
        //            {
        //                break;
        //            }

        //            UIAutoHelper.ScrollIntoView(listItems[itemsCount - 1]);
        //            listItems = listBox.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, listItemName));

        //        } while (itemsCount != listItems.Count);
        //    }
        //    else
        //    {
        //        Assert.Fail("No results were displayed for the data, " + listItemName);
        //    }

        //}


        //Method is incorrect. 
        //public static void SendKeyToWindow(Window window, TestStack.White.UIItems.TextBox textBox, String message)
        //{
        //    TestStack.White.InputDevices.AttachedMouse mouse = window.Mouse;
        //    mouse.DoubleClick(textBox.ClickablePoint);
        //    Thread.Sleep(WaitTime);
        //    TestStack.White.InputDevices.AttachedKeyboard keyboard = window.Keyboard;
        //    keyboard.Enter(message);
        //    Thread.Sleep(WaitTime);

        //}



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Theranos.Automation.AutoStack
{
    public class AutoElement:AutoStack
    {
        public static Window GetWindowByName(string WindowName)
        {
            Window appWin = null;
            StartTime = DateTime.Now;
            do
            {
                try
                {
                    appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(WindowName));
                }
                catch (ElementNotAvailableException)
                {
                    
                }
                
            } while (appWin == null && IsMaxWaitNotElapsed());
            if (appWin==null)
            {
                throw new ElementNotAvailableException("Unable to find the window \"" + WindowName + "\"");
            }
            return appWin;
        }

        public static Button GetButtonById(Window appWin, string buttonId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (buttonId == null || buttonId == "")
            {
                throw new AutomationException("Button Id is either null or empty", Environment.StackTrace);
            }
            Button button = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<Button>(SearchCriteria.ByAutomationId(buttonId)))
                {
                    button = appWin.Get<Button>(SearchCriteria.ByAutomationId(buttonId));
                }
            } while (button == null && IsMaxWaitNotElapsed());

            return button;
        }

        public static Button GetButtonByName(Window appWin, string buttonName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (buttonName == null || buttonName == "")
            {
                throw new AutomationException("Button Nmae is either null or empty", Environment.StackTrace);
            }
            Button button = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<Button>(SearchCriteria.ByText(buttonName)))
                {
                    button = appWin.Get<Button>(SearchCriteria.ByText(buttonName));
                }
            } while (button == null && IsMaxWaitNotElapsed());

            return button;
        }

        public static CheckBox GetCheckBoxById(Window appWin, string checkBoxId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (checkBoxId == null || checkBoxId == "")
            {
                throw new AutomationException("Button Id is either null or empty", Environment.StackTrace);
            }
            CheckBox checkBox = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId)))
                {
                    checkBox = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId));
                }
            } while (checkBox == null && IsMaxWaitNotElapsed());

            return checkBox;
        }

        public static RadioButton GetRadioButtonById(Window appWin, string radioButtonId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (radioButtonId == null || radioButtonId == "")
            {
                throw new AutomationException("Button Id is either null or empty", Environment.StackTrace);
            }
            RadioButton radioButton = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId)))
                {
                    radioButton = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId));
                }
            } while (radioButton == null && IsMaxWaitNotElapsed());

            return radioButton;
        }

        public static TextBox GetTextBoxById(Window appWin, string textBoxId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (textBoxId == null || textBoxId == "")
            {
                throw new AutomationException("TextBox Id is either null or empty", Environment.StackTrace);
            }
            TextBox textBox = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<TextBox>(SearchCriteria.ByAutomationId(textBoxId)))
                {
                    textBox = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(textBoxId));
                }
            } while (textBox == null && IsMaxWaitNotElapsed());

            return textBox;

        }

        //public static CheckBox GetCheckBoxById(Window appWin, string checkBoxId)
        //{
        //    if (appWin == null)
        //    {
        //        throw new AutomationException("App window is null", Environment.StackTrace);
        //    }

        //    if (checkBoxId == null || checkBoxId == "")
        //    {
        //        throw new AutomationException("CheckBox Id is either null or empty", Environment.StackTrace);
        //    }
        //    CheckBox checkBox = null;
        //    StartTime = DateTime.Now;
        //    do
        //    {
        //        if (appWin.Exists<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId)))
        //        {
        //            checkBox = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId));
        //        }
        //    } while (checkBox == null && IsMaxWaitNotElapsed());

        //    return checkBox;

        //}

        //public static RadioButton GetRadioButtonById(Window appWin, string radioButtonId)
        //{
        //    if (appWin == null)
        //    {
        //        throw new AutomationException("App window is null", Environment.StackTrace);
        //    }

        //    if (radioButtonId == null || radioButtonId == "")
        //    {
        //        throw new AutomationException("CheckBox Id is either null or empty", Environment.StackTrace);
        //    }
        //    RadioButton radioButton = null;
        //    StartTime = DateTime.Now;
        //    do
        //    {
        //        if (appWin.Exists<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId)))
        //        {
        //            radioButton = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(radioButtonId));
        //        }
        //    } while (radioButton == null && IsMaxWaitNotElapsed());

        //    return radioButton;

        //}


        public static IUIItem GetUIItemById(Window appWin, string uiItemId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (uiItemId == null || uiItemId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            IUIItem uiItem = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(uiItemId)))
                {
                    uiItem = appWin.Get(SearchCriteria.ByAutomationId(uiItemId));
                }
            } while (uiItem == null && IsMaxWaitNotElapsed());

            return uiItem;

        }

        public static IUIItem GetUIItemByName(Window appWin, string uiItemName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (uiItemName == null || uiItemName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            IUIItem uiItem = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByText(uiItemName)))
                {
                    uiItem = appWin.Get(SearchCriteria.ByText(uiItemName));
                }
            } while (uiItem == null && IsMaxWaitNotElapsed());

            return uiItem;

        }

        public static string GetTextBoxValueById(Window appWin, string textBoxId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (textBoxId == null || textBoxId == "")
            {
                throw new AutomationException("TextBox Id is either null or empty", Environment.StackTrace);
            }
            TextBox textBox = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<TextBox>(SearchCriteria.ByAutomationId(textBoxId)))
                {
                    textBox = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(textBoxId));
                }
            } while (textBox == null && IsMaxWaitNotElapsed());

            return textBox.Text;

        }

        public static bool GetCheckBoxStateById(Window appWin, string checkBoxId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (checkBoxId == null || checkBoxId == "")
            {
                throw new AutomationException("TextBox Id is either null or empty", Environment.StackTrace);
            }
            CheckBox checkBox = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId)))
                {
                    checkBox = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(checkBoxId));
                }
            } while (checkBox == null && IsMaxWaitNotElapsed());

            return checkBox.Checked;

        }



        public static AutomationElement GetElementById(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(elementId)))
                {
                    element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static string GetElementNameById(Window appWin, string elementId)
        {
            var element=GetElementById(appWin, elementId);
            if (element!=null)
            {
                return element.Current.Name;
            }
            else
            {
                return null;
            }
            

        }

        public static AutomationElement GetElementByClassName(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Class Name is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByClassName(elementClassName)))
                {
                    element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByName(Window appWin, string elementName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Name is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByText(elementName)))
                {
                    element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementById(Window appWin, string elementId,TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(elementId)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;
                        
                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                    }
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByClassName(Window appWin, string elementClassName, TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByClassName(elementClassName)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                    }
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByName(Window appWin, string elementName, TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByText(elementName)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                    }
                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementById(AutomationElement parent, string elementId)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByClassName(AutomationElement parent, string elementClassName)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Class Name is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByName(AutomationElement parent, string elementName)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Name is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementById(AutomationElement parent, string elementId, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                switch (treescope)
                {
                    case TreeScope.Ancestors:
                        element = parent.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                    case TreeScope.Children:
                        element = parent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                    case TreeScope.Descendants:
                        element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                    case TreeScope.Element:
                        element = parent.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                    case TreeScope.Parent:
                        element = parent.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                    case TreeScope.Subtree:
                        element = parent.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                        break;

                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByClassName(AutomationElement parent, string elementClassName, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                switch (treescope)
                {
                    case TreeScope.Ancestors:
                        element = parent.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Children:
                        element = parent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Descendants:
                        element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Element:
                        element = parent.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Parent:
                        element = parent.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Subtree:
                        element = parent.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                }
            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElement GetElementByName(AutomationElement parent, string elementName, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElement element = null;
            StartTime = DateTime.Now;
            do
            {
                switch (treescope)
                {
                    case TreeScope.Ancestors:
                        element = parent.FindFirst(TreeScope.Ancestors, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                    case TreeScope.Children:
                        element = parent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                    case TreeScope.Descendants:
                        element = parent.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                    case TreeScope.Element:
                        element = parent.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                    case TreeScope.Parent:
                        element = parent.FindFirst(TreeScope.Parent, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                    case TreeScope.Subtree:
                        element = parent.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, elementName));
                        break;

                }

            } while (element == null && IsMaxWaitNotElapsed());

            return element;

        }
        
        public static AutomationElementCollection GetElementCollectionById(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(elementId)))
                {
                    element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByClassName(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Class Name is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByClassName(elementClassName)))
                {
                    element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByName(Window appWin, string elementName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Name is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            //do
            //{
                if (ExistsByName(appWin, elementName))
                {
                    element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                }
            //} while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionById(Window appWin, string elementId, TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(elementId)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                    }
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByClassName(Window appWin, string elementClassName, TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByClassName(elementClassName)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                            break;

                    }
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByName(Window appWin, string elementName, TreeScope treescope)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByText(elementName)))
                {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = appWin.AutomationElement.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Children:
                            element = appWin.AutomationElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Descendants:
                            element = appWin.AutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Element:
                            element = appWin.AutomationElement.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Parent:
                            element = appWin.AutomationElement.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Subtree:
                            element = appWin.AutomationElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                    }
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionById(AutomationElement parent, string elementId)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByClassName(AutomationElement parent, string elementClassName)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Class Name is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));

            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByName(AutomationElement parent, string elementName)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Name is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByNameNoWait(AutomationElement parent, string elementName)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Name is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            
            element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
            

            return element;

        }

        public static AutomationElementCollection GetElementCollectionById(AutomationElement parent, string elementId, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = parent.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Children:
                            element = parent.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Descendants:
                            element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Element:
                            element = parent.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Parent:
                            element = parent.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                        case TreeScope.Subtree:
                            element = parent.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
                            break;

                    }

            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByClassName(AutomationElement parent, string elementClassName, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {
                switch (treescope)
                {
                    case TreeScope.Ancestors:
                        element = parent.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Children:
                        element = parent.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Descendants:
                        element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Element:
                        element = parent.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Parent:
                        element = parent.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                    case TreeScope.Subtree:
                        element = parent.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, elementClassName));
                        break;

                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetElementCollectionByName(AutomationElement parent, string elementName, TreeScope treescope)
        {
            if (parent == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            AutomationElementCollection element = null;
            StartTime = DateTime.Now;
            do
            {

                    switch (treescope)
                    {
                        case TreeScope.Ancestors:
                            element = parent.FindAll(TreeScope.Ancestors, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Children:
                            element = parent.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Descendants:
                            element = parent.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Element:
                            element = parent.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Parent:
                            element = parent.FindAll(TreeScope.Parent, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

                        case TreeScope.Subtree:
                            element = parent.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, elementName));
                            break;

               
                }
            } while (element.Count == 0 && IsMaxWaitNotElapsed());

            return element;

        }

        public static AutomationElementCollection GetAllChilderen(AutomationElement parent,TreeScope treescope)
        {

            if (parent == null)
            {
                throw new AutomationException("Element is null", Environment.StackTrace);
            }
            AutomationElementCollection elementCollection = null;
            StartTime = DateTime.Now;
            do
            {

                switch (treescope)
                {
                    case TreeScope.Ancestors:
                        elementCollection = parent.FindAll(TreeScope.Ancestors, Condition.TrueCondition);
                        break;

                    case TreeScope.Children:
                        elementCollection = parent.FindAll(TreeScope.Children, Condition.TrueCondition);
                        break;

                    case TreeScope.Descendants:
                        elementCollection = parent.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                        break;

                    case TreeScope.Element:
                        elementCollection = parent.FindAll(TreeScope.Element, Condition.TrueCondition);
                        break;

                    case TreeScope.Parent:
                        elementCollection = parent.FindAll(TreeScope.Parent, Condition.TrueCondition);
                        break;

                    case TreeScope.Subtree:
                        elementCollection = parent.FindAll(TreeScope.Subtree, Condition.TrueCondition);
                        break;


                }
            } while (elementCollection == null && IsMaxWaitNotElapsed());

            return elementCollection;
        }

        public static AutomationElementCollection GetAllChilderen(AutomationElement parent)
        {
            if (parent == null)
            {
                throw new AutomationException("Element is null", Environment.StackTrace);
            }
            AutomationElementCollection elementCollection = null;
            StartTime = DateTime.Now;
            do
            {
                elementCollection = parent.FindAll(TreeScope.Children, Condition.TrueCondition);
            } while (elementCollection == null && IsMaxWaitNotElapsed());

            return elementCollection;
        }



        public static bool ExistsById(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }
            bool exists=false;
            StartTime = DateTime.Now;
            do
            {
                if (appWin.Exists(SearchCriteria.ByAutomationId(elementId)))
                {
                    exists=true;
                }
            } while (!exists && IsMaxWaitNotElapsed());

            return exists;
            
        }

        public static bool ExistsByIdNoWait(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            //StartTime = DateTime.Now;
            //do
            //{
            //} while (!appWin.Exists(SearchCriteria.ByAutomationId(elementId)) && IsMaxWaitNotElapsed());

            return appWin.Exists(SearchCriteria.ByAutomationId(elementId));

        }

        public static bool ExistsByClassName(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            StartTime = DateTime.Now;
            do
            {
            } while (!appWin.Exists(SearchCriteria.ByClassName(elementClassName)) && IsMaxWaitNotElapsed());

            return appWin.Exists(SearchCriteria.ByClassName(elementClassName));
            
        }

        public static bool ExistsByClassNameNoWait(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            return appWin.Exists(SearchCriteria.ByClassName(elementClassName));

        }

        public static bool ExistsByName(Window appWin, string elementText)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementText == null || elementText == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            StartTime = DateTime.Now;
            do
            {
            } while (!appWin.Exists(SearchCriteria.ByText(elementText)) && IsMaxWaitNotElapsed());

            return appWin.Exists(SearchCriteria.ByText(elementText));
           
        }

        public static bool EnabledById(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsById(appWin,elementId))
            {
                throw new AutomationException("Unable to find element with ID "+elementId, Environment.StackTrace);
            }

            var element=GetElementById(appWin, elementId);
            StartTime = DateTime.Now;
            do
            {
            } while (!element.Current.IsEnabled && IsMaxWaitNotElapsed());

            return element.Current.IsEnabled;

        }

        public static bool EnabledByClassName(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsByClassName(appWin, elementClassName))
            {
                throw new AutomationException("Unable to find element with ID " + elementClassName, Environment.StackTrace);
            }

            var element = GetElementByClassName(appWin, elementClassName);
            StartTime = DateTime.Now;
            do
            {
            } while (!element.Current.IsEnabled && IsMaxWaitNotElapsed());

            return element.Current.IsEnabled;


        }

        public static bool EnabledByName(Window appWin, string elementName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsByName(appWin, elementName))
            {
                throw new AutomationException("Unable to find element with ID " + elementName, Environment.StackTrace);
            }
            var element=GetElementByName(appWin, elementName);
            StartTime = DateTime.Now;
            do
            {
            } while (!element.Current.IsEnabled && IsMaxWaitNotElapsed());

            return element.Current.IsEnabled;


        }

        public static bool VisibleById(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsById(appWin, elementId))
            {
                throw new AutomationException("Unable to find element with ID " + elementId, Environment.StackTrace);
            }

            var element=GetElementById(appWin, elementId);

            StartTime = DateTime.Now;
            do
            {
            } while (element.Current.IsOffscreen && IsMaxWaitNotElapsed());

            return !element.Current.IsOffscreen;


        }

        public static bool VisibleByIdNoWait(Window appWin, string elementId)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementId == null || elementId == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsByIdNoWait(appWin, elementId))
            {
                throw new AutomationException("Unable to find element with ID " + elementId, Environment.StackTrace);
            }

            return !GetElementById(appWin, elementId).Current.IsOffscreen;

        }

        public static bool VisibleByClassName(Window appWin, string elementClassName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementClassName == null || elementClassName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsByClassName(appWin, elementClassName))
            {
                throw new AutomationException("Unable to find element with ID " + elementClassName, Environment.StackTrace);
            }
            
            var element=GetElementByClassName(appWin, elementClassName);
            StartTime = DateTime.Now;
            do
            {
            } while (element.Current.IsOffscreen && IsMaxWaitNotElapsed());


            return !element.Current.IsOffscreen;
           

        }

        public static bool VisibleByName(Window appWin, string elementName)
        {
            if (appWin == null)
            {
                throw new AutomationException("App window is null", Environment.StackTrace);
            }

            if (elementName == null || elementName == "")
            {
                throw new AutomationException("Element Id is either null or empty", Environment.StackTrace);
            }

            if (!ExistsByName(appWin, elementName))
            {
                throw new AutomationException("Unable to find element with ID " + elementName, Environment.StackTrace);
            }
            var element = GetElementByName(appWin, elementName);

            StartTime = DateTime.Now;
            do
            {
            } while (element.Current.IsOffscreen && IsMaxWaitNotElapsed());


            return !element.Current.IsOffscreen;
            

        }


    }
}

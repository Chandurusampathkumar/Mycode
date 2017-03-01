using System.Windows.Automation;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.AutoStack.Utility.Input;

namespace Theranos.Automation.AutoStack.Utility
{
    public class MouseHelper
    {
        public static void MoveToAndClickByName(Window appWin, string elementName)
        {
            Condition conditions = new AndCondition(
                new PropertyCondition(AutomationElement.IsOffscreenProperty, false),
                new PropertyCondition(AutomationElement.NameProperty, elementName));
            //new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, true));
            var element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, conditions);
            MoveToAndClick(element, MouseButton.Left);
        }

        public static void MoveToAndClickById(Window appWin, string elementId)
        {
            Condition conditions = new AndCondition(
                new PropertyCondition(AutomationElement.IsOffscreenProperty, false),
                new PropertyCondition(AutomationElement.AutomationIdProperty, elementId));
            //new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, true));
            var element = appWin.AutomationElement.FindFirst(TreeScope.Descendants, conditions);
            MoveToAndClick(element, MouseButton.Left);
        }


        public static void MoveToAndClick(AutomationElement element)
        {
            MoveToAndClick(element, MouseButton.Left);
        }

        public static void MoveToAndClick(AutomationElement element, MouseButton mouseButton)
        {
            
            System.Windows.Point winPointTopLeft = element.Current.BoundingRectangle.TopLeft;
            
            var height=element.Current.BoundingRectangle.Height;
            var width=element.Current.BoundingRectangle.Width;
            var centerX = winPointTopLeft.X + width / 2;
            var centerY = winPointTopLeft.Y + height / 2;

            System.Drawing.Point drawingPoint = new System.Drawing.Point((int)(centerX), (int)(centerY));
            Mouse.MoveTo(drawingPoint);
            Mouse.Click(mouseButton);
        }
    }
}

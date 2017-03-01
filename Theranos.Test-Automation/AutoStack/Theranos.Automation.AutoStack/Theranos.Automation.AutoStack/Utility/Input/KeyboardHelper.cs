using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack.Utility.Input;

namespace Theranos.Automation.AutoStack.Utility.Input
{
    public class KeyboardHelper
    {
        public void SendTabKey()
        {
            Keyboard.Press(Key.Tab);
        }
    }
}

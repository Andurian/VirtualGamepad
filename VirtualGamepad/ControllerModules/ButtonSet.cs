using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualGamepad.ControllerModules
{
    public class ButtonSet : IControllerModule
    {
        List<Button> buttons;

        public ButtonSet(List<Button> buttons)
        {
            this.Buttons = buttons;
        }
        public void update(JoystickState stick)
        {
            foreach(var b in buttons)
            {
                b.update(stick);
            }
        }

        public void translateInput()
        {
            foreach(var b in buttons)
            {
                b.translateInput();
            }
            
        }

        public List<Button> Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }
    }
}

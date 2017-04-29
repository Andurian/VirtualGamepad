using VirtualGamepad.ControllerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualGamepad.Mapping
{
    public class ButtonToKeyMapping
    {
        private bool previousPressed;
        
        short keyCode;

        public ButtonToKeyMapping(short keyCode)
        {
            this.keyCode = keyCode;
            previousPressed = false;
        }

        private void update(Button button)
        {
            previousPressed = button.Pressed;
        }

        public void map(Button button)
        {
            if (button.Pressed && !previousPressed)
            {
                InputInterface.PressKey(keyCode);
            }

            if (!button.Pressed && previousPressed)
            {
                InputInterface.ReleaseKey(keyCode);
            }

            update(button);
        }

    }
}

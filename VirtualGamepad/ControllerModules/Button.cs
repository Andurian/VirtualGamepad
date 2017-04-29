using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualGamepad.Mapping;

namespace VirtualGamepad.ControllerModules
{
    public class Button : IControllerModule
    {
        private ButtonToKeyMapping mapping;

        private int index; //< Index im Button-Array des Controllers

        private bool pressed;

        public Button(int index)
        {
            this.index = index;
        }


        public void update(JoystickState stick)
        {
            pressed = stick.GetButtons()[index] != 0;
        }

        public void translateInput()
        {
            Mapping.map(this);
        }

        public ButtonToKeyMapping Mapping
        {
            get { return mapping; }
            set { mapping = value; }
        }

        public bool Pressed
        {
            get { return pressed; }
            private set { pressed = value; }
        }
    }
}

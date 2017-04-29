using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VirtualGamepad.ControllerModules
{
    public interface IControllerModule
    {
        void update(JoystickState stick);
        void translateInput();
    }
}

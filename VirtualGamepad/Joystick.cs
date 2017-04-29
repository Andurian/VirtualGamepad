using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;
using System;
using VirtualGamepad.ControllerModules;
using VirtualGamepad.Mapping;

namespace VirtualGamepad
{
    using ControllerButton = VirtualGamepad.ControllerModules.Button;
    using FormsKeys = System.Windows.Forms.Keys;

    public class Joystick
    {
        #region param

        private Device joystickDevice;
        private JoystickState state;

        private IntPtr hWnd;

        private List<IControllerModule> modules;

        public bool[] buttons;

        #endregion

        public Joystick(IntPtr window_handle)
        {
            hWnd = window_handle;
            AnalogStick leftStick = new AnalogStick(0, 65535, 8, s => s.X, s => s.Y);
            leftStick.Mapping = new AnalogStickToKeyMapping();

            AnalogStick rightStick = new AnalogStick(0, 65535, 9, s => s.Rx, s => s.Ry);
            rightStick.Mapping = new AnalogStickToMouseMapping();

            modules = new List<IControllerModule>();
            modules.Add(leftStick);
            modules.Add(rightStick);

            var buttonsToKeys = new Dictionary<int, int>();

            buttonsToKeys[0] = (int)FormsKeys.Space; // A
            buttonsToKeys[1] = (int)FormsKeys.Alt; // B
            buttonsToKeys[2] = (int)FormsKeys.Control; // X
            buttonsToKeys[3] = (int)FormsKeys.R; // Y
            buttonsToKeys[4] = (int)FormsKeys.Q; // Linker Bumper
            buttonsToKeys[5] = (int)FormsKeys.E; // Rechter Bumper
            buttonsToKeys[6] = (int)FormsKeys.Escape; // Back
            buttonsToKeys[7] = (int)FormsKeys.Enter; // Start
            //buttonsToKeys[8] = (int)FormsKeys.I; // Klick Linker Stick
            //buttonsToKeys[9] = (int)FormsKeys.J; // Klick Rechter Stick

            List<ControllerButton> buttons = new List<ControllerButton>();
            for(int i = 0; i <= 7; ++i)
            {
                ControllerButton b = new ControllerButton(i);
                b.Mapping = new ButtonToKeyMapping((short)buttonsToKeys[i]);
                buttons.Add(b);
            }

            ButtonSet bSet = new ButtonSet(buttons);
            modules.Add(bSet);

            Trigger t = new Trigger(0, 65535);
            t.Mapping = new TriggerToTemporaryCustomMapping(20000);
            modules.Add(t);

        }

        public string FindJoysticks()
        {
            string systemJoysticks = null;

            try
            {
                // Find all the GameControl devices that are attached.
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                // check that we have at least one device.
                if (gameControllerList.Count > 0)
                {
                    foreach (DeviceInstance deviceInstance in gameControllerList)
                    {
                        // create a device from this controller so we can retrieve info.
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                        systemJoysticks = joystickDevice.DeviceInformation.InstanceName;

                        break;
                    }
                }
            }
            catch
            {
                return null;
            }

            return systemJoysticks;
        }

        public bool AcquireJoystick(string name)
        {
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                int i = 0;
                bool found = false;

                foreach (DeviceInstance deviceInstance in gameControllerList)
                {
                    if (deviceInstance.InstanceName == name)
                    {
                        found = true;
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
                        break;
                    }
                    i++;
                }

                if (!found)
                    return false;

                joystickDevice.SetDataFormat(DeviceDataFormat.Joystick);

                joystickDevice.Acquire();

                UpdateStatus();
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        public void ReleaseJoystick()
        {
            joystickDevice.Unacquire();
        }

        public void UpdateStatus()
        {
            Poll();

            //leftStick.update(state.X, state.Y, state.GetButtons());
            //rightStick.update(state.Rx, state.Ry, state.GetButtons());

            foreach(var m in modules)
            {
                m.update(state);
            }

            foreach(var m in modules)
            {
                m.translateInput();
            }

            byte[] jsButtons = state.GetButtons();
            buttons = new bool[jsButtons.Length];

            int i = 0;
            foreach (byte button in jsButtons)
            {
                buttons[i] = button >= 128;
                i++;
            }

        }

        private void Poll()
        {
            try
            {
                // poll the joystick
                joystickDevice.Poll();
                // update the joystick state field
                state = joystickDevice.CurrentJoystickState;
            }
            catch
            {
                throw (null);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VirtualGamepad.ControllerModules;

namespace VirtualGamepad.Mapping
{
    using Direction = AnalogStick.Direction;

    public class AnalogStickToMouseMapping : IAnalogStickMapping
    {
        //private AnalogStick stick;

        private int maxDirectionValue;
        private int maxSymmetricDirectionValue;
        private int minSymmetricThreshold;
        private int maxMouseMovementSpeed;

        private InputInterface.MOUSEEVENTF actionOnClick;

        bool previousClicked;

        public AnalogStickToMouseMapping()
        {
            maxDirectionValue = 65535;
            maxSymmetricDirectionValue = maxDirectionValue / 2 + 2000;
            minSymmetricThreshold = 8000;
            maxMouseMovementSpeed = 20;

            previousClicked = false;
            actionOnClick = InputInterface.MOUSEEVENTF.LEFTDOWN;
        }


        private void update(AnalogStick stick)
        {
            previousClicked = stick.Clicked;
        }


        //TODO: Aktion beim Klick variabel maachen
        public void map(AnalogStick stick)
        {
            var m = getMouseMovement(stick);
            InputInterface.MoveMouse(m[0], m[1]);

            if(stick.Clicked && !previousClicked)
            {
                InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.LEFTDOWN);
            }
            
            if(!stick.Clicked && previousClicked)
            {
                 InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.LEFTUP);
            }

            update(stick);
        }


        private int[] getMouseMovement(AnalogStick stick)
        {
            var stickMovement = stick.Movement;
            var mouseMovement = new int[2];

            mouseMovement[0] = 0;
            mouseMovement[1] = 0;

            if (stickMovement[(int)Direction.LEFT] > minSymmetricThreshold)
            {
                mouseMovement[0] = -whichIndex(minSymmetricThreshold, maxSymmetricDirectionValue, maxMouseMovementSpeed, stickMovement[(int)Direction.LEFT]);
            }

            if (stickMovement[(int)Direction.RIGHT] > minSymmetricThreshold)
            {
                mouseMovement[0] = whichIndex(minSymmetricThreshold, maxSymmetricDirectionValue, maxMouseMovementSpeed, stickMovement[(int)Direction.RIGHT]);
            }

            if (stickMovement[(int)Direction.TOP] > minSymmetricThreshold)
            {
                mouseMovement[1] = -whichIndex(minSymmetricThreshold, maxSymmetricDirectionValue, maxMouseMovementSpeed, stickMovement[(int)Direction.TOP]);
            }

            if (stickMovement[(int)Direction.DOWN] > minSymmetricThreshold)
            {
                mouseMovement[1] = whichIndex(minSymmetricThreshold, maxSymmetricDirectionValue, maxMouseMovementSpeed, stickMovement[(int)Direction.DOWN]);
            }

            return mouseMovement;
        }

        private int whichIndex(int tmin, int tmax, int smax, int val)
        {
            int stepsize = (tmax - tmin) / smax;
            for (int i = 0; i < smax; ++i)
            {
                if (tmin + i * stepsize >= val)
                    return i - 1;
            }
            return 0;
        }

    }
}

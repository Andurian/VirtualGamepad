using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualGamepad.ControllerModules;

namespace VirtualGamepad.Mapping
{
    using Direction = AnalogStick.Direction;
    using FormsKeys = System.Windows.Forms.Keys;

    public class AnalogStickToKeyMapping : IAnalogStickMapping
    {
        int thresholdLeft = 25383;
        int thresholdTop = 16383;

        int thresholdRight = 40151;
        int thresholdDown = 49151;

        int thresholdVertical = 16383;
        int thresholdHorizontal = 10000;

        private bool[] oldDirectionStatus;

        static Dictionary<Direction, int> directionsToKeys;


        public AnalogStickToKeyMapping()
        {
            oldDirectionStatus = new bool[4];

            directionsToKeys = new Dictionary<AnalogStick.Direction, int>();

            directionsToKeys[Direction.TOP] = (int)FormsKeys.W;// 17; // W
            directionsToKeys[Direction.RIGHT] = (int)FormsKeys.D;// 23; // D
            directionsToKeys[Direction.DOWN] = (int)FormsKeys.S;// 31; // S
            directionsToKeys[Direction.LEFT] = (int)FormsKeys.A;// 30; // A
        }

        bool[] getDirectionStatus(AnalogStick stick)
        {
            var directionsPressed = new bool[4];
            var movement = stick.Movement;

            directionsPressed[(int)Direction.TOP] = movement[(int)Direction.TOP] > thresholdVertical;
            directionsPressed[(int)Direction.RIGHT] = movement[(int)Direction.RIGHT] > thresholdHorizontal;
            directionsPressed[(int)Direction.DOWN] = movement[(int)Direction.DOWN] > thresholdVertical;
            directionsPressed[(int)Direction.LEFT] = movement[(int)Direction.LEFT] > thresholdHorizontal;
            return directionsPressed;
        }

        private bool[] getReleasedDirections(bool[] currentDirectionStatus)
        {
            var releasedDirections = new bool[currentDirectionStatus.Length];

            for (int i = 0; i < currentDirectionStatus.Length; ++i)
            {
                if (currentDirectionStatus[i] == false && oldDirectionStatus[i] == true)
                {
                    releasedDirections[i] = true;
                }
                else
                {
                    releasedDirections[i] = false;
                }
            }
            return releasedDirections;
        }

        private bool[] getPressedDirections(bool[] currentDirectionStatus)
        {
            var pressedDirections = new bool[currentDirectionStatus.Length];

            for (int i = 0; i < currentDirectionStatus.Length; ++i)
            {
                if (currentDirectionStatus[i] == true && oldDirectionStatus[i] == false)
                {
                    pressedDirections[i] = true;
                }
                else
                {
                    pressedDirections[i] = false;
                }
            }
            return pressedDirections;
        }

        private void update(bool[] currentDirectionStatus)
        {
            oldDirectionStatus = currentDirectionStatus;
        }

        public void map(AnalogStick stick)
        {
            var currentDirectionStatus = getDirectionStatus(stick);
            var releasedDirections = getReleasedDirections(currentDirectionStatus);
            var pressedDirections = getPressedDirections(currentDirectionStatus);

            //s += "Release:\t";
            //foreach (bool b in releasedDirections)
            //{
            //    s += b + "\t";
            //}
            //s += "\n";

            //s += "Pressed:\t";
            //foreach (bool b in pressedDirections)
            //{
            //    s += b + "\t";
            //}
            //s += "\n";

            for (int i = 0; i < releasedDirections.Length; ++i)
            {
                //string t = " ";
                if (releasedDirections[i] == true)
                {
                    InputInterface.ReleaseKey((short)directionsToKeys[(Direction)i]);
                    //t = "rel";
                }
                //s += t + "\t";
            }
            //s += "\n";

            for (int i = 0; i < pressedDirections.Length; ++i)
            {

                //string t = " ";
                if (pressedDirections[i] == true)
                {
                    InputInterface.PressKey((short)directionsToKeys[(Direction)i]);
                   // t = "prs";
                }
                //s += t + "\t";
            }

            update(currentDirectionStatus);
        }
    }
}

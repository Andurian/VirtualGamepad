using VirtualGamepad.ControllerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualGamepad.Mapping
{
    using Side = Trigger.Side;

    public class TriggerToTemporaryCustomMapping
    {
        private int threshold;

        private bool[] previousPressed;

        public TriggerToTemporaryCustomMapping(int threshold)
        {
            this.threshold = threshold;

            previousPressed = new bool[2];
            previousPressed[(int)Side.LEFT] = previousPressed[(int)Side.RIGHT] = false;
        }

        private bool[] getPressedStatus(int[] movement)
        {
            bool[] pressedStatus = new bool[movement.Length];

            for(int i = 0; i < movement.Length; ++i)
            {
                pressedStatus[i] = movement[i] > threshold;
            }

            return pressedStatus;
        }

        private void update(bool[] pressedStatus)
        {
            previousPressed = pressedStatus;
        }

        public void map(Trigger trigger)
        {
            var pressedStatus = getPressedStatus(trigger.Movement);
            int x = 0;
            for(int i = 0; i < pressedStatus.Length; ++i)
            {
                
                if(previousPressed[i] && !pressedStatus[i])
                {
                    if(i == 0)
                    {
                        x = 1;
                        InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.RIGHTUP);
                    }
                    else
                    {
                        if(i == 1)
                        {
                            x = 2;
                            InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.LEFTUP);
                        }
                    }
                }


                if (!previousPressed[i] && pressedStatus[i])
                {
                    if (i == 0)
                    {
                        x = 3;
                        //System.Windows.Forms.MessageBox.Show("ClickRight");
                        InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.RIGHTDOWN);
                    }
                    else
                    {
                        if (i == 1)
                        {
                            x = 4;
                            InputInterface.SendMouseClick(InputInterface.MOUSEEVENTF.LEFTDOWN);
                        }
                    }
                }
            }

            update(pressedStatus);

            //if(x != 0)
            //    System.Windows.Forms.MessageBox.Show("" + x);

        }
    }
}

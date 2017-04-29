using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualGamepad.View
{
    public partial class Form1 : Form
    {
        private Joystick joystick;
        private System.Windows.Forms.Timer pollingTimer;

        public Form1()
        {
            InitializeComponent();

            this.joystick = new Joystick(this.Handle);
            connectToJoystick(joystick);

            //status = new JoystickStatus(joystick);

            //pollingTimer = new System.Windows.Forms.Timer(this.components);
            //pollingTimer.Interval = 20;
            //pollingTimer.Enabled = true;
        }

        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                System.Console.Write("Test");
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        //enableTimer();
                        break;
                    }
                }
            }
        }
    }
}

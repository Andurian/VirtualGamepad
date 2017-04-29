using VirtualGamepad.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace VirtualGamepad.View
{

    public partial class MainWindow : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Joystick joystick;
        private System.Windows.Forms.Timer pollingTimer;

        //private JoystickStatus status;
        //private bool[] joystickButtons;

        public MainWindow()
        {
            InitializeComponent();
            this.joystick = new Joystick(this.Handle);
            connectToJoystick(joystick);

            //status = new JoystickStatus(joystick);

            pollingTimer = new System.Windows.Forms.Timer(this.components);
            pollingTimer.Interval = 20;
            pollingTimer.Enabled = true;
            pollingTimer.Tick += new System.EventHandler(joystickTimer_Tick_1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
            }
        }

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate()
                {
                    pollingTimer.Enabled = true;
                }));
            }
            else
                pollingTimer.Enabled = true;
        }

        private void joystickTimer_Tick_1(object sender, EventArgs e)
        {
            //output.Text = "X : " + joystick.Xaxis + "\n";
            //output.Text += "Y : " + joystick.Yaxis + "\n\n";
            //JoystickStatus.MoveMouse();

            output.Text = "";

            try
            {
                joystick.UpdateStatus();
                //joystickButtons = joystick.buttons;

                //output.Text = status.step();

                //if (joystick.Xaxis == 0)
                //    output.Text+="Left\n";

                //if (joystick.Xaxis == 65535)
                //    output.Text+="Right\n";

                //if (joystick.Yaxis == 0)
                //{
                //    output.Text += "Up\n";
                //    //Console.Beep(5000, 1000);
                //    PressKey(33);
                //}

                //if (joystick.Yaxis == 65535)
                //    output.Text+="Down\n";

                //for (int i = 0; i < joystickButtons.Length; i++)
                //{
                //    if(joystickButtons[i] == true)
                //        output.Text+="Button " + i + " Pressed\n";
                //}
            }
            catch
            {
                pollingTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            output.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //joystickTimer.Enabled = false;

            //PressKeyDialog dialog = new PressKeyDialog(status);
            //var ret = dialog.ShowDialog();

            //joystickTimer.Enabled = true;
        }

        private void analogStickControlLeft_Load(object sender, EventArgs e)
        {

        }

    }
}

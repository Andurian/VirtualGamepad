using VirtualGamepad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VirtualGamepad.View
{
    public partial class PressKeyDialog : Form
    {
        //private JoystickStatus status;
        private System.Windows.Forms.Keys key;

        public PressKeyDialog(/*JoystickStatus s*/)
        {
            InitializeComponent();
            //status = s;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
           // status.testSetKeyForA((int)key);
            this.Dispose();
        }

        private void PressKeyDialog_KeyDown(object sender, KeyEventArgs e)
        {
            labelCheck.Text = "Key: " + e.KeyCode;
            key = e.KeyCode;
        }

        private void buttonLeaveEmpty_Click(object sender, EventArgs e)
        {

        }
    }
}

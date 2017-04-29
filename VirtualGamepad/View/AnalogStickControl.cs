using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualGamepad;
using VirtualGamepad.ControllerModules;

namespace VirtualGamepad.View
{
    public partial class AnalogStickControl : UserControl
    {
        private AnalogStick stick;
        
        public AnalogStickControl()
        {
            InitializeComponent();
        }

        private void checkBoxUseAsMouse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonChangeMappingTop_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeMappingLeft_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeMappingRight_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeMappingDown_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeMappingClick_Click(object sender, EventArgs e)
        {

        }

        public AnalogStick Stick
        {
            get { return stick; }
            set { stick = value; }
        }
    }
}

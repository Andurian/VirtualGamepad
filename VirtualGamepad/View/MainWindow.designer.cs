namespace VirtualGamepad.View
{
    partial class MainWindow
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.analogStickControlLeft = new VirtualGamepad.View.AnalogStickControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "s";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 6);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(253, 149);
            this.output.TabIndex = 1;
            this.output.Text = "";
            // 
            // analogStickControlLeft
            // 
            this.analogStickControlLeft.AutoSize = true;
            this.analogStickControlLeft.Location = new System.Drawing.Point(271, 6);
            this.analogStickControlLeft.Name = "analogStickControlLeft";
            this.analogStickControlLeft.Size = new System.Drawing.Size(442, 188);
            this.analogStickControlLeft.Stick = null;
            this.analogStickControlLeft.TabIndex = 4;
            this.analogStickControlLeft.Load += new System.EventHandler(this.analogStickControlLeft_Load);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 205);
            this.Controls.Add(this.analogStickControlLeft);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "JoystickInterface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox output;
        private VirtualGamepad.View.AnalogStickControl analogStickControlLeft;
    }
}


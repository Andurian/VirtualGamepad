namespace VirtualGamepad.View
{
    partial class PressKeyDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLeaveEmpty = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelCheck = new System.Windows.Forms.Label();
            this.labelAufforderung = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLeaveEmpty);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.labelCheck);
            this.panel1.Controls.Add(this.labelAufforderung);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 88);
            this.panel1.TabIndex = 0;
            // 
            // buttonLeaveEmpty
            // 
            this.buttonLeaveEmpty.Location = new System.Drawing.Point(174, 62);
            this.buttonLeaveEmpty.Name = "buttonLeaveEmpty";
            this.buttonLeaveEmpty.Size = new System.Drawing.Size(83, 23);
            this.buttonLeaveEmpty.TabIndex = 3;
            this.buttonLeaveEmpty.Text = "Leave Empty";
            this.buttonLeaveEmpty.UseVisualStyleBackColor = true;
            this.buttonLeaveEmpty.Click += new System.EventHandler(this.buttonLeaveEmpty_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(93, 62);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheck.Location = new System.Drawing.Point(3, 65);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(0, 20);
            this.labelCheck.TabIndex = 1;
            // 
            // labelAufforderung
            // 
            this.labelAufforderung.AutoSize = true;
            this.labelAufforderung.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAufforderung.Location = new System.Drawing.Point(52, 9);
            this.labelAufforderung.Name = "labelAufforderung";
            this.labelAufforderung.Size = new System.Drawing.Size(147, 31);
            this.labelAufforderung.TabIndex = 0;
            this.labelAufforderung.Text = "Press Key";
            // 
            // PressKeyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "PressKeyDialog";
            this.Text = "PressKeyDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressKeyDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.Label labelAufforderung;
        private System.Windows.Forms.Button buttonLeaveEmpty;
    }
}
namespace prjTimeClockProgram
{
    partial class FrmTimeClockProgramMainForm
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimeClockProgramMainForm));
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClock = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(120, 71);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(100, 20);
            this.txtUserCode.TabIndex = 0;
            this.txtUserCode.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter user code:";
            this.toolTip1.SetToolTip(this.label1, "Hint: your lunch code plus a lower case \"a\"\r\n");
            // 
            // btnClock
            // 
            this.btnClock.Location = new System.Drawing.Point(96, 174);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(114, 23);
            this.btnClock.TabIndex = 2;
            this.btnClock.Text = "&Clock In/Out";
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(271, 49);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(414, 148);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 668);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version 0.9. Originally created by: Hayden Mumm,\r\nFor use and modification by Fre" +
    "edom Robotics team 6318.\r\n\r\nconsider donating: https://freedomengineers6318.weeb" +
    "ly.com/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FrmTimeClockProgramMainForm
            // 
            this.AcceptButton = this.btnClock;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnClock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmTimeClockProgramMainForm";
            this.Text = "Time Clock - V. 0.9";
            this.Load += new System.EventHandler(this.FrmTimeClockProgramMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClock;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


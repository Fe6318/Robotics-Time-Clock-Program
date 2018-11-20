namespace FE6318.TimeClockProgram.UI
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
            this.btnAdministrator = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(222, 130);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(100, 22);
            this.txtUserCode.TabIndex = 1;
            this.txtUserCode.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Enter user code:";
            this.toolTip1.SetToolTip(this.label1, "Hint: your lunch code plus a lower case \"a\"\r\n");
            // 
            // btnClock
            // 
            this.btnClock.Location = new System.Drawing.Point(222, 190);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(100, 23);
            this.btnClock.TabIndex = 2;
            this.btnClock.Text = "&Clock In/Out";
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(716, 208);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(609, 293);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1047, 669);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version 1.0.1.0 Originally created by: Hayden Mumm,\r\nfor use and modification by " +
    "Freedom Robotics team 6318.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAdministrator
            // 
            this.btnAdministrator.Location = new System.Drawing.Point(207, 433);
            this.btnAdministrator.Name = "btnAdministrator";
            this.btnAdministrator.Size = new System.Drawing.Size(139, 23);
            this.btnAdministrator.TabIndex = 4;
            this.btnAdministrator.Text = "Open Administrator Form";
            this.btnAdministrator.UseVisualStyleBackColor = true;
            this.btnAdministrator.Click += new System.EventHandler(this.btnAdministrator_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(49, 682);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "GitHub page";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FrmTimeClockProgramMainForm
            // 
            this.AcceptButton = this.btnClock;
            this.AccessibleDescription = "A program used to track attendance for robotics members";
            this.ClientSize = new System.Drawing.Size(1349, 721);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdministrator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnClock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimeClockProgramMainForm";
            this.Text = "Time Clock - V. 1.0.1.0";
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
        private System.Windows.Forms.Button btnAdministrator;
        private System.Windows.Forms.Label label3;
    }
}


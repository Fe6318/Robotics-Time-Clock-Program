namespace prjTimeClockProgram
{
    partial class AdministratorForm
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
            this.lbxIn = new System.Windows.Forms.ListBox();
            this.lbxOut = new System.Windows.Forms.ListBox();
            this.dtpIn = new System.Windows.Forms.DateTimePicker();
            this.dtpOut = new System.Windows.Forms.DateTimePicker();
            this.cmbSelectedUser = new System.Windows.Forms.ComboBox();
            this.btnModifyIn = new System.Windows.Forms.Button();
            this.btnModifyOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintCurUser = new System.Windows.Forms.Button();
            this.btnPrintAllUsersHours = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxIn
            // 
            this.lbxIn.FormattingEnabled = true;
            this.lbxIn.Location = new System.Drawing.Point(57, 245);
            this.lbxIn.Name = "lbxIn";
            this.lbxIn.Size = new System.Drawing.Size(170, 186);
            this.lbxIn.TabIndex = 0;
            // 
            // lbxOut
            // 
            this.lbxOut.FormattingEnabled = true;
            this.lbxOut.Location = new System.Drawing.Point(383, 245);
            this.lbxOut.Name = "lbxOut";
            this.lbxOut.Size = new System.Drawing.Size(170, 186);
            this.lbxOut.TabIndex = 1;
            // 
            // dtpIn
            // 
            this.dtpIn.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.dtpIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIn.Location = new System.Drawing.Point(41, 114);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(200, 20);
            this.dtpIn.TabIndex = 2;
            // 
            // dtpOut
            // 
            this.dtpOut.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.dtpOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOut.Location = new System.Drawing.Point(362, 114);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(200, 20);
            this.dtpOut.TabIndex = 3;
            // 
            // cmbSelectedUser
            // 
            this.cmbSelectedUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedUser.FormattingEnabled = true;
            this.cmbSelectedUser.Location = new System.Drawing.Point(236, 57);
            this.cmbSelectedUser.Name = "cmbSelectedUser";
            this.cmbSelectedUser.Size = new System.Drawing.Size(121, 21);
            this.cmbSelectedUser.TabIndex = 4;
            this.cmbSelectedUser.SelectedIndexChanged += new System.EventHandler(this.cmbSelectedUser_SelectedIndexChanged);
            // 
            // btnModifyIn
            // 
            this.btnModifyIn.Location = new System.Drawing.Point(98, 160);
            this.btnModifyIn.Name = "btnModifyIn";
            this.btnModifyIn.Size = new System.Drawing.Size(75, 23);
            this.btnModifyIn.TabIndex = 5;
            this.btnModifyIn.Text = "Modify";
            this.btnModifyIn.UseVisualStyleBackColor = true;
            this.btnModifyIn.Click += new System.EventHandler(this.btnModifyIn_Click);
            // 
            // btnModifyOut
            // 
            this.btnModifyOut.Location = new System.Drawing.Point(427, 160);
            this.btnModifyOut.Name = "btnModifyOut";
            this.btnModifyOut.Size = new System.Drawing.Size(75, 23);
            this.btnModifyOut.TabIndex = 6;
            this.btnModifyOut.Text = "Modify";
            this.btnModifyOut.UseVisualStyleBackColor = true;
            this.btnModifyOut.Click += new System.EventHandler(this.btnModifyOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Times Clocked In";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Times Clocked Out";
            // 
            // btnPrintCurUser
            // 
            this.btnPrintCurUser.Location = new System.Drawing.Point(254, 444);
            this.btnPrintCurUser.Name = "btnPrintCurUser";
            this.btnPrintCurUser.Size = new System.Drawing.Size(103, 23);
            this.btnPrintCurUser.TabIndex = 9;
            this.btnPrintCurUser.Text = "Print Current User";
            this.btnPrintCurUser.UseVisualStyleBackColor = true;
            this.btnPrintCurUser.Click += new System.EventHandler(this.btnPrintCurUser_Click);
            // 
            // btnPrintAllUsersHours
            // 
            this.btnPrintAllUsersHours.Location = new System.Drawing.Point(249, 490);
            this.btnPrintAllUsersHours.Name = "btnPrintAllUsersHours";
            this.btnPrintAllUsersHours.Size = new System.Drawing.Size(116, 23);
            this.btnPrintAllUsersHours.TabIndex = 10;
            this.btnPrintAllUsersHours.Text = "Print All Users Hours";
            this.btnPrintAllUsersHours.UseVisualStyleBackColor = true;
            this.btnPrintAllUsersHours.Click += new System.EventHandler(this.btnPrintAllUsersHours_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 535);
            this.Controls.Add(this.btnPrintAllUsersHours);
            this.Controls.Add(this.btnPrintCurUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModifyOut);
            this.Controls.Add(this.btnModifyIn);
            this.Controls.Add(this.cmbSelectedUser);
            this.Controls.Add(this.dtpOut);
            this.Controls.Add(this.dtpIn);
            this.Controls.Add(this.lbxOut);
            this.Controls.Add(this.lbxIn);
            this.Name = "AdministratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdministratorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxIn;
        private System.Windows.Forms.ListBox lbxOut;
        private System.Windows.Forms.DateTimePicker dtpIn;
        private System.Windows.Forms.DateTimePicker dtpOut;
        private System.Windows.Forms.ComboBox cmbSelectedUser;
        private System.Windows.Forms.Button btnModifyIn;
        private System.Windows.Forms.Button btnModifyOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintCurUser;
        private System.Windows.Forms.Button btnPrintAllUsersHours;
    }
}
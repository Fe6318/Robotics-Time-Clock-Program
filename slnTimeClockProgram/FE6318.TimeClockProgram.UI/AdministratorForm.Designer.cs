namespace FE6318.TimeClockProgram.UI
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
            this.btnDeleteIn = new System.Windows.Forms.Button();
            this.btnDeleteOut = new System.Windows.Forms.Button();
            this.btnAddIn = new System.Windows.Forms.Button();
            this.btnAddOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxIn
            // 
            this.lbxIn.FormattingEnabled = true;
            this.lbxIn.ItemHeight = 16;
            this.lbxIn.Location = new System.Drawing.Point(76, 350);
            this.lbxIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxIn.Name = "lbxIn";
            this.lbxIn.Size = new System.Drawing.Size(225, 228);
            this.lbxIn.TabIndex = 6;
            // 
            // lbxOut
            // 
            this.lbxOut.FormattingEnabled = true;
            this.lbxOut.ItemHeight = 16;
            this.lbxOut.Location = new System.Drawing.Point(511, 350);
            this.lbxOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxOut.Name = "lbxOut";
            this.lbxOut.Size = new System.Drawing.Size(225, 228);
            this.lbxOut.TabIndex = 8;
            // 
            // dtpIn
            // 
            this.dtpIn.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.dtpIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIn.Location = new System.Drawing.Point(55, 140);
            this.dtpIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(265, 22);
            this.dtpIn.TabIndex = 1;
            // 
            // dtpOut
            // 
            this.dtpOut.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.dtpOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOut.Location = new System.Drawing.Point(483, 140);
            this.dtpOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(265, 22);
            this.dtpOut.TabIndex = 3;
            // 
            // cmbSelectedUser
            // 
            this.cmbSelectedUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedUser.FormattingEnabled = true;
            this.cmbSelectedUser.Location = new System.Drawing.Point(315, 70);
            this.cmbSelectedUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSelectedUser.Name = "cmbSelectedUser";
            this.cmbSelectedUser.Size = new System.Drawing.Size(160, 24);
            this.cmbSelectedUser.TabIndex = 0;
            this.cmbSelectedUser.SelectedIndexChanged += new System.EventHandler(this.cmbSelectedUser_SelectedIndexChanged);
            // 
            // btnModifyIn
            // 
            this.btnModifyIn.Location = new System.Drawing.Point(131, 197);
            this.btnModifyIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifyIn.Name = "btnModifyIn";
            this.btnModifyIn.Size = new System.Drawing.Size(100, 28);
            this.btnModifyIn.TabIndex = 2;
            this.btnModifyIn.Text = "Modify";
            this.btnModifyIn.UseVisualStyleBackColor = true;
            this.btnModifyIn.Click += new System.EventHandler(this.btnModifyIn_Click);
            // 
            // btnModifyOut
            // 
            this.btnModifyOut.Location = new System.Drawing.Point(569, 197);
            this.btnModifyOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifyOut.Name = "btnModifyOut";
            this.btnModifyOut.Size = new System.Drawing.Size(100, 28);
            this.btnModifyOut.TabIndex = 4;
            this.btnModifyOut.Text = "Modify";
            this.btnModifyOut.UseVisualStyleBackColor = true;
            this.btnModifyOut.Click += new System.EventHandler(this.btnModifyOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Times Clocked In";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Times Clocked Out";
            // 
            // btnPrintCurUser
            // 
            this.btnPrintCurUser.Location = new System.Drawing.Point(339, 594);
            this.btnPrintCurUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintCurUser.Name = "btnPrintCurUser";
            this.btnPrintCurUser.Size = new System.Drawing.Size(137, 28);
            this.btnPrintCurUser.TabIndex = 9;
            this.btnPrintCurUser.Text = "Print Current User";
            this.btnPrintCurUser.UseVisualStyleBackColor = true;
            this.btnPrintCurUser.Click += new System.EventHandler(this.btnPrintCurUser_Click);
            // 
            // btnPrintAllUsersHours
            // 
            this.btnPrintAllUsersHours.Location = new System.Drawing.Point(332, 651);
            this.btnPrintAllUsersHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintAllUsersHours.Name = "btnPrintAllUsersHours";
            this.btnPrintAllUsersHours.Size = new System.Drawing.Size(155, 28);
            this.btnPrintAllUsersHours.TabIndex = 10;
            this.btnPrintAllUsersHours.Text = "Print All Users Hours";
            this.btnPrintAllUsersHours.UseVisualStyleBackColor = true;
            this.btnPrintAllUsersHours.Click += new System.EventHandler(this.btnPrintAllUsersHours_Click);
            // 
            // btnDeleteIn
            // 
            this.btnDeleteIn.Location = new System.Drawing.Point(131, 232);
            this.btnDeleteIn.Name = "btnDeleteIn";
            this.btnDeleteIn.Size = new System.Drawing.Size(100, 27);
            this.btnDeleteIn.TabIndex = 11;
            this.btnDeleteIn.Text = "Delete";
            this.btnDeleteIn.UseVisualStyleBackColor = true;
            this.btnDeleteIn.Click += new System.EventHandler(this.btnDeleteIn_Click);
            // 
            // btnDeleteOut
            // 
            this.btnDeleteOut.Location = new System.Drawing.Point(569, 232);
            this.btnDeleteOut.Name = "btnDeleteOut";
            this.btnDeleteOut.Size = new System.Drawing.Size(100, 27);
            this.btnDeleteOut.TabIndex = 12;
            this.btnDeleteOut.Text = "Delete";
            this.btnDeleteOut.UseVisualStyleBackColor = true;
            this.btnDeleteOut.Click += new System.EventHandler(this.btnDeleteOut_Click);
            // 
            // btnAddIn
            // 
            this.btnAddIn.Location = new System.Drawing.Point(131, 265);
            this.btnAddIn.Name = "btnAddIn";
            this.btnAddIn.Size = new System.Drawing.Size(100, 28);
            this.btnAddIn.TabIndex = 13;
            this.btnAddIn.Text = "Add";
            this.btnAddIn.UseVisualStyleBackColor = true;
            this.btnAddIn.Click += new System.EventHandler(this.btnAddIn_Click);
            // 
            // btnAddOut
            // 
            this.btnAddOut.Location = new System.Drawing.Point(569, 265);
            this.btnAddOut.Name = "btnAddOut";
            this.btnAddOut.Size = new System.Drawing.Size(100, 28);
            this.btnAddOut.TabIndex = 14;
            this.btnAddOut.Text = "Add";
            this.btnAddOut.UseVisualStyleBackColor = true;
            this.btnAddOut.Click += new System.EventHandler(this.btnAddOut_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 691);
            this.Controls.Add(this.btnAddOut);
            this.Controls.Add(this.btnAddIn);
            this.Controls.Add(this.btnDeleteOut);
            this.Controls.Add(this.btnDeleteIn);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnDeleteIn;
        private System.Windows.Forms.Button btnDeleteOut;
        private System.Windows.Forms.Button btnAddIn;
        private System.Windows.Forms.Button btnAddOut;
    }
}
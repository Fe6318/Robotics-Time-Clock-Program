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
            this.SuspendLayout();
            // 
            // lbxIn
            // 
            this.lbxIn.FormattingEnabled = true;
            this.lbxIn.Location = new System.Drawing.Point(53, 199);
            this.lbxIn.Name = "lbxIn";
            this.lbxIn.Size = new System.Drawing.Size(170, 186);
            this.lbxIn.TabIndex = 0;
            // 
            // lbxOut
            // 
            this.lbxOut.FormattingEnabled = true;
            this.lbxOut.Location = new System.Drawing.Point(379, 199);
            this.lbxOut.Name = "lbxOut";
            this.lbxOut.Size = new System.Drawing.Size(170, 186);
            this.lbxOut.TabIndex = 1;
            // 
            // dtpIn
            // 
            this.dtpIn.Location = new System.Drawing.Point(41, 114);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(200, 20);
            this.dtpIn.TabIndex = 2;
            // 
            // dtpOut
            // 
            this.dtpOut.Location = new System.Drawing.Point(362, 114);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(200, 20);
            this.dtpOut.TabIndex = 3;
            // 
            // cmbSelectedUser
            // 
            this.cmbSelectedUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedUser.FormattingEnabled = true;
            this.cmbSelectedUser.Location = new System.Drawing.Point(236, 69);
            this.cmbSelectedUser.Name = "cmbSelectedUser";
            this.cmbSelectedUser.Size = new System.Drawing.Size(121, 21);
            this.cmbSelectedUser.TabIndex = 4;
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.cmbSelectedUser);
            this.Controls.Add(this.dtpOut);
            this.Controls.Add(this.dtpIn);
            this.Controls.Add(this.lbxOut);
            this.Controls.Add(this.lbxIn);
            this.Name = "AdministratorForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdministratorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxIn;
        private System.Windows.Forms.ListBox lbxOut;
        private System.Windows.Forms.DateTimePicker dtpIn;
        private System.Windows.Forms.DateTimePicker dtpOut;
        private System.Windows.Forms.ComboBox cmbSelectedUser;
    }
}
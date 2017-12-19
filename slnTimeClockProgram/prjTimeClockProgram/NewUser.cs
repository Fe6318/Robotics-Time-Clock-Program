using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjTimeClockProgram
{
    public partial class NewUser : Form
    {
        FrmTimeClockProgramMainForm ownerForm;
        public NewUser(FrmTimeClockProgramMainForm frmTimeClockProgramMainForm)
        {
            ownerForm = frmTimeClockProgramMainForm;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //show messagebox error if no user ID
            if (txtUserID.Text == String.Empty)
            {
                MessageBox.Show("Enter a user ID", "Error", 0, MessageBoxIcon.Error);
                txtUserID.Focus();
                txtUserID.SelectAll();
                return;
            }

            //show messagebox error if no first name
            if (txtFirstName.Text == String.Empty)
            {
                MessageBox.Show("Enter a first name", "Error", 0, MessageBoxIcon.Error);
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            //show messagebox error if no last name
            if (txtLastName.Text == String.Empty)
            {
                MessageBox.Show("Enter a last name", "Error", 0, MessageBoxIcon.Error);
                txtLastName.Focus();
                txtLastName.SelectAll();
                return;
            }

            //add the user to the main form
            ownerForm.AddNewUser(txtUserID.Text, txtFirstName.Text, txtLastName.Text);
            
            //close the form it's no longer neccessary
           this.Close();
        }
    }
}

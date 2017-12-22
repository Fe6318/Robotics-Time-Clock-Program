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
    public partial class Password : Form
    {
        private bool isCorrectPassword;
        public Password()
        {
            InitializeComponent();
            isCorrectPassword = false;
        }

        public bool getIsCorrectPassword()
        {
            return isCorrectPassword;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Equals("password"))
            {
                isCorrectPassword = true;
            } else
            {
                isCorrectPassword = false;
            }
            this.Close();
        }
    }
}

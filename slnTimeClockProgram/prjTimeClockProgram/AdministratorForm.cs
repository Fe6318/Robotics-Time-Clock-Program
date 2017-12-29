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
    public partial class AdministratorForm : Form
    {
        FrmTimeClockProgramMainForm mainForm;
        public AdministratorForm(FrmTimeClockProgramMainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            //add each user's name into the drop down box
            for(int i = 0; mainForm.lstUsers.Count < i; i++)
            {
                cmbSelectedUser.Items.Add(mainForm.lstUsers.ElementAt(i).getName());
            }

            //put the first user in the list's information in each of the list boxes.


        }
    }
}

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

        List<User> lstUser;
        FrmTimeClockProgramMainForm mainForm;
        public AdministratorForm(FrmTimeClockProgramMainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            lstUser = mainForm.lstUsers;
        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            //add each user's name into the drop down box
            for(int i = 0; mainForm.lstUsers.Count < i; i++)
            {
                cmbSelectedUser.Items.Add(lstUser.ElementAt(i).getName());
            }


            
                //put the first user in the list's information in each of the list boxes.
                for (int i = 0; System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\in.6318").Count() > i; i++)
                {

                    lbxIn.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\in.6318").Skip(i).Take(1).First()));
                    lbxOut.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\out.6318").Skip(i).Take(1).First()));
                }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FE6318.TimeClockProgram.BusinessLayer;

namespace FE6318.TimeClockProgram.UI
{
    public partial class FrmTimeClockProgramMainForm : Form
    {
        public String strINSTALL_DIRECTORY = Application.StartupPath;
        public String strINFORMATION_DIRECTORY;
        public String strUSER_DIRECTORY;
        public String strLOG_DIRECTORY;
        public UserList userList = new UserList();

        public FrmTimeClockProgramMainForm()
        {
            InitializeComponent();
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            String strCurrentUserCode = txtUserCode.Text;
            User curUser = null;

            //run through all the users and find the matching user code
            for (int i = 0; userList.Count() > i; i++)
            {
                //if it matches clock in or out
                if(userList.ElementAt(i).UserID.Equals(strCurrentUserCode))
                {
                    curUser = userList[i];
                }
            }

            if(curUser == null)
            {
                if (strCurrentUserCode.Equals("+R+I+C+Ka")) { System.Diagnostics.Process.Start("https://youtu.be/dQw4w9WgXcQ"); return; }

                NewUser newUser = new NewUser(this);

                newUser.ShowDialog();
                return;
            }

            if (curUser.IsClockedIn)
            {
                
                curUser.clockOut();
                PrintUserInfo(curUser);
            }
            else
            {
                curUser.clockIn();
                PrintUserInfo(curUser);

            }
            txtUserCode.Focus();
            txtUserCode.SelectAll();

            userList.Save();
                
        }

        public void PrintUserInfo(User user)
        {
            
            if (!user.IsClockedIn)
            {
                lblOutput.Text = "User: " + user.Name + Environment.NewLine +
                             "Clocked out: " + user.getFormatedClockInTime() + Environment.NewLine +
                             "Total hours: " + Math.Round(user.LoggedHours, 2).ToString() + Environment.NewLine + 
                             "Hours this session: " + Math.Round(user.getNumberOfHoursElapsedBetweenClocks(),2);
            } else
            {
                lblOutput.Text = "User: " + user.Name + Environment.NewLine +
                             "Clocked in: " + user.getFormatedClockInTime() + Environment.NewLine +
                             "Total hours: " + Math.Round(user.LoggedHours, 2).ToString();
            }
        }

        public void AddNewUser(String userCode, String firstName, String lastName) 
        {
            userList.Add(new User(userCode,firstName,lastName));
            userList.Save();
            
        }

        private void FrmTimeClockProgramMainForm_Load(object sender, EventArgs e)
        {
            userList.Read();   
        }

        //when the form closes we want to clock out all the users so no hour counting errors will occur
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //confirm password to close the form
            Password password = new Password();
            password.ShowDialog();

            if (password.getIsCorrectPassword() == false)
            {
                MessageBox.Show("Incorrect password", "Error", 0, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {

                //clock out all users
                for (int i = 0; userList.Count > i; i++)
                {
                    userList.ElementAt(i).clockOut();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://freedomengineers6318.weebly.com/");
        }

        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            Password OPassword = new Password();
            OPassword.ShowDialog();

            if (OPassword.getIsCorrectPassword() == false)
            {
                MessageBox.Show("Incorrect password", "Error", 0, MessageBoxIcon.Error);
            }
            else
            {
                AdministratorForm OAdminForm = new AdministratorForm(this);
                OAdminForm.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fe6318/Robotics-Time-Clock-Program");
        }
    }
}

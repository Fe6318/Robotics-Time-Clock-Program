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

            //save this information to a text file
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(strUSER_DIRECTORY + @"\" + firstName + lastName + ".6318",false))
            {
                file.WriteLine(userCode);
                file.WriteLine(firstName);
                file.WriteLine(lastName);
                file.WriteLine("0");
            }

            //create a log directory for the user
            System.IO.Directory.CreateDirectory(strLOG_DIRECTORY + @"\" + firstName + lastName);
        }

        private void FrmTimeClockProgramMainForm_Load(object sender, EventArgs e)
        {
            //create a directory for all of the stored information on users
            System.IO.Directory.CreateDirectory(strINSTALL_DIRECTORY + @"\Information");
            strINFORMATION_DIRECTORY = strINSTALL_DIRECTORY + @"\Information";

            //create a directory for all user information
            System.IO.Directory.CreateDirectory(strINFORMATION_DIRECTORY + @"\Users");
            strUSER_DIRECTORY = strINFORMATION_DIRECTORY + @"\Users";

            //create a directory for logs
            System.IO.Directory.CreateDirectory(strINFORMATION_DIRECTORY + @"\Log");
            strLOG_DIRECTORY = strINFORMATION_DIRECTORY + @"\Log";

            String[] strAllUserFiles;
            //store all of the files in the user directory to strAllUserFiles
            strAllUserFiles = System.IO.Directory.GetFiles(strUSER_DIRECTORY);

            //use this to load in all of the current users
            for (int i = 0; strAllUserFiles.GetLength(0) > i; i++)
            {
                //read all the relevent lines of the file
                
                string line1 = System.IO.File.ReadLines(strAllUserFiles[i]).Skip(0).Take(1).First();
                string line2 = System.IO.File.ReadLines(strAllUserFiles[i]).Skip(1).Take(1).First();
                string line3 = System.IO.File.ReadLines(strAllUserFiles[i]).Skip(2).Take(1).First();
                string line4 = System.IO.File.ReadLines(strAllUserFiles[i]).Skip(3).Take(1).First();

                //create a log directory for the user
                System.IO.Directory.CreateDirectory(strLOG_DIRECTORY + @"\" + line2 + line3);
                
                //add a new user with this information
                userList.Add(new User(line1, line2, line3));
            }
            
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
            System.Diagnostics.Process.Start("https://github.com/hmumm/Robotics-Time-Clock-Program");
        }
    }
}

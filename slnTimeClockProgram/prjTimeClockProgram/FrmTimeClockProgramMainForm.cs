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
    public partial class FrmTimeClockProgramMainForm : Form
    {
        public String strINSTALL_DIRECTORY = Application.StartupPath;
        public String strINFORMATION_DIRECTORY;
        public String strUSER_DIRECTORY;
        public String strLOG_DIRECTORY;
        public List<User> lstUsers = new List<User>();

        public FrmTimeClockProgramMainForm()
        {
            InitializeComponent();
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            String strCurrentUserCode = txtUserCode.Text;

            //run through all the users and find the matching user code
            for (int i = 0; lstUsers.Count() > i; i++)
            {
                //if it matches clock in or out
                if(lstUsers.ElementAt(i).getUserID().Equals(strCurrentUserCode))
                {
                    if(lstUsers.ElementAt(i).getIsClockedIn())
                    {
                        User curUser = lstUsers.ElementAt(i);
                        curUser.clockOut();

                        //print out information
                        lblOutput.Text = "User: " + curUser.getName() + Environment.NewLine +
                                         "Clocked out: " + curUser.getFormatedClockOutTime() + Environment.NewLine +
                                         "Hours this session: " + Math.Round(curUser.getNumberOfHoursElapsedBetweenClocks(),2).ToString() + Environment.NewLine +
                                         "Total hours: " + Math.Round(curUser.getLoggedHours(),2).ToString();
                    } else
                    {
                        User curUser = lstUsers.ElementAt(i);
                        curUser.clockIn();

                        //print out information
                        lblOutput.Text = "User: " + curUser.getName() + Environment.NewLine +
                                         "Clocked in: " + curUser.getFormatedClockInTime() + Environment.NewLine +
                                         "Total hours: " + Math.Round(curUser.getLoggedHours(),2).ToString();

                    }
                    txtUserCode.Focus();
                    txtUserCode.SelectAll();
                    return;
                }
            }

            //if it makes it past the for loop then no user exists with that user code
            if (strCurrentUserCode.Equals("+R+I+C+Ka")) { System.Diagnostics.Process.Start("https://youtu.be/dQw4w9WgXcQ"); return; }
                //message box will show the messagebox then if the user answers yes it will launch the new form. If they say no the program will continue as normal
            if (MessageBox.Show("No such User exists."+ Environment.NewLine + Environment.NewLine +  "Create New User?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                NewUser newUser = new NewUser(this);
                
                newUser.ShowDialog();
            }
        }

        public void AddNewUser(String userCode, String firstName, String lastName) 
        {
            lstUsers.Add(new User(userCode,firstName,lastName,0,false,strLOG_DIRECTORY,strUSER_DIRECTORY));

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
                

                //create the log files
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + line2 + line3 + @"\in.6318",true)){}

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + line2 + line3 + @"\out.6318", true)) { }
                //add a new user with this information
                lstUsers.Add(new User(line1, line2, line3, double.Parse(line4), false, strLOG_DIRECTORY, strUSER_DIRECTORY));
            }
            
        }

        //when the form closes we want to clock out all the users so no hour counting errors will occur
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //confirm password to close the form
            Password OPassword = new Password();
            OPassword.ShowDialog();

            if (OPassword.getIsCorrectPassword() == false)
            {
                MessageBox.Show("Incorrect password", "Error", 0, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {

                //clock out all users
                for (int i = 0; lstUsers.Count > i; i++)
                {
                    lstUsers.ElementAt(i).clockOut();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://freedomengineers6318.weebly.com/");
        }
    }
}

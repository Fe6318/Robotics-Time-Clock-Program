using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using FE6318.TimeClockProgram.BusinessLayer;

namespace FE6318.TimeClockProgram.UI
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
            for (int i = 0; mainForm.lstUsers.Count > i; i++)
            {
                cmbSelectedUser.Items.Add(lstUser.ElementAt(i).Name);
            }

            //changing the index will cause it to update and have it load each list box
            //cmbSelectedUser.SelectedIndex = 0;

        }

        private void cmbSelectedUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reset everything
            dtpIn.ResetText();
            dtpOut.ResetText();

            //update the list boxes
            updateListBoxes();
        }

        private void btnModifyIn_Click(object sender, EventArgs e)
        {
            //check if no value is selected
            if(lbxIn.SelectedIndex == -1)
            {
                MessageBox.Show("No value is selected", "Error", 0, MessageBoxIcon.Error);
                return;
            }

            //read the file into an array
            string[] arrLine = File.ReadAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318");
            //change the selected value in the array
            arrLine[lbxIn.SelectedIndex] = dtpIn.Value.ToString();
            //write the array back to the file
            File.WriteAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318", arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void btnModifyOut_Click(object sender, EventArgs e)
        {
            //check if no value is selected
            if (lbxOut.SelectedIndex == -1)
            {
                MessageBox.Show("No value is selected", "Error", 0, MessageBoxIcon.Error);
                return;
            }

            //read the file into the array
            string[] arrLine = File.ReadAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318");
            //change the selected value in the array
            arrLine[lbxOut.SelectedIndex] = dtpOut.Value.ToString();
            //write the array back to the file
            File.WriteAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318", arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void updateListBoxes()
        {
            //clear the list boxes
            lbxIn.Items.Clear();
            lbxOut.Items.Clear();


            //read all the datetime's back in and put them in the list boxes
            for (int i = 0; System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318").Count() > i; i++)
            {
                lbxOut.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318").Skip(i).Take(1).First()));
            }
            
            for (int i = 0; System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318").Count() > i; i++)
            {
                lbxIn.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318").Skip(i).Take(1).First()));
            }
        }
        private void printCurrentUser()
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument p = new PrintDocument();
            String strUSER_IN_DIR = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318";
            String strUSER_OUT_DIR = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318";

            int y = 70; //y value on the page
            int itemsPerPage = 0; //items per page
            int i = 0; //which line we're on
            bool isFirstPage = true; //wether we are on the first page or not
            int offset = 25;
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {
                    //Reset the variables
                    if(!e1.HasMorePages)
                    {
                        y = 70;
                        itemsPerPage = 0;
                        i = 0;
                        isFirstPage = true;

                    }


                    if (isFirstPage)
                    {
                        //if it's the first page draw the name, and the in and out lower
                        e1.Graphics.DrawString(lstUser.ElementAt(cmbSelectedUser.SelectedIndex).Name, new Font("Times New Roman", 16), new SolidBrush(Color.Black), new RectangleF(350 - offset, 10, p.DefaultPageSettings.PrintableArea.Width, 50));
                        e1.Graphics.DrawString("In", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(90 - offset, 30, 30, 20));
                        e1.Graphics.DrawString("Out", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(755 - offset, 30, 50, 20));
                    } else
                    {
                        //if it isn't draw them higher
                        e1.Graphics.DrawString("In", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(90 - offset, 10, 30, 20));
                        e1.Graphics.DrawString("Out", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(730 - offset, 10, 50, 20));

                    }


                    while (System.IO.File.ReadLines(strUSER_OUT_DIR).Count() > i)
                    {
                        //write the datetime's
                        e1.Graphics.DrawString(System.IO.File.ReadLines(strUSER_IN_DIR).Skip(i).Take(1).First(), new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(30 - offset, y, 175, 20));
                        e1.Graphics.DrawString(System.IO.File.ReadLines(strUSER_OUT_DIR).Skip(i).Take(1).First(), new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(675 - offset, y, 175, 20));

                        //if we can still fit more
                        if (itemsPerPage < 33)
                        {
                            e1.HasMorePages = false; //don't make another page
                            y += 30; //add 30 to the y
                            itemsPerPage++; //one more item on the page
                        }
                        else
                        {
                            //if we can't fit anymore
                            e1.HasMorePages = true; //we need another page
                            y = 50; //reset the y to 50
                            itemsPerPage = 0; //now their is none on the page
                            isFirstPage = false; //it's not the firts page
                            return; //we have to return, so the printpreview will call this again.
                        }
                        i++;
                    }

                };
            //set the document to the one we just created
            printPreviewDialog1.Document = p;
            //set up the print preview
            printPreviewDialog1.Width = 1280;
            printPreviewDialog1.Height = 720;
            printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;
            //show the print preview
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrintCurUser_Click(object sender, EventArgs e)
        {
            printCurrentUser();
        }

        private void btnPrintAllUsersHours_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument p = new PrintDocument();

            int y = 15; //y value on the page
            int itemsPerPage = 0; //items per page
            int i = 0; //which line we're on
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                //reset the starting variables
                if(!e1.HasMorePages)
                {
                    y = 15;
                    itemsPerPage = 0;
                    i = 0;
                }

                while (lstUser.Count() > i) {

                    //update the users hours first
                    lstUser.ElementAt(i).updateHours();
                    //draw the users name
                    e1.Graphics.DrawString(lstUser.ElementAt(i).Name, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(20, y, p.DefaultPageSettings.PrintableArea.Width, 50));
                    //draw their total hours
                    e1.Graphics.DrawString(Math.Round(lstUser.ElementAt(i).LoggedHours,2).ToString(), new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(750, y, p.DefaultPageSettings.PrintableArea.Width, 50));

                    if (itemsPerPage < 35)
                    {
                        e1.HasMorePages = false;
                        y += 30;
                        itemsPerPage++;
                    } else
                    {
                        e1.HasMorePages = true;
                        y = 15;
                        itemsPerPage = 0;
                        return;
                    }
                    i++;
                }
            };

                //set the document to the one we just created
                printPreviewDialog1.Document = p;
            //set up the print preview
            printPreviewDialog1.Width = 1367;
            printPreviewDialog1.Height = 768;
            printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;
            //show the print preview
            printPreviewDialog1.ShowDialog();
        }

        private void btnDeleteIn_Click(object sender, EventArgs e)
        {
            String strInDirectory = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318";

            //check if no value is selected
            if (lbxIn.SelectedIndex == -1)
            {
                MessageBox.Show("No value is selected", "Error", 0, MessageBoxIcon.Error);
                return;
            }


            //read the file into an array
            string[] arrLine = File.ReadAllLines(strInDirectory);
            //put the array into a list
            List<String> lstLine = new List<String>(arrLine);
            //change the selected value in the list
            lstLine.RemoveAt(lbxIn.SelectedIndex);
            //change back into an array
            arrLine = lstLine.ToArray();
            //write the array back to the file
            File.WriteAllLines(strInDirectory, arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();

        }

        private void btnDeleteOut_Click(object sender, EventArgs e)
        {
            String strOutDirectory = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318";

            //check if no value is selected
            if (lbxOut.SelectedIndex == -1)
            {
                MessageBox.Show("No value is selected", "Error", 0, MessageBoxIcon.Error);
                return;
            }


            //read the file into an array
            string[] arrLine = File.ReadAllLines(strOutDirectory);
            //put the array into a list
            List<String> lstLine = new List<String>(arrLine);
            //change the selected value in the list
            lstLine.RemoveAt(lbxOut.SelectedIndex);
            //change back into an array
            arrLine = lstLine.ToArray();
            //write the array back to the file
            File.WriteAllLines(strOutDirectory, arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void btnAddIn_Click(object sender, EventArgs e)
        {
            String strInDirectory = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\in.6318";
            int intSelectedIndex = lbxIn.SelectedIndex;

            //read the file into an array
            string[] arrLine = File.ReadAllLines(strInDirectory);
            //put the array into a list
            List<String> lstLine = new List<String>(arrLine);
            if (intSelectedIndex == -1)
            {
                lstLine.Insert(0, dtpOut.Value.ToString());
            }
            else
            {
                //add the selected value in the list
                lstLine.Insert(intSelectedIndex + 1,dtpIn.Value.ToString());
            }
            //change back into an array
            arrLine = lstLine.ToArray();
            //write the array back to the file
            File.WriteAllLines(strInDirectory, arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void btnAddOut_Click(object sender, EventArgs e)
        {
            String strOutDirectory = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).FirstName + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).LastName + @"\out.6318";
            int intSelectedIndex = lbxIn.SelectedIndex;

            if(lbxOut.Items.Count + 1 > lbxIn.Items.Count)
            {
                MessageBox.Show("Out can't contain more time's then in", "Error", 0, MessageBoxIcon.Error);
                return;
            }

            //read the file into an array
            string[] arrLine = File.ReadAllLines(strOutDirectory);
            //put the array into a list
            List<string> lstLine = new List<string>(arrLine);

            if (intSelectedIndex == -1)
            {
                lstLine.Insert(0, dtpOut.Value.ToString());
            }
            else
            {
                //add the selected value in the list
                lstLine.Insert(intSelectedIndex + 1, dtpOut.Value.ToString());
            }
            //change back into an array
            arrLine = lstLine.ToArray();
            //write the array back to the file
            File.WriteAllLines(strOutDirectory, arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }
    }
}

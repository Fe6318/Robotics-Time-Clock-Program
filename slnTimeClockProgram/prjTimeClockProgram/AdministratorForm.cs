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
            for (int i = 0; mainForm.lstUsers.Count > i; i++)
            {
                cmbSelectedUser.Items.Add(lstUser.ElementAt(i).getName());
            }
            cmbSelectedUser.SelectedIndex = 0;
            //put the first user in the list's information in each of the list boxes.
            //for (int i = 0; System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\in.6318").Count() > i; i++)
            //{
            //    lbxIn.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\in.6318").Skip(i).Take(1).First()));
            //    lbxOut.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(0).getFirstName() + lstUser.ElementAt(0).getLastName() + @"\out.6318").Skip(i).Take(1).First()));
            //}

        }

        private void cmbSelectedUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpIn.ResetText();
            dtpOut.ResetText();

            updateListBoxes();
        }

        private void btnModifyIn_Click(object sender, EventArgs e)
        {

            string[] arrLine = File.ReadAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\in.6318");
            arrLine[lbxIn.SelectedIndex] = dtpIn.Value.ToString();
            File.WriteAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\in.6318", arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void btnModifyOut_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\out.6318");
            arrLine[lbxOut.SelectedIndex] = dtpOut.Value.ToString();
            File.WriteAllLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\out.6318", arrLine);

            //update the logged hours
            lstUser.ElementAt(cmbSelectedUser.SelectedIndex).updateHours();

            updateListBoxes();
        }

        private void updateListBoxes()
        {
            lbxIn.Items.Clear();
            lbxOut.Items.Clear();

            for (int i = 0; System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\out.6318").Count() > i; i++)
            {
                lbxIn.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\in.6318").Skip(i).Take(1).First()));
                lbxOut.Items.Add(DateTime.Parse(System.IO.File.ReadLines(mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\out.6318").Skip(i).Take(1).First()));
            }
        }
        private void printCurrentUser()
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument p = new PrintDocument();
            String strUSER_IN_DIR = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\in.6318";
            String strUSER_OUT_DIR = mainForm.strLOG_DIRECTORY + @"\" + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getFirstName() + lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getLastName() + @"\out.6318";

            int y = 70;
            int itemsPerPage = 0;
            int i = 0;
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {

                    e1.Graphics.DrawString(lstUser.ElementAt(cmbSelectedUser.SelectedIndex).getName(), new Font("Times New Roman", 16), new SolidBrush(Color.Black), new RectangleF(350, 10, p.DefaultPageSettings.PrintableArea.Width, 50));
                    e1.Graphics.DrawString("In", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(90, 30, 30, 20));
                    e1.Graphics.DrawString("Out", new Font("Times New Roman", 14), new SolidBrush(Color.Black), new RectangleF(700, 30, 50, 20));

                    
                    while (System.IO.File.ReadLines(strUSER_OUT_DIR).Count() > i)
                    {
                        e1.Graphics.DrawString(System.IO.File.ReadLines(strUSER_IN_DIR).Skip(i).Take(1).First(), new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(20, y, 150, 20));
                        e1.Graphics.DrawString(System.IO.File.ReadLines(strUSER_OUT_DIR).Skip(i).Take(1).First(), new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(640, y, 150, 20));
                        if (itemsPerPage < 33)
                        {
                            e1.HasMorePages = false;
                            y += 30;
                            itemsPerPage++;
                            
                        }
                        else
                        {
                            e1.HasMorePages = true;
                            y = 70;
                            itemsPerPage = 0;
                            return;
                        }
                        i++;
                    }

                };

            printPreviewDialog1.Document = p;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrintCurUser_Click(object sender, EventArgs e)
        {
            printCurrentUser();
        }
    }
}

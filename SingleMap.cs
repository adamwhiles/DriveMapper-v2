using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1;
using IWshRuntimeLibrary;

namespace DriveMapper_v2
{
    public partial class SingleMap : Form
    {
        public SingleMap()
        {
            InitializeComponent();
            // Create list with all possible drive letters
            List<string> fullDriveList = new List<string>(new string[] {"D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"});
            // Set usedDrives to currently used drive letters
            var usedDrives = System.IO.DriveInfo.GetDrives();
            // Setup list to hold used drive letters
            List<string> driveNames = new List<string>();
            // Loop through all the currently used drive letters and strip the : and \ before adding to the driveNames list
            foreach (var drive in usedDrives)
            {
                string drive2 = drive.Name.TrimEnd(':', '\\');
                driveNames.Add(drive2);
            }
            // Create a third list that will hold the available drive letters by comparing the full list with the used list
            List<string> availableDrives = fullDriveList.Except(driveNames).ToList();
            // Set the drop down to hold the available drive letters
            cmbLetters.DataSource = availableDrives;

            chkAuto.CheckedChanged += new EventHandler(chkAuto_CheckedChanged);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
                cmbLetters.Enabled = false;
            else
                cmbLetters.Enabled = true; 
            }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnMapIt_Click(object sender, EventArgs e)
        {
            string newDrive = "";
            string newPath = "";
            if (txtDrivePath.Text.Trim() == "")
            {
                MessageBox.Show("Missing mapping location information (path), please verify and try again.","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if ((cmbLetters.SelectedValue.ToString() == "") && (chkAuto.Checked == false))
            {
                MessageBox.Show("Drive letter not selected, please select a drive letter or check the auto select box", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                //Do Map Drive
                // If auto drive letter is checked then get the next available drive letter
                if (chkAuto.Checked == true)
                {
                    newDrive = nextDrive.GetNextDriveLetter();
                    newDrive += ":";
                }
                // If auto drive is not checked then take the drive letter from the drop down
                else
                {
                    newDrive = cmbLetters.SelectedValue.ToString();
                    newDrive += ":";
                }
                IWshNetwork_Class network = new IWshNetwork_Class();
                // take path that was entered by user
                newPath = txtDrivePath.Text;
                try
                {
                    network.MapNetworkDrive(newDrive, @newPath, true, Type.Missing, Type.Missing);
                    MessageBox.Show("Drive mapped: " + newDrive + " (" + newPath + ")", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("An Error has occurred: " + err.Message, "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCancelMap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

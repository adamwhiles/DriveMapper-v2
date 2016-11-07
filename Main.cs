using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using getDrives;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplication1;
using System.Collections;
using System.Text.RegularExpressions;

namespace DriveMapper_v2
{
    public partial class Main : Form
    {
        DataTable driveTable = new DataTable("Drives");
        DataColumn driveColumn;
        DataRow driveRow;
        BindingSource dBind = new BindingSource();

        public Main()
        {
            InitializeComponent();

            buildTable();
            fillTable();
            dataDrives.ColumnAdded += dataDrives_ColumnAdded;
        }

        public void buildTable()
        {
            // Build our data table headers and add names
            driveColumn = new DataColumn();
            driveColumn.DataType = System.Type.GetType("System.String");
            driveColumn.ColumnName = "Drive Letter";
            driveColumn.ReadOnly = true;
            driveColumn.Unique = true;
            driveTable.Columns.Add(driveColumn);
            driveColumn = new DataColumn();
            driveColumn.DataType = System.Type.GetType("System.String");
            driveColumn.ColumnName = "Drive Path";
            driveColumn.ReadOnly = true;
            driveColumn.Unique = true;
            driveTable.Columns.Add(driveColumn);
            // remove extra row from datagridview
            dataDrives.AllowUserToAddRows = false;
        }


        public void fillTable()
        {

            // Get a listing of all drives
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            // Loop through all the drives
            foreach (DriveInfo d in allDrives)
            {
                // Check if the current drive in the loop is a network drive or not
                if (d.DriveType == DriveType.Network && d.ToString() != null)
                {
                    Drive drive1 = new Drive();
                    drive1.driveLetter = d.ToString();
                    drive1.drivePath = Pathing.GetUNCPath(d.ToString());
                    // Add the drive letter and path to the datatable
                    driveRow = driveTable.NewRow();
                    driveRow["Drive Letter"] = drive1.driveLetter;
                    //MessageBox.Show("added" + drive1.driveLetter);
                    driveRow["Drive Path"] = drive1.drivePath;
                    driveTable.Rows.Add(driveRow);    
                    // Bind the datatable(driveTable) to the binding source and set the datagrid source to the table
                    dBind.DataSource = driveTable;
                    dataDrives.DataSource = dBind;
                    dataDrives.Refresh();
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Populate the datatable and datagrid with the latest mapped drive info
            driveTable.Clear();
            fillTable();
        }

        private void dataDrives_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Set column widths for the datagridview when a new column is added. hard coded for 2 columns only
            if(dataDrives.Columns.Count == 1)
            dataDrives.Columns[0].Width = 45;
            if (dataDrives.Columns.Count == 2)
            dataDrives.Columns[1].Width = 535;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDrives = new SaveFileDialog();
            exportDrives.DefaultExt = "txt";
            exportDrives.Filter = "txt files (*.txt)|*.txt";
            if (exportDrives.ShowDialog() == DialogResult.OK)
            {
                    string value = ""; // set string variable to hold each line before writing out to file
                    DataGridViewRow dr = new DataGridViewRow();

                    // open stream to input data into file
                    using (StreamWriter sw = new StreamWriter(exportDrives.FileName))
                    {
                        // loop through the rows and columns to format the data and add the comma
                        for (int i = 0; i <= dataDrives.Rows.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                sw.WriteLine();
                            }
                            dr = dataDrives.Rows[i];

                            for (int j = 0; j <= dataDrives.Columns.Count - 1; j++)
                            {
                                if (j > 0 && dr.Cells[j].FormattedValue.ToString() != "")
                                {
                                    sw.Write(",");
                                }
                                if (dr.Cells[j].FormattedValue.ToString() != "")
                                {
                                    value = dr.Cells[j].FormattedValue.ToString();
                                    sw.Write(value);
                                }
                            }
                        }
                        sw.Close();
                    } 
             }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SingleMap form2 = new SingleMap();
            form2.Show();
        }

        private void dataDrives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportMap form3 = new ImportMap();
            form3.Show();
        }

        static IEnumerable<string> ReadAsLines(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            Discover form4 = new Discover();
            form4.Show();
        }
    }
}

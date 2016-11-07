using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using IWshRuntimeLibrary;
using System.IO;
using System.Runtime.InteropServices;

namespace DriveMapper_v2
{
    public partial class ImportMap : Form
    {
        [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection(
            [MarshalAs(UnmanagedType.LPTStr)] string localName,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName,
            ref int length);
        DataColumn driveColumn;
        DataTable csvData = new DataTable();
        BindingSource dataBind = new BindingSource();
        IWshNetwork_Class network = new IWshNetwork_Class();
        DriveInfo[] usedDrives = DriveInfo.GetDrives();

        public ImportMap()
        {
            InitializeComponent();
            buildTable();
            importGrid.ColumnAdded += importGrid_ColumnAdded;
            importGrid.CellValueChanged += importGrid_CellValueChanged;
        }

        public void buildTable()
        {
            // Build our data table headers and add names
            driveColumn = new DataColumn();
            driveColumn.DataType = System.Type.GetType("System.String");
            driveColumn.ColumnName = "Drive Letter";
            driveColumn.ReadOnly = false;
            driveColumn.Unique = true;
            csvData.Columns.Add(driveColumn);
            driveColumn = new DataColumn();
            driveColumn.DataType = System.Type.GetType("System.String");
            driveColumn.ColumnName = "Drive Path";
            driveColumn.ReadOnly = false;
            driveColumn.Unique = true;
            csvData.Columns.Add(driveColumn);
            // remove extra row from datagridview
            importGrid.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog importDrives = new OpenFileDialog();
            importDrives.DefaultExt = "txt files(*.txt)|*.txt";
            DialogResult result = importDrives.ShowDialog();
            if (result == DialogResult.OK)
            {
                string csvFile = importDrives.FileName;
                GetDataTableFromCSV(csvFile);
            }
        }

        private void importGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Set column widths for the datagridview when a new column is added. hard coded for 2 columns only
            if (importGrid.Columns.Count == 1)
                importGrid.Columns[0].Width = 45;
            if (importGrid.Columns.Count == 2)
                importGrid.Columns[1].Width = 475;

        }

        private void importGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string changedLetter = importGrid.Rows[e.RowIndex].Cells[0].Value.ToString(); // Set the current value of the cell that was changed
            importGrid.Rows[e.RowIndex].Cells[0].ErrorText = ""; // Clear any current error text on the current cell
                foreach (DriveInfo d in usedDrives)
                {
                        if (d.Name == changedLetter)
                        {
                            importGrid.Rows[e.RowIndex].Cells[0].ErrorText = String.Format("Drive Letter is in use and mapped to: {0}", GetUNCPath(changedLetter)); //Sets the error text on the cell
                        }
                    }
        }

        public void GetDataTableFromCSV(string csvFile)
        {
                // call textfieldparser to read in the csv file
                using (TextFieldParser csvReader = new TextFieldParser(csvFile))
                {
                    csvReader.TextFieldType = FieldType.Delimited;
                    csvReader.SetDelimiters(",");

                    // read data into fields splitting on the delimiter until the eof is reached
                    while (!csvReader.EndOfData)
                    {
                        // put data into fields
                        string[] fieldData = csvReader.ReadFields();
                        // put fields into the datatable
                        csvData.Rows.Add(fieldData);
                    }
                    // bind the datatable to the grid
                    importGrid.DataSource = csvData;
                    foreach (DataGridViewRow row in importGrid.Rows)
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string driveLetter = cell.FormattedValue.ToString();
                            string drivePath = cell.FormattedValue.ToString();
                            foreach (DriveInfo d in usedDrives)
                            {
                                if (cell.OwningColumn.Name == "Drive Letter")
                                {
                                    if (d.Name == driveLetter)
                                    {
                                        cell.ErrorText = String.Format("Drive Letter is in use and mapped to: {0}", GetUNCPath(driveLetter)); //Sets the error text on the cell
                                    }
                                }

                                if (cell.OwningColumn.Name == "Drive Path")
                                {
                                    if (GetUNCPath(d.Name) == drivePath)
                                    {
                                        cell.ErrorText = String.Format("This path is already mapped to the drive letter: {0}", d.Name); //Sets the error text on the cell
                                    }
                                }
                            }
                        }
                    //Refresh the gridview to show the updated cells with any errors    
                    importGrid.Refresh();
                    // enable to button for mapping the imported drives
                    btnMapImported.Enabled = true;
                    // close csv file
                    csvReader.Close();
                }
            
        }

        public static string GetUNCPath(string originalPath)
        {
            StringBuilder sb = new StringBuilder(512);
            int size = sb.Capacity;

            // look for the {LETTER}: combination ...
            if (originalPath.Length > 2 && originalPath[1] == ':')
            {
                // don't use char.IsLetter here - as that can be misleading
                // the only valid drive letters are a-z && A-Z.
                char c = originalPath[0];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    int error = WNetGetConnection(originalPath.Substring(0, 2),
                        sb, ref size);
                    if (error == 0)
                    {
                        DirectoryInfo dir = new DirectoryInfo(originalPath);

                        string path = Path.GetFullPath(originalPath)
                            .Substring(Path.GetPathRoot(originalPath).Length);
                        return Path.Combine(sb.ToString().TrimEnd(), path);
                    }
                }
            }
            return originalPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Setup our base strings for the confirmation box after mapping has been attempted
            String mapErrors = "The following drives will not be mapped due to errors, please correct any errors and try again:";
            String mapValidated = "\n\nThe following drives will be mapped:";
            String driveLetter;
            String drivePath;
            // Setup the list that will hold the index of the rows that were mapped so they can be deleted after processing.
            List<int> removeRows = new List<int>();
            // Go through the rows and if no errors are found map the drive and remove from the list, if errors are found notify the user and do not map or remove from the list
            foreach (DataGridViewRow row in importGrid.Rows)
            {
                driveLetter = row.Cells[0].FormattedValue.ToString().TrimEnd('\\'); // Get the Drive Letter from the current row. Trim the slashes to prep the drive letter for mapping
                drivePath = row.Cells[1].FormattedValue.ToString(); // Get the Drive Path from the current row
                if (row.Cells[0].ErrorText == "" && row.Cells[1].ErrorText == "")
                {
                    try
                    {
                        // Map the drive of the current row if no errors were found
                        MessageBox.Show("Drive mapped: " + driveLetter + " (" + drivePath + ")", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        network.MapNetworkDrive(driveLetter, @drivePath, true, Type.Missing, Type.Missing);
                        mapValidated += String.Format("\n {0} ({1})", driveLetter, drivePath);
                        removeRows.Add(row.Index); // Add the current row index to the list to be deleted
                    }
                    catch (System.Exception err)
                    {
                        // Catch any errors in the mapping procedure and display those to the user
                        MessageBox.Show("An Error has occurred: " + err.Message, "",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }                    
                }
                else
                {
                    // If there are errors in the row, notify the user that the drive will not be mapped
                    mapErrors += String.Format("\n {0} ({1})", driveLetter, drivePath);
                    MessageBox.Show("Drive not mapped: " + driveLetter + " (" + drivePath + ")", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            //MessageBox.Show(string.Format("{0}{1}", mapErrors, mapValidated));
            removeRows.Reverse(); // Reverse the list so that when we remove the rows we do it from the bottom up
            foreach (int removeRow in removeRows) {
                importGrid.Rows.Remove(importGrid.Rows[removeRow]); // Remove the rows based on the indexes in the list
            }

        }
    }
}


 
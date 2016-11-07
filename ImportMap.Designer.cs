namespace DriveMapper_v2
{
    partial class ImportMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.importGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMapImported = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.importGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // importGrid
            // 
            this.importGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.importGrid.Location = new System.Drawing.Point(12, 12);
            this.importGrid.Name = "importGrid";
            this.importGrid.Size = new System.Drawing.Size(566, 150);
            this.importGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import Drives";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMapImported
            // 
            this.btnMapImported.Enabled = false;
            this.btnMapImported.Location = new System.Drawing.Point(334, 168);
            this.btnMapImported.Name = "btnMapImported";
            this.btnMapImported.Size = new System.Drawing.Size(120, 23);
            this.btnMapImported.TabIndex = 2;
            this.btnMapImported.Text = "Map Imported Drives";
            this.btnMapImported.UseVisualStyleBackColor = true;
            this.btnMapImported.Click += new System.EventHandler(this.button2_Click);
            // 
            // ImportMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 199);
            this.Controls.Add(this.btnMapImported);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.importGrid);
            this.Name = "ImportMap";
            this.ShowIcon = false;
            this.Text = "Import Drives from CSV";
            ((System.ComponentModel.ISupportInitialize)(this.importGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView importGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMapImported;
    }
}
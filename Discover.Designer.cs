namespace DriveMapper_v2
{
    partial class Discover
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
            this.dataGroups = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGroups
            // 
            this.dataGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGroups.Location = new System.Drawing.Point(12, 12);
            this.dataGroups.Name = "dataGroups";
            this.dataGroups.Size = new System.Drawing.Size(550, 217);
            this.dataGroups.TabIndex = 0;
            // 
            // Discover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 241);
            this.Controls.Add(this.dataGroups);
            this.Name = "Discover";
            this.ShowIcon = false;
            this.Text = "Discover Mappable Drives";
            ((System.ComponentModel.ISupportInitialize)(this.dataGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGroups;
    }
}
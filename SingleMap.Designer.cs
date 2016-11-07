namespace DriveMapper_v2
{
    partial class SingleMap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelMap = new System.Windows.Forms.Button();
            this.btnMapIt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDrivePath = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLetters = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelMap);
            this.groupBox1.Controls.Add(this.btnMapIt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDrivePath);
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbLetters);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Drive";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCancelMap
            // 
            this.btnCancelMap.Location = new System.Drawing.Point(281, 102);
            this.btnCancelMap.Name = "btnCancelMap";
            this.btnCancelMap.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMap.TabIndex = 6;
            this.btnCancelMap.Text = "Cancel";
            this.btnCancelMap.UseVisualStyleBackColor = true;
            this.btnCancelMap.Click += new System.EventHandler(this.btnCancelMap_Click);
            // 
            // btnMapIt
            // 
            this.btnMapIt.Location = new System.Drawing.Point(362, 102);
            this.btnMapIt.Name = "btnMapIt";
            this.btnMapIt.Size = new System.Drawing.Size(75, 23);
            this.btnMapIt.TabIndex = 5;
            this.btnMapIt.Text = "Map It!";
            this.btnMapIt.UseVisualStyleBackColor = true;
            this.btnMapIt.Click += new System.EventHandler(this.btnMapIt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path";
            // 
            // txtDrivePath
            // 
            this.txtDrivePath.Location = new System.Drawing.Point(44, 76);
            this.txtDrivePath.Name = "txtDrivePath";
            this.txtDrivePath.Size = new System.Drawing.Size(393, 20);
            this.txtDrivePath.TabIndex = 3;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(9, 55);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(109, 17);
            this.chkAuto.TabIndex = 2;
            this.chkAuto.Text = "Auto Select Drive";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drive Letter";
            // 
            // cmbLetters
            // 
            this.cmbLetters.FormattingEnabled = true;
            this.cmbLetters.Location = new System.Drawing.Point(74, 28);
            this.cmbLetters.Name = "cmbLetters";
            this.cmbLetters.Size = new System.Drawing.Size(38, 21);
            this.cmbLetters.TabIndex = 0;
            // 
            // SingleMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 163);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SingleMap";
            this.Text = "Add a New Mapped Drive";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelMap;
        private System.Windows.Forms.Button btnMapIt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDrivePath;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLetters;
    }
}
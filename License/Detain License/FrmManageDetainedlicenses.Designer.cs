namespace DVLD___Driving_Licenses_Managment.License.Detain_License
{
    partial class FrmManageDetainedlicenses
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsApplicationOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetainLincesesList = new System.Windows.Forms.DataGridView();
            this.pbReleaseLicense = new System.Windows.Forms.PictureBox();
            this.pbDetainLicense = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmsApplicationOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLincesesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReleaseLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetainLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(422, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 54);
            this.label1.TabIndex = 37;
            this.label1.Text = "Detained Driving Licenses";
            // 
            // cmsApplicationOptions
            // 
            this.cmsApplicationOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsApplicationOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonHistoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.releaseLicenseToolStripMenuItem});
            this.cmsApplicationOptions.Name = "contextMenuStrip1";
            this.cmsApplicationOptions.Size = new System.Drawing.Size(326, 138);
            this.cmsApplicationOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplicationOptions_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.flooding;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showLicenseToolStripMenuItem.Text = "Show License Details";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonHistoryToolStripMenuItem
            // 
            this.showPersonHistoryToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.isdn;
            this.showPersonHistoryToolStripMenuItem.Name = "showPersonHistoryToolStripMenuItem";
            this.showPersonHistoryToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showPersonHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(322, 6);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            this.releaseLicenseToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.unlock__1_;
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.releaseLicenseToolStripMenuItem.Text = "Release License";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecordNumber.Location = new System.Drawing.Point(122, 606);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(87, 38);
            this.lblRecordNumber.TabIndex = 43;
            this.lblRecordNumber.Text = "Number";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(14, 606);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(123, 38);
            this.lblRecordsNum.TabIndex = 42;
            this.lblRecordsNum.Text = "# Records: ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(349, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 26);
            this.textBox1.TabIndex = 41;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(118, 248);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 28);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 39;
            this.label2.Text = "Filter by:";
            // 
            // dgvDetainLincesesList
            // 
            this.dgvDetainLincesesList.AllowUserToAddRows = false;
            this.dgvDetainLincesesList.AllowUserToDeleteRows = false;
            this.dgvDetainLincesesList.AllowUserToOrderColumns = true;
            this.dgvDetainLincesesList.AllowUserToResizeColumns = false;
            this.dgvDetainLincesesList.AllowUserToResizeRows = false;
            this.dgvDetainLincesesList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvDetainLincesesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetainLincesesList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetainLincesesList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDetainLincesesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainLincesesList.ContextMenuStrip = this.cmsApplicationOptions;
            this.dgvDetainLincesesList.Location = new System.Drawing.Point(21, 287);
            this.dgvDetainLincesesList.Name = "dgvDetainLincesesList";
            this.dgvDetainLincesesList.ReadOnly = true;
            this.dgvDetainLincesesList.RowHeadersWidth = 50;
            this.dgvDetainLincesesList.RowTemplate.Height = 28;
            this.dgvDetainLincesesList.Size = new System.Drawing.Size(1167, 316);
            this.dgvDetainLincesesList.TabIndex = 36;
            // 
            // pbReleaseLicense
            // 
            this.pbReleaseLicense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbReleaseLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbReleaseLicense.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbReleaseLicense.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.unlock__1_;
            this.pbReleaseLicense.Location = new System.Drawing.Point(1071, 228);
            this.pbReleaseLicense.Name = "pbReleaseLicense";
            this.pbReleaseLicense.Size = new System.Drawing.Size(36, 36);
            this.pbReleaseLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReleaseLicense.TabIndex = 47;
            this.pbReleaseLicense.TabStop = false;
            this.toolTip1.SetToolTip(this.pbReleaseLicense, "Release");
            this.pbReleaseLicense.Click += new System.EventHandler(this.pbReleaseLicense_Click);
            this.pbReleaseLicense.MouseHover += new System.EventHandler(this.pbReleaseLicense_MouseHover);
            // 
            // pbDetainLicense
            // 
            this.pbDetainLicense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbDetainLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDetainLicense.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbDetainLicense.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.lock__3_;
            this.pbDetainLicense.Location = new System.Drawing.Point(1133, 228);
            this.pbDetainLicense.Name = "pbDetainLicense";
            this.pbDetainLicense.Size = new System.Drawing.Size(36, 36);
            this.pbDetainLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDetainLicense.TabIndex = 46;
            this.pbDetainLicense.TabStop = false;
            this.toolTip1.SetToolTip(this.pbDetainLicense, "Detain");
            this.pbDetainLicense.Click += new System.EventHandler(this.pbDetainLicense_Click);
            this.pbDetainLicense.MouseHover += new System.EventHandler(this.pbDetainLicense_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1088, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.close__1_;
            this.pictureBox1.Location = new System.Drawing.Point(512, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManageDetainedlicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1203, 689);
            this.Controls.Add(this.pbReleaseLicense);
            this.Controls.Add(this.pbDetainLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetainLincesesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManageDetainedlicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.FrmManageDetainedlicenses_Load);
            this.cmsApplicationOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLincesesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReleaseLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetainLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDetainLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem showPersonHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetainLincesesList;
        private System.Windows.Forms.PictureBox pbReleaseLicense;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
    }
}
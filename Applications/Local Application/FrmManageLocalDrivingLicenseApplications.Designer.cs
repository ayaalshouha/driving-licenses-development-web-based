namespace DVLD___Driving_Licenses_Managment
{
    partial class FrmManageLocalDrivingLicenseApplications
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
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalApplicationsList = new System.Windows.Forms.DataGridView();
            this.cmsApplicationOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ScheduletoolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoriticalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.isseDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatusChoices = new System.Windows.Forms.ComboBox();
            this.pbAddNewLocalApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApplicationsList)).BeginInit();
            this.cmsApplicationOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewLocalApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecordNumber.Location = new System.Drawing.Point(114, 597);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(87, 38);
            this.lblRecordNumber.TabIndex = 18;
            this.lblRecordNumber.Text = "Number";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(6, 597);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(123, 38);
            this.lblRecordsNum.TabIndex = 17;
            this.lblRecordsNum.Text = "# Records: ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(341, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 26);
            this.textBox1.TabIndex = 16;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(110, 239);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 28);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter by:";
            // 
            // dgvInternationalApplicationsList
            // 
            this.dgvInternationalApplicationsList.AllowUserToAddRows = false;
            this.dgvInternationalApplicationsList.AllowUserToDeleteRows = false;
            this.dgvInternationalApplicationsList.AllowUserToOrderColumns = true;
            this.dgvInternationalApplicationsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvInternationalApplicationsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationalApplicationsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalApplicationsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInternationalApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalApplicationsList.ContextMenuStrip = this.cmsApplicationOptions;
            this.dgvInternationalApplicationsList.Location = new System.Drawing.Point(13, 278);
            this.dgvInternationalApplicationsList.Name = "dgvInternationalApplicationsList";
            this.dgvInternationalApplicationsList.ReadOnly = true;
            this.dgvInternationalApplicationsList.RowHeadersWidth = 50;
            this.dgvInternationalApplicationsList.RowTemplate.Height = 28;
            this.dgvInternationalApplicationsList.Size = new System.Drawing.Size(1167, 316);
            this.dgvInternationalApplicationsList.TabIndex = 10;
            // 
            // cmsApplicationOptions
            // 
            this.cmsApplicationOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsApplicationOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem4,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ScheduletoolStripMenuItem7,
            this.toolStripMenuItem3,
            this.isseDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showPersonToolStripMenuItem});
            this.cmsApplicationOptions.Name = "contextMenuStrip1";
            this.cmsApplicationOptions.Size = new System.Drawing.Size(344, 296);
            this.cmsApplicationOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplicationOptions_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(340, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.edit;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.delete;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(340, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(340, 6);
            // 
            // ScheduletoolStripMenuItem7
            // 
            this.ScheduletoolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.theoriticalTestToolStripMenuItem,
            this.practicalTestToolStripMenuItem});
            this.ScheduletoolStripMenuItem7.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.schedule_scan;
            this.ScheduletoolStripMenuItem7.Name = "ScheduletoolStripMenuItem7";
            this.ScheduletoolStripMenuItem7.Size = new System.Drawing.Size(343, 32);
            this.ScheduletoolStripMenuItem7.Text = "Schadule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.eye_chart;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.visionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // theoriticalTestToolStripMenuItem
            // 
            this.theoriticalTestToolStripMenuItem.Enabled = false;
            this.theoriticalTestToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.text_message;
            this.theoriticalTestToolStripMenuItem.Name = "theoriticalTestToolStripMenuItem";
            this.theoriticalTestToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.theoriticalTestToolStripMenuItem.Text = "Schedule Writtien Test";
            this.theoriticalTestToolStripMenuItem.Click += new System.EventHandler(this.theoriticalTestToolStripMenuItem_Click);
            // 
            // practicalTestToolStripMenuItem
            // 
            this.practicalTestToolStripMenuItem.Enabled = false;
            this.practicalTestToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.car_alarm;
            this.practicalTestToolStripMenuItem.Name = "practicalTestToolStripMenuItem";
            this.practicalTestToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.practicalTestToolStripMenuItem.Text = "Schedule Street Test";
            this.practicalTestToolStripMenuItem.Click += new System.EventHandler(this.practicalTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(340, 6);
            // 
            // isseDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.flooding;
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Name = "isseDrivingLicenseFirstTimeToolStripMenuItem";
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First time)";
            this.isseDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.isseDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(340, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.flooding;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(340, 6);
            // 
            // showPersonToolStripMenuItem
            // 
            this.showPersonToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.account_settings;
            this.showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            this.showPersonToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.showPersonToolStripMenuItem.Text = "Show Person License History";
            this.showPersonToolStripMenuItem.Click += new System.EventHandler(this.showPersonToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(395, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 54);
            this.label1.TabIndex = 11;
            this.label1.Text = "Local Drining License Applications";
            // 
            // cbStatusChoices
            // 
            this.cbStatusChoices.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbStatusChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusChoices.FormattingEnabled = true;
            this.cbStatusChoices.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatusChoices.Location = new System.Drawing.Point(342, 239);
            this.cbStatusChoices.Name = "cbStatusChoices";
            this.cbStatusChoices.Size = new System.Drawing.Size(117, 28);
            this.cbStatusChoices.TabIndex = 22;
            this.cbStatusChoices.Visible = false;
            this.cbStatusChoices.SelectedIndexChanged += new System.EventHandler(this.cbStatusChoices_SelectedIndexChanged);
            // 
            // pbAddNewLocalApplication
            // 
            this.pbAddNewLocalApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddNewLocalApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddNewLocalApplication.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbAddNewLocalApplication.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.horizontal_line;
            this.pbAddNewLocalApplication.Location = new System.Drawing.Point(1122, 219);
            this.pbAddNewLocalApplication.Name = "pbAddNewLocalApplication";
            this.pbAddNewLocalApplication.Size = new System.Drawing.Size(34, 34);
            this.pbAddNewLocalApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddNewLocalApplication.TabIndex = 23;
            this.pbAddNewLocalApplication.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAddNewLocalApplication, "Add");
            this.pbAddNewLocalApplication.Click += new System.EventHandler(this.pbAddNewLocalApplication_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pictureBox2.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pictureBox2.Location = new System.Drawing.Point(869, 164);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.compare_documents__1_;
            this.pictureBox1.Location = new System.Drawing.Point(537, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(1080, 611);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1252, 678);
            this.Controls.Add(this.pbAddNewLocalApplication);
            this.Controls.Add(this.cbStatusChoices);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInternationalApplicationsList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManageLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.FrmManageLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApplicationsList)).EndInit();
            this.cmsApplicationOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewLocalApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalApplicationsList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbStatusChoices;
        private System.Windows.Forms.PictureBox pbAddNewLocalApplication;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationOptions;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem isseDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduletoolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoriticalTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicalTestToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}